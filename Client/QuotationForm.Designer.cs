namespace Client
{
    partial class QuotationForm
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
            NewButton = new Button();
            EditButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(7, 96);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1218, 427);
            dataGridView1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(270, 15);
            label1.TabIndex = 7;
            label1.Text = "Input (Quotation ID) / Customer Name) to search:";
            // 
            // SearchField
            // 
            SearchField.Location = new Point(12, 51);
            SearchField.Name = "SearchField";
            SearchField.Size = new Size(179, 23);
            SearchField.TabIndex = 8;
            SearchField.KeyUp += SearchField_KeyUp;
            // 
            // NewButton
            // 
            NewButton.Location = new Point(425, 51);
            NewButton.Name = "NewButton";
            NewButton.Size = new Size(121, 23);
            NewButton.TabIndex = 11;
            NewButton.Text = "Add Quotation";
            NewButton.UseVisualStyleBackColor = true;
            NewButton.Click += NewButton_Click;
            // 
            // EditButton
            // 
            EditButton.Location = new Point(562, 51);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(121, 23);
            EditButton.TabIndex = 12;
            EditButton.Text = "Edit Selected";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // QuotationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1229, 534);
            Controls.Add(EditButton);
            Controls.Add(NewButton);
            Controls.Add(SearchField);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "QuotationForm";
            Text = "QuotationForm";
            Load += QuotationForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private TextBox SearchField;
        private Button NewButton;
        private Button EditButton;
    }
}