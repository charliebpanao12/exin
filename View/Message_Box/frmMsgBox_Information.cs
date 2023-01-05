using System;
using System.Windows.Forms;

namespace EXIN
{
    public partial class frmMsgBox_Information : Form
    {

        public frmMsgBox_Information()
        {
            InitializeComponent();
        }

        private void frmMsgBox_Information_Load(object sender, EventArgs e)
        {
            //***** Main Code
            zeroitSmoothAnimator1.Start();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Close the transparent form
            frmTransparentForm obj = (frmTransparentForm)Application.OpenForms["frmTransparentForm"];
            obj.Close();

            // Close this form
            this.Close();
        }

    }
}
