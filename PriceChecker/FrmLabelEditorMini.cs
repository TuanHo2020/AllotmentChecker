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
    public partial class FrmLabelEditor : Form
    {
        Models.ElementLabel _lbl;
        BO.ElementLabelBO elbo;
        Models.WebAction _action;
        public FrmLabelEditor(Models.ElementLabel lbl)
        {
            InitializeComponent();
            elbo = new BO.ElementLabelBO();
            if (lbl.LabelId == 0)
            {
                _lbl = new Models.ElementLabel();
            }
            else
            {
                _lbl = elbo.GetLabel(lbl.LabelId);
                _lbl.ActionId = lbl.ActionId;          
            }
            var abo = new BO.ActionBO();
            _action = abo.GetAction(_lbl.ActionId);
        }
        public FrmLabelEditor(Models.WebAction act)
        {
            InitializeComponent();
            elbo = new BO.ElementLabelBO();
            _lbl = new Models.ElementLabel();
            _action = act;
            _lbl.ActionId = _action.ActionId;       
        }

        private void FrmLabelEditor_Load(object sender, EventArgs e)
        {            
            /*USE FULL VERSION WITH NAME FRMLABELEDITOR STILL INSIDE THIS PROJECT IF YOU WANT FULL FUNCTION */
            if(_lbl.LabelId ==0)
            {
                btnAction.Text = "Add New";
            }
            else
            {
                btnAction.Text = "Update";                
            }
            BindDetailData();
        }
        void BindDetailData()
        {   
            txtLabelName.Text = _lbl.LabelName;
            txtXPath.Text = _lbl.XPath;
            txtCustomData.Text = _lbl.CustomData;

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAction_Click(object sender, EventArgs e)
        {            
            _lbl.XPath = string.IsNullOrEmpty(txtXPath.Text) ? string.Empty : txtXPath.Text;           
            _lbl.LabelName = txtLabelName.Text;
            _lbl.CustomData = txtCustomData.Text;
            if (_lbl.LabelId == 0)
            {
                _lbl.ResultXPath = string.Empty;
                _lbl.ExpectedResultType = (int)LabelExpectedResultType.Nothing;
                _lbl.WaitType = (int)WaitType.Nothing;
                _lbl.LabelOrder = elbo.GetQueryable(_lbl.ActionId).Count();
                //02/01/2020: this is just for default behavior. The inteface has been simplified to not contain behavior selection.
                _lbl.ExpectedBehavior = (int)WebElementBehavior.ClickByXPath;
                elbo.Add(_lbl);
            }
            else
            {
                elbo.Save();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
