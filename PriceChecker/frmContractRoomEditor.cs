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
    public partial class frmContractRoomEditor : Form
    {
        Models.ContractRoom _room;
        Models.Hotel _hotel;
        BO.ContractRoomBO crbo;
        public frmContractRoomEditor(Models.ContractRoom r)
        {
            MyInitialize();
            _room = crbo.GetRoom(r.RoomId);
            _hotel = _room.Hotel;
        }
        void MyInitialize()
        {
            InitializeComponent();
            crbo = new BO.ContractRoomBO();
        }
        public frmContractRoomEditor(Models.Hotel h)
        {
            MyInitialize();
            _hotel = h;
            _room = new Models.ContractRoom { HotelId = h.HotelId };
         
        }

        private void frmContractRoomEditor_Load(object sender, EventArgs e)
        {
            if(_room.RoomId!=0)
            {
                txtRoomName.Text = _room.RoomName;
                btnAction.Text = "Update";

            }
            else
            {
                btnAction.Text = "Add";
                this.Text = "Add room for hotel \"" + _hotel.HotelName + "\"";
                btnRemove.Enabled = false;
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            _room.RoomName = txtRoomName.Text;
            if(_room.RoomId == 0)
            {
                crbo.Add(_room);
            }
            else
            {
                crbo.Save();
            }
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            crbo.Delete(_room);
            this.Close();
        }
    }
}
