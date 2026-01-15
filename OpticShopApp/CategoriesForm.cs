using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpticShopApp
{
	public partial class CategoriesForm : OpticShopApp.MainForm
	{
		public CategoriesForm()
		{
			InitializeComponent();
		}

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'opticShopDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.opticShopDataSet.Products);
            // TODO: This line of code loads data into the 'opticShopDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.opticShopDataSet.Products);
            // TODO: This line of code loads data into the 'opticShopDataSet.Categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.opticShopDataSet.Categories);

        }
    }
}
