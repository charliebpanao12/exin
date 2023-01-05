using EXIN.Controller;
using System;
using System.Windows.Forms;

namespace EXIN.Voucher_System
{
    public partial class ucVoucher_Home : UserControl
    {
        public ucVoucher_Home()
        {
            InitializeComponent();
        }

        private void ucVoucher_Home_Load(object sender, EventArgs e)
        {
            // Controls - Button 3
            btnSelect.FillColor = Global.themeColor1;
            btnSelect.FillColor2 = Global.themeColor2;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            
        }
    }
}
