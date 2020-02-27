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
    public partial class frmAllotmentHotels : Form
    {
        public frmAllotmentHotels()
        {
            InitializeComponent();
            dgAllotmentHotels.CellClick += DgAllotmentHotels_CellClick;
            dgAllotmentHotels.AutoGenerateColumns = false;
            dgAllotmentHotels.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.Width = 600;
        }

        private void DgAllotmentHotels_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var h = (Models.Hotel)dgAllotmentHotels.Rows[e.RowIndex].DataBoundItem;
            if(e.ColumnIndex == clmEdit.Index)
            {
                var editor = new frmHotelEditor(h.HotelId);
                if (editor.ShowDialog() != DialogResult.Cancel)
                {
                    BindAllotmentHotels();
                }
            }
        
            else if(e.ColumnIndex == clmCloseDates.Index)
            {
                var viewer = new FrmHotelCloseDateViewer(h);
                viewer.ShowDialog();
            }
        }

        void BindAllotmentHotels()
        {
            var hbo = new BO.HotelBO();
            var hh = hbo.GetQueryable(null).Where(h => h.CheckAllotment).OrderBy(h=>h.HotelName).ToList();
            dgAllotmentHotels.DataSource = hh;
        }

        private void frmAllotmentHotels_Load(object sender, EventArgs e)
        {
            BindAllotmentHotels();
        }
    }
}
