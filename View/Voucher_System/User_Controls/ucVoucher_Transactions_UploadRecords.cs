using EXIN.Controller;
using System;
using System.Windows.Forms;

namespace EXIN.Voucher_System
{
    public partial class ucVoucher_Transactions_UploadRecords : UserControl
    {
        public ucVoucher_Transactions_UploadRecords()
        {
            InitializeComponent();

            //Panel Resize Progress bar
            panelProgressBar.Width = 233;
            panelProgressBar.Height = 63;

            //Panel Resize Recordcount
            panelRecordCount.Width = 122;
            panelRecordCount.Height = 63;

            // Panel with Datagrid
            panelUpload.CustomBorderColor = Global.themeColor1;

            // Controls - TextBox
            txtFilePath.BorderColor = Global.themeColor1;
            txtFilePath.FocusedState.BorderColor = Global.themeColor2;
            txtFilePath.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtErrorLogs.BorderColor = Global.themeColor1;
            txtErrorLogs.FocusedState.BorderColor = Global.themeColor2;
            txtErrorLogs.HoverState.BorderColor = Global.themeColor2;

            // Controls - Button - Delete
            btnBrowse.FillColor = Global.themeColor1;
            btnBrowse.HoverState.FillColor = Global.themeColor2;
            btnBrowse.HoverState.ForeColor = Global.themeForeColor;

            // Controls - Button - Cancel
            btnCancel.FillColor = Global.themeColor1;
            btnCancel.HoverState.FillColor = Global.themeColor2;
            btnCancel.HoverState.ForeColor = Global.themeForeColor;
        }

        private void ucVoucher_Transactions_UploadRecords_Load(object sender, EventArgs e)
        {

        }
    }
}
