using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace OpticShopApp
{
    public partial class MainForm : Form
    {
        private bool _formLoaded = false;

        public MainForm()
        {
            InitializeComponent();
        }
        private const string ConnectionString =
    @"Data Source=DESKTOP-F33QBUH\SQLEXPRESS;Initial Catalog=OpticShop;Integrated Security=True";

        private void MainForm_Load(object sender, EventArgs e)
        {
            categoriesTableAdapter.Fill(opticShopDataSet.Categories);
            brandsTableAdapter.Fill(opticShopDataSet.Brands);
            productsTableAdapter.Fill(opticShopDataSet.Products);

            dataGridView1.DataSource = productsBindingSource;

            comboBoxCategoryFilter.DataSource = categoriesBindingSource;
            comboBoxCategoryFilter.DisplayMember = "CategoryName";
            comboBoxCategoryFilter.ValueMember = "CategoryID";
            comboBoxCategoryFilter.SelectedIndex = -1;

            comboBoxBrandFilter.DataSource = brandsBindingSource;
            comboBoxBrandFilter.DisplayMember = "BrandName";
            comboBoxBrandFilter.ValueMember = "BrandID";
            comboBoxBrandFilter.SelectedIndex = -1;

            _formLoaded = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Validate();
            productsBindingSource.EndEdit();
            tableAdapterManager.UpdateAll(opticShopDataSet);
        }

        private void ApplyFilter()
        {
            if (!_formLoaded) return;

            string filter = "";

            if (!string.IsNullOrWhiteSpace(textBoxNameFilter.Text))
                filter += $"ProductName LIKE '%{textBoxNameFilter.Text}%'";

            if (decimal.TryParse(textBoxPriceFrom.Text, out decimal from))
            {
                if (filter != "") filter += " AND ";
                filter += $"Price >= {from.ToString().Replace(',', '.')}";
            }

            if (decimal.TryParse(textBoxPriceTo.Text, out decimal to))
            {
                if (filter != "") filter += " AND ";
                filter += $"Price <= {to.ToString().Replace(',', '.')}";
            }

            if (comboBoxCategoryFilter.SelectedValue != null)
            {
                if (filter != "") filter += " AND ";
                filter += $"CategoryID = {comboBoxCategoryFilter.SelectedValue}";
            }

            if (comboBoxBrandFilter.SelectedValue != null)
            {
                if (filter != "") filter += " AND ";
                filter += $"BrandID = {comboBoxBrandFilter.SelectedValue}";
            }

            productsBindingSource.Filter = filter;
        }

        private void textBoxNameFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
            ApplySearchHighlight();
        }

        private void textBoxPriceFrom_TextChanged(object sender, EventArgs e) => ApplyFilter();
        private void textBoxPriceTo_TextChanged(object sender, EventArgs e) => ApplyFilter();
        private void comboBoxCategoryFilter_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();
        private void comboBoxBrandFilter_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();

        private void buttonResetFilter_Click(object sender, EventArgs e)
        {
            textBoxNameFilter.Clear();
            textBoxPriceFrom.Clear();
            textBoxPriceTo.Clear();
            comboBoxCategoryFilter.SelectedIndex = -1;
            comboBoxBrandFilter.SelectedIndex = -1;
            productsBindingSource.RemoveFilter();
            ApplySearchHighlight();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            ApplySearchHighlight();
        }

        private void ApplySearchHighlight()
        {
            string text = textBoxSearch.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dataGridView1.Rows)
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White;
                    cell.Style.ForeColor = Color.Black;
                }

            if (text == "") return;

            foreach (DataGridViewRow row in dataGridView1.Rows)
                foreach (DataGridViewCell cell in row.Cells)
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(text))
                        cell.Style.BackColor = Color.Lime;
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = productsBindingSource;
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = categoriesBindingSource;
        }

        private void brandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = brandsBindingSource;
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditProductForm f = new EditProductForm();   
            if (f.ShowDialog() == DialogResult.OK)
            {
                productsTableAdapter.Fill(opticShopDataSet.Products);
            }
        }

        

        private void editProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productsBindingSource.Current == null) return;

            DataRowView r = (DataRowView)productsBindingSource.Current;

            EditProductForm f = new EditProductForm(
                Convert.ToInt32(r["ProductID"]),
                r["ProductName"].ToString(),
                Convert.ToDecimal(r["Price"]),
                Convert.ToInt32(r["Stock"]),
                Convert.ToInt32(r["CategoryID"]),
                Convert.ToInt32(r["BrandID"])
            );

            if (f.ShowDialog() == DialogResult.OK)
                productsTableAdapter.Fill(opticShopDataSet.Products);
        }

        private void deleteProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productsBindingSource.Current == null) return;

            if (MessageBox.Show("Delete product?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                productsBindingSource.RemoveCurrent();
                tableAdapterManager.UpdateAll(opticShopDataSet);
            }
        }

        private void queryEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryEdit f = new QueryEdit();
            f.ShowDialog();
            productsTableAdapter.Fill(opticShopDataSet.Products);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void comboBoxCategoryFilter_SelectedIndexChanged_1(object sender, EventArgs e) { }

        private void buttonExportAccounting_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
SELECT 
    s.SaleID,
    s.SaleDate,
    c.FullName,
    p.ProductName,
    sd.Quantity,
    sd.Price,
    sd.Quantity * sd.Price AS SumLine
FROM Sales s
JOIN Clients c ON s.ClientID = c.ClientID
JOIN SaleDetails sd ON s.SaleID = sd.SaleID
JOIN Products p ON sd.ProductID = p.ProductID
ORDER BY s.SaleDate
", conn);

                SqlDataReader r = cmd.ExecuteReader();

                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Text files (*.txt)|*.txt";
                dlg.FileName = "AccountingReport.txt";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(dlg.FileName))
                    {
                        while (r.Read())
                        {
                            sw.WriteLine($"{r[0]} | {r[1]} | {r[2]} | {r[3]} | {r[4]} x {r[5]} = {r[6]}");
                        }
                    }
                    MessageBox.Show("Файл бухгалтера збережено");
                }
            }
        }

        private void buttonExportManager_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
SELECT
    COUNT(SaleID) AS TotalOrders,
    SUM(TotalAmount) AS TotalRevenue
FROM Sales
", conn);

                SqlDataReader r = cmd.ExecuteReader();

                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Text files (*.txt)|*.txt";
                dlg.FileName = "ManagerReport.txt";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(dlg.FileName))
                    {
                        if (r.Read())
                        {
                            sw.WriteLine("ЗВІТ МЕНЕДЖЕРА");
                            sw.WriteLine("-------------------");
                            sw.WriteLine("Загальна кількість замовлень: " + r[0]);
                            sw.WriteLine("Загальний оборот: " + r[1]);
                        }
                    }
                    MessageBox.Show("Звіт менеджера збережено");
                }
            }
        }

        private void buttonReceipts_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"
        SELECT 
            s.SaleID,
            s.SaleDate,
            c.FullName AS Client,
            p.ProductName,
            sd.Quantity,
            sd.Price,
            (sd.Quantity * sd.Price) AS ItemTotal,
            s.TotalAmount
        FROM Sales s
        JOIN Clients c ON s.ClientID = c.ClientID
        JOIN SaleDetails sd ON s.SaleID = sd.SaleID
        JOIN Products p ON sd.ProductID = p.ProductID
        ORDER BY s.SaleDate DESC, s.SaleID";

                using (SqlConnection conn = new SqlConnection(
                    @"Data Source=DESKTOP-F33QBUH\SQLEXPRESS;Initial Catalog=OpticShop;Integrated Security=True"))
                {
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
            }
        }

    