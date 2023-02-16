using Microsoft.Data.SqlClient;
using System;
using DapperSolution.Models;
using System.Linq;
using System.Collections.Generic;

namespace DapperSolution
{
    class Program
    {
        internal static IDAObjects Dao { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DBConnection();
        }

        static void DBConnection()
        {
            Dao = new DAObjects();
            Dao.Initialize();
        }
    }
}
