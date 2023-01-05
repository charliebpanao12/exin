using EXIN.Controller;
using System;
using System.Windows.Forms;

namespace EXIN.Voucher_System
{
    public partial class ucVoucher_Transactions_ViewRecords : UserControl
    {
        public ucVoucher_Transactions_ViewRecords()
        {
            InitializeComponent();

            //Panel Resize Progress bar
            panelProgressBar.Width = 233;
            panelProgressBar.Height = 63;

            //Panel Resize Recordcount
            panelRecordCount.Width = 122;
            panelRecordCount.Height = 63;

            // Panel with Datagrid
            panelAccountClass.CustomBorderColor = Global.themeColor1;

            // Controls - Textbox - Search
            txtSearch.BorderColor = Global.themeColor1;
            txtSearch.FocusedState.BorderColor = Global.themeColor2;
            txtSearch.HoverState.BorderColor = Global.themeColor2;

            // Controls - Button - Add
            btnAdd.FillColor = Global.themeColor1;
            btnAdd.HoverState.FillColor = Global.themeColor2;
            btnAdd.HoverState.ForeColor = Global.themeForeColor;

            // Controls - Button - Edit
            btnEdit.FillColor = Global.themeColor1;
            btnEdit.HoverState.FillColor = Global.themeColor2;
            btnEdit.HoverState.ForeColor = Global.themeForeColor;

            // Controls - Button - Delete
            btnDelete.FillColor = Global.themeColor1;
            btnDelete.HoverState.FillColor = Global.themeColor2;
            btnDelete.HoverState.ForeColor = Global.themeForeColor;

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

            // Controls - Filter - TextBox
            txtSearchField.BorderColor = Global.themeColor1;
            txtSearchField.FocusedState.BorderColor = Global.themeColor2;
            txtSearchField.HoverState.BorderColor = Global.themeColor2;

            // Controls - Checkbox
            chkCKV.CheckedState.BorderColor = Global.themeColor1;
            chkCKV.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkJV.CheckedState.BorderColor = Global.themeColor1;
            chkJV.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPCV.CheckedState.BorderColor = Global.themeColor1;
            chkPCV.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkExactMatch.CheckedState.BorderColor = Global.themeColor1;
            chkExactMatch.CheckedState.FillColor = Global.themeColor1;

            // Controls - Filter - ComboBox
            cboSearchField.BorderColor = Global.themeColor1;
            cboSearchField.FocusedState.BorderColor = Global.themeColor2;
            cboSearchField.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - TextBox
            txtSearchField.BorderColor = Global.themeColor1;
            txtSearchField.FocusedState.BorderColor = Global.themeColor2;
            txtSearchField.HoverState.BorderColor = Global.themeColor2;

            // Controls - Checkbox
            chkAllDate.CheckedState.BorderColor = Global.themeColor1;
            chkAllDate.CheckedState.FillColor = Global.themeColor1;

            // Controls - DateTimePicker
            dtpStartDate.FillColor = Global.themeColor1;
            dtpStartDate.BorderColor = Global.themeColor1;
            dtpStartDate.CustomFormat = "MMMM dd, yyyy";

            // Controls - DateTimePicker
            dtpEndDate.FillColor = Global.themeColor1;
            dtpEndDate.BorderColor = Global.themeColor1;
            dtpEndDate.CustomFormat = "MMMM dd, yyyy";

            // Controls - Filter - ComboBox
            cboStatus.BorderColor = Global.themeColor1;
            cboStatus.FocusedState.BorderColor = Global.themeColor2;
            cboStatus.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboClearing.BorderColor = Global.themeColor1;
            cboClearing.FocusedState.BorderColor = Global.themeColor2;
            cboClearing.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboReleasing.BorderColor = Global.themeColor1;
            cboReleasing.FocusedState.BorderColor = Global.themeColor2;
            cboReleasing.HoverState.BorderColor = Global.themeColor2;

            #endregion



        }




        private void ucVoucher_Transactions_ViewRecords_Load(object sender, EventArgs e)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //frmVoucher_List_AccountClass_Details myNewForm = new frmVoucher_List_AccountClass_Details();
            //myNewForm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //frmVoucher_List_AccountClass_Details myNewForm = new frmVoucher_List_AccountClass_Details();
            //myNewForm.ShowDialog();
        }
    }
}
