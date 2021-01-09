using Dapper;
using DataSenderAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataSenderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private IConfiguration Configuration; //interface for getting connection string
        private readonly string connString;

        public DepartmentsController(IConfiguration _configuration)
        {
            Configuration = _configuration;
            this.connString = this.Configuration.GetConnectionString("MainDB");
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns>All instances in Department Table</returns>
        // GET: api/departments
        [HttpGet]
        public async Task<IEnumerable<Departments>> Get()
        {
            //gets all departments here
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //2. open the sql connection to the DB
                conn.Open();

                string sql = @"SELECT Department_ID, Department FROM [dbo].[Departments] WITH (NOLOCK)";
                return await conn.QueryAsync<Departments>(sql);
            }
        }

        // GET api/departments/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<string>> Get(int id)
        {
            //gets all departments here
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //2. open the sql connection to the DB
                conn.Open();

                string sql = @"SELECT Department FROM [dbo].[Departments] WITH (NOLOCK)
                                WHERE Department_ID = @Department_ID";

                return await conn.QueryAsync<string>(sql, new {Department_ID = id });
            }
        }

        // POST api/departments
        [HttpPost]
        public void Post([FromBody] Departments department)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //2. open the sql connection to the DB
                conn.Open();

                string sql = $"INSERT INTO [dbo].[Departments] (Department) " +
                    $"VALUES (@Department)";

                var ret = conn.Execute(sql, department);
            }

        }

        // PUT api/id/department
        [HttpPut("{department_id}/{department}")]
        public void Put(int department_id, string department)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //2. open the sql connection to the DB
                conn.Open();

                string sql = @"UPDATE [dbo].[Departments]
                SET Department = @Department
                WHERE Department_ID = @Department_ID;"; 

                var ret = conn.Execute(sql, new { Department = department, Department_ID = department_id } );
            }
        }

        // DELETE api/departments/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //2. open the sql connection to the DB
                conn.Open();

                string sql = @"DELETE FROM [dbo].[Departments]
                WHERE Department_ID = @Department_ID;";

                var ret = conn.Execute(sql, new { Department_ID = id });
            }

        }
    }
}
