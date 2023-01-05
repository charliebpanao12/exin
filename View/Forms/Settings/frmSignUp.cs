using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EXIN
{
    public partial class frmSignUp : Form
    {
        public frmSignUp()
        {
            InitializeComponent();
        }

        string Post;
        string passwordHash;



        private void updateUserReg()
        {
            MySqlConnect MySqlConn = new MySqlConnect();

            MySqlCommand mySqlCmd = new MySqlCommand("SELECT * FROM `rci_user_profile` WHERE `employeeId` = @user", MySqlConn.mySqlconn);

            mySqlCmd.Parameters.AddWithValue("@user", MySqlConn.myAccount);

            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            DataTable mySqlDataTable = new DataTable();
            mySqlAdapter.Fill(mySqlDataTable);

            //LOOP THRU ComboBox
            foreach (DataRow row in mySqlDataTable.Rows)
            {
                lblAccount.Text = row[0].ToString();
                txtUserName.Text = row[1].ToString();
                txtEmail.Text = row[3].ToString();
                txtFirstName.Text = row[4].ToString();
                txtMiddleName.Text = row[5].ToString();
                txtLastName.Text = row[6].ToString();
            }


            //MessageBox.Show("Select the Payee to be updated", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MySqlConn.closeConnection();
        }
        private void frmSignUp_Load(object sender, EventArgs e)
        {
            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);
            Guna.UI.Lib.GraphicsHelper.DrawLineShadow(pnlParent, Color.Black, 20, 10, Guna.UI.WinForms.VerHorAlign.HoriziontalTop);
            pnlGradient.GradientColor1 = Color.FromArgb(150, 40, 223, 153);
            pnlGradient.GradientColor2 = Color.FromArgb(200, 6, 84, 70);

            MySqlConnect Acctg = new MySqlConnect();
            Post = Acctg.updateUserString;
            //MessageBox.Show(Post);
            btnRegister.Text = Post;

            if (Post == "Save")
            {
                lblSignUp.Text = "Update";
                updateUserReg();
            }

            lblAccount.Hide();

        }

        public void PostData()
        {

            if (Post == "Save")
            {

                try
                {
                    if (txtUserName.Text == "" || txtPassword.Text == "" || txtPassConfirm.Text == "" || txtFirstName.Text == "" || txtMiddleName.Text == "" || txtLastName.Text == "" || txtEmail.Text == "")
                    {
                        MessageBox.Show("Do not leave a textbox empty", "Error Prompt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    if (txtPassword.Text != txtPassConfirm.Text)
                    {
                        MessageBox.Show("Password confirmation does not match, please try again", "Incorrect Password ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPassword.Text = "";
                        txtPassConfirm.Text = "";
                        return;
                    }

                    MySqlConnect Acctg = new MySqlConnect();


                    Acctg.mysqlQuery = "UPDATE `rci_user_profile` SET `userName` = @userName, `userPassword` = @userPassword,`userEmail` = @userEmail," +
                       "`userFirstName` = @firstName, `userMiddleName` = @middleName, `userLastName` = @lastName WHERE `employeeId` = @user";

                    passwordHash = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);

                    DialogResult resultInsert = MessageBox.Show("Do you want to save updated information?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (resultInsert == DialogResult.Yes)
                    {
                        Acctg.myUserUpdate(txtUserName.Text, passwordHash, txtEmail.Text, txtFirstName.Text, txtMiddleName.Text, txtLastName.Text);
                    }

                }

                catch (Exception ex)
                {
                    Accounting Acctg = new Accounting();
                    Acctg.Alert(ex.Message, frmAlert.alertTypeEnum.Error);
                    MessageBox.Show(ex.Message);
                    return;
                }

            }
            else
            {
                try
                {
                    if (txtUserName.Text == "" || txtPassword.Text == "" || txtPassConfirm.Text == "" || txtFirstName.Text == "" || txtMiddleName.Text == "" || txtLastName.Text == "" || txtEmail.Text == "")
                    {
                        MessageBox.Show("Do not leave a textbox empty", "Error Prompt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (txtPassword.Text != txtPassConfirm.Text)
                    {
                        MessageBox.Show("Password confirmation does not match, please try again", "Incorrect Password ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPassword.Text = "";
                        txtPassConfirm.Text = "";
                        return;
                    }


                    MySqlConnect Acctg = new MySqlConnect();

                    Acctg.mysqlQuery = "INSERT INTO `rci_user_profile`(`userName`,`userPassword`,`userEmail`,`userFirstName`,`userMiddleName`,`userLastName`,`userStatus`)" +
                    "VALUES(@userName,@userPassword,@userEmail,@firstName,@middleName,@lastName,@userStatus)";

                    passwordHash = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);

                    DialogResult resultInsert = MessageBox.Show("Are all information correct?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (resultInsert == DialogResult.Yes)
                    {
                        Acctg.myUserRegistration(txtUserName.Text, passwordHash, txtEmail.Text, txtFirstName.Text, txtMiddleName.Text, txtLastName.Text);
                    }

                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    txtPassConfirm.Text = "";
                    txtEmail.Text = "";
                    txtFirstName.Text = "";
                    txtMiddleName.Text = "";
                    txtLastName.Text = "";
                }

                catch (Exception ex)
                {
                    Accounting Acctg = new Accounting();
                    Acctg.Alert(ex.Message, frmAlert.alertTypeEnum.Error);
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            PostData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                PostData();
            }
        }
    }
}
