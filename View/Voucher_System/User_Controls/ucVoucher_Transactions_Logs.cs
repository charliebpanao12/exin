using EXIN.Controller;
using System;
using System.Windows.Forms;

namespace EXIN.Voucher_System
{
    public partial class ucVoucher_Transactions_Logs : UserControl
    {
        public ucVoucher_Transactions_Logs()
        {
            InitializeComponent();

            //Panel Resize Progress bar
            panelProgressBar.Width = 233;
            panelProgressBar.Height = 63;

            //Panel Resize Recordcount
            panelRecordCount.Width = 122;
            panelRecordCount.Height = 63;

            // Panel with Datagrid
            panelLogs.CustomBorderColor = Global.themeColor1;

            // Controls - Textbox - Search
            txtSearch.BorderColor = Global.themeColor1;
            txtSearch.FocusedState.BorderColor = Global.themeColor2;
            txtSearch.HoverState.BorderColor = Global.themeColor2;

            // Controls - Button - Cancel
            btnCancel.FillColor = Global.themeColor1;
            btnCancel.HoverState.FillColor = Global.themeColor2;
            btnCancel.HoverState.ForeColor = Global.themeForeColor;

            #region Filter Box
            // Controls - Filter
            panelFilter_Header.FillColor = Global.themeColor2;
            grpFilter.ForeColor = Global.themeColor1;
            btnApplyFilter.FillColor = Global.themeColor1;
            btnApplyFilter.FillColor2 = Global.themeColor2;

            // Controls - DateTimePicker
            dtpStartDate.FillColor = Global.themeColor1;
            dtpStartDate.BorderColor = Global.themeColor1;
            dtpStartDate.CustomFormat = "MMMM dd, yyyy";

            // Controls - DateTimePicker
            dtpEndDate.FillColor = Global.themeColor1;
            dtpEndDate.BorderColor = Global.themeColor1;
            dtpEndDate.CustomFormat = "MMMM dd, yyyy";

            // Controls - Checkbox
            chkAllDate.CheckedState.BorderColor = Global.themeColor1;
            chkAllDate.CheckedState.FillColor = Global.themeColor1;

            // Controls - Filter - ComboBox
            cboCategoryName.BorderColor = Global.themeColor1;
            cboCategoryName.FocusedState.BorderColor = Global.themeColor2;
            cboCategoryName.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - TextBox
            txtCategoryCode.BorderColor = Global.themeColor1;
            txtCategoryCode.FocusedState.BorderColor = Global.themeColor2;
            txtCategoryCode.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboUnitName.BorderColor = Global.themeColor1;
            cboUnitName.FocusedState.BorderColor = Global.themeColor2;
            cboUnitName.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - TextBox
            txtUnitCode.BorderColor = Global.themeColor1;
            txtUnitCode.FocusedState.BorderColor = Global.themeColor2;
            txtUnitCode.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboRegister.BorderColor = Global.themeColor1;
            cboRegister.FocusedState.BorderColor = Global.themeColor2;
            cboRegister.HoverState.BorderColor = Global.themeColor2;
            #endregion

        }

        private void ucVoucher_Transactions_Logs_Load(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            transitionFilterBox.Show(panelFilter);
            panelFilter.BringToFront();
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            transitionFilterBox.Hide(panelFilter);

            // Your codes here to filter your records
        }

        private void btnHideFilter_Click(object sender, EventArgs e)
        {
            transitionFilterBox.Hide(panelFilter);
        }
    }
}
