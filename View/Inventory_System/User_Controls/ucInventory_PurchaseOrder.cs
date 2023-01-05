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
    public partial class ucInventory_PurchaseOrder : UserControl
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

        public ucInventory_PurchaseOrder()
        {        
            InitializeComponent();
            dtpDateFrom.Value = DateTime.Now;
            dtpDateTo.Value = DateTime.Now;
            dtpDate.Value = DateTime.Now;


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
            dtpDateFrom.FillColor = Global.themeColor1;
            dtpDateFrom.BorderColor = Global.themeColor1;
            dtpDateFrom.CustomFormat = "MMMM dd, yyyy";

            // Controls - DateTimePicker
            dtpDateTo.FillColor = Global.themeColor1;
            dtpDateTo.BorderColor = Global.themeColor1;
            dtpDateTo.CustomFormat = "MMMM dd, yyyy";

            // Controls - DateTimePicker
            dtpDate.FillColor = Global.themeColor1;
            dtpDate.BorderColor = Global.themeColor1;
            dtpDate.CustomFormat = "MMMM dd, yyyy";


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

        private void ucInventory_InventoryIn_Load(object sender, EventArgs e)
        {
            dgvTransactionPO.Rows.Clear();
            dgvTransactionPO_details.Rows.Clear();
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
                //SQLStatement = "SELECT transaction_id, date_time, SUM(quantity) AS quantity FROM tbl_purchase_order_transactions WHERE DATE(date_time) BETWEEN'" + queryDateFrom + "' AND '" + queryDateTo + "'AND status != 'Deleted' GROUP BY transaction_id ORDER BY transaction_id DESC";
                //SQLStatement = "SELECT transaction_id, date_time, SUM(quantity) AS total_quantity FROM tbl_purchase_order_transactions WHERE category_code = '" + Global.businessCategory + "' AND unit_code = " + Global.businessUnitCode + " AND DATE(date_time) BETWEEN '" + queryDateFrom + "' AND '" + queryDateTo + "' AND status<>'Deleted' GROUP BY transaction_id ORDER BY transaction_id DESC";
                SQLStatement = "SELECT T1.transaction_id, T1.po_date, T1.total_quantity, T1.product_id, T2.category_code, T2.unit_code, T1.status FROM" +
                               "(SELECT transaction_id, product_id, po_date, quantity, SUM(quantity) AS total_quantity, status FROM tbl_purchase_order_transactions WHERE DATE(po_date) BETWEEN '" + queryDateFrom + "' AND '" + queryDateTo + "' AND status<>'Deleted' GROUP BY transaction_id) as T1  "+
                               "LEFT JOIN (SELECT product_id, category_code, unit_code FROM tbl_inventory_products_masterlist WHERE category_code = '" + Global.inventoryBusinessCategoryCode + "' AND unit_code = '" + Global.inventoryBusinessUnitCode + "') as T2 on T1.product_id = T2.product_id ORDER BY T1.po_date DESC";
            }
            dgvTransactionPO.Rows.Clear();
            dgvTransactionPO_details.Rows.Clear();

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
                    if (dgvTransactionPO.Rows.Count>0)
                    {
                        if (DateofDelivery != Conns.mySqlDataReader.GetDateTime("po_date").ToShortDateString())
                        {
                            dgvTransactionPO.Rows.Add(i, "Total Quantity", "", Math.Round(TotalQuantity));
                            TotalQuantity = 0;  // Reset the total quantity to zero
                        }
                    }

                    // Validate if the row is same date with the previous row
                    if (DateofDelivery != Conns.mySqlDataReader.GetDateTime("po_date").ToShortDateString())
                    {
                        DateofDelivery = Conns.mySqlDataReader.GetDateTime("po_date").ToShortDateString();
                        dgvTransactionPO.Rows.Add(0, "", DateofDelivery, "");
                    }

                    // Get the value of time and total quantity
                    TimeofDelivery = Conns.mySqlDataReader.GetDateTime("po_date").ToShortTimeString();
                    TotalQuantity += Convert.ToDouble(Conns.mySqlDataReader["total_quantity"].ToString());

                    // Show the record as new row to datagrid
                    dgvTransactionPO.Rows.Add(i, Conns.mySqlDataReader["transaction_id"].ToString(), TimeofDelivery, Conns.mySqlDataReader["total_quantity"].ToString());

                    i++;
                }

                dgvTransactionPO.Rows.Add(i, "Total Quantity", "", Math.Round(TotalQuantity)); // Show the total quantity at the end of the row
            }
            else
            {
                //new classMsgBox().showMsgError("No record found!");
                control_Docking.ClearUserControls(frmInventory_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
                control_Docking.DockControl_InventorySystem(new ucInventory_PurchaseOrder()); // Loads the target user control in docked mode
            }

            dgvTransactionIn_details_Load();
        }

        private void dgvTransactionIn_details_Load()
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
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

        private void btnAddNewTransaction_Click(object sender, EventArgs e)
        {
            frmInventory_PurchaseOrder_AddNewTransaction frmInventory_PurchaseOrder_AddNewTransaction = new frmInventory_PurchaseOrder_AddNewTransaction();
            frmInventory_PurchaseOrder_AddNewTransaction.AddorEditorEditProduct = "Add";
            frmInventory_PurchaseOrder_AddNewTransaction.ShowDialog();
        }

         
        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            MySqlConnect Conns = new MySqlConnect();
            if (TransactionID > 0)
            {
                new classMsgBox().showMsgConfirmation_Delete("Do you really want to delete this record?");
                if (Global.msgConfirmation == true)
                {
                    // your codes here when the OK button has been pressed
                    Conns.mySqlCmd = new MySqlCommand("update tbl_purchase_order_transactions set status = 'Deleted' WHERE transaction_id =" + TransactionID, Conns.mySqlconn);
                    Conns.mySqlCmd.ExecuteNonQuery();
                    new classMsgBox().showMsgSuccessful("Deleted Successfully");
                }
                Application.OpenForms["frmInventory_ParentContainer"].Activate(); // Bring the parent form to the front
            }
            else
            {
                new classMsgBox().showMsgError("Please select a record first before you delete it!");
                control_Docking.ClearUserControls(frmInventory_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
                control_Docking.DockControl_InventorySystem(new ucInventory_PurchaseOrder()); // Loads the target user control in docked mode
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search = txtSearch.Text;
            dgvTransactionPO.Rows.Clear();
     
            if (Search != null || Search != " ")
            {
                MySqlConnect Conns = new MySqlConnect();
                int i = 0;
                //SQLStatement = "SELECT transaction_id, date_time, SUM(quantity) AS quantity FROM tbl_purchase_order_transactions WHERE transaction_id = '" + Search + "' OR product_id = '" + Search + "' OR item_name LIKE'%' '" + Search + "' '%' AND status = 'Active' GROUP BY transaction_id ORDER BY transaction_id DESC";
                SQLStatement = "SELECT transaction_id, date_time, quantity, SUM(quantity) AS total_quantity FROM tbl_purchase_order_transactions WHERE transaction_id = '" + Search + "' OR product_id = '" + Search + "' OR item_name LIKE'%' '" + Search + "' '%' AND category_code='" + Global.inventoryBusinessCategoryCode + "' AND unit_code=" + Global.inventoryBusinessUnitCode + " AND DATE(date_time) BETWEEN '" + dtpDateFrom.Value.ToString("yyyy-MM-dd") + "' AND '" + dtpDateTo.Value.ToString("yyyy-MM-dd") + "' AND status != 'Deleted' GROUP BY transaction_id ORDER BY transaction_id DESC";
                //SQLStatement = "SELECT T1.transaction_id, T1.date_time, T1.total_quantity, T1.product_id, T2.category_code, T2.unit_code, T1.status FROM" +
                //              "(SELECT transaction_id, product_id, date_time, quantity, SUM(quantity) AS total_quantity, status FROM tbl_purchase_order_transactions WHERE category_code = '" + Global.businessCategory + "' AND unit_code = " + Global.businessUnitCode + " AND DATE(date_time) BETWEEN '" + queryDateFrom + "' AND '" + queryDateTo + "' AND status<>'Deleted' GROUP BY transaction_id) as T1  " +
                //              "LEFT JOIN (SELECT product_id, category_code, unit_code FROM tbl_inventory_products_masterlist) as T2 on T1.product_id = T2.product_id ORDER BY T1.date_time DESC";
                Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(Conns.mySqlDataReader);
                int NumberOfResults = dt.Rows.Count;
                if (NumberOfResults > 0)
                {

                            Conns.mySqlDataReader.Close();

                            while (Conns.mySqlDataReader.Read())
                            {
                                DateofDelivery = Conns.mySqlDataReader.GetDateTime("date_time").ToShortDateString();
                                TimeofDelivery = Conns.mySqlDataReader.GetDateTime("date_time").ToShortTimeString();
                                i++;
                                dgvTransactionPO.Rows.Add(i, "", DateofDelivery, "");
                                dgvTransactionPO.Rows.Add(i, Conns.mySqlDataReader["transaction_id"].ToString(), TimeofDelivery, Conns.mySqlDataReader["quantity"].ToString());
                                TotalQuantity += TotalQuantity + Convert.ToDouble(Conns.mySqlDataReader["quantity"].ToString());
                                dgvTransactionPO.Rows.Add(i, "Total Quantity", "", Math.Round(TotalQuantity));

                            }
                  
                }
                else
                {
                    //new classMsgBox().showMsgError("No record found!");
                    control_Docking.ClearUserControls(frmInventory_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
                    control_Docking.DockControl_InventorySystem(new ucInventory_PurchaseOrder()); // Loads the target user control in docked mode
                }
                Conns.mySqlconn.Close();
                dgvTransactionIn_details_Load();
            }
        }
        private void dgvTransaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            control_Docking.ClearUserControls(frmInventory_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_InventorySystem(new ucInventory_PurchaseOrder()); // Loads the target user control in docked mode
        }


      private void dgvTransactionIn_SelectionChanged(object sender, EventArgs e)
        {
    
        }
        private void InventoryInForm()
        {
            MySqlConnect Conns = new MySqlConnect();
            //Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_inventory_in_transactions WHERE transaction_id =" + TransactionID, Conns.mySqlconn);
            Conns.mySqlCmd = new MySqlCommand("SELECT T1.transaction_id, T2.Project_Code, T2.Project_Name, T1.bill_to, T1.ship_to, T1.po_date, T1.po_no, T1.consignment, T1.business_style, T1.department, T1.phone, T1.memo, T1.prepared_by, T1.checked_by, T1.approved_by, T1.acknowledged_by, T1.remarks FROM " +
                                    "(SELECT transaction_id, Project_Code, category_code, bill_to, ship_to, po_date, po_no, consignment, business_style, department, phone, memo, prepared_by, checked_by, approved_by, acknowledged_by, remarks, status FROM tbl_purchase_order_transactions) AS T1 " +
                                    "LEFT JOIN (SELECT Project_Code, Category_Code, Project_Name FROM tbl_projects) AS T2 ON T1.Project_Code = T2 .Project_Code WHERE T1.transaction_id = " + TransactionID, Conns.mySqlconn);
            //Conns.mySqlDataReader.Close();
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
            while (Conns.mySqlDataReader.Read())
            {
                TimeofDelivery = Conns.mySqlDataReader.GetDateTime("po_date").ToShortTimeString();
                txtTransactionID.Text = Conns.mySqlDataReader["transaction_id"].ToString();
                txtBranchZipCode.Text = Conns.mySqlDataReader["Project_Code"].ToString();
                txtBranch.Text = Conns.mySqlDataReader["Project_Name"].ToString();
                txtBillToZipCode.Text = Conns.mySqlDataReader["bill_to"].ToString();
                txtBillTo.Text = Conns.mySqlDataReader["Project_Name"].ToString();
                txtShipToZipCode.Text = Conns.mySqlDataReader["ship_to"].ToString();
                txtShipTo.Text = Conns.mySqlDataReader["Project_Name"].ToString();
                dtpDate.Text = Conns.mySqlDataReader["po_date"].ToString();
                txtTime.Text = TimeofDelivery;
                txtDeliveryNumber.Text = Conns.mySqlDataReader["po_no"].ToString();
                txtConsignment.Text = Conns.mySqlDataReader["consignment"].ToString();
                txtBusinessStyle.Text = Conns.mySqlDataReader["business_style"].ToString();
                txtDepartment.Text = Conns.mySqlDataReader["department"].ToString();
                txtPhone.Text = Conns.mySqlDataReader["phone"].ToString();
                txtMemo.Text = Conns.mySqlDataReader["memo"].ToString();
                txtPreparedBy.Text = Conns.mySqlDataReader["prepared_by"].ToString();
                txtCheckedBy.Text = Conns.mySqlDataReader["checked_by"].ToString();
                txtApprovedBy.Text = Conns.mySqlDataReader["approved_by"].ToString();
                txtAcknowledgedBy.Text = Conns.mySqlDataReader["acknowledged_by"].ToString();
                txtRemarks.Text = Conns.mySqlDataReader["remarks"].ToString();
            }

        }

        private void dgvTransactionIn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (Information.IsNumeric(dgvTransactionPO.Rows[e.RowIndex].Cells[1].Value))
            {
                TransactionID = Convert.ToInt32(dgvTransactionPO.Rows[e.RowIndex].Cells[1].Value);
                if (TransactionID > 0)
                {
                    MySqlConnect Conns = new MySqlConnect();
                    SQLStatement = "SELECT product_id, barcode, sku, item_name, unit_of_measure, quantity, unit_price, total_amount FROM tbl_purchase_order_transactions WHERE transaction_id =" + TransactionID + " AND status = 'Active'";
                    dgvTransactionPO_details.Rows.Clear();
                    Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
                    Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                    while (Conns.mySqlDataReader.Read())
                    {
                        i++;
                        dgvTransactionPO_details.Rows.Add(i,
                            Conns.mySqlDataReader["product_id"].ToString(),
                            Conns.mySqlDataReader["barcode"].ToString(),
                            Conns.mySqlDataReader["sku"].ToString(),
                            Conns.mySqlDataReader["item_name"].ToString(),
                            Conns.mySqlDataReader["unit_of_measure"].ToString(),
                            Conns.mySqlDataReader["quantity"].ToString(),
                            Conns.mySqlDataReader["unit_price"].ToString(),
                            Conns.mySqlDataReader["total_amount"].ToString());
                    }
                    Conns.mySqlconn.Close();
                    InventoryInForm();
                }
                else
                {
                    dgvTransactionPO_details.Rows.Clear();
                }
            }
            else
            {
                dgvTransactionPO_details.Rows.Clear();
            }

        }

        private void btnEditTransaction_Click(object sender, EventArgs e)
        {
            if (TransactionID > 0)
            {

                frmInventory_PurchaseOrder_AddNewTransaction frmInventory_PurchaseOrder_AddNewTransaction = new frmInventory_PurchaseOrder_AddNewTransaction();
                frmInventory_PurchaseOrder_AddNewTransaction.AddorEditorEditProduct = "Edit";
                frmInventory_PurchaseOrder_AddNewTransaction.TransactionID = TransactionID;
                frmInventory_PurchaseOrder_AddNewTransaction.ShowDialog();
            }
            else
            {
                new classMsgBox().showMsgError("Please select a record first before you edit it!");
                control_Docking.ClearUserControls(frmInventory_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
                control_Docking.DockControl_InventorySystem(new ucInventory_PurchaseOrder()); // Loads the target user control in docked mode
            }

        }
    }
}
