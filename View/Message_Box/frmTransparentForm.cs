using System;
using System.Windows.Forms;

namespace EXIN
{
    public partial class frmTransparentForm : Form
    {
        public frmTransparentForm()
        {
            //this.Opacity = 0;

            InitializeComponent();
        }

        private void frmTransparentForm_Load(object sender, EventArgs e)
        {
            //***** Main Code
            zeroitSmoothAnimator1.Start();
        }

    }
}
