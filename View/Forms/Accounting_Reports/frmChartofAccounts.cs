using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace EXIN
{
    public partial class frmChartofAccounts : Form
    {
        public frmChartofAccounts()
        {
            InitializeComponent();
        }

        string Post;
        private void frmChartofAccount_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            cmbSLName.Hide();
        }

        private void PostData()
        {
            if (Post == "Save")
            {

                try
                {
                    if (txtGLNo.Text == "" || txtSLName.Text == "" || txtSLNo.Text == "")
                    {
                        MessageBox.Show("Do not leave a textbox empty", "Error Prompt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Accounting Acctg = new Accounting();
                    Acctg.mysqlQuery = "UPDATE `rci_chart_of_accounts` SET `sl_no` = @SLNo, `sl_name` = @SLName,`gl_no` = @GLNo," +
                       "`gl_name` = @GLName WHERE `seq_id` = @id";

                    DialogResult resultUpdate = MessageBox.Show("Do you want to continue updating this Account?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (resultUpdate == DialogResult.Yes)
                    {
                        Acctg.UpdateChartAccount(Convert.ToInt32(txtSLNo.Text), txtSLName.Text, Convert.ToInt32(txtGLNo.Text), txtGLName.Text, Convert.ToInt32(lblChartID.Text));
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
                    if (txtGLName.Text == "" || txtGLNo.Text == "" || txtSLName.Text == "" || txtSLNo.Text == "")
                    {
                        MessageBox.Show("Do not leave a textbox empty", "Error Prompt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Accounting Acctg = new Accounting();

                    Acctg.mysqlQuery = "INSERT INTO `rci_chart_of_accounts`(`sl_no`,`sl_name`,`gl_no`,`gl_name`)" +
                    "VALUES(@SLNo,@SLName,@GLNo,@GLName)";


                    DialogResult resultInsert = MessageBox.Show("Do you want to continue adding new Account?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (resultInsert == DialogResult.Yes)
                    {
                        Acctg.AddChartAccount(Convert.ToInt32(txtSLNo.Text), txtSLName.Text, Convert.ToInt32(txtGLNo.Text), txtGLName.Text);
                    }

                    txtSLName.Text = null;
                    txtSLNo.Text = null;
                    txtGLName.Text = null;
                    txtGLNo.Text = null;
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Post = (sender as Guna2Button).Text;
            PostData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Post = "Save";

            txtSLName.Hide();
            cmbSLName.Show();


            string btnText = (sender as Guna2Button).Text;

            if (btnText == "Cancel")
            {
                this.Close();
                return;
            }
            else
            {


                if (cmbSLName.Items.Count == 0)
                {
                    //Add Subledger to combobox
                    MySqlConnect MySqlConn = new MySqlConnect();

                    MySqlCommand mySqlCmd = new MySqlCommand("SELECT `sl_name` FROM rci_chart_of_accounts ORDER BY `sl_name` ASC", MySqlConn.mySqlconn);
                    MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                    mySqlAdapter.SelectCommand = mySqlCmd;
                    DataTable mySqlDataTable = new DataTable();
                    mySqlAdapter.Fill(mySqlDataTable);



                    //LOOP THRU ComboBox
                    foreach (DataRow row in mySqlDataTable.Rows)
                    {
                        cmbSLName.Items.Add(row[0].ToString());
                    }

                    MySqlConn.closeConnection();


                    MessageBox.Show("Select the SL or GL to be updated", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnUpdate.Text = "Cancel";
                    btnAdd.Text = "Save";
                    MySqlConn.closeConnection();

                }
                else
                {
                    btnUpdate.Text = "Update";
                    return;
                }
            }
        }


        private void cmbSL_SelectedValueChanged(object sender, EventArgs e)
        {


            txtGLName.Show();

            MySqlConnect MySqlConn = new MySqlConnect();

            MySqlCommand mySqlCmd = new MySqlCommand("SELECT * FROM `rci_chart_of_accounts` WHERE `sl_name` = @cmbselected", MySqlConn.mySqlconn);

            mySqlCmd.Parameters.AddWithValue("@cmbselected", cmbSLName.GetItemText(cmbSLName.SelectedItem));

            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            DataTable mySqlDataTable = new DataTable();
            mySqlAdapter.Fill(mySqlDataTable);

            //LOOP THRU ComboBox
            foreach (DataRow row in mySqlDataTable.Rows)
            {
                txtSLNo.Text = row[1].ToString();
                txtSLName.Text = row[2].ToString();
                txtGLName.Text = row[4].ToString();
                txtGLNo.Text = row[3].ToString();
                lblChartID.Text = row[0].ToString();
            }


            //MessageBox.Show("Select the Payee to be updated", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MySqlConn.closeConnection();
        }

        private void txtGLSLName_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputHandler inputChecker = new InputHandler();

            inputChecker.CheckEnterKey(PostData, e);

        }

        private void txtGLSLNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputHandler inputChecker = new InputHandler();

            inputChecker.CheckInputNum(e);

            inputChecker.CheckEnterKey(PostData, e);
        }
    }
}
