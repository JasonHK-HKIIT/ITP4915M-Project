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
            label1 = new Label();
            textBox1 = new TextBox();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonViewLines = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 29);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(369, 23);
            label1.TabIndex = 0;
            label1.Text = "Filter purchase order by any column value:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(18, 74);
            textBox1.Margin = new Padding(5, 5, 5, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(279, 30);
            textBox1.TabIndex = 1;
            textBox1.KeyUp += textBox1_KeyUp;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(430, 73);
            buttonAdd.Margin = new Padding(5, 5, 5, 5);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(191, 35);
            buttonAdd.TabIndex = 2;
            buttonAdd.Text = "Add Purchase Order";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += ButtonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(664, 73);
            buttonEdit.Margin = new Padding(5, 5, 5, 5);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(191, 35);
            buttonEdit.TabIndex = 3;
            buttonEdit.Text = "Edit Selected";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += ButtonEdit_Click;
            // 
            // buttonViewLines
            // 
            buttonViewLines.Location = new Point(897, 73);
            buttonViewLines.Margin = new Padding(5, 5, 5, 5);
            buttonViewLines.Name = "buttonViewLines";
            buttonViewLines.Size = new Size(191, 35);
            buttonViewLines.TabIndex = 4;
            buttonViewLines.Text = "View PO Lines";
            buttonViewLines.UseVisualStyleBackColor = true;
            buttonViewLines.Click += ButtonViewPOLines_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(11, 145);
            dataGridView1.Margin = new Padding(5, 5, 5, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1914, 655);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // PurchaseOrderForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 818);
            Controls.Add(buttonViewLines);
            Controls.Add(buttonEdit);
            Controls.Add(buttonAdd);
            Controls.Add(dataGridView1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Margin = new Padding(5, 5, 5, 5);
            Name = "PurchaseOrderForm";
            Text = "PurchaseOrderForm";
            Load += PurchaseOrderForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
