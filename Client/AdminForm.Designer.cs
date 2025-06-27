namespace Client
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private TextBox SearchField;
        private Button NewButton;
        private DataGridView dataGridView1;
        private Button EditButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            SearchField = new TextBox();
            NewButton = new Button();
            dataGridView1 = new DataGridView();
            EditButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(307, 15);
            label1.TabIndex = 0;
            label1.Text = "Input (UserID) / (Name) / (TeamName) / (Role) to search:";
            // 
            // SearchField
            // 
            SearchField.Location = new Point(12, 48);
            SearchField.Name = "SearchField";
            SearchField.Size = new Size(179, 23);
            SearchField.TabIndex = 1;
            SearchField.KeyUp += SearchField_KeyUp;
            // 
            // NewButton
            // 
            NewButton.Location = new Point(275, 47);
            NewButton.Name = "NewButton";
            NewButton.Size = new Size(121, 23);
            NewButton.TabIndex = 2;
            NewButton.Text = "Add User";
            NewButton.UseVisualStyleBackColor = true;
            NewButton.Click += NewButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(7, 96);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1218, 427);
            dataGridView1.TabIndex = 3;
            // 
            // EditButton
            // 
            EditButton.Location = new Point(422, 47);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(121, 23);
            EditButton.TabIndex = 4;
            EditButton.Text = "Edit Selected";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 534);
            Controls.Add(EditButton);
            Controls.Add(dataGridView1);
            Controls.Add(NewButton);
            Controls.Add(SearchField);
            Controls.Add(label1);
            Name = "AdminForm";
            Text = "AdminForm";
            Load += AdminForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
