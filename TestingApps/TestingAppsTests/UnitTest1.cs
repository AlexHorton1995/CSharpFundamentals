
using Microsoft.VisualStudio.TestPlatform.TestHost;
using TestingApps;

namespace TestingAppsTests
{

    [TestClass]
    public class UnitTest1
    {
        internal TestingApp testApp { get; set; } 
     
        [TestInitialize]
        public void TestInitialize()
        {
            this.testApp = new TestingApp();
        }

        [TestMethod]
        public void TestSayYo()
        {
            //Arrange
            string expected = "  YO!";

            //Act
            string actual = TestingApp.SayYo();

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(actual.Length == 5);

        }

        [TestMethod]
        public void TestSayGreetings()
        {
            TestingApp.SayGreetings();
        }

        [TestMethod]
        public void TestSayHelloWorld()
        {
            TestingApp.SayHelloWorld();
        }


    }
}