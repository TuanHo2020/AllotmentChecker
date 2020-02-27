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
    public partial class frmCityEditor : Form
    {
        BO.CityBO cbo;
        Models.City _city;
        public frmCityEditor()
        {
            InitializeComponent();
            cbo = new BO.CityBO();
            _city = new Models.City();
        }

        public frmCityEditor(int id)
        {
            InitializeComponent();
            cbo = new BO.CityBO();
            _city = cbo.GetCity(id);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are u sure to delete?", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            else
            {
                cbo.Delete(_city);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            _city.CityCode = txtCityCode.Text;
            _city.CityName = txtCityName.Text;
            _city.HasAirport = cxHasAirport.Checked;
            if (_city.CityId == 0)
            {
                cbo.Add(_city);
            }
            else
            {
                cbo.Save();
            }
        }

        private void frmCityEditor_Load(object sender, EventArgs e)
        {
            if (_city.CityId != 0)
            {
                txtCityCode.Text = _city.CityCode;
                txtCityName.Text = _city.CityName;
                cxHasAirport.Checked = _city.HasAirport;
                btnAction.Text = "Update";
            }
            else
            {
                btnDelete.Enabled = false;
                btnAction.Text = "Add";
            }
        }

    }
}
