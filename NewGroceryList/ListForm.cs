using NewGroceryList.Dao;
using NewGroceryList.FileHandlers;
using NewGroceryList.Models;
using System.Globalization;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NewGroceryList
{
    public partial class ListForm : Form
    {
        public static DataTable ItemData = new DataTable();
        public static IAppDao dao;
        public static IFileHandler Fhandler;

        #region Constructors

        public ListForm()
        {
            InitializeComponent();
        }

        static ListForm()
        {
            dao = new AppDao();
            Fhandler = new FileHandler();
            ItemData = dao.CreateItemTable();
        }
        #endregion

        #region Handlers

        private void ListForm_Load(object sender, EventArgs e)
        {
            Initialize();
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


            //write totals
            UpdateTotals();

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
                        UpdateTotals();
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
            if (dataGridView1.Rows.Count > 0)
            {
                FormModel model;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    model = new FormModel();
                    var item = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    var price = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    var qty = dataGridView1.Rows[i].Cells[2].Value.ToString();

                    var deleteRow = MessageBox.Show($"Do you want to Update {item} ?", "Update Item?", MessageBoxButtons.YesNo);
                    if (deleteRow.ToString() == "Yes")
                    {
                        //pass the old values chosen into the new model for population
                        using (var formPopup = new ModalForm(item, price, qty))
                        {
                            formPopup.ShowDialog();
                            model = formPopup.GetDataFromModal();
                            dao.UpdateDataRow(ItemData, model);
                            UpdateTotals();
                        }

                        MessageBox.Show($"Item {item} with quantity {qty} for price {price} has been updated.");
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

        private void SaveList_Click(object sender, EventArgs e)
        {
            //creates a fixed length file and saves it to the computer

            if (!SaveFile())
            {
                //display error to the user if issues creating and saving file.
                MessageBox.Show("File did not create properly.", "File Error", MessageBoxButtons.OK);
            }

        }

        private void PrintList_Click(object sender, EventArgs e)
        {
            //create file, save it, then print it.
        }

        private void EmailList_Click(object sender, EventArgs e)
        {
            //New form needed to collect email info.

        }

        #endregion

        #region Worker Methods

        private void Initialize()
        {
            ItemName.Text = "Enter Item";
            ItemQty.Text = "0";
            ItemPrice.Text = "0.00";
            Taxable.Checked = false;
            ItemName.Focus();
        }

        private void UpdateTotals()
        {
            var totItems = ItemData.Rows.Count;
            if (totItems > 0)
            {
                var taxItems = ItemData.AsEnumerable().Where(x => x["IsTaxable"].ToString() == "T").Count();
                decimal subTotal = 0;

                foreach (DataRow row in ItemData.Rows)
                {
                    subTotal += (decimal)row["ItemPrice"];
                }

                TotalItems.Text = totItems.ToString();
                TaxableItems.Text = taxItems.ToString();
                SubTotal.Text = subTotal.ToString("$0.00");
            }
        }

        /// <summary>
        /// SaveFile
        /// Method creates and saves a fixed length record file to directory of user's choosing
        /// </summary>
        /// <returns>bool</returns>
        private bool SaveFile()
        {
            bool fileSaved = false;

            if (ItemData.Rows.Count > 0)
            {
                var currTime = DateTime.Now;

                //4.  Create the file, put the record into the file (with a file header), and prompt user on location.
                var header = Fhandler.SetHeader(currTime);

                var location = @"C:\ShoppingList\"; //name of the directory to put files into
                var saveFiles = "savefiles";

                //List to be printed out
                var listName = string.Format(@"ShoppingList_{0}{1}.txt",
                    currTime.Date.ToString("MMddyyyy"), currTime.ToString("HHmmss"));

                //list to be saved for future loading
                var saveName = string.Format(@".\{0}\ShoppingList_{1}.csv",
                    saveFiles, currTime.Date.ToString("MMddyyyy")); //name of the file

                if (!Directory.Exists(location))
                {
                    Directory.CreateDirectory(location);
                    Directory.SetCurrentDirectory(location);
                    Directory.CreateDirectory(saveFiles);
                }
                else
                {
                    Directory.SetCurrentDirectory(location);
                }

                if (ItemData.Rows.Count > 0)
                {
                    using (StreamWriter srS = new StreamWriter(saveName))
                    using (StreamWriter sr = new StreamWriter(listName))
                    {
                        sr.WriteLine(header); //write header

                        foreach (DataRow row in ItemData.Rows)
                        {
                            sr.WriteLine(Fhandler.WriteDetailLine(row)); //write to the printed file
                            srS.WriteLine(Fhandler.WriteSaveDetailLine(row)); //write to the save file.
                        }
                    }
                    fileSaved = true;
                }
            }

            return fileSaved;
        }

        private bool LoadFile()
        {
            bool fileLoaded = false;
            try
            {
                var fileContent = string.Empty;
                var filePath = string.Empty;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = @"c:\ShoppingList\savefiles";
                    openFileDialog.Filter = "csv files (*.csv)|*.csv";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                        //Read the contents of the file into a stream
                        var fileStream = openFileDialog.OpenFile();

                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            fileContent = reader.ReadToEnd();
                        }
                    }
                }

                fileLoaded = true;
            }
            catch (Exception e)
            {
                fileLoaded = false;
            }

            return fileLoaded;
        }

        private bool PrintFile()
        {
            bool filePrinted = false;

            return filePrinted;
        }

        private bool ShareList()
        {
            bool emailSent = false;

            return emailSent;
        }



        #endregion

        private void LoadList_Click(object sender, EventArgs e)
        {
            LoadFile();
        }
    }
}
