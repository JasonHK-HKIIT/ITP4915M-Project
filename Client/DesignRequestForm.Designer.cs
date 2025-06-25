namespace Client
{
    partial class DesignRequestForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox SearchField;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button BtnCancelSelected;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SearchField = new TextBox();
            dataGridView1 = new DataGridView();
            AddButton = new Button();
            EditButton = new Button();
            BtnCancelSelected = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // SearchField
            // 
            SearchField.Location = new Point(13, 68);
            SearchField.Margin = new Padding(4);
            SearchField.Name = "SearchField";
            SearchField.Size = new Size(411, 30);
            SearchField.TabIndex = 0;
            SearchField.KeyUp += SearchField_KeyUp;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(13, 159);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1168, 475);
            dataGridView1.TabIndex = 1;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(518, 65);
            AddButton.Margin = new Padding(4);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(162, 34);
            AddButton.TabIndex = 2;
            AddButton.Text = "Add Request";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // EditButton
            // 
            EditButton.Location = new Point(716, 64);
            EditButton.Margin = new Padding(4);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(165, 34);
            EditButton.TabIndex = 3;
            EditButton.Text = "Edit Selected";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // BtnCancelSelected
            // 
            BtnCancelSelected.Location = new Point(925, 64);
            BtnCancelSelected.Margin = new Padding(4);
            BtnCancelSelected.Name = "BtnCancelSelected";
            BtnCancelSelected.Size = new Size(183, 34);
            BtnCancelSelected.TabIndex = 4;
            BtnCancelSelected.Text = "Cancel Selected";
            BtnCancelSelected.UseVisualStyleBackColor = true;
            BtnCancelSelected.Click += BtnCancelSelected_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 22);
            label1.Name = "label1";
            label1.Size = new Size(476, 23);
            label1.TabIndex = 5;
            label1.Text = "Input (DesignRequestID) / (Customer Name) to search:";
            // 
            // DesignRequestForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 647);
            Controls.Add(label1);
            Controls.Add(BtnCancelSelected);
            Controls.Add(EditButton);
            Controls.Add(AddButton);
            Controls.Add(dataGridView1);
            Controls.Add(SearchField);
            Margin = new Padding(4);
            Name = "DesignRequestForm";
            Text = "Design Request Management";
            Load += DesignRequestForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label label1;
    }
}
