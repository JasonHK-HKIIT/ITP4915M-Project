namespace Client
{
    partial class ServiceCaseForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button3;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.button1 = new Button();
            this.dataGridView1 = new DataGridView();
            this.button2 = new Button();
            this.button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new Point(15, 24);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(401, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input (Case ID) / (Customer Name) / (Order ID) to search:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Point(15, 61);
            this.textBox1.Margin = new Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(229, 27);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new Point(410, 60);
            this.button1.Margin = new Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new Size(156, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add Case";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(9, 120);
            this.dataGridView1.Margin = new Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(1549, 541);
            this.dataGridView1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new Point(588, 61);
            this.button2.Margin = new Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new Size(156, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "Edit Selected";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new Point(764, 61);
            this.button3.Margin = new Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new Size(156, 29);
            this.button3.TabIndex = 5;
            this.button3.Text = "Delete Selected";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // ServiceCaseForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1566, 676);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Margin = new Padding(4, 4, 4, 4);
            this.Name = "ServiceCaseForm";
            this.Text = "ServiceCaseForm";
            this.Load += this.ServiceCaseForm_Load;
            ((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
