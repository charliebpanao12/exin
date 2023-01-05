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
using EXIN;
using EXIN.Controller;

namespace EXIN.Inventory_System
{
    public partial class frmInventory_Products_NewItem : Form
    {
        public int productID;
        public string productName;
        public string AddOrEditorView;
        public string status;

        public frmInventory_Products_NewItem()
        {
            InitializeComponent();
            // Controls - Button 3
            btnCancel.FillColor = Global.themeColor1;
            btnCancel.FillColor2 = Global.themeColor2;

            // Controls - Button 3
            btnSave.FillColor = Global.themeColor1;
            btnSave.FillColor2 = Global.themeColor2;

            // Controls - Textbox 2
            txtProductID.BorderColor = Global.themeColor1;
            txtProductID.FocusedState.BorderColor = Global.themeColor2;
            txtProductID.HoverState.BorderColor = Global.themeColor2;

            // Controls - Combobox
            cboCategory.BorderColor = Global.themeColor1;
            cboCategory.FocusedState.BorderColor = Global.themeColor2;
            cboCategory.HoverState.BorderColor = Global.themeColor2;

            // Controls - Combobox
            cboInventoryType.BorderColor = Global.themeColor1;
            cboInventoryType.FocusedState.BorderColor = Global.themeColor2;
            cboInventoryType.HoverState.BorderColor = Global.themeColor2;

            // Panel Title
            panelTitleBar.CustomBorderColor = Global.themeColor2;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            //ucInventory_Products ucInventory_Products = new ucInventory_Products();
            //ucInventory_Products.Show();
        }

        //Clear Data  
        public void ClearData()
        {
            txtProductID.Text = "Automatic";
            cboInventoryType.Text = "";
            cboCategory.Text = "";
            txtItemName.Text = "";
            txtDescription.Text = "";
            txtUnitOfMeasure.Text = "";
            txtItemColor.Text = "";
            txtItemBrand.Text = "";
            txtItemVariant.Text = "";
            txtSKU.Text = "";
            numtxtUnitCost.Text = "";
            numtxtSellingPrice.Text = "";
            txtItemSize.Text = "";
            txtSBarCode.Text = "";
            numtxtBeginningInventory.Text = "";
            numtxtActualCount.Text = "";
        }
        public void Alert(string msg, frmAlert.alertTypeEnum type)
        {
            frmAlert f = new frmAlert();
            f.setAlert(msg, type);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlConnect Conns = new MySqlConnect();
            //Validation for saving record
            if (cboInventoryType.Text == "")
            {
                //new classMsgBox().showMsgError("Please fill up the inventory type before you proceed!");
                this.Alert("Please fill up the inventory type before you proceed!", frmAlert.alertTypeEnum.Error);
                Application.OpenForms["frmInventory_Products_NewItem"].Activate(); // Bring the parent form to the front
                return;
            }
            if (cboCategory.Text == "")
            {
                new classMsgBox().showMsgError("Please fill up the category before you proceed!");
                Application.OpenForms["frmInventory_Products_NewItem"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtItemName.Text == "")
            {
                new classMsgBox().showMsgError("Please fill up the product name before you proceed!");
                Application.OpenForms["frmInventory_Products_NewItem"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtDescription.Text == "")
            {
                new classMsgBox().showMsgError("Please fill up the item description before you proceed!");
                Application.OpenForms["frmInventory_Products_NewItem"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtUnitOfMeasure.Text == "")
            {
                new classMsgBox().showMsgError("Please fill up the unit of measure before you proceed!");
                Application.OpenForms["frmInventory_Products_NewItem"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtItemColor.Text == "")
            {
                new classMsgBox().showMsgError("Please fill up the item color before you proceed!");
                Application.OpenForms["frmInventory_Products_NewItem"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtItemBrand.Text == "")
            {
                new classMsgBox().showMsgError("Please fill up the item brand before you proceed!");
                Application.OpenForms["frmInventory_Products_NewItem"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtItemVariant.Text == "")
            {
                new classMsgBox().showMsgError("Please fill up the item variant before you proceed!");
                Application.OpenForms["frmInventory_Products_NewItem"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtItemSize.Text == "")
            {
                new classMsgBox().showMsgError("Please fill up the item size before you proceed!");
                Application.OpenForms["frmInventory_Products_NewItem"].Activate(); // Bring the parent form to the front
                return;
            }
            if (numtxtUnitCost.Value == 0)
            {
                new classMsgBox().showMsgError("Only numbers are allowed in unit cost!");
                Application.OpenForms["frmInventory_Products_NewItem"].Activate(); // Bring the parent form to the front
                return;
            }
            if (numtxtSellingPrice.Value == 0)
            {
                new classMsgBox().showMsgError("Only numbers are allowed in selling price!");
                Application.OpenForms["frmInventory_Products_NewItem"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtSBarCode.Text == "")
            {
                new classMsgBox().showMsgError("Please fill up the bar code before you proceed!");
                Application.OpenForms["frmInventory_Products_NewItem"].Activate(); // Bring the parent form to the front
                return;
            }
            if (txtSKU.Text == "")
            {
                new classMsgBox().showMsgError("Please fill up the sku before you proceed!");
                Application.OpenForms["frmInventory_Products_NewItem"].Activate(); // Bring the parent form to the front
                return;
            }
            if (numtxtBeginningInventory.Value == 0)
            {
                new classMsgBox().showMsgError("Only numbers are allowed in beginning inventory!");
                Application.OpenForms["frmInventory_Products_NewItem"].Activate(); // Bring the parent form to the front
                return;
            }
            if (numtxtActualCount.Value == 0)
            {
                new classMsgBox().showMsgError("Only numbers are allowed in actual count!");
                Application.OpenForms["frmInventory_Products_NewItem"].Activate(); // Bring the parent form to the front
                return;
            }

            //if (cboInventoryType.Text == " " ||
            //            cboCategory.Text == " " ||
            //            txtItemName.Text == " " ||
            //            txtDescription.Text == "" ||
            //            txtUnitOfMeasure.Text == "" ||
            //            txtItemColor.Text == "" ||
            //            txtItemBrand.Text == "" ||
            //            txtItemVariant.Text == "" ||
            //            txtSKU.Text == "" ||
            //            numtxtUnitCost.Text == "" ||
            //            numtxtSellingPrice.Text == "" ||
            //            txtItemSize.Text == "" ||
            //            txtSBarCode.Text == "" ||
            //            numtxtBeginningInventory.Text == "" ||
            //            numtxtActualCount.Text == "")
            //{
            //        new classMsgBox().showMsgError("Fill up Empty Field");
            //        Application.OpenForms["frmInventory_Products_NewItem"].Activate(); // Bring the parent form to the front
            //}
            else
            {
                status = "active";
                new classMsgBox().showMsgConfirmation("Do you want to save?");
                // your codes here when the OK button has been pressed
                        if (Global.msgConfirmation == true)
                        {
                            if (AddOrEditorView == "Add")
                            {


                                Conns.mySqlCmd = new MySqlCommand("insert into tbl_inventory_products_masterlist" +
                                    " (product_id, " +
                                    "category_code," +
                                    "unit_code," +
                                    "inventory_type," +
                                    "item_category," +
                                    "item_name," +
                                    "item_description," +
                                    "unit_of_measure," +
                                    "item_color," +
                                    "item_brand," +
                                    "item_variant," +
                                    "item_size," +
                                    "unit_cost," +
                                    "selling_price," +
                                    "bar_code," +
                                    "sku," +
                                    "beginning_inventory," +
                                    "actual_count," +
                                    "status) " +
                                    "values " +
                                        "(@product_id, " +
                                        "@category_code," +
                                        "@unit_code," +
                                        "@inventory_type," +
                                        "@item_category," +
                                        "@item_name," +
                                        "@item_description," +
                                        "@unit_of_measure," +
                                        "@item_color," +
                                        "@item_brand," +
                                        "@item_variant," +
                                        "@item_size," +
                                        "@unit_cost," +
                                        "@selling_price," +
                                        "@bar_code," +
                                        "@sku," +
                                        "@beginning_inventory," +
                                        "@actual_count," +
                                        "@status)",
                                        Conns.mySqlconn);
                                Conns.mySqlCmd.Parameters.AddWithValue("product_id", txtProductID.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("category_code", Global.inventoryBusinessCategoryCode);
                                Conns.mySqlCmd.Parameters.AddWithValue("unit_code", Global.inventoryBusinessUnitCode);
                                Conns.mySqlCmd.Parameters.AddWithValue("inventory_type", cboInventoryType.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("item_category", cboCategory.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("item_name", txtItemName.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("item_description", txtDescription.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("unit_of_measure", txtUnitOfMeasure.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("item_color", txtItemColor.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("item_brand", txtItemBrand.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("item_variant", txtItemVariant.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("sku", txtSKU.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("unit_cost", numtxtUnitCost.Value);
                                Conns.mySqlCmd.Parameters.AddWithValue("selling_price", numtxtSellingPrice.Value);
                                Conns.mySqlCmd.Parameters.AddWithValue("item_size", txtItemSize.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("bar_code", txtSBarCode.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("beginning_inventory", numtxtBeginningInventory.Value);
                                Conns.mySqlCmd.Parameters.AddWithValue("actual_count", numtxtActualCount.Value);
                                Conns.mySqlCmd.Parameters.AddWithValue("status", status);
                                Conns.mySqlCmd.ExecuteNonQuery();
                                Conns.mySqlconn.Close();
                                ClearData();
                                new classMsgBox().showMsgSuccessful("Successfully Saved!");
                            }
                            else if (AddOrEditorView == "Edit")
                            {
                                Conns.mySqlCmd = new MySqlCommand("update tbl_inventory_products_masterlist set " +
                                    "category_code=@category_code," +
                                    "unit_code=@unit_code," +
                                    "inventory_type=@inventory_type," +
                                    "item_category=@item_category," +
                                    "item_name=@item_name," +
                                    "item_description=@item_description," +
                                    "unit_of_measure=@unit_of_measure," +
                                    "item_color=@item_color," +
                                    "item_brand=@item_brand," +
                                    "item_variant=@item_variant," +
                                    "item_size=@item_size," +
                                    "unit_cost=@unit_cost," +
                                    "selling_price=@selling_price," +
                                    "bar_code=@bar_code," +
                                    "sku=@sku," +
                                    "beginning_inventory=@beginning_inventory," +
                                    "actual_count=@actual_count WHERE product_id = " + productID, Conns.mySqlconn);
                                //Conns.mySqlCmd.Parameters.AddWithValue("product_id", txtProductID.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("category_code", Global.inventoryBusinessCategoryCode);
                                Conns.mySqlCmd.Parameters.AddWithValue("unit_code", Global.inventoryBusinessUnitCode);
                                Conns.mySqlCmd.Parameters.AddWithValue("inventory_type", cboInventoryType.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("item_category", cboCategory.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("item_name", txtItemName.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("item_description", txtDescription.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("unit_of_measure", txtUnitOfMeasure.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("item_color", txtItemColor.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("item_brand", txtItemBrand.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("item_variant", txtItemVariant.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("sku", txtSKU.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("unit_cost", numtxtUnitCost.Value);
                                Conns.mySqlCmd.Parameters.AddWithValue("selling_price", numtxtSellingPrice.Value);
                                Conns.mySqlCmd.Parameters.AddWithValue("item_size", txtItemSize.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("bar_code", txtSBarCode.Text);
                                Conns.mySqlCmd.Parameters.AddWithValue("beginning_inventory", numtxtBeginningInventory.Value);
                                Conns.mySqlCmd.Parameters.AddWithValue("actual_count", numtxtActualCount.Value);
                                Conns.mySqlCmd.ExecuteNonQuery();
                                Conns.mySqlconn.Close();
                                new classMsgBox().showMsgSuccessful("Successfully Updated!");
                            }
                        }
                        else
                        {
                                // your codes here when the NO button has been pressed
                                Application.OpenForms["frmInventory_Products_NewItem"].Activate(); // Bring the parent form to the fron
      
                        }
                        Application.OpenForms["frmInventory_Products_NewItem"].Activate(); // Bring the parent form to the fron
                        this.Hide();
            }
        }

                private void cboInventoryType_SelectedIndexChanged(object sender, EventArgs e)
                {

                }

                private void frmInventory_Products_NewItem_Load(object sender, EventArgs e)
                {
                guna2ShadowForm1.SetShadowForm(this);
                MySqlConnect Conns = new MySqlConnect();
                int i = 0;

                        Conns.mySqlCmd = new MySqlCommand("SELECT distinct inventory_type FROM tbl_inventory_products_masterlist", Conns.mySqlconn);
                        Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                            while (Conns.mySqlDataReader.Read())
                            {
                                i++;
                                cboInventoryType.Items.Add(Conns.mySqlDataReader["inventory_type"].ToString());
                            }

                        Conns.mySqlCmd = new MySqlCommand("SELECT distinct item_category FROM tbl_inventory_products_masterlist", Conns.mySqlconn);
                        Conns.mySqlDataReader.Close();
                        Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                            while (Conns.mySqlDataReader.Read())
                            {
                                i++;
                                cboCategory.Items.Add(Conns.mySqlDataReader["item_category"].ToString());
                            }

                        Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_inventory_products_masterlist WHERE product_id = " + productID, Conns.mySqlconn);
                        Conns.mySqlDataReader.Close();
                        Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                            while (Conns.mySqlDataReader.Read())
                            {
                                txtProductID.Text = Conns.mySqlDataReader["product_id"].ToString();
                                cboInventoryType.Text = Conns.mySqlDataReader["inventory_type"].ToString();
                                cboCategory.Text = Conns.mySqlDataReader["item_category"].ToString();
                                txtItemName.Text = Conns.mySqlDataReader["item_name"].ToString();
                                txtDescription.Text = Conns.mySqlDataReader["item_description"].ToString();
                                txtUnitOfMeasure.Text = Conns.mySqlDataReader["unit_of_measure"].ToString();
                                txtItemColor.Text = Conns.mySqlDataReader["item_color"].ToString();
                                txtItemBrand.Text = Conns.mySqlDataReader["item_brand"].ToString();
                                txtItemVariant.Text = Conns.mySqlDataReader["item_variant"].ToString();
                                txtItemSize.Text = Conns.mySqlDataReader["item_size"].ToString();
                                numtxtUnitCost.Value = Convert.ToInt32(Conns.mySqlDataReader["unit_cost"].ToString());
                                numtxtSellingPrice.Value = Convert.ToInt32(Conns.mySqlDataReader["selling_price"].ToString());
                                txtSBarCode.Text = Conns.mySqlDataReader["bar_code"].ToString();
                                txtSKU.Text = Conns.mySqlDataReader["sku"].ToString();
                                numtxtBeginningInventory.Value = Convert.ToInt32(Conns.mySqlDataReader["beginning_inventory"].ToString());
                                numtxtActualCount.Value = Convert.ToInt32(Conns.mySqlDataReader["actual_count"].ToString());
                            }

                                    if (AddOrEditorView == "View")
                                    {
                                        Conns.mySqlCmd = new MySqlCommand("SELECT * FROM tbl_inventory_products_masterlist WHERE product_id = " + productID, Conns.mySqlconn);
                                        Conns.mySqlDataReader.Close();
                                        Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                                        while (Conns.mySqlDataReader.Read())
                                        {
                                            txtProductID.Text = Conns.mySqlDataReader["product_id"].ToString();
                                            cboInventoryType.Text = Conns.mySqlDataReader["inventory_type"].ToString();
                                            cboCategory.Text = Conns.mySqlDataReader["item_category"].ToString();
                                            txtItemName.Text = Conns.mySqlDataReader["item_name"].ToString();
                                            txtDescription.Text = Conns.mySqlDataReader["item_description"].ToString();
                                            txtUnitOfMeasure.Text = Conns.mySqlDataReader["unit_of_measure"].ToString();
                                            txtItemColor.Text = Conns.mySqlDataReader["item_color"].ToString();
                                            txtItemBrand.Text = Conns.mySqlDataReader["item_brand"].ToString();
                                            txtItemVariant.Text = Conns.mySqlDataReader["item_variant"].ToString();
                                            txtItemSize.Text = Conns.mySqlDataReader["item_size"].ToString();
                                            numtxtUnitCost.Value = Convert.ToInt32(Conns.mySqlDataReader["unit_cost"].ToString());
                                            numtxtSellingPrice.Value = Convert.ToInt32(Conns.mySqlDataReader["selling_price"].ToString());
                                            txtSBarCode.Text = Conns.mySqlDataReader["bar_code"].ToString();
                                            txtSKU.Text = Conns.mySqlDataReader["sku"].ToString();
                                            numtxtBeginningInventory.Value = Convert.ToInt32(Conns.mySqlDataReader["beginning_inventory"].ToString());
                                            numtxtActualCount.Value = Convert.ToInt32(Conns.mySqlDataReader["actual_count"].ToString());
                                        }
                                        txtProductID.Enabled = false;
                                        cboInventoryType.Enabled = false;
                                        cboCategory.Enabled = false;
                                        txtItemName.Enabled = false;
                                        txtDescription.Enabled = false;
                                        txtUnitOfMeasure.Enabled = false;
                                        txtItemColor.Enabled = false;
                                        txtItemBrand.Enabled = false;
                                        txtItemVariant.Enabled = false;
                                        txtItemSize.Enabled = false;
                                        numtxtUnitCost.Enabled = false;
                                        numtxtSellingPrice.Enabled = false;
                                        txtSBarCode.Enabled = false;
                                        txtSKU.Enabled = false;
                                        numtxtBeginningInventory.Enabled = false;
                                        numtxtActualCount.Enabled = false;
                                        panelFooter.Visible = false;
                                        panelViewFooter.Visible = true;

                                    }

                }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frmInventory_Products_NewItem"].Activate(); // Bring the parent form to the fron
            this.Hide();
        }
    }
}
