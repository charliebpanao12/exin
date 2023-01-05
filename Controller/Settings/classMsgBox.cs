namespace EXIN.Controller
{
    class classMsgBox
    {
        public void showMsgConfirmation(string message)
        {
            frmTransparentForm form = new frmTransparentForm();
            form.Opacity = 0.5D;
            form.Show();
            form.SendToBack();

            frmMsgBox_Confirmation frmMsgBox_Confirmation = new frmMsgBox_Confirmation();
            frmMsgBox_Confirmation.lblMessage.Text = "" + message;
            frmMsgBox_Confirmation.ShowDialog();
        }

        public void showMsgConfirmation_Delete(string message)
        {
            frmTransparentForm form = new frmTransparentForm();
            form.Opacity = 0.5D;
            form.Show();
            form.SendToBack();

            frmMsgBox_Confirmation_Delete frmMsgBox_Confirmation_Delete = new frmMsgBox_Confirmation_Delete();
            frmMsgBox_Confirmation_Delete.lblMessage.Text = "" + message;
            frmMsgBox_Confirmation_Delete.ShowDialog();
        }

        public void showMsgError(string message)
        {
            frmTransparentForm form = new frmTransparentForm();
            form.Opacity = 0.5D;
            form.Show();
            form.SendToBack();

            frmMsgBox_Error frmMsgBox_Error = new frmMsgBox_Error();
            frmMsgBox_Error.lblMessage.Text = "" + message;
            frmMsgBox_Error.ShowDialog();
        }

        public void showMsgInformation(string message)
        {
            frmTransparentForm form = new frmTransparentForm();
            form.Opacity = 0.5D;
            form.Show();
            form.SendToBack();

            frmMsgBox_Information frmMsgBox_Information = new frmMsgBox_Information();
            frmMsgBox_Information.lblMessage.Text = "" + message;
            frmMsgBox_Information.ShowDialog();
        }

        public void showMsgLogout(string message)
        {
            frmTransparentForm form = new frmTransparentForm();
            form.Opacity = 0.5D;
            form.Show();
            form.SendToBack();

            frmMsgBox_LogOut frmMsgBox_LogOut = new frmMsgBox_LogOut();
            frmMsgBox_LogOut.lblMessage.Text = "" + message;
            frmMsgBox_LogOut.ShowDialog();
        }

        public void showMsgSuccessful(string message)
        {
            frmTransparentForm form = new frmTransparentForm();
            form.Opacity = 0.5D;
            form.Show();
            form.SendToBack();

            frmMsgBox_Successful frmMsgBox_Successful = new frmMsgBox_Successful();
            frmMsgBox_Successful.lblMessage.Text = "" + message;
            frmMsgBox_Successful.ShowDialog();
        }
    }
}
