namespace OpticShopApp
{
    partial class QueryEdit
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
            this.TestInput = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonTopProducts = new System.Windows.Forms.Button();
            this.buttonBrandRevenue = new System.Windows.Forms.Button();
            this.buttonClientSales = new System.Windows.Forms.Button();
            this.buttonStock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TestInput
            // 
            this.TestInput.Location = new System.Drawing.Point(60, 22);
            this.TestInput.Name = "TestInput";
            this.TestInput.Size = new System.Drawing.Size(183, 50);
            this.TestInput.TabIndex = 0;
            this.TestInput.Text = "SELECT * FROM Products";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(249, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Do SQL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(359, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(467, 24);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 29);
            this.button3.TabIndex = 3;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(52, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(708, 277);
            this.dataGridView1.TabIndex = 4;
            // 
            // buttonTopProducts
            // 
            this.buttonTopProducts.Location = new System.Drawing.Point(249, 59);
            this.buttonTopProducts.Name = "buttonTopProducts";
            this.buttonTopProducts.Size = new System.Drawing.Size(121, 60);
            this.buttonTopProducts.TabIndex = 5;
            this.buttonTopProducts.Text = "Топ продажів";
            this.buttonTopProducts.UseVisualStyleBackColor = true;
            this.buttonTopProducts.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonBrandRevenue
            // 
            this.buttonBrandRevenue.Location = new System.Drawing.Point(376, 59);
            this.buttonBrandRevenue.Name = "buttonBrandRevenue";
            this.buttonBrandRevenue.Size = new System.Drawing.Size(117, 60);
            this.buttonBrandRevenue.TabIndex = 6;
            this.buttonBrandRevenue.Text = "Дохід по брендам";
            this.buttonBrandRevenue.UseVisualStyleBackColor = true;
            this.buttonBrandRevenue.Click += new System.EventHandler(this.buttonBrandRevenue_Click);
            // 
            // buttonClientSales
            // 
            this.buttonClientSales.Location = new System.Drawing.Point(499, 59);
            this.buttonClientSales.Name = "buttonClientSales";
            this.buttonClientSales.Size = new System.Drawing.Size(119, 60);
            this.buttonClientSales.TabIndex = 7;
            this.buttonClientSales.Text = "Клієнти";
            this.buttonClientSales.UseVisualStyleBackColor = true;
            this.buttonClientSales.Click += new System.EventHandler(this.buttonClientSales_Click);
            // 
            // buttonStock
            // 
            this.buttonStock.Location = new System.Drawing.Point(624, 59);
            this.buttonStock.Name = "buttonStock";
            this.buttonStock.Size = new System.Drawing.Size(108, 60);
            this.buttonStock.TabIndex = 8;
            this.buttonStock.Text = "Склад";
            this.buttonStock.UseVisualStyleBackColor = true;
            this.buttonStock.Click += new System.EventHandler(this.buttonStock_Click);
            // 
            // QueryEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStock);
            this.Controls.Add(this.buttonClientSales);
            this.Controls.Add(this.buttonBrandRevenue);
            this.Controls.Add(this.buttonTopProducts);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TestInput);
            this.Name = "QueryEdit";
            this.Text = "QueryEdit";
            this.Load += new System.EventHandler(this.QueryEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox TestInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonTopProducts;
        private System.Windows.Forms.Button buttonBrandRevenue;
        private System.Windows.Forms.Button buttonClientSales;
        private System.Windows.Forms.Button buttonStock;
    }
}