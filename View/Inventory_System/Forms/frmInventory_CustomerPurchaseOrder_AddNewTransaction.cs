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
    public partial class frmInventory_CustomerPurchaseOrder_AddNewTransaction : Form
    {
        public string SQLStatement;
        public string ProductItemSearch;
        public string Search;
        public string AddorEditorEditProduct;
        public string recordstatus;
        public string DateofDelivery;
        public string TimeofDelivery;
        public int CustomerPOID;
        public int POID;
        public int productID;
        public string BillTo;
        public string ShipTo;
        public int newPOID;
        public int newCustomerID;
        public double totalcost;
        public double totalamount;
        public int CustomerIDSearch;
        public string CustomerID;




        public frmInventory_CustomerPurchaseOrder_AddNewTransaction()
        {
            InitializeComponent();
            dtpPODate.Value = DateTime.Now;
            dtpPOTime.Value = DateTime.Now;


            // Controls - Combobox
            cboProductItemSearch.BorderColor = Global.themeColor1;
            cboProductItemSearch.FocusedState.BorderColor = Global.themeColor2;
            cboProductItemSearch.HoverState.BorderColor = Global.themeColor2;

            // Controls - Textbox 4
            txtSearch.BorderColor = Global.themeColor1;
            txtSearch.FocusedState.BorderColor = Global.themeColor2;
            txtSearch.HoverState.BorderColor = Global.themeColor2;

            // Panel with Datagrid
            panelRecords.CustomBorderColor = Global.themeColor1;
     
            // Panel
            panelCart.CustomBorderColor = Global.themeColor1;


            // Controls - Button 3
            btnCancel.FillColor = Global.themeColor1;
            btnCancel.FillColor2 = Global.themeColor2;

            // Controls - Button 3
            btnSave.FillColor = Global.themeColor1;
            btnSave.FillColor2 = Global.themeColor2;

            // Controls - DateTimePicker
            dtpPODate.FillColor = Global.themeColor1;
            dtpPODate.BorderColor = Global.themeColor1;
            dtpPODate.CustomFormat = "MMMM dd, yyyy";

            // Controls - DateTimePicker
            dtpPOTime.FillColor = Global.themeColor1;
            dtpPOTime.BorderColor = Global.themeColor1;
            dtpPOTime.CustomFormat = "MMMM dd, yyyy";  
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
                if (panelCartItems.Controls[i] is ucInventory_CustomerPurchaseOrder_CartItem)
                {
                    ucInventory_CustomerPurchaseOrder_CartItem ucInventory_CustomerPurchaseOrder_CartItem = panelCartItems.Controls[i] as ucInventory_CustomerPurchaseOrder_CartItem;
                    if (ucInventory_CustomerPurchaseOrder_CartItem.deleteMe == true)
                    {
                        panelCartItems.Controls.Remove(panelCartItems.Controls[i]);
                        return;
                    }
                }
            }
        }
        private void generateCustomerPOID()
        {
            MySqlConnect Conns = new MySqlConnect();
            newPOID = 0;
            SQLStatement = "SELECT po_id FROM tbl_inventory_customer_po ORDER BY po_id DESC LIMIT 1";
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
                    newPOID = Convert.ToInt32(Conns.mySqlDataReader["po_id"].ToString());
                    newPOID++;
                    txtPOID.Text = newPOID.ToString();
                }
            }
            else
            {
                newPOID = 30000001;
                txtPOID.Text = newPOID.ToString();
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
                Application.OpenForms["frmInventory_CustomerPurchaseOrder_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (dtpPODate.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill up the purchase order date in before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_CustomerPurchaseOrder_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (dtpPOTime.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill up the purchase order time in before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_CustomerPurchaseOrder_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            //Validation for saving record
            if (cboCustomerID.Enabled == true && cboCustomerID.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill up the customer id before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_CustomerPurchaseOrder_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtCustomerID.Enabled == true && txtCustomerID.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill up the customer id before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_CustomerPurchaseOrder_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }

            if (txtCustomerName.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill up the customer name to before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_CustomerPurchaseOrder_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtPhone.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill phone before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_CustomerPurchaseOrder_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtAddress.Text == "")
            {
                //new clagssMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill up the address before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_CustomerPurchaseOrder_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            //Validation for saving record
            if (txtBusinessStyle.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill up the business style before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_CustomerPurchaseOrder_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtPreparedBy.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill up the prepared by before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_CustomerPurchaseOrder_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtAcknowledgedBy.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill up the acknowledge by before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_CustomerPurchaseOrder_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtOrderStatus.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill received by before you proceed!");
                this.Alert("Please fill up the order status by before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_CustomerPurchaseOrder_AddNewTransaction"].Activate(); // Bring the parent form to the front
                return;
            }

            MySqlConnect Conns = new MySqlConnect();

            if (AddorEditorEditProduct == "Edit")
            {
                SQLStatement = "DELETE FROM tbl_inventory_customer_po WHERE po_id = " + POID /* + " AND category_code = " + Global.businessCategory + " AND unit_code = " + Global.businessUnitCode*/;
                Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                Conns.mySqlDataReader.Close();

                recordstatus = "Active";
                new classMsgBox().showMsgConfirmation("Do you want to save?");
                // your codes here when the OK button has been pressed

                if (CustomerID == "cboCustomerID")
                {
                    for (var j = panelCartItems.Controls.Count - 1; j >= 0; j--)
                    {

                        if (panelCartItems.Controls[j] is ucInventory_CustomerPurchaseOrder_CartItem)
                        {
                            ucInventory_CustomerPurchaseOrder_CartItem ucInventory_CustomerPurchaseOrder_CartItem = panelCartItems.Controls[j] as ucInventory_CustomerPurchaseOrder_CartItem;
                            int productID = ucInventory_CustomerPurchaseOrder_CartItem.productID;
                            string barcode = ucInventory_CustomerPurchaseOrder_CartItem.barcode;
                            string sku = ucInventory_CustomerPurchaseOrder_CartItem.sku;
                            string itemname = ucInventory_CustomerPurchaseOrder_CartItem.itemname;
                            string unitOfMeasure = ucInventory_CustomerPurchaseOrder_CartItem.unitOfMeasure;
                            double orderquantity = ucInventory_CustomerPurchaseOrder_CartItem.orderquantity;
                            double unitPrice = ucInventory_CustomerPurchaseOrder_CartItem.unitPrice;
                            double sellingPrice = ucInventory_CustomerPurchaseOrder_CartItem.sellingPrice;
                            double totalAmount = ucInventory_CustomerPurchaseOrder_CartItem.totalAmount;

                            Conns.mySqlCmd = new MySqlCommand("insert into tbl_inventory_customer_po " +
                                            " (po_id, " +
                                            "po_date," +
                                            "customer_id," +
                                            "product_id," +
                                            "item_name," +
                                            "unit_of_measure," +
                                            "unit_cost," +
                                            "selling_price," +
                                            "bar_code," +
                                            "sku," +
                                            "order_quantity," +
                                            "prepared_by," +
                                            "acknowledged_by," +
                                            "order_status," +
                                            "record_status) " +
                                            "values " +
                                            " (@po_id, " +
                                            "@po_date," +
                                            "@customer_id," +
                                            "@product_id," +
                                            "@item_name," +
                                            "@unit_of_measure," +
                                            "@unit_cost," +
                                            "@selling_price," +
                                            "@bar_code," +
                                            "@sku," +
                                            "@order_quantity," +
                                            "@prepared_by," +
                                            "@acknowledged_by," +
                                            "@order_status," +
                                            "@record_status)", Conns.mySqlconn);
                            Conns.mySqlCmd.Parameters.AddWithValue("po_id", txtPOID.Text);
                            Conns.mySqlCmd.Parameters.AddWithValue("po_date", dtpPODate.Value.ToString("yyyy-MM-dd H:mm:ss"));
                            Conns.mySqlCmd.Parameters.AddWithValue("customer_id", cboCustomerID.Text);
                            Conns.mySqlCmd.Parameters.AddWithValue("product_id", productID);
                            Conns.mySqlCmd.Parameters.AddWithValue("item_name", itemname);
                            Conns.mySqlCmd.Parameters.AddWithValue("unit_of_measure", unitOfMeasure);
                            Conns.mySqlCmd.Parameters.AddWithValue("unit_cost", unitPrice);
                            Conns.mySqlCmd.Parameters.AddWithValue("selling_price", sellingPrice);
                            Conns.mySqlCmd.Parameters.AddWithValue("bar_code", barcode);
                            Conns.mySqlCmd.Parameters.AddWithValue("sku", sku);
                            Conns.mySqlCmd.Parameters.AddWithValue("order_quantity", orderquantity);
                            Conns.mySqlCmd.Parameters.AddWithValue("prepared_by", txtPreparedBy.Text);
                            Conns.mySqlCmd.Parameters.AddWithValue("acknowledged_by", txtAcknowledgedBy.Text);
                            Conns.mySqlCmd.Parameters.AddWithValue("order_status", txtOrderStatus.Text);
                            Conns.mySqlCmd.Parameters.AddWithValue("record_status", recordstatus);
                            Conns.mySqlCmd.ExecuteNonQuery();
                        }
                    }
                }
                Conns.mySqlconn.Close();
                new classMsgBox().showMsgSuccessful("Successfully Updated!");
            }
            else
            {
                recordstatus = "Active";
                new classMsgBox().showMsgConfirmation("Do you want to save?");
                // your codes here when the OK button has been pressed
                if (Global.msgConfirmation == true)
                {
                    //Generate new Customer PO ID
                    generateCustomerPOID();

                    if (CustomerID == "cboCustomerID")
                    {
                        for (var j = panelCartItems.Controls.Count - 1; j >= 0; j--)
                        {

                            if (panelCartItems.Controls[j] is ucInventory_CustomerPurchaseOrder_CartItem)
                            {
                                ucInventory_CustomerPurchaseOrder_CartItem ucInventory_CustomerPurchaseOrder_CartItem = panelCartItems.Controls[j] as ucInventory_CustomerPurchaseOrder_CartItem;
                                int productID = ucInventory_CustomerPurchaseOrder_CartItem.productID;
                                string barcode = ucInventory_CustomerPurchaseOrder_CartItem.barcode;
                                string sku = ucInventory_CustomerPurchaseOrder_CartItem.sku;
                                string itemname = ucInventory_CustomerPurchaseOrder_CartItem.itemname;
                                string unitOfMeasure = ucInventory_CustomerPurchaseOrder_CartItem.unitOfMeasure;
                                double orderquantity = ucInventory_CustomerPurchaseOrder_CartItem.orderquantity;
                                double unitPrice = ucInventory_CustomerPurchaseOrder_CartItem.unitPrice;
                                double sellingPrice = ucInventory_CustomerPurchaseOrder_CartItem.sellingPrice;
                                double totalAmount = ucInventory_CustomerPurchaseOrder_CartItem.totalAmount;

                                Conns.mySqlCmd = new MySqlCommand("insert into tbl_inventory_customer_po " +
                                                " (po_id, " +
                                                "po_date," +
                                                "customer_id," +
                                                "product_id," +
                                                "item_name," +
                                                "unit_of_measure," +
                                                "unit_cost," +
                                                "selling_price," +
                                                "bar_code," +
                                                "sku," +
                                                "order_quantity," +
                                                "prepared_by," +
                                                "acknowledged_by," +
                                                "order_status," +
                                                "record_status) " +
                                                "values " +
                                                " (@po_id, " +
                                                "@po_date," +
                                                "@customer_id," +
                                                "@product_id," +
                                                "@item_name," +
                                                "@unit_of_measure," +
                                                "@unit_cost," +
                                                "@selling_price," +
                                                "@bar_code," +
                                                "@sku," +
                                                "@order_quantity," +
                                                "@prepared_by," +
                                                "@acknowledged_by," +
                                                "@order_status," +
                                                "@record_status)", Conns.mySqlconn);
                                Conns.mySqlCmd.Parameters.AddWithValue("po_id", txtPOID.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("po_date", dtpPODate.Value.ToString("yyyy-MM-dd H:mm:ss"));
                                Conns.mySqlCmd.Parameters.AddWithValue("customer_id", cboCustomerID.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("product_id", productID);
                                Conns.mySqlCmd.Parameters.AddWithValue("item_name", itemname);
                                Conns.mySqlCmd.Parameters.AddWithValue("unit_of_measure", unitOfMeasure);
                                Conns.mySqlCmd.Parameters.AddWithValue("unit_cost", unitPrice);
                                Conns.mySqlCmd.Parameters.AddWithValue("selling_price", sellingPrice);
                                Conns.mySqlCmd.Parameters.AddWithValue("bar_code", barcode);
                                Conns.mySqlCmd.Parameters.AddWithValue("sku", sku);
                                Conns.mySqlCmd.Parameters.AddWithValue("order_quantity", orderquantity);
                                Conns.mySqlCmd.Parameters.AddWithValue("prepared_by", txtPreparedBy.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("acknowledged_by", txtAcknowledgedBy.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("order_status", txtOrderStatus.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("record_status", recordstatus);
                                Conns.mySqlCmd.ExecuteNonQuery();

                                Conns.mySqlCmd = new MySqlCommand("insert into tbl_inventory_customer_list " +
                                                " (AutoNum, " +
                                                " customer_type, " +
                                                " customer_name, " +
                                                " ordering_passcode, " +
                                                " tin, " +
                                                " business_style, " +
                                                " phone, " +
                                                " address, " +
                                                " record_status)" +
                                                "VALUES " +
                                                " (@AutoNum, " +
                                                " @customer_type, " +
                                                " @customer_name, " +
                                                " @ordering_passcode, " +
                                                " @tin, " +
                                                " @business_style, " +
                                                " @phone, " +
                                                " @address, " +
                                                " @record_status)", Conns.mySqlconn);
                                Conns.mySqlCmd.Parameters.AddWithValue("AutoNum", cboCustomerID.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("customer_type", txtCustomerType.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("customer_name", txtCustomerName.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("ordering_passcode", txtOrderingPasscode.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("tin", txtTIN.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("business_style", txtBusinessStyle.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("phone", txtPhone.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("address", txtAddress.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("record_status", recordstatus);
                                Conns.mySqlCmd.ExecuteNonQuery();
                            }
                        }
                    }
                    else if (CustomerID == "txtCustomerID")
                    {
                        for (var j = panelCartItems.Controls.Count - 1; j >= 0; j--)
                        {

                            if (panelCartItems.Controls[j] is ucInventory_CustomerPurchaseOrder_CartItem)
                            {
              
                                Conns.mySqlCmd = new MySqlCommand("insert into tbl_inventory_customer_list " +
                                                " (AutoNum, " +
                                                " customer_type, " +
                                                " customer_name, " +
                                                " ordering_passcode, " +
                                                " tin, " +
                                                " business_style, " +
                                                " phone, " +
                                                " address, " +
                                                " record_status)" +
                                                "VALUES " +
                                                " (@AutoNum, " +
                                                " @customer_type, " +
                                                " @customer_name, " +
                                                " @ordering_passcode, " +
                                                " @tin, " +
                                                " @business_style, " +
                                                " @phone, " +
                                                " @address, " +
                                                " @record_status)", Conns.mySqlconn);
                                Conns.mySqlCmd.Parameters.AddWithValue("AutoNum", txtCustomerID.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("customer_type", txtCustomerType.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("customer_name", txtCustomerName.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("ordering_passcode", txtOrderingPasscode.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("tin", txtTIN.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("business_style", txtBusinessStyle.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("phone", txtPhone.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("address", txtAddress.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("record_status", recordstatus);
              

                                ucInventory_CustomerPurchaseOrder_CartItem ucInventory_CustomerPurchaseOrder_CartItem = panelCartItems.Controls[j] as ucInventory_CustomerPurchaseOrder_CartItem;
                                int productID = ucInventory_CustomerPurchaseOrder_CartItem.productID;
                                string barcode = ucInventory_CustomerPurchaseOrder_CartItem.barcode;
                                string sku = ucInventory_CustomerPurchaseOrder_CartItem.sku;
                                string itemname = ucInventory_CustomerPurchaseOrder_CartItem.itemname;
                                string unitOfMeasure = ucInventory_CustomerPurchaseOrder_CartItem.unitOfMeasure;
                                double orderquantity = ucInventory_CustomerPurchaseOrder_CartItem.orderquantity;
                                double unitPrice = ucInventory_CustomerPurchaseOrder_CartItem.unitPrice;
                                double sellingPrice = ucInventory_CustomerPurchaseOrder_CartItem.sellingPrice;
                                double totalAmount = ucInventory_CustomerPurchaseOrder_CartItem.totalAmount;
                                Conns.mySqlCmd = new MySqlCommand("insert into tbl_inventory_customer_po " +
                                                 " (po_id, " +
                                                 "po_date," +
                                                 "customer_id," +
                                                 "product_id," +
                                                 "item_name," +
                                                 "unit_of_measure," +
                                                 "unit_cost," +
                                                 "selling_price," +
                                                 "bar_code," +
                                                 "sku," +
                                                 "order_quantity," +
                                                 "prepared_by," +
                                                 "acknowledged_by," +
                                                 "order_status," +
                                                 "record_status) " +
                                                 "values " +
                                                 " (@po_id, " +
                                                 "@po_date," +
                                                 "@customer_id," +
                                                 "@product_id," +
                                                 "@item_name," +
                                                 "@unit_of_measure," +
                                                 "@unit_cost," +
                                                 "@selling_price," +
                                                 "@bar_code," +
                                                 "@sku," +
                                                 "@order_quantity," +
                                                 "@prepared_by," +
                                                 "@acknowledged_by," +
                                                 "@order_status," +
                                                 "@record_status)", Conns.mySqlconn);
                                Conns.mySqlCmd.Parameters.AddWithValue("po_id", txtPOID.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("po_date", dtpPODate.Value.ToString("yyyy-MM-dd H:mm:ss"));
                                Conns.mySqlCmd.Parameters.AddWithValue("customer_id", CustomerID);
                                Conns.mySqlCmd.Parameters.AddWithValue("product_id", productID);
                                Conns.mySqlCmd.Parameters.AddWithValue("item_name", itemname);
                                Conns.mySqlCmd.Parameters.AddWithValue("unit_of_measure", unitOfMeasure);
                                Conns.mySqlCmd.Parameters.AddWithValue("unit_cost", unitPrice);
                                Conns.mySqlCmd.Parameters.AddWithValue("selling_price", sellingPrice);
                                Conns.mySqlCmd.Parameters.AddWithValue("bar_code", barcode);
                                Conns.mySqlCmd.Parameters.AddWithValue("sku", sku);
                                Conns.mySqlCmd.Parameters.AddWithValue("order_quantity", orderquantity);
                                Conns.mySqlCmd.Parameters.AddWithValue("prepared_by", txtPreparedBy.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("acknowledged_by", txtAcknowledgedBy.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("order_status", txtOrderStatus.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("record_status", recordstatus);
                                Conns.mySqlCmd.ExecuteNonQuery();
                            }
                        }
                    }
                    Conns.mySqlconn.Close();
                    new classMsgBox().showMsgSuccessful("Successfully Saved!");
                }
            }
            Application.OpenForms["frmInventory_CustomerPurchaseOrder_AddNewTransaction"].Activate(); // Bring the parent form to the front

                this.Hide();
        }


        private void dgvTransaction_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {

                // Input quantity for chosen item
                frmInventory_CustomerPurchaseOrder_AddNewTransaction_Quantity frmInventory_CustomerPurchaseOrder_AddNewTransaction_Quantity = new frmInventory_CustomerPurchaseOrder_AddNewTransaction_Quantity();
                frmInventory_CustomerPurchaseOrder_AddNewTransaction_Quantity.ShowDialog();

                Boolean isExisting = false;
                // Validate the items from the cart if the item exists
                for (var i = panelCartItems.Controls.Count - 1; i >= 0; i--)
                {
                    if (panelCartItems.Controls[i] is ucInventory_CustomerPurchaseOrder_CartItem)
                    {
                        ucInventory_CustomerPurchaseOrder_CartItem ucInventory_CustomerPurchaseOrder_CartItem = panelCartItems.Controls[i] as ucInventory_CustomerPurchaseOrder_CartItem;

                        if (ucInventory_CustomerPurchaseOrder_CartItem.productID == Convert.ToInt32(dgvTransaction.Rows[e.RowIndex].Cells[1].Value.ToString()))
                        {
                            ucInventory_CustomerPurchaseOrder_CartItem.orderquantity += Convert.ToDouble(frmInventory_CustomerPurchaseOrder_AddNewTransaction_Quantity.numtxtQuantity.Value);
                            ucInventory_CustomerPurchaseOrder_CartItem.txtQuantity.Text = "" + (Convert.ToDouble(ucInventory_CustomerPurchaseOrder_CartItem.txtQuantity.Text) + Convert.ToDouble(frmInventory_CustomerPurchaseOrder_AddNewTransaction_Quantity.numtxtQuantity.Value));
                            isExisting = true;
                            i = -1;
                        }
                    }
                }

                // Add the item to the cart
                if (isExisting == false)
                {
                    ucInventory_CustomerPurchaseOrder_CartItem ucInventory_CustomerPurchaseOrder_CartItem = new ucInventory_CustomerPurchaseOrder_CartItem();
                    ucInventory_CustomerPurchaseOrder_CartItem.Dock = DockStyle.Top;
                    ucInventory_CustomerPurchaseOrder_CartItem.productID = Convert.ToInt32(dgvTransaction.Rows[e.RowIndex].Cells[1].Value.ToString());
                    ucInventory_CustomerPurchaseOrder_CartItem.itemname = dgvTransaction.Rows[e.RowIndex].Cells[4].Value.ToString();
                    ucInventory_CustomerPurchaseOrder_CartItem.unitOfMeasure = dgvTransaction.Rows[e.RowIndex].Cells[5].Value.ToString();
                    ucInventory_CustomerPurchaseOrder_CartItem.unitPrice = Convert.ToDouble(dgvTransaction.Rows[e.RowIndex].Cells[6].Value.ToString());
                    ucInventory_CustomerPurchaseOrder_CartItem.sellingPrice = Convert.ToDouble(dgvTransaction.Rows[e.RowIndex].Cells[7].Value.ToString());
                    ucInventory_CustomerPurchaseOrder_CartItem.barcode = dgvTransaction.Rows[e.RowIndex].Cells[8].Value.ToString();
                    ucInventory_CustomerPurchaseOrder_CartItem.sku = dgvTransaction.Rows[e.RowIndex].Cells[9].Value.ToString();
                    //ucInventory_PurchaseOrder_CartItem.discount = Convert.ToDouble(frmInventory_CustomerPurchaseOrder_AddNewTransaction_Quantity.numtxtDiscount.Value);
                    ucInventory_CustomerPurchaseOrder_CartItem.orderquantity = Convert.ToDouble(frmInventory_CustomerPurchaseOrder_AddNewTransaction_Quantity.numtxtQuantity.Value);
                    totalcost = ucInventory_CustomerPurchaseOrder_CartItem.sellingPrice * ucInventory_CustomerPurchaseOrder_CartItem.orderquantity;
                    //totalamount = totalcost - ucInventory_PurchaseOrder_CartItem.discount;
                    ucInventory_CustomerPurchaseOrder_CartItem.totalAmount = totalcost;
                    panelCartItems.Controls.Add(ucInventory_CustomerPurchaseOrder_CartItem);
                }
            }            
        }

        private void frmInventory_InventoryIn_AddNewTransaction_Load(object sender, EventArgs e)
        {
            dtpPODate.Value = DateTime.Now;
            
            int i = 0;

            MySqlConnect Conns = new MySqlConnect();
            SQLStatement = "SELECT distinct item_name FROM tbl_inventory_products_masterlist ORDER BY item_name ASC";
            Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
            while (Conns.mySqlDataReader.Read())
            {
                i++;
                cboProductItemSearch.Items.Add(Conns.mySqlDataReader["item_name"].ToString());
            }


            SQLStatement = "SELECT distinct AutoNum FROM tbl_inventory_customer_list ORDER BY AutoNum ASC";
            Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
            Conns.mySqlDataReader.Close();
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
            while (Conns.mySqlDataReader.Read())
            {
                i++;
                cboCustomerID.Items.Add(Conns.mySqlDataReader["AutoNum"].ToString());
            }
           

            // Validation for add or edit
            if (AddorEditorEditProduct == "Add")
            {
                        lblTitle.Text = "Customer Purchase Order - New Transaction";
            }

            else if (AddorEditorEditProduct == "Edit")
            {
                        //Title Label
                        lblTitle.Text = "Customer Purchase Order - Update Transaction";
                             
                         SQLStatement = "SELECT distinct T1.product_id, T1.category_code, T1.inventory_type, T1.item_name, T1.unit_of_measure, T1.unit_cost, T1.selling_price, T1.bar_code, T1.sku, T2.po_id, T2.po_date, T2.order_quantity, T2.prepared_by, T2.acknowledged_by, T2.order_status, T3. Autonum, T3.customer_name, T3.business_style, T3.phone, T3.address FROM " +
                                                        "(SELECT product_id, bar_code, sku, category_code, inventory_type, item_category, item_name, item_description, unit_of_measure, unit_cost, selling_price, item_color, item_brand, item_variant, item_size, beginning_inventory, actual_count FROM tbl_inventory_products_masterlist) as T1 " +
                                                        "LEFT JOIN (SELECT po_id, po_date, customer_id, product_id, order_quantity, prepared_by, acknowledged_by, order_status, record_status FROM tbl_inventory_customer_po ) AS T2 ON T1.product_id = T2.product_id " +
                                                        "LEFT JOIN (SELECT AutoNum, customer_name, business_style, phone, address, record_status FROM tbl_inventory_customer_list) AS T3 ON T2.customer_id = T3.AutoNum WHERE T2.po_id = " + POID + " AND T2.record_status = 'Active'";
                        Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
                        Conns.mySqlDataReader.Close();
                        Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                        while (Conns.mySqlDataReader.Read())
                        {
                                TimeofDelivery = Conns.mySqlDataReader.GetDateTime("po_date").ToShortTimeString();
                                txtPOID.Text = Conns.mySqlDataReader["po_id"].ToString();
                                cboCustomerID.Text = Conns.mySqlDataReader["AutoNum"].ToString();
                                txtCustomerName.Text = Conns.mySqlDataReader["customer_name"].ToString();
                                txtBusinessStyle.Text = Conns.mySqlDataReader["business_style"].ToString();
                                dtpPODate.Text = Conns.mySqlDataReader["po_date"].ToString();
                                dtpPOTime.Text = TimeofDelivery;
                                txtAddress.Text = Conns.mySqlDataReader["address"].ToString();
                                txtPhone.Text = Conns.mySqlDataReader["phone"].ToString(); 
                                txtPreparedBy.Text = Conns.mySqlDataReader["prepared_by"].ToString();
                                txtAcknowledgedBy.Text = Conns.mySqlDataReader["acknowledged_by"].ToString();
                                txtOrderStatus.Text = Conns.mySqlDataReader["order_status"].ToString();

                                //dgvTransaction.Rows.Add(i,
                                //Conns.mySqlDataReader["product_id"].ToString(),
                                //Conns.mySqlDataReader["category_code"].ToString(),
                                //Conns.mySqlDataReader["inventory_type"].ToString(),
                                //Conns.mySqlDataReader["item_name"].ToString(),
                                //Conns.mySqlDataReader["unit_of_measure"].ToString(),
                                //Conns.mySqlDataReader["unit_cost"].ToString(),
                                //Conns.mySqlDataReader["selling_price"].ToString(),
                                //Conns.mySqlDataReader["bar_code"].ToString(),
                                //Conns.mySqlDataReader["sku"].ToString());

                                ucInventory_CustomerPurchaseOrder_CartItem ucInventory_CustomerPurchaseOrder_CartItem = new ucInventory_CustomerPurchaseOrder_CartItem();
                                ucInventory_CustomerPurchaseOrder_CartItem.Dock = DockStyle.Top;
                                ucInventory_CustomerPurchaseOrder_CartItem.productID = Convert.ToInt32(Conns.mySqlDataReader["product_id"].ToString());
                                ucInventory_CustomerPurchaseOrder_CartItem.itemname = Conns.mySqlDataReader["item_name"].ToString();
                                ucInventory_CustomerPurchaseOrder_CartItem.unitOfMeasure = Conns.mySqlDataReader["unit_of_measure"].ToString();
                                ucInventory_CustomerPurchaseOrder_CartItem.unitPrice = Convert.ToDouble(Conns.mySqlDataReader["unit_cost"].ToString());
                                ucInventory_CustomerPurchaseOrder_CartItem.sellingPrice = Convert.ToDouble(Conns.mySqlDataReader["selling_price"].ToString());
                                ucInventory_CustomerPurchaseOrder_CartItem.barcode = Conns.mySqlDataReader["bar_code"].ToString();
                                ucInventory_CustomerPurchaseOrder_CartItem.sku = Conns.mySqlDataReader["sku"].ToString();
                                ucInventory_CustomerPurchaseOrder_CartItem.orderquantity = Convert.ToDouble(Conns.mySqlDataReader["order_quantity"].ToString());
                                //ucInventory_PurchaseOrder_CartItem.discount = Convert.ToDouble(Conns.mySqlDataReader["discount"].ToString());
                                double totalcost = ucInventory_CustomerPurchaseOrder_CartItem.sellingPrice * ucInventory_CustomerPurchaseOrder_CartItem.orderquantity;
                                //double totalamount = totalcost - ucInventory_PurchaseOrder_CartItem.discount;
                                ucInventory_CustomerPurchaseOrder_CartItem.totalAmount = totalcost;
                                panelCartItems.Controls.Add(ucInventory_CustomerPurchaseOrder_CartItem);

                        }   
                                Conns.mySqlconn.Close();
            } 
        }

        private void cboInventoryTypeSearch_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search = txtSearch.Text;
            dgvTransaction.Rows.Clear();

            if (Search != null || Search != " ")
            {

                MySqlConnect Conns = new MySqlConnect();
                int i = 0;
                SQLStatement = "SELECT T1.product_id, T1.category_code, T1.inventory_type, T1.item_name, T1.unit_of_measure, T1.unit_cost, T1.selling_price, T1.bar_code, T1.sku FROM " +
                "(SELECT product_id, category_code, inventory_type, item_name, unit_of_measure, unit_cost, bar_code, sku FROM tbl_inventory_products_masterlist) AS T1 " +
                "LEFT JOIN (SELECT transaction_id, product_id, quantity, discount, total_amount, status FROM tbl_purchase_order_transactions) AS T2 ON T1.product_id = T2.product_id WHERE T1.product_id = '" + Search + "' OR T1.item_name LIKE'%' '" + Search + "' '%' AND T1.item_name = '" + ProductItemSearch + "' AND T1.status = 'Active' GROUP BY T1.transaction_id ORDER BY T1.transaction_id DESC";

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


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frmInventory_CustomerPurchaseOrder_AddNewTransaction"].Refresh();
            Application.OpenForms["frmInventory_CustomerPurchaseOrder_AddNewTransaction"].Activate(); // Bring the parent form to the front
        }

        private void dgvTransaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MySqlConnect Conns = new MySqlConnect();

            //Delete
            //if (e.ColumnIndex == 10)
            //{
            //    productID = Convert.ToInt32(dgvTransaction.Rows[e.RowIndex].Cells[1].Value);
            //    //TransactionID = Convert.ToInt32(Conns.mySqlDataReader["transaction_id"].ToString());

            //    new classMsgBox().showMsgConfirmation_Delete("Do you really want to Delete this record?");
            //    if (Global.msgConfirmation == true)
            //    {
            //        // your codes here when the OK button has been pressed
            //        ucInventory_InventoryIn_CartItem ucInventory_InventoryIn_CartItem = new ucInventory_InventoryIn_CartItem();
            //        ucInventory_InventoryIn_CartItem.Hide();
            //        Conns.mySqlCmd = new MySqlCommand("update tbl_inventory_customer_po set status = 'Deleted' WHERE product_id = " + productID /*+ " AND transaction_id = " + TransactionID*/, Conns.mySqlconn);
            //        Conns.mySqlCmd.ExecuteNonQuery();
            //        new classMsgBox().showMsgSuccessful("Deleted Successfully");
            //    }
            //    dgvTransaction.Refresh();
            //    Application.OpenForms["frmInventory_CustomerPurchaseOrder_AddNewTransaction"].Activate(); // Bring the parent form to the front
            //}
        }

        private void cboProductItemSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductItemSearch = cboProductItemSearch.Text;
            dgvTransaction.Rows.Clear();

            if (ProductItemSearch != null)
            {

                MySqlConnect Conns = new MySqlConnect();
                int i = 0;
                //SQLStatement = "SELECT product_id, barcode, sku, category_code, item_name FROM tbl_purchase_order_transactions WHERE inventory_type = '" + InventoryTypeSearch + "' AND status = 'Active' GROUP BY transaction_id ORDER BY transaction_id DESC";
                //SQLStatement = "SELECT T1.product_id, T1.bar_code, T1.sku, T1.inventory_type, T1.category_code, T1.item_name, T1.status FROM " +
                //"(SELECT product_id, bar_code, sku, inventory_type, category_code, item_name, status FROM tbl_inventory_products_masterlist) AS T1 " +
                //"WHERE T1.product_id = '" + Search + "' OR T1.item_name LIKE'%' '" + Search + "' '%' AND T1.inventory_type = '" + InventoryTypeSearch + "' AND T1.status = 'Active' ORDER BY T1.item_name ASC";
                SQLStatement = "SELECT product_id, category_code, inventory_type, item_name, unit_of_measure, unit_cost, selling_price, bar_code, sku, status FROM tbl_inventory_products_masterlist WHERE product_id = '" + Search + "' OR item_name LIKE'%' '" + Search + "' '%' AND item_name = '" + ProductItemSearch + "' AND status = 'Active' GROUP BY product_id ORDER BY product_id DESC";

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

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void cboCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomerIDSearch = Convert.ToInt32(cboCustomerID.Text);

            if (CustomerIDSearch != 0)
            {

                MySqlConnect Conns = new MySqlConnect();
                int i = 0;
                SQLStatement = "SELECT  Autonum, customer_type, customer_name, business_style, phone, address, record_status FROM tbl_inventory_customer_list WHERE Autonum = '" + CustomerIDSearch + "' AND record_status = 'Active' GROUP BY Autonum ORDER BY Autonum DESC";


                Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                while (Conns.mySqlDataReader.Read())
                {
                    txtCustomerName.Text = Conns.mySqlDataReader["customer_name"].ToString();
                    txtPhone.Text = Conns.mySqlDataReader["phone"].ToString();
                    txtAddress.Text = Conns.mySqlDataReader["address"].ToString();
                    txtBusinessStyle.Text = Conns.mySqlDataReader["business_style"].ToString();

                }
                Conns.mySqlconn.Close();
            }
        }

        private void cbxCustomerNumberAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCustomerNumberAuto.Checked == true)
            {
                CustomerID = "txtCustomerID";
                cboCustomerID.Enabled = false;
                txtCustomerID.Show();

                txtCustomerID.Enabled = true;
                txtCustomerID.Text = "Automatic";
                txtCustomerType.Enabled = true;
                txtCustomerName.Enabled = true;
                txtOrderingPasscode.Enabled = true;
                txtTIN.Enabled = true;
                txtBusinessStyle.Enabled = true;
                txtPhone.Enabled = true;
                txtAddress.Enabled = true;

                cboCustomerID.Text = "";
                txtCustomerType.Text = "";
                txtCustomerName.Text = "";
                txtOrderingPasscode.Text = "";
                txtTIN.Text = "";
                txtBusinessStyle.Text = "";
                txtPhone.Text = "";
                txtAddress.Text = "";
            }
            else
            {
                CustomerID = "cboCustomerID";
                cboCustomerID.Enabled = true;
                txtCustomerID.Hide();

                txtCustomerID.Enabled = false;
                txtCustomerType.Enabled = false;
                txtCustomerName.Enabled = false;
                txtTIN.Enabled = false;
                txtOrderingPasscode.Enabled = false;
                txtBusinessStyle.Enabled = false;
                txtPhone.Enabled = false;
                txtAddress.Enabled = false;


                cboCustomerID.Text = "";
                txtCustomerType.Text = "";
                txtCustomerName.Text = "";
                txtOrderingPasscode.Text = "";
                txtTIN.Text = "";
                txtBusinessStyle.Text = "";
                txtPhone.Text = "";
                txtAddress.Text = "";
            }
        }
        private void generateCustomerID()
        {
            MySqlConnect Conns = new MySqlConnect();
            newCustomerID = 0;
            SQLStatement = "SELECT Autonum FROM tbl_inventory_customer_po ORDER BY Autonum DESC LIMIT 1";
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
                    newCustomerID = Convert.ToInt32(Conns.mySqlDataReader["Autonum"].ToString());
                    newCustomerID++;
                    txtCustomerID.Text = newCustomerID.ToString();
                }
            }
            else
            {
                    txtCustomerID.Text = "1";
            }
            Conns.mySqlconn.Close();

        }
    }
}
