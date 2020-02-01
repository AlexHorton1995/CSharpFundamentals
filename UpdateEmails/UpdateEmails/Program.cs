using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;

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
                var sqlConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
                string rec;

                using (SqlConnection conn = new SqlConnection(sqlConnStr))
                using (OleDbConnection connection = new OleDbConnection(conString.ToString()))
                {
                    connection.Open(); //open the Foxpro DataTable
                    conn.Open(); //open the sql data table
                    string sql = null;
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    StringBuilder sbv = new StringBuilder(500);
                    DataTable dataTable;

                    //Get all the table schema information
                    var tableNames = connection.GetSchema(OleDbMetaDataCollectionNames.Tables);

                    foreach (System.Data.DataRow rowTables in tableNames.Rows)
                    {
                        Console.Out.WriteLine(rowTables["table_name"].ToString());
                        dataTable = new DataTable(rowTables["table_name"].ToString());
                        DataTable columns = connection.GetSchema(
                            System.Data.OleDb.OleDbMetaDataCollectionNames.Columns,
                            new String[] { null, null, rowTables["table_name"].ToString(), null }
                        );
                        foreach (System.Data.DataRow rowColumns in columns.Rows)
                        {
                            DataColumn dataColumn = new DataColumn(rowColumns["column_name"].ToString());
                            dataTable.Columns.Add(dataColumn);
                            
                            Console.Out.WriteLine(
                                rowColumns["column_name"].ToString()
                            );
                        }


                    }

                    string[] Membership = new string[]{
                        "ATDATA","ATDATAC","BGCHECK","CCSYNC",
                        "CCSYNCD","MA","MACODES","MAINFO","MAMINFO","ME","MECODES",
                        "MECONNECT","MECONTLOG","MECONTLOGD","MECONTLOGE","MEINFO","MEMINFO","MI",
                        "MICODES","SK","SKCODES","SKGCAL","SKINFO","SKREF","SKSERV","VI","VICODES"
                    };

                    string[] accounting = new string[]
                    {
                        "APAUTO","APAUTOD","APCHECK","APCODES","APINFO","APOPEN","APOPEND","APPAID","APPAIDD","APVEND","ARAPPLY","ARAUTO","ARAUTOD","ARCODES","ARCREDIT","ARCUST",
                        "ARINFO","ARINV","ARINVD","ARITEMS","ARMINFO","ARPMT","ARPMTD","ARPMTMETH","ARPOST","FAACCTS","FABUDGET","FAFUNDS","FAINFO","FAMAJOR","FAMSTR","FAMSTRD","FAPOST",
                        "FAPREVYR","FAPRIOR","FARECON","FAREPEAT","FAREPEATD","FARSCTD","FATRANS","FATRANSD","PRAP","PRCODES","PRDESC","PRDESCT","PREMPL","PRGROUP","PRHIST","PRINFO","PRITEMS",
                        "PRLEAVE","PRMINFO","PRPAID","PRPAIDD","PRPOST","PRPROC","PRTABLES","PRTAXES","PRW2","PRW3"
                    };

                    string[] contributions = new string[]
                    {
                        "CO","COAUTO","COCODES","COFUND","COINFO","COMEM","COMINFO","COO","COOENV","COOFUND","COOPP","COOTRANS","COPLED","COPOST","CORECEIPT","CORECEIPTD","COSCAN","COTRANS"
                    };

                    adapter.SelectCommand = connection.CreateCommand();

                    //int count = Membership.Count();
                    //int count = accounting.Count();
                    int count = contributions.Count();

                    for (int i = 0; i < count; i++)
                    {
                        //string tablename = membership[i];
                        //string tablename = accounting[i];
                        string tablename = contributions[i];
                        sql = string.Format("SELECT * FROM {0}", tablename);
                        adapter.SelectCommand.CommandText = sql;
                        var results = adapter.SelectCommand.ExecuteReader();

                        using (results)
                        {
                            int columns = results.FieldCount;

                            //sbv.Append(string.Format("CREATE TABLE [membership].[{0}](", tablename));
                            //sbv.Append(string.Format("CREATE TABLE [accounting].[{0}](", tablename));
                            sbv.Append(string.Format("CREATE TABLE [contributions].[{0}](", tablename));
                            sbv.Append(Environment.NewLine);

                            for (int j = 0; j < columns; j++)
                            {
                                sbv.Append(string.Format("[{0}] [{1}] null,", results.GetName(j), results.GetFieldType(j).ToString())).Append(Environment.NewLine);
                            }
                            sbv.Append("ON [PRIMARY]").Append(Environment.NewLine);
                            sbv.Append("GO").Append(Environment.NewLine);
                        }
                        using (StreamWriter writer = new StreamWriter("B:\\Fox2SQLOutputC.txt", true))
                        {
                            writer.WriteLine(sbv.ToString());
                        }
                    }

                    int x = 0;



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

                    using (StreamWriter writer = new StreamWriter("B:\\EmailOutput.csv"))
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
