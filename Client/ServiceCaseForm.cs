using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ServiceCaseForm : Form
    {
        public class ServiceCase
        {
            public string CaseID { get; set; }
            public string Customer { get; set; }
            public string Order { get; set; }
            public string CaseType { get; set; }
            public string Status { get; set; }
            public string AssignedTo { get; set; }
        }

        private List<ServiceCase> cases = new List<ServiceCase>();

        public ServiceCaseForm()
        {
            InitializeComponent();
            button1.Click += ButtonAdd_Click;
            button2.Click += ButtonEdit_Click;
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cases.ToList();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var detail = new ServiceCaseDetailForm())
            {
                detail.Text = "Add Service Case";
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    cases.Add(new ServiceCase
                    {
                        CaseID = detail.CaseID,
                        Customer = detail.Customer,
                        Order = detail.Order,
                        CaseType = detail.CaseType,
                        Status = detail.Status,
                        AssignedTo = detail.AssignedTo
                    });
                    BindDataGrid();
                }
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            int idx = dataGridView1.SelectedRows[0].Index;
            var sc = cases[idx];
            using (var detail = new ServiceCaseDetailForm())
            {
                detail.Text = "Edit Service Case";
                detail.SetFields(sc.CaseID, sc.Customer, sc.Order, sc.CaseType, sc.Status, sc.AssignedTo);
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    sc.CaseID = detail.CaseID;
                    sc.Customer = detail.Customer;
                    sc.Order = detail.Order;
                    sc.CaseType = detail.CaseType;
                    sc.Status = detail.Status;
                    sc.AssignedTo = detail.AssignedTo;
                    BindDataGrid();
                }
            }
        }
    }

}
