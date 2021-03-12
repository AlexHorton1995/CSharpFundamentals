using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FileMoverTestProjects
{
    [TestClass]
    public class UnitTest1
    {
        internal IEnumerable<string> TestMoveFiles { get; set; }
        internal string TestSource { get; set; }
        internal string TestDestination { get; set; }

        [TestInitialize]
        public void InitializeTests()
        {
            this.TestSource = @"K:\TestSource";
            this.TestDestination = @"K:\TestDestination";
        }

        [TestMethod]
        public void TestFindAndMoveFiles()
        {
            //writing this one test case to keep Michael off my back :)
            FileMover.Program.FindAndMoveFiles(TestSource, TestDestination);
        }
    }
}
