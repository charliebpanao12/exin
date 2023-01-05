using EXIN.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EXIN.Point_Of_Sales
{
    public partial class ucPOS_TransactionRecords : UserControl
    {
        int transactionID;

        public ucPOS_TransactionRecords()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Panel with Datagrid
            panelRecords.CustomBorderColor = Global.themeColor1;

            // Controls - Textbox 3
            txtSearch.BorderColor = Global.themeColor1;
            txtSearch.FocusedState.BorderColor = Global.themeColor2;
            txtSearch.HoverState.BorderColor = Global.themeColor2;

            #region Filter Box
            // Controls - Filter
            panelFilter_Header.FillColor = Global.themeColor2;
            grpFilter.ForeColor = Global.themeColor1;
            btnApplyFilter.FillColor = Global.themeColor1;
            btnApplyFilter.FillColor2 = Global.themeColor2;

            // Controls - DateTimePicker
            dtpDateFrom.FillColor = Global.themeColor1;
            dtpDateFrom.BorderColor = Global.themeColor1;
            dtpDateFrom.CustomFormat = "MMMM dd, yyyy";

            // Controls - DateTimePicker
            dtpDateTo.FillColor = Global.themeColor1;
            dtpDateTo.BorderColor = Global.themeColor1;
            dtpDateTo.CustomFormat = "MMMM dd, yyyy";

            // Controls - Filter - ComboBox
            cboRecordStatus.BorderColor = Global.themeColor1;
            cboRecordStatus.FocusedState.BorderColor = Global.themeColor2;
            cboRecordStatus.HoverState.BorderColor = Global.themeColor2;

            #endregion
        }

        private void ucTransactionRecords_Load(object sender, EventArgs e)
        {
            clearFields();
            loadTransactionRecords();
        }

        private void clearFields()
        {
            txtSearch.Text = "";
            dtpDateFrom.Value = DateTime.Now;
            dtpDateTo.Value = DateTime.Now;
            cboRecordStatus.Text = "Active";
        }

        private void loadTransactionRecords()
        {
            // Preloader - Ready
            var loader = new WaitFormFunc();

            transactionID = 0;

            String filterTransactions;
            String filterRecordStatus;

            filterTransactions = txtSearch.Text.Trim();
            filterRecordStatus = cboRecordStatus.Text.Trim();

            Image Viewicon = Image.FromFile("Resources/General/Datagrid_Images/view.jpg");
            Image Editicon = Image.FromFile("Resources/General/Datagrid_Images/edit.jpg");
            Image Deleteicon = Image.FromFile("Resources/General/Datagrid_Images/delete.jpg");

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_pos_transactions WHERE (transaction_date BETWEEN '" + dtpDateFrom.Value.ToString("yyyy-MM-dd") + "' AND '" + dtpDateTo.Value.ToString("yyyy-MM-dd") + "') AND Status LIKE '" + filterRecordStatus + "%' ORDER BY transaction_id DESC", Conns.mySqlconn);     // Create a query command
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command, then store the results to a Data Reader

            DataTable mySqlDataTable = new DataTable(); // Create Data Table
            mySqlDataTable.Load(Conns.mySqlDataReader); // Pass the content from Data Reader to Data Table
            int numRows = mySqlDataTable.Rows.Count;    // Get the total records found

            dgvRecords.Rows.Clear();    // Clear the records from datagrid
            lblNumRows.Text = "Count: " + numRows;

            if (numRows > 0)
            {
                if (numRows > 5)    // Preloader - Start 
                { loader.ShowSmall(); }

                int i = 1;
                Conns.mySqlDataReader.Close();  // Close the Data Reader
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySql command again to store the records to Data Reader

                while (Conns.mySqlDataReader.Read())    // Loop the records
                {
                    dgvRecords.Rows.Add(Conns.mySqlDataReader["ID"].ToString(),
                        clview.Image = Viewicon,
                        cledit.Image = Deleteicon,
                        cldelete.Image = Editicon,
                        Conns.mySqlDataReader["transaction_id"].ToString(),
                        Convert.ToDateTime(Conns.mySqlDataReader["transaction_date"]).ToString("MMMM dd, yyyy") + " " + Conns.mySqlDataReader["transaction_time"].ToString(),
                        Conns.mySqlDataReader["transaction_type"].ToString(),
                        Conns.mySqlDataReader["table_number"].ToString(),
                        Conns.mySqlDataReader["cashier"].ToString(),
                        Conns.mySqlDataReader["Status"].ToString());
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database

            // Preloader - Close
            loader.CloseSmall();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            clearFields();
            loadTransactionRecords();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadTransactionRecords();
            }
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
            loadTransactionRecords();
            transitionFilterBox.Hide(panelFilter);
        }

        private void dgvRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                transactionID = Convert.ToInt32(dgvRecords.Rows[e.RowIndex].Cells[4].Value);    // Get the ID of the record

                if (e.ColumnIndex == 1) // View the details
                {
                    frmPOS_Payment frmPOS_Payment = new frmPOS_Payment();
                    frmPOS_Payment.transactionID = transactionID;
                    frmPOS_Payment.ShowDialog();
                }
                else if (e.ColumnIndex == 2) // Delete the records
                {
                    // Show confirmation box
                    //new classMsgBox().showMsgConfirmation_Delete("Do you really want to delete this record?");
                    //if (Global.msgConfirmation == true)
                    //{
                    //    // Delete the record from the database
                    //    MySqlConnect Conns = new MySqlConnect();    // Connect to the database
                    //    Conns.mySqlCmd = new MySqlCommand("UPDATE tbl_units SET Status='Deleted' WHERE ID=" + businessUnitID + ";", Conns.mySqlconn);     // Create a query command
                    //    Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    //    Conns.closeConnection();    // !Important ->> Close the connection from the database

                    //    new classMsgBox().showMsgSuccessful("Record has been deleted!");
                    //    loadBusinessUnits();
                    //}
                    //Application.OpenForms["frmSettings"].Activate(); // Bring the parent form to the front
                }
                else if (e.ColumnIndex == 3) // Edit the details
                {
                    // Preloader - Ready
                    var loader = new WaitFormFunc();

                    // Preloader - Start
                    loader.ShowSmall();

                    var targetForm = Application.OpenForms.OfType<frmPOS_ParentContainer>().Single();

                    targetForm.Controls["panelContainer"].Controls.Clear();
                    ucPOS_NewTransaction ucPOS_NewTransaction = new ucPOS_NewTransaction();
                    ucPOS_NewTransaction.Dock = DockStyle.Fill;
                    ucPOS_NewTransaction.addViewEdit = "Edit";
                    ucPOS_NewTransaction.transactionID = transactionID;
                    targetForm.Controls["panelContainer"].Controls.Add(ucPOS_NewTransaction);

                    // Preloader - Close
                    loader.CloseSmall();
                }
            }
            catch
            {
                return;
            }
        }
    }
}
