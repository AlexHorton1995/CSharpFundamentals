using System;
using System.Text;
using HelloWorld.DAO;
using System.Linq;
using System.Runtime.CompilerServices;
using HelloWorld.Models;
using OfficeOpenXml;
using System.IO;
using System.Collections.Generic;
using Hortography;
using System.Security.Cryptography;

[assembly: InternalsVisibleTo("HelloWorldTests")]
namespace HelloWorld
{
    public class PreProgram : IDisposable
    {
        internal static IDataAccessObjects DAO;
        internal static IHortography Encryption;
        internal static byte[] _EncryptedKeyBytes;
        internal static string _EncryptedKeyValue; //pass this in from the commandline
        private bool disposedValue;
        internal static ExcelPackage exPack;

        public PreProgram()
        {

        }

        static PreProgram()
        {

        }

        internal static void Main(string[] args)
        {
            using var dao = new DataAccessObjects();
            if (Initialize(dao, args))
            {
                var rowCnt = ParseInfo();
                Console.WriteLine(@"Number of rows written: " + rowCnt);
            }
        }

        internal static bool Initialize(DataAccessObjects dao, string[] args)
        {
            bool retType;
            try
            {

                var conSelection = args[0].Split(':').ToList()[1];
                _EncryptedKeyValue = args[1].Split(':').ToList()[1];
                retType = (DAO = dao.InitializeDAO(conSelection)) != null;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                retType = false;
            }
            return retType;
        }

        internal static int ParseInfo()
        {
            int recCount = 0;

            try
            {

                var recs = DAO.GetInvoiceTotalsByPriceRange(10.00M, 30.00M)
                        .OrderBy(x => x.AlbumTitle)
                        .ThenBy(x => x.ArtistsName)
                        .ThenBy(x => x.TrackName);


                if (recs.Count() > 0)
                {
                    DisplayInExcel(recs);
                }
                else
                {
                    Console.WriteLine(@"No Rows Returned");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an exception during ParseInfo(): " + e.StackTrace);
            }

            return recCount;
        }

        internal static bool EncryptKey()
        {
            try
            {
                using (Aes aEncrypt = Aes.Create())
                {
                    var keyIn = Encoding.UTF8.GetBytes(_EncryptedKeyValue);

                    _EncryptedKeyBytes = Encryption.EncryptStringtoBytes(_EncryptedKeyValue, keyIn, aEncrypt.IV);
                }
                return _EncryptedKeyBytes != null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        internal static string DecryptKey()
        {
            string retString = null;
            try
            {
                using (Aes aDecrypt = Aes.Create())
                {
                    var keyIn = Encoding.UTF8.GetBytes(_EncryptedKeyValue);
                    retString = Encryption.DecryptBytesToPlainTextString(keyIn, keyIn, aDecrypt.IV);
                }
                return retString;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return retString;
            }
        }

        internal static void DisplayInExcel(IOrderedEnumerable<QueryModel> items)
        {
            try
            {
                //prepare to encrypt the file
                Encryption = new Hortography.Hortography();
                EncryptKey();

                //this has to be here for the excel license
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(new FileInfo(string.Format(@"{0}Report_{1}.xlsx", DAO.FileLocation, DateTime.Now.ToString("MMddyyyy_HHmmss")))))
                {
                    var sheet1 = package.Workbook.Worksheets.Add("Sheet1");

                    //add header row first
                    HashSet<string> header = new HashSet<string>()
                    {
                        "InvoiceLineID","MediaTrackID","AlbumTitle","ArtistsName","TrackName",
                        "MediaType","UnitPrice","Quantity"
                    };

                    int colInt = 1;
                    int rowInt = 1;

                    foreach (var cell in header)
                    {
                        sheet1.Cells[1, colInt].Value = cell;
                        sheet1.Cells[1, colInt].Style.Font.Bold = true;
                        ++colInt;
                    }

                    //reset the column to the first column
                    colInt = 1;
                    rowInt = 2;

                    foreach (var item in items)
                    {
                        sheet1.Cells[rowInt, 1].Value = item.InvoiceLineID;
                        sheet1.Cells[rowInt, 2].Value = item.MediaTrackID;
                        sheet1.Cells[rowInt, 3].Value = item.AlbumTitle;
                        sheet1.Cells[rowInt, 4].Value = item.ArtistsName;
                        sheet1.Cells[rowInt, 5].Value = item.TrackName;
                        sheet1.Cells[rowInt, 6].Value = item.MediaType;
                        sheet1.Cells[rowInt, 7].Value = item.UnitPrice;
                        sheet1.Cells[rowInt, 8].Value = item.Quantity;

                        ++rowInt;
                    }
                    package.Save(_EncryptedKeyValue);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        internal static void OpenInExcel()
        {
            try
            {
                //Get the Encrypted Password
                Encryption = new Hortography.Hortography();
                var getKey = DecryptKey();

                //this has to be here for the excel license
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                FileInfo existingFile = new FileInfo("");
                using (ExcelPackage package = new ExcelPackage(existingFile, getKey))
                {
                    //get the first worksheet in the workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                    int colCount = worksheet.Dimension.End.Column;  //get Column Count
                    int rowCount = worksheet.Dimension.End.Row;     //get row count
                    for (int row = 1; row <= rowCount; row++)
                    {
                        for (int col = 1; col <= colCount; col++)
                        {
                            Console.WriteLine(" Row:" + row + " column:" + col + " Value:" + worksheet.Cells[row, col].Value.ToString().Trim());
                        }
                    }
                }

                //using (var package = new ExcelPackage(new FileInfo(string.Format(@"{0}Report_{1}.xlsx", DAO.FileLocation, DateTime.Now.ToString("MMddyyyy_HHmmss")))))
                //{
                //    var sheet1 = package.Workbook.Worksheets.Add("Sheet1");

                //    //add header row first
                //    HashSet<string> header = new HashSet<string>()
                //    {
                //        "InvoiceLineID","MediaTrackID","AlbumTitle","ArtistsName","TrackName",
                //        "MediaType","UnitPrice","Quantity"
                //    };

                //    int colInt = 1;
                //    int rowInt = 1;

                //    foreach (var cell in header)
                //    {
                //        sheet1.Cells[1, colInt].Value = cell;
                //        sheet1.Cells[1, colInt].Style.Font.Bold = true;
                //        ++colInt;
                //    }

                //    //reset the column to the first column
                //    colInt = 1;
                //    rowInt = 2;

                //    foreach (var item in items)
                //    {
                //        sheet1.Cells[rowInt, 1].Value = item.InvoiceLineID;
                //        sheet1.Cells[rowInt, 2].Value = item.MediaTrackID;
                //        sheet1.Cells[rowInt, 3].Value = item.AlbumTitle;
                //        sheet1.Cells[rowInt, 4].Value = item.ArtistsName;
                //        sheet1.Cells[rowInt, 5].Value = item.TrackName;
                //        sheet1.Cells[rowInt, 6].Value = item.MediaType;
                //        sheet1.Cells[rowInt, 7].Value = item.UnitPrice;
                //        sheet1.Cells[rowInt, 8].Value = item.Quantity;

                //        ++rowInt;
                //    }
                //    package.Save(_EncryptedKeyValue);
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }


        #region Disposable

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (DAO != null)
                    {

                    }
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~PreProgram()
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
