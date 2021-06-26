using HelloWorld.DAO;
using HelloWorld.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorldTests.MockDAO
{
    public class MockDao : IDataAccessObjects
    {

        private IConfiguration configuration;

        public string ConnString { get; }
        public string FileLocation { get;  }
        public Dictionary<string, string> ConnStrings { get; set; }
        public Dictionary<string, string> FileLocations { get; set; }

        public MockDao()
        {
            this.ConnString = "123";
            this.configuration = null;
        }

        public IEnumerable<QueryModel> GetInvoiceTotalsByPriceRange(decimal lowRange, decimal highRange)
        {
            List<QueryModel> mockData = new List<QueryModel>()
            {
                new QueryModel()
                {
                    AlbumTitle = "Test Title1",
                    ArtistsName = "Test Artist 1",
                    InvoiceLineID = 1,
                    MediaTrackID = 1,
                    MediaType = "",
                    Quantity = 10,
                    TrackName = "",
                    UnitPrice = 100.00M
                },
                new QueryModel()
                {
                    AlbumTitle = "Test Title2",
                    ArtistsName = "Test Artist 2",
                    InvoiceLineID = 2,
                    MediaTrackID = 2,
                    MediaType = "blah",
                    Quantity = 20,
                    TrackName = "yo mama",
                    UnitPrice = 200.00M
                },
                new QueryModel()
                {
                    AlbumTitle = "Test Title3",
                    ArtistsName = "Test Artist 3",
                    InvoiceLineID = 3,
                    MediaTrackID = 3,
                    MediaType = "blah blah",
                    Quantity = 30,
                    TrackName = "is ugly",
                    UnitPrice = 300.00M
                }
            };

            return mockData;
        }

        public DataAccessObjects InitializeDAO(string args)
        {
            DataAccessObjects testObj = new DataAccessObjects();

            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddEnvironmentVariables()
                .Build();

            configuration = builder;
            if (SetConnString())
            {
                testObj.ConnString = this.ConnString;
                return testObj;
            }
            else
            {
                return null;
            }
        }

        private bool SetConnString()
        {
            return !string.IsNullOrEmpty(configuration.GetConnectionString("DummyConnection"));
        }
    }
}
