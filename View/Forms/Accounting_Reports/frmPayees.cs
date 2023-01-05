using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace EXIN
{
    public partial class frmPayees : Form
    {
        public frmPayees()
        {
            InitializeComponent();
        }


        string Post;
        private void frmCheckVoucher_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            cmbPayee.Hide();

        }

        public void PostData()
        {

            if (Post == "Save")
            {
                try
                {
                    if (txtAddress.Text == "" || txtContact.Text == "" || txtTIN.Text == "")
                    {
                        MessageBox.Show("Do not leave a textbox empty", "Error Prompt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Accounting Acctg = new Accounting();
                    Acctg.mysqlQuery = "UPDATE `rci_payee_profile` SET `payee_Name` = @name, `payee_Address` = @address,`payee_Contact` = @contact," +
                       "`payee_TIN` = @tinNumber, `usercode` = @usercode WHERE `payee_id` = @id";

                    DialogResult resultUpdate = MessageBox.Show("Do you want to continue updating this Payee details?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (resultUpdate == DialogResult.Yes)
                    {
                        Acctg.payeeUpdate(cmbPayee.Text, txtAddress.Text, Convert.ToDouble(txtContact.Text), Convert.ToDouble(txtTIN.Text), Convert.ToInt32(lblPayeeID.Text));
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
                    if (txtAddress.Text == "" || txtCheckName.Text == "" || txtContact.Text == "" || txtTIN.Text == "")
                    {
                        MessageBox.Show("Do not leave a textbox empty", "Error Prompt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    Accounting Acctg = new Accounting();

                    Acctg.mysqlQuery = "INSERT INTO `rci_payee_profile`(`payee_Name`,`payee_Address`,`payee_Contact`,`payee_TIN`,`usercode`)" +
                    "VALUES(@name,@address,@contact,@tinNumber,@user)";


                    DialogResult resultInsert = MessageBox.Show("Do you want to continue adding new Payee?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (resultInsert == DialogResult.Yes)
                    {
                        Acctg.payeeInsert(txtCheckName.Text, txtAddress.Text, Convert.ToDouble(txtContact.Text), Convert.ToDouble(txtTIN.Text), Acctg.myAccount);
                    }

                    txtCheckName.Text = null;
                    txtAddress.Text = null;
                    txtContact.Text = null;
                    txtTIN.Text = null;


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

            txtCheckName.Hide();
            cmbPayee.Show();


            string btnText = (sender as Guna2Button).Text;

            if (btnText == "Cancel")
            {
                this.Close();
                return;
            }
            else
            {


                if (cmbPayee.Items.Count == 0)
                {

                    MySqlConnect MySqlConn = new MySqlConnect();

                    MySqlCommand mySqlCmd = new MySqlCommand("SELECT `payee_Name` FROM rci_payee_profile ORDER BY `payee_Name` ASC", MySqlConn.mySqlconn);
                    MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                    mySqlAdapter.SelectCommand = mySqlCmd;
                    DataTable mySqlDataTable = new DataTable();
                    mySqlAdapter.Fill(mySqlDataTable);

                    //LOOP THRU ComboBox
                    foreach (DataRow row in mySqlDataTable.Rows)
                    {
                        cmbPayee.Items.Add(row[0].ToString());
                    }

                    MessageBox.Show("Select the Payee to be updated", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnUpdate.Text = "Cancel";
                    btnAdd.Text = "Save";
                    MySqlConn.closeConnection();
                }
                else
                {
                    btnUpdate.Text = "Update";
                    Post = "Save";
                    return;
                }
            }
        }


        private void cmbPayee_SelectedValueChanged(object sender, EventArgs e)
        {

            MySqlConnect MySqlConn = new MySqlConnect();

            MySqlCommand mySqlCmd = new MySqlCommand("SELECT * FROM `rci_payee_profile` WHERE `payee_Name` = @cmbselected", MySqlConn.mySqlconn);

            mySqlCmd.Parameters.AddWithValue("@cmbselected", cmbPayee.GetItemText(cmbPayee.SelectedItem));

            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            DataTable mySqlDataTable = new DataTable();
            mySqlAdapter.Fill(mySqlDataTable);

            //LOOP THRU ComboBox
            foreach (DataRow row in mySqlDataTable.Rows)
            {
                txtAddress.Text = row[2].ToString();
                txtContact.Text = row[3].ToString();
                txtTIN.Text = row[4].ToString();
                lblPayeeID.Text = row[0].ToString();
            }


            //MessageBox.Show("Select the Payee to be updated", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MySqlConn.closeConnection();
        }

        private void txtPayeeandAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputHandler inputHandler = new InputHandler();

            inputHandler.CheckEnterKey(PostData, e);
        }

        private void txtContactandTIN_KeyPress(object sender, KeyPressEventArgs e)
        {


            InputHandler inputHandler = new InputHandler();

            inputHandler.CheckInputNum(e);

            inputHandler.CheckEnterKey(PostData, e);


        }

    }
}
