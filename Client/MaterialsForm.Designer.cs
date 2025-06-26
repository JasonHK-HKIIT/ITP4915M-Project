namespace Client
{
    partial class MaterialsForm
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
            SearchField = new TextBox();
            NewButton = new Button();
            EditButton = new Button();
            MaterialsView = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)MaterialsView).BeginInit();
            SuspendLayout();
            // 
            // SearchField
            // 
            SearchField.Location = new Point(11, 10);
            SearchField.Margin = new Padding(2, 2, 2, 2);
            SearchField.Name = "SearchField";
            SearchField.Size = new Size(191, 23);
            SearchField.TabIndex = 0;
            SearchField.KeyDown += SearchField_KeyDown;
            // 
            // NewButton
            // 
            NewButton.Location = new Point(648, 9);
            NewButton.Margin = new Padding(2, 2, 2, 2);
            NewButton.Name = "NewButton";
            NewButton.Size = new Size(73, 23);
            NewButton.TabIndex = 1;
            NewButton.Text = "New";
            NewButton.UseVisualStyleBackColor = true;
            NewButton.Click += NewButton_Click;
            // 
            // EditButton
            // 
            EditButton.Location = new Point(726, 9);
            EditButton.Margin = new Padding(2, 2, 2, 2);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(73, 23);
            EditButton.TabIndex = 2;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // MaterialsView
            // 
            MaterialsView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MaterialsView.Location = new Point(9, 37);
            MaterialsView.Margin = new Padding(2, 2, 2, 2);
            MaterialsView.MultiSelect = false;
            MaterialsView.Name = "MaterialsView";
            MaterialsView.ReadOnly = true;
            MaterialsView.RowHeadersWidth = 51;
            MaterialsView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            MaterialsView.Size = new Size(789, 422);
            MaterialsView.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(218, 13);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(217, 15);
            label1.TabIndex = 4;
            label1.Text = "Search by (MaterialID) / (MaterialName)";
            // 
            // MaterialsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 468);
            Controls.Add(label1);
            Controls.Add(MaterialsView);
            Controls.Add(EditButton);
            Controls.Add(NewButton);
            Controls.Add(SearchField);
            Margin = new Padding(2, 2, 2, 2);
            Name = "MaterialsForm";
            Text = "MaterialsForm";
            Load += MaterialsForm_Load;
            ((System.ComponentModel.ISupportInitialize)MaterialsView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SearchField;
        private Button NewButton;
        private Button EditButton;
        private DataGridView MaterialsView;
        private Label label1;
    }
}