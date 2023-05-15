using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperSolution.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

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
            this._connectionString = "Data Source=DESKTOP-C1TJG0L;Initial Catalog=Chinook;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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
                    string sql = @"SELECT Title, [Name] from Album ALB
                                INNER JOIN Artist ART ON ALB.ArtistId = ART.ArtistId";

                   
                    //using Dapper
                    //var query = connection.Query<AlbumModel>(sql).ToList();
                    var query = connection.Query<AlbumModel>(sql, null, sTran).ToList();

                    foreach (var data in query)
                    {

                        Console.WriteLine($"Artist: {data.Name} Album: {data.Title}");
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
