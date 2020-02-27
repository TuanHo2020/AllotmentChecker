using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using System.IO;


namespace PriceChecker
{
    public partial class FrmHotels : Form
    {
      class CsvRow
        {
            public string Id { get; set; }
            public string HotelCode { get; set; }
            public string StarRating { get; set; }
            public string HotelName { get; set; }
            public string Address { get; set; }
            public string ContactNumbers { get; set; }
            public string CityCode { get; set; }
            public string CountryCode { get; set; }
            public string MapLatiude { get; set; }
            public string MapLongitude { get; set; }
            public string MappingCode { get; set; }
            public string Live { get; set; }
            public string Status { get; set; }
            public string ChannelManager { get; set; }
        }
        public FrmHotels()
        {
            InitializeComponent();
            dgHotels.AutoGenerateColumns = false;
            dgHotels.ReadOnly = true;
            dgHotels.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgHotels.CellClick += DgHotels_CellClick;
        }

        private void DgHotels_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dgHotels.NewRowIndex)
            {
                var editor = new frmHotelEditor();
                editor.ShowDialog();
                BindHotels();
            }
            else if (e.ColumnIndex == clmEdit.Index)
            {
                var hotel = (Models.Hotel)dgHotels.Rows[e.RowIndex].DataBoundItem;
                var editor = new frmHotelEditor(hotel.HotelId);
                if (editor.ShowDialog() != DialogResult.Cancel)
                {
                    BindHotels();
                }
            }
        }

       

        void BindHotels()
        {
            var star = string.IsNullOrEmpty(txtStar.Text) ? 0 : int.Parse(txtStar.Text);
            var hbo = new BO.HotelBO();
            var ihotels = hbo.GetQueryable(null).Where(h => h.StarRating >= star);
            if (cxActiveOnly.Checked)
            {
                ihotels = ihotels.Where(h => !h.IsDuplicated);
            }
          
            var bs = new BindingSource();
            bs.DataSource = ihotels.OrderBy(x => x.HotelName).ToList();
            dgHotels.DataSource = bs;
        }
        private void FrmHotels_Load(object sender, EventArgs e)
        {
          
            BindHotels();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            BindHotels();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.ShowDialog();
            var path = dlg.FileName;
            if(string.IsNullOrEmpty(path))
            {
                return;
            }
            var dicColumns = new Dictionary<string, int>();
            var csv = new CsvReader(File.OpenText(path));
            csv.Read();
            csv.ReadHeader();
            var headerRow = csv.Context.HeaderRecord;
            for(var i = 0;i<headerRow.Count();i++)
            {
                var name = headerRow[i];
                dicColumns.Add(name, i);
            }
            var records = csv.GetRecords<CsvRow>();

            foreach (var record in records)
            {
                var hbo = new BO.HotelBO();

                var hotel = hbo.GetHotel(record.HotelName);
                if (hotel == null)
                {
                    hotel = hbo.GetQueryable(null).SingleOrDefault(h => h.HMSID == record.Id);
                }
                if (hotel == null)
                {
                    hotel = new Models.Hotel();
                    hotel.CheckAllotment = true;                 
                }
                hotel.HotelName = record.HotelName;
                hotel.HMSID = record.Id;             
                hotel.StarRating = decimal.Parse(record.StarRating);
                if (hotel.CityId == 43||hotel.CityId ==0)//43 is unknown
                {
                    var cbo = new BO.CityBO();
                    var c = cbo.GetQueryable().FirstOrDefault(f => f.CityCode == record.CityCode);
                    if (c == null)
                    {
                        c = new Models.City();
                        c.CityCode = record.CityCode;
                        c.CityName = record.CityCode;
                        c.HasAirport = false;
                        cbo.Add(c);
                    }
                    hotel.CityId = c.CityId;
                }
                if(hotel.HotelId == 0)
                {
                    hbo.Add(hotel);
                }
                else
                {
                    hbo.Save();
                }
            }
            MessageBox.Show("Done");
        }
    }
}
