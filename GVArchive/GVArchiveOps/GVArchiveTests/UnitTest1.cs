using GVArchiveOps;
using GVArchiveOps.DataModels;
using GVArchiveTests.MockClasses;
using GVArchiveTests.Properties;

namespace GVArchiveTests
{
    [TestClass]
    public class UnitTest1
    {
        internal MockDataModel? mockModel;
        internal IGVArchive mockArchive;

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
            this.mockArchive.CreateModels();
            Assert.IsNotNull(this.mockArchive.Models);
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
            var actual = this.mockArchive.FileReadyForImport(fileIn).Where(x => x.IncidentID == 2473638).FirstOrDefault();

            //ASSERT
            Assert.AreEqual(expected, actual);
        }


    }
}