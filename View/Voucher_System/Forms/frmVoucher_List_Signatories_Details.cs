using EXIN.Controller;
using System;
using System.Windows.Forms;

namespace EXIN.Voucher_System
{
    public partial class frmVoucher_List_Signatories_Details : Form
    {
        public frmVoucher_List_Signatories_Details()
        {
            InitializeComponent();

            // Controls - TextBox
            txtFullName.BorderColor = Global.themeColor1;
            txtFullName.FocusedState.BorderColor = Global.themeColor2;
            txtFullName.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtPosition.BorderColor = Global.themeColor1;
            txtPosition.FocusedState.BorderColor = Global.themeColor2;
            txtPosition.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtDepartment.BorderColor = Global.themeColor1;
            txtDepartment.FocusedState.BorderColor = Global.themeColor2;
            txtDepartment.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboStatus.BorderColor = Global.themeColor1;
            cboStatus.FocusedState.BorderColor = Global.themeColor2;
            cboStatus.HoverState.BorderColor = Global.themeColor2;

            // Panel Title
            guna2PanelTitle.CustomBorderColor = Global.themeColor2;

            // Controls - Button 3
            btnSave.FillColor = Global.themeColor1;
            btnSave.FillColor2 = Global.themeColor2;

            // Controls - Button 3
            btnClose.FillColor = Global.themeColor1;
            btnClose.FillColor2 = Global.themeColor2;
        }

        private void frmVoucher_List_Signatories_Details_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
