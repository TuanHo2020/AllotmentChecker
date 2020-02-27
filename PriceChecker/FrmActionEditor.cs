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
    public partial class FrmActionEditor : Form
    {
        Models.WebAction _action;
        BO.ActionBO abo;
        BO.ElementLabelBO lbo;
        public BackgroundWorker _wk { get; set; }


        public FrmActionEditor(int actionId)
        {
            InitWindow();
            _action = abo.GetAction(actionId);
      
                
        }
        void InitilizeWorker()
        {
            if(_wk!=null)
            {
                _wk.Dispose();
            }
            _wk = new BackgroundWorker() { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
          
            _wk.DoWork += _wk_DoWork;
            _wk.ProgressChanged += _wk_ProgressChanged;
            _wk.RunWorkerCompleted += _wk_RunWorkerCompleted;
        }

        private void _wk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtProgress.AppendText("All tasks done");
        }

        private void _wk_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            txtProgress.AppendText(e.UserState.ToString() + Environment.NewLine);
        }

        private void _wk_DoWork(object sender, DoWorkEventArgs e)
        {
            DoAction();
        }
        void DoAction()
        {
            var objAction = new Objects.WebActionObject(_action);
            objAction._wk = _wk;
            objAction.ExecuteAction(true);
        }

        void InitWindow()
        {
            InitializeComponent();
            abo = new BO.ActionBO();
            lbo = new BO.ElementLabelBO();
            dgLabels.AutoGenerateColumns = false;
            dgLabels.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgLabels.CellClick += DgLabels_CellClick;
            dgLabels.ReadOnly = true;
        }

        private void DgLabels_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            var idx = e.RowIndex;
            if (idx == dgLabels.NewRowIndex)
            {
                FrmLabelEditor editor = new PriceChecker.FrmLabelEditor(_action);
                if (editor.ShowDialog() != DialogResult.Cancel)
                {
                    BindLabels();
                }
            }
            else
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
                else if (e.ColumnIndex == clmMoveDown.Index)
                {
                    lbo.MoveDown(lbl);
                    BindLabels();
                }
                else if (e.ColumnIndex == clmMoveUp.Index)
                {
                    lbo.MoveUp(lbl);
                    BindLabels();
                }
                else if (e.ColumnIndex == clmExecute.Index)
                {
                    var objLabel = new Objects.LabelObject(lbl, null);
                    try
                    {
                        objLabel.ExecuteBehavior();
                    }
                    catch (Exception ex)
                    {
                        txtProgress.AppendText(ex.ToString());
                    }
                }
            }
        }

        void BindLabels()
        {
            lbo = new BO.ElementLabelBO();
            BindingSource bs = new BindingSource();
            bs.DataSource = lbo.GetQueryable(_action.ActionId).OrderBy(x => x.LabelOrder).ToList();
            dgLabels.DataSource = bs;
        }

        private void FrmActionEditor_Load(object sender, EventArgs e)
        {
            if (_action.ActionId != 0)
            {
                this.Text = "Editing action " + _action.ActionName;
                txtActionName.Text = _action.ActionName;
            }          
            BindLabels();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            _action.ActionName = txtActionName.Text;
            abo.Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are u sure to delete?","", MessageBoxButtons.YesNo)!= DialogResult.Yes)
            {
                return;
            }
            abo.Delete(_action);
        }

        private void btnRunAction_Click(object sender, EventArgs e)
        {
            InitilizeWorker();
            _wk.RunWorkerAsync();
        }
    }
}
