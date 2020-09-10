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
        void DeleteDataRow(DataTable dt, string value);
    }

    public class AppDao : IAppDao
    {
        public AppDao() { }

        public DataTable CreateItemTable()
        {
            var retTable = new DataTable("ItemTable");
            retTable.Columns.Add("ItemName", typeof(string));
            retTable.Columns.Add("ItemPrice", typeof(decimal));
            retTable.Columns.Add("ItemQuantity", typeof(int));
            retTable.Columns.Add("IsTaxable", typeof(string));

            return retTable;
        }

        public void AddDataRow(DataTable dt, FormModel model)
        {
            DataRow row = dt.NewRow();
            row["ItemName"] = model.ItemName;
            row["ItemPrice"] = model.ItemPrice;
            row["ItemQuantity"] = model.ItemQuantity;
            row["IsTaxable"] = model.Taxable;
            dt.Rows.Add(row);
        }

        public void DeleteDataRow(DataTable dt, string value)
        {
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                var dr = dt.Rows[i];

                if (dr["ItemName"].ToString() == value.ToString())
                {
                    dr.Delete();
                }
            }
        }

        public void UpdateDataRow(DataTable dt, string cValue, int updateType, FormModel model)
        {
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                var dr = dt.Rows[i];

                if (dr["ItemName"].ToString() == cValue.ToString())
                {
                    switch (updateType)
                    {
                        case 1: //update ItemName
                            dr["ItemName"] = model.ItemName;
                            break;
                        case 2: //update Item Price (based on quantity)
                            dr["ItemName"] = model.ItemName;
                            break;
                        case 3: //update item Quantity (will need to update price as well)
                            break;
                    }

                    dr.Delete();
                }
            }
        }

    }
}

