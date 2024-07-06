using System;
using System.Windows.Forms;
using System.Drawing;

namespace _222017034_Final_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // TextBox'larýn TextChanged olaylarýný baðlayýn
            txtName.TextChanged += TextBox_TextChanged;
            txtPasswd.TextChanged += TextBox_TextChanged;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "admin" && txtPasswd.Text == "123456")
            {
                btnLogin.ForeColor = Color.Lime;
                btnLogin.Text = "SUCCESS";

                StokTakip f2 = new StokTakip();
                f2.Show();
                this.Hide();
            }
            else
            {
                btnLogin.ForeColor = Color.Red;
                btnLogin.Text = "FAIL";
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (btnLogin.ForeColor == Color.Red && btnLogin.Text == "FAIL")
            {
                btnLogin.ForeColor = Color.White;
                btnLogin.Text = "LOGIN";
            }
        }
    }
}
