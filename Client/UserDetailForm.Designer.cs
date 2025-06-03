using Org.BouncyCastle.Asn1.Crmf;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Client
{
    partial class UserDetailForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.UsernameField = new TextBox();
            this.PasswordField = new TextBox();
            this.RoleField = new ComboBox();
            this.ActivatedField = new CheckBox();
            this.SaveButton = new Button();
            this.CancelButton = new Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(13, 16);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(80, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(16, 51);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(77, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(53, 86);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(40, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Role";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(19, 119);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(74, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Activated";
            // 
            // UsernameField
            // 
            this.UsernameField.Location = new Point(101, 13);
            this.UsernameField.Margin = new Padding(4);
            this.UsernameField.Name = "UsernameField";
            this.UsernameField.Size = new Size(321, 27);
            this.UsernameField.TabIndex = 4;
            // 
            // PasswordField
            // 
            this.PasswordField.Location = new Point(101, 48);
            this.PasswordField.Margin = new Padding(4);
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.Size = new Size(321, 27);
            this.PasswordField.TabIndex = 5;
            this.PasswordField.UseSystemPasswordChar = true;
            // 
            // RoleField
            // 
            this.RoleField.DropDownStyle = ComboBoxStyle.DropDownList;
            this.RoleField.Items.AddRange(new object[] { "Admin", "User", "Manager" });
            this.RoleField.Location = new Point(101, 83);
            this.RoleField.Margin = new Padding(4);
            this.RoleField.Name = "RoleField";
            this.RoleField.Size = new Size(321, 27);
            this.RoleField.TabIndex = 6;
            // 
            // ActivatedField
            // 
            this.ActivatedField.AutoSize = true;
            this.ActivatedField.Location = new Point(101, 118);
            this.ActivatedField.Margin = new Padding(4);
            this.ActivatedField.Name = "ActivatedField";
            this.ActivatedField.Size = new Size(96, 23);
            this.ActivatedField.TabIndex = 7;
            this.ActivatedField.Text = "Activated";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new Point(220, 149);
            this.SaveButton.Margin = new Padding(4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new Size(97, 29);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += this.SaveButton_Click;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new Point(325, 149);
            this.CancelButton.Margin = new Padding(4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new Size(97, 29);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += this.CancelButton_Click;
            // 
            // UserDetailForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(438, 194);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ActivatedField);
            this.Controls.Add(this.RoleField);
            this.Controls.Add(this.PasswordField);
            this.Controls.Add(this.UsernameField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Margin = new Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserDetailForm";
            this.Text = "UserDetailForm";
            this.Load += this.UserDetailForm_Load;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox UsernameField;
        private TextBox PasswordField;
        private ComboBox RoleField;
        private CheckBox ActivatedField;
        private Button SaveButton;
        private Button CancelButton;
    }
}
