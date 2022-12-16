using GVArchiveOps;
using GVArchiveOps.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVArchiveTests
{
    [TestClass]
    public class ImplementationTests : IDisposable
    {
        internal IGVArchive? mockArchive;
        internal FileInfo? file;

        [TestInitialize]
        public void TestInitialize()
        {
            mockArchive = new GVArchive();
            Environment.CurrentDirectory = @"C:\CodeRepo";
        }


        [TestMethod]
        public void TestFileReadyForImport()
        {
            //ARRANGE
            //var fileIn = new FileInfo(@".\GVArchive\GVArchiveOps\GVArchiveTests\Resources\TestFile.csv");
            var fileIn = new FileInfo($@"{Environment.CurrentDirectory}\GVArchiveData\AccidentalDeath.csv");

            //2473638,December 3, 2022,Kentucky,Louisville,4500 E Pages Lane,4,0,N/A
            DataModel? expected = new DataModel()
            {
                IncidentID = 2475720,
                IncidentDate = new DateTime(2022, 12, 6),
                IncidentState = "New York",
                Locale = "Syracuse",
                Address = "573 Delaware St",
                NumFatalities = 1,
                NumInjured = 0,
                Operations = "N/A"
            };

            //ACT
            var actual = this.mockArchive?.FileReadyForImport(fileIn).Where(x => x.IncidentID == 2475720).FirstOrDefault();

            //ASSERT
            Assert.AreEqual(expected?.IncidentID, actual?.IncidentID);
            Assert.AreEqual(expected?.IncidentDate, actual?.IncidentDate);
            Assert.AreEqual(expected?.IncidentState, actual?.IncidentState);
            Assert.AreEqual(expected?.Locale, actual?.Locale);
            Assert.AreEqual(expected?.Address, actual?.Address);
            Assert.AreEqual(expected?.NumFatalities, actual?.NumFatalities);
            Assert.AreEqual(expected?.NumInjured, actual?.NumInjured);
            Assert.AreEqual(expected?.Operations, actual?.Operations);
        }

        #region Disposable
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (mockArchive != null)
                    {
                        mockArchive?.Dispose();
                    }
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitTest1()
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
