namespace NewGroceryList
{
    partial class ListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ItemName = new System.Windows.Forms.TextBox();
            this.ItemPrice = new System.Windows.Forms.TextBox();
            this.ItemQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Taxable = new System.Windows.Forms.CheckBox();
            this.UpdateItem = new System.Windows.Forms.Button();
            this.AddItem = new System.Windows.Forms.Button();
            this.DeleteItem = new System.Windows.Forms.Button();
            this.SaveList = new System.Windows.Forms.Button();
            this.PrintList = new System.Windows.Forms.Button();
            this.EmailList = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LoadList = new System.Windows.Forms.Button();
            this.ExitApplication = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.SubTotal = new System.Windows.Forms.Label();
            this.TaxableItems = new System.Windows.Forms.Label();
            this.TotalItems = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.newPrintDialog = new System.Windows.Forms.PrintDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemName
            // 
            this.ItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemName.Location = new System.Drawing.Point(84, 12);
            this.ItemName.MaxLength = 33;
            this.ItemName.Name = "ItemName";
            this.ItemName.Size = new System.Drawing.Size(215, 35);
            this.ItemName.TabIndex = 0;
            // 
            // ItemPrice
            // 
            this.ItemPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemPrice.Location = new System.Drawing.Point(84, 53);
            this.ItemPrice.MaxLength = 6;
            this.ItemPrice.Name = "ItemPrice";
            this.ItemPrice.Size = new System.Drawing.Size(127, 35);
            this.ItemPrice.TabIndex = 1;
            // 
            // ItemQty
            // 
            this.ItemQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemQty.Location = new System.Drawing.Point(84, 94);
            this.ItemQty.MaxLength = 1;
            this.ItemQty.Name = "ItemQty";
            this.ItemQty.Size = new System.Drawing.Size(60, 35);
            this.ItemQty.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "Item:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 29);
            this.label2.TabIndex = 12;
            this.label2.Text = "Price:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 29);
            this.label3.TabIndex = 12;
            this.label3.Text = "Qty:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Taxable);
            this.panel1.Controls.Add(this.UpdateItem);
            this.panel1.Controls.Add(this.AddItem);
            this.panel1.Controls.Add(this.DeleteItem);
            this.panel1.Controls.Add(this.ItemName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ItemPrice);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ItemQty);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 332);
            this.panel1.TabIndex = 6;
            // 
            // Taxable
            // 
            this.Taxable.AutoSize = true;
            this.Taxable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Taxable.Location = new System.Drawing.Point(189, 97);
            this.Taxable.Name = "Taxable";
            this.Taxable.Size = new System.Drawing.Size(190, 33);
            this.Taxable.TabIndex = 3;
            this.Taxable.Text = "Taxable Item?";
            this.Taxable.UseVisualStyleBackColor = true;
            // 
            // UpdateItem
            // 
            this.UpdateItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateItem.Location = new System.Drawing.Point(220, 235);
            this.UpdateItem.Name = "UpdateItem";
            this.UpdateItem.Size = new System.Drawing.Size(181, 75);
            this.UpdateItem.TabIndex = 6;
            this.UpdateItem.Text = "Update Item";
            this.UpdateItem.UseVisualStyleBackColor = true;
            this.UpdateItem.Click += new System.EventHandler(this.UpdateItem_Click);
            // 
            // AddItem
            // 
            this.AddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddItem.Location = new System.Drawing.Point(118, 154);
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(181, 75);
            this.AddItem.TabIndex = 4;
            this.AddItem.Text = "Add Item";
            this.AddItem.UseVisualStyleBackColor = true;
            this.AddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // DeleteItem
            // 
            this.DeleteItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteItem.Location = new System.Drawing.Point(9, 235);
            this.DeleteItem.Name = "DeleteItem";
            this.DeleteItem.Size = new System.Drawing.Size(181, 75);
            this.DeleteItem.TabIndex = 5;
            this.DeleteItem.Text = "Remove Item";
            this.DeleteItem.UseVisualStyleBackColor = true;
            this.DeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // SaveList
            // 
            this.SaveList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveList.Location = new System.Drawing.Point(226, 17);
            this.SaveList.Name = "SaveList";
            this.SaveList.Size = new System.Drawing.Size(181, 75);
            this.SaveList.TabIndex = 8;
            this.SaveList.Text = "Save";
            this.SaveList.UseVisualStyleBackColor = true;
            this.SaveList.Click += new System.EventHandler(this.SaveList_Click);
            // 
            // PrintList
            // 
            this.PrintList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintList.Location = new System.Drawing.Point(15, 98);
            this.PrintList.Name = "PrintList";
            this.PrintList.Size = new System.Drawing.Size(181, 75);
            this.PrintList.TabIndex = 9;
            this.PrintList.Text = "Print";
            this.PrintList.UseVisualStyleBackColor = true;
            this.PrintList.Click += new System.EventHandler(this.PrintList_Click);
            // 
            // EmailList
            // 
            this.EmailList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailList.Location = new System.Drawing.Point(226, 98);
            this.EmailList.Name = "EmailList";
            this.EmailList.Size = new System.Drawing.Size(181, 75);
            this.EmailList.TabIndex = 10;
            this.EmailList.Text = "Share";
            this.EmailList.UseVisualStyleBackColor = true;
            this.EmailList.Click += new System.EventHandler(this.EmailList_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LoadList);
            this.panel2.Controls.Add(this.ExitApplication);
            this.panel2.Controls.Add(this.SaveList);
            this.panel2.Controls.Add(this.PrintList);
            this.panel2.Controls.Add(this.EmailList);
            this.panel2.Location = new System.Drawing.Point(7, 351);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(422, 283);
            this.panel2.TabIndex = 12;
            // 
            // LoadList
            // 
            this.LoadList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadList.Location = new System.Drawing.Point(15, 17);
            this.LoadList.Name = "LoadList";
            this.LoadList.Size = new System.Drawing.Size(181, 75);
            this.LoadList.TabIndex = 7;
            this.LoadList.Text = "Load";
            this.LoadList.UseVisualStyleBackColor = true;
            this.LoadList.Click += new System.EventHandler(this.LoadList_Click);
            // 
            // ExitApplication
            // 
            this.ExitApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitApplication.Location = new System.Drawing.Point(15, 181);
            this.ExitApplication.Name = "ExitApplication";
            this.ExitApplication.Size = new System.Drawing.Size(392, 72);
            this.ExitApplication.TabIndex = 11;
            this.ExitApplication.Text = "Close Application";
            this.ExitApplication.UseVisualStyleBackColor = true;
            this.ExitApplication.Click += new System.EventHandler(this.ExitApplication_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(434, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(770, 333);
            this.dataGridView1.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(435, 352);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(769, 264);
            this.panel3.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.SubTotal);
            this.panel4.Controls.Add(this.TaxableItems);
            this.panel4.Controls.Add(this.TotalItems);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(49, 46);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(669, 174);
            this.panel4.TabIndex = 11;
            // 
            // SubTotal
            // 
            this.SubTotal.AutoSize = true;
            this.SubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubTotal.Location = new System.Drawing.Point(410, 110);
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.Size = new System.Drawing.Size(131, 52);
            this.SubTotal.TabIndex = 12;
            this.SubTotal.Text = "$0.00";
            // 
            // TaxableItems
            // 
            this.TaxableItems.AutoSize = true;
            this.TaxableItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaxableItems.Location = new System.Drawing.Point(410, 58);
            this.TaxableItems.Name = "TaxableItems";
            this.TaxableItems.Size = new System.Drawing.Size(47, 52);
            this.TaxableItems.TabIndex = 12;
            this.TaxableItems.Text = "0";
            // 
            // TotalItems
            // 
            this.TotalItems.AutoSize = true;
            this.TotalItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalItems.Location = new System.Drawing.Point(410, 3);
            this.TotalItems.Name = "TotalItems";
            this.TotalItems.Size = new System.Drawing.Size(47, 52);
            this.TotalItems.TabIndex = 12;
            this.TotalItems.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(153, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(251, 52);
            this.label4.TabIndex = 12;
            this.label4.Text = "Total Items:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(183, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(221, 52);
            this.label6.TabIndex = 12;
            this.label6.Text = "Sub Total:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(95, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(309, 52);
            this.label5.TabIndex = 12;
            this.label5.Text = "Taxable Items:";
            // 
            // newPrintDialog
            // 
            this.newPrintDialog.UseEXDialog = true;
            // 
            // ListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 664);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grocery List App";
            this.Load += new System.EventHandler(this.ListForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox ItemName;
        private System.Windows.Forms.TextBox ItemPrice;
        private System.Windows.Forms.TextBox ItemQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AddItem;
        private System.Windows.Forms.Button SaveList;
        private System.Windows.Forms.Button PrintList;
        private System.Windows.Forms.Button EmailList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button UpdateItem;
        private System.Windows.Forms.Button DeleteItem;
        private System.Windows.Forms.CheckBox Taxable;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button ExitApplication;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label SubTotal;
        private System.Windows.Forms.Label TaxableItems;
        private System.Windows.Forms.Label TotalItems;
        private System.Windows.Forms.Button LoadList;
        private System.Windows.Forms.PrintDialog newPrintDialog;
    }
}

