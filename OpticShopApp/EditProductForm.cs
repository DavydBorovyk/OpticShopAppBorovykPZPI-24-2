using System;
using System.Windows.Forms;

namespace OpticShopApp
{
    public partial class EditProductForm : Form
    {
        private int productId;
        private bool editMode = false;

        // ADD
        public EditProductForm()
        {
            InitializeComponent();
            editMode = false;
        }

        // EDIT
        public EditProductForm(
            int id,
            string name,
            decimal price,
            int stock,
            int categoryId,
            int brandId
        ) : this()
        {
            editMode = true;
            productId = id;

            textBoxName.Text = name;
            textBoxPrice.Text = price.ToString();
            textBoxStock.Text = stock.ToString();
            comboBoxCategory.SelectedValue = categoryId;
            comboBoxBrand.SelectedValue = brandId;
        }

        private void EditProductForm_Load(object sender, EventArgs e)
        {
            categoriesTableAdapter.Fill(opticShopDataSet.Categories);
            brandsTableAdapter.Fill(opticShopDataSet.Brands);
            productsTableAdapter.Fill(opticShopDataSet.Products);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (editMode)
                {
                    var row = opticShopDataSet.Products.FindByProductID(productId);

                    if (row == null)
                    {
                        MessageBox.Show("Товар не знайдено!");
                        return;
                    }

                    row.ProductName = textBoxName.Text;
                    row.Price = Convert.ToDecimal(textBoxPrice.Text);
                    row.Stock = Convert.ToInt32(textBoxStock.Text);
                    row.CategoryID = Convert.ToInt32(comboBoxCategory.SelectedValue);
                    row.BrandID = Convert.ToInt32(comboBoxBrand.SelectedValue);
                }
                else
                {
                    var row = opticShopDataSet.Products.NewProductsRow();

                    row.ProductName = textBoxName.Text;
                    row.Price = Convert.ToDecimal(textBoxPrice.Text);
                    row.Stock = Convert.ToInt32(textBoxStock.Text);
                    row.CategoryID = Convert.ToInt32(comboBoxCategory.SelectedValue);
                    row.BrandID = Convert.ToInt32(comboBoxBrand.SelectedValue);

                    opticShopDataSet.Products.AddProductsRow(row);
                }

                productsTableAdapter.Update(opticShopDataSet.Products);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
