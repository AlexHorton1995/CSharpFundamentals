using NewGroceryList.Models;
using System.Data;

namespace NewGroceryList.Dao
{
    public interface IAppDao
    {
        DataTable CreateItemTable();
        void AddDataRow(DataTable dt, FormModel model);
        void DeleteDataRow(DataTable dt, string value);
        void UpdateDataRow(DataTable dt, FormModel model);
        void DeleteAllRows(DataTable dt);
    }

    public class AppDao : IAppDao
    {
        #region Constructors
        public AppDao() { }
        #endregion

        #region DataTable Operations
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
                    dt.AcceptChanges();
                }
            }
        }

        public void DeleteAllRows(DataTable dt)
        {
            dt.Clear();
        }

        public void UpdateDataRow(DataTable dt, FormModel model)
        {
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                var dr = dt.Rows[i];

                if (dr["ItemName"].ToString() == model.ItemName)
                {
                    dr.BeginEdit();
                    dr["ItemName"] = model.ItemName;
                    dr["ItemPrice"] = model.ItemPrice;
                    dr["ItemQuantity"] = model.ItemQuantity;
                    dr["IsTaxable"] = model.Taxable;
                    dr.AcceptChanges();
                }
            }
        }
        #endregion
    }
}

