using EXIN.Controller;
using System;
using System.Windows.Forms;

namespace EXIN.Payroll_System
{
    public partial class ucPayroll_EmployeeList : UserControl
    {
        public ucPayroll_EmployeeList()
        {
            InitializeComponent();

            // Panel with Datagrid
            panelEmployeeList.CustomBorderColor = Global.themeColor1;

            // Controls - Textbox 3
            txtSearch.BorderColor = Global.themeColor1;
            txtSearch.FocusedState.BorderColor = Global.themeColor2;
            txtSearch.HoverState.BorderColor = Global.themeColor2;

            // Controls - Button 1
            btnNewEmployee.FillColor = Global.themeColor1;
            btnNewEmployee.HoverState.FillColor = Global.themeColor2;
            btnNewEmployee.HoverState.ForeColor = Global.themeForeColor;

            // Controls - Button 1
            btnSetupMultipleSchedules.FillColor = Global.themeColor1;
            btnSetupMultipleSchedules.HoverState.FillColor = Global.themeColor2;
            btnSetupMultipleSchedules.HoverState.ForeColor = Global.themeForeColor;

            // Controls - Button 1
            btnViewScheduleList.FillColor = Global.themeColor1;
            btnViewScheduleList.HoverState.FillColor = Global.themeColor2;
            btnViewScheduleList.HoverState.ForeColor = Global.themeForeColor;

            // Controls - Button 1
            btnSyncEmployeeList.FillColor = Global.themeColor1;
            btnSyncEmployeeList.HoverState.FillColor = Global.themeColor2;
            btnSyncEmployeeList.HoverState.ForeColor = Global.themeForeColor;

            // Controls - Button 1
            btnGeneralSearch.FillColor = Global.themeColor1;
            btnGeneralSearch.HoverState.FillColor = Global.themeColor2;
            btnGeneralSearch.HoverState.ForeColor = Global.themeForeColor;

            #region Filter Box
            // Controls - Filter
            panelFilter_Header.FillColor = Global.themeColor2;
            grpFilter.ForeColor = Global.themeColor1;
            btnApplyFilter.FillColor = Global.themeColor1;
            btnApplyFilter.FillColor2 = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboOption01.BorderColor = Global.themeColor1;
            cboOption01.FocusedState.BorderColor = Global.themeColor2;
            cboOption01.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboOption02.BorderColor = Global.themeColor1;
            cboOption02.FocusedState.BorderColor = Global.themeColor2;
            cboOption02.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboOption03.BorderColor = Global.themeColor1;
            cboOption03.FocusedState.BorderColor = Global.themeColor2;
            cboOption03.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboOption04.BorderColor = Global.themeColor1;
            cboOption04.FocusedState.BorderColor = Global.themeColor2;
            cboOption04.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboOption05.BorderColor = Global.themeColor1;
            cboOption05.FocusedState.BorderColor = Global.themeColor2;
            cboOption05.HoverState.BorderColor = Global.themeColor2;
            #endregion

        }

        private void ucPayroll_EmployeeList_Load(object sender, EventArgs e)
        {
            cboOption01.DropDownStyle = ComboBoxStyle.DropDown;
            cboOption01.Text = "Option 02";
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {

        }

        private void btnHideFilter_Click(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            transitionFilterBox.Show(panelFilter);
            panelFilter.BringToFront();
        }

        private void btnHideFilter_Click_1(object sender, EventArgs e)
        {
            transitionFilterBox.Hide(panelFilter);
        }

        private void btnApplyFilter_Click_1(object sender, EventArgs e)
        {
            transitionFilterBox.Hide(panelFilter);

            // Your codes here to filter your records

        }

    }
}
