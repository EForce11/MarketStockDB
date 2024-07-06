using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _222017034_Final_Project
{
    public partial class StokTakip : Form
    {
        public StokTakip()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-QICHVL0\\MSSQLSERVER01;Initial Catalog=222017034_DB;Integrated Security=True;Encrypt=False");

        public class Product
        {
            public int Id { get; set; }
            public string Category { get; set; }
            public string Brand { get; set; }
            public string ProductName { get; set; }
            public decimal PurchasePrice { get; set; }
            public int StockQuantity { get; set; }
            public DateTime PurchaseDate { get; set; }
        }

        private void StokTakip_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Product", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yükleme hatası: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                e.CellStyle.ForeColor = Color.Black;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Category = txtCategory.Text,
                Brand = txtBrand.Text,
                ProductName = txtName.Text,
                PurchaseDate = datePurchaseDate.Value
            };

            if (!decimal.TryParse(txtPrice.Text, out decimal purchasePrice))
            {
                MessageBox.Show("Geçersiz fiyat değeri.");
                return;
            }
            product.PurchasePrice = purchasePrice;
            product.StockQuantity = (int)numStock.Value;

            // Veritabanına ekleme işlemi
            AddProductToDatabase(product);
        }

        private void AddProductToDatabase(Product product)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Product (Category, Brand, ProductName, PurchasePrice, StockQuantity, PurchaseDate) VALUES (@Category, @Brand, @ProductName, @PurchasePrice, @StockQuantity, @PurchaseDate)", con);
                cmd.Parameters.AddWithValue("@Category", product.Category);
                cmd.Parameters.AddWithValue("@Brand", product.Brand);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@PurchasePrice", product.PurchasePrice);
                cmd.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
                cmd.Parameters.AddWithValue("@PurchaseDate", product.PurchaseDate);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occured adding the product: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtID.Text, out int id))
            {
                MessageBox.Show("Geçersiz ID değeri.");
                return;
            }

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Product WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    MessageBox.Show("Belirtilen ID'ye sahip ürün bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünü silerken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtID.Text, out int id))
            {
                MessageBox.Show("Geçersiz ID değeri.");
                return;
            }

            try
            {
                con.Open();
                StringBuilder queryBuilder = new StringBuilder("UPDATE Product SET ");
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(txtCategory.Text))
                {
                    queryBuilder.Append("Category = @Category, ");
                    parameters.Add(new SqlParameter("@Category", txtCategory.Text));
                }
                if (!string.IsNullOrEmpty(txtBrand.Text))
                {
                    queryBuilder.Append("Brand = @Brand, ");
                    parameters.Add(new SqlParameter("@Brand", txtBrand.Text));
                }
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    queryBuilder.Append("ProductName = @ProductName, ");
                    parameters.Add(new SqlParameter("@ProductName", txtName.Text));
                }
                if (!string.IsNullOrEmpty(txtPrice.Text))
                {
                    if (!decimal.TryParse(txtPrice.Text, out decimal purchasePrice))
                    {
                        MessageBox.Show("Geçersiz fiyat değeri.");
                        return;
                    }
                    queryBuilder.Append("PurchasePrice = @PurchasePrice, ");
                    parameters.Add(new SqlParameter("@PurchasePrice", purchasePrice));
                }
                if (numStock.Value > 0)
                {
                    queryBuilder.Append("StockQuantity = @StockQuantity, ");
                    parameters.Add(new SqlParameter("@StockQuantity", (int)numStock.Value));
                }
                if (datePurchaseDate.Value != DateTimePicker.MinimumDateTime)
                {
                    queryBuilder.Append("PurchaseDate = @PurchaseDate, ");
                    parameters.Add(new SqlParameter("@PurchaseDate", datePurchaseDate.Value));
                }

                queryBuilder.Length -= 2; // Remove the last comma and space
                queryBuilder.Append(" WHERE Id = @Id");
                parameters.Add(new SqlParameter("@Id", id));

                SqlCommand cmd = new SqlCommand(queryBuilder.ToString(), con);
                cmd.Parameters.AddRange(parameters.ToArray());

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    MessageBox.Show("Belirtilen ID'ye sahip ürün bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünü güncellerken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            LoadData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllControls(this);
        }

        private void ClearAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                else if (control is NumericUpDown)
                {
                    ((NumericUpDown)control).Value = 0;
                }
                else if (control is DateTimePicker)
                {
                    ((DateTimePicker)control).Value = DateTime.Today;
                }
                else if (control.HasChildren)
                {
                    ClearAllControls(control);
                }
            }
        }
    }
}
