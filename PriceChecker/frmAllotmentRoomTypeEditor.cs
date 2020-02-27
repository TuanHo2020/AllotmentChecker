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
    public partial class frmAllotmentRoomTypeEditor : Form
    {
        Models.AllotmentRoomType _rt;
        BO.AllotmentRoomTypeBO rtbo;
        Models.Hotel _hotel;
        
        public frmAllotmentRoomTypeEditor(int id)
        {
            InitializeComponent();
            rtbo = new BO.AllotmentRoomTypeBO();          
                _rt = rtbo.GetRecord(id);
            
        }
        public frmAllotmentRoomTypeEditor(Models.Hotel h)
        {
            InitializeComponent();
            rtbo = new BO.AllotmentRoomTypeBO();
            _rt = new Models.AllotmentRoomType();
            _rt.HotelId = h.HotelId;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are u sure to delete?","", MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                rtbo.Delete(_rt);
            }
        }

        private void frmAllotmentRoomTypeEditor_Load(object sender, EventArgs e)
        {
            if(_rt.RecordId!=0)
            {
                txtDefaultAllotment.Text = _rt.DefaultAllotment.ToString();
                txtRoomName.Text = _rt.RoomName;
                cxIgnoreThis.Checked = _rt.IgnoreThisRoomType;
                btnAction.Text = "Update";
            }
            else
            {
                btnAction.Text = "Add";
                btnDelete.Enabled = false;
                txtDefaultAllotment.Text = "1";
            }
            var hbo = new BO.HotelBO();
            _hotel = hbo.GetHotel(_rt.HotelId);
            lblHotelName.Text = _hotel.HotelName;
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            _rt = rtbo.GetRecord(_rt.RecordId);
            _rt.RoomName = txtRoomName.Text;
            var newAllotment = int.Parse(txtDefaultAllotment.Text);            
            if(_rt.RecordId == 0)
            {
                _rt.DefaultAllotment = newAllotment;
                rtbo.Add(_rt);
            }
            else
            {
                if(newAllotment<_rt.DefaultAllotment)
                {
                    var arbo = new BO.AllotmentRecordBO();
                    arbo.ExecuteSql(@"DELETE FROM AllotmentRecords WHERE AllotmentRoomTypeId={0} AND
                        CurrentAllotment>={1}", new object[] { _rt.RecordId, newAllotment });
                }
                _rt.DefaultAllotment = newAllotment;
                _rt.IgnoreThisRoomType = cxIgnoreThis.Checked;
                rtbo.Save();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
