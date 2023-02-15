using System.Threading.Tasks;
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using GVArchiveOps.DataModels;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;
using System.Data;

[assembly: InternalsVisibleTo("GVArchiveTests")]
namespace GVArchiveOps
{
    public interface IGVArchive : IDisposable
    {
        string? ConnString { get; set; }
        bool CreateTempTable();
        bool UploadTempTable(DataTable dt);
        bool InsertIntoLiveTable();
        bool DropTempTable();


        IDataModel? model { get; }
        List<DataModel>? Models { get; }
        void CreateModels();
        List<DataModel>? FileReadyForImport(FileInfo inputFile);
    }

    public class GVArchive : IGVArchive
    {

        #region Properties
        public IDataModel? model { get; set; }
        public List<DataModel>? Models { get; set; }
        public string? ConnString { get; set; }
        private SqlConnection? conn;


        #endregion


        #region CRUD OPS
        //CRUD OPERATIONS
        public void CreateModels()
        {
            this.Models = new List<DataModel>();
        }

        public bool CreateTempTable()
        {
            //ConnString = Environment.GetEnvironmentVariable("GVArchiveConnString");

            try
            {
                using (conn = new SqlConnection(this.ConnString))
                {
                    conn.Open();

                    var sql = @"
                            CREATE TABLE [TempIncidents](
	                            [TempIncidentID] [int] NOT NULL,
	                            [TempIncidentDate] [datetime] NOT NULL,
	                            [TempIncidentState] [varchar](60) NOT NULL,
	                            [TempLocale] [varchar](200) NULL,
	                            [TempAddress] [varchar](70) NULL,
	                            [TempNumFatalities] [int] NOT NULL,
	                            [TempNumInjured] [int] NOT NULL,
	                            [TempOperations] [varchar](60) NULL,
                             CONSTRAINT [PK_TempIncidents] PRIMARY KEY CLUSTERED 
                            (
	                            [TempIncidentID] ASC,
	                            [TempIncidentDate] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                            ) ON [PRIMARY]
                            ";

                    return conn.Execute(sql) < 0;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UploadTempTable(DataTable dt)
        {
            using (conn = new SqlConnection(this.ConnString))
            {
                conn.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName = dt.TableName;
                    try
                    {
                        bulkCopy.WriteToServer(dt);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return false;
                    }
                }
            }
        }

        public bool InsertIntoLiveTable()
        {
            using (conn = new SqlConnection(this.ConnString))
            {
                conn.Open();

                var sql = @"
                            INSERT INTO [dbo].[Incidents]
                                (
	                                [IncidentID],[IncidentDate],[IncidentState],[Locale],
                                    [Address],[NumFatalities],[NumInjured],[Operations]
                                )
                            SELECT [TempIncidentID],[TempIncidentDate],[TempIncidentState],[TempLocale],
                                   [TempAddress],[TempNumFatalities],[TempNumInjured],[TempOperations]
                            FROM [#TempIncidents]
                            LEFT OUTER JOIN [dbo].[Incidents] WITH (NOLOCK)
                                ON [TempIncidentID] = [IncidentID]
                            WHERE [IncidentID] IS NULL
                            ";

                conn.Query(sql);
            }

            return true;
        }

        public bool DropTempTable()
        {
            try
            {
                using (conn = new SqlConnection(this.ConnString))
                {
                    conn.Open();

                    var sql = @"DROP TABLE [TempIncidents]";

                    conn.Query(sql);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        #endregion

        #region File Ops
        public List<DataModel>? FileReadyForImport(FileInfo inputFile)
        {

            CreateModels();

            string? line;

            using (var sr = new StreamReader(inputFile.FullName))
            {
                sr.ReadLine(); //ignore the header

                while ((line = sr.ReadLine()) != null)
                {
                    var lineArr = line.Split(',');

                    var testDt = $"{lineArr[1]} {lineArr[2].Trim()}";


                    DataModel model = new DataModel()
                    {
                        IncidentID = int.TryParse(lineArr[0], out int incID) ? incID : 0,
                        IncidentDate = DateTime.TryParse(lineArr[1], out DateTime incDt) ? incDt : DateTime.Today,
                        IncidentState = !string.IsNullOrEmpty(lineArr[2]) ? lineArr[2] : string.Empty,
                        Locale = !string.IsNullOrEmpty(lineArr[3]) ? lineArr[3] : string.Empty,
                        Address = !string.IsNullOrEmpty(lineArr[4]) ? lineArr[4] : string.Empty,
                        NumFatalities = int.TryParse(lineArr[5], out int numFatal) ? numFatal : 0,
                        NumInjured = int.TryParse(lineArr[6], out int numInjured) ? numInjured : 0,
                        Operations = !string.IsNullOrEmpty(lineArr[7]) ? lineArr[7] : string.Empty
                    };
                    this.Models?.Add(model);
                }
            }
            return this.Models;
        }



        #endregion


        #region Disposable

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~GVArchive()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


        #endregion


    }
}