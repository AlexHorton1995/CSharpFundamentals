using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PersonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonAPI.DAO
{
	//This class houses all of our actual interaction logic here.

	public class PersonModelMethods : IPersonModelMethods
	{
		internal SqlConnection _client { get; set; }
		internal string ConnString { get; set; }

		public PersonModelMethods(IConfiguration config)
		{
			this.ConnString = config.GetConnectionString("DefaultConnection");
		}

		public async Task<IEnumerable<PersonModel>> GetAllPeople()
		{
			using (_client = new SqlConnection(ConnString))
			{
				_client.Open();

				var sql = @"SELECT * FROM dbo.PersonMain (NOLOCK)";

				return await _client.QueryAsync<PersonModel>(sql);
			}

		}

		public async Task<PersonModel> GetSinglePerson(string id)
		{
			using (_client = new SqlConnection(ConnString))
			{
				_client.Open();

				var sql = @"SELECT * FROM dbo.PersonMain (NOLOCK) WHERE ID = @ID";
				var retList = await _client.QueryAsync<PersonModel>(sql, new { ID = id });
				return retList.FirstOrDefault();

			}
		}

		public async Task<PersonModel> InsertPerson(PersonModel model)
		{
			using (_client = new SqlConnection(ConnString))
			{
				_client.Open();

				var sql = @"
			INSERT INTO [dbo].[PersonMain]
		   ([ID],[FirstName],[MidInit],[LastName]
			,[DOB],[Age],[Address1],[Address2],[City]
			,[State],[ZipCode],[Phone1],[Phone2],[EMail])
			 VALUES(@ID, @FirstName, @MidInit, @LastName,
					@DOB, @Age, @Address1, @Address2, @City
					,@State, @ZipCode,@Phone1,@Phone2,@Email)";
				await _client.QueryAsync<PersonModel>(sql, model);

				var retList = await this.GetSinglePerson(model.ID);

				return retList;
			}
		}

		public async Task<PersonModel> UpdatePerson(PersonModel model)
		{
			using (_client = new SqlConnection(ConnString))
			{
				_client.Open();

				var sql = @"
					UPDATE dbo.PersonMain
						SET FirstName = @FirstName
						,MidInit = @MidInit
						,LastName = @LastName
						,DOB = @DOB
						,Age = @Age
						,Address1 = @Address1
						,Address2 = @Address2
						,City = @City
						,State = @State
						,ZipCode = @ZipCode
						,Phone1 = @Phone1
						,Phone2 = @Phone2
						,EMail = @EMail
					WHERE ID = @ID";
				await _client.QueryAsync<PersonModel>(sql, model);

				var retList = await this.GetSinglePerson(model.ID);

				return retList;
			}
		}

		public async Task<bool> DeletePerson(string personID)
		{
			using (_client = new SqlConnection(ConnString))
			{
				_client.Open();

				var sql = @"DELETE FROM dbo.PersonMain WHERE ID = @ID";
				var retRec = await _client.ExecuteAsync(sql, new { ID = personID });
				return retRec > 0;
			}
		}
	}
}
