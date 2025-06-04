using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Client
{
    public partial class PurchaseOrderDetailForm : Form
    {
        public PurchaseOrderDetailForm()
        {
            InitializeComponent();
            buttonSave.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };    // Save
            buttonCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); }; // Cancel
            buttonAddLine.Click += ButtonAddLine_Click;    // Add Line
            buttonDeleteLine.Click += ButtonDeleteLine_Click; // Delete Line
        }

        // Pre-fill form fields for Edit
        public void SetFields(
            string poId, string supplierId, DateTime orderDate, DateTime deliveryDate,
            string status, string poStatus
        // Optionally, add a parameter for line items
        )
        {
            textBoxPOID.Text = poId;
            comboBoxSupplier.Text = supplierId;
            dateTimePickerOrder.Value = orderDate;
            dateTimePickerDelivery.Value = deliveryDate;
            comboBoxStatus.Text = status;
            comboBoxPOStatus.Text = poStatus;

            // TODO: Set line items in dataGridViewLineItems, if passed
        }

        // Expose properties to read form data
        public string PurchaseOrderID => textBoxPOID.Text;
        public string SupplierID => comboBoxSupplier.Text;
        public DateTime OrderDate => dateTimePickerOrder.Value;
        public DateTime DeliveryDate => dateTimePickerDelivery.Value;
        public string Status => comboBoxStatus.Text;
        public string POStatus => comboBoxPOStatus.Text;

        // Example stub for line items (extend as needed)
        public DataGridView LineItemsGrid => dataGridViewLineItems;

        // You could add a method to get line items as a list, if needed
        // public List<PurchaseOrderLine> GetLineItems() { ... }

        private void ButtonAddLine_Click(object sender, EventArgs e)
        {
            // TODO: Add a new line item (show dialog, or add empty row)
        }

        private void ButtonDeleteLine_Click(object sender, EventArgs e)
        {
            if (dataGridViewLineItems.SelectedRows.Count > 0)
                dataGridViewLineItems.Rows.RemoveAt(dataGridViewLineItems.SelectedRows[0].Index);
        }

        private void PurchaseOrderDetailForm_Load(object sender, EventArgs e)
        {
            // TODO: Load suppliers, status lists, etc. into ComboBoxes if needed
        }
    }
}
