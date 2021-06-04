using System;
using System.Collections.Generic;
using System.Text;
using HelloWorld.Models;
using HelloWorld.DAO;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("HelloWorldTests")]
namespace HelloWorld
{
    public class PreProgram : IDisposable
    {
        internal static IDataAccessObjects DAO;
        private bool disposedValue;


        public PreProgram()
        {

        }

        static PreProgram()
        {

        }

        internal static void Main() 
        {
            using var dao = new DataAccessObjects();
            if (Initialize(dao))
            {
                var rowCnt = ParseInfo();
                Console.WriteLine(@"Number of rows written: " + rowCnt);
            }
        }

        internal static bool Initialize(DataAccessObjects dao)
        {
            bool retType;
            try
            {
                retType = (DAO = dao.InitializeDAO()) != null;
                
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
            var recs = DAO.GetInvoiceTotalsByPriceRange(10.00M, 30.00M)
                    .OrderBy(x => x.AlbumTitle)
                    .ThenBy(x => x.ArtistsName)
                    .ThenBy(x => x.TrackName);

            if (recs.Count() > 0)
            {
                StringBuilder sb = new StringBuilder(5000);

                sb.Append(@"InvoiceLineID, MediaTrackID, AlbumTitle, ArtistsName,TrackName, MediaType, UnitPrice, Quantity");
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
                    Console.WriteLine(sb.ToString());
                    ++recCount;
                }
            }
            else
            {
                Console.WriteLine(@"No Rows Returned");
            }

            return recCount;
        }

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
    }
}
