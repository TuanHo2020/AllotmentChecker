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
    public partial class frmStringViewer : Form
    {
        string _text;
        public frmStringViewer(string text)
        {
            InitializeComponent();
            _text = text;
        }

        private void frmStringViewer_Load(object sender, EventArgs e)
        {
            Console.WriteLine("text until here: " + _text);
            txtProgress.Text = "abc: " +  _text;
        }
    }
}
