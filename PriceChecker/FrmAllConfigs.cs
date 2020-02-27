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
    public partial class FrmAllConfigs : Form
    {
        public FrmAllConfigs()
        {
            InitializeComponent();
        }

        private void btnHotelList_Click(object sender, EventArgs e)
        {
            var viewer = new FrmHotels();
            viewer.ShowDialog();
        }

        private void btnCityList_Click(object sender, EventArgs e)
        {
            var viewer = new frmCities();
            viewer.ShowDialog();
        }


        private void btnActionList_Click(object sender, EventArgs e)
        {
            var viewer = new FrmActionList();
            viewer.ShowDialog();
        }

        private void btnXPathConfig_Click(object sender, EventArgs e)
        {
            var viewer = new frmLabelList();
            viewer.ShowDialog();
        }
    }
}
