using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonAPI.DAO;
using PersonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonAPI.Attributes;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace PersonAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [ApiKey]
    public class PersonModelController : ControllerBase
    {
        private IPersonModelMethods personDao;
        public IPersonModelMethods DAO { get => personDao; set => personDao = value; }

        private readonly ILogger<PersonModelController> _logger;
        private IConfiguration config { get; set; }
        private PersonModelMethods methods { get; set; }

        public PersonModelController(IConfiguration _configuration, ILogger<PersonModelController> logger)
        {
            this.config = _configuration;
            personDao = new PersonModelMethods(_configuration);
            _logger = logger;
        }


        /// <summary>
        /// Gets an IEnumerable list of Persons from the Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonModel>>> Get()
        {
            try
            {
                var data = await personDao.GetAllPeople().ConfigureAwait(false);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }

        }


        /// <summary>
        /// Gets a single Person from the Database
        /// </summary>
        /// <param name="id">The GUID stored in the table</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PersonModel>>> Get(string id)
        {
            try
            {
                var data = await personDao.GetSinglePerson(id).ConfigureAwait(false);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        /// <summary>
        /// Inserts a single new row into the Database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<ActionResult<PersonModel>> Post([FromBody] PersonModel model)
        {
            try
            {
                model.ID = Guid.NewGuid().ToString().ToUpper();
                var data = await personDao.InsertPerson(model).ConfigureAwait(false);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        /// <summary>
        /// Updates a single row in the Database.
        /// Passes in an updated model by the ID of the user.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<IEnumerable<PersonModel>>> Put([FromBody] PersonModel model, string id)
        {
            try
            {
                var oldData = await personDao.GetSinglePerson(id);

                if(oldData != null)
                {
                    var updateModel = new PersonModel()
                    {
                        ID = oldData.ID,
                        FirstName = model.FirstName ?? oldData.FirstName,
                        MidInit = model.MidInit ?? oldData.MidInit,
                        LastName = model.LastName ?? oldData.LastName,
                        Address1 = model.Address1 ?? oldData.Address1,
                        Address2 = model.Address2 ?? oldData.Address2,
                        City = model.City ?? oldData.City,
                        State = model.State ?? oldData.State,
                        ZipCode = model.ZipCode ?? oldData.ZipCode,
                        Phone1 = model.Phone1 ?? oldData.Phone1,
                        Phone2 = model.Phone2 ?? oldData.Phone2,
                        EMail = model.EMail ?? oldData.EMail
                    };
    
                    var data = await personDao.UpdatePerson(updateModel);
                    return Ok(data);

                }
                else
                {
                    return StatusCode(200, "NO Matching ID");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        /// <summary>
        /// Deletes a single row from the Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var data = await personDao.DeletePerson(id).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}
