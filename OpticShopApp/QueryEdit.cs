using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OpticShopApp
{
    public partial class QueryEdit : Form
    {
        private const string ConnectionString =
            @"Data Source=DESKTOP-F33QBUH\SQLEXPRESS;Initial Catalog=OpticShop;Integrated Security=True";

        public QueryEdit()
        {
            InitializeComponent();
        }

        private void QueryEdit_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlconn = new SqlConnection(ConnectionString))
                {
                    sqlconn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(TestInput.Text, sqlconn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Error:\n" + ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            TestInput.Clear();
            TestInput.Text = "SELECT ";
            TestInput.Focus();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TestInput.Text =
@"SELECT 
    P.ProductName,
    SUM(SD.Quantity) AS TotalSold,
    SUM(SD.Quantity * SD.Price) AS TotalRevenue
FROM SaleDetails SD
JOIN Products P ON SD.ProductID = P.ProductID
GROUP BY P.ProductName
ORDER BY TotalSold DESC";
        }

        private void buttonBrandRevenue_Click(object sender, EventArgs e)
        {
            TestInput.Text =
            @"SELECT 
    B.BrandName,
    SUM(SD.Quantity * SD.Price) AS Revenue
FROM SaleDetails SD
JOIN Products P ON SD.ProductID = P.ProductID
JOIN Brands B ON P.BrandID = B.BrandID
GROUP BY B.BrandName
ORDER BY Revenue DESC";
        }

        private void buttonClientSales_Click(object sender, EventArgs e)
        {
            TestInput.Text =
@"SELECT 
    C.FullName,
    COUNT(S.SaleID) AS OrdersCount,
    SUM(S.TotalAmount) AS TotalSpent
FROM Sales S
JOIN Clients C ON S.ClientID = C.ClientID
GROUP BY C.FullName
ORDER BY TotalSpent DESC";
        }

        private void buttonStock_Click(object sender, EventArgs e)
        {
            TestInput.Text =
@"SELECT 
    ProductName,
    Stock,
    Price,
    (Stock * Price) AS StockValue
FROM Products
ORDER BY Stock ASC";
        }
    }
}
