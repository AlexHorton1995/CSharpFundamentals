using System;
using System.Text;
using HelloWorld.DAO;
using System.Linq;
using System.Runtime.CompilerServices;
using HelloWorld.Models;
using OfficeOpenXml;
using System.IO;

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
            //this has to be here for the excel license
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(@"B:\OneDrive\Documents\MyWorkbook.xlsx")))
            {

                var sheet1 = package.Workbook.Worksheets.Add("Sheet1");

                //var sheet1 = package.Workbook.Worksheets["Sheet1"];
                sheet1.Cells[1, 1].Value = "dis some sheet here";
                sheet1.Cells[1, 1].Style.Font.Bold = true;

                package.Save();
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
