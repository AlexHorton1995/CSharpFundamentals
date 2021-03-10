using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace FileMover
{
    class Program
    {
        //Instantiate static IConfiguration object
        public static IConfiguration _Config { get; set; }
        public static LogLines Log { get; set; }

        static void Main(string[] args)
        {
            //create new configuration object
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            //get location of files from commandline args

            string sourcePath = string.Empty, destinationPath = string.Empty;

            foreach (var str in args.ToList())
            {
                var splitArgs = str.Split('=', StringSplitOptions.None);

                if (splitArgs[0].Contains("Source", StringComparison.OrdinalIgnoreCase))
                    sourcePath = splitArgs[1].Replace('_', ' ');

                if (splitArgs[0].Contains("Dest", StringComparison.OrdinalIgnoreCase))
                    destinationPath = splitArgs[1].Replace('_', ' ');

            }


            //Load the configuration to the class object
            _Config = configuration.Build();

            //retrieve the connection string here
            var connString = _Config.GetConnectionString("DefaultConnection");



            if (!InsertData(connString, FindAndMoveFiles(sourcePath, destinationPath)))
                Console.Write(@"Issue with inserting log into table.");

        }

        static IEnumerable<string> FindAndMoveFiles(string sourcePath, string destinationPath)
        {
            List<string> returnList = new List<string>();

            try
            {
                int currentYear = DateTime.Now.Year;
                //set our input file directory
                Directory.SetCurrentDirectory(sourcePath);

                List<string> FolderList = new List<string>();

                //get the list of folders here
                var filePath = Directory.GetCurrentDirectory();
                var files = Directory.GetDirectories(sourcePath).AsList();


                //create a list of directory names here
                foreach (var fi in files)
                {
                    var folder = string.Format(@"{0}\{1}\{2}", filePath, Path.GetFileName(fi), currentYear);

                    FolderList.Add(folder);
                }

                //Contributions First
                var contFolderDirectory = FolderList.Where(x => x.Contains(@"Contributions", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                var ContFiles = Directory.GetFiles(contFolderDirectory).ToList();

                //Capital Improvement Next
                var capImpFolderDirectory = FolderList.Where(x => x.Contains(@"Capital Improvement", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                var CapImpFiles = Directory.GetFiles(capImpFolderDirectory).ToList();

                //Special Offering Last
                var sOffFolderDirectory = FolderList.Where(x => x.Contains(@"Special Offering", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                var sOffImpFiles = Directory.GetFiles(sOffFolderDirectory).ToList();

                //Safe check to make sure the destination path exists.
                if (Directory.Exists(destinationPath))
                {
                    #region Contributions
                    foreach (var cFile in ContFiles)
                    {
                        var cFileName = Path.GetFileName(cFile);
                        var newCFileName = string.Format(@"{0}\{1}\{2}", destinationPath, currentYear, cFileName);

                        File.Move(cFile, newCFileName);

                        //make sure the new file is there.
                        if (File.Exists(newCFileName))
                            File.Delete(cFile);

                        returnList.Add(newCFileName);
                    }
                    #endregion

                    #region Capital Improvement
                    foreach (var capFile in CapImpFiles)
                    {
                        var capFileName = Path.GetFileName(capFile);
                        var newCapFileName = string.Format(@"{0}\Capital Improvement\{1}\{2}", destinationPath, currentYear, capFileName);
                        File.Move(capFile, newCapFileName);

                        //make sure the new file is there.
                        if (File.Exists(newCapFileName))
                            File.Delete(capFile);

                        returnList.Add(newCapFileName);
                    }
                    #endregion

                    #region Special Offering
                    foreach (var sOffFile in sOffImpFiles)
                    {
                        var sOffFileName = Path.GetFileName(sOffFile);
                        var newSOffFileName = string.Format(@"{0}\Special Offering\{1}\{2}", destinationPath, currentYear, sOffFileName);
                        File.Move(sOffFile, newSOffFileName);

                        //make sure the new file is there.
                        if (File.Exists(newSOffFileName))
                            File.Delete(sOffFile);

                        returnList.Add(newSOffFileName);
                    }
                    #endregion
                }

                return returnList;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        static bool InsertData(string connString, IEnumerable<string> ListOfFiles)
        {
            List<LogLines> insertLines = new List<LogLines>();
            try
            {
                foreach (var fileLog in ListOfFiles)
                {
                    Log = new LogLines()
                    {
                        ID = Guid.NewGuid().ToString(),
                        InsertDate = DateTime.Today.Date,
                        Status = true,
                        FileName = Path.GetFileNameWithoutExtension(fileLog),
                        FileType = Path.GetExtension(fileLog)
                    };
                    insertLines.Add(Log);
                }

                using (var conn = new SqlConnection(connString))
                {
                    //SQL QUERY HERE

                    var sql = @"
            INSERT INTO MoverStatusLog (
                [id]
               ,[insert_date]
               ,[status]
               ,[file_name]
               ,[file_type]) 
            VALUES
                (@ID, @InsertDate, @Status, @FileName, @FileType)
            ";

                    conn.Open();

                    foreach (var line in insertLines)
                    {
                        var result = conn.Execute(sql,
                            new
                            {
                                ID = line.ID,
                                InsertDate = line.InsertDate,
                                Status = line.Status,
                                FileName = line.FileName,
                                FileType = line.FileType
                            });
                    }

                    //var getRows = conn.ExecuteScalar(sql); //Dapper Query
                }
                Console.Write(@"Inserted log row into table.");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }

    public class LogLines
    {
        public String ID { get; set; }
        public DateTime InsertDate { get; set; }
        public bool Status { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
    }
}
