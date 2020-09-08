using NewGroceryList.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGroceryList.Dao
{
    public interface IAppDao
    {
        DataTable CreateItemTable();
        void AddDataRow(DataTable dt, FormModel model);
        void DeleteDataRow(DataTable dt, FormModel model);
    }

    public class AppDao
    {
        public AppDao() { }

        public DataTable CreateItemTable()
        {
            var retTable = new DataTable("ItemTable");
            retTable.Columns.Add("ItemName", typeof(string));
            retTable.Columns.Add("ItemPrice", typeof(decimal));
            retTable.Columns.Add("ItemQuantity", typeof(int));

            return retTable;
        }

        public void AddDataRow(DataTable dt, FormModel model)
        {
            DataRow row = dt.NewRow();
            row["ItemName"] = model.ItemName;
            row["ItemPrice"] = model.ItemPrice;
            row["ItemQuantity"] = model.ItemQuantity;
            dt.Rows.Add(row);
        }

        public void DeleteDataRow(DataTable dt, FormModel model)
        {
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                var dr = dt.Rows[i];

                if(dr["ItemName"].ToString() == model.ItemName)
                {
                    dr.Delete();
                }
            }

        }
    }
}
