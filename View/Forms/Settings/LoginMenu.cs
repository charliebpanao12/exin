using System;
using System.Windows.Forms;

namespace EXIN
{
    public partial class frmLogInMenu : Form
    {
        public frmLogInMenu()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();

        }


    }
}
