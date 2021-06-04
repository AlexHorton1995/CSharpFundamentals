using Microsoft.Extensions.Configuration;
using PersonAPI.DAO;
using PersonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAPITests.TestDao
{
    public class MockTestDao : IPersonModelMethods
    {
        //public IConfiguration config;

        public Task<bool> DeletePerson(string personID)
        {
            return Task.FromResult(true);
        }

        public Task<IEnumerable<PersonModel>> GetAllPeople()
        {
            IEnumerable<PersonModel> retModels = new List<PersonModel>()
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

            return Task.FromResult(retModels);
        }

        public Task<PersonModel> GetSinglePerson(string id)
        {
            PersonModel retModel = new PersonModel()
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

            return Task.FromResult(retModel);
        }

        public Task<PersonModel> InsertPerson(PersonModel model)
        {
            return Task.FromResult(model);
        }

        public Task<PersonModel> UpdatePerson(PersonModel model)
        {
            return Task.FromResult(model);
        }
    }
}
