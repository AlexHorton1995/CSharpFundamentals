using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonAPI;
using PersonAPI.Controllers;
using PersonAPI.Models;
using PersonAPITests.TestControllers;
using PersonAPITests.TestDao;
using PersonAPITests.TestModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PersonAPITests
{

    [TestClass]
    public class UnitTest1
    {
        internal MockPersonModel testPerson { get; set; }
        internal MockTestDao Dao { get; set; }
        internal MockPersonModelController testController { get; set; }
        internal ILogger<MockPersonModelController> _mockLogger;
        internal IConfiguration _mockConfig;

        [TestInitialize]
        public void TestInitialize()
        {
            this.testPerson = new MockPersonModel();
            this.Dao = new MockTestDao();
            this.testController = new MockPersonModelController()
            {
                DAO = this.Dao
            };


        }

        [TestClass]
        public class TestPersonModel
        {
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

        [TestClass]
        public class TestController : UnitTest1
        {
            [TestMethod]
            public void TestGetMany()
            {
                //Arrange
                List<PersonModel> expected = new List<PersonModel>()
                {
                    new PersonModel()
                    {
                         ID = "6335E8B7-DC33-45A5-B268-D34D9AD1E127",
                         FirstName = "Test One First Name",
                         MidInit = "A",
                         LastName = "Test One Last Name",
                         Address1 = "Test One Address One",
                         Address2 = "Test One Address Two",
                         City = "TestCity",
                         State = "KS",
                         ZipCode = "66442",
                         DOB = new DateTime(2000, 01, 01),
                         EMail = "anyhere@usa.com",
                         Phone1 = "444-555-1212",
                         Phone2 = "555-444-2121"
                    },
                    new PersonModel()
                    {
                         ID = "6335E8B7-DC33-45A5-B268-D34D9AD1E127",
                         FirstName = "Test Two First Name",
                         MidInit = "A",
                         LastName = "Test Two Last Name",
                         Address1 = "Test Two Address One",
                         Address2 = "Test Two Address Two",
                         City = "TestNYCity",
                         State = "NY",
                         ZipCode = "10010",
                         DOB = new DateTime(1990, 01, 01),
                         EMail = "anyhere@NY.com",
                         Phone1 = "444-555-1212",
                         Phone2 = "555-444-2121"
                    }
                };

                //Act
                var test1 = this.testController.Get();
                ActionResult result = test1.Result.Result;
                OkObjectResult okResult = result as OkObjectResult;

                //Assert
                Assert.IsInstanceOfType(okResult.Value, typeof(List<PersonModel>));
                List<PersonModel> actual = okResult.Value as List<PersonModel>;
                Assert.IsTrue(actual.Count() == 2);
                Assert.AreEqual(expected.FirstOrDefault().ID, actual.FirstOrDefault().ID);
                Assert.AreEqual(expected.FirstOrDefault().FirstName, actual.FirstOrDefault().FirstName);
                Assert.AreEqual(expected.FirstOrDefault().MidInit, actual.FirstOrDefault().MidInit);
                Assert.AreEqual(expected.FirstOrDefault().LastName, actual.FirstOrDefault().LastName);
                Assert.AreEqual(expected.FirstOrDefault().Address1, actual.FirstOrDefault().Address1);
                Assert.AreEqual(expected.FirstOrDefault().Address2, actual.FirstOrDefault().Address2);
                Assert.AreEqual(expected.FirstOrDefault().City, actual.FirstOrDefault().City);
                Assert.AreEqual(expected.FirstOrDefault().State, actual.FirstOrDefault().State);
                Assert.AreEqual(expected.FirstOrDefault().ZipCode, actual.FirstOrDefault().ZipCode);
                Assert.AreEqual(expected.FirstOrDefault().DOB, actual.FirstOrDefault().DOB);
                Assert.AreEqual(expected.FirstOrDefault().Age, actual.FirstOrDefault().Age);
                Assert.AreEqual(expected.FirstOrDefault().EMail, actual.FirstOrDefault().EMail);
                Assert.AreEqual(expected.FirstOrDefault().Phone1, actual.FirstOrDefault().Phone1);
                Assert.AreEqual(expected.FirstOrDefault().Phone2, actual.FirstOrDefault().Phone2);
            }

            [TestMethod]
            public void TestGetSingle()
            {
                //Arrange
                PersonModel expected = new PersonModel()
                {
                    ID = "6335E8B7-DC33-45A5-B268-D34D9AD1E127",
                    FirstName = "Test One First Name",
                    MidInit = "A",
                    LastName = "Test One Last Name",
                    Address1 = "Test One Address One",
                    Address2 = "Test One Address Two",
                    City = "TestCity",
                    State = "KS",
                    ZipCode = "66442",
                    DOB = new DateTime(2000, 01, 01),
                    EMail = "anyhere@usa.com",
                    Phone1 = "444-555-1212",
                    Phone2 = "555-444-2121"
                };

                //Act
                var test1 = this.testController.Get("6335E8B7-DC33-45A5-B268-D34D9AD1E127");
                ActionResult result = test1.Result.Result;
                OkObjectResult okResult = result as OkObjectResult;

                //Assert
                Assert.IsInstanceOfType(okResult.Value, typeof(PersonModel));
                PersonModel actual = okResult.Value as PersonModel;
                Assert.AreEqual(expected.ID, actual.ID);
                Assert.AreEqual(expected.FirstName, actual.FirstName);
                Assert.AreEqual(expected.MidInit, actual.MidInit);
                Assert.AreEqual(expected.LastName, actual.LastName);
                Assert.AreEqual(expected.Address1, actual.Address1);
                Assert.AreEqual(expected.Address2, actual.Address2);
                Assert.AreEqual(expected.City, actual.City);
                Assert.AreEqual(expected.State, actual.State);
                Assert.AreEqual(expected.ZipCode, actual.ZipCode);
                Assert.AreEqual(expected.DOB, actual.DOB);
                Assert.AreEqual(expected.Age, actual.Age);
                Assert.AreEqual(expected.EMail, actual.EMail);
                Assert.AreEqual(expected.Phone1, actual.Phone1);
                Assert.AreEqual(expected.Phone2, actual.Phone2);
            }

            [TestMethod]
            public void TestPost()
            {
                //Arrange
                PersonModel expected = new PersonModel()
                {
                    ID = "6335E8B7-DC33-45A5-B268-D34D9AD1E127",
                    FirstName = "Test One First Name",
                    MidInit = "A",
                    LastName = "Test One Last Name",
                    Address1 = "Test One Address One",
                    Address2 = "Test One Address Two",
                    City = "TestCity",
                    State = "KS",
                    ZipCode = "66442",
                    DOB = new DateTime(2000, 01, 01),
                    EMail = "anyhere@usa.com",
                    Phone1 = "444-555-1212",
                    Phone2 = "555-444-2121"
                };

                //Act
                var test1 = this.testController.Post(expected);
                ActionResult result = test1.Result.Result;
                OkObjectResult okResult = result as OkObjectResult;

                //Assert
                Assert.IsInstanceOfType(okResult.Value, typeof(PersonModel));
                PersonModel actual = okResult.Value as PersonModel;
                Assert.AreEqual(expected.ID, actual.ID);
                Assert.AreEqual(expected.FirstName, actual.FirstName);
                Assert.AreEqual(expected.MidInit, actual.MidInit);
                Assert.AreEqual(expected.LastName, actual.LastName);
                Assert.AreEqual(expected.Address1, actual.Address1);
                Assert.AreEqual(expected.Address2, actual.Address2);
                Assert.AreEqual(expected.City, actual.City);
                Assert.AreEqual(expected.State, actual.State);
                Assert.AreEqual(expected.ZipCode, actual.ZipCode);
                Assert.AreEqual(expected.DOB, actual.DOB);
                Assert.AreEqual(expected.Age, actual.Age);
                Assert.AreEqual(expected.EMail, actual.EMail);
                Assert.AreEqual(expected.Phone1, actual.Phone1);
                Assert.AreEqual(expected.Phone2, actual.Phone2);
            }

            [TestMethod]
            public void TestPut()
            {
                //Arrange
                PersonModel expected = new PersonModel()
                {
                    ID = "6335E8B7-DC33-45A5-B268-D34D9AD1E127",
                    FirstName = "Test One First Name",
                    MidInit = "A",
                    LastName = "Testing Put Last Name", //Test One Last Name
                    Address1 = "Test One Address One",
                    Address2 = "Test One Address Two",
                    City = "TestCity",
                    State = "KS",
                    ZipCode = "66442",
                    DOB = new DateTime(2000, 01, 01),
                    EMail = "anyhere@usa.com",
                    Phone1 = "444-555-1212",
                    Phone2 = "555-444-2121"
                };

                //Act
                var test1 = this.testController.Put(expected, expected.ID);
                ActionResult result = test1.Result.Result;
                OkObjectResult okResult = result as OkObjectResult;

                //Assert
                Assert.IsInstanceOfType(okResult.Value, typeof(PersonModel));
                PersonModel actual = okResult.Value as PersonModel;
                Assert.AreEqual(expected.ID, actual.ID);
                Assert.AreEqual(expected.FirstName, actual.FirstName);
                Assert.AreEqual(expected.MidInit, actual.MidInit);
                Assert.AreEqual(expected.LastName, actual.LastName);
                Assert.AreEqual(expected.Address1, actual.Address1);
                Assert.AreEqual(expected.Address2, actual.Address2);
                Assert.AreEqual(expected.City, actual.City);
                Assert.AreEqual(expected.State, actual.State);
                Assert.AreEqual(expected.ZipCode, actual.ZipCode);
                Assert.AreEqual(expected.DOB, actual.DOB);
                Assert.AreEqual(expected.Age, actual.Age);
                Assert.AreEqual(expected.EMail, actual.EMail);
                Assert.AreEqual(expected.Phone1, actual.Phone1);
                Assert.AreEqual(expected.Phone2, actual.Phone2);
            }

            [TestMethod]
            public void TestDelete()
            {
                //Arrange
                PersonModel expected = new PersonModel()
                {
                    ID = "6335E8B7-DC33-45A5-B268-D34D9AD1E127",
                    FirstName = "Test One First Name",
                    MidInit = "A",
                    LastName = "Testing Put Last Name", //Test One Last Name
                    Address1 = "Test One Address One",
                    Address2 = "Test One Address Two",
                    City = "TestCity",
                    State = "KS",
                    ZipCode = "66442",
                    DOB = new DateTime(2000, 01, 01),
                    EMail = "anyhere@usa.com",
                    Phone1 = "444-555-1212",
                    Phone2 = "555-444-2121"
                };

                //Act
                var test1 = this.testController.Delete(expected.ID);
                ActionResult result = test1.Result;
                StatusCodeResult okResult = result as StatusCodeResult;

                //Assert
                Assert.IsInstanceOfType(okResult.StatusCode, typeof(int));
                Assert.AreEqual(okResult.StatusCode, 200);
            }
        }
    }
}
