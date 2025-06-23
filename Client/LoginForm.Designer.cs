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
            label2 = new Label();
            inputUsername = new TextBox();
            label3 = new Label();
            inputPassword = new TextBox();
            buttonLogin = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 168);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // inputUsername
            // 
            inputUsername.Location = new Point(84, 165);
            inputUsername.Margin = new Padding(2);
            inputUsername.Name = "inputUsername";
            inputUsername.Size = new Size(156, 23);
            inputUsername.TabIndex = 2;
            inputUsername.Text = "U001";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 205);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 3;
            label3.Text = "Password";
            // 
            // inputPassword
            // 
            inputPassword.Location = new Point(84, 202);
            inputPassword.Margin = new Padding(2);
            inputPassword.Name = "inputPassword";
            inputPassword.Size = new Size(156, 23);
            inputPassword.TabIndex = 4;
            inputPassword.Text = "hash123";
            inputPassword.UseSystemPasswordChar = true;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(84, 241);
            buttonLogin.Margin = new Padding(2);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(61, 24);
            buttonLogin.TabIndex = 5;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(265, 117);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(288, 285);
            Controls.Add(pictureBox1);
            Controls.Add(buttonLogin);
            Controls.Add(inputPassword);
            Controls.Add(label3);
            Controls.Add(inputUsername);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Smile & Sunshine Toy";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox inputUsername;
        private Label label3;
        private TextBox inputPassword;
        private Button buttonLogin;
        private PictureBox pictureBox1;
    }
}
