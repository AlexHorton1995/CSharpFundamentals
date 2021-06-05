using System;
using System.Text;
using HelloWorld.DAO;
using System.Linq;
using System.Runtime.CompilerServices;
using HelloWorld.Models;
using OfficeOpenXml;
using System.IO;
using System.Collections.Generic;

[assembly: InternalsVisibleTo("HelloWorldTests")]
namespace HelloWorld
{
    public class PreProgram : IDisposable
    {
        internal static IDataAccessObjects DAO;
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

                var conSelection = args[0].Split(':').ToList();
                retType = (DAO = dao.InitializeDAO(conSelection[1])) != null;
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

                DisplayInExcel(recs);

                if (recs.Count() > 0)
                {
                    StringBuilder sb = new StringBuilder(5000);

                    sb.Append(@"InvoiceLineID,MediaTrackID,AlbumTitle,ArtistsName,TrackName,MediaType,UnitPrice,Quantity");
                    Console.WriteLine(sb.ToString());
                    foreach (var rec in recs)
                    {
                        sb = new StringBuilder(5000);
                        sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7}",
                            rec.InvoiceLineID,
                            rec.MediaTrackID,
                            rec.AlbumTitle,
                            rec.ArtistsName,
                            rec.TrackName,
                            rec.MediaType,
                            rec.UnitPrice,
                            rec.Quantity);
                        //Console.WriteLine(sb.ToString());
                        ++recCount;
                    }
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

        internal static void DisplayInExcel(IOrderedEnumerable<QueryModel> items)
        {
            try
            {

                //this has to be here for the excel license
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(new FileInfo(string.Format(@"B:\OneDrive\Documents\MyWorkbook_{0}.xlsx", DateTime.Now.ToString("MMddyyyy_HHmmss")))))
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

                    foreach(var cell in header)
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

                    package.Save();
                }
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
