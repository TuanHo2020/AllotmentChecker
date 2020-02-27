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
    public partial class FrmAllotmentRoomTypes : Form
    {
        Models.Hotel _h;
        public FrmAllotmentRoomTypes(Models.Hotel h)
        {
            InitializeComponent();
            _h = h;
            dgAllotmentRoomTypes.CellClick += DgAllotmentRoomTypes_CellClick;
            dgAllotmentRoomTypes.AutoGenerateColumns = false;
        }

        private void DgAllotmentRoomTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex== clmEdit.Index)
            {
                var rt = (Models.AllotmentRoomType)dgAllotmentRoomTypes.Rows[e.RowIndex].DataBoundItem;
                
                    var editor = new frmAllotmentRoomTypeEditor(rt.RecordId);
                    if(editor.ShowDialog()!= DialogResult.Cancel)
                    {
                        BindRoomTypes();
                    }
               
            }
        }

        void BindRoomTypes()
        {
            var rbo = new BO.AllotmentRoomTypeBO();
            var rr = rbo.GetQueryable(_h.HotelId).ToList();
            var bs = new BindingSource();
            bs.DataSource = rr;
            dgAllotmentRoomTypes.DataSource = bs;
       
        }

        private void FrmAllotmentRoomType_Load(object sender, EventArgs e)
        {
            this.Text = "Showing allotment room types for hotel " + _h.HotelName;
            BindRoomTypes();
        }
    }
}
