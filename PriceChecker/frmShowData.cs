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
    public partial class frmShowData : Form
    {
        string _content;
        public frmShowData(string content)
        {
            InitializeComponent();
            _content = content;
        }

        private void frmShowData_Load(object sender, EventArgs e)
        {
            txtContent.Text = _content;
        }
    }
}
