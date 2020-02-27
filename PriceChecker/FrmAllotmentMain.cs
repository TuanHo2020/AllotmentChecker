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
    public partial class FrmAllotmentMain : Form
    {
        public FrmAllotmentMain()
        {
            InitializeComponent();
        }

        private void btnAllotmentChecker_Click(object sender, EventArgs e)
        {
            var checker = new frmAllotmentCheckerMain();
            checker.ShowDialog();
        }

        private void btnAllotmentReport_Click(object sender, EventArgs e)
        {
            var reporter = new FrmCloseDateReport();
            reporter.Show();
        }


        private void btnAllotmentHotels_Click(object sender, EventArgs e)
        {
            var viewer = new frmAllotmentHotels();
            viewer.ShowDialog();
        }

        private void btnAllConfigs_Click(object sender, EventArgs e)
        {
            var viewer = new FrmAllConfigs();
            viewer.ShowDialog();
        }

    }
}
