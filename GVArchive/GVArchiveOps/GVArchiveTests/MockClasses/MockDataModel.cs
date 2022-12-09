using GVArchiveOps.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVArchiveTests.MockClasses
{
    internal class MockDataModel : IDataModel
    {
        public int IncidentID { get; set; }
        public DateTime IncidentDate { get; set; }
        public string? IncidentState { get; set; }
        public string? Locale { get; set; }
        public string? Address { get; set; }
        public int NumFatalities { get; set; }
        public int NumInjured { get; set; }
        public string? Operations { get; set; }

        public void Initialize()
        {
            this.IncidentID = 0;
            this.IncidentDate = DateTime.Today;
            this.IncidentState = null;
            this.Locale = null;
            this.Address = null;
            this.NumFatalities = 0;
            this.NumInjured = 0;
            this.Operations = null;
        }
    }
}
