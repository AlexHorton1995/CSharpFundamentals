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
    public class TestDao : IPersonModelMethods
    {
        public IConfiguration config;

        public Task<bool> DeletePerson(string personID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PersonModel>> GetAllPeople()
        {
            throw new NotImplementedException();
        }

        public Task<PersonModel> GetSinglePerson(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonModel> InsertPerson(PersonModel model)
        {
            throw new NotImplementedException();
        }

        public Task<PersonModel> UpdatePerson(PersonModel model)
        {
            throw new NotImplementedException();
        }
    }
}
