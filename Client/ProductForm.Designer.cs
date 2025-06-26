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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            SearchField = new TextBox();
            AddButton = new Button();
            EditButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(7, 95);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1218, 427);
            dataGridView1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(463, 15);
            label1.TabIndex = 6;
            label1.Text = "Input (ProductID) / (ProductName) /(ProductType) / (ProductSpecifications) to search:";
            // 
            // SearchField
            // 
            SearchField.Location = new Point(12, 55);
            SearchField.Name = "SearchField";
            SearchField.Size = new Size(179, 23);
            SearchField.TabIndex = 7;
            SearchField.KeyUp += SearchField_KeyUp;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(268, 55);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(121, 23);
            AddButton.TabIndex = 10;
            AddButton.Text = "Add Product";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // EditButton
            // 
            EditButton.Location = new Point(416, 55);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(121, 23);
            EditButton.TabIndex = 11;
            EditButton.Text = "Edit Selected";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1233, 534);
            Controls.Add(EditButton);
            Controls.Add(AddButton);
            Controls.Add(SearchField);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "ProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProductForm";
            Load += ProductForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Label label1;
        private TextBox SearchField;
        private Button AddButton;
        private Button EditButton;
    }
}