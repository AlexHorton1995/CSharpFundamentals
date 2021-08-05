using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace UpdateEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailUpdater();
        }


        public static bool EmailUpdater()
        {

            try
            {
                var conString = System.Configuration.ConfigurationManager.ConnectionStrings["PowerChurch"].ConnectionString;

                string rec;


                using (OleDbConnection connection = new OleDbConnection(conString.ToString()))
                {
                    connection.Open();
                    string sql = null;
                    OleDbDataAdapter adapter = new OleDbDataAdapter();

                    //start of loop using the streamreader here
                    using (StreamReader reader = new StreamReader("B:\\somefile.csv"))
                    {
                        reader.ReadLine(); //skip the header row of the file.

                        while ((rec = reader.ReadLine()) != null)
                        {

                            //parse the input file.
                            string[] valArr = new string[] { };
                            string[] splitChar = new string[] { "," };
                            valArr = rec.Split(splitChar, StringSplitOptions.None);

                            sql = "UPDATE ME SET E_MAIL = '" + valArr[0] + "' WHERE ENV_NO = " + Convert.ToInt32(valArr[1]);

                            //try to update the line here
                            adapter.UpdateCommand = connection.CreateCommand();
                            adapter.UpdateCommand.CommandText = sql;
                            int updateRows = adapter.UpdateCommand.ExecuteNonQuery();
                        }

                    }

                    //End of loop
                    sql = "SELECT * FROM ME WHERE E_MAIL <> ''";

                    adapter.SelectCommand = connection.CreateCommand();
                    adapter.SelectCommand.CommandText = sql;


                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "ME");

                    DataTable dt = new DataTable();
                    dt = ds.Tables["ME"];

                    using(StreamWriter writer = new StreamWriter("B:\\EmailOutput.csv"))
                    {
                        StringBuilder sb = new StringBuilder(128);
                        sb.Append("Last Name,First Name,Email,Envelope Number");
                        writer.WriteLine(sb.ToString());

                        foreach (DataRow row in dt.Rows)
                        {
                            sb = new StringBuilder(128);
                            sb.Append(row["lastname"].ToString().Trim()).Append(",");
                            sb.Append(row["firstname"].ToString().Trim()).Append(",");
                            sb.Append(row["e_mail"].ToString().Trim()).Append(",");
                            sb.Append(row["env_no"].ToString().Trim()).Append(",");
                            writer.WriteLine(sb.ToString());
                        }

                    }

 
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
