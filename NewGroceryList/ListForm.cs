using NewGroceryList.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewGroceryList
{
    public partial class ListForm : Form
    {
        public static DataSet ds;
        public static DataTable ItemData;
        public static AppDao dao;

        public ListForm()
        {
            InitializeComponent();
        }

        static ListForm()
        {
            ItemData = new DataTable();
            ds = new DataSet("ShoppingData");
            dao = new AppDao();
        }

        private void ListForm_Load(object sender, EventArgs e)
        {
            ItemData = dao.CreateItemTable();
            ds.Tables.Add(ItemData);
        }

        public void SetGrid()
        {
            dataGridView1.DataSource = ds;
        }
    }
}
