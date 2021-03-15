using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonAPI;
using PersonAPI.Models;
using System;

namespace PersonAPITests
{

    [TestClass]
    public class UnitTest1
    {
        PersonModel testPerson { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            this.testPerson = new PersonModel();
        }

        [TestMethod]
        public void TestNewPersonModel()
        {
            var expected = new PersonModel()
            {
                ID = Guid.NewGuid().ToString(),
                 FirstName = "Test 1 Name",
                 MidInit = "D",
                 LastName = "Test 1 L Name",
                 Address1 = "123 ANYWHERE USA",
                 Address2 = "456 JENKINS RD",
                 City = "OMAHA",
                 State = "NE", 
                 ZipCode = "68111", 
                 EMail = "TESTEMAIL@EMAIL.COM", 
                 DOB = new DateTime(2020, 01, 01),
                 Phone1 = "402-555-1212", 
                 Phone2 = "800-123-1234"
            };

            var age = expected.Age;

            Assert.AreEqual(age, (byte?)1);


        }
    }
}
