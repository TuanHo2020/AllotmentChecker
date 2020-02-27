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
    public partial class FrmCloseDateReport : Form
    {
        class BindItem
        {
            public int RecordId { get; set; }
            public DateTime AllotmentDate { get; set; }
            public int HotelId { get; set; }
            public bool Acknowledged { get; set; }
            public string RoomName { get; set; }
            public string HotelName { get; set; }
        //    public int Allotment { get; set; }
        }
        public FrmCloseDateReport()
        {
            InitializeComponent();           
            dgRecords.AutoGenerateColumns = false;
            dgRecords.AllowUserToAddRows = false;
            dgRecords.CellFormatting += DgRecords_CellFormatting;
        }

        private void DgRecords_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex == clmDate.Index)
            {
                var v = e.Value as DateTime?;
                var str = v == null ? string.Empty : ((DateTime)v).ToString("dd/MM/yyyy");
                e.Value = str;
            }
        }

        void BindData()
        {
            var lst = GetBindItemList();
            dgRecords.DataSource = lst;
            var hotelIds = lst.Select(x => new { x.HotelId, x.HotelName }).Distinct().ToList();
            var bld = new StringBuilder();          
            var dt = DateTime.UtcNow.AddHours(7).Date;
    
        }
        List<BindItem> GetBindItemList()
        {
            var entities = new Models.PriceCheckerEntities();
            var arbo = new BO.AllotmentRecordBO(entities);
            var rtbo = new BO.AllotmentRoomTypeBO(entities);
            var hbo = new BO.HotelBO(entities);
        
            var rr = arbo.GetQueryable();
            var rts = rtbo.GetQueryable();
            var hh = hbo.GetQueryable(null);
            var qq = from r in rr
                     join rt in rts on r.AllotmentRoomTypeId equals rt.RecordId
                     join h in hh on rt.HotelId equals h.HotelId
                     where h.CheckAllotment & r.CurrentAllotment < rt.DefaultAllotment && !r.Acknowledged & !rt.IgnoreThisRoomType
                     select new BindItem
                     {
                         Acknowledged = r.Acknowledged,
                         HotelId = h.HotelId,
                         HotelName = h.HotelName,
                         AllotmentDate = r.AllotmentDate,
                         RecordId = r.RecordId,
                         RoomName = rt.RoomName,
                     //    Allotment = r.CurrentAllotment
                     };
            var lst = qq.OrderBy(q => q.HotelName).ThenBy(q => q.RoomName).ToList();
            return lst;
        }

        private void btnUpdateAndRefresh_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgRecords.Rows)
            {
                var bd = (BindItem)row.DataBoundItem;               
                if (bd.Acknowledged)
                {
                   
                    var arbo = new BO.AllotmentRecordBO();
                    var record = arbo.GetRecord(bd.RecordId);
                    record.Acknowledged = true;
                    arbo.Save();
                }                
            }
            BindData();
        }

        private void FrmCloseDateReport_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnRemoveNotAcknowledged_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are u sure to delete?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var cmdText = @"DELETE AllotmentRecords FROM AllotmentRecords r JOIN 
AllotmentRoomTypes c ON r.AllotmentRoomTypeId = c.RecordId WHERE Acknowledged=0";
                var arbo = new BO.AllotmentRecordBO();
                arbo.ExecuteSql(cmdText, new object[] { });
                BindData();
            }
        }

        private void btnExportXML_Click(object sender, EventArgs e)
        {           
            var lst = GetBindItemList();
            var records = (from x in lst select new Modules.SaveFileModule.CsvRecord {HotelName = x.HotelName,
                RoomName = x.RoomName, CloseDate = x.AllotmentDate, Acknowledged = x.Acknowledged }).ToList();
            Modules.SaveFileModule.Save(records);
            if (cxMarkAsAcknowledged.Checked)
            {
                var cmdText = "UPDATE AllotmentRecords SET Acknowledged=1 WHERE RecordId={0}";
                var rbo = new BO.AllotmentRecordBO();
                foreach (var x in lst)
                {
                    if(!x.Acknowledged)
                    {
                        rbo.ExecuteSql(cmdText, new object[] { x.RecordId });
                    }
                }
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            var dresult = MessageBox.Show(@"This will remove all ACKNOWLEDGE RECORDS and make ANY 
CLOSED DATES FROM TODAY APPEARED AS UNACKNOWLEDGED in the next report. Are you sure to process?",
"Confirmation", MessageBoxButtons.YesNo);
            if(dresult != DialogResult.Yes)
            {
                return;
            }
            var cmdText = "DELETE FROM AllotmentRecords";
            var rbo = new BO.AllotmentRecordBO();
            rbo.ExecuteSql(cmdText, new object[] { });
        }
    }
}
