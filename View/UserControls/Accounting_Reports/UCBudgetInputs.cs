using Guna.UI.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace EXIN
{
    public partial class UCBudgetInputs : UserControl
    {
        public UCBudgetInputs()
        {
            InitializeComponent();

        }

        string busUnitName;
        string busUnit;
        string projectCode;
        string costCenterCode;
        string busUQuery;
        int userId;
        string SQLStatement;
        string accountClassName;
        string accountCode;

        MySqlConnect ConnAll = new MySqlConnect();
        FS FSConn = new FS();



        private void btnAddInput_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmBudgetSetup"] != null)
            {
                (Application.OpenForms["frmBudgetSetup"] as frmBudgetSetup).AddBudgetInput();
            }


        }


        private void btnDeleteInput_Click(object sender, EventArgs e)
        {
            (sender as GunaImageButton).Parent.Hide();
        }

        /***************COMBOBOX FILL*********************/

        public void fillAccountClassCode()
        {
            //LOOP THRU cmbClass



            userId = ConnAll.myAccount;


            SQLStatement = @"SELECT `ExpandedAccounts`, `ExpandedAccountDesc` FROM `tbl_expandedpnlaccounts`
                                       ORDER BY `ExpandedAccounts` ASC ;";

            MySqlCommand mySqlCmd = new MySqlCommand(SQLStatement, ConnAll.mySqlconn); ;
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
            mySqlAdapter.SelectCommand = mySqlCmd;
            System.Data.DataTable mySqlDataTable = new System.Data.DataTable();
            mySqlAdapter.Fill(mySqlDataTable);
            ConnAll.closeConnection();


            foreach (DataRow row in mySqlDataTable.Rows)
            {
                cmbAccountClass.Items.Add(row[1].ToString());

            }

            cmbAccountClass.MouseWheel += new MouseEventHandler(combobox_MouseWheel);

            void combobox_MouseWheel(object sender, MouseEventArgs e)
            {
                ((HandledMouseEventArgs)e).Handled = true;
            }

        }


        /*************************FETCH COMBO BOX CODES*****************/

        private void populateClassCode()
        {

            //Get Class Code
            SQLStatement = @"SELECT `ExpandedAccounts` FROM `tbl_expandedpnlaccounts` WHERE `ExpandedAccountDesc` = @className;";

            MySqlCommand AccountClassCmd = new MySqlCommand(SQLStatement, ConnAll.mySqlconn);
            AccountClassCmd.Parameters.AddWithValue("@className", accountClassName);
            MySqlDataAdapter AccountClassAdapter = new MySqlDataAdapter();
            AccountClassAdapter.SelectCommand = AccountClassCmd;
            System.Data.DataTable AccountClassDataTable = new System.Data.DataTable();
            AccountClassAdapter.Fill(AccountClassDataTable);


            foreach (DataRow row in AccountClassDataTable.Rows)
            {
                accountCode = row[0].ToString();
            }


        }

        private void UCBudgetInputs_Load(object sender, EventArgs e)
        {
            fillAccountClassCode();
        }

        private void cmbAccountClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            accountClassName = cmbAccountClass.GetItemText(cmbAccountClass.SelectedItem);
            populateClassCode();
            txtClassCode.Text = accountCode;

        }

        private void txtBudgetAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                txtBudgetAmount.Text = string.Format("{0:#,##0.00}", double.Parse(txtBudgetAmount.Text));
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
