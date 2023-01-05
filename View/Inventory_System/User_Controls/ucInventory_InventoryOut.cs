using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using EXIN.Controller;
using Microsoft.VisualBasic;

namespace EXIN.Inventory_System
{
    public partial class ucInventory_InventoryOut : UserControl
    {
        public string SQLStatement;
        public string FilterLoad;
        public string Search;
        public string AddorEditorEditProduct;
        int i;
        DateTime DateFrom;
        DateTime DateTo;

        public string queryDateFrom;
        public string queryDateTo;
        public string queryDate;
        public string queryInvoiceDate;
        public int TransactionID;
        public string DateofDelivery;
        public string TimeofDelivery;
        double TotalQuantity;

        public ucInventory_InventoryOut()
        {
            InitializeComponent();
            dtpDateFrom.Value = DateTime.Now;
            dtpDateTo.Value = DateTime.Now;
            dtpDate.Value = DateTime.Now;
            dtpInvoiceDate.Value = DateTime.Now;

            // Controls - Button 1
            btnAddNewTransaction.FillColor = Global.themeColor1;
            btnAddNewTransaction.HoverState.FillColor = Global.themeColor2;
            btnAddNewTransaction.HoverState.ForeColor = Global.themeForeColor;

            // Controls - Button 1
            btnEditTransaction.FillColor = Global.themeColor1;
            btnEditTransaction.HoverState.FillColor = Global.themeColor2;
            btnEditTransaction.HoverState.ForeColor = Global.themeForeColor;

            // Controls - Button 1
            btnDeleteRecord.FillColor = Global.themeColor1;
            btnDeleteRecord.HoverState.FillColor = Global.themeColor2;
            btnDeleteRecord.HoverState.ForeColor = Global.themeForeColor;

            // Panel with Datagrid
            panelRecords.CustomBorderColor = Global.themeColor1;

            // Controls - txtSearch
            txtSearch.BorderColor = Global.themeColor1;
            txtSearch.FocusedState.BorderColor = Global.themeColor2;
            txtSearch.HoverState.BorderColor = Global.themeColor2;

            // Controls - DateTimePicker
            dtpDate.FillColor = Global.themeColor1;
            dtpDate.BorderColor = Global.themeColor1;
            dtpDate.CustomFormat = "MMMM dd, yyyy";

            // Controls - DateTimePicker
            dtpInvoiceDate.FillColor = Global.themeColor1;
            dtpInvoiceDate.BorderColor = Global.themeColor1;
            dtpInvoiceDate.CustomFormat = "MMMM dd, yyyy";

            // Controls - DateTimePicker
            dtpDateFrom.FillColor = Global.themeColor1;
            dtpDateFrom.BorderColor = Global.themeColor1;
            dtpDateFrom.CustomFormat = "MMMM dd, yyyy";

            // Controls - DateTimePicker
            dtpDateTo.FillColor = Global.themeColor1;
            dtpDateTo.BorderColor = Global.themeColor1;
            dtpDateTo.CustomFormat = "MMMM dd, yyyy";

            #region Filter Box
            // Controls - Filter
            panelFilter_Header.FillColor = Global.themeColor2;
            grpFilter.ForeColor = Global.themeColor1;
            btnApplyFilter.FillColor = Global.themeColor1;
            btnApplyFilter.FillColor2 = Global.themeColor2;


            #endregion
        }
        #region dockController
        public static frmInventory_ParentContainer _obj;

        public static frmInventory_ParentContainer Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new frmInventory_ParentContainer();
                }
                return _obj;
            }
        }

        classControl_Docking control_Docking = new classControl_Docking(); //Declare Control_Docking Class         
        #endregion

        private void ucInventory_InventoryOut_Load(object sender, EventArgs e)
        {

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
            FilterLoad = "Filter";
            LoadData();
        }

        private void InventoryInForm()
        {
            MySqlConnect Conns = new MySqlConnect();
            //Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_inventory_in_transactions WHERE transaction_id =" + TransactionID, Conns.mySqlconn);
            Conns.mySqlCmd = new MySqlCommand("SELECT T1.transaction_id, T2.Project_Code, T2.Project_Name, T1.bill_to, T1.ship_to, T1.date_time, T1.dr_no, T1.invoice_number, T1.invoice_date, T1.consignment, T1.business_style, T1.department, T1.phone, T1.memo, T1.prepared_by, T1.checked_by, T1.approved_by, T1.released_by, T1.received_by FROM " +
                                    "(SELECT transaction_id, Project_Code, category_code, bill_to, ship_to, date_time, dr_no, invoice_number, invoice_date, consignment, business_style, department, phone, memo, prepared_by, checked_by, approved_by, released_by, received_by, status FROM tbl_inventory_out_transactions) AS T1 " +
                                    "LEFT JOIN (SELECT Project_Code, Category_Code, Project_Name FROM tbl_projects) AS T2 ON T1.Project_Code = T2 .Project_Code WHERE T1.transaction_id = " + TransactionID, Conns.mySqlconn);
            //Conns.mySqlDataReader.Close();
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
            while (Conns.mySqlDataReader.Read())
            {
                TimeofDelivery = Conns.mySqlDataReader.GetDateTime("date_time").ToShortTimeString();
                txtTransactionID.Text = Conns.mySqlDataReader["transaction_id"].ToString();
                txtBranchZipCode.Text = Conns.mySqlDataReader["Project_Code"].ToString();
                txtBranch.Text = Conns.mySqlDataReader["Project_Name"].ToString();
                txtBillToZipCode.Text = Conns.mySqlDataReader["bill_to"].ToString();
                txtBillTo.Text = Conns.mySqlDataReader["Project_Name"].ToString();
                txtShipToZipCode.Text = Conns.mySqlDataReader["ship_to"].ToString();
                txtShipTo.Text = Conns.mySqlDataReader["Project_Name"].ToString();
                dtpDate.Text = Conns.mySqlDataReader["date_time"].ToString();
                txtTime.Text = TimeofDelivery;
                txtDeliveryNumber.Text = Conns.mySqlDataReader["dr_no"].ToString();
                txtInvoiceNumber.Text = Conns.mySqlDataReader["invoice_number"].ToString();
                dtpInvoiceDate.Text = Conns.mySqlDataReader["invoice_date"].ToString();
                txtConsignment.Text = Conns.mySqlDataReader["consignment"].ToString();
                txtBusinessStyle.Text = Conns.mySqlDataReader["business_style"].ToString();
                txtDepartment.Text = Conns.mySqlDataReader["department"].ToString();
                txtPhone.Text = Conns.mySqlDataReader["phone"].ToString();
                txtMemo.Text = Conns.mySqlDataReader["memo"].ToString();
                txtPreparedBy.Text = Conns.mySqlDataReader["prepared_by"].ToString();
                txtCheckedBy.Text = Conns.mySqlDataReader["checked_by"].ToString();
                txtApprovedBy.Text = Conns.mySqlDataReader["approved_by"].ToString();
                txtReleasedBy.Text = Conns.mySqlDataReader["released_by"].ToString();
                txtReceivedBy.Text = Conns.mySqlDataReader["received_by"].ToString();
            }

        }

        private void dgvRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Information.IsNumeric(dgvTransactionOut.Rows[e.RowIndex].Cells[1].Value))
            {
                TransactionID = Convert.ToInt32(dgvTransactionOut.Rows[e.RowIndex].Cells[1].Value);
                if (TransactionID > 0)
                {
                    MySqlConnect Conns = new MySqlConnect();
                    SQLStatement = "SELECT product_id, barcode, sku, item_name, unit_of_measure, quantity, unit_price, selling_price, discount, total_amount FROM tbl_inventory_out_transactions WHERE transaction_id =" + TransactionID + " AND status = 'Active'";
                    dgvTransactionOut_details.Rows.Clear();
                    Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
                    Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                    while (Conns.mySqlDataReader.Read())
                    {
                        i++;
                        dgvTransactionOut_details.Rows.Add(i,
                            Conns.mySqlDataReader["product_id"].ToString(),
                            Conns.mySqlDataReader["barcode"].ToString(),
                            Conns.mySqlDataReader["sku"].ToString(),
                            Conns.mySqlDataReader["item_name"].ToString(),
                            Conns.mySqlDataReader["unit_of_measure"].ToString(),
                            Conns.mySqlDataReader["quantity"].ToString(),
                            Conns.mySqlDataReader["unit_price"].ToString(),
                            Conns.mySqlDataReader["selling_price"].ToString(),
                            //Conns.mySqlDataReader["discount"].ToString(),
                            Conns.mySqlDataReader["total_amount"].ToString());
                    }
                    Conns.mySqlconn.Close();
                    InventoryInForm();
                }
                else
                {
                    dgvTransactionOut.Rows.Clear();
                }
            }
            else
            {
                dgvTransactionOut.Rows.Clear();
            }
        }
        private void LoadData()
        {
            TotalQuantity = 0;
            TransactionID = 0;

            MySqlConnect Conns = new MySqlConnect();
            DateFrom = dtpDateFrom.Value;
            DateTo = dtpDateTo.Value;
            queryDateFrom = DateFrom.ToString("yyyy-MM-dd");
            queryDateTo = DateTo.ToString("yyyy-MM-dd");
            if (DateFrom <= DateTo)
            {
                //SQLStatement = "SELECT transaction_id, date_time, SUM(quantity) AS quantity FROM tbl_inventory_in_transactions WHERE DATE(date_time) BETWEEN'" + queryDateFrom + "' AND '" + queryDateTo + "'AND status != 'Deleted' GROUP BY transaction_id ORDER BY transaction_id DESC";
                //SQLStatement = "SELECT transaction_id, date_time, SUM(quantity) AS total_quantity FROM tbl_inventory_in_transactions WHERE category_code = '" + Global.businessCategory + "' AND unit_code = " + Global.businessUnitCode + " AND DATE(date_time) BETWEEN '" + queryDateFrom + "' AND '" + queryDateTo + "' AND status<>'Deleted' GROUP BY transaction_id ORDER BY transaction_id DESC";
                SQLStatement = "SELECT T1.transaction_id, T1.date_time, T1.total_quantity, T1.product_id, T2.category_code, T2.unit_code, T1.status FROM" +
                               "(SELECT transaction_id, product_id, date_time, quantity, SUM(quantity) AS total_quantity, status FROM tbl_inventory_out_transactions WHERE DATE(date_time) BETWEEN '" + queryDateFrom + "' AND '" + queryDateTo + "' AND status<>'Deleted' GROUP BY transaction_id) as T1  " +
                               "LEFT JOIN (SELECT product_id, category_code, unit_code FROM tbl_inventory_products_masterlist WHERE category_code = '" + Global.inventoryBusinessCategoryCode + "' AND unit_code = '" + Global.inventoryBusinessUnitCode + "') as T2 on T1.product_id = T2.product_id ORDER BY T1.date_time DESC";
            }
            dgvTransactionOut.Rows.Clear();
            dgvTransactionOut_details.Rows.Clear();

            Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(Conns.mySqlDataReader);

            int NumberOfResults = dt.Rows.Count; //recordCount = ds.Tables("records").Rows.Count
            if (NumberOfResults > 0)
            {
                //Conns.mySqlDataReader.Close();
                //Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                //while (Conns.mySqlDataReader.Read())
                //{
                //    DateofDelivery = Conns.mySqlDataReader.GetDateTime("date_time").ToShortDateString();
                //    dgvTransactionIn.Rows.Add("", DateofDelivery, "");
                //}
                ////for looper = 0 To NumberOfResults - 1;
                //if (DateofDelivery = DateTime.Parse(dt.Rows.("date_time")).ToLongDateString)
                //{
                Conns.mySqlDataReader.Close();
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();

                DateofDelivery = "1990-01-01";

                while (Conns.mySqlDataReader.Read())
                {
                    // Validate if the row is same date with the previous row. If not, show the total quantity as new row
                    if (dgvTransactionOut.Rows.Count > 0)
                    {
                        if (DateofDelivery != Conns.mySqlDataReader.GetDateTime("date_time").ToShortDateString())
                        {
                            dgvTransactionOut.Rows.Add(i, "Total Quantity", "", Math.Round(TotalQuantity));
                            TotalQuantity = 0;  // Reset the total quantity to zero
                        }
                    }

                    // Validate if the row is same date with the previous row
                    if (DateofDelivery != Conns.mySqlDataReader.GetDateTime("date_time").ToShortDateString())
                    {
                        DateofDelivery = Conns.mySqlDataReader.GetDateTime("date_time").ToShortDateString();
                        dgvTransactionOut.Rows.Add(0, "", DateofDelivery, "");
                    }

                    // Get the value of time and total quantity
                    TimeofDelivery = Conns.mySqlDataReader.GetDateTime("date_time").ToShortTimeString();
                    TotalQuantity += Convert.ToDouble(Conns.mySqlDataReader["total_quantity"].ToString());

                    // Show the record as new row to datagrid
                    dgvTransactionOut.Rows.Add(i, Conns.mySqlDataReader["transaction_id"].ToString(), TimeofDelivery, Conns.mySqlDataReader["total_quantity"].ToString());

                    i++;
                }

                dgvTransactionOut.Rows.Add(i, "Total Quantity", "", Math.Round(TotalQuantity)); // Show the total quantity at the end of the row
            }
            else
            {
                //new classMsgBox().showMsgError("No record found!");
                control_Docking.ClearUserControls(frmInventory_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
                control_Docking.DockControl_InventorySystem(new ucInventory_InventoryOut()); // Loads the target user control in docked mode
            }


        }
        
        private void ucInventory_InventoryOut_Load_1(object sender, EventArgs e)
        {
            dgvTransactionOut.Rows.Clear();
            dgvTransactionOut_details.Rows.Clear();
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            new classMsgBox().showMsgConfirmation_Delete("Do you really want to delete this record?");
            if (Global.msgConfirmation == true)
            {
                // your codes here when the OK button has been pressed
                new classMsgBox().showMsgSuccessful("Successfully Deleted");
            }
            else
            {
                // your codes here when the NO button has been pressed

            }
            Application.OpenForms["frmInventory_ParentContainer"].Activate(); // Bring the parent form to the front
        }

        private void panelRecords_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddNewTransaction_Click(object sender, EventArgs e)
        {
            frmInventory_InventoryOut_AddNewTransaction frmInventory_InventoryOut_AddNewTransaction = new frmInventory_InventoryOut_AddNewTransaction();
            frmInventory_InventoryOut_AddNewTransaction.AddorEditorEditProduct = "Add";
            frmInventory_InventoryOut_AddNewTransaction.ShowDialog();
        }

        private void btnEditTransaction_Click(object sender, EventArgs e)
        {
            if (TransactionID > 0)
            {

                frmInventory_InventoryOut_AddNewTransaction frmInventory_InventoryOut_AddNewTransaction = new frmInventory_InventoryOut_AddNewTransaction();
                frmInventory_InventoryOut_AddNewTransaction.AddorEditorEditProduct = "Edit";
                frmInventory_InventoryOut_AddNewTransaction.TransactionID = TransactionID;
                frmInventory_InventoryOut_AddNewTransaction.ShowDialog();
            }
            else
            {
                new classMsgBox().showMsgError("Please select a record first before you edit it!");
                control_Docking.ClearUserControls(frmInventory_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
                control_Docking.DockControl_InventorySystem(new ucInventory_InventoryOut()); // Loads the target user control in docked mode
            }
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            control_Docking.ClearUserControls(frmInventory_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_InventorySystem(new ucInventory_InventoryOut()); // Loads the target user control in docked mode
        }

        private void dgvTransactionOut_details_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
