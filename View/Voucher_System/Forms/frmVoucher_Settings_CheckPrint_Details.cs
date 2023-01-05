using EXIN.Controller;
using System;
using System.Windows.Forms;

namespace EXIN.Voucher_System
{
    public partial class frmVoucher_Settings_CheckPrint_Details : Form
    {
        public frmVoucher_Settings_CheckPrint_Details()
        {
            InitializeComponent();

            // Panel Title
            guna2PanelTitle.CustomBorderColor = Global.themeColor2;

            // Controls - Button 3
            btnSave.FillColor = Global.themeColor1;
            btnSave.FillColor2 = Global.themeColor2;

            // Controls - Button 3
            btnClose.FillColor = Global.themeColor1;
            btnClose.FillColor2 = Global.themeColor2;

            #region TemplateName
            // Panel Title
            grpTemplate.CustomBorderColor = Global.themeColor1;

            // Controls - ComboBox
            cboTemplateName.BorderColor = Global.themeColor1;
            cboTemplateName.FocusedState.BorderColor = Global.themeColor2;
            cboTemplateName.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboType.BorderColor = Global.themeColor1;
            cboType.FocusedState.BorderColor = Global.themeColor2;
            cboType.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboUsersName.BorderColor = Global.themeColor1;
            cboUsersName.FocusedState.BorderColor = Global.themeColor2;
            cboUsersName.HoverState.BorderColor = Global.themeColor2;

            // Controls - TextBox
            txtID.BorderColor = Global.themeColor1;
            txtID.FocusedState.BorderColor = Global.themeColor2;
            txtID.HoverState.BorderColor = Global.themeColor2;
            #endregion

            #region PayeeName
            // Panel Title
            grpPayeeName.CustomBorderColor = Global.themeColor1;

            // Controls - ComboBox
            cboPayeeName_FontStyle.BorderColor = Global.themeColor1;
            cboPayeeName_FontStyle.FocusedState.BorderColor = Global.themeColor2;
            cboPayeeName_FontStyle.HoverState.BorderColor = Global.themeColor2;

            // Controls - Numeric Text Box
            numPayeeName_Top.BorderColor = Global.themeColor1;
            numPayeeName_Top.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numPayeeName_Left.BorderColor = Global.themeColor1;
            numPayeeName_Left.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numPayeeName_Height.BorderColor = Global.themeColor1;
            numPayeeName_Height.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numPayeeName_Width.BorderColor = Global.themeColor1;
            numPayeeName_Width.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numPayeeName_FontSize.BorderColor = Global.themeColor1;
            numPayeeName_FontSize.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeName_Bold.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeName_Bold.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeName_Italic.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeName_Italic.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeName_Underline.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeName_Underline.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeName_UCase.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeName_UCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeName_LCase.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeName_LCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeName_PCase.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeName_PCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeName_Asterisk.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeName_Asterisk.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeName_CanGrow.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeName_CanGrow.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeName_Visible.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeName_Visible.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeName_Center.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeName_Center.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeName_Left.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeName_Left.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeName_Right.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeName_Right.CheckedState.FillColor = Global.themeColor1;

            // Controls - Label
            lblPayeeName.ForeColor = Global.themeColor1;
            lblPayeeName.ForeColor = Global.themeColor1;
            #endregion

            #region AmtWords
            // Panel Title
            grpAmtWords.CustomBorderColor = Global.themeColor1;

            // Controls - ComboBox
            cboAmtWords_FontStyle.BorderColor = Global.themeColor1;
            cboAmtWords_FontStyle.FocusedState.BorderColor = Global.themeColor2;
            cboAmtWords_FontStyle.HoverState.BorderColor = Global.themeColor2;

            // Controls - Numeric Text Box
            numAmtWords_Top.BorderColor = Global.themeColor1;
            numAmtWords_Top.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numAmtWords_Left.BorderColor = Global.themeColor1;
            numAmtWords_Left.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numAmtWords_Height.BorderColor = Global.themeColor1;
            numAmtWords_Height.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numAmtWords_Width.BorderColor = Global.themeColor1;
            numAmtWords_Width.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numAmtWords_FontSize.BorderColor = Global.themeColor1;
            numAmtWords_FontSize.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtWords_Bold.CheckedState.BorderColor = Global.themeColor1;
            chkAmtWords_Bold.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtWords_Italic.CheckedState.BorderColor = Global.themeColor1;
            chkAmtWords_Italic.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtWords_Underline.CheckedState.BorderColor = Global.themeColor1;
            chkAmtWords_Underline.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtWords_UCase.CheckedState.BorderColor = Global.themeColor1;
            chkAmtWords_UCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtWords_LCase.CheckedState.BorderColor = Global.themeColor1;
            chkAmtWords_LCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtWords_PCase.CheckedState.BorderColor = Global.themeColor1;
            chkAmtWords_PCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtWords_Asterisk.CheckedState.BorderColor = Global.themeColor1;
            chkAmtWords_Asterisk.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtWords_CanGrow.CheckedState.BorderColor = Global.themeColor1;
            chkAmtWords_CanGrow.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtWords_Visible.CheckedState.BorderColor = Global.themeColor1;
            chkAmtWords_Visible.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtWords_Center.CheckedState.BorderColor = Global.themeColor1;
            chkAmtWords_Center.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtWords_Left.CheckedState.BorderColor = Global.themeColor1;
            chkAmtWords_Left.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtWords_Right.CheckedState.BorderColor = Global.themeColor1;
            chkAmtWords_Right.CheckedState.FillColor = Global.themeColor1;

            // Controls - Label
            lblAmtWords.ForeColor = Global.themeColor1;
            lblAmtWords.ForeColor = Global.themeColor1;
            #endregion

            #region AmtNum
            // Panel Title
            grpAmtNum.CustomBorderColor = Global.themeColor1;

            // Controls - ComboBox
            cboAmtNum_FontStyle.BorderColor = Global.themeColor1;
            cboAmtNum_FontStyle.FocusedState.BorderColor = Global.themeColor2;
            cboAmtNum_FontStyle.HoverState.BorderColor = Global.themeColor2;

            // Controls - Numeric Text Box
            numAmtNum_Top.BorderColor = Global.themeColor1;
            numAmtNum_Top.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numAmtNum_Left.BorderColor = Global.themeColor1;
            numAmtNum_Left.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numAmtNum_Height.BorderColor = Global.themeColor1;
            numAmtNum_Height.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numAmtNum_Width.BorderColor = Global.themeColor1;
            numAmtNum_Width.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numAmtNum_FontSize.BorderColor = Global.themeColor1;
            numAmtNum_FontSize.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtNum_Bold.CheckedState.BorderColor = Global.themeColor1;
            chkAmtNum_Bold.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtNum_Italic.CheckedState.BorderColor = Global.themeColor1;
            chkAmtNum_Italic.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtNum_Underline.CheckedState.BorderColor = Global.themeColor1;
            chkAmtNum_Underline.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtNum_UCase.CheckedState.BorderColor = Global.themeColor1;
            chkAmtNum_UCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtNum_LCase.CheckedState.BorderColor = Global.themeColor1;
            chkAmtNum_LCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtNum_PCase.CheckedState.BorderColor = Global.themeColor1;
            chkAmtNum_PCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtNum_Asterisk.CheckedState.BorderColor = Global.themeColor1;
            chkAmtNum_Asterisk.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtNum_CanGrow.CheckedState.BorderColor = Global.themeColor1;
            chkAmtNum_CanGrow.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtNum_Visible.CheckedState.BorderColor = Global.themeColor1;
            chkAmtNum_Visible.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtNum_Center.CheckedState.BorderColor = Global.themeColor1;
            chkAmtNum_Center.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtNum_Left.CheckedState.BorderColor = Global.themeColor1;
            chkAmtNum_Left.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkAmtNum_Right.CheckedState.BorderColor = Global.themeColor1;
            chkAmtNum_Right.CheckedState.FillColor = Global.themeColor1;

            // Controls - Label
            lblAmtNum.ForeColor = Global.themeColor1;
            lblAmtNum.ForeColor = Global.themeColor1;
            #endregion

            #region PayeeAcct
            // Panel Title
            grpPayeeAcct.CustomBorderColor = Global.themeColor1;

            // Controls - ComboBox
            cboPayeeAcct_FontStyle.BorderColor = Global.themeColor1;
            cboPayeeAcct_FontStyle.FocusedState.BorderColor = Global.themeColor2;
            cboPayeeAcct_FontStyle.HoverState.BorderColor = Global.themeColor2;

            // Controls - Numeric Text Box
            numPayeeAcct_Top.BorderColor = Global.themeColor1;
            numPayeeAcct_Top.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numPayeeAcct_Left.BorderColor = Global.themeColor1;
            numPayeeAcct_Left.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numPayeeAcct_Height.BorderColor = Global.themeColor1;
            numPayeeAcct_Height.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numPayeeAcct_Width.BorderColor = Global.themeColor1;
            numPayeeAcct_Width.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numPayeeAcct_FontSize.BorderColor = Global.themeColor1;
            numPayeeAcct_FontSize.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeAcct_Bold.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeAcct_Bold.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeAcct_Italic.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeAcct_Italic.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeAcct_Underline.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeAcct_Underline.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeAcct_UCase.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeAcct_UCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeAcct_LCase.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeAcct_LCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeAcct_PCase.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeAcct_PCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeAcct_Asterisk.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeAcct_Asterisk.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeAcct_CanGrow.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeAcct_CanGrow.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeAcct_Visible.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeAcct_Visible.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeAcct_Center.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeAcct_Center.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeAcct_Left.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeAcct_Left.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkPayeeAcct_Right.CheckedState.BorderColor = Global.themeColor1;
            chkPayeeAcct_Right.CheckedState.FillColor = Global.themeColor1;

            // Controls - Label
            lblPayeeAcct.ForeColor = Global.themeColor1;
            lblPayeeAcct.ForeColor = Global.themeColor1;
            #endregion

            #region CVNum
            // Panel Title
            grpCVNum.CustomBorderColor = Global.themeColor1;

            // Controls - ComboBox
            cboCVNum_FontStyle.BorderColor = Global.themeColor1;
            cboCVNum_FontStyle.FocusedState.BorderColor = Global.themeColor2;
            cboCVNum_FontStyle.HoverState.BorderColor = Global.themeColor2;

            // Controls - Numeric Text Box
            numCVNum_Top.BorderColor = Global.themeColor1;
            numCVNum_Top.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numCVNum_Left.BorderColor = Global.themeColor1;
            numCVNum_Left.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numCVNum_Height.BorderColor = Global.themeColor1;
            numCVNum_Height.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numCVNum_Width.BorderColor = Global.themeColor1;
            numCVNum_Width.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numCVNum_FontSize.BorderColor = Global.themeColor1;
            numCVNum_FontSize.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Checkbox
            chkCVNum_Bold.CheckedState.BorderColor = Global.themeColor1;
            chkCVNum_Bold.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkCVNum_Italic.CheckedState.BorderColor = Global.themeColor1;
            chkCVNum_Italic.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkCVNum_Underline.CheckedState.BorderColor = Global.themeColor1;
            chkCVNum_Underline.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkCVNum_UCase.CheckedState.BorderColor = Global.themeColor1;
            chkCVNum_UCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkCVNum_LCase.CheckedState.BorderColor = Global.themeColor1;
            chkCVNum_LCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkCVNum_PCase.CheckedState.BorderColor = Global.themeColor1;
            chkCVNum_PCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkCVNum_Asterisk.CheckedState.BorderColor = Global.themeColor1;
            chkCVNum_Asterisk.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkCVNum_CanGrow.CheckedState.BorderColor = Global.themeColor1;
            chkCVNum_CanGrow.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkCVNum_Visible.CheckedState.BorderColor = Global.themeColor1;
            chkCVNum_Visible.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkCVNum_Center.CheckedState.BorderColor = Global.themeColor1;
            chkCVNum_Center.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkCVNum_Left.CheckedState.BorderColor = Global.themeColor1;
            chkCVNum_Left.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkCVNum_Right.CheckedState.BorderColor = Global.themeColor1;
            chkCVNum_Right.CheckedState.FillColor = Global.themeColor1;

            // Controls - Label
            lblCVNum.ForeColor = Global.themeColor1;
            lblCVNum.ForeColor = Global.themeColor1;
            #endregion

            #region Date
            // Panel Title
            grpDate.CustomBorderColor = Global.themeColor1;

            // Controls - ComboBox
            cboDate_FontStyle.BorderColor = Global.themeColor1;
            cboDate_FontStyle.FocusedState.BorderColor = Global.themeColor2;
            cboDate_FontStyle.HoverState.BorderColor = Global.themeColor2;

            // Controls - Numeric Text Box
            numDate_Top.BorderColor = Global.themeColor1;
            numDate_Top.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate_Left.BorderColor = Global.themeColor1;
            numDate_Left.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate_Height.BorderColor = Global.themeColor1;
            numDate_Height.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate_Width.BorderColor = Global.themeColor1;
            numDate_Width.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate_FontSize.BorderColor = Global.themeColor1;
            numDate_FontSize.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate_Bold.CheckedState.BorderColor = Global.themeColor1;
            chkDate_Bold.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate_Italic.CheckedState.BorderColor = Global.themeColor1;
            chkDate_Italic.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate_Underline.CheckedState.BorderColor = Global.themeColor1;
            chkDate_Underline.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate_UCase.CheckedState.BorderColor = Global.themeColor1;
            chkDate_UCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate_LCase.CheckedState.BorderColor = Global.themeColor1;
            chkDate_LCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate_PCase.CheckedState.BorderColor = Global.themeColor1;
            chkDate_PCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate_Asterisk.CheckedState.BorderColor = Global.themeColor1;
            chkDate_Asterisk.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate_CanGrow.CheckedState.BorderColor = Global.themeColor1;
            chkDate_CanGrow.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate_Visible.CheckedState.BorderColor = Global.themeColor1;
            chkDate_Visible.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate_Center.CheckedState.BorderColor = Global.themeColor1;
            chkDate_Center.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate_Left.CheckedState.BorderColor = Global.themeColor1;
            chkDate_Left.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate_Right.CheckedState.BorderColor = Global.themeColor1;
            chkDate_Right.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate_ShortFmt.CheckedState.BorderColor = Global.themeColor1;
            chkDate_ShortFmt.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate_LongFmt.CheckedState.BorderColor = Global.themeColor1;
            chkDate_LongFmt.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate_NoFmt.CheckedState.BorderColor = Global.themeColor1;
            chkDate_NoFmt.CheckedState.FillColor = Global.themeColor1;

            // Controls - Label
            lblDate.ForeColor = Global.themeColor1;
            lblDate.ForeColor = Global.themeColor1;
            #endregion

            #region Date2
            // Panel Title
            grpDate2.CustomBorderColor = Global.themeColor1;

            // Controls - ComboBox
            cboDate2_FontStyle.BorderColor = Global.themeColor1;
            cboDate2_FontStyle.FocusedState.BorderColor = Global.themeColor2;
            cboDate2_FontStyle.HoverState.BorderColor = Global.themeColor2;

            // Controls - Numeric Text Box
            numDate2_FontSize.BorderColor = Global.themeColor1;
            numDate2_FontSize.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2M1_Top.BorderColor = Global.themeColor1;
            numDate2M1_Top.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2M1_Left.BorderColor = Global.themeColor1;
            numDate2M1_Left.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2M1_Height.BorderColor = Global.themeColor1;
            numDate2M1_Height.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2M1_Width.BorderColor = Global.themeColor1;
            numDate2M1_Width.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2M1_Top.BorderColor = Global.themeColor1;
            numDate2M1_Top.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2M1_Left.BorderColor = Global.themeColor1;
            numDate2M1_Left.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2M1_Height.BorderColor = Global.themeColor1;
            numDate2M1_Height.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2M1_Width.BorderColor = Global.themeColor1;
            numDate2M1_Width.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2M2_Top.BorderColor = Global.themeColor1;
            numDate2M2_Top.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2M2_Left.BorderColor = Global.themeColor1;
            numDate2M2_Left.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2M2_Height.BorderColor = Global.themeColor1;
            numDate2M2_Height.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2M2_Width.BorderColor = Global.themeColor1;
            numDate2M2_Width.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2D1_Top.BorderColor = Global.themeColor1;
            numDate2D1_Top.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2D1_Left.BorderColor = Global.themeColor1;
            numDate2D1_Left.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2D1_Height.BorderColor = Global.themeColor1;
            numDate2D1_Height.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2D1_Width.BorderColor = Global.themeColor1;
            numDate2D1_Width.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2D2_Top.BorderColor = Global.themeColor1;
            numDate2D2_Top.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2D2_Left.BorderColor = Global.themeColor1;
            numDate2D2_Left.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2D2_Height.BorderColor = Global.themeColor1;
            numDate2D2_Height.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2D2_Width.BorderColor = Global.themeColor1;
            numDate2D2_Width.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2Y1_Top.BorderColor = Global.themeColor1;
            numDate2Y1_Top.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2Y1_Left.BorderColor = Global.themeColor1;
            numDate2Y1_Left.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2Y1_Height.BorderColor = Global.themeColor1;
            numDate2Y1_Height.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2Y1_Width.BorderColor = Global.themeColor1;
            numDate2Y1_Width.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2Y2_Top.BorderColor = Global.themeColor1;
            numDate2Y2_Top.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2Y2_Left.BorderColor = Global.themeColor1;
            numDate2Y2_Left.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2Y2_Height.BorderColor = Global.themeColor1;
            numDate2Y2_Height.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2Y2_Width.BorderColor = Global.themeColor1;
            numDate2Y2_Width.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2Y3_Top.BorderColor = Global.themeColor1;
            numDate2Y3_Top.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2Y3_Left.BorderColor = Global.themeColor1;
            numDate2Y3_Left.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2Y3_Height.BorderColor = Global.themeColor1;
            numDate2Y3_Height.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2Y3_Width.BorderColor = Global.themeColor1;
            numDate2Y3_Width.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2Y4_Top.BorderColor = Global.themeColor1;
            numDate2Y4_Top.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2Y4_Left.BorderColor = Global.themeColor1;
            numDate2Y4_Left.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2Y4_Height.BorderColor = Global.themeColor1;
            numDate2Y4_Height.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Numeric Text Box
            numDate2Y4_Width.BorderColor = Global.themeColor1;
            numDate2Y4_Width.UpDownButtonFillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate2_Bold.CheckedState.BorderColor = Global.themeColor1;
            chkDate2_Bold.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate2_Italic.CheckedState.BorderColor = Global.themeColor1;
            chkDate2_Italic.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate2_Underline.CheckedState.BorderColor = Global.themeColor1;
            chkDate2_Underline.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate2_UCase.CheckedState.BorderColor = Global.themeColor1;
            chkDate2_UCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate2_LCase.CheckedState.BorderColor = Global.themeColor1;
            chkDate2_LCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate2_PCase.CheckedState.BorderColor = Global.themeColor1;
            chkDate2_PCase.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate2_Asterisk.CheckedState.BorderColor = Global.themeColor1;
            chkDate2_Asterisk.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate2_CanGrow.CheckedState.BorderColor = Global.themeColor1;
            chkDate2_CanGrow.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate2_Visible.CheckedState.BorderColor = Global.themeColor1;
            chkDate2_Visible.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate2_Center.CheckedState.BorderColor = Global.themeColor1;
            chkDate2_Center.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate2_Left.CheckedState.BorderColor = Global.themeColor1;
            chkDate2_Left.CheckedState.FillColor = Global.themeColor1;

            // Controls - Checkbox
            chkDate2_Right.CheckedState.BorderColor = Global.themeColor1;
            chkDate2_Right.CheckedState.FillColor = Global.themeColor1;

            // Controls - Label
            lblDate2.ForeColor = Global.themeColor1;
            lblDate2.ForeColor = Global.themeColor1;
            #endregion

        }

        private void frmVoucher_Settings_CheckPrint_Details_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
