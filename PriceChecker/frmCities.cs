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
    public partial class frmCities : Form
    {
        public frmCities()
        {
            InitializeComponent();
            dgCities.AutoGenerateColumns = false;
            dgCities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgCities.CellClick += DgCities_CellClick;
        }

        private void DgCities_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == dgCities.NewRowIndex)
            {
                var editor = new frmCityEditor();
                if(editor.ShowDialog()!= DialogResult.Cancel)
                {
                    BindCities();
                }
            }
            else if(e.ColumnIndex == clmEdit.Index)
            {
                var city = (Models.City)dgCities.Rows[e.RowIndex].DataBoundItem;
                var editor = new frmCityEditor(city.CityId);
                if(editor.ShowDialog()!=DialogResult.Cancel)
                {
                    BindCities();
                }
            }
        }

        void BindCities()
        {
            var cbo = new BO.CityBO();
            var cc = cbo.GetQueryable().ToList();
            var bs = new BindingSource();
            bs.DataSource = cc;
            dgCities.DataSource = bs;
        }

        private void frmCities_Load(object sender, EventArgs e)
        {
            BindCities();
        }
    }
}
