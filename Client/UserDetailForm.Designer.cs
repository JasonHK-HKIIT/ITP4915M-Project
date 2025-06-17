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
            this.PasswordField = new TextBox();
            this.RoleField = new ComboBox();
            this.ActivatedField = new CheckBox();
            this.SaveButton = new Button();
            this.CancelButton = new Button();
            this.PositionField = new TextBox();
            this.label5 = new Label();
            this.TeamField = new ComboBox();
            this.label6 = new Label();
            this.NameField = new TextBox();
            this.label7 = new Label();
            this.ManagerField = new ComboBox();
            this.label8 = new Label();
            this.UserIdField = new TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(34, 16);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(60, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(17, 83);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(77, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(53, 184);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(40, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Role";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(19, 251);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(74, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Activated";
            // 
            // PasswordField
            // 
            this.PasswordField.Location = new Point(101, 80);
            this.PasswordField.Margin = new Padding(4);
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.Size = new Size(321, 27);
            this.PasswordField.TabIndex = 5;
            this.PasswordField.UseSystemPasswordChar = true;
            // 
            // RoleField
            // 
            this.RoleField.DropDownStyle = ComboBoxStyle.DropDownList;
            this.RoleField.Items.AddRange(new object[] { "User", "Manager", "Admin" });
            this.RoleField.Location = new Point(101, 181);
            this.RoleField.Margin = new Padding(4);
            this.RoleField.Name = "RoleField";
            this.RoleField.Size = new Size(321, 27);
            this.RoleField.TabIndex = 6;
            // 
            // ActivatedField
            // 
            this.ActivatedField.AutoSize = true;
            this.ActivatedField.Checked = true;
            this.ActivatedField.CheckState = CheckState.Checked;
            this.ActivatedField.Location = new Point(101, 250);
            this.ActivatedField.Margin = new Padding(4);
            this.ActivatedField.Name = "ActivatedField";
            this.ActivatedField.Size = new Size(96, 23);
            this.ActivatedField.TabIndex = 7;
            this.ActivatedField.Text = "Activated";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new Point(220, 281);
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
            this.CancelButton.Location = new Point(325, 281);
            this.CancelButton.Margin = new Padding(4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new Size(97, 29);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += this.CancelButton_Click;
            // 
            // PositionField
            // 
            this.PositionField.Location = new Point(101, 147);
            this.PositionField.Name = "PositionField";
            this.PositionField.Size = new Size(321, 27);
            this.PositionField.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new Point(29, 150);
            this.label5.Name = "label5";
            this.label5.Size = new Size(65, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "Position";
            // 
            // TeamField
            // 
            this.TeamField.DropDownStyle = ComboBoxStyle.DropDownList;
            this.TeamField.FormattingEnabled = true;
            this.TeamField.Location = new Point(101, 114);
            this.TeamField.Name = "TeamField";
            this.TeamField.Size = new Size(321, 27);
            this.TeamField.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new Point(46, 117);
            this.label6.Name = "label6";
            this.label6.Size = new Size(47, 19);
            this.label6.TabIndex = 14;
            this.label6.Text = "Team";
            // 
            // NameField
            // 
            this.NameField.Location = new Point(101, 46);
            this.NameField.Name = "NameField";
            this.NameField.Size = new Size(321, 27);
            this.NameField.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new Point(44, 49);
            this.label7.Name = "label7";
            this.label7.Size = new Size(51, 19);
            this.label7.TabIndex = 16;
            this.label7.Text = "Name";
            // 
            // ManagerField
            // 
            this.ManagerField.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ManagerField.FormattingEnabled = true;
            this.ManagerField.Location = new Point(101, 215);
            this.ManagerField.Name = "ManagerField";
            this.ManagerField.Size = new Size(321, 27);
            this.ManagerField.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new Point(21, 218);
            this.label8.Name = "label8";
            this.label8.Size = new Size(72, 19);
            this.label8.TabIndex = 18;
            this.label8.Text = "Manager";
            // 
            // UserIdField
            // 
            this.UserIdField.Location = new Point(101, 13);
            this.UserIdField.Name = "UserIdField";
            this.UserIdField.ReadOnly = true;
            this.UserIdField.Size = new Size(321, 27);
            this.UserIdField.TabIndex = 19;
            // 
            // UserDetailForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(438, 327);
            this.Controls.Add(this.UserIdField);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ManagerField);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.NameField);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TeamField);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PositionField);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ActivatedField);
            this.Controls.Add(this.RoleField);
            this.Controls.Add(this.PasswordField);
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
        private TextBox PasswordField;
        private ComboBox RoleField;
        private CheckBox ActivatedField;
        private Button SaveButton;
        private Button CancelButton;
        private TextBox PositionField;
        private Label label5;
        private ComboBox TeamField;
        private Label label6;
        private TextBox NameField;
        private Label label7;
        private ComboBox ManagerField;
        private Label label8;
        private TextBox UserIdField;
    }
}
