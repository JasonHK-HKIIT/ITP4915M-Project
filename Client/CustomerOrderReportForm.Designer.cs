namespace Client
{
    partial class CustomerOrderReportForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.DataGridView dgvResults;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblDateFrom = new Label();
            dtpFrom = new DateTimePicker();
            lblDateTo = new Label();
            dtpTo = new DateTimePicker();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnEnter = new Button();
            btnBack = new Button();
            pnlSummary = new Panel();
            dgvResults = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Azure;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.IndianRed;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(749, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Customer Order Report";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDateFrom
            // 
            lblDateFrom.Location = new Point(30, 80);
            lblDateFrom.Name = "lblDateFrom";
            lblDateFrom.Size = new Size(90, 23);
            lblDateFrom.TabIndex = 1;
            lblDateFrom.Text = "Date From:";
            // 
            // dtpFrom
            // 
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(120, 80);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(150, 23);
            dtpFrom.TabIndex = 2;
            // 
            // lblDateTo
            // 
            lblDateTo.Location = new Point(290, 80);
            lblDateTo.Name = "lblDateTo";
            lblDateTo.Size = new Size(70, 23);
            lblDateTo.TabIndex = 3;
            lblDateTo.Text = "Date To:";
            // 
            // dtpTo
            // 
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(360, 80);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(150, 23);
            dtpTo.TabIndex = 4;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(530, 80);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(60, 23);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Location = new Point(590, 80);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(120, 23);
            cmbStatus.TabIndex = 6;
            // 
            // btnEnter
            // 
            btnEnter.BackColor = Color.LightSteelBlue;
            btnEnter.Location = new Point(510, 120);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new Size(90, 30);
            btnEnter.TabIndex = 7;
            btnEnter.Text = "Enter";
            btnEnter.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.LightSteelBlue;
            btnBack.Location = new Point(620, 120);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(90, 30);
            btnBack.TabIndex = 8;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // pnlSummary
            // 
            pnlSummary.BackColor = Color.Azure;
            pnlSummary.BorderStyle = BorderStyle.FixedSingle;
            pnlSummary.Location = new Point(30, 170);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(680, 50);
            pnlSummary.TabIndex = 9;
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.BackgroundColor = Color.White;
            dgvResults.Location = new Point(30, 230);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.Size = new Size(680, 230);
            dgvResults.TabIndex = 10;
            // 
            // CustomerOrderReportForm
            // 
            ClientSize = new Size(750, 500);
            Controls.Add(lblTitle);
            Controls.Add(lblDateFrom);
            Controls.Add(dtpFrom);
            Controls.Add(lblDateTo);
            Controls.Add(dtpTo);
            Controls.Add(lblStatus);
            Controls.Add(cmbStatus);
            Controls.Add(btnEnter);
            Controls.Add(btnBack);
            Controls.Add(pnlSummary);
            Controls.Add(dgvResults);
            Name = "CustomerOrderReportForm";
            Text = "Customer Order Report";
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
        }
    }
}
