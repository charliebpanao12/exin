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
    public partial class frmInventory_InventoryIn_AddNewTransaction : Form
    {
        public string SQLStatement;
        public string InventoryTypeSearch;
        public string Search;
        public string AddorEditorEditProduct;
        public string status;
        public string DateofDelivery;
        public string TimeofDelivery;
        public int TransactionID;
        public int productID;
        public string BillTo;
        public string ShipTo;
        public int newTransactionID;
        public int newDRNumber;
        public int newInvoiceNumber;
        public string BranchZipCode;


        public frmInventory_InventoryIn_AddNewTransaction()
        {
            InitializeComponent();
            dtpDate.Value = DateTime.Now;
            dtpInvoiceDate.Value = DateTime.Now;
            dtpTime.Value = DateTime.Now;


            // Controls - Combobox
            cboInventoryTypeSearch.BorderColor = Global.themeColor1;
            cboInventoryTypeSearch.FocusedState.BorderColor = Global.themeColor2;
            cboInventoryTypeSearch.HoverState.BorderColor = Global.themeColor2;

            // Controls - Textbox 4
            txtSearch.BorderColor = Global.themeColor1;
            txtSearch.FocusedState.BorderColor = Global.themeColor2;
            txtSearch.HoverState.BorderColor = Global.themeColor2;

            // Panel with Datagrid
            panelRecords.CustomBorderColor = Global.themeColor1;
     
            // Panel
            guna2Panel4.CustomBorderColor = Global.themeColor1;

            // Controls - Combobox
            cboBranch.BorderColor = Global.themeColor1;
            cboBranch.FocusedState.BorderColor = Global.themeColor2;
            cboBranch.HoverState.BorderColor = Global.themeColor2;

            // Controls - Combobox
            cboBillTo.BorderColor = Global.themeColor1;
            cboBillTo.FocusedState.BorderColor = Global.themeColor2;
            cboBillTo.HoverState.BorderColor = Global.themeColor2;

            // Controls - Combobox
            cboShipTo.BorderColor = Global.themeColor1;
            cboShipTo.FocusedState.BorderColor = Global.themeColor2;
            cboShipTo.HoverState.BorderColor = Global.themeColor2;

            // Controls - Button 3
            btnCancel.FillColor = Global.themeColor1;
            btnCancel.FillColor2 = Global.themeColor2;

            // Controls - Button 3
            btnSave.FillColor = Global.themeColor1;
            btnSave.FillColor2 = Global.themeColor2;

            // Controls - DateTimePicker
            dtpDate.FillColor = Global.themeColor1;
            dtpDate.BorderColor = Global.themeColor1;
            dtpDate.CustomFormat = "MMMM dd, yyyy";

            // Controls - DateTimePicker
            dtpInvoiceDate.FillColor = Global.themeColor1;
            dtpInvoiceDate.BorderColor = Global.themeColor1;
            dtpInvoiceDate.CustomFormat = "MMMM dd, yyyy";

            // Controls - DateTimePicker
            dtpTime.FillColor = Global.themeColor1;
            dtpTime.BorderColor = Global.themeColor1;
            dtpTime.CustomFormat = "MMMM dd, yyyy";  
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void deleteItem()
        {
            for (var i = panelCartItems.Controls.Count - 1; i >= 0; i--)
            {
                if (panelCartItems.Controls[i] is ucInventory_InventoryIn_CartItem)
                {
                    ucInventory_InventoryIn_CartItem ucInventory_InventoryIn_CartItem = panelCartItems.Controls[i] as ucInventory_InventoryIn_CartItem;
                    if (ucInventory_InventoryIn_CartItem.deleteMe == true)
                    {
                        panelCartItems.Controls.Remove(panelCartItems.Controls[i]);
                        return;
                    }
                }
            }
        }
        private void generateNewTransactionID()
        {
            MySqlConnect Conns = new MySqlConnect();
            newTransactionID = 0;
            SQLStatement = "SELECT transaction_id FROM tbl_inventory_in_transactions ORDER BY transaction_id DESC LIMIT 1";
            Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(Conns.mySqlDataReader);
            int recordCount = dt.Rows.Count;
            if (recordCount > 0)
            {
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                while (Conns.mySqlDataReader.Read())
                {
                    newTransactionID = Convert.ToInt32(Conns.mySqlDataReader["transaction_id"].ToString());
                    newTransactionID++;
                    txtTransactionID.Text = newTransactionID.ToString();
                }
            }
            else
            {
                newTransactionID = 30000001;
            }
            Conns.mySqlconn.Close();
        }
        private void generateNewDRnumber()
        {
            MySqlConnect Conns = new MySqlConnect();
            newDRNumber = 101;
            SQLStatement = "SELECT dr_no FROM tbl_inventory_in_transactions ORDER BY dr_no DESC LIMIT 1";
            Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(Conns.mySqlDataReader);
            int recordCount = dt.Rows.Count;
            if (recordCount > 0)
            {
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                while (Conns.mySqlDataReader.Read())
                {
                    newDRNumber = Convert.ToInt32(Conns.mySqlDataReader["dr_no"].ToString());
                    newDRNumber++;
                    txtDeliveryNumber.Text = newDRNumber.ToString();
                }
            }
            else
            {
                newDRNumber = 101;
                txtDeliveryNumber.Text = newDRNumber.ToString();
            }
            Conns.mySqlconn.Close();
        }
        private void generateNewInvoiceNumber()
        {
            MySqlConnect Conns = new MySqlConnect();
            newInvoiceNumber = 201;
            SQLStatement = "SELECT invoice_number FROM tbl_inventory_in_transactions ORDER BY invoice_number DESC LIMIT 1";
            Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(Conns.mySqlDataReader);
            int recordCount = dt.Rows.Count;
            if (recordCount > 0)
            {
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                while (Conns.mySqlDataReader.Read())
                {
                    newInvoiceNumber = Convert.ToInt32(Conns.mySqlDataReader["invoice_number"].ToString());
                    newInvoiceNumber++;
                    txtInvoiceNumber.Text = newInvoiceNumber.ToString();
                }
            }
            else
            {
                newInvoiceNumber = 201;
                txtInvoiceNumber.Text = newInvoiceNumber.ToString();
            }
            Conns.mySqlconn.Close();
        }

        public void Alert(string msg, frmAlert.alertTypeEnum type)
        {
            frmAlert f = new frmAlert();
            f.setAlert(msg, type);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate if the cart is empty
            if (panelCartItems.Controls.Count == 0)
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("There are no items in the cart!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }

            //Validation for saving record
            if (cboBranch.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill up the branch before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (cboBillTo.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill up the bill to before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (cboShipTo.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill up the ship to before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (dtpDate.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill up the inventory date in before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (dtpTime.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill up the inventory time in before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtDeliveryNumber.Text == "")
            {
                //new clagssMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill up the delivery number before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtInvoiceNumber.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill up the invoice number before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (dtpInvoiceDate.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill up the invoice date before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtConsignment.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill consignment before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtBusinessStyle.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill business style before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtDepartment.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill department before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtPhone.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill phone before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtMemo.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill memo before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtPreparedBy.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill prepared by before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtCheckedBy.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill checked by before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtApprovedBy.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill approved by before you proceed!");
                this.Alert("Please fill approved by before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtReleasedBy.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill released by before you proceed!");
                this.Alert("Please fill released by before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtReceivedBy.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill received by before you proceed!");
                this.Alert("Please fill received by before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }

            MySqlConnect Conns = new MySqlConnect();
            if (AddorEditorEditProduct == "Edit")
            {
                SQLStatement = "DELETE FROM tbl_inventory_in_transactions WHERE transaction_id = " + TransactionID/* + " AND category_code = " + Global.businessCategory + " AND unit_code = " + Global.businessUnitCode*/;
                Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                Conns.mySqlDataReader.Close();
                status = "Active";
                //Generate new Transaction ID
                //generateNewTransactionID();
                //Generate new DR Number
                if (cbxDeliveryNumberAuto.Checked == true)
                {
                    generateNewDRnumber();
                }
                else
                {
                    newDRNumber = Convert.ToInt32(txtDeliveryNumber.Text);
                }
                //Generate new Invoice Number
                if (cbxInvoiceNumberAuto.Checked == true)
                {
                    generateNewInvoiceNumber();
                }
                else
                {
                    newInvoiceNumber = Convert.ToInt32(txtInvoiceNumber.Text);
                }

                for (var j = panelCartItems.Controls.Count - 1; j >= 0; j--)
                {

                    if (panelCartItems.Controls[j] is ucInventory_InventoryIn_CartItem)
                    {
                        ucInventory_InventoryIn_CartItem ucInventory_InventoryIn_CartItem = panelCartItems.Controls[j] as ucInventory_InventoryIn_CartItem;
                        int productID = ucInventory_InventoryIn_CartItem.productID;
                        string barcode = ucInventory_InventoryIn_CartItem.barcode;
                        string sku = ucInventory_InventoryIn_CartItem.sku;
                        string productName = ucInventory_InventoryIn_CartItem.productName;
                        string unitOfMeasure = ucInventory_InventoryIn_CartItem.unitOfMeasure;
                        double quantity = ucInventory_InventoryIn_CartItem.quantity;
                        double unitPrice = ucInventory_InventoryIn_CartItem.unitPrice;
                        double sellingPrice = ucInventory_InventoryIn_CartItem.sellingPrice;
                        //double discount = ucInventory_InventoryIn_CartItem.discount;
                        double totalAmount = ucInventory_InventoryIn_CartItem.totalAmount;

                        Conns.mySqlCmd = new MySqlCommand("insert into tbl_inventory_in_transactions" +
                                    " (transaction_id, " +
                                    "category_code," +
                                    "unit_code," +
                                    "Project_Code," +
                                    "product_id," +
                                    "barcode," +
                                    "sku," +
                                    "item_name," +
                                    "unit_of_measure," +
                                    "quantity," +
                                    "unit_price," +
                                    "selling_price," +
                                    //"discount," +
                                    "total_amount," +
                                    "bill_to," +
                                    "ship_to," +
                                    "date_time," +
                                    "dr_no," +
                                    "invoice_number," +
                                    "invoice_date," +
                                    "consignment," +
                                    "business_style," +
                                    "department," +
                                    "phone," +
                                    "memo," +
                                    "prepared_by," +
                                    "checked_by," +
                                    "approved_by," +
                                    "released_by," +
                                    "received_by," +
                                    "status) " +
                                    "values " +
                                    " (@transaction_id, " +
                                    "@category_code," +
                                    "@unit_code," +
                                    "@Project_Code," +
                                    "@product_id," +
                                    "@barcode," +
                                    "@sku," +
                                    "@item_name," +
                                    "@unit_of_measure," +
                                    "@quantity," +
                                    "@unit_price," +
                                    "@selling_price," +
                                    //"@discount," +
                                    "@total_amount," +
                                    "@bill_to," +
                                    "@ship_to," +
                                    "@date_time," +
                                    "@dr_no," +
                                    "@invoice_number," +
                                    "@invoice_date," +
                                    "@consignment," +
                                    "@business_style," +
                                    "@department," +
                                    "@phone," +
                                    "@memo," +
                                    "@prepared_by," +
                                    "@checked_by," +
                                    "@approved_by," +
                                    "@released_by," +
                                    "@received_by," +
                                    "@status) ", Conns.mySqlconn);
                        Conns.mySqlCmd.Parameters.AddWithValue("transaction_id", txtTransactionID.Text);
                        Conns.mySqlCmd.Parameters.AddWithValue("category_code", Global.inventoryBusinessCategoryCode);
                        Conns.mySqlCmd.Parameters.AddWithValue("unit_code", Global.inventoryBusinessUnitCode);
                        Conns.mySqlCmd.Parameters.AddWithValue("Project_Code", txtBranchZipCode.Text);
                        Conns.mySqlCmd.Parameters.AddWithValue("product_id", productID);
                        Conns.mySqlCmd.Parameters.AddWithValue("barcode", barcode);
                        Conns.mySqlCmd.Parameters.AddWithValue("sku", sku);
                        Conns.mySqlCmd.Parameters.AddWithValue("item_name", productName);
                        Conns.mySqlCmd.Parameters.AddWithValue("unit_of_measure", unitOfMeasure);
                        Conns.mySqlCmd.Parameters.AddWithValue("quantity", quantity);
                        Conns.mySqlCmd.Parameters.AddWithValue("unit_price", unitPrice);
                        Conns.mySqlCmd.Parameters.AddWithValue("selling_price", sellingPrice);
                        //Conns.mySqlCmd.Parameters.AddWithValue("discount", discount);
                        Conns.mySqlCmd.Parameters.AddWithValue("total_amount", totalAmount);
                        Conns.mySqlCmd.Parameters.AddWithValue("bill_to", txtBillToZipCode.Text);
                        Conns.mySqlCmd.Parameters.AddWithValue("ship_to", txtShipToZipCode.Text);
                        Conns.mySqlCmd.Parameters.AddWithValue("date_time", dtpDate.Value.ToString("yyyy-MM-dd H:mm:ss"));
                        Conns.mySqlCmd.Parameters.AddWithValue("dr_no", txtDeliveryNumber.Text);
                        Conns.mySqlCmd.Parameters.AddWithValue("invoice_number", txtInvoiceNumber.Text);
                        Conns.mySqlCmd.Parameters.AddWithValue("invoice_date", dtpInvoiceDate.Value.ToString("yyyy-MM-dd"));
                        Conns.mySqlCmd.Parameters.AddWithValue("consignment", txtConsignment.Text);
                        Conns.mySqlCmd.Parameters.AddWithValue("business_style", txtBusinessStyle.Text);
                        Conns.mySqlCmd.Parameters.AddWithValue("department", txtDepartment.Text);
                        Conns.mySqlCmd.Parameters.AddWithValue("phone", txtPhone.Text);
                        Conns.mySqlCmd.Parameters.AddWithValue("memo", txtMemo.Text);
                        Conns.mySqlCmd.Parameters.AddWithValue("prepared_by", txtPreparedBy.Text);
                        Conns.mySqlCmd.Parameters.AddWithValue("checked_by", txtCheckedBy.Text);
                        Conns.mySqlCmd.Parameters.AddWithValue("approved_by", txtApprovedBy.Text);
                        Conns.mySqlCmd.Parameters.AddWithValue("released_by", txtReleasedBy.Text);
                        Conns.mySqlCmd.Parameters.AddWithValue("received_by", txtReceivedBy.Text);
                        Conns.mySqlCmd.Parameters.AddWithValue("status", status);
                        Conns.mySqlCmd.ExecuteNonQuery();
                    }
                }
                Conns.mySqlconn.Close();
                new classMsgBox().showMsgSuccessful("Successfully Updated!");
            }
            else
            {
                status = "Active";
                new classMsgBox().showMsgConfirmation("Do you want to save?");
                // your codes here when the OK button has been pressed
                if (Global.msgConfirmation == true)
                {
                    //Generate new Transaction ID
                    generateNewTransactionID();

                    //Generate new DR Number
                    if (cbxDeliveryNumberAuto.Checked == true)
                    {
                        generateNewDRnumber();
                    }
                    else
                    {
                        newDRNumber = Convert.ToInt32(txtDeliveryNumber.Text);
                    }
                    //Generate new Invoice Number
                    if (cbxInvoiceNumberAuto.Checked == true)
                    {
                        generateNewInvoiceNumber();
                    }
                    else
                    {
                        newInvoiceNumber = Convert.ToInt32(txtInvoiceNumber.Text);
                    }

                    for (var j = panelCartItems.Controls.Count - 1; j >= 0; j--)
                    {

                        if (panelCartItems.Controls[j] is ucInventory_InventoryIn_CartItem)
                        {
                            ucInventory_InventoryIn_CartItem ucInventory_InventoryIn_CartItem = panelCartItems.Controls[j] as ucInventory_InventoryIn_CartItem;
                            int productID = ucInventory_InventoryIn_CartItem.productID;
                            string barcode = ucInventory_InventoryIn_CartItem.barcode;
                            string sku = ucInventory_InventoryIn_CartItem.sku;
                            string productName = ucInventory_InventoryIn_CartItem.productName;
                            string unitOfMeasure = ucInventory_InventoryIn_CartItem.unitOfMeasure;
                            double quantity = ucInventory_InventoryIn_CartItem.quantity;
                            double unitPrice = ucInventory_InventoryIn_CartItem.unitPrice;
                            double sellingPrice = ucInventory_InventoryIn_CartItem.sellingPrice;
                            //double discount = ucInventory_InventoryIn_CartItem.discount;
                            double totalAmount = ucInventory_InventoryIn_CartItem.totalAmount;

                            Conns.mySqlCmd = new MySqlCommand("insert into tbl_inventory_in_transactions" +
                                        " (transaction_id, " +
                                        "category_code," +
                                        "unit_code," +
                                        "Project_Code," +
                                        "product_id," +
                                        "barcode," +
                                        "sku," +
                                        "item_name," +
                                        "unit_of_measure," +
                                        "quantity," +
                                        "unit_price," +
                                        "selling_price," +
                                        //"discount," +
                                        "total_amount," +
                                        "bill_to," +
                                        "ship_to," +
                                        "date_time," +
                                        "dr_no," +
                                        "invoice_number," +
                                        "invoice_date," +
                                        "consignment," +
                                        "business_style," +
                                        "department," +
                                        "phone," +
                                        "memo," +
                                        "prepared_by," +
                                        "checked_by," +
                                        "approved_by," +
                                        "released_by," +
                                        "received_by," +
                                        "status) " +
                                        "values " +
                                        " (@transaction_id, " +
                                        "@category_code," +
                                        "@unit_code," +
                                        "@Project_Code," +
                                        "@product_id," +
                                        "@barcode," +
                                        "@sku," +
                                        "@item_name," +
                                        "@unit_of_measure," +
                                        "@quantity," +
                                        "@unit_price," +
                                        "@selling_price," +
                                        //"@discount," +
                                        "@total_amount," +
                                        "@bill_to," +
                                        "@ship_to," +
                                        "@date_time," +
                                        "@dr_no," +
                                        "@invoice_number," +
                                        "@invoice_date," +
                                        "@consignment," +
                                        "@business_style," +
                                        "@department," +
                                        "@phone," +
                                        "@memo," +
                                        "@prepared_by," +
                                        "@checked_by," +
                                        "@approved_by," +
                                        "@released_by," +
                                        "@received_by," +
                                        "@status) ", Conns.mySqlconn);
                            Conns.mySqlCmd.Parameters.AddWithValue("transaction_id", newTransactionID);
                            Conns.mySqlCmd.Parameters.AddWithValue("category_code", Global.inventoryBusinessCategoryCode);
                            Conns.mySqlCmd.Parameters.AddWithValue("unit_code", Global.inventoryBusinessUnitCode);
                            Conns.mySqlCmd.Parameters.AddWithValue("Project_Code", txtBranchZipCode.Text);
                            Conns.mySqlCmd.Parameters.AddWithValue("product_id", productID);
                            Conns.mySqlCmd.Parameters.AddWithValue("barcode", barcode);
                            Conns.mySqlCmd.Parameters.AddWithValue("sku", sku);
                            Conns.mySqlCmd.Parameters.AddWithValue("item_name", productName);
                            Conns.mySqlCmd.Parameters.AddWithValue("unit_of_measure", unitOfMeasure);
                            Conns.mySqlCmd.Parameters.AddWithValue("quantity", quantity);
                            Conns.mySqlCmd.Parameters.AddWithValue("unit_price", unitPrice);
                            Conns.mySqlCmd.Parameters.AddWithValue("selling_price", sellingPrice);
                            //Conns.mySqlCmd.Parameters.AddWithValue("discount", discount);
                            Conns.mySqlCmd.Parameters.AddWithValue("total_amount", totalAmount);
                            Conns.mySqlCmd.Parameters.AddWithValue("bill_to", txtBillToZipCode.Text);
                            Conns.mySqlCmd.Parameters.AddWithValue("ship_to", txtShipToZipCode.Text);
                            Conns.mySqlCmd.Parameters.AddWithValue("date_time", dtpDate.Value.ToString("yyyy-MM-dd H:mm:ss"));
                            Conns.mySqlCmd.Parameters.AddWithValue("dr_no", txtDeliveryNumber.Text);
                            Conns.mySqlCmd.Parameters.AddWithValue("invoice_number", txtInvoiceNumber.Text);
                            Conns.mySqlCmd.Parameters.AddWithValue("invoice_date", dtpInvoiceDate.Value.ToString("yyyy-MM-dd"));
                            Conns.mySqlCmd.Parameters.AddWithValue("consignment", txtConsignment.Text);
                            Conns.mySqlCmd.Parameters.AddWithValue("business_style", txtBusinessStyle.Text);
                            Conns.mySqlCmd.Parameters.AddWithValue("department", txtDepartment.Text);
                            Conns.mySqlCmd.Parameters.AddWithValue("phone", txtPhone.Text);
                            Conns.mySqlCmd.Parameters.AddWithValue("memo", txtMemo.Text);
                            Conns.mySqlCmd.Parameters.AddWithValue("prepared_by", txtPreparedBy.Text);
                            Conns.mySqlCmd.Parameters.AddWithValue("checked_by", txtCheckedBy.Text);
                            Conns.mySqlCmd.Parameters.AddWithValue("approved_by", txtApprovedBy.Text);
                            Conns.mySqlCmd.Parameters.AddWithValue("released_by", txtReleasedBy.Text);
                            Conns.mySqlCmd.Parameters.AddWithValue("received_by", txtReceivedBy.Text);
                            Conns.mySqlCmd.Parameters.AddWithValue("status", status);
                            Conns.mySqlCmd.ExecuteNonQuery();
                        }
                    }
                    Conns.mySqlconn.Close();
                    new classMsgBox().showMsgSuccessful("Successfully Saved!");
                }
            }
            Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front

                this.Hide();
        }


        private void dgvTransaction_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {

                // Input quantity for chosen item
                frmInventory_InventoryIn_AddNewTransaction_Quantity frmInventory_InventoryIn_AddNewTransaction_Quantity = new frmInventory_InventoryIn_AddNewTransaction_Quantity();
                frmInventory_InventoryIn_AddNewTransaction_Quantity.ShowDialog();

                Boolean isExisting = false;
                // Validate the items from the cart if the item exists
                for (var i = panelCartItems.Controls.Count - 1; i >= 0; i--)
                {
                    if (panelCartItems.Controls[i] is ucInventory_InventoryIn_CartItem)
                    {
                        ucInventory_InventoryIn_CartItem ucInventory_InventoryIn_CartItem = panelCartItems.Controls[i] as ucInventory_InventoryIn_CartItem;

                        if (ucInventory_InventoryIn_CartItem.productID == Convert.ToInt32(dgvTransaction.Rows[e.RowIndex].Cells[1].Value.ToString()))
                        {
                            ucInventory_InventoryIn_CartItem.quantity += Convert.ToDouble(frmInventory_InventoryIn_AddNewTransaction_Quantity.numtxtQuantity.Value);
                            ucInventory_InventoryIn_CartItem.txtQuantity.Text = "" + (Convert.ToDouble(ucInventory_InventoryIn_CartItem.txtQuantity.Text) + Convert.ToDouble(frmInventory_InventoryIn_AddNewTransaction_Quantity.numtxtQuantity.Value));
                            isExisting = true;
                            i = -1;
                        }
                    }
                }

                // Add the item to the cart
                if (isExisting == false)
                {
                    ucInventory_InventoryIn_CartItem ucInventory_InventoryIn_CartItem = new ucInventory_InventoryIn_CartItem();
                    ucInventory_InventoryIn_CartItem.Dock = DockStyle.Top;
                    ucInventory_InventoryIn_CartItem.productID = Convert.ToInt32(dgvTransaction.Rows[e.RowIndex].Cells[1].Value.ToString());
                    ucInventory_InventoryIn_CartItem.productName = dgvTransaction.Rows[e.RowIndex].Cells[4].Value.ToString();
                    ucInventory_InventoryIn_CartItem.unitOfMeasure = dgvTransaction.Rows[e.RowIndex].Cells[5].Value.ToString();
                    ucInventory_InventoryIn_CartItem.unitPrice = Convert.ToDouble(dgvTransaction.Rows[e.RowIndex].Cells[6].Value.ToString());
                    ucInventory_InventoryIn_CartItem.sellingPrice = Convert.ToDouble(dgvTransaction.Rows[e.RowIndex].Cells[7].Value.ToString());
                    ucInventory_InventoryIn_CartItem.barcode = dgvTransaction.Rows[e.RowIndex].Cells[8].Value.ToString();
                    ucInventory_InventoryIn_CartItem.sku = dgvTransaction.Rows[e.RowIndex].Cells[9].Value.ToString();
                    //ucInventory_InventoryIn_CartItem.discount = Convert.ToDouble(frmInventory_InventoryIn_AddNewTransaction_Quantity.numtxtDiscount.Value);
                    ucInventory_InventoryIn_CartItem.quantity = Convert.ToDouble(frmInventory_InventoryIn_AddNewTransaction_Quantity.numtxtQuantity.Value);
                    double totalcost = ucInventory_InventoryIn_CartItem.unitPrice  * ucInventory_InventoryIn_CartItem.quantity;
                    //double totalamount = totalcost - ucInventory_InventoryIn_CartItem.discount;
                    ucInventory_InventoryIn_CartItem.totalAmount = totalcost;
                    panelCartItems.Controls.Add(ucInventory_InventoryIn_CartItem);
                }
            }            
        }

        private void frmInventory_InventoryIn_AddNewTransaction_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;
            dtpInvoiceDate.Value = DateTime.Now;
            int i = 0;

            MySqlConnect Conns = new MySqlConnect();
            SQLStatement = "SELECT distinct inventory_type FROM tbl_inventory_products_masterlist ORDER BY inventory_type ASC";
            Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
            while (Conns.mySqlDataReader.Read())
            {
                i++;
                cboInventoryTypeSearch.Items.Add(Conns.mySqlDataReader["inventory_type"].ToString());
            }

            //ComboList of Project_Name for Branch, Bill to, Ship to
            Conns.mySqlCmd = new MySqlCommand("SELECT distinct Project_Name FROM tbl_projects", Conns.mySqlconn);
            Conns.mySqlDataReader.Close();
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
            cboBranch.Items.Clear();
            cboBillTo.Items.Clear();
            cboShipTo.Items.Clear();
            while (Conns.mySqlDataReader.Read())
            {
                i++;
                //CategoryCode
                cboBranch.Items.Add(Conns.mySqlDataReader["Project_Name"].ToString());
                //Load BillTo
                cboBillTo.Items.Add(Conns.mySqlDataReader["Project_Name"].ToString());
                //Load ShipTo
                cboShipTo.Items.Add(Conns.mySqlDataReader["Project_Name"].ToString());
            }

                    // Validation for add or edit
                    if (AddorEditorEditProduct == "Add")
                    {
                        lblTitle.Text = "Inventory In - New Transaction";
                    }
                    else if (AddorEditorEditProduct == "Edit")
                    {
                        //Title Label
                        lblTitle.Text = "Inventory In - Update Transaction";

                        BranchZipCode = txtBranchZipCode.Text;
                    //Query for Branch Name
                    //SQLStatement = "SELECT Project_Name FROM tbl_projects WHERE Project_Code = " + BranchZipCode;
                    //Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
                    //Conns.mySqlDataReader.Close();
                    //Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                    //while (Conns.mySqlDataReader.Read())
                    //{
                    //    cboBranch.Text = Conns.mySqlDataReader["Project_Name"].ToString();
                    //}

                    Image Deleteicon = Image.FromFile("Resources/General/Datagrid_Images/delete.jpg");

                    Conns.mySqlCmd = new MySqlCommand("SELECT distinct T1.product_id, T1.inventory_type, T1.item_name, T1.unit_of_measure, T1.unit_cost, T1.selling_price, T1.bar_code, T1.sku, T2.transaction_id, T3.Project_Code, T2.quantity, T2.discount, T2.category_code, T2.bill_to, T2.Category_Code, T2.ship_to, T2.date_time, T2.dr_no, T2.invoice_number, T2.invoice_date, T2.consignment, T2.business_style, T2.department, T2.phone, T2.memo, T2.prepared_by, T2.checked_by, T2.approved_by, T2.released_by, T2.received_by FROM " +
                                                         "(SELECT product_id, bar_code, sku, inventory_type, item_category, item_name, item_description, unit_of_measure, unit_cost, selling_price, item_color, item_brand, item_variant, item_size, beginning_inventory, actual_count FROM tbl_inventory_products_masterlist) as T1 " +
                                                         "LEFT JOIN (SELECT transaction_id, category_code, Project_Code, product_id, quantity, discount, total_amount, bill_to, ship_to, date_time, dr_no, invoice_number, invoice_date, consignment, business_style, department, phone, memo, prepared_by, checked_by, approved_by, released_by, received_by, status FROM tbl_inventory_in_transactions) AS T2 ON T1.product_id = T2.product_id " +
                                                         "LEFT JOIN (SELECT Project_Code, Category_Code FROM tbl_projects) AS T3 ON T2.Project_Code = T3.Project_Code WHERE T2.transaction_id = " + TransactionID + " AND status = 'Active'", Conns.mySqlconn);
                        Conns.mySqlDataReader.Close();
                        Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                        while (Conns.mySqlDataReader.Read())
                        {
                            TimeofDelivery = Conns.mySqlDataReader.GetDateTime("date_time").ToShortTimeString();
                            txtTransactionID.Text = Conns.mySqlDataReader["transaction_id"].ToString();
                            txtBranchZipCode.Text = Conns.mySqlDataReader["Project_Code"].ToString();
                            cboBranch.Text = Conns.mySqlDataReader["category_code"].ToString();
                            txtBillToZipCode.Text = Conns.mySqlDataReader["bill_to"].ToString();
                            cboBillTo.Text = Conns.mySqlDataReader["category_code"].ToString();
                            txtShipToZipCode.Text = Conns.mySqlDataReader["ship_to"].ToString();
                            cboShipTo.Text = Conns.mySqlDataReader["category_code"].ToString();
                            dtpDate.Text = Conns.mySqlDataReader["date_time"].ToString();
                            dtpTime.Text = TimeofDelivery;
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

                            //dgvTransaction.Rows.Add(i,
                            //    Conns.mySqlDataReader["product_id"].ToString(),
                            //    Conns.mySqlDataReader["category_code"].ToString(),
                            //    Conns.mySqlDataReader["inventory_type"].ToString(),
                            //    Conns.mySqlDataReader["item_name"].ToString(),
                            //    Conns.mySqlDataReader["unit_of_measure"].ToString(),
                            //    Conns.mySqlDataReader["unit_cost"].ToString(),
                            //    Conns.mySqlDataReader["selling_price"].ToString(),
                            //    Conns.mySqlDataReader["bar_code"].ToString(),
                            //    Conns.mySqlDataReader["sku"].ToString(),
                            //    cldelete.Image = Deleteicon);

                    ucInventory_InventoryIn_CartItem ucInventory_InventoryIn_CartItem = new ucInventory_InventoryIn_CartItem();
                    ucInventory_InventoryIn_CartItem.Dock = DockStyle.Top;
                    ucInventory_InventoryIn_CartItem.productID = Convert.ToInt32(Conns.mySqlDataReader["product_id"].ToString());
                    ucInventory_InventoryIn_CartItem.productName = Conns.mySqlDataReader["item_name"].ToString();
                    ucInventory_InventoryIn_CartItem.unitOfMeasure = Conns.mySqlDataReader["unit_of_measure"].ToString();
                    ucInventory_InventoryIn_CartItem.unitPrice = Convert.ToDouble(Conns.mySqlDataReader["unit_cost"].ToString());
                    ucInventory_InventoryIn_CartItem.sellingPrice = Convert.ToDouble(Conns.mySqlDataReader["selling_price"].ToString());
                    ucInventory_InventoryIn_CartItem.barcode = Conns.mySqlDataReader["bar_code"].ToString();
                    ucInventory_InventoryIn_CartItem.sku = Conns.mySqlDataReader["sku"].ToString();
                    ucInventory_InventoryIn_CartItem.quantity = Convert.ToDouble(Conns.mySqlDataReader["quantity"].ToString());
                    ucInventory_InventoryIn_CartItem.discount = Convert.ToDouble(Conns.mySqlDataReader["discount"].ToString());
                    double totalcost = ucInventory_InventoryIn_CartItem.unitPrice * ucInventory_InventoryIn_CartItem.quantity;
                    double totalamount = totalcost - ucInventory_InventoryIn_CartItem.discount;
                    ucInventory_InventoryIn_CartItem.totalAmount = totalcost;
                    panelCartItems.Controls.Add(ucInventory_InventoryIn_CartItem);
                }
                        Conns.mySqlconn.Close();
                    } 
        }

        private void cboInventoryTypeSearch_SelectedValueChanged(object sender, EventArgs e)
        {
            InventoryTypeSearch = cboInventoryTypeSearch.Text;
            dgvTransaction.Rows.Clear();

            if (InventoryTypeSearch != null)
            {

                MySqlConnect Conns = new MySqlConnect();
                int i = 0;
                //SQLStatement = "SELECT product_id, barcode, sku, category_code, item_name FROM tbl_inventory_in_transactions WHERE inventory_type = '" + InventoryTypeSearch + "' AND status = 'Active' GROUP BY transaction_id ORDER BY transaction_id DESC";
                //SQLStatement = "SELECT T1.product_id, T1.bar_code, T1.sku, T1.inventory_type, T1.category_code, T1.item_name, T1.status FROM " +
                //"(SELECT product_id, bar_code, sku, inventory_type, category_code, item_name, status FROM tbl_inventory_products_masterlist) AS T1 " +
                //"WHERE T1.product_id = '" + Search + "' OR T1.item_name LIKE'%' '" + Search + "' '%' AND T1.inventory_type = '" + InventoryTypeSearch + "' AND T1.status = 'Active' ORDER BY T1.item_name ASC";
                SQLStatement = "SELECT product_id, category_code, inventory_type, item_name, unit_of_measure, unit_cost, selling_price, bar_code, sku, status FROM tbl_inventory_products_masterlist WHERE product_id = '" + Search + "' OR item_name LIKE'%' '" + Search + "' '%' AND inventory_type = '" + InventoryTypeSearch + "' AND status = 'Active' GROUP BY product_id ORDER BY product_id DESC";

                Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                while (Conns.mySqlDataReader.Read())
                {
                    i++;

                    dgvTransaction.Rows.Add(i,
                        Conns.mySqlDataReader["product_id"].ToString(),
                        Conns.mySqlDataReader["category_code"].ToString(),
                        Conns.mySqlDataReader["inventory_type"].ToString(),
                        Conns.mySqlDataReader["item_name"].ToString(),
                        Conns.mySqlDataReader["unit_of_measure"].ToString(),
                        Conns.mySqlDataReader["unit_cost"].ToString(),
                        Conns.mySqlDataReader["selling_price"].ToString(),
                        Conns.mySqlDataReader["bar_code"].ToString(),
                        Conns.mySqlDataReader["sku"].ToString());
                }
                Conns.mySqlconn.Close();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search = txtSearch.Text;
            dgvTransaction.Rows.Clear();

            if (Search != null || Search != " ")
            {

                MySqlConnect Conns = new MySqlConnect();
                int i = 0;
                //SQLStatement = "SELECT product_id, barcode, sku, category_code, item_name FROM tbl_inventory_in_transactions WHERE inventory_type = '" + InventoryTypeSearch + "' AND status = 'Active' GROUP BY transaction_id ORDER BY transaction_id DESC";
                SQLStatement = "SELECT T1.product_id, T1.category_code, T1.inventory_type, T1.item_name, T1.unit_of_measure, T1.unit_cost, T1.selling_price, T1.bar_code, T1.sku FROM " +
                "(SELECT product_id, category_code, inventory_type, item_name, unit_of_measure, unit_cost, selling_price, bar_code, sku FROM tbl_inventory_products_masterlist) AS T1 " +
                "LEFT JOIN (SELECT transaction_id, product_id, quantity, discount, total_amount, status FROM tbl_inventory_in_transactions) AS T2 ON T1.product_id = T2.product_id WHERE T1.product_id = '" + Search + "' OR T1.item_name LIKE'%' '" + Search + "' '%' AND T2.inventory_type = '" + InventoryTypeSearch + "' AND T1.status = 'Active' GROUP BY T1.transaction_id ORDER BY T1.transaction_id DESC";

                Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                while (Conns.mySqlDataReader.Read())
                {
                    i++;

                    dgvTransaction.Rows.Add(i,
                        Conns.mySqlDataReader["product_id"].ToString(),
                        Conns.mySqlDataReader["category_code"].ToString(),
                        Conns.mySqlDataReader["inventory_type"].ToString(),
                        Conns.mySqlDataReader["item_name"].ToString(),
                        Conns.mySqlDataReader["unit_of_measure"].ToString(),
                        Conns.mySqlDataReader["unit_cost"].ToString(),
                        Conns.mySqlDataReader["selling_price"].ToString(),
                        Conns.mySqlDataReader["bar_code"].ToString(),
                        Conns.mySqlDataReader["sku"].ToString(),
                        Conns.mySqlDataReader["quantity"].ToString(),
                        //Conns.mySqlDataReader["discount"].ToString(),
                        Conns.mySqlDataReader["total_amount"].ToString());
                }
                Conns.mySqlconn.Close();
            }
        }

        private void cboBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnect Conns = new MySqlConnect();
            SQLStatement = "SELECT Project_Code FROM tbl_projects WHERE Project_Name = '"+ cboBranch.Text + "' AND Category_Code= '"+ Global.inventoryBusinessCategoryCode + "' AND Unit_Code = "+ Global.inventoryBusinessUnitCode +";";
            Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
            while (Conns.mySqlDataReader.Read())
            {
                txtBranchZipCode.Text = Conns.mySqlDataReader["Project_Code"].ToString();
            }
            Conns.mySqlconn.Close();
        }

        private void cboBillTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnect Conns = new MySqlConnect();
            SQLStatement = "SELECT Project_Code FROM tbl_projects WHERE Project_Name = '" + cboBillTo.Text + "' AND Category_Code= '" + Global.inventoryBusinessCategoryCode + "' AND Unit_Code = " + Global.inventoryBusinessUnitCode + ";";
            Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
            while (Conns.mySqlDataReader.Read())
            {
                txtBillToZipCode.Text = Conns.mySqlDataReader["Project_Code"].ToString();
            }
            Conns.mySqlconn.Close();
        }

        private void cboShipTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnect Conns = new MySqlConnect();
            SQLStatement = "SELECT Project_Code FROM tbl_projects WHERE Project_Name = '" + cboShipTo.Text + "' AND Category_Code= '" + Global.inventoryBusinessCategoryCode + "' AND Unit_Code = " + Global.inventoryBusinessUnitCode + ";";
            Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
            while (Conns.mySqlDataReader.Read())
            {
                txtShipToZipCode.Text = Conns.mySqlDataReader["Project_Code"].ToString();
            }
            Conns.mySqlconn.Close();
        }

        private void cbxDeliveryNumberAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDeliveryNumberAuto.Checked == true)
            {
                txtDeliveryNumber.Enabled = false;
                txtDeliveryNumber.Text = "Automatic";
            }
            else
            {
                txtDeliveryNumber.Enabled = true;
                txtDeliveryNumber.Text = "";
            }
        }

        private void cbxInvoiceNumberAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxInvoiceNumberAuto.Checked == true)
            {
                txtInvoiceNumber.Enabled = false;
                txtInvoiceNumber.Text = "Automatic";
            }
            else
            {
                txtInvoiceNumber.Enabled = true;
                txtInvoiceNumber.Text = "";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Refresh();
            Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
        }

        private void dgvTransaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MySqlConnect Conns = new MySqlConnect();

            //Delete
            if (e.ColumnIndex == 10)
            {
                productID = Convert.ToInt32(dgvTransaction.Rows[e.RowIndex].Cells[1].Value);
                //TransactionID = Convert.ToInt32(Conns.mySqlDataReader["transaction_id"].ToString());

                new classMsgBox().showMsgConfirmation_Delete("Do you really want to Delete this record?");
                if (Global.msgConfirmation == true)
                {
                    // your codes here when the OK button has been pressed
                    ucInventory_InventoryIn_CartItem ucInventory_InventoryIn_CartItem = new ucInventory_InventoryIn_CartItem();
                    ucInventory_InventoryIn_CartItem.Hide();
                    Conns.mySqlCmd = new MySqlCommand("update tbl_inventory_in_transactions set status = 'Deleted' WHERE product_id = " + productID /*+ " AND transaction_id = " + TransactionID*/, Conns.mySqlconn);
                    Conns.mySqlCmd.ExecuteNonQuery();
                    new classMsgBox().showMsgSuccessful("Deleted Successfully");
                }
                dgvTransaction.Refresh();
                Application.OpenForms["frmInventory_InventoryIn_AddNewTransaction"].Activate(); // Bring the parent form to the front
            }
        }
    }
}
