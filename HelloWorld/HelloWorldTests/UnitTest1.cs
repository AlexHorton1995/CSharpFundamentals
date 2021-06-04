using HelloWorld;
using HelloWorld.DAO;
using HelloWorldTests.MockDAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HelloWorldTests
{
    [TestClass]
    public class UnitTest1 : IDisposable
    {
        private bool disposedValue;
        public MockDao _mockDAO;

        [TestInitialize]
        public void InitializeTest()
        {
            _mockDAO = new MockDao();

            PreProgram.DAO = _mockDAO;

        }


        [TestMethod]
        public void TestInitializeDAO()
        {
            var dao = _mockDAO.InitializeDAO();
            Assert.IsTrue(PreProgram.Initialize(dao));
        }

        [TestMethod]
        public void TestParseInfo()
        {
            var actual = PreProgram.ParseInfo();

            Assert.IsTrue(actual > 0);
            Assert.AreEqual(3, actual);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            
        }

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
    }
}
