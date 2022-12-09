using GVArchiveOps;
using GVArchiveOps.DataModels;
using GVArchiveTests.MockClasses;
using GVArchiveTests.Properties;

namespace GVArchiveTests
{
    [TestClass]
    public class UnitTest1 : IDisposable
    {
        internal MockDataModel? mockModel;
        internal IGVArchive? mockArchive;
 

        [TestInitialize]
        public void TestInitialize()
        {
            Environment.CurrentDirectory = @"C:\CodeRepo";
            mockArchive = new GVArchive();
            mockModel = new MockDataModel();
        }

        [TestMethod]
        public void TestNewDataModels()
        {
            //Arrange
            this.mockModel = new MockDataModel();

            //Act
            this.mockModel.Initialize();

            //Assert
            Assert.IsNotNull(this.mockModel); 
            Assert.IsTrue(this.mockModel.IncidentID == 0);
            Assert.IsTrue(this.mockModel.IncidentDate == DateTime.Today);
            Assert.IsTrue(this.mockModel.IncidentState == null);
            Assert.IsTrue(this.mockModel.Locale == null);
            Assert.IsTrue(this.mockModel.Address == null);
            Assert.IsTrue(this.mockModel.NumFatalities == 0);
            Assert.IsTrue(this.mockModel.NumInjured == 0);
            Assert.IsTrue(this.mockModel.Operations == null);


        }

        [TestMethod]
        public void TestCreateModels()
        {
            this.mockArchive?.CreateModels();
            Assert.IsNotNull(this.mockArchive?.Models);
        }

        [TestMethod]
        public void TestFileReadyForImport()
        {
            //ARRANGE
            var fileIn = new FileInfo(@".\GVArchive\GVArchiveOps\GVArchiveTests\Resources\TestFile.csv");

            //2473638,December 3, 2022,Kentucky,Louisville,4500 E Pages Lane,4,0,N/A
            DataModel? expected = new DataModel()
            {
                IncidentID = 2473638,
                IncidentDate = new DateTime(2022, 12, 3),
                IncidentState = "Kentucky",
                Locale = "Louisville",
                Address = "4500 E Pages Lane",
                NumFatalities = 4,
                NumInjured = 0,
                Operations = "N/A"
            };

            //ACT
            var actual = this.mockArchive?.FileReadyForImport(fileIn).Where(x => x.IncidentID == 2473638).FirstOrDefault();

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

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    mockArchive?.Dispose();
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
    }
}