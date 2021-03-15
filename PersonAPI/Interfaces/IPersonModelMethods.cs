using PersonAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonAPI.DAO
{
    public interface IPersonModelMethods
    {
        /// <summary>
        /// Deletes a single row from the Database
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        Task<bool> DeletePerson(string personID);

        /// <summary>
        /// Gets an IEnumerable list of Persons from the Database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PersonModel>> GetAllPeople();

        /// <summary>
        /// Gets a single Person from the Database
        /// </summary>
        /// <param name="id">The GUID stored in the table</param>
        /// <returns></returns>
        Task<PersonModel> GetSinglePerson(string id);

        /// <summary>
        /// Inserts a single new row into the Database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PersonModel> InsertPerson(PersonModel model);

        /// <summary>
        /// Updates a single row in the Database.
        /// Passes in an updated model by the ID of the user.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PersonModel> UpdatePerson(PersonModel model);
    }
}