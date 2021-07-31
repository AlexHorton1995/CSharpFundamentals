using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {


        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        internal string ConnString { get; set; }

        //the UI app calls the connection string from its appsettings.json file
        public SamuraiContext(string conString)
        {
            this.ConnString = conString;
        }
        
        //called internally by EF Core that determines what is going into the model
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.ConnString);
        }
    
    }
}
