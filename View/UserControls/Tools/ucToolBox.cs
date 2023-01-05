using EXIN.Controller;
using System;
using System.Windows.Forms;

namespace EXIN.Tools
{
    public partial class ucToolBox : UserControl
    {
        public ucToolBox()
        {
            InitializeComponent();

            // Controls - Label 1
            lblWindowTitle.ForeColor = Global.themeColor1;

            // Controls - Group
            grpUserAccess.ForeColor = Global.themeColor1;

            // Controls - Textbox 1
            txtInfo1.FillColor = Global.themeColor1;
            txtInfo1.BorderColor = Global.themeColor1;
            txtInfo1.FocusedState.BorderColor = Global.themeColor2;
            txtInfo1.ForeColor = Global.themeForeColor;

            // Controls - Textbox 2
            txtInfo2.BorderColor = Global.themeColor1;
            txtInfo2.FocusedState.BorderColor = Global.themeColor2;
            txtInfo2.HoverState.BorderColor = Global.themeColor2;

            // Controls - Textbox 3
            txtInfo3.BorderColor = Global.themeColor1;
            txtInfo3.FocusedState.BorderColor = Global.themeColor2;
            txtInfo3.HoverState.BorderColor = Global.themeColor2;

            // Controls - Textbox 4
            txtSearchInfo.BorderColor = Global.themeColor1;
            txtSearchInfo.FocusedState.BorderColor = Global.themeColor2;
            txtSearchInfo.HoverState.BorderColor = Global.themeColor2;

            // Controls - Combobox
            cboOptions.BorderColor = Global.themeColor1;
            cboOptions.FocusedState.BorderColor = Global.themeColor2;
            cboOptions.HoverState.BorderColor = Global.themeColor2;

            // Controls - Checkbox
            chkOption1.CheckedState.BorderColor = Global.themeColor1;
            chkOption1.CheckedState.FillColor = Global.themeColor1;

            // Controls - Radio Button
            rdoOption2.CheckedState.BorderColor = Global.themeColor1;
            rdoOption2.CheckedState.FillColor = Global.themeColor1;

            // Controls - Button 1
            btnCommand1.FillColor = Global.themeColor1;
            btnCommand1.HoverState.FillColor = Global.themeColor2;
            btnCommand1.HoverState.ForeColor = Global.themeForeColor;

            // Controls - Button 2
            btnCommand2.FillColor = Global.themeColor1;
            btnCommand2.FillColor2 = Global.themeColor2;

            // Controls - Button 3
            btnCommand3.FillColor = Global.themeColor1;
            btnCommand3.FillColor2 = Global.themeColor2;

            // Panel with Datagrid
            panelRecords.CustomBorderColor = Global.themeColor1;

            // Controls - txtSearch
            txtSearch.BorderColor = Global.themeColor1;
            txtSearch.FocusedState.BorderColor = Global.themeColor2;
            txtSearch.HoverState.BorderColor = Global.themeColor2;

            // Controls - Checkbox
            //chkCheckAll.CheckedState.BorderColor = Global.themeColor1;
            //chkCheckAll.CheckedState.FillColor = Global.themeColor1;

            // Controls - DateTimePicker
            dtpDateTimePicker.FillColor = Global.themeColor1;
            dtpDateTimePicker.BorderColor = Global.themeColor1;
            dtpDateTimePicker.CustomFormat = "MMMM dd, yyyy";

            // Controls - Numeric Text Box
            numtxtNumericTextBox.BorderColor = Global.themeColor1;
            numtxtNumericTextBox.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Toggle Switch
            toggleToggleSwitch.CheckedState.FillColor = Global.themeColor1;

            // Controls - Chip
            chipSampleChip.BorderColor = Global.themeColor1;
            chipSampleChip.FillColor = Global.themeColor1;

            // Controls - Notification Paint
            btnNotificationPaint.FillColor = Global.themeColor1;
            btnNotificationPaint.HoverState.FillColor = Global.themeColor2;
            btnNotificationPaint.HoverState.ForeColor = Global.themeForeColor;
            notifpaintNotificationPaint.FillColor = Global.themeColor2; // Main code for custom notification paint

            // Controls - Progress Bar 1
            pbarProgressBar1.ProgressColor = Global.themeColor2;

            // Controls - Progress Bar 2
            pbarProgressBar2.ProgressColor = Global.themeColor1;
            pbarProgressBar2.ProgressColor2 = Global.themeColor2;

            // Controls - Tile Button (Menu)
            btnMenu.HoverState.BorderColor = Global.themeColor1;
            btnMenu.HoverState.CustomBorderColor = Global.themeColor1;

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

        private void ucToolBox_Load(object sender, EventArgs e)
        {

        }

        private void btnStartProgressBar_1_Click(object sender, EventArgs e)
        {
            pbarProgressBar1.Value = 0;
            timerProgressBar1.Start();
        }

        private void timerProgressBar1_Tick(object sender, EventArgs e)
        {
            if (pbarProgressBar1.Value == 100)
            {
                timerProgressBar1.Stop();
            }
            else
            {
                pbarProgressBar1.Value += 1;
            }

        }

        private void btnStartProgressBar_2_Click(object sender, EventArgs e)
        {
            pbarProgressBar2.Value = 0;
            timerProgressBar2.Start();
        }

        private void timerProgressBar2_Tick(object sender, EventArgs e)
        {
            if (pbarProgressBar2.Value == 100)
            {
                timerProgressBar2.Stop();
            }
            else
            {
                pbarProgressBar2.Value += 1;
            }

        }

        private void btnNotificationPaint_Click(object sender, EventArgs e)
        {
            new classMsgBox().showMsgSuccessful("Hello World!");
            Application.OpenForms["frmPayroll_ParentContainer"].Activate(); // Bring the parent form to the front
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            transitionFilterBox.Show(panelFilter);
            panelFilter.BringToFront();
        }

        private void btnHideFilter_Click(object sender, EventArgs e)
        {
            transitionFilterBox.Hide(panelFilter);
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            transitionFilterBox.Hide(panelFilter);

            // Your codes here to filter your records

        }
    }
}
