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
    public partial class FrmActionList : Form
    {
        public FrmActionList()
        {
            InitializeComponent();
            
            dgActions.AutoGenerateColumns = false;
            dgActions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgActions.CellClick += DgActions_CellClick;
            dgActions.ReadOnly = true;
        }

        private void DgActions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == dgActions.NewRowIndex)
            {
                var editor = new frmAddAction();
                if(editor.ShowDialog()!= DialogResult.Cancel)
                {
                    BindActions();
                }
            }
            else if(e.ColumnIndex == clmEdit.Index)
            {
                var action = (Models.WebAction)dgActions.Rows[e.RowIndex].DataBoundItem;
                var editor = new FrmActionEditor(action.ActionId);
                if(editor.ShowDialog()!= DialogResult.Cancel)
                {
                    BindActions();
                }
            }
        }

        void BindActions()
        {
            var abo = new BO.ActionBO();
            var lst = abo.GetQueryable().ToList();
            var bs = new BindingSource();
            bs.DataSource = lst;
            dgActions.DataSource = bs;
        }
        private void FrmActionList_Load(object sender, EventArgs e)
        {
            this.Text = "Action list";
            BindActions();
        }
    }
}
