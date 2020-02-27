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
    public partial class FrmLabelNavigator : Form
    {
        string _initMsg = null;
        Objects.WebActionObject _act;
        public FrmLabelNavigator(Objects.WebActionObject act, Models.ElementLabel lbl, string msg)
        {
            InitializeComponent();
            _initMsg = msg;
            _act = act;
            dgLabels.AutoGenerateColumns = false;
            dgLabels.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgLabels.CellClick += DgLabels_CellClick;
        }

        private void DgLabels_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgLabels.Columns[e.ColumnIndex].CellType == typeof(DataGridViewLinkCell))
            {
                var lbl = (Models.ElementLabel)dgLabels.Rows[e.RowIndex].DataBoundItem;
                if (e.ColumnIndex == clmEdit.Index)
                {                    
                    var editor = new FrmLabelEditor(lbl);
                    if (editor.ShowDialog() != DialogResult.Cancel)
                    {
                        BindLabels();
                    }
                }
                else if(e.ColumnIndex == clmRun.Index)
                {
                    var objLabel = new Objects.LabelObject(lbl, _act._ReturnDataCollection);
                    try
                    {
                        objLabel.ExecuteBehavior();
                    }
                    catch (Exception ex)
                    {
                        txtResult.AppendText(ex.ToString());
                    }
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            
        }

        void BindLabels()
        {
            var lbo = new BO.ElementLabelBO();
            var ll = lbo.GetQueryable(_act._ActionData.ActionId).OrderBy(l => l.LabelOrder).ToList();
            var bs = new BindingSource();
            bs.DataSource = ll;
            dgLabels.DataSource = bs;
        }

        private void FrmLabelNavigator_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(_initMsg))
            {
                MessageBox.Show(_initMsg);
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
           this.DialogResult = MessageBox.Show(@"Click Yes to continue the task, no throw an exception", "",
                MessageBoxButtons.YesNo);
            base.OnClosing(e);
        }

    }
}
