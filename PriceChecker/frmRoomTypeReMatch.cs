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
    public partial class frmRoomTypeReMatch : Form
    {
        Models.ContractRoom _r;
        List<string> _availRooms;
        public frmRoomTypeReMatch(Models.ContractRoom r, List<string> availRoomTypes)
        {
            InitializeComponent();
            _r = r;
            _availRooms = availRoomTypes;
        }

        private void frmRoomTypeReMatch_Load(object sender, EventArgs e)
        {
            txtNotMatchedRoomType.Text = "Room type \"" + _r.RoomName + @""" cannot be found. Please
 match it to one of the below room type to continue.";
            foreach(var ar in _availRooms)
            {
                cmbAvailableRoomTypes.Items.Add(ar);
            }
        }

        private void btnMatch_Click(object sender, EventArgs e)
        {
            if(cmbAvailableRoomTypes.SelectedItem == null||cmbAvailableRoomTypes.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a matched room type");
                return;
            }
            var rbo = new BO.ContractRoomBO();
            _r = rbo.GetRoom(_r.RoomId);
            _r.RoomName = cmbAvailableRoomTypes.SelectedItem as string;
            rbo.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
