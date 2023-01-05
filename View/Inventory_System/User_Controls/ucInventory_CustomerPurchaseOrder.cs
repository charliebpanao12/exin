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
    public partial class ucInventory_CustomerPurchaseOrder : UserControl
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
        public int POID;
        public string DateofDelivery;
        public string TimeofDelivery;
        double TotalQuantity;

        public ucInventory_CustomerPurchaseOrder()
        {        
            InitializeComponent();
            dtpDateFrom.Value = DateTime.Now;
            dtpDateTo.Value = DateTime.Now;
            dtpCustomerPODate.Value = DateTime.Now;


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
            dtpCustomerPODate.FillColor = Global.themeColor1;
            dtpCustomerPODate.BorderColor = Global.themeColor1;
            dtpCustomerPODate.CustomFormat = "MMMM dd, yyyy";

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
            dgvTransactionCustomerPO.Rows.Clear();
            dgvTransactionCustomerPO_details.Rows.Clear();
        }
        private void LoadData()
        {
            TotalQuantity = 0;
            POID = 0;

            MySqlConnect Conns = new MySqlConnect();
            DateFrom = dtpDateFrom.Value;
            DateTo = dtpDateTo.Value;
            queryDateFrom = DateFrom.ToString("yyyy-MM-dd");
            queryDateTo = DateTo.ToString("yyyy-MM-dd");
            if (DateFrom <= DateTo)
            {
                SQLStatement = "SELECT T1.po_id, T1.po_date, T1.customer_id, T2.customer_name, T1.product_id, T1.total_quantity, T2.phone, T2.address, T2.business_style, T1.prepared_by, T1.acknowledged_by, T1.order_status FROM" +
                               "(SELECT po_id, po_date, customer_id, product_id, SUM(order_quantity)AS total_quantity, prepared_by, acknowledged_by, order_status, record_status FROM tbl_inventory_customer_po WHERE DATE(po_date) BETWEEN '" + queryDateFrom + "' AND '" + queryDateTo + "' AND record_status<>'Deleted' GROUP BY po_id) as T1 " +
                               "LEFT JOIN (SELECT AutoNum, customer_name, business_style, phone, address, record_status FROM tbl_inventory_customer_list) as T2 on T1.customer_id = T2.AutoNum ORDER BY T1.po_date DESC ";
            }
            dgvTransactionCustomerPO.Rows.Clear();
            dgvTransactionCustomerPO_details.Rows.Clear();

            Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(Conns.mySqlDataReader);

            int NumberOfResults = dt.Rows.Count; //recordCount = ds.Tables("records").Rows.Count
            if (NumberOfResults > 0)
            {
                Conns.mySqlDataReader.Close();
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();

                DateofDelivery = "1990-01-01";

                while (Conns.mySqlDataReader.Read())
                {
                    // Validate if the row is same date with the previous row. If not, show the total quantity as new row
                    if (dgvTransactionCustomerPO.Rows.Count>0)
                    {
                        if (DateofDelivery != Conns.mySqlDataReader.GetDateTime("po_date").ToShortDateString())
                        {
                            dgvTransactionCustomerPO.Rows.Add(i, "Total Quantity", "", Math.Round(TotalQuantity));
                            TotalQuantity = 0;  // Reset the total quantity to zero
                        }
                    }

                    // Validate if the row is same date with the previous row
                    if (DateofDelivery != Conns.mySqlDataReader.GetDateTime("po_date").ToShortDateString())
                    {
                        DateofDelivery = Conns.mySqlDataReader.GetDateTime("po_date").ToShortDateString();
                        dgvTransactionCustomerPO.Rows.Add(0, "", DateofDelivery, "");
                    }

                    // Get the value of time and total quantity
                    TimeofDelivery = Conns.mySqlDataReader.GetDateTime("po_date").ToShortTimeString();
                    TotalQuantity += Convert.ToDouble(Conns.mySqlDataReader["total_quantity"].ToString());

                    // Show the record as new row to datagrid
                    dgvTransactionCustomerPO.Rows.Add(i, Conns.mySqlDataReader["po_id"].ToString(), TimeofDelivery, Conns.mySqlDataReader["total_quantity"].ToString());

                    i++;
                }

                dgvTransactionCustomerPO.Rows.Add(i, "Total Quantity", "", Math.Round(TotalQuantity)); // Show the total quantity at the end of the row
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
            frmInventory_CustomerPurchaseOrder_AddNewTransaction frmInventory_CustomerPurchaseOrder_AddNewTransaction = new frmInventory_CustomerPurchaseOrder_AddNewTransaction();
            frmInventory_CustomerPurchaseOrder_AddNewTransaction.AddorEditorEditProduct = "Add";
            frmInventory_CustomerPurchaseOrder_AddNewTransaction.ShowDialog();
        }

         
        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            MySqlConnect Conns = new MySqlConnect();
            if (POID > 0)
            {
                new classMsgBox().showMsgConfirmation_Delete("Do you really want to delete this record?");
                if (Global.msgConfirmation == true)
                {
                    // your codes here when the OK button has been pressed
                    Conns.mySqlCmd = new MySqlCommand("update tbl_inventory_customer_po set record_status = 'Deleted' WHERE po_id =" + POID, Conns.mySqlconn);
                    Conns.mySqlCmd.ExecuteNonQuery();
                    new classMsgBox().showMsgSuccessful("Deleted Successfully");
                }
                Application.OpenForms["frmInventory_ParentContainer"].Activate(); // Bring the parent form to the front
            }
            else
            {
                new classMsgBox().showMsgError("Please select a record first before you delete it!");
                control_Docking.ClearUserControls(frmInventory_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
                control_Docking.DockControl_InventorySystem(new ucInventory_CustomerPurchaseOrder()); // Loads the target user control in docked mode
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search = txtSearch.Text;
            dgvTransactionCustomerPO.Rows.Clear();
     
            if (Search != null || Search != " ")
            {
                MySqlConnect Conns = new MySqlConnect();
                int i = 0;
                SQLStatement = "SELECT po_id, po_date, customer_id, product_id, order_quantity, SUM(order_quantity) AS total_quantity, order_status FROM tbl_inventory_customer_po WHERE po_id = '" + Search + "' OR product_id = '" + Search + "' AND order_status != 'Deleted' GROUP BY po_id ORDER BY po_id DESC";

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
                                DateofDelivery = Conns.mySqlDataReader.GetDateTime("po_date").ToShortDateString();
                                TimeofDelivery = Conns.mySqlDataReader.GetDateTime("po_date").ToShortTimeString();
                                i++;
                                dgvTransactionCustomerPO.Rows.Add(i, "", DateofDelivery, "");
                                dgvTransactionCustomerPO.Rows.Add(i, Conns.mySqlDataReader["po_id"].ToString(), TimeofDelivery, Conns.mySqlDataReader["order_quantity"].ToString());
                                TotalQuantity += TotalQuantity + Convert.ToDouble(Conns.mySqlDataReader["order_quantity"].ToString());
                                dgvTransactionCustomerPO.Rows.Add(i, "Total Quantity", "", Math.Round(TotalQuantity));

                            }
                  
                }
                else
                {
                    //new classMsgBox().showMsgError("No record found!");
                    control_Docking.ClearUserControls(frmInventory_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
                    control_Docking.DockControl_InventorySystem(new ucInventory_CustomerPurchaseOrder()); // Loads the target user control in docked mode
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
            control_Docking.DockControl_InventorySystem(new ucInventory_CustomerPurchaseOrder()); // Loads the target user control in docked mode
        }

        private void InventoryInForm()
        {
            MySqlConnect Conns = new MySqlConnect();
            SQLStatement = "SELECT T1.po_id, T1.po_date, T1.customer_id, T1.product_id, T1.prepared_by, T1.acknowledged_by, T1.order_status, T2.customer_name, T2.business_style, T2.phone, T2.address, T1.record_status FROM" +
                "(SELECT po_id, po_date, customer_id, product_id, prepared_by, acknowledged_by, order_status, record_status FROM tbl_inventory_customer_po WHERE po_id = " + POID + " AND record_status = 'Active') AS T1 " +
                "LEFT JOIN (SELECT AutoNum, customer_name, business_style, phone, address, record_status FROM tbl_inventory_customer_list WHERE record_status = 'Active') AS T2 ON T1.customer_id = T2.AutoNum";

            //SQLStatement = "SELECT T1.AutoNum, T1.customer_name, T1.phone, T1.address, T1.business_style, T2.po_id, T2.po_date, T2.product_id, T2.prepared_by, T2.acknowledged_by, T2.order_status FROM" +
            //    "(SELECT AutoNum, customer_name, business_style, phone, address, record_status FROM tbl_inventory_customer_list ) as T1 " +
            //   "LEFT JOIN (SELECT po_id, po_date, customer_id, product_id, SUM(order_quantity)AS total_quantity, prepared_by, acknowledged_by, order_status, record_status FROM tbl_inventory_customer_po ORDER BY po_date DESC ) as T2 on T1.AutoNum = T2.customer_id WHERE T2.po_id = " + POID + " AND T2.record_status = 'Active'";

            Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
            while (Conns.mySqlDataReader.Read())
            {
                TimeofDelivery = Conns.mySqlDataReader.GetDateTime("po_date").ToShortTimeString();
                txtCustomerPOID.Text = Conns.mySqlDataReader["po_id"].ToString();
                dtpCustomerPODate.Text = Conns.mySqlDataReader["po_date"].ToString();
                txtCustomerPOTime.Text = TimeofDelivery;
                txtCustomerID.Text = Conns.mySqlDataReader["customer_id"].ToString();
                txtCustomerName.Text = Conns.mySqlDataReader["customer_name"].ToString();
                txtPhone.Text = Conns.mySqlDataReader["phone"].ToString();
                txtAddress.Text = Conns.mySqlDataReader["address"].ToString();
                txtBusinessStyle.Text = Conns.mySqlDataReader["business_style"].ToString();
                txtPreparedBy.Text = Conns.mySqlDataReader["prepared_by"].ToString();
                txtAcknowledgedBy.Text = Conns.mySqlDataReader["acknowledged_by"].ToString();
                txtOrderStatus.Text = Conns.mySqlDataReader["order_status"].ToString();
            }
            Conns.mySqlconn.Close();
        }


        private void btnEditTransaction_Click(object sender, EventArgs e)
        {
            if (POID > 0)
            {

                frmInventory_CustomerPurchaseOrder_AddNewTransaction frmInventory_CustomerPurchaseOrder_AddNewTransaction = new frmInventory_CustomerPurchaseOrder_AddNewTransaction();
                frmInventory_CustomerPurchaseOrder_AddNewTransaction.AddorEditorEditProduct = "Edit";
                frmInventory_CustomerPurchaseOrder_AddNewTransaction.POID = POID;
                frmInventory_CustomerPurchaseOrder_AddNewTransaction.ShowDialog();
            }
            else
            {
                new classMsgBox().showMsgError("Please select a record first before you edit it!");
                control_Docking.ClearUserControls(frmInventory_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
                control_Docking.DockControl_InventorySystem(new ucInventory_CustomerPurchaseOrder()); // Loads the target user control in docked mode
            }

        }

        private void InventoryInFormPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvTransactionCustomerPO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Information.IsNumeric(dgvTransactionCustomerPO.Rows[e.RowIndex].Cells[1].Value))
            {
                POID = Convert.ToInt32(dgvTransactionCustomerPO.Rows[e.RowIndex].Cells[1].Value);
                if (POID > 10000000)
                {
                    MySqlConnect Conns = new MySqlConnect();
                    SQLStatement = "SELECT T1.product_id, T1.bar_code, T1.sku, T1.item_name, T1.unit_of_measure, T2.po_id, T2.order_quantity, T1.unit_cost, (T2.order_quantity * T1.unit_cost) AS total_amount FROM " +
                        "(SELECT product_id, bar_code, sku, inventory_type, item_category, item_name, item_description, unit_of_measure, unit_cost, selling_price, item_color, item_brand, item_variant, item_size, beginning_inventory, actual_count FROM tbl_inventory_products_masterlist WHERE unit_code = '" + Global.inventoryBusinessUnitCode + "' AND status = 'Active') as T1 " +
                        "LEFT JOIN (SELECT po_id, po_date, customer_id, product_id, order_quantity, prepared_by, acknowledged_by, order_status, record_status FROM tbl_inventory_customer_po) AS T2 ON T1.product_id = T2.product_id WHERE T2.po_id =" + POID + " AND T2.record_status = 'Active'";
                    dgvTransactionCustomerPO_details.Rows.Clear();
                    Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
                    Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();

                    while (Conns.mySqlDataReader.Read())
                    {
                        i++;
                        dgvTransactionCustomerPO_details.Rows.Add(i,
                            Conns.mySqlDataReader["product_id"].ToString(),
                            Conns.mySqlDataReader["bar_code"].ToString(),
                            Conns.mySqlDataReader["sku"].ToString(),
                            Conns.mySqlDataReader["item_name"].ToString(),
                            Conns.mySqlDataReader["unit_of_measure"].ToString(),
                            Conns.mySqlDataReader["order_quantity"].ToString(),
                            Conns.mySqlDataReader["unit_cost"].ToString(),
                            Conns.mySqlDataReader["total_amount"].ToString());
                    }
                    InventoryInForm();
                    Conns.mySqlconn.Close();
                }
                else
                {
                    dgvTransactionCustomerPO_details.Rows.Clear();
                }
            }
            else
            {
                dgvTransactionCustomerPO_details.Rows.Clear();
            }
        }
    }
}
