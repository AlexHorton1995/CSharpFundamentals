using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlClient;
using GVArchiveOps.DataModels;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("GVArchiveTests")]
namespace GVArchiveOps
{
    public interface IGVArchive
    {
        IDataModel? model { get; }
        List<DataModel>? Models { get; }
        void CreateModels();
        List<DataModel> FileReadyForImport(FileInfo inputFile);
    }

    public class GVArchive : IGVArchive
    {

        #region Properties
        public IDataModel? model { get; set; }
        public List<DataModel>? Models { get; set; }
        protected string? ConnString { get; set; }

        #endregion


        #region CRUD OPS
        //CRUD OPERATIONS
        public void CreateModels()
        {
            this.Models = new List<DataModel>();            
        }

        #endregion

        #region File Ops
        public List<DataModel> FileReadyForImport(FileInfo inputFile)
        {
            CreateModels();

            string? line;

            using(var sr = new StreamReader(inputFile.FullName))
            {
                sr.ReadLine(); //ignore the header

                while ((line = sr.ReadLine()) != null)
                {
                    var lineArr = line.Split(',');

                    var dateColumn = $"{lineArr[1]} {lineArr[2]}";

                    DataModel model = new DataModel()
                    {
                        IncidentID = int.TryParse(lineArr[0], out int incID) ? incID : 0,
                        IncidentDate = DateTime.TryParse(lineArr[1], out DateTime incDt) ? incDt : DateTime.Today,
                        IncidentState = string.IsNullOrEmpty(lineArr[2]) ? lineArr[2] : string.Empty,
                        Locale = string.IsNullOrEmpty(lineArr[3]) ? lineArr[3] : string.Empty,
                        Address = string.IsNullOrEmpty(lineArr[4]) ? lineArr[4] : string.Empty,
                        NumFatalities = int.TryParse(lineArr[5], out int numFatal) ? numFatal : 0,
                        NumInjured = int.TryParse(lineArr[6], out int numInjured) ? numInjured : 0,
                        Operations = string.IsNullOrEmpty(lineArr[7]) ? lineArr[7] : string.Empty
                    };
                    this.Models.Add(model);
                }
            }
            return this.Models;
        }


        #endregion


    }
}