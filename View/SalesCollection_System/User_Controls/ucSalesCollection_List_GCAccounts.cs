using EXIN.Controller;
using System;
using System.Windows.Forms;

namespace EXIN.SalesCollection_System
{
    public partial class ucSalesCollection_List_GCAccounts : UserControl
    {
        public ucSalesCollection_List_GCAccounts()
        {
            InitializeComponent();

            //Panel Resize Progress bar
            panelProgressBar.Width = 233;
            panelProgressBar.Height = 63;

            //Panel Resize Recordcount
            panelRecordCount.Width = 122;
            panelRecordCount.Height = 63;

            // Panel with Datagrid
            panelGCAccounts.CustomBorderColor = Global.themeColor1;

            // Controls - Textbox - Search
            txtSearch.BorderColor = Global.themeColor1;
            txtSearch.FocusedState.BorderColor = Global.themeColor2;
            txtSearch.HoverState.BorderColor = Global.themeColor2;

            // Controls - Checkbox - Check All
            chkCheckAll.CheckedState.BorderColor = Global.themeColor1;
            chkCheckAll.CheckedState.FillColor = Global.themeColor1;

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
            txtGCCode.BorderColor = Global.themeColor1;
            txtGCCode.FocusedState.BorderColor = Global.themeColor2;
            txtGCCode.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - TextBox
            txtGCName.BorderColor = Global.themeColor1;
            txtGCName.FocusedState.BorderColor = Global.themeColor2;
            txtGCName.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - TextBox
            txtGCValue.BorderColor = Global.themeColor1;
            txtGCValue.FocusedState.BorderColor = Global.themeColor2;
            txtGCValue.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboStatus.BorderColor = Global.themeColor1;
            cboStatus.FocusedState.BorderColor = Global.themeColor2;
            cboStatus.HoverState.BorderColor = Global.themeColor2;
            #endregion
        }

        private void ucSalesCollection_List_GCAccounts_Load(object sender, EventArgs e)
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
            frmSalesCollection_List_GCAccounts_Details myNewForm = new frmSalesCollection_List_GCAccounts_Details();
            myNewForm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmSalesCollection_List_GCAccounts_Details myNewForm = new frmSalesCollection_List_GCAccounts_Details();
            myNewForm.ShowDialog();
        }
    }
}
