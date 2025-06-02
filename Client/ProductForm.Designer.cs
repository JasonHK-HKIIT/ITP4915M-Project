namespace Client
{
    partial class ProductForm
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
            this.dataGridView1 = new DataGridView();
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.button3 = new Button();
            this.button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(9, 120);
            this.dataGridView1.Margin = new Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new Size(1566, 541);
            this.dataGridView1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(15, 27);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(193, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Input product ID to search:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Point(15, 70);
            this.textBox1.Margin = new Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(229, 27);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += this.textBox1_TextChanged;
            this.textBox1.KeyUp += this.textBox1_KeyUp;
            // 
            // button3
            // 
            this.button3.Location = new Point(345, 70);
            this.button3.Margin = new Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new Size(156, 29);
            this.button3.TabIndex = 10;
            this.button3.Text = "Add Product";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += this.button3_Click;
            // 
            // button2
            // 
            this.button2.Location = new Point(535, 70);
            this.button2.Margin = new Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new Size(156, 29);
            this.button2.TabIndex = 11;
            this.button2.Text = "Edit Selected";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1585, 676);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ProductForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ProductForm";
            this.Load += this.ProductForm_Load;
            ((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Label label1;
        private TextBox textBox1;
        private Button button3;
        private Button button2;
    }
}