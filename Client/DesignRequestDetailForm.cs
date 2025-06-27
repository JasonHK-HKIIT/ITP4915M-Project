using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class DesignRequestDetailForm : Form
    {
        private readonly bool IsEditMode = false;
        private readonly string RequestId;

        public DesignRequestDetailForm()
        {
            InitializeComponent();

            this.Text = "Design Request Detail Form";
        }

        public DesignRequestDetailForm(string requestId) : this()
        {
            IsEditMode = true;
            this.RequestId = requestId;
        }

        private void DesignRequestDetailForm_Load(object sender, EventArgs e)
        {
            // Load Customers
            var customersCommand = new MySqlCommand("SELECT CustomerID, CustomerName FROM Customer", Program.Connection);
            var customersAdapter = new MySqlDataAdapter(customersCommand);
            var customersTable = new DataTable();
            customersAdapter.Fill(customersTable);
            CustomerField.DisplayMember = "CustomerName";
            CustomerField.ValueMember = "CustomerID";
            CustomerField.DataSource = customersTable;

            // Load Assigned Managers (UserID where Role = 'Manager')
            var managerCommand = new MySqlCommand("SELECT UserID, Name FROM User WHERE Role = 'Manager'", Program.Connection);
            var managerAdapter = new MySqlDataAdapter(managerCommand);
            var managerTable = new DataTable();
            managerAdapter.Fill(managerTable);
            AssignedManagerField.DisplayMember = "Name";
            AssignedManagerField.ValueMember = "UserID";
            AssignedManagerField.DataSource = managerTable;

            // Load ApprovedBy Dropdown (optional)
            var approverCommand = new MySqlCommand("SELECT UserID, Name FROM User", Program.Connection);
            var approverAdapter = new MySqlDataAdapter(approverCommand);
            var approverTable = new DataTable();
            approverAdapter.Fill(approverTable);
            ApprovedByField.DisplayMember = "Name";
            ApprovedByField.ValueMember = "UserID";
            ApprovedByField.DataSource = approverTable;

            // Load Status options
            StatusField.Items.AddRange(new[] { "Pending", "Approved", "Rejected" });

            // Edit Mode
            if (IsEditMode)
            {
                var command = new MySqlCommand("SELECT * FROM ProductDesignRequest WHERE DesignRequestID = @id", Program.Connection);
                command.Parameters.AddWithValue("@id", RequestId);
                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    RequestIdField.Text = reader["DesignRequestID"].ToString();
                    CustomerField.SelectedValue = reader["CustomerID"].ToString();
                    RequestDateField.Value = reader.GetDateTime("RequestDate");
                    SpecificationsField.Text = reader["Specifications"].ToString();
                    ConsultantFeeField.Text = reader["ConsultantFee"]?.ToString() ?? "";
                    StatusField.SelectedItem = reader["Status"].ToString();
                    ApprovalDateField.Value = reader["ApprovalDate"] == DBNull.Value ? DateTime.Today : Convert.ToDateTime(reader["ApprovalDate"]);
                    AssignedManagerField.SelectedValue = reader["UserID"].ToString();
                    ApprovedByField.SelectedValue = reader["ApprovedBy"]?.ToString() ?? "";
                }
            }
            else
            {
                RequestDateField.Value = DateTime.Today;
                ApprovalDateField.Value = DateTime.Today;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsEditMode)
                {
                    var update = new MySqlCommand(@"
                        UPDATE ProductDesignRequest SET
                            CustomerID = @CustomerID,
                            RequestDate = @RequestDate,
                            Specifications = @Specifications,
                            ConsultantFee = @ConsultantFee,
                            Status = @Status,
                            ApprovalDate = @ApprovalDate,
                            UserID = @UserID,
                            ApprovedBy = @ApprovedBy
                        WHERE DesignRequestID = @DesignRequestID", Program.Connection);

                    update.Parameters.AddWithValue("@DesignRequestID", RequestId);
                    update.Parameters.AddWithValue("@CustomerID", CustomerField.SelectedValue);
                    update.Parameters.AddWithValue("@RequestDate", RequestDateField.Value.Date);
                    update.Parameters.AddWithValue("@Specifications", SpecificationsField.Text);
                    update.Parameters.AddWithValue("@ConsultantFee", string.IsNullOrWhiteSpace(ConsultantFeeField.Text) ? DBNull.Value : (object)decimal.Parse(ConsultantFeeField.Text));
                    update.Parameters.AddWithValue("@Status", StatusField.Text);
                    update.Parameters.AddWithValue("@ApprovalDate", ApprovalDateField.Value.Date);
                    update.Parameters.AddWithValue("@UserID", AssignedManagerField.SelectedValue);
                    update.Parameters.AddWithValue("@ApprovedBy", ApprovedByField.SelectedValue);
                    update.ExecuteNonQuery();
                }
                else
                {
                    var lastIdCommand = new MySqlCommand("SELECT DesignRequestID FROM ProductDesignRequest ORDER BY DesignRequestID DESC LIMIT 1", Program.Connection);
                    var lastIdString = lastIdCommand.ExecuteScalar() as string ?? "DR000";
                    var nextId = int.Parse(lastIdString.Substring(2)) + 1;

                    var insert = new MySqlCommand(@"
                        INSERT INTO ProductDesignRequest
                            (DesignRequestID, CustomerID, RequestDate, Specifications, ConsultantFee, Status, ApprovalDate, UserID, ApprovedBy)
                        VALUES
                            (@DesignRequestID, @CustomerID, @RequestDate, @Specifications, @ConsultantFee, @Status, @ApprovalDate, @UserID, @ApprovedBy)", Program.Connection);

                    insert.Parameters.AddWithValue("@DesignRequestID", $"DR{nextId.ToString().PadLeft(3, '0')}");
                    insert.Parameters.AddWithValue("@CustomerID", CustomerField.SelectedValue);
                    insert.Parameters.AddWithValue("@RequestDate", RequestDateField.Value.Date);
                    insert.Parameters.AddWithValue("@Specifications", SpecificationsField.Text);
                    insert.Parameters.AddWithValue("@ConsultantFee", string.IsNullOrWhiteSpace(ConsultantFeeField.Text) ? DBNull.Value : (object)decimal.Parse(ConsultantFeeField.Text));
                    insert.Parameters.AddWithValue("@Status", StatusField.Text);
                    insert.Parameters.AddWithValue("@ApprovalDate", ApprovalDateField.Value.Date);
                    insert.Parameters.AddWithValue("@UserID", AssignedManagerField.SelectedValue);
                    insert.Parameters.AddWithValue("@ApprovedBy", ApprovedByField.SelectedValue);
                    insert.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving design request:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void RequestIdField_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
