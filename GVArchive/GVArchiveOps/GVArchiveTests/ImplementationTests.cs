using GVArchiveOps;
using GVArchiveOps.DataModels;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

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
        public void TestCreateAndDropTempTable()
        {
            mockArchive.ConnString = "Data Source=DESKTOP-C1TJG0L;Initial Catalog=GVArchive;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var actual = this.mockArchive?.CreateTempTable();
            var actual2 = this.mockArchive?.DropTempTable();

            Assert.IsTrue(actual);
            Assert.IsTrue(actual2);
        }

        [TestMethod]
        public void TestBulkCopy() 
        {
            this.mockArchive.ConnString = "Data Source=DESKTOP-C1TJG0L;Initial Catalog=GVArchive;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var isCreated = this.mockArchive?.CreateTempTable();
            
            DataTable dataTable = new DataTable("TempIncidents");
            dataTable.Columns.Add("TempIncidentID", typeof(int));
            dataTable.Columns.Add("TempIncidentDate", typeof(DateTime));
            dataTable.Columns.Add("TempIncidentState", typeof(string));
            dataTable.Columns.Add("TempLocale", typeof(string));
            dataTable.Columns.Add("TempAddress", typeof(string));
            dataTable.Columns.Add("TempNumFatalities", typeof(int));
            dataTable.Columns.Add("TempNumInjured", typeof(int));
            dataTable.Columns.Add("TempOperations", typeof(string));

            DataRow row = dataTable.NewRow();

            row["TempIncidentID"] = 1;
            row["TempIncidentDate"] = DateTime.Now;
            row["TempIncidentState"] = "Texas";
            row["TempLocale"] = "Houston";
            row["TempAddress"] = "123 Anywhere USA";
            row["TempNumFatalities"] = 1;
            row["TempNumInjured"] = 1;
            row["TempOperations"] = "N/A";

            dataTable.Rows.Add(row);

            var isUploaded = this.mockArchive.UploadTempTable(dataTable);
            var isDropped = this.mockArchive.DropTempTable();

            Assert.IsTrue(isCreated);
            Assert.IsTrue(isUploaded);
            Assert.IsTrue(isDropped);

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
                IncidentID = 2516643,
                IncidentDate = new DateTime(2023, 02, 02),
                IncidentState = "Texas",
                Locale = "Houston",
                Address = "6425 Westheimer Rd",
                NumFatalities = 0,
                NumInjured = 1,
                Operations = "N/A"
            };

            //ACT
            var actual = this.mockArchive?.FileReadyForImport(fileIn)?.Where(x => x.IncidentID == 2516643).FirstOrDefault();

            //ASSERT
            Assert.AreEqual(expected.IncidentID, actual?.IncidentID);
            Assert.AreEqual(expected.IncidentDate, actual?.IncidentDate);
            Assert.AreEqual(expected.IncidentState, actual?.IncidentState);
            Assert.AreEqual(expected.Locale, actual?.Locale);
            Assert.AreEqual(expected.Address, actual?.Address);
            Assert.AreEqual(expected.NumFatalities, actual?.NumFatalities);
            Assert.AreEqual(expected.NumInjured, actual?.NumInjured);
            Assert.AreEqual(expected.Operations, actual?.Operations);
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
