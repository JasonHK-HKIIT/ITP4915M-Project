namespace Client
{
    partial class LoginForm
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
            this.label1 = new Label();
            this.label2 = new Label();
            this.inputUsername = new TextBox();
            this.label3 = new Label();
            this.inputPassword = new TextBox();
            this.buttonLogin = new Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft JhengHei UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 136);
            this.label1.Location = new Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(301, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Smile && Sunshine Toy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(17, 65);
            this.label2.Name = "label2";
            this.label2.Size = new Size(80, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // inputUsername
            // 
            this.inputUsername.Location = new Point(103, 62);
            this.inputUsername.Name = "inputUsername";
            this.inputUsername.Size = new Size(200, 27);
            this.inputUsername.TabIndex = 2;
            this.inputUsername.Text = "U001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(17, 98);
            this.label3.Name = "label3";
            this.label3.Size = new Size(77, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password";
            // 
            // inputPassword
            // 
            this.inputPassword.Location = new Point(103, 95);
            this.inputPassword.Name = "inputPassword";
            this.inputPassword.Size = new Size(200, 27);
            this.inputPassword.TabIndex = 4;
            this.inputPassword.Text = "hash123";
            this.inputPassword.UseSystemPasswordChar = true;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new Point(113, 143);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new Size(94, 29);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += this.buttonLogin_Click;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(324, 186);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.inputPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inputUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Smile & Sunshine Toy";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox inputUsername;
        private Label label3;
        private TextBox inputPassword;
        private Button buttonLogin;
    }
}
