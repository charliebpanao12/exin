using System;
using System.Windows.Forms;

namespace EXIN
{
    public partial class frmUserLogin : Form
    {

        public frmUserLogin()
        {
            InitializeComponent();
        }

        private void frmUserLogin_Load(object sender, EventArgs e)
        {
            //***** Main Code
            zeroitSmoothAnimator1.Start();
            guna2ShadowForm1.SetShadowForm(this);
            CheckforUpdates();
        }

        MySqlConnect ConnAll = new MySqlConnect();

        private async void CheckforUpdates()
        {
            //Check for update through Squirrel

            //var pathToUpdateFolder = @"https://kncgroupreports.com";
            //using (var updateManager = new UpdateManager(pathToUpdateFolder))
            //{

            //    CurrentVersion.Text = $"Current version: {updateManager.CurrentlyInstalledVersion()}";
            //    var releaseEntry = await updateManager.UpdateApp();
            //    NewVersion.Text = $"Update Version: {releaseEntry?.Version.ToString() ?? "No update"}";
            //}


            //if (NewVersion.Text == "Update Version: No update")
            //{
            //    return;
            //}
            //else
            //{
            //    MessageBox.Show("App successfully updated, Restart EXIN", "Update Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    System.Windows.Forms.Application.Exit();
            //}
        }
        private void SystemExpiry()
        {
            //var lastmonth = DateTime.Today.AddMonths(-1);
            //MessageBox.Show(lastmonth.ToString());



            ConnAll.mysqlQuery = "SELECT * FROM `tbl_val`";

            ConnAll.mySystemExpiry();

            DateTime expiry = Convert.ToDateTime(ConnAll.endDate);

            var today = DateTime.Now;

            DateTime thirtyDaysBefore = expiry.AddDays(-30);

            if (today > thirtyDaysBefore && today < expiry)
            {
                MessageBox.Show("You still have 30 days before system registration, please call EXINNOV");
            }

            if (today > expiry)
            {
                MessageBox.Show("Systems Registration needs updating, please call EXINNOV");
                System.Windows.Forms.Application.Exit();
            }
        }


        private void btnLog_Click(object sender, EventArgs e)
        {

            SystemExpiry();

            // Check user
            ConnAll.mysqlQuery = "SELECT * FROM `tbl_users` WHERE `User_Name` = @userName";
            ConnAll.myUserValue = txtUser.Text;

            ConnAll.myUserLogin();

            //Check password
            ConnAll.mysqlQuery = "SELECT * FROM `tbl_users` WHERE `User_Name` = @userName";


            ConnAll.myPassValue = txtPassword.Text;
            ConnAll.myUserValue = txtUser.Text;

            ConnAll.myPassLogin();
            txtUser.Text = null;
            txtPassword.Text = null;

            if (ConnAll.myLoginStatus)
            {
                this.Hide();
            }
            else
            {
                return;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                SystemExpiry();

                // Check user
                ConnAll.mysqlQuery = "SELECT * FROM `tbl_users` WHERE `User_Name` = @userName";
                ConnAll.myUserValue = txtUser.Text;

                ConnAll.myUserLogin();

                //Check password
                ConnAll.mysqlQuery = "SELECT * FROM `tbl_users` WHERE  `User_Name` = @userName";

                ConnAll.myPassValue = txtPassword.Text;
                ConnAll.myUserValue = txtUser.Text;

                ConnAll.myPassLogin();
                txtUser.Text = null;
                txtPassword.Text = null;

                if (ConnAll.myLoginStatus)
                {
                    this.Hide();
                }
                else
                {
                    return;
                }

            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }
    }
}

