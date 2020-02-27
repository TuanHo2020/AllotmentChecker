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
    public partial class FrmHotelCloseDateViewer : Form
    {
        class BindingItem
        {
            public int RecordId { get; set; }
            public int CurrentAllotment { get; set; }
            public string RoomName { get; set; }
            public bool Acknowledged { get; set; }
            public DateTime Date { get; set; }
        }
        Models.Hotel _hotel;
        BO.AllotmentRoomTypeBO rtbo;
        BO.AllotmentRecordBO rbo;
        Models.AllotmentRoomType _currentRoomType = null;
     //   bool remove2020Only;
        public FrmHotelCloseDateViewer(Models.Hotel h)
        {
            InitializeComponent();
            _hotel = h;
            dgRecords.CellClick += DgRecords_CellClick;
            dgRecords.AutoGenerateColumns = false;
         
        }

        private void DgRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmRemove.Index)
            {
                var bindingItem = (BindingItem)dgRecords.Rows[e.RowIndex].DataBoundItem;     
                if (MessageBox.Show("are u sure to remove?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var record = rbo.GetRecord(bindingItem.RecordId);
                    rbo.Delete(record);
                    BindData();
                }
                else return;
            }
        }
        void BindData()
        {

            dgRecords.DataSource = GetBindingItemList();
          
        }
        List<BindingItem> GetBindingItemList()
        {
            var entities = new Models.PriceCheckerEntities();
            rtbo = new BO.AllotmentRoomTypeBO(entities);
            rbo = new BO.AllotmentRecordBO(entities);
            var rts = rtbo.GetQueryable();
            var rr = rbo.GetQueryable();
            var qq = from r in rr
                     join rt in rts on r.AllotmentRoomTypeId equals rt.RecordId
                     where rt.HotelId == _hotel.HotelId && r.CurrentAllotment < rt.DefaultAllotment
                     & !rt.IgnoreThisRoomType
                     select new { rt, r };
            if (_currentRoomType != null && _currentRoomType.RecordId != 0)
            {
                qq = qq.Where(x => x.rt.RecordId == _currentRoomType.RecordId);
            }
            
            if (cxNotAcknowledgedOnly.Checked)
            {
                qq = qq.Where(q => !q.r.Acknowledged);
            }

            var items = qq.Select(x => new BindingItem
            {
                Acknowledged = x.r.Acknowledged,
                CurrentAllotment = x.r.CurrentAllotment,
                Date = x.r.AllotmentDate,
                RecordId = x.r.RecordId,
                RoomName = x.rt.RoomName
            }).OrderBy(x => x.Acknowledged).ThenBy(x => x.RoomName).ThenBy(x => x.Date).ToList();
            return items;
        }

        private void FrmAllotmentRecordViewer_Load(object sender, EventArgs e)
        {
          
            cxNotAcknowledgedOnly.Checked = true;
            BindData();
            this.Text = "View allotment for hotel \"" + _hotel.HotelName + "\"";
            var itemAll = new Models.AllotmentRoomType { RoomName = "All Rooms" };
            cmbRoomTypes.Items.Add(itemAll);
            var rtbo = new BO.AllotmentRoomTypeBO();
            var rts = rtbo.GetQueryable().Where(x=>x.HotelId == _hotel.HotelId).ToList();
            foreach(var rt in rts)
            {
                cmbRoomTypes.Items.Add(rt);
            }
            cmbRoomTypes.SelectedIndex = 0;
        }

        private void cxNotAcknowledgedOnly_CheckedChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgRecords.Rows)
            {
                var rw = (BindingItem)row.DataBoundItem;
                var record = rbo.GetRecord(rw.RecordId);
                if(record.Acknowledged !=rw.Acknowledged)
                {
                    record.Acknowledged = rw.Acknowledged;
                    rtbo.Save();
                }
            }
            BindData();
        }

       

        private void btnView_Click(object sender, EventArgs e)
        {
            _currentRoomType = (Models.AllotmentRoomType)cmbRoomTypes.SelectedItem;
            BindData();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("This will remove all records of current hotels. Are u sure to process?",
                null, MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                var cmdText = string.Empty;
             
                cmdText = @"DELETE AllotmentRecords FROM AllotmentRecords r JOIN 
AllotmentRoomTypes c ON r.AllotmentRoomTypeId = c.RecordId WHERE HotelId ={0}";
                if (cxNotAcknowledged.Checked)
                {
                    cmdText += " AND Acknowledged=0";
                  
                }
               
                rbo.ExecuteSql(cmdText, new object[] { });
                this.DialogResult = DialogResult.OK;
                this.Close();
              /*  var arbo = new BO.AllotmentRoomTypeBO();
                var rr = arbo.GetQueryable(_hotel.HotelId).ToList();
                foreach(var r in rr)
                {
                    r.IgnoreThisRoomType = false;
                }
                arbo.Save();*/
            }
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            var lst = GetBindingItemList();
            var records = (from x in lst
                           select new Modules.SaveFileModule.CsvRecord
                           {
                               HotelName = _hotel.HotelName,
                               RoomName = x.RoomName,
                               CloseDate = x.Date,
                               Acknowledged = x.Acknowledged
                           }).ToList();
            Modules.SaveFileModule.Save(records);
        }
    }
}
