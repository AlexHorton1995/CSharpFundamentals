using NewGroceryList.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewGroceryList
{
    public partial class ModalForm : Form
    {
        public string inItem { get; set; }
        public string inPrice { get; set; }
        public string inQty { get; set; }

        public ModalForm(string item, string price, string qty)
        {
            InitializeComponent();
            this.inItem = item;
            this.inPrice = price;
            this.inQty = qty;
        }

        public FormModel GetDataFromModal()
        {
            var iName = ItemName.Text;
            decimal.TryParse(ItemPrice.Text, out decimal price);
            Int16.TryParse(ItemQty.Text, out short qty);
            var iQty = qty;
            var iPrice = price * qty;

            FormModel retModel = new FormModel()
            {
                ItemName = iName,
                ItemPrice = iPrice,
                ItemQuantity = iQty,
                Taxable = Taxable.Checked ? "T" : string.Empty
            };

            return retModel;
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

            this.Close();
        }

        private void ModalForm_Load(object sender, EventArgs e)
        {
            decimal.TryParse(inPrice, out decimal origPrice);
            Int32.TryParse(inQty, out int qty);

            ItemName.Text = this.inItem;
            ItemQty.Text = "1";
            ItemPrice.Text = (origPrice / qty).ToString();
            Taxable.Checked = false;
            ItemName.Focus();
        }
    }
}
