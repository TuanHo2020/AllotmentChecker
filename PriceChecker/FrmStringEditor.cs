using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceChecker
{
    public partial class FrmStringEditor : Form
    {
        string _message;
        public string StringValue { get; set; }
        public FrmStringEditor(string message, object initValue)
        {
            _message = message;
            InitializeComponent();
        }

        private void FrmStringEditor_Load(object sender, EventArgs e)
        {
            this.Text = _message;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            StringValue = txtValue.Text;
        }
    }
}
