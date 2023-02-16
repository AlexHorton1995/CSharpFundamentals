using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVArchiveOps.DataModels
{
    public interface IDataModel
    {
        int IncidentID { get; }
        DateTime IncidentDate { get; }
        string? IncidentState { get; }
        string? Locale { get; }
        string? Address { get; }
        int NumFatalities { get; }
        int NumInjured { get; }
        string? Operations { get; }

        void Initialize();
    }

    public class DataModel : IDataModel
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

        public DataModel() { Initialize(); }

    }
}
