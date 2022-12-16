using System.Threading.Tasks;
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using GVArchiveOps.DataModels;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("GVArchiveTests")]
namespace GVArchiveOps
{
    public interface IGVArchive : IDisposable
    {
        IDataModel? model { get; }
        List<DataModel>? Models { get; }
        void CreateModels();
        List<DataModel>? FileReadyForImport(FileInfo inputFile);
        bool HasConnString();
    }

    public class GVArchive : IGVArchive
    {

        #region Properties
        public IDataModel? model { get; set; }
        public List<DataModel>? Models { get; set; }
        protected string? ConnString { get; set; }
        private SqlConnection conn;


        #endregion


        #region CRUD OPS
        //CRUD OPERATIONS
        public void CreateModels()
        {
            this.Models = new List<DataModel>();
        }

        public bool HasConnString()
        {
            return false;
        }

        public bool CreateTempTable()
        {
            ConnString = "Data Source=DESKTOP-C1TJG0L;Initial Catalog=GVArchive;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (conn = new SqlConnection(this.ConnString))
            {
                conn.Open();

                var sql = @"
                            CREATE TABLE [#TempIncidents](
	                            [TempIncidentID] [int] NOT NULL,
	                            [TempIncidentDate] [datetime] NOT NULL,
	                            [TempIncidentState] [varchar](60) NOT NULL,
	                            [TempLocale] [varchar](200) NULL,
	                            [TempAddress] [varchar](70) NULL,
	                            [TempNumFatalities] [int] NOT NULL,
	                            [TempNumInjured] [int] NOT NULL,
	                            [TempOperations] [varchar](60) NULL,
                             CONSTRAINT [PK_TempIncidents] PRIMARY KEY CLUSTERED 
                            (
	                            [TempIncidentID] ASC,
	                            [TempIncidentDate] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                            ) ON [PRIMARY]
                            GO
                            ";

                conn.Query(sql);



            }

            return false;
        }

        public bool DropTempTable()
        {
            using (conn = new SqlConnection(this.ConnString))
            {
                conn.Open();

                var sql = @"DROP TABLE [#TempIncidents]";
            }
            return false;

        }

        #endregion

        #region File Ops
        public List<DataModel>? FileReadyForImport(FileInfo inputFile)
        {
            CreateModels();

            string? line;

            using (var sr = new StreamReader(inputFile.FullName))
            {
                sr.ReadLine(); //ignore the header

                while ((line = sr.ReadLine()) != null)
                {
                    var lineArr = line.Split(',');

                    var testDt = $"{lineArr[1]} {lineArr[2].Trim()}";


                    DataModel model = new DataModel()
                    {
                        IncidentID = int.TryParse(lineArr[0], out int incID) ? incID : 0,
                        IncidentDate = DateTime.TryParse($"{lineArr[1]} {lineArr[2].Trim()}", out DateTime incDt) ? incDt : DateTime.Today,
                        IncidentState = !string.IsNullOrEmpty(lineArr[3]) ? lineArr[3] : string.Empty,
                        Locale = !string.IsNullOrEmpty(lineArr[4]) ? lineArr[4] : string.Empty,
                        Address = !string.IsNullOrEmpty(lineArr[5]) ? lineArr[5] : string.Empty,
                        NumFatalities = int.TryParse(lineArr[6], out int numFatal) ? numFatal : 0,
                        NumInjured = int.TryParse(lineArr[7], out int numInjured) ? numInjured : 0,
                        Operations = !string.IsNullOrEmpty(lineArr[8]) ? lineArr[8] : string.Empty
                    };
                    this.Models?.Add(model);
                }
            }
            return this.Models;
        }



        #endregion


        #region Disposable

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~GVArchive()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


        #endregion


    }
}