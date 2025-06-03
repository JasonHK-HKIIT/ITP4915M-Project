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
            this.SearchField = new TextBox();
            this.AddButton = new Button();
            this.EditButton = new Button();
            ((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(9, 120);
            this.dataGridView1.Margin = new Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            // SearchField
            // 
            this.SearchField.Location = new Point(15, 70);
            this.SearchField.Margin = new Padding(4);
            this.SearchField.Name = "SearchField";
            this.SearchField.Size = new Size(229, 27);
            this.SearchField.TabIndex = 7;
            this.SearchField.KeyUp += this.SearchField_KeyUp;
            // 
            // AddButton
            // 
            this.AddButton.Location = new Point(345, 70);
            this.AddButton.Margin = new Padding(4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new Size(156, 29);
            this.AddButton.TabIndex = 10;
            this.AddButton.Text = "Add Product";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += this.AddButton_Click;
            // 
            // EditButton
            // 
            this.EditButton.Location = new Point(535, 70);
            this.EditButton.Margin = new Padding(4);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new Size(156, 29);
            this.EditButton.TabIndex = 11;
            this.EditButton.Text = "Edit Selected";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += this.EditButton_Click;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1585, 676);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.SearchField);
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
        private TextBox SearchField;
        private Button AddButton;
        private Button EditButton;
    }
}