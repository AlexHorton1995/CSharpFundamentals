using Microsoft.Extensions.Configuration;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace SamuraiApp.UI
{
    class Program
    {
        private static string ConnString { get; set; }
        private static IConfiguration configuration;
        private static SamuraiContext samuraiConn;

        static Program()
        {
            GetConnString();
            Connect();
        }

        static void Main(string[] args)
        {
            GetSamurai("Before add");
            AddSamurai();
            GetSamurai("After Add");
            Console.WriteLine("Press any Key to continue....");
            Console.ReadKey();
        }

        static void Connect()
        {
            samuraiConn = new SamuraiContext(ConnString);
            samuraiConn.Database.EnsureCreated();
        }

        static void GetConnString()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddEnvironmentVariables()
                .Build();

            configuration = builder;

            //pass in the connection string to the DBContext
            ConnString = configuration.GetConnectionString("DefaultConnection");
        }

        static void AddSamurai()
        {
            var samurai = new Samurai() { Name = "Sampson" };
            samuraiConn.Add(samurai);
            samuraiConn.SaveChanges();
        }

        static void GetSamurai(string text)
        {
            var samurais = samuraiConn.Samurais.ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count()}");
            foreach(var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }

    }
}
