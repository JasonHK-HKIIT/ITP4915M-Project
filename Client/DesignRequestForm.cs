using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    public partial class DesignRequestForm : Form
    {
        // Simple data model
        public class DesignRequest
        {
            public string Customer { get; set; }
            public string AssignedManager { get; set; }
            public string Specifications { get; set; }
        }

        private List<DesignRequest> requests = new List<DesignRequest>();

        public DesignRequestForm()
        {
            InitializeComponent();
            button3.Click += ButtonAdd_Click;   // "Add Request"
            button1.Click += ButtonEdit_Click;  // "Edit Selected"
            // button2 (Approve) can be wired similarly if you need approval logic

            BindDataGrid();
        }

        private void BindDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = requests.ToList();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new DesignRequestDetailForm())
            {
                detail.Text = "Add Design Request";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    requests.Add(new DesignRequest
                    {
                        Customer = detail.Customer,
                        AssignedManager = detail.AssignedManager,
                        Specifications = detail.Specifications
                    });
                    BindDataGrid();
                }
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a design request to edit.");
                return;
            }
            int idx = dataGridView1.SelectedRows[0].Index;
            var dr = requests[idx];
            using (var detail = new DesignRequestDetailForm())
            {
                detail.Text = "Edit Design Request";
                detail.SetFields(dr.Customer, dr.AssignedManager, dr.Specifications);
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    dr.Customer = detail.Customer;
                    dr.AssignedManager = detail.AssignedManager;
                    dr.Specifications = detail.Specifications;
                    BindDataGrid();
                }
            }
        }
    }
}
