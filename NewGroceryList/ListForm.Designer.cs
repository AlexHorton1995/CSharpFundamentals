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
            this.AddItem = new System.Windows.Forms.Button();
            this.SaveList = new System.Windows.Forms.Button();
            this.PrintList = new System.Windows.Forms.Button();
            this.EmailList = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UpdateItem = new System.Windows.Forms.Button();
            this.DeleteItem = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TotalList = new System.Windows.Forms.Button();
            this.Taxable = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ExitApplication = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemName
            // 
            this.ItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemName.Location = new System.Drawing.Point(84, 12);
            this.ItemName.Name = "ItemName";
            this.ItemName.Size = new System.Drawing.Size(215, 35);
            this.ItemName.TabIndex = 0;
            // 
            // ItemPrice
            // 
            this.ItemPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemPrice.Location = new System.Drawing.Point(84, 53);
            this.ItemPrice.Name = "ItemPrice";
            this.ItemPrice.Size = new System.Drawing.Size(127, 35);
            this.ItemPrice.TabIndex = 1;
            // 
            // ItemQty
            // 
            this.ItemQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemQty.Location = new System.Drawing.Point(84, 94);
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
            this.label1.TabIndex = 3;
            this.label1.Text = "Item:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Price:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Qty:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Taxable);
            this.panel1.Controls.Add(this.AddItem);
            this.panel1.Controls.Add(this.ItemName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ItemPrice);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ItemQty);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 194);
            this.panel1.TabIndex = 6;
            // 
            // AddItem
            // 
            this.AddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddItem.Location = new System.Drawing.Point(218, 56);
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(184, 73);
            this.AddItem.TabIndex = 6;
            this.AddItem.Text = "Add Item";
            this.AddItem.UseVisualStyleBackColor = true;
            this.AddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // SaveList
            // 
            this.SaveList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveList.Location = new System.Drawing.Point(3, 9);
            this.SaveList.Name = "SaveList";
            this.SaveList.Size = new System.Drawing.Size(148, 104);
            this.SaveList.TabIndex = 8;
            this.SaveList.Text = "Save List";
            this.SaveList.UseVisualStyleBackColor = true;
            // 
            // PrintList
            // 
            this.PrintList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintList.Location = new System.Drawing.Point(3, 119);
            this.PrintList.Name = "PrintList";
            this.PrintList.Size = new System.Drawing.Size(148, 104);
            this.PrintList.TabIndex = 9;
            this.PrintList.Text = "Print List";
            this.PrintList.UseVisualStyleBackColor = true;
            // 
            // EmailList
            // 
            this.EmailList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailList.Location = new System.Drawing.Point(3, 229);
            this.EmailList.Name = "EmailList";
            this.EmailList.Size = new System.Drawing.Size(148, 93);
            this.EmailList.TabIndex = 10;
            this.EmailList.Text = "Share List";
            this.EmailList.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ExitApplication);
            this.panel2.Controls.Add(this.TotalList);
            this.panel2.Controls.Add(this.UpdateItem);
            this.panel2.Controls.Add(this.DeleteItem);
            this.panel2.Controls.Add(this.SaveList);
            this.panel2.Controls.Add(this.PrintList);
            this.panel2.Controls.Add(this.EmailList);
            this.panel2.Location = new System.Drawing.Point(6, 213);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(422, 403);
            this.panel2.TabIndex = 12;
            // 
            // UpdateItem
            // 
            this.UpdateItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateItem.Location = new System.Drawing.Point(157, 9);
            this.UpdateItem.Name = "UpdateItem";
            this.UpdateItem.Size = new System.Drawing.Size(251, 104);
            this.UpdateItem.TabIndex = 12;
            this.UpdateItem.Text = "Update Item";
            this.UpdateItem.UseVisualStyleBackColor = true;
            this.UpdateItem.Click += new System.EventHandler(this.UpdateItem_Click);
            // 
            // DeleteItem
            // 
            this.DeleteItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteItem.Location = new System.Drawing.Point(158, 119);
            this.DeleteItem.Name = "DeleteItem";
            this.DeleteItem.Size = new System.Drawing.Size(251, 104);
            this.DeleteItem.TabIndex = 11;
            this.DeleteItem.Text = "Remove Item";
            this.DeleteItem.UseVisualStyleBackColor = true;
            this.DeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
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
            this.dataGridView1.TabIndex = 11;
            // 
            // TotalList
            // 
            this.TotalList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalList.Location = new System.Drawing.Point(157, 229);
            this.TotalList.Name = "TotalList";
            this.TotalList.Size = new System.Drawing.Size(251, 93);
            this.TotalList.TabIndex = 13;
            this.TotalList.Text = "Total List";
            this.TotalList.UseVisualStyleBackColor = true;
            // 
            // Taxable
            // 
            this.Taxable.AutoSize = true;
            this.Taxable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Taxable.Location = new System.Drawing.Point(84, 155);
            this.Taxable.Name = "Taxable";
            this.Taxable.Size = new System.Drawing.Size(190, 33);
            this.Taxable.TabIndex = 7;
            this.Taxable.Text = "Taxable Item?";
            this.Taxable.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(435, 352);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(769, 264);
            this.panel3.TabIndex = 13;
            // 
            // ExitApplication
            // 
            this.ExitApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitApplication.Location = new System.Drawing.Point(3, 328);
            this.ExitApplication.Name = "ExitApplication";
            this.ExitApplication.Size = new System.Drawing.Size(404, 72);
            this.ExitApplication.TabIndex = 14;
            this.ExitApplication.Text = "Close Application";
            this.ExitApplication.UseVisualStyleBackColor = true;
            this.ExitApplication.Click += new System.EventHandler(this.ExitApplication_Click);
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
        private System.Windows.Forms.Button TotalList;
        private System.Windows.Forms.CheckBox Taxable;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button ExitApplication;
    }
}

