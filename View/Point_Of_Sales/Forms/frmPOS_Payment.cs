using EXIN.Controller;
using EXIN.View.Point_Of_Sales.Reports;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EXIN.Point_Of_Sales
{
    public partial class frmPOS_Payment : Form
    {
        public static int transactionID;
        double totalAmount;

        // Prepare the variables
        double netOfVAT = 0;
        double discountAmount = 0;
        double vatAmount = 0;
        double totalSalesAmount = 0;
        double totalAmountDue = 0;
        double paymentAmount = 0;
        double totalChangeAmount = 0;

        public frmPOS_Payment()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            //// Controls - Button 3
            //btnClose.FillColor = Global.themeColor1;
            //btnClose.FillColor2 = Global.themeColor2;

            //// Controls - Button 3
            //btnBilling.FillColor = Global.themeColor1;
            //btnBilling.FillColor2 = Global.themeColor2;

            //// Controls - Button 3
            //btnSave.FillColor = Global.themeColor1;
            //btnSave.FillColor2 = Global.themeColor2;
        }

        private void frmPOS_Payment_Load(object sender, EventArgs e)
        {
            // Preloader - Ready
            var loader = new WaitFormFunc();

            // Preloader - Start
            loader.ShowSmall();

            //***** Main Code
            zeroitSmoothAnimator1.Start();

            clearFields();
            loadDetails();

            // Preloader - Close
            loader.CloseSmall();
        }

        private void clearFields()
        {
            lblTotalAmount.Text = "0.00";
            cboDiscount.Text = "No Discount";
            cboPaymentMethod.Text = "Cash";
            numtxtDiscountAmount.Value = 0;
            numtxtPaymentAmount.Value = 0;
            numtxtChange.Value = 0;
        }

        private void loadDetails()
        {
            MySqlConnect Conns = new MySqlConnect();    // Connect to the database
            Conns.mySqlCmd = new MySqlCommand("SELECT t1.transaction_id, t1.product_id, t1.sales_quantity, t1.landing_cost, t1.unit_cost, t1.selling_price, t2.table_number, t2.order_type, t2.net_of_vat, t2.vat_amount, t2.total_sales_amount, t2.discount_type, t2.discount_amount, t2.total_amount_due, t2.payment_amount, t2.payment_method, t2.change_amount, t3.item_name, t3.unit_of_measure FROM " +
                "(SELECT transaction_id, Category_Code, Unit_Code, product_id, sales_quantity, landing_cost, unit_cost, selling_price FROM tbl_pos_transactions_detailed WHERE Category_Code='" + Global.posBusinessCategoryCode + "' AND Unit_Code=" + Global.posBusinessUnitCode + " AND transaction_id=" + transactionID + ") AS t1 " +
                "LEFT JOIN (SELECT transaction_id, Category_Code, Unit_Code, table_number, order_type, net_of_vat, vat_amount, total_sales_amount, discount_type, discount_amount, total_amount_due, payment_amount, payment_method, change_amount FROM tbl_pos_transactions WHERE Category_Code='" + Global.posBusinessCategoryCode + "' AND Unit_Code=" + Global.posBusinessUnitCode + " AND transaction_id=" + transactionID + ") AS t2 ON t1.transaction_id=t2.transaction_id " +
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
                    ucPOS_NewTransaction_CartItem_2 ucPOS_NewTransaction_CartItem_2 = new ucPOS_NewTransaction_CartItem_2();
                    ucPOS_NewTransaction_CartItem_2.Dock = DockStyle.Top;
                    ucPOS_NewTransaction_CartItem_2.itemCode = Conns.mySqlDataReader["product_id"].ToString();
                    ucPOS_NewTransaction_CartItem_2.itemName = Conns.mySqlDataReader["item_name"].ToString();
                    ucPOS_NewTransaction_CartItem_2.itemUoM = Conns.mySqlDataReader["unit_of_measure"].ToString();
                    ucPOS_NewTransaction_CartItem_2.itemLandingCost = Convert.ToDouble(Conns.mySqlDataReader["landing_cost"].ToString());
                    ucPOS_NewTransaction_CartItem_2.itemUnitCost = Convert.ToDouble(Conns.mySqlDataReader["unit_cost"].ToString());
                    ucPOS_NewTransaction_CartItem_2.itemPrice = Convert.ToDouble(Conns.mySqlDataReader["selling_price"].ToString());
                    ucPOS_NewTransaction_CartItem_2.itemQuantity = Convert.ToDouble(Conns.mySqlDataReader["sales_quantity"].ToString());
                    panelCartItems.Controls.Add(ucPOS_NewTransaction_CartItem_2);
                    ucPOS_NewTransaction_CartItem_2.BringToFront();

                    totalAmount += Convert.ToDouble(Conns.mySqlDataReader["selling_price"].ToString()) * Convert.ToDouble(Conns.mySqlDataReader["sales_quantity"].ToString());
                    i++;
                }

                lblTransactionID.Text = "" + transactionID;
                lblTotalAmount.Text = "" + totalAmount.ToString("N2");
                cboDiscount.Text = Conns.mySqlDataReader["discount_type"].ToString();
                cboPaymentMethod.Text = Conns.mySqlDataReader["payment_method"].ToString();
                numtxtDiscountAmount.Value = Convert.ToDecimal(Conns.mySqlDataReader["discount_amount"].ToString());
                numtxtPaymentAmount.Value = Convert.ToDecimal(Conns.mySqlDataReader["payment_amount"].ToString());
                numtxtChange.Value = Convert.ToDecimal(Conns.mySqlDataReader["change_amount"].ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            printBilling(transactionID); // Print receipt
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            computeTotal(); // Recompute total

            if (Convert.ToDouble(numtxtPaymentAmount.Value) < totalAmountDue)
            {
                new classMsgBox().showMsgError("Insufficient payment amount");
                Application.OpenForms["frmPOS_Payment"].Activate(); // Bring the parent form to the front
                return;
            }

            saveTransaction();
        }

        private void cboDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            computeTotal();
        }

        private void cboPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numtxtPaymentAmount_Enter(object sender, EventArgs e)
        {
            numtxtPaymentAmount.ResetText();
        }

        private void numtxtPaymentAmount_ValueChanged(object sender, EventArgs e)
        {
            computeTotal();
        }

        private void btnBills_20_Click(object sender, EventArgs e)
        {
            numtxtPaymentAmount.Value = 20;
            computeTotal();
        }

        private void btnBills_50_Click(object sender, EventArgs e)
        {
            numtxtPaymentAmount.Value = 50;
            computeTotal();
        }

        private void btnBills_100_Click(object sender, EventArgs e)
        {
            numtxtPaymentAmount.Value = 100;
            computeTotal();
        }

        private void btnBills_200_Click(object sender, EventArgs e)
        {
            numtxtPaymentAmount.Value = 200;
            computeTotal();
        }

        private void btnBills_500_Click(object sender, EventArgs e)
        {
            numtxtPaymentAmount.Value = 500;
            computeTotal();
        }

        private void btnBills_1000_Click(object sender, EventArgs e)
        {
            numtxtPaymentAmount.Value = 1000;
            computeTotal();
        }

        private void computeTotal()
        {
            // Computation
            totalSalesAmount = totalAmount;

            // Net of VAT
            netOfVAT = totalSalesAmount / 1.12;

            // Discount
            if (cboDiscount.Text == "No Discount")
            {
                discountAmount = 0;
            }
            else if (cboDiscount.Text == "Senior Discount")
            {
                discountAmount = netOfVAT * 0.2;
            }
            else if (cboDiscount.Text == "PWD Discount")
            {
                discountAmount = netOfVAT * 0.2;
            }

            vatAmount = (netOfVAT - discountAmount) * 0.12;
            totalAmountDue = totalSalesAmount - discountAmount;
            paymentAmount = Convert.ToDouble(numtxtPaymentAmount.Value);
            totalChangeAmount = paymentAmount - totalAmountDue;
            if (totalChangeAmount < 0)
            {
                totalChangeAmount = 0;
            }

            lblTotalAmount.Text = "" + totalAmountDue.ToString("N2");
            numtxtDiscountAmount.Value = Convert.ToDecimal(discountAmount);
            numtxtChange.Value = Convert.ToDecimal(totalChangeAmount);
        }

        private void saveTransaction()
        {
            // Show confirmation box
            new classMsgBox().showMsgConfirmation("Do you want to continue?");
            if (Global.msgConfirmation == true)
            {
                DateTime transDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToShortTimeString());
                DateTime dateRecorded = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToShortTimeString());

                // Save the transaction record to database
                MySqlConnect Conns4 = new MySqlConnect();    // Connect to the database 
                Conns4.mySqlCmd = new MySqlCommand("UPDATE tbl_pos_transactions SET transaction_date=@transaction_date, transaction_time=@transaction_time, net_of_vat=@net_of_vat, vat_amount=@vat_amount, total_sales_amount=@total_sales_amount, discount_type=@discount_type, discount_amount=@discount_amount, total_amount_due=@total_amount_due, payment_amount=@payment_amount, payment_method=@payment_method, change_amount=@change_amount, cashier=@cashier WHERE transaction_id=@transaction_id AND Category_Code=@Category_Code AND Unit_Code=@Unit_Code;", Conns4.mySqlconn);     // Create a query command                    
                Conns4.mySqlCmd.Parameters.AddWithValue("transaction_id", transactionID);
                Conns4.mySqlCmd.Parameters.AddWithValue("Category_Code", Global.posBusinessCategoryCode);
                Conns4.mySqlCmd.Parameters.AddWithValue("Unit_Code", Global.posBusinessUnitCode);
                Conns4.mySqlCmd.Parameters.AddWithValue("transaction_date", transDate.ToString("yyyy-MM-dd"));
                Conns4.mySqlCmd.Parameters.AddWithValue("transaction_time", transDate.ToShortTimeString());
                Conns4.mySqlCmd.Parameters.AddWithValue("net_of_vat", netOfVAT);
                Conns4.mySqlCmd.Parameters.AddWithValue("vat_amount", vatAmount);
                Conns4.mySqlCmd.Parameters.AddWithValue("total_sales_amount", totalSalesAmount);
                Conns4.mySqlCmd.Parameters.AddWithValue("discount_type", cboDiscount.Text);
                Conns4.mySqlCmd.Parameters.AddWithValue("discount_amount", discountAmount);
                Conns4.mySqlCmd.Parameters.AddWithValue("total_amount_due", totalAmountDue);
                Conns4.mySqlCmd.Parameters.AddWithValue("payment_amount", paymentAmount);
                Conns4.mySqlCmd.Parameters.AddWithValue("payment_method", cboPaymentMethod.Text);
                Conns4.mySqlCmd.Parameters.AddWithValue("change_amount", totalChangeAmount);
                Conns4.mySqlCmd.Parameters.AddWithValue("cashier", Global.displayName);
                Conns4.mySqlCmd.Parameters.AddWithValue("date_recorded", dateRecorded);
                Conns4.mySqlDataReader = Conns4.mySqlCmd.ExecuteReader();     // Execute the mySQL command
                Conns4.closeConnection();    // !Important ->> Close the connection from the database

                printReceipt(transactionID); // Print receipt

                // Show message if the transaction is successful
                new classMsgBox().showMsgSuccessful("Transaction has been saved");
                Application.OpenForms["frmPOS_ParentContainer"].Activate(); // Bring the parent form to the front

                this.Hide();

                // Go back to transaction records
                var targetForm = Application.OpenForms.OfType<frmPOS_ParentContainer>().Single();
                targetForm.Controls["panelContainer"].Controls.Clear();
                ucPOS_TransactionRecords ucPOS_TransactionRecords = new ucPOS_TransactionRecords();
                ucPOS_TransactionRecords.Dock = DockStyle.Fill;
                targetForm.Controls["panelContainer"].Controls.Add(ucPOS_TransactionRecords);
            }
            Application.OpenForms["frmPOS_ParentContainer"].Activate(); // Bring the parent form to the front 
        }

        private void printBilling(int varTransactionID)
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
                    if (panelCartItems.Controls[i] is ucPOS_NewTransaction_CartItem_2)
                    {
                        ucPOS_NewTransaction_CartItem_2 ucPOS_NewTransaction_CartItem_2 = panelCartItems.Controls[i] as ucPOS_NewTransaction_CartItem_2;

                        varDataTable.Rows.Add(
                            "• " + ucPOS_NewTransaction_CartItem_2.itemName,
                            "" + ucPOS_NewTransaction_CartItem_2.itemQuantity + " " + ucPOS_NewTransaction_CartItem_2.itemUoM,
                            "" + Convert.ToDouble((ucPOS_NewTransaction_CartItem_2.itemQuantity * ucPOS_NewTransaction_CartItem_2.itemPrice)).ToString("N2"),
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
                reportDocument = new crptPOS_Billing();
                reportDocument.SetDataSource(varDataTable);

                // Get the details from the database
                MySqlConnect Conns = new MySqlConnect();    // Connect to the database
                Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_pos_transactions WHERE Category_Code='" + Global.posBusinessCategoryCode + "' AND Unit_Code=" + Global.posBusinessUnitCode + " AND transaction_id=" + varTransactionID + " LIMIT 1;", Conns.mySqlconn);     // Create a query command
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
                        // Setting Parameters
                        reportDocument.SetParameterValue("parCorporationName", Global.posCorpName);
                        reportDocument.SetParameterValue("parBusinessUnitName", Global.posBusinessUnitName);
                        reportDocument.SetParameterValue("parBusinessUnitAddress", Global.posBusinessUnitAddress);
                        reportDocument.SetParameterValue("parBusinessUnitTIN", "TIN: " + Global.posBusinessUnitTIN);
                        reportDocument.SetParameterValue("parTransNo", varTransactionID);
                        reportDocument.SetParameterValue("parDate", Convert.ToDateTime(Conns.mySqlDataReader["transaction_date"].ToString()).ToString("yyyy-MM-dd"));
                        reportDocument.SetParameterValue("parOrderType", Conns.mySqlDataReader["order_type"].ToString());
                        reportDocument.SetParameterValue("parTableNo", Conns.mySqlDataReader["table_number"].ToString());
                        reportDocument.SetParameterValue("parCashier", Conns.mySqlDataReader["cashier"].ToString());
                        reportDocument.SetParameterValue("parTotalSales", totalAmount.ToString("N2"));
                        i++;
                    }
                }

                // Printing the document
                reportDocument.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                reportDocument.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
            }
        }

        private void printReceipt(int varTransactionID)
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
                    if (panelCartItems.Controls[i] is ucPOS_NewTransaction_CartItem_2)
                    {
                        ucPOS_NewTransaction_CartItem_2 ucPOS_NewTransaction_CartItem_2 = panelCartItems.Controls[i] as ucPOS_NewTransaction_CartItem_2;

                        varDataTable.Rows.Add(
                            "• " + ucPOS_NewTransaction_CartItem_2.itemName,
                            "" + ucPOS_NewTransaction_CartItem_2.itemQuantity + " " + ucPOS_NewTransaction_CartItem_2.itemUoM,
                            "" + Convert.ToDouble((ucPOS_NewTransaction_CartItem_2.itemQuantity * ucPOS_NewTransaction_CartItem_2.itemPrice)).ToString("N2"),
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
                reportDocument = new crptPOS_Receipt();
                reportDocument.SetDataSource(varDataTable);

                // Get the details from the database
                MySqlConnect Conns = new MySqlConnect();    // Connect to the database
                Conns.mySqlCmd = new MySqlCommand("SELECT t1.transaction_id, t1.Category_Code, t1.Unit_Code, t1.transaction_date, t1.transaction_time, t1.order_type, t1.table_number, t1.cashier, t1.discount_type, t1.payment_method, t1.net_of_vat, t1.vat_amount, t1.discount_amount, t1.total_sales_amount, t1.total_amount_due, t1.payment_amount, t1.change_amount FROM " +
                    "(SELECT transaction_id, Category_Code, Unit_Code, transaction_date, transaction_time, order_type, table_number, cashier, discount_type, payment_method, net_of_vat, vat_amount, discount_amount, total_sales_amount, total_amount_due, payment_amount, change_amount FROM tbl_pos_transactions WHERE Category_Code='" + Global.posBusinessCategoryCode + "' AND Unit_Code=" + Global.posBusinessUnitCode + " AND transaction_id=" + varTransactionID + ") AS t1 " +
                    "LIMIT 1;", Conns.mySqlconn);     // Create a query command
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
                        // Setting Parameters
                        reportDocument.SetParameterValue("parCorporationName", Global.posCorpName);
                        reportDocument.SetParameterValue("parBusinessUnitName", Global.posBusinessUnitName);
                        reportDocument.SetParameterValue("parBusinessUnitAddress", Global.posBusinessUnitAddress);
                        reportDocument.SetParameterValue("parBusinessUnitTIN", "TIN: " + Global.posBusinessUnitTIN);
                        reportDocument.SetParameterValue("parTransNo", varTransactionID);
                        reportDocument.SetParameterValue("parDate", Convert.ToDateTime(Conns.mySqlDataReader["transaction_date"].ToString()).ToString("yyyy-MM-dd"));
                        reportDocument.SetParameterValue("parTransTime", Conns.mySqlDataReader["transaction_time"].ToString());
                        reportDocument.SetParameterValue("parOrderType", Conns.mySqlDataReader["order_type"].ToString());
                        reportDocument.SetParameterValue("parTableNo", Conns.mySqlDataReader["table_number"].ToString());
                        reportDocument.SetParameterValue("parCashier", Conns.mySqlDataReader["cashier"].ToString());
                        reportDocument.SetParameterValue("parDiscountType", Conns.mySqlDataReader["discount_type"].ToString());
                        reportDocument.SetParameterValue("parPaymentMethod", Conns.mySqlDataReader["payment_method"].ToString());
                        reportDocument.SetParameterValue("parNetOfVAT", Convert.ToDouble(Conns.mySqlDataReader["net_of_vat"].ToString()).ToString("N2"));
                        reportDocument.SetParameterValue("parVATAmount", Convert.ToDouble(Conns.mySqlDataReader["vat_amount"].ToString()).ToString("N2"));
                        reportDocument.SetParameterValue("parDiscountAmount", Convert.ToDouble(Conns.mySqlDataReader["discount_amount"].ToString()).ToString("N2"));
                        reportDocument.SetParameterValue("parTotalSales", Convert.ToDouble(Conns.mySqlDataReader["total_sales_amount"].ToString()).ToString("N2"));
                        reportDocument.SetParameterValue("parAmountDue", Convert.ToDouble(Conns.mySqlDataReader["total_amount_due"].ToString()).ToString("N2"));
                        reportDocument.SetParameterValue("parPaymentAmount", Convert.ToDouble(Conns.mySqlDataReader["payment_amount"].ToString()).ToString("N2"));
                        reportDocument.SetParameterValue("parChange", Convert.ToDouble(Conns.mySqlDataReader["change_amount"].ToString()).ToString("N2"));
                        i++;
                    }
                }

                // Printing the document
                reportDocument.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                reportDocument.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}