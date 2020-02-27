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
    public partial class frmLabelList : Form
    {
        public frmLabelList()
        {
            InitializeComponent();
            dgLabelList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgLabelList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgLabelList.CellClick += DgLabelList_CellClick;
            dgLabelList.AutoGenerateColumns = false;
        }

        private void DgLabelList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var lbl = (Models.ElementLabel)dgLabelList.Rows[e.RowIndex].DataBoundItem;
            var editor = new FrmLabelEditor(lbl);
            editor.ShowDialog();
            BindLabels();
        }

        private void frmLabelList_Load(object sender, EventArgs e)
        {
            BindLabels();
        }
        void BindLabels()
        {
            var lbo = new BO.ElementLabelBO();
            var ll = lbo.GetQueryable().OrderBy(x => x.LabelName).ToList();
            dgLabelList.DataSource = ll;
        }
    }
}
