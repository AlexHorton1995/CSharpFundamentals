using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperSolution.Models;
using Microsoft.Data.SqlClient;

namespace DapperSolution
{
    public interface IDAObjects
    {
        public bool Initialize();

        public bool BeginTransaction();
        public bool RollbackTransaction();
        public bool CommitTransaction();

    }

    public class DAObjects : IDAObjects
    {
        internal string _connectionString { get; set; }

        public DAObjects()
        {
            this._connectionString = "Data Source=DESKTOP-VBBHMUF;Initial Catalog=Chinook;Integrated Security=True";
        }

        public bool BeginTransaction()
        {
            return false;
        }

        public bool RollbackTransaction()
        {
            return false;
        }


        public bool CommitTransaction()
        {
            return false;
        }

        public bool Initialize()
        {

            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                connection.Open(); //open the DB Connection here

                using (SqlTransaction sTran = connection.BeginTransaction("TestTran"))
                {
                    //Write SQL Query
                    string sql = @"SELECT * FROM Album";

                    //using Dapper
                    //var query = connection.Query<AlbumModel>(sql).ToList();
                    var query = connection.Query<AlbumModel>(sql, null, sTran).ToList();

                    foreach (var data in query)
                    {

                        Console.WriteLine($"The output of {data.Title}");
                    }

                    sTran.Commit();

                    Console.WriteLine();
                    Console.WriteLine("Press Any key to continue...");
                    Console.ReadLine();
                }
            }

            return false;
        }
    }
}
