namespace Client
{
    partial class PurchaseOrderForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private TextBox textBox1;
        private Button buttonAdd;
        private Button buttonEdit;
        private Button buttonViewLines;
        private DataGridView dataGridView1;

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
            this.buttonAdd = new Button();
            this.buttonEdit = new Button();
            this.buttonViewLines = new Button();
            this.dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(15, 24);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(304, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter purchase order by any column value:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Point(15, 61);
            this.textBox1.Margin = new Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(229, 27);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyUp += this.textBox1_KeyUp;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new Point(352, 60);
            this.buttonAdd.Margin = new Padding(4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new Size(156, 29);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add Purchase Order";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += this.ButtonAdd_Click;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new Point(543, 60);
            this.buttonEdit.Margin = new Padding(4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new Size(156, 29);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Edit Selected";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += this.ButtonEdit_Click;
            // 
            // buttonViewLines
            // 
            this.buttonViewLines.Location = new Point(734, 60);
            this.buttonViewLines.Margin = new Padding(4);
            this.buttonViewLines.Name = "buttonViewLines";
            this.buttonViewLines.Size = new Size(156, 29);
            this.buttonViewLines.TabIndex = 4;
            this.buttonViewLines.Text = "View PO Lines";
            this.buttonViewLines.UseVisualStyleBackColor = true;
            this.buttonViewLines.Click += this.ButtonViewPOLines_Click;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(9, 120);
            this.dataGridView1.Margin = new Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(1566, 541);
            this.dataGridView1.TabIndex = 5;
            // 
            // PurchaseOrderForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1574, 676);
            this.Controls.Add(this.buttonViewLines);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Margin = new Padding(4);
            this.Name = "PurchaseOrderForm";
            this.Text = "PurchaseOrderForm";
            this.Load += this.PurchaseOrderForm_Load;
            ((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
