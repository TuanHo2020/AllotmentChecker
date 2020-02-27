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
    public partial class frmAddAction : Form
    {
    
        public frmAddAction()
        {
            InitializeComponent();
          
        }

        private void frmAddAction_Load(object sender, EventArgs e)
        {
            this.Text = "Add action for project";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var abo = new BO.ActionBO();
            var action = new Models.WebAction();
            action.ActionName = txtActionName.Text;        
            abo.Add(action);
        }
    }
}
