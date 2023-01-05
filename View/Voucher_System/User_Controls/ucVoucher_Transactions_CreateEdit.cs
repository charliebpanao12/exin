using EXIN.Controller;
using System;
using System.Windows.Forms;

namespace EXIN.Voucher_System
{
    public partial class ucVoucher_Transactions_CreateEdit : UserControl
    {
        public ucVoucher_Transactions_CreateEdit()
        {
            InitializeComponent();

            // Panel with Datagrid
            panelTransactions.CustomBorderColor = Global.themeColor1;
            panelMain.BorderColor = Global.themeColor1;

            // Controls - Button - Data Tab
            btnDataTab.FillColor = Global.themeColor2;
            btnDataTab.HoverState.FillColor = Global.themeColor2;
            btnDataTab.HoverState.ForeColor = Global.themeForeColor;

            // Controls - Button - Entry Tab
            btnEntryTab.FillColor = Global.themeColor1;
            btnEntryTab.HoverState.FillColor = Global.themeColor2;
            btnEntryTab.HoverState.ForeColor = Global.themeForeColor;

            // Controls - Button - Save
            btnSave.FillColor = Global.themeColor1;
            btnSave.HoverState.FillColor = Global.themeColor2;
            btnSave.HoverState.ForeColor = Global.themeForeColor;

            // Controls - Button - Copy Defaults
            btnCopyDefaults.FillColor = Global.themeColor1;
            btnCopyDefaults.HoverState.FillColor = Global.themeColor2;
            btnCopyDefaults.HoverState.ForeColor = Global.themeForeColor;

            // Controls - Button - Cancel
            btnCancel.FillColor = Global.themeColor1;
            btnCancel.HoverState.FillColor = Global.themeColor2;
            btnCancel.HoverState.ForeColor = Global.themeForeColor;

            #region DataTab
            // Controls - TextBox
            txtVoucherNo.BorderColor = Global.themeColor1;
            txtVoucherNo.FocusedState.BorderColor = Global.themeColor2;
            txtVoucherNo.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboPayeeName.BorderColor = Global.themeColor1;
            cboPayeeName.FocusedState.BorderColor = Global.themeColor2;
            cboPayeeName.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtPayeeCode.BorderColor = Global.themeColor1;
            txtPayeeCode.FocusedState.BorderColor = Global.themeColor2;
            txtPayeeCode.HoverState.BorderColor = Global.themeColor2;

            // Controls - DateTimePicker
            dtpDatePrepared.FillColor = Global.themeColor1;
            dtpDatePrepared.BorderColor = Global.themeColor1;
            dtpDatePrepared.CustomFormat = "MMMM dd, yyyy";

            // Controls - DateTimePicker
            dtpRefDate.FillColor = Global.themeColor1;
            dtpRefDate.BorderColor = Global.themeColor1;
            dtpRefDate.CustomFormat = "MMMM dd, yyyy";

            // Controls - DateTimePicker
            dtpDueDate.FillColor = Global.themeColor1;
            dtpDueDate.BorderColor = Global.themeColor1;
            dtpDueDate.CustomFormat = "MMMM dd, yyyy";

            // Controls - TextBox
            txtRefNoFrom.BorderColor = Global.themeColor1;
            txtRefNoFrom.FocusedState.BorderColor = Global.themeColor2;
            txtRefNoFrom.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtRefNoTo.BorderColor = Global.themeColor1;
            txtRefNoTo.FocusedState.BorderColor = Global.themeColor2;
            txtRefNoTo.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtPONo.BorderColor = Global.themeColor1;
            txtPONo.FocusedState.BorderColor = Global.themeColor2;
            txtPONo.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtInvoiceNo.BorderColor = Global.themeColor1;
            txtInvoiceNo.FocusedState.BorderColor = Global.themeColor2;
            txtInvoiceNo.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtLiquidationNo.BorderColor = Global.themeColor1;
            txtLiquidationNo.FocusedState.BorderColor = Global.themeColor2;
            txtLiquidationNo.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboProjectName.BorderColor = Global.themeColor1;
            cboProjectName.FocusedState.BorderColor = Global.themeColor2;
            cboProjectName.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtProjectCode.BorderColor = Global.themeColor1;
            txtProjectCode.FocusedState.BorderColor = Global.themeColor2;
            txtProjectCode.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboCostCenterName.BorderColor = Global.themeColor1;
            cboCostCenterName.FocusedState.BorderColor = Global.themeColor2;
            cboCostCenterName.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtCostCenterCode.BorderColor = Global.themeColor1;
            txtCostCenterCode.FocusedState.BorderColor = Global.themeColor2;
            txtCostCenterCode.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboAccountClassName.BorderColor = Global.themeColor1;
            cboAccountClassName.FocusedState.BorderColor = Global.themeColor2;
            cboAccountClassName.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtAccountClassCode.BorderColor = Global.themeColor1;
            txtAccountClassCode.FocusedState.BorderColor = Global.themeColor2;
            txtAccountClassCode.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtPreparedBy.BorderColor = Global.themeColor1;
            txtPreparedBy.FocusedState.BorderColor = Global.themeColor2;
            txtPreparedBy.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboCheckedBy.BorderColor = Global.themeColor1;
            cboCheckedBy.FocusedState.BorderColor = Global.themeColor2;
            cboCheckedBy.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboVerifiedBy.BorderColor = Global.themeColor1;
            cboVerifiedBy.FocusedState.BorderColor = Global.themeColor2;
            cboVerifiedBy.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboApprovedBy.BorderColor = Global.themeColor1;
            cboApprovedBy.FocusedState.BorderColor = Global.themeColor2;
            cboApprovedBy.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboIssuedCheckBy.BorderColor = Global.themeColor1;
            cboIssuedCheckBy.FocusedState.BorderColor = Global.themeColor2;
            cboIssuedCheckBy.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboClearing.BorderColor = Global.themeColor1;
            cboClearing.FocusedState.BorderColor = Global.themeColor2;
            cboClearing.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboReleasing.BorderColor = Global.themeColor1;
            cboReleasing.FocusedState.BorderColor = Global.themeColor2;
            cboReleasing.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboTemplateName.BorderColor = Global.themeColor1;
            cboTemplateName.FocusedState.BorderColor = Global.themeColor2;
            cboTemplateName.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtAmountInNos.BorderColor = Global.themeColor1;
            txtAmountInNos.FocusedState.BorderColor = Global.themeColor2;
            txtAmountInNos.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtParticulars.BorderColor = Global.themeColor1;
            txtParticulars.FocusedState.BorderColor = Global.themeColor2;
            txtParticulars.HoverState.BorderColor = Global.themeColor2;

            #endregion

        }

        private void ucVoucher_Transactions_CreateEdit_Load(object sender, EventArgs e)
        {

        }

        private void btnDataTab_Click(object sender, EventArgs e)
        {
            btnDataTab.FillColor = Global.themeColor2;
            btnEntryTab.FillColor = Global.themeColor1;
        }

        private void btnEntryTab_Click(object sender, EventArgs e)
        {
            btnDataTab.FillColor = Global.themeColor1;
            btnEntryTab.FillColor = Global.themeColor2;
        }
    }
}
