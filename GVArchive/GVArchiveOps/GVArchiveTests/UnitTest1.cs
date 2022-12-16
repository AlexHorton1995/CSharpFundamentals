using FluentAssertions;
using GVArchiveOps;
using GVArchiveOps.DataModels;
using Moq;

namespace GVArchiveTests
{
    [TestClass]
    public class UnitTest1 : IDisposable
    {
        internal Mock<IDataModel>? mockData;
        internal Mock<IGVArchive>? mockGVArchive;
        internal Mock<IDataModel>? mockModel;


        [TestInitialize]
        public void TestInitialize()
        {
            mockData = new Mock<IDataModel>();
            mockGVArchive = new Mock<IGVArchive>();
            Environment.CurrentDirectory = @"C:\CodeRepo";
            mockModel = new Mock<IDataModel>();
        }

        [TestMethod]
        public void TestNewDataModels()
        {
            var testmodel = new DataModel()
            {
                IncidentID = 15,
                IncidentDate = DateTime.Today,
                IncidentState = "Nebraska",
                Locale = "Omaha",
                Address = "123 Anywhere",
                NumFatalities = 1,
                NumInjured = 5,
                Operations = "N/A"
            };


            //Arrange
            mockGVArchive?.Object.CreateModels();
            mockGVArchive.Verify(x => x.CreateModels(), Times.Once());
            mockGVArchive.Setup(x => x.Models).Returns(() => new List<DataModel>(){
                new DataModel()
                {
                    IncidentID = 15,
                    IncidentDate = DateTime.Today,
                    IncidentState = "Nebraska",
                    Locale = "Omaha",
                    Address = "123 Anywhere",
                    NumFatalities = 1,
                    NumInjured = 5,
                    Operations = "N/A"
                }
            });

            mockGVArchive.Object.Models.Should().NotBeNull();

            var returnModels = mockGVArchive?.Object.Models;

            Assert.IsTrue(mockGVArchive?.Object.Models?.Any());

            Assert.IsInstanceOfType(returnModels, typeof(List<DataModel>));
            Assert.IsTrue(returnModels.FirstOrDefault().IncidentID == 15);
            Assert.IsTrue(returnModels.FirstOrDefault().IncidentDate == DateTime.Today);
            Assert.IsTrue(returnModels.FirstOrDefault().IncidentState == "Nebraska");
            Assert.IsTrue(returnModels.FirstOrDefault().Locale == "Omaha");
            Assert.IsTrue(returnModels.FirstOrDefault().Address == "123 Anywhere");
            Assert.IsTrue(returnModels.FirstOrDefault().NumFatalities == 1);
            Assert.IsTrue(returnModels.FirstOrDefault().NumInjured == 5);
            Assert.IsTrue(returnModels.FirstOrDefault().Operations == "N/A");

        }

        [TestMethod]
        public void TestCreateModels()
        {
            mockGVArchive?.Object.CreateModels();
            mockGVArchive?.Verify(x => x.CreateModels(), Times.Once());
            mockGVArchive?.Setup(x => x.model).Returns(new DataModel());
            mockGVArchive?.Object.model?.Initialize();
            var testModel = mockGVArchive?.Object.model;

            Assert.IsNotNull(testModel);
            Assert.AreEqual(testModel.IncidentID, 0);
            Assert.AreEqual(testModel.IncidentDate, DateTime.Today);
            Assert.AreEqual(testModel.IncidentState, null);
            Assert.AreEqual(testModel.Locale, null);
            Assert.AreEqual(testModel.Address, null);
            Assert.AreEqual(testModel.NumFatalities, 0);
            Assert.AreEqual(testModel.NumInjured, 0);
            Assert.AreEqual(testModel.Operations, null);

        }

        [TestMethod]
        public void TestCreateNewTable()
        {
        
        }


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