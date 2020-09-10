using NewGroceryList.Dao;
using NewGroceryList.Models;
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
        public static DataTable ItemData = new DataTable();
        public static AppDao dao;

        public ListForm()
        {
            InitializeComponent();
        }

        static ListForm()
        {
            dao = new AppDao();
            ItemData = dao.CreateItemTable();
        }

        private void ListForm_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            ItemName.Text = "Enter Item";
            ItemQty.Text = "0";
            ItemPrice.Text = "0.00";
            Taxable.Checked = false;
            ItemName.Focus();
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            //check validation first to make sure there's a quantity, item and price
            bool hasErrors = false;
            var itemName = ItemName.Text.ToUpper();
            var isDecimal = Decimal.TryParse(ItemPrice.Text, out decimal price);
            var isShort = Int16.TryParse(ItemQty.Text, out short quantity);
            var isTaxable = Taxable.Checked;

            if (ItemName.Text.Equals("Enter Item"))
            {
                MessageBox.Show("You did not enter an item.  Please try again.");
                hasErrors = true;
            }
            else if (!isDecimal)
            {
                MessageBox.Show("Incorrect format for a price.  Please try again.");
                hasErrors = true;
            }
            else if (price == 0)
            {
                MessageBox.Show("No price entered.  Please try again.");
                hasErrors = true;
            }
            else if (!isShort)
            {
                MessageBox.Show("Incorrect format for quantity.  Please try again.");
                hasErrors = true;
            }
            else if (quantity == 0)
            {
                MessageBox.Show("No quantity entered.  Please try again.");
                hasErrors = true;
            }

            if (hasErrors) return;

            var totalPrice = price * quantity;

            //passed validation, try to add item to the table now
            FormModel model = new FormModel()
            {
                ItemName = itemName,
                ItemPrice = totalPrice,
                ItemQuantity = quantity,
                Taxable = isTaxable ? "T" : string.Empty
            };

            dao.AddDataRow(ItemData, model);
            dataGridView1.DataSource = ItemData;

            //clear out fields
            Initialize();
        }

        private void ExitApplication_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit Grocery List?", MessageBoxButtons.YesNo);

            if (result.ToString().Equals("Yes"))
                this.Close();
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    var item = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    var price = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    var qty = dataGridView1.Rows[i].Cells[2].Value.ToString();

                    var deleteRow = MessageBox.Show($"Do you want to delete {item} ?", "Delete Item?", MessageBoxButtons.YesNo);
                    if (deleteRow.ToString() == "Yes")
                    {
                        dao.DeleteDataRow(ItemData, item.ToString());
                        MessageBox.Show($"Item {item} with quantity {qty} for price {price} has been removed.");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("No items in list.");
                dataGridView1 = null;
            }
        }

        private void UpdateItem_Click(object sender, EventArgs e)
        {
            var formPopup = new ModalForm();
            formPopup.ShowDialog();

            var model = formPopup.GetDataFromModal();

            formPopup.Close();

            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    
                    var item = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    var price = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    var qty = dataGridView1.Rows[i].Cells[2].Value.ToString();

                    var deleteRow = MessageBox.Show($"Do you want to Update {item} ?", "Update Item?", MessageBoxButtons.YesNo);
                    if (deleteRow.ToString() == "Yes")
                    {
                        dao.DeleteDataRow(ItemData, item.ToString());
                        MessageBox.Show($"Item {item} with quantity {qty} for price {price} has been removed.");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("No items in list.");
                dataGridView1 = null;
            }
        }
    }
}
