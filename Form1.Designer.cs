namespace _222017034_Final_Project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            txtName = new TextBox();
            txtPasswd = new TextBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Gray;
            btnLogin.BackgroundImageLayout = ImageLayout.None;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(68, 336);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(137, 77);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtName
            // 
            txtName.BackColor = Color.Gray;
            txtName.Font = new Font("Segoe UI", 13F);
            txtName.ForeColor = Color.White;
            txtName.Location = new Point(50, 143);
            txtName.Name = "txtName";
            txtName.Size = new Size(182, 31);
            txtName.TabIndex = 1;
            // 
            // txtPasswd
            // 
            txtPasswd.BackColor = Color.Gray;
            txtPasswd.Font = new Font("Segoe UI", 13F);
            txtPasswd.ForeColor = Color.White;
            txtPasswd.Location = new Point(50, 255);
            txtPasswd.Name = "txtPasswd";
            txtPasswd.PasswordChar = '*';
            txtPasswd.Size = new Size(182, 31);
            txtPasswd.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 20F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(69, 103);
            label2.Name = "label2";
            label2.Size = new Size(136, 37);
            label2.TabIndex = 4;
            label2.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 20F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(69, 215);
            label1.Name = "label1";
            label1.Size = new Size(128, 37);
            label1.TabIndex = 5;
            label1.Text = "Password";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(279, 450);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txtPasswd);
            Controls.Add(txtName);
            Controls.Add(btnLogin);
            Name = "Form1";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private TextBox txtName;
        private TextBox txtPasswd;
        private Label label2;
        private Label label1;
    }
}
