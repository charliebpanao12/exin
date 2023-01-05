using EXIN.Controller;
using System;
using System.Windows.Forms;

namespace EXIN.Voucher_System
{
    public partial class ucVoucher_Settings_CheckPrint : UserControl
    {
        public ucVoucher_Settings_CheckPrint()
        {
            InitializeComponent();

            //Panel Resize Progress bar
            panelProgressBar.Width = 233;
            panelProgressBar.Height = 63;

            //Panel Resize Recordcount
            panelRecordCount.Width = 122;
            panelRecordCount.Height = 63;

            // Panel with Datagrid
            panelCheckPrintSetup.CustomBorderColor = Global.themeColor1;

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

            // Controls - Filter - ComboBox
            cboName.BorderColor = Global.themeColor1;
            cboName.FocusedState.BorderColor = Global.themeColor2;
            cboName.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboTemplateName.BorderColor = Global.themeColor1;
            cboTemplateName.FocusedState.BorderColor = Global.themeColor2;
            cboTemplateName.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboTemplateType.BorderColor = Global.themeColor1;
            cboTemplateType.FocusedState.BorderColor = Global.themeColor2;
            cboTemplateType.HoverState.BorderColor = Global.themeColor2;
            #endregion
        }

        private void btnHideFilter_Click(object sender, EventArgs e)
        {
            transitionFilterBox.Hide(panelFilter);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmVoucher_Settings_CheckPrint_Details myNewForm = new frmVoucher_Settings_CheckPrint_Details();
            myNewForm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmVoucher_Settings_CheckPrint_Details myNewForm = new frmVoucher_Settings_CheckPrint_Details();
            myNewForm.ShowDialog();
        }

        private void ucVoucher_Settings_CheckPrint_Load(object sender, EventArgs e)
        {

        }
    }
}
