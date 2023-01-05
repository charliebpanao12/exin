using EXIN.Controller;
using System;
using System.Windows.Forms;

namespace EXIN.SalesCollection_System
{
    public partial class frmSalesCollection_List_GCAccounts_Details : Form
    {
        public frmSalesCollection_List_GCAccounts_Details()
        {
            InitializeComponent();

            // Controls - TextBox
            txtGCCode.BorderColor = Global.themeColor1;
            txtGCCode.FocusedState.BorderColor = Global.themeColor2;
            txtGCCode.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtGCName.BorderColor = Global.themeColor1;
            txtGCName.FocusedState.BorderColor = Global.themeColor2;
            txtGCName.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtGCValue.BorderColor = Global.themeColor1;
            txtGCValue.FocusedState.BorderColor = Global.themeColor2;
            txtGCValue.HoverState.BorderColor = Global.themeColor2;

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

        private void frmSalesCollection_List_GCAccounts_Details_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
