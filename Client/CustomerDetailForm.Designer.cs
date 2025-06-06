namespace Client
{
    partial class CustomerDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.textBox2 = new TextBox();
            this.textBox3 = new TextBox();
            this.textBox4 = new TextBox();
            this.button1 = new Button();
            this.button2 = new Button();
            this.maskedTextBox1 = new MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(31, 33);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(92, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "CustomerID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(70, 81);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(51, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(68, 121);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(53, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Phone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(58, 164);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(67, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Address";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Point(166, 71);
            this.textBox2.Margin = new Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(321, 27);
            this.textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Location = new Point(166, 112);
            this.textBox3.Margin = new Padding(4, 4, 4, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Size(321, 27);
            this.textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            this.textBox4.Location = new Point(166, 154);
            this.textBox4.Margin = new Padding(4, 4, 4, 4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Size(661, 27);
            this.textBox4.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new Point(614, 207);
            this.button1.Margin = new Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new Size(97, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new Point(731, 207);
            this.button2.Margin = new Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new Size(97, 29);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new Point(166, 23);
            this.maskedTextBox1.Margin = new Padding(4, 4, 4, 4);
            this.maskedTextBox1.Mask = "CUST000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new Size(321, 27);
            this.maskedTextBox1.TabIndex = 10;
            this.maskedTextBox1.Text = "C";
            // 
            // CustomerDetailForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(864, 264);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new Padding(4, 4, 4, 4);
            this.Name = "CustomerDetailForm";
            this.Text = "CustomerDetailForm";
            this.Load += this.CustomerDetailForm_Load;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private Button button2;
        private MaskedTextBox maskedTextBox1;
    }
}