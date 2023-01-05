using System;
using System.Windows.Forms;

namespace EXIN
{
    public partial class frmDummy : Form
    {

        public frmDummy()
        {
            InitializeComponent();
        }

        private void frmDummy_Load(object sender, EventArgs e)
        {
            //*****Main Code
            zeroitSmoothAnimator1.Start();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmMsgBox_Confirmation frmMsgBox_Confirmation = new frmMsgBox_Confirmation();
            frmMsgBox_Confirmation.lblMessage.Text = "Hello" + "";
            frmMsgBox_Confirmation.ShowDialog();
        }

    }
}
