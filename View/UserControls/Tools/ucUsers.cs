using EXIN.Controller;
using System;
using System.Windows.Forms;

namespace EXIN.Tools
{
    public partial class UCUsers : UserControl
    {

        public UCUsers()
        {
            InitializeComponent();

            grpUserAccess.CustomBorderColor = Global.themeColor1;
            txtUserId.FillColor = Global.themeColor1;
            btnSubmit.FillColor = Global.themeColor1;
            btnCancel.FillColor = Global.themeColor1;
            txtUserId.FillColor = Global.themeColor1;
            guna2Panel1.CustomBorderColor = Global.themeColor1;
            txtEmployeeId.BorderColor = Global.themeColor1;
            txtEmployeeId.FocusedState.BorderColor = Global.themeColor2;
            txtEmployeeId.HoverState.BorderColor = Global.themeColor2;

            txtFirstName.BorderColor = Global.themeColor1;
            txtFirstName.FocusedState.BorderColor = Global.themeColor2;
            txtFirstName.HoverState.BorderColor = Global.themeColor2;

            btnBatchDelete.Hide();
            btnCancel.Hide();

            readUsers();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {


        }

        private void readUsers()
        {

        }

        //Settings for Scrollbars
        private void dgvAdminDashboard_MouseLeave(object sender, EventArgs e)
        {
            dgvAdminDashboard.ScrollBars = ScrollBars.None;
        }

        private void dgvAdminDashboard_MouseHover(object sender, EventArgs e)
        {
            dgvAdminDashboard.ScrollBars = ScrollBars.Both;
        }

        private void dgvAdminDashboard_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvAdminDashboard.ScrollBars = ScrollBars.Both;
        }

        private void dgvAdminDashboard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                String userID;
                userID = dgvAdminDashboard.Rows[e.RowIndex].Cells[5].Value.ToString();
                //MessageBox.Show(userID);
                // Your codes here
                //frmLogIn frmLogIn = new frmLogIn();
                //frmLogIn.Show();
            }
        }

        private void btnBatchDelete_Click(object sender, EventArgs e)
        {

        }

        private void UCUsers_Load(object sender, EventArgs e)
        {

        }
    }
}
