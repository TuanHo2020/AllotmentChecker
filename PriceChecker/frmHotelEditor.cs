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
    public partial class frmHotelEditor : Form
    {
       
        Models.Hotel _hotel;
        BO.HotelBO hbo;     
        BO.CityBO ctbo;
       
        
        public frmHotelEditor()
        {
            InitializeComponent();
            hbo = new BO.HotelBO();
            _hotel = new Models.Hotel();
            InitializeDataView();
            ctbo = new BO.CityBO();
          
        }

    /*    private void DgRoomTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmContractRoomEditor editor = null;
            MessageBox.Show("ok");
            if(e.RowIndex == dgRoomTypes.NewRowIndex)
            {
                editor = new frmContractRoomEditor(_hotel);
            }
            else
            {
                var r = (Models.ContractRoom)dgRoomTypes.Rows[e.RowIndex].DataBoundItem;
                editor = new frmContractRoomEditor(r);                
            }
            if(editor.ShowDialog()== DialogResult.OK)
            {
                BindRoomTypes();
            }

        }*/

        void InitializeDataView()
        {
            dgRoomTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;            
            dgRoomTypes.AutoGenerateColumns = false;
            dgRoomTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgRoomTypes.CellClick += DgRoomTypes_CellClick;
        }

        private void DgRoomTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmContractRoomEditor editor = null;
            if (e.RowIndex == dgRoomTypes.NewRowIndex)
            {
                editor = new frmContractRoomEditor(_hotel);
            }
            else
            {
                var r = (Models.ContractRoom)dgRoomTypes.Rows[e.RowIndex].DataBoundItem;
                editor = new frmContractRoomEditor(r);
            }
            if (editor.ShowDialog() == DialogResult.OK)
            {
                BindRoomTypes();
            }

        }

        public frmHotelEditor(int hotelId)
        {
            ctbo = new BO.CityBO();
            InitializeComponent();
            hbo = new BO.HotelBO();
            _hotel = hbo.GetHotel(hotelId);
            InitializeDataView();
        }
   
      
        void BindDetailData()
        {         
            txtHmsId.Text = _hotel.HMSID;
            txtHotelName.Text = _hotel.HotelName;
            cxCheckAllotment.Checked = _hotel.CheckAllotment;
            BindRoomTypes();
        }
        void BindRoomTypes()
        {
            var crbo = new BO.ContractRoomBO();
            var crs = crbo.GetQueryable(_hotel.HotelId).ToList();
            var bs = new BindingSource();
            bs.DataSource = crs;
            dgRoomTypes.DataSource = bs;
        }
        void BindCities()
        {          
            var cc = ctbo.GetQueryable().ToList();
            cmbCities.DataSource = cc;
            cmbCities.DisplayMember = "CityName";
        }
        private void frmHotelEditor_Load(object sender, EventArgs e)
        {
            BindCities();
            /* Here: we need functions to add and remove room types, update contract valid date
             * to available date in season */
            if (_hotel.HotelId != 0)
            {
                BindDetailData();
                btnAction.Text = "Update";
                btnDelete.Enabled = true;
                txtMinCutOffDates.Text = _hotel.MinCutOffDates.ToString();
            
                dtContractValidTo.Value = _hotel.ContractValidTo;
                dtContractValidFrom.Value = DateTime.UtcNow;
                var city = ctbo.GetCity(_hotel.CityId);
                cmbCities.SelectedIndex = cmbCities.FindString(city.CityName);
                dgRoomTypes.Enabled = true;
            }
            else
            {
                dtContractValidFrom.Value = dtContractValidTo.Value = DateTime.UtcNow.AddDays(-1);
                txtMinCutOffDates.Text = "1";
                btnAction.Text = "Add";
                btnDelete.Enabled = false;
            }
           
        }


        private void btnAction_Click(object sender, EventArgs e)
        {
            _hotel.HotelName = txtHotelName.Text;         
            _hotel.HMSID = txtHmsId.Text;
            _hotel.CheckAllotment = cxCheckAllotment.Checked;
            _hotel.ContractValidTo = dtContractValidTo.Value;
            _hotel.ContractValidFrom = dtContractValidFrom.Value;
            _hotel.CityId = ((Models.City)cmbCities.SelectedItem).CityId;
            _hotel.MinCutOffDates = string.IsNullOrEmpty(txtMinCutOffDates.Text)?0: int.Parse(txtMinCutOffDates.Text);
            if(cmbCities.SelectedItem==null)
            {
                MessageBox.Show("Select a city");
                return;
            }
            if (_hotel.HotelId == 0)
            {
                var initDate = new DateTime(2000, 1, 1);
                _hotel.CreatedDate = DateTime.UtcNow;  
                 hbo.Add(_hotel);              
                BindDetailData();            
            }
            else
            {
                hbo.Save();
            }
       
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are u sure to delete?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                hbo.Delete(_hotel);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }




    }
}
