using EXIN.Controller;
using System;
using System.Windows.Forms;

namespace EXIN
{
    public partial class frmMsgBox_Confirmation_Delete : Form
    {

        public frmMsgBox_Confirmation_Delete()
        {
            InitializeComponent();
        }

        private void frmMsgBox_Confirmation_Delete_Load(object sender, EventArgs e)
        {
            //***** Main Code
            zeroitSmoothAnimator1.Start();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Give the returned value to the global variable for confirmation message
            Global.msgConfirmation = true;

            // Close the transparent form
            frmTransparentForm obj = (frmTransparentForm)Application.OpenForms["frmTransparentForm"];
            obj.Close();

            // Close this form 
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            // Give the returned value to the global variable for confirmation message
            Global.msgConfirmation = false;

            // Close the transparent form
            frmTransparentForm obj = (frmTransparentForm)Application.OpenForms["frmTransparentForm"];
            obj.Close();

            // Close this form 
            this.Close();
        }

    }
}
