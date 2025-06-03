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
    public partial class UserDetailForm : Form
    {
        public UserDetailForm()
        {
            InitializeComponent();
            button1.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
            button2.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        public void SetFields(string username, string password, string role, bool active)
        {
            textBox1.Text = username;
            textBox2.Text = password;
            comboBox1.Text = role;
            checkBox1.Checked = active;
        }

        public string Username => textBox1.Text;
        public string Password => textBox2.Text;
        public string Role => comboBox1.Text;
        public bool Active => checkBox1.Checked;
    }

}
