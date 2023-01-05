using EXIN.Controller;
using EXIN.View.Point_Of_Sales.Reports;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
//using System.Reflection;
using System.Windows.Forms;

namespace EXIN.Point_Of_Sales
{
    public partial class ucPOS_NewTransaction : UserControl
    {
        public static String addViewEdit;
        public static int transactionID;

        public String filterProductID = "";
        public string filterCategory = "";

        public ucPOS_NewTransaction()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            InitializeThemes();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        public void InitializeThemes()
        {
            //// Controls - Textbox 3
            //txtSearch.BorderColor = Global.themeColor1;
            //txtSearch.FocusedState.BorderColor = Global.themeColor2;
            //txtSearch.HoverState.BorderColor = Global.themeColor2;

            // Controls - ComboBox
            cboTable.BorderColor = Global.themeColor1;
            cboTable.FocusedState.BorderColor = Global.themeColor2;
            cboTable.HoverState.BorderColor = Global.themeColor2;
        }

        private void ucPOS_NewTransaction_Load(object sender, EventArgs e)
        {
            // Main Code
            zeroitSmoothAnimator1.Start();

            clearFields();
            loadCategories();
            //loadItems_Menu();

            if (addViewEdit == "Edit")
            {
                loadTransactionDetails();
                btnClearItems.Enabled = false;
            }
        }

        private void clearFields()
        {
            txtSearch.Text = "";
            lblChooseItems.Text = "Choose Items";
            cboTable.Text = "Table 01";
            btnDineIn.Checked = true;
            btnTakeOut.Checked = false;
            btnClearItems.Enabled = true;
        }

        private void loadCategories()
        {
            panelCategories.Controls.Clear(); // Clear the container first            

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT DISTINCT item_category FROM tbl_inventory_products_masterlist WHERE category_code='" + Global.posBusinessCategoryCode + "' AND unit_code=" + Global.posBusinessUnitCode + " ORDER BY item_category ASC;", Conns.mySqlconn);     // Create a query command
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command, then store the results to a Data Reader

            DataTable mySqlDataTable = new DataTable(); // Create Data Table
            mySqlDataTable.Load(Conns.mySqlDataReader); // Pass the content from Data Reader to Data Table
            int numRows = mySqlDataTable.Rows.Count;    // Get the total records found

            if (numRows > 0)
            {
                int i = 1;
                Conns.mySqlDataReader.Close();  // Close the Data Reader
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySql command again to store the records to Data Reader

                while (Conns.mySqlDataReader.Read())    // Loop the records
                {
                    ucPOS_NewTransaction_Category ucPOS_NewTransaction_Category = new ucPOS_NewTransaction_Category();
                    ucPOS_NewTransaction_Category.Dock = DockStyle.Top;
                    ucPOS_NewTransaction_Category.category = Conns.mySqlDataReader["item_category"].ToString();
                    panelCategories.Controls.Add(ucPOS_NewTransaction_Category);
                    ucPOS_NewTransaction_Category.BringToFront();
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database
        }

        public void loadItems_Menu()
        {
            // Preloader - Ready
            var loader = new WaitFormFunc();

            string query = "";
            query = "SELECT * FROM tbl_inventory_products_masterlist WHERE category_code='" + Global.posBusinessCategoryCode + "' AND unit_code=" + Global.posBusinessUnitCode + " AND item_category LIKE '" + filterCategory + "%' ORDER BY item_name ASC;";

            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand(query, Conns.mySqlconn);     // Create a query command
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command, then store the results to a Data Reader

            DataTable mySqlDataTable = new DataTable(); // Create Data Table
            mySqlDataTable.Load(Conns.mySqlDataReader); // Pass the content from Data Reader to Data Table
            int numRows = mySqlDataTable.Rows.Count;    // Get the total records found

            fpanelItemList.Controls.Clear(); // Clear the container first   

            if (numRows > 0)
            {
                if (numRows > 5)    // Preloader - Start 
                { loader.ShowSmall(); }

                int i = 1;
                Conns.mySqlDataReader.Close();  // Close the Data Reader
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySql command again to store the records to Data Reader

                while (Conns.mySqlDataReader.Read())    // Loop the records
                {
                    ucPOS_NewTransaction_Item ucPOS_NewTransaction_Item = new ucPOS_NewTransaction_Item();
                    //ucPOS_NewTransaction_Item.Dock = DockStyle.Top;
                    ucPOS_NewTransaction_Item.itemCode = Conns.mySqlDataReader["product_id"].ToString();
                    ucPOS_NewTransaction_Item.itemName = Conns.mySqlDataReader["item_name"].ToString();
                    ucPOS_NewTransaction_Item.itemUoM = Conns.mySqlDataReader["unit_of_measure"].ToString();
                    ucPOS_NewTransaction_Item.itemLandingCost = Convert.ToDouble(Conns.mySqlDataReader["landing_cost"].ToString());
                    ucPOS_NewTransaction_Item.itemUnitCost = Convert.ToDouble(Conns.mySqlDataReader["unit_cost"].ToString());
                    ucPOS_NewTransaction_Item.itemPrice = Convert.ToDouble(Conns.mySqlDataReader["selling_price"].ToString());
                    fpanelItemList.Controls.Add(ucPOS_NewTransaction_Item);
                    //ucPOS_NewTransaction_Item.BringToFront();
                    i++;
                }
            }
            Conns.closeConnection();    // !Important ->> Close the connection from the database

            // Preloader - Close
            loader.CloseSmall();
        }

        private void loadTransactionDetails()
        {
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT t1.transaction_id, t1.product_id, t1.sales_quantity, t1.landing_cost, t1.unit_cost, t1.selling_price, t2.table_number, t2.order_type, t3.item_name, t3.unit_of_measure FROM " +
                "(SELECT transaction_id, Category_Code, Unit_Code, product_id, sales_quantity, landing_cost, unit_cost, selling_price FROM tbl_pos_transactions_detailed WHERE Category_Code='" + Global.posBusinessCategoryCode + "' AND Unit_Code=" + Global.posBusinessUnitCode + " AND transaction_id=" + transactionID + ") AS t1 " +
                "LEFT JOIN (SELECT transaction_id, Category_Code, Unit_Code, table_number, order_type FROM tbl_pos_transactions WHERE Category_Code='" + Global.posBusinessCategoryCode + "' AND Unit_Code=" + Global.posBusinessUnitCode + " AND transaction_id=" + transactionID + ") AS t2 ON t1.transaction_id=t2.transaction_id " +
                "LEFT JOIN (SELECT product_id, item_name, unit_of_measure FROM tbl_inventory_products_masterlist) AS t3 ON t1.product_id=t3.product_id;", Conns.mySqlconn);     // Create a query command
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command, then store the results to a Data Reader

            DataTable mySqlDataTable = new DataTable(); // Create Data Table
            mySqlDataTable.Load(Conns.mySqlDataReader); // Pass the content from Data Reader to Data Table
            int numRows = mySqlDataTable.Rows.Count;    // Get the total records found

            if (numRows > 0)
            {
                //MessageBox.Show("Hello World: " + numRows);
                int i = 1;
                Conns.mySqlDataReader.Close();  // Close the Data Reader
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySql command again to store the records to Data Reader

                while (Conns.mySqlDataReader.Read())    // Loop the records
                {
                    // Load the items to the cart
                    ucPOS_NewTransaction_CartItem ucPOS_NewTransaction_CartItem = new ucPOS_NewTransaction_CartItem();
                    ucPOS_NewTransaction_CartItem.Dock = DockStyle.Top;
                    ucPOS_NewTransaction_CartItem.itemCode = Conns.mySqlDataReader["product_id"].ToString();
                    ucPOS_NewTransaction_CartItem.itemName = Conns.mySqlDataReader["item_name"].ToString();
                    ucPOS_NewTransaction_CartItem.itemUoM = Conns.mySqlDataReader["unit_of_measure"].ToString();
                    ucPOS_NewTransaction_CartItem.itemLandingCost = Convert.ToDouble(Conns.mySqlDataReader["landing_cost"].ToString());
                    ucPOS_NewTransaction_CartItem.itemUnitCost = Convert.ToDouble(Conns.mySqlDataReader["unit_cost"].ToString());
                    ucPOS_NewTransaction_CartItem.itemPrice = Convert.ToDouble(Conns.mySqlDataReader["selling_price"].ToString());
                    ucPOS_NewTransaction_CartItem.itemQuantity = Convert.ToDouble(Conns.mySqlDataReader["sales_quantity"].ToString());
                    panelCartItems.Controls.Add(ucPOS_NewTransaction_CartItem);
                    ucPOS_NewTransaction_CartItem.BringToFront();

                    i++;
                }
                cboTable.Text = "" + Conns.mySqlDataReader["table_number"].ToString();
                if (Conns.mySqlDataReader["order_type"].ToString() == "Dine In")
                {
                    panelDineInTakeOut.Visible = true;
                    btnDineIn.Checked = true;
                    btnTakeOut.Checked = false;
                }
                else if (Conns.mySqlDataReader["order_type"].ToString() == "Take Out")
                {
                    panelDineInTakeOut.Visible = true;
                    btnDineIn.Checked = false;
                    btnTakeOut.Checked = true;
                }
                else
                {
                    panelDineInTakeOut.Visible = false;
                }
            }
        }

        public void deleteItem()
        {
            for (var i = panelCartItems.Controls.Count - 1; i >= 0; i--)
            {
                if (panelCartItems.Controls[i] is ucPOS_NewTransaction_CartItem)
                {
                    ucPOS_NewTransaction_CartItem ucPOS_NewTransaction_CartItem = panelCartItems.Controls[i] as ucPOS_NewTransaction_CartItem;
                    if (ucPOS_NewTransaction_CartItem.deleteMe == true)
                    {
                        panelCartItems.Controls.Remove(panelCartItems.Controls[i]);
                        return;
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Find the specific item from the database then direct add to cart
                string query = "";
                query = "SELECT * FROM tbl_inventory_products_masterlist WHERE category_code='" + Global.posBusinessCategoryCode + "' AND unit_code=" + Global.posBusinessUnitCode + " AND product_id=" + txtSearch.Text.Trim() + " ORDER BY item_name ASC LIMIT 1;";

                MySqlConnect Conns = new MySqlConnect();    // Connect to the database
                Conns.mySqlCmd = new MySqlCommand(query, Conns.mySqlconn);     // Create a query command
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySQL command, then store the results to a Data Reader

                DataTable mySqlDataTable = new DataTable(); // Create Data Table
                mySqlDataTable.Load(Conns.mySqlDataReader); // Pass the content from Data Reader to Data Table
                int numRows = mySqlDataTable.Rows.Count;    // Get the total records found

                if (numRows > 0)
                {
                    int i = 1;
                    Conns.mySqlDataReader.Close();  // Close the Data Reader
                    Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();     // Execute the mySql command again to store the records to Data Reader

                    while (Conns.mySqlDataReader.Read())    // Loop the records
                    {
                        // Validate if the selected item is already in the cart
                        Boolean itemExist = false;
                        for (var j = panelCartItems.Controls.Count - 1; j >= 0; j--)
                        {
                            if (panelCartItems.Controls[j] is ucPOS_NewTransaction_CartItem)
                            {
                                ucPOS_NewTransaction_CartItem ucPOS_NewTransaction_CartItem = panelCartItems.Controls[j] as ucPOS_NewTransaction_CartItem;
                                if (Conns.mySqlDataReader["product_id"].ToString() == ucPOS_NewTransaction_CartItem.itemCode)
                                {
                                    ucPOS_NewTransaction_CartItem.addQuantity();
                                    itemExist = true;
                                    break;
                                }
                            }
                        }

                        if (itemExist == false)
                        {
                            ucPOS_NewTransaction_CartItem ucPOS_NewTransaction_CartItem = new ucPOS_NewTransaction_CartItem();
                            ucPOS_NewTransaction_CartItem.Dock = DockStyle.Top;
                            ucPOS_NewTransaction_CartItem.itemCode = Conns.mySqlDataReader["product_id"].ToString();
                            ucPOS_NewTransaction_CartItem.itemName = Conns.mySqlDataReader["item_name"].ToString();
                            ucPOS_NewTransaction_CartItem.itemUoM = Conns.mySqlDataReader["unit_of_measure"].ToString();
                            ucPOS_NewTransaction_CartItem.itemLandingCost = Convert.ToDouble(Conns.mySqlDataReader["landing_cost"].ToString());
                            ucPOS_NewTransaction_CartItem.itemUnitCost = Convert.ToDouble(Conns.mySqlDataReader["unit_cost"].ToString());
                            ucPOS_NewTransaction_CartItem.itemPrice = Convert.ToDouble(Conns.mySqlDataReader["selling_price"].ToString());

                            panelCartItems.Controls.Add(ucPOS_NewTransaction_CartItem);
                            ucPOS_NewTransaction_CartItem.BringToFront();
                        }

                        i++;
                    }
                }
                Conns.closeConnection();    // !Important ->> Close the connection from the database

                txtSearch.Text = "";
            }
        }

        private void btnDineIn_Click(object sender, EventArgs e)
        {
            btnDineIn.Checked = true;
            btnTakeOut.Checked = false;
        }

        private void btnTakeOut_Click(object sender, EventArgs e)
        {
            btnDineIn.Checked = false;
            btnTakeOut.Checked = true;
        }

        private void btnClearItems_Click(object sender, EventArgs e)
        {
            if (panelCartItems.Controls.Count == 0)
            {
                new classMsgBox().showMsgError("There are no items to clear");
                Application.OpenForms["frmPOS_ParentContainer"].Activate(); // Bring the parent form to the front
                return;
            }

            // Show confirmation box
            new classMsgBox().showMsgConfirmation_Delete("Do you want to clear all items?");
            if (Global.msgConfirmation == true)
            {
                Application.OpenForms["frmPOS_ParentContainer"].Activate(); // Bring the parent form to the front
                panelCartItems.Controls.Clear();
            }
            Application.OpenForms["frmPOS_ParentContainer"].Activate(); // Bring the parent form to the front            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (panelCartItems.Controls.Count == 0)
            {
                new classMsgBox().showMsgError("There are no items to be saved");
                Application.OpenForms["frmPOS_ParentContainer"].Activate(); // Bring the parent form to the front
                return;
            }

            saveTransaction();
        }

        private void saveTransaction()
        {
            // Show confirmation box
            new classMsgBox().showMsgConfirmation("Do you want to continue?");
            if (Global.msgConfirmation == true)
            {
                // Validate if the transaction is NEW or for EDIT
                if (addViewEdit == "Add")
                {
                    transactionID = classGlobalFunctions.generateNewID(10000001, "transaction_id", "SELECT transaction_id FROM tbl_pos_transactions WHERE Category_Code='" + Global.posBusinessCategoryCode + "' AND Unit_Code=" + Global.posBusinessUnitCode + " ORDER BY transaction_id DESC LIMIT 1;");
                }
                else if (addViewEdit == "Edit")
                {
                    MySqlConnect Conns2 = new MySqlConnect();    // Connect to the database 
                    Conns2.mySqlCmd = new MySqlCommand("DELETE FROM tbl_pos_transactions WHERE Category_Code='" + Global.posBusinessCategoryCode + "' AND Unit_Code=" + Global.posBusinessUnitCode + " AND transaction_id=" + transactionID + ";", Conns2.mySqlconn);     // Create a query command 
                    Conns2.mySqlDataReader = Conns2.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns2.closeConnection();    // !Important ->> Close the connection from the database

                    MySqlConnect Conns3 = new MySqlConnect();    // Connect to the database 
                    Conns3.mySqlCmd = new MySqlCommand("DELETE FROM tbl_pos_transactions_detailed WHERE Category_Code='" + Global.posBusinessCategoryCode + "' AND Unit_Code=" + Global.posBusinessUnitCode + " AND transaction_id=" + transactionID + ";", Conns3.mySqlconn);     // Create a query command 
                    Conns3.mySqlDataReader = Conns3.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                    Conns3.closeConnection();    // !Important ->> Close the connection from the database
                }

                // Save the transaction record to database
                MySqlConnect Conns4 = new MySqlConnect();    // Connect to the database 
                Conns4.mySqlCmd = new MySqlCommand("INSERT INTO tbl_pos_transactions(transaction_id, Category_Code, Unit_Code, transaction_type, transaction_date, transaction_time, table_number, order_type, cashier, status, date_recorded) " +
                    "VALUES (@transaction_id, @Category_Code, @Unit_Code, @transaction_type, @transaction_date, @transaction_time, @table_number, @order_type, @cashier, @status, @date_recorded);", Conns4.mySqlconn);     // Create a query command                    
                Conns4.mySqlCmd.Parameters.AddWithValue("transaction_id", transactionID);
                Conns4.mySqlCmd.Parameters.AddWithValue("Category_Code", Global.posBusinessCategoryCode);
                Conns4.mySqlCmd.Parameters.AddWithValue("Unit_Code", Global.posBusinessUnitCode);
                Conns4.mySqlCmd.Parameters.AddWithValue("transaction_type", "POS");
                Conns4.mySqlCmd.Parameters.AddWithValue("transaction_date", DateTime.Now.ToString("yyyy-MM-dd"));
                Conns4.mySqlCmd.Parameters.AddWithValue("transaction_time", DateTime.Now.ToShortTimeString());
                Conns4.mySqlCmd.Parameters.AddWithValue("table_number", cboTable.Text);
                if (panelDineInTakeOut.Visible == true)
                {
                    if (btnDineIn.Checked == true)
                    {
                        Conns4.mySqlCmd.Parameters.AddWithValue("order_type", "Dine In");
                    }
                    else if (btnTakeOut.Checked == true)
                    {
                        Conns4.mySqlCmd.Parameters.AddWithValue("order_type", "Take Out");
                    }
                }
                else
                {
                    Conns4.mySqlCmd.Parameters.AddWithValue("order_type", "N/A");
                }
                Conns4.mySqlCmd.Parameters.AddWithValue("cashier", Global.displayName);
                Conns4.mySqlCmd.Parameters.AddWithValue("Status", "Active");
                Conns4.mySqlCmd.Parameters.AddWithValue("date_recorded", DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToShortTimeString());
                Conns4.mySqlDataReader = Conns4.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                Conns4.closeConnection();    // !Important ->> Close the connection from the database

                // Loop the items from the cart then save to transaction details
                for (var i = panelCartItems.Controls.Count - 1; i >= 0; i--)
                {
                    if (panelCartItems.Controls[i] is ucPOS_NewTransaction_CartItem)
                    {
                        ucPOS_NewTransaction_CartItem ucPOS_NewTransaction_CartItem = panelCartItems.Controls[i] as ucPOS_NewTransaction_CartItem;

                        MySqlConnect Conns5 = new MySqlConnect();    // Connect to the database 
                        Conns5.mySqlCmd = new MySqlCommand("INSERT INTO tbl_pos_transactions_detailed(transaction_id, Category_Code, Unit_Code, product_id, sales_quantity, landing_cost, unit_cost, selling_price) " +
                            "VALUES (@transaction_id, @Category_Code, @Unit_Code, @product_id, @sales_quantity, @landing_cost, @unit_cost, @selling_price);", Conns5.mySqlconn);     // Create a query command                    
                        Conns5.mySqlCmd.Parameters.AddWithValue("transaction_id", transactionID);
                        Conns5.mySqlCmd.Parameters.AddWithValue("Category_Code", Global.posBusinessCategoryCode);
                        Conns5.mySqlCmd.Parameters.AddWithValue("Unit_Code", Global.posBusinessUnitCode);
                        Conns5.mySqlCmd.Parameters.AddWithValue("product_id", ucPOS_NewTransaction_CartItem.itemCode);
                        Conns5.mySqlCmd.Parameters.AddWithValue("sales_quantity", ucPOS_NewTransaction_CartItem.itemQuantity);
                        Conns5.mySqlCmd.Parameters.AddWithValue("landing_cost", ucPOS_NewTransaction_CartItem.itemLandingCost);
                        Conns5.mySqlCmd.Parameters.AddWithValue("unit_cost", ucPOS_NewTransaction_CartItem.itemUnitCost);
                        Conns5.mySqlCmd.Parameters.AddWithValue("selling_price", ucPOS_NewTransaction_CartItem.itemPrice);
                        Conns5.mySqlDataReader = Conns5.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                        Conns5.closeConnection();    // !Important ->> Close the connection from the database
                    }
                }

                printOrders(transactionID); // Print order slip

                // Show message if the transaction is successful
                new classMsgBox().showMsgSuccessful("Transaction has been saved");
                Application.OpenForms["frmPOS_ParentContainer"].Activate(); // Bring the parent form to the front

                // Go back to transaction records
                var targetForm = Application.OpenForms.OfType<frmPOS_ParentContainer>().Single();
                targetForm.Controls["panelContainer"].Controls.Clear();
                ucPOS_TransactionRecords ucPOS_TransactionRecords = new ucPOS_TransactionRecords();
                ucPOS_TransactionRecords.Dock = DockStyle.Fill;
                targetForm.Controls["panelContainer"].Controls.Add(ucPOS_TransactionRecords);
            }
            Application.OpenForms["frmPOS_ParentContainer"].Activate(); // Bring the parent form to the front 
        }

        private void printOrders(int varTransactionID)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Declaring Variables
                var varDataTable = new DataTable();

                // Preparing the columns of varDataTable
                #region varDataTable
                varDataTable.Columns.Add("DataColumn1");
                varDataTable.Columns.Add("DataColumn2");
                varDataTable.Columns.Add("DataColumn3");
                varDataTable.Columns.Add("DataColumn4");
                varDataTable.Columns.Add("DataColumn5");
                varDataTable.Columns.Add("DataColumn6");
                varDataTable.Columns.Add("DataColumn7");
                varDataTable.Columns.Add("DataColumn8");
                varDataTable.Columns.Add("DataColumn9");
                varDataTable.Columns.Add("DataColumn10");
                varDataTable.Columns.Add("DataColumn11");
                varDataTable.Columns.Add("DataColumn12");
                varDataTable.Columns.Add("DataColumn13");
                varDataTable.Columns.Add("DataColumn14");
                varDataTable.Columns.Add("DataColumn15");
                varDataTable.Columns.Add("DataColumn16");
                varDataTable.Columns.Add("DataColumn17");
                varDataTable.Columns.Add("DataColumn18");
                varDataTable.Columns.Add("DataColumn19");
                varDataTable.Columns.Add("DataColumn20");
                varDataTable.Columns.Add("DataColumn21");
                varDataTable.Columns.Add("DataColumn22");
                varDataTable.Columns.Add("DataColumn23");
                varDataTable.Columns.Add("DataColumn24");
                varDataTable.Columns.Add("DataColumn25");
                varDataTable.Columns.Add("DataColumn26");
                varDataTable.Columns.Add("DataColumn27");
                varDataTable.Columns.Add("DataColumn28");
                varDataTable.Columns.Add("DataColumn29");
                varDataTable.Columns.Add("DataColumn30");
                varDataTable.Columns.Add("DataColumn31");
                varDataTable.Columns.Add("DataColumn32");
                varDataTable.Columns.Add("DataColumn33");
                varDataTable.Columns.Add("DataColumn34");
                varDataTable.Columns.Add("DataColumn35");
                varDataTable.Columns.Add("DataColumn36");
                varDataTable.Columns.Add("DataColumn37");
                varDataTable.Columns.Add("DataColumn38");
                varDataTable.Columns.Add("DataColumn39");
                varDataTable.Columns.Add("DataColumn40");
                varDataTable.Columns.Add("DataColumn41");
                varDataTable.Columns.Add("DataColumn42");
                varDataTable.Columns.Add("DataColumn43");
                varDataTable.Columns.Add("DataColumn44");
                varDataTable.Columns.Add("DataColumn45");
                varDataTable.Columns.Add("DataColumn46");
                varDataTable.Columns.Add("DataColumn47");
                varDataTable.Columns.Add("DataColumn48");
                varDataTable.Columns.Add("DataColumn49");
                varDataTable.Columns.Add("DataColumn50");
                #endregion;

                // Passing the data to varDataTable
                for (var i = panelCartItems.Controls.Count - 1; i >= 0; i--)
                {
                    if (panelCartItems.Controls[i] is ucPOS_NewTransaction_CartItem)
                    {
                        ucPOS_NewTransaction_CartItem ucPOS_NewTransaction_CartItem = panelCartItems.Controls[i] as ucPOS_NewTransaction_CartItem;

                        varDataTable.Rows.Add(
                            "• " + ucPOS_NewTransaction_CartItem.itemName,
                            "" + ucPOS_NewTransaction_CartItem.itemQuantity + " " + ucPOS_NewTransaction_CartItem.itemUoM,
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "");
                    }
                }

                // Preparing for printing
                CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                //reportDocument.Load(Application.StartupPath + "/Resources/Point_Of_Sales/CrystalReport1.rpt");
                reportDocument = new crptPOS_SalesOrder_Slip();
                reportDocument.SetDataSource(varDataTable);

                // Setting Parameters
                reportDocument.SetParameterValue("parCorporationName", Global.posCorpName);
                reportDocument.SetParameterValue("parBusinessUnitName", Global.posBusinessUnitName);
                reportDocument.SetParameterValue("parBusinessUnitAddress", Global.posBusinessUnitAddress);
                reportDocument.SetParameterValue("parBusinessUnitTIN", "TIN: " + Global.posBusinessUnitTIN);
                reportDocument.SetParameterValue("parTransNo", varTransactionID);
                reportDocument.SetParameterValue("parDate", DateTime.Now.ToString("yyyy-MM-dd"));
                if (panelDineInTakeOut.Visible == true)
                {
                    if (btnDineIn.Checked == true)
                    {
                        reportDocument.SetParameterValue("parOrderType", "Dine In");
                    }
                    else if (btnTakeOut.Checked == true)
                    {
                        reportDocument.SetParameterValue("parOrderType", "Take Out");
                    }
                }
                else
                {
                    reportDocument.SetParameterValue("parOrderType", "N/A");
                }

                reportDocument.SetParameterValue("parTableNo", cboTable.Text);

                // Printing the document
                reportDocument.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                reportDocument.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
            }
        }
    }
}
