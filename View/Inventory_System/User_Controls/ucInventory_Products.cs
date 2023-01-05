using EXIN.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EXIN.Inventory_System
{
    public partial class ucInventory_Products : UserControl
    {
        public int productID;
        public string productName;
        public string AddOrEditorView;

        public string InventoryTypeSearch;
        public string CategoryTypeSearch;
        public string BranchProjectSearch;

        public string SQLStatement;
        public string FilterLoad;
        public string strSearch;
        int i;

        public ucInventory_Products()
        {
            InitializeComponent();

            // Controls - Button 1
            btnAddNewItem.FillColor = Global.themeColor1;
            btnAddNewItem.HoverState.FillColor = Global.themeColor2;
            btnAddNewItem.HoverState.ForeColor = Global.themeForeColor;

            // Controls - Button 1
            btnDeleteItem.FillColor = Global.themeColor1;
            btnDeleteItem.HoverState.FillColor = Global.themeColor2;
            btnDeleteItem.HoverState.ForeColor = Global.themeForeColor;

            // Panel with Datagrid
            panelRecords.CustomBorderColor = Global.themeColor1;

            // Controls - txtSearch
            txtSearch.BorderColor = Global.themeColor1;
            txtSearch.FocusedState.BorderColor = Global.themeColor2;
            txtSearch.HoverState.BorderColor = Global.themeColor2;

            #region Filter Box
            // Controls - Filter
            panelFilter_Header.FillColor = Global.themeColor2;
            grpFilter.ForeColor = Global.themeColor1;
            btnApplyFilter.FillColor = Global.themeColor1;
            btnApplyFilter.FillColor2 = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboInventoryTypeSearch.BorderColor = Global.themeColor1;
            cboInventoryTypeSearch.FocusedState.BorderColor = Global.themeColor2;
            cboInventoryTypeSearch.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboCategoryTypeSearch.BorderColor = Global.themeColor1;
            cboCategoryTypeSearch.FocusedState.BorderColor = Global.themeColor2;
            cboCategoryTypeSearch.HoverState.BorderColor = Global.themeColor2;

            // Controls - Filter - ComboBox
            cboBranchProjectSearch.BorderColor = Global.themeColor1;
            cboBranchProjectSearch.FocusedState.BorderColor = Global.themeColor2;
            cboBranchProjectSearch.HoverState.BorderColor = Global.themeColor2;

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

        private void dgvRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MySqlConnect Conns = new MySqlConnect();
            //Edit
            if (e.ColumnIndex == 1)
            {
                frmInventory_Products_NewItem frmInventory_Products_NewItem = new frmInventory_Products_NewItem();
                frmInventory_Products_NewItem.AddOrEditorView = "Edit";
                frmInventory_Products_NewItem.productID = Convert.ToInt32(dgvRecords.Rows[e.RowIndex].Cells[4].Value);
                frmInventory_Products_NewItem.ShowDialog();
            }
            //Delete
            else if (e.ColumnIndex == 2)
            {
                int productID = Convert.ToInt32(dgvRecords.Rows[e.RowIndex].Cells[4].Value);
                new classMsgBox().showMsgConfirmation_Delete("Do you really want to Delete this record?");
                if (Global.msgConfirmation == true)
                {
                    // your codes here when the OK button has been pressed
                   
                        Conns.mySqlCmd = new MySqlCommand("update tbl_inventory_products_masterlist set status = 'Deleted' WHERE product_id =" + productID, Conns.mySqlconn);
                        Conns.mySqlCmd.ExecuteNonQuery();
                        new classMsgBox().showMsgSuccessful("Deleted Successfully");
                }
                Application.OpenForms["frmInventory_ParentContainer"].Activate(); // Bring the parent form to the front
            //View
            }
            else if (e.ColumnIndex == 3)
            {
                frmInventory_Products_NewItem frmInventory_Products_NewItem = new frmInventory_Products_NewItem();
                frmInventory_Products_NewItem.AddOrEditorView = "View";
                frmInventory_Products_NewItem.productID = Convert.ToInt32(dgvRecords.Rows[e.RowIndex].Cells[4].Value);
                frmInventory_Products_NewItem.ShowDialog();
            }

        }
        private void ucInventory_Products_DataLoad()
        {
            InventoryTypeSearch = cboInventoryTypeSearch.Text;
            CategoryTypeSearch = cboCategoryTypeSearch.Text;
            BranchProjectSearch = cboBranchProjectSearch.Text;

            if (InventoryTypeSearch != null && CategoryTypeSearch == "" && BranchProjectSearch == "")
            {

                SQLStatement = "SELECT T1.product_id, T1.bar_code, T1.sku, T1.inventory_type, T1.item_category, T1.item_name, T1.item_description, T1.unit_of_measure, T1.unit_cost, T1.selling_price, T1.item_color, T1.item_brand, T1.item_variant, T1.item_size, T1.beginning_inventory, T1.actual_count, T2.total_in, T3.total_out, T4.total_PO, T5.total_CustomerPO FROM " +
                "(SELECT product_id, bar_code, sku, inventory_type, item_category, item_name, item_description, unit_of_measure, unit_cost, selling_price, item_color, item_brand, item_variant, item_size, beginning_inventory, actual_count FROM tbl_inventory_products_masterlist WHERE inventory_type = '" + InventoryTypeSearch + "' AND unit_code = '" + Global.inventoryBusinessUnitCode + "' AND status = 'Active') as T1 " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_in, status FROM tbl_inventory_in_transactions WHERE status = 'Active' GROUP BY product_id) as T2 on T1.product_id = T2.product_id " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_out, status FROM tbl_inventory_out_transactions WHERE status = 'Active' GROUP BY product_id) as T3 on T1.product_id = T3.product_id " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_PO, status FROM tbl_purchase_order_transactions WHERE status = 'Active' GROUP BY product_id) AS T4 on T1.product_id = T4.product_id " +
                "LEFT JOIN (SELECT po_id, product_id, SUM(order_quantity) AS total_CustomerPO, record_status FROM tbl_inventory_customer_po WHERE record_status = 'Active' GROUP BY product_id) AS T5 on T1.product_id = T5.product_id ORDER BY T1.product_id ASC";


                Image Editicon = Image.FromFile("Resources/General/Datagrid_Images/edit.jpg");
                Image Deleteicon = Image.FromFile("Resources/General/Datagrid_Images/delete.jpg");
                Image Viewicon = Image.FromFile("Resources/General/Datagrid_Images/view.jpg");

                dgvRecords.Rows.Clear();

                MySqlConnect Conns = new MySqlConnect();
                Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                while (Conns.mySqlDataReader.Read())
                {
                    i++;
                    dgvRecords.Rows.Add(i, cledit.Image = Editicon, cldelete.Image = Deleteicon, clview.Image = Viewicon,
                        Conns.mySqlDataReader["product_id"].ToString(),
                        Conns.mySqlDataReader["bar_code"].ToString(),
                        Conns.mySqlDataReader["sku"].ToString(),
                        Conns.mySqlDataReader["inventory_type"].ToString(),
                        Conns.mySqlDataReader["item_category"].ToString(),
                        Conns.mySqlDataReader["item_name"].ToString(),
                        Conns.mySqlDataReader["item_description"].ToString(),
                        Conns.mySqlDataReader["unit_of_measure"].ToString(),
                        Conns.mySqlDataReader["unit_cost"].ToString(),
                        Conns.mySqlDataReader["selling_price"].ToString(),
                        Conns.mySqlDataReader["item_color"].ToString(),
                        Conns.mySqlDataReader["item_brand"].ToString(),
                        Conns.mySqlDataReader["item_variant"].ToString(),
                        Conns.mySqlDataReader["item_size"].ToString(),
                        Conns.mySqlDataReader["beginning_inventory"].ToString(),
                        Conns.mySqlDataReader["actual_count"].ToString(),
                        Conns.mySqlDataReader["total_in"].ToString(),
                        Conns.mySqlDataReader["total_out"].ToString(),
                        Conns.mySqlDataReader["total_PO"].ToString(),
                        Conns.mySqlDataReader["total_CustomerPO"].ToString());
                }
                Conns.mySqlconn.Close();
            }
            else if (CategoryTypeSearch != null && InventoryTypeSearch == "" && BranchProjectSearch == "")
            {

                SQLStatement = "SELECT T1.product_id, T1.bar_code, T1.sku, T1.inventory_type, T1.item_category, T1.item_name, T1.item_description, T1.unit_of_measure, T1.unit_cost, T1.selling_price, T1.item_color, T1.item_brand, T1.item_variant, T1.item_size, T1.beginning_inventory, T1.actual_count, T2.total_in, T3.total_out, T4.total_PO, T5.total_CustomerPO FROM " +
                "(SELECT product_id, bar_code, sku, inventory_type, item_category, item_name, item_description, unit_of_measure, unit_cost, selling_price, item_color, item_brand, item_variant, item_size, beginning_inventory, actual_count FROM tbl_inventory_products_masterlist WHERE item_category = '" + CategoryTypeSearch + "'AND unit_code = '" + Global.inventoryBusinessUnitCode + "' AND status = 'Active') as T1 " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_in, status FROM tbl_inventory_in_transactions  WHERE status = 'Active' GROUP BY product_id) as T2 on T1.product_id = T2.product_id " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_out, status FROM tbl_inventory_out_transactions WHERE status = 'Active' GROUP BY product_id) as T3 on T1.product_id = T3.product_id " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_PO, status FROM tbl_purchase_order_transactions WHERE status = 'Active' GROUP BY product_id) AS T4 on T1.product_id = T4.product_id " +
                "LEFT JOIN (SELECT po_id, product_id, SUM(order_quantity) AS total_CustomerPO, record_status FROM tbl_inventory_customer_po WHERE record_status = 'Active' GROUP BY product_id) AS T5 on T1.product_id = T5.product_id ORDER BY T1.product_id ASC";


                Image Editicon = Image.FromFile("Resources/General/Datagrid_Images/edit.jpg");
                Image Deleteicon = Image.FromFile("Resources/General/Datagrid_Images/delete.jpg");
                Image Viewicon = Image.FromFile("Resources/General/Datagrid_Images/view.jpg");

                dgvRecords.Rows.Clear();

                MySqlConnect Conns = new MySqlConnect();
                Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                while (Conns.mySqlDataReader.Read())
                {
                    i++;
                    dgvRecords.Rows.Add(i, cledit.Image = Editicon, cldelete.Image = Deleteicon, clview.Image = Viewicon,
                        Conns.mySqlDataReader["product_id"].ToString(),
                        Conns.mySqlDataReader["bar_code"].ToString(),
                        Conns.mySqlDataReader["sku"].ToString(),
                        Conns.mySqlDataReader["inventory_type"].ToString(),
                        Conns.mySqlDataReader["item_category"].ToString(),
                        Conns.mySqlDataReader["item_name"].ToString(),
                        Conns.mySqlDataReader["item_description"].ToString(),
                        Conns.mySqlDataReader["unit_of_measure"].ToString(),
                        Conns.mySqlDataReader["unit_cost"].ToString(),
                        Conns.mySqlDataReader["selling_price"].ToString(),
                        Conns.mySqlDataReader["item_color"].ToString(),
                        Conns.mySqlDataReader["item_brand"].ToString(),
                        Conns.mySqlDataReader["item_variant"].ToString(),
                        Conns.mySqlDataReader["item_size"].ToString(),
                        Conns.mySqlDataReader["beginning_inventory"].ToString(),
                        Conns.mySqlDataReader["actual_count"].ToString(),
                        Conns.mySqlDataReader["total_in"].ToString(),
                        Conns.mySqlDataReader["total_out"].ToString(),
                        Conns.mySqlDataReader["total_PO"].ToString(),
                        Conns.mySqlDataReader["total_CustomerPO"].ToString());
                }
                Conns.mySqlconn.Close();
            }
            else if (BranchProjectSearch != null && InventoryTypeSearch == "" && CategoryTypeSearch == "")
            {

                SQLStatement = "SELECT T1.product_id, T1.bar_code, T1.sku, T1.inventory_type, T1.item_category, T1.item_name, T1.item_description, T1.unit_of_measure, T1.unit_cost, T1.selling_price, T1.item_color, T1.item_brand, T1.item_variant, T1.item_size, T1.beginning_inventory, T1.actual_count, T2.total_in, T3.total_out, T4.total_PO, T5.total_CustomerPO FROM " +
                "(SELECT product_id, bar_code, sku, inventory_type, item_category, item_name, item_description, unit_of_measure, unit_cost, selling_price, item_color, item_brand, item_variant, item_size, beginning_inventory, actual_count FROM tbl_inventory_products_masterlist WHERE category_code = '" + Global.inventoryBusinessCategoryCode + "'AND unit_code = '" + Global.inventoryBusinessUnitCode + "' AND status = 'Active') as T1 " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_in, status FROM tbl_inventory_in_transactions  WHERE status = 'Active' GROUP BY product_id) as T2 on T1.product_id = T2.product_id " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_out, status FROM tbl_inventory_out_transactions WHERE status = 'Active' GROUP BY product_id) as T3 on T1.product_id = T3.product_id " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_PO, status FROM tbl_purchase_order_transactions WHERE status = 'Active' GROUP BY product_id) AS T4 on T1.product_id = T4.product_id " +
                "LEFT JOIN (SELECT po_id, product_id, SUM(order_quantity) AS total_CustomerPO, record_status FROM tbl_inventory_customer_po WHERE record_status = 'Active' GROUP BY product_id) AS T5 on T1.product_id = T5.product_id ORDER BY T1.product_id ASC";


                Image Editicon = Image.FromFile("Resources/General/Datagrid_Images/edit.jpg");
                Image Deleteicon = Image.FromFile("Resources/General/Datagrid_Images/delete.jpg");
                Image Viewicon = Image.FromFile("Resources/General/Datagrid_Images/view.jpg");

                dgvRecords.Rows.Clear();

                MySqlConnect Conns = new MySqlConnect();
                Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                while (Conns.mySqlDataReader.Read())
                {
                    i++;
                    dgvRecords.Rows.Add(i, cledit.Image = Editicon, cldelete.Image = Deleteicon, clview.Image = Viewicon,
                        Conns.mySqlDataReader["product_id"].ToString(),
                        Conns.mySqlDataReader["bar_code"].ToString(),
                        Conns.mySqlDataReader["sku"].ToString(),
                        Conns.mySqlDataReader["inventory_type"].ToString(),
                        Conns.mySqlDataReader["item_category"].ToString(),
                        Conns.mySqlDataReader["item_name"].ToString(),
                        Conns.mySqlDataReader["item_description"].ToString(),
                        Conns.mySqlDataReader["unit_of_measure"].ToString(),
                        Conns.mySqlDataReader["unit_cost"].ToString(),
                        Conns.mySqlDataReader["selling_price"].ToString(),
                        Conns.mySqlDataReader["item_color"].ToString(),
                        Conns.mySqlDataReader["item_brand"].ToString(),
                        Conns.mySqlDataReader["item_variant"].ToString(),
                        Conns.mySqlDataReader["item_size"].ToString(),
                        Conns.mySqlDataReader["beginning_inventory"].ToString(),
                        Conns.mySqlDataReader["actual_count"].ToString(),
                        Conns.mySqlDataReader["total_in"].ToString(),
                        Conns.mySqlDataReader["total_out"].ToString(),
                        Conns.mySqlDataReader["total_PO"].ToString(),
                        Conns.mySqlDataReader["total_CustomerPO"].ToString());
                }
                Conns.mySqlconn.Close();
            }
            else if (InventoryTypeSearch != null && CategoryTypeSearch != null && BranchProjectSearch == "")
            {
                
                SQLStatement = "SELECT T1.product_id, T1.bar_code, T1.sku, T1.inventory_type, T1.item_category, T1.item_name, T1.item_description, T1.unit_of_measure, T1.unit_cost, T1.selling_price, T1.item_color, T1.item_brand, T1.item_variant, T1.item_size, T1.beginning_inventory, T1.actual_count, T2.total_in, T3.total_out, T4.total_PO, T5.total_CustomerPO FROM " +
                "(SELECT product_id, bar_code, sku, inventory_type, item_category, item_name, item_description, unit_of_measure, unit_cost, selling_price, item_color, item_brand, item_variant, item_size, beginning_inventory, actual_count FROM tbl_inventory_products_masterlist WHERE inventory_type = '" + InventoryTypeSearch + "' AND item_category = '" + CategoryTypeSearch + "'AND unit_code = '" + Global.inventoryBusinessUnitCode + "' AND status = 'Active') as T1 " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_in, status FROM tbl_inventory_in_transactions  WHERE status = 'Active' GROUP BY product_id) as T2 on T1.product_id = T2.product_id " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_out, status FROM tbl_inventory_out_transactions WHERE status = 'Active' GROUP BY product_id) as T3 on T1.product_id = T3.product_id " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_PO, status FROM tbl_purchase_order_transactions WHERE status = 'Active' GROUP BY product_id) AS T4 on T1.product_id = T4.product_id " +
                "LEFT JOIN (SELECT po_id, product_id, SUM(order_quantity) AS total_CustomerPO, record_status FROM tbl_inventory_customer_po WHERE record_status = 'Active' GROUP BY product_id) AS T5 on T1.product_id = T5.product_id ORDER BY T1.product_id ASC";


                Image Editicon = Image.FromFile("Resources/General/Datagrid_Images/edit.jpg");
                Image Deleteicon = Image.FromFile("Resources/General/Datagrid_Images/delete.jpg");
                Image Viewicon = Image.FromFile("Resources/General/Datagrid_Images/view.jpg");

                dgvRecords.Rows.Clear();

                MySqlConnect Conns = new MySqlConnect();
                Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                while (Conns.mySqlDataReader.Read())
                {
                    i++;
                    dgvRecords.Rows.Add(i, cledit.Image = Editicon, cldelete.Image = Deleteicon, clview.Image = Viewicon,
                        Conns.mySqlDataReader["product_id"].ToString(),
                        Conns.mySqlDataReader["bar_code"].ToString(),
                        Conns.mySqlDataReader["sku"].ToString(),
                        Conns.mySqlDataReader["inventory_type"].ToString(),
                        Conns.mySqlDataReader["item_category"].ToString(),
                        Conns.mySqlDataReader["item_name"].ToString(),
                        Conns.mySqlDataReader["item_description"].ToString(),
                        Conns.mySqlDataReader["unit_of_measure"].ToString(),
                        Conns.mySqlDataReader["unit_cost"].ToString(),
                        Conns.mySqlDataReader["selling_price"].ToString(),
                        Conns.mySqlDataReader["item_color"].ToString(),
                        Conns.mySqlDataReader["item_brand"].ToString(),
                        Conns.mySqlDataReader["item_variant"].ToString(),
                        Conns.mySqlDataReader["item_size"].ToString(),
                        Conns.mySqlDataReader["beginning_inventory"].ToString(),
                        Conns.mySqlDataReader["actual_count"].ToString(),
                        Conns.mySqlDataReader["total_in"].ToString(),
                        Conns.mySqlDataReader["total_out"].ToString(),
                        Conns.mySqlDataReader["total_PO"].ToString(),
                        Conns.mySqlDataReader["total_CustomerPO"].ToString());
                }
                Conns.mySqlconn.Close();
            }
            
            else if (InventoryTypeSearch != null && CategoryTypeSearch == "" && BranchProjectSearch != null)
            {
                
                SQLStatement = "SELECT T1.product_id, T1.bar_code, T1.sku, T1.inventory_type, T1.item_category, T1.item_name, T1.item_description, T1.unit_of_measure, T1.unit_cost, T1.selling_price, T1.item_color, T1.item_brand, T1.item_variant, T1.item_size, T1.beginning_inventory, T1.actual_count, T2.total_in, T3.total_out, T4.total_PO, T5.total_CustomerPO FROM " +
                "(SELECT product_id, bar_code, sku, inventory_type, item_category, item_name, item_description, unit_of_measure, unit_cost, selling_price, item_color, item_brand, item_variant, item_size, beginning_inventory, actual_count FROM tbl_inventory_products_masterlist WHERE inventory_type = '" + InventoryTypeSearch + "' AND category_code= '" + Global.inventoryBusinessCategoryCode + "'AND unit_code = '" + Global.inventoryBusinessUnitCode + "' AND status = 'Active') as T1 " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_in, status FROM tbl_inventory_in_transactions  WHERE status = 'Active' GROUP BY product_id) as T2 on T1.product_id = T2.product_id " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_out, status FROM tbl_inventory_out_transactions WHERE status = 'Active' GROUP BY product_id) as T3 on T1.product_id = T3.product_id " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_PO, status FROM tbl_purchase_order_transactions WHERE status = 'Active' GROUP BY product_id) AS T4 on T1.product_id = T4.product_id " +
                "LEFT JOIN (SELECT po_id, product_id, SUM(order_quantity) AS total_CustomerPO, record_status FROM tbl_inventory_customer_po WHERE record_status = 'Active' GROUP BY product_id) AS T5 on T1.product_id = T5.product_id ORDER BY T1.product_id ASC";


                Image Editicon = Image.FromFile("Resources/General/Datagrid_Images/edit.jpg");
                Image Deleteicon = Image.FromFile("Resources/General/Datagrid_Images/delete.jpg");
                Image Viewicon = Image.FromFile("Resources/General/Datagrid_Images/view.jpg");

                dgvRecords.Rows.Clear();

                MySqlConnect Conns = new MySqlConnect();
                Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                while (Conns.mySqlDataReader.Read())
                {
                    i++;
                    dgvRecords.Rows.Add(i, cledit.Image = Editicon, cldelete.Image = Deleteicon, clview.Image = Viewicon,
                        Conns.mySqlDataReader["product_id"].ToString(),
                        Conns.mySqlDataReader["bar_code"].ToString(),
                        Conns.mySqlDataReader["sku"].ToString(),
                        Conns.mySqlDataReader["inventory_type"].ToString(),
                        Conns.mySqlDataReader["item_category"].ToString(),
                        Conns.mySqlDataReader["item_name"].ToString(),
                        Conns.mySqlDataReader["item_description"].ToString(),
                        Conns.mySqlDataReader["unit_of_measure"].ToString(),
                        Conns.mySqlDataReader["unit_cost"].ToString(),
                        Conns.mySqlDataReader["selling_price"].ToString(),
                        Conns.mySqlDataReader["item_color"].ToString(),
                        Conns.mySqlDataReader["item_brand"].ToString(),
                        Conns.mySqlDataReader["item_variant"].ToString(),
                        Conns.mySqlDataReader["item_size"].ToString(),
                        Conns.mySqlDataReader["beginning_inventory"].ToString(),
                        Conns.mySqlDataReader["actual_count"].ToString(),
                        Conns.mySqlDataReader["total_in"].ToString(),
                        Conns.mySqlDataReader["total_out"].ToString(),
                        Conns.mySqlDataReader["total_PO"].ToString(),
                        Conns.mySqlDataReader["total_CustomerPO"].ToString());
                }
                Conns.mySqlconn.Close();
            }
            else if (InventoryTypeSearch == "" && CategoryTypeSearch != null && BranchProjectSearch != null)
            {
                
                SQLStatement = "SELECT T1.product_id, T1.bar_code, T1.sku, T1.inventory_type, T1.item_category, T1.item_name, T1.item_description, T1.unit_of_measure, T1.unit_cost, T1.selling_price, T1.item_color, T1.item_brand, T1.item_variant, T1.item_size, T1.beginning_inventory, T1.actual_count, T2.total_in, T3.total_out, T4.total_PO, T5.total_CustomerPO FROM " +
                "(SELECT product_id, bar_code, sku, inventory_type, item_category, item_name, item_description, unit_of_measure, unit_cost, selling_price, item_color, item_brand, item_variant, item_size, beginning_inventory, actual_count FROM tbl_inventory_products_masterlist WHERE item_category = '" + CategoryTypeSearch + "' AND category_code= '" + Global.inventoryBusinessCategoryCode + "'AND unit_code = '" + Global.inventoryBusinessUnitCode + "' AND status = 'Active') as T1 " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_in, status FROM tbl_inventory_in_transactions  WHERE status = 'Active' GROUP BY product_id) as T2 on T1.product_id = T2.product_id " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_out, status FROM tbl_inventory_out_transactions WHERE status = 'Active' GROUP BY product_id) as T3 on T1.product_id = T3.product_id " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_PO, status FROM tbl_purchase_order_transactions WHERE status = 'Active' GROUP BY product_id) AS T4 on T1.product_id = T4.product_id " +
                "LEFT JOIN (SELECT po_id, product_id, SUM(order_quantity) AS total_CustomerPO, record_status FROM tbl_inventory_customer_po WHERE record_status = 'Active' GROUP BY product_id) AS T5 on T1.product_id = T5.product_id ORDER BY T1.product_id ASC";


                Image Editicon = Image.FromFile("Resources/General/Datagrid_Images/edit.jpg");
                Image Deleteicon = Image.FromFile("Resources/General/Datagrid_Images/delete.jpg");
                Image Viewicon = Image.FromFile("Resources/General/Datagrid_Images/view.jpg");

                dgvRecords.Rows.Clear();

                MySqlConnect Conns = new MySqlConnect();
                Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                while (Conns.mySqlDataReader.Read())
                {
                    i++;
                    dgvRecords.Rows.Add(i, cledit.Image = Editicon, cldelete.Image = Deleteicon, clview.Image = Viewicon,
                        Conns.mySqlDataReader["product_id"].ToString(),
                        Conns.mySqlDataReader["bar_code"].ToString(),
                        Conns.mySqlDataReader["sku"].ToString(),
                        Conns.mySqlDataReader["inventory_type"].ToString(),
                        Conns.mySqlDataReader["item_category"].ToString(),
                        Conns.mySqlDataReader["item_name"].ToString(),
                        Conns.mySqlDataReader["item_description"].ToString(),
                        Conns.mySqlDataReader["unit_of_measure"].ToString(),
                        Conns.mySqlDataReader["unit_cost"].ToString(),
                        Conns.mySqlDataReader["selling_price"].ToString(),
                        Conns.mySqlDataReader["item_color"].ToString(),
                        Conns.mySqlDataReader["item_brand"].ToString(),
                        Conns.mySqlDataReader["item_variant"].ToString(),
                        Conns.mySqlDataReader["item_size"].ToString(),
                        Conns.mySqlDataReader["beginning_inventory"].ToString(),
                        Conns.mySqlDataReader["actual_count"].ToString(),
                        Conns.mySqlDataReader["total_in"].ToString(),
                        Conns.mySqlDataReader["total_out"].ToString(),
                        Conns.mySqlDataReader["total_PO"].ToString(),
                        Conns.mySqlDataReader["total_CustomerPO"].ToString());
                }
                Conns.mySqlconn.Close();
            }
           
            else if (InventoryTypeSearch != null && CategoryTypeSearch != null && BranchProjectSearch != null)
            {
                SQLStatement = "SELECT T1.product_id, T1.bar_code, T1.sku, T1.inventory_type, T1.item_category, T1.item_name, T1.item_description, T1.unit_of_measure, T1.unit_cost, T1.selling_price, T1.item_color, T1.item_brand, T1.item_variant, T1.item_size, T1.beginning_inventory, T1.actual_count, T2.total_in, T3.total_out, T4.total_PO, T5.total_CustomerPO FROM " +
                "(SELECT product_id, bar_code, sku, inventory_type, item_category, item_name, item_description, unit_of_measure, unit_cost, selling_price, item_color, item_brand, item_variant, item_size, beginning_inventory, actual_count FROM tbl_inventory_products_masterlist WHERE inventory_type = '" + InventoryTypeSearch + "' AND item_category = '" + CategoryTypeSearch + "' AND category_code= '" + Global.inventoryBusinessCategoryCode + "'AND unit_code = '" + Global.inventoryBusinessUnitCode + "' AND status = 'Active') as T1 " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_in, status FROM tbl_inventory_in_transactions  WHERE status = 'Active' GROUP BY product_id) as T2 on T1.product_id = T2.product_id " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_out, status FROM tbl_inventory_out_transactions WHERE status = 'Active' GROUP BY product_id) as T3 on T1.product_id = T3.product_id " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_PO, status FROM tbl_purchase_order_transactions WHERE status = 'Active' GROUP BY product_id) AS T4 on T1.product_id = T4.product_id " +
                "LEFT JOIN (SELECT po_id, product_id, SUM(order_quantity) AS total_CustomerPO, record_status FROM tbl_inventory_customer_po WHERE record_status = 'Active' GROUP BY product_id) AS T5 on T1.product_id = T5.product_id ORDER BY T1.product_id ASC";


                Image Editicon = Image.FromFile("Resources/General/Datagrid_Images/edit.jpg");
                Image Deleteicon = Image.FromFile("Resources/General/Datagrid_Images/delete.jpg");
                Image Viewicon = Image.FromFile("Resources/General/Datagrid_Images/view.jpg");

                dgvRecords.Rows.Clear();

                MySqlConnect Conns = new MySqlConnect();
                Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                while (Conns.mySqlDataReader.Read())
                {
                    i++;
                    dgvRecords.Rows.Add(i, cledit.Image = Editicon, cldelete.Image = Deleteicon, clview.Image = Viewicon,
                        Conns.mySqlDataReader["product_id"].ToString(),
                        Conns.mySqlDataReader["bar_code"].ToString(),
                        Conns.mySqlDataReader["sku"].ToString(),
                        Conns.mySqlDataReader["inventory_type"].ToString(),
                        Conns.mySqlDataReader["item_category"].ToString(),
                        Conns.mySqlDataReader["item_name"].ToString(),
                        Conns.mySqlDataReader["item_description"].ToString(),
                        Conns.mySqlDataReader["unit_of_measure"].ToString(),
                        Conns.mySqlDataReader["unit_cost"].ToString(),
                        Conns.mySqlDataReader["selling_price"].ToString(),
                        Conns.mySqlDataReader["item_color"].ToString(),
                        Conns.mySqlDataReader["item_brand"].ToString(),
                        Conns.mySqlDataReader["item_variant"].ToString(),
                        Conns.mySqlDataReader["item_size"].ToString(),
                        Conns.mySqlDataReader["beginning_inventory"].ToString(),
                        Conns.mySqlDataReader["actual_count"].ToString(),
                        Conns.mySqlDataReader["total_in"].ToString(),
                        Conns.mySqlDataReader["total_out"].ToString(),
                        Conns.mySqlDataReader["total_PO"].ToString(),
                        Conns.mySqlDataReader["total_CustomerPO"].ToString());
                }
                Conns.mySqlconn.Close();
            }
            else
            {
                //Datagridview Display
                SQLStatement = "SELECT T1.product_id, T1.bar_code, T1.sku, T1.inventory_type, T1.item_category, T1.item_name, T1.item_description, T1.unit_of_measure, T1.unit_cost, T1.selling_price, T1.item_color, T1.item_brand, T1.item_variant, T1.item_size, T1.beginning_inventory, T1.actual_count, T2.total_in, T3.total_out, T4.total_PO, T5.total_CustomerPO FROM " +
                "(SELECT product_id, bar_code, sku, inventory_type, item_category, item_name, item_description, unit_of_measure, unit_cost, selling_price, item_color, item_brand, item_variant, item_size, beginning_inventory, actual_count FROM tbl_inventory_products_masterlist WHERE unit_code = '" + Global.inventoryBusinessUnitCode + "' AND status = 'Active') as T1 " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_in, status FROM tbl_inventory_in_transactions  WHERE status = 'Active' GROUP BY product_id) as T2 on T1.product_id = T2.product_id " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_out, status FROM tbl_inventory_out_transactions WHERE status = 'Active' GROUP BY product_id) as T3 on T1.product_id = T3.product_id " +
                "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_PO, status FROM tbl_purchase_order_transactions WHERE status = 'Active' GROUP BY product_id) AS T4 on T1.product_id = T4.product_id " +
                "LEFT JOIN (SELECT po_id, product_id, SUM(order_quantity) AS total_CustomerPO, record_status FROM tbl_inventory_customer_po WHERE record_status = 'Active' GROUP BY product_id) AS T5 on T1.product_id = T5.product_id ORDER BY T1.product_id ASC";


                Image Editicon = Image.FromFile("Resources/General/Datagrid_Images/edit.jpg");
                Image Deleteicon = Image.FromFile("Resources/General/Datagrid_Images/delete.jpg");
                Image Viewicon = Image.FromFile("Resources/General/Datagrid_Images/view.jpg");

                dgvRecords.Rows.Clear();

                MySqlConnect Conns = new MySqlConnect();
                Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                while (Conns.mySqlDataReader.Read())
                {
                    i++;
                    dgvRecords.Rows.Add(i, cledit.Image = Editicon, cldelete.Image = Deleteicon, clview.Image = Viewicon,
                        Conns.mySqlDataReader["product_id"].ToString(),
                        Conns.mySqlDataReader["bar_code"].ToString(),
                        Conns.mySqlDataReader["sku"].ToString(),
                        Conns.mySqlDataReader["inventory_type"].ToString(),
                        Conns.mySqlDataReader["item_category"].ToString(),
                        Conns.mySqlDataReader["item_name"].ToString(),
                        Conns.mySqlDataReader["item_description"].ToString(),
                        Conns.mySqlDataReader["unit_of_measure"].ToString(),
                        Conns.mySqlDataReader["unit_cost"].ToString(),
                        Conns.mySqlDataReader["selling_price"].ToString(),
                        Conns.mySqlDataReader["item_color"].ToString(),
                        Conns.mySqlDataReader["item_brand"].ToString(),
                        Conns.mySqlDataReader["item_variant"].ToString(),
                        Conns.mySqlDataReader["item_size"].ToString(),
                        Conns.mySqlDataReader["beginning_inventory"].ToString(),
                        Conns.mySqlDataReader["actual_count"].ToString(),
                        Conns.mySqlDataReader["total_in"].ToString(),
                        Conns.mySqlDataReader["total_out"].ToString(),
                        Conns.mySqlDataReader["total_PO"].ToString(),
                        Conns.mySqlDataReader["total_CustomerPO"].ToString());
                }
                Conns.mySqlconn.Close();
            }

        }


        public void ucInventory_Products_Load(object sender, EventArgs e)
        {
           
            ucInventory_Products_DataLoad();
        }


        private void btnFilter_Click(object sender, EventArgs e)
        {
            transitionFilterBox.Show(panelFilter);
            panelFilter.BringToFront();

            MySqlConnect Conns = new MySqlConnect();
            int i = 0;
            //Load Inventory Type
            Conns.mySqlCmd = new MySqlCommand("SELECT distinct inventory_type FROM tbl_inventory_products_masterlist", Conns.mySqlconn);
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
            while (Conns.mySqlDataReader.Read())
            {
                i++;
                cboInventoryTypeSearch.Items.Add(Conns.mySqlDataReader["inventory_type"].ToString());
            }
            //Load Category Type
            Conns.mySqlCmd = new MySqlCommand("SELECT distinct item_category FROM tbl_inventory_products_masterlist", Conns.mySqlconn);
            Conns.mySqlDataReader.Close();
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
            while (Conns.mySqlDataReader.Read())
            {
                i++;
                cboCategoryTypeSearch.Items.Add(Conns.mySqlDataReader["item_category"].ToString());
            }
            //Load Category Code/Business Category
            Conns.mySqlCmd = new MySqlCommand("SELECT distinct category_code FROM tbl_inventory_products_masterlist", Conns.mySqlconn);
            Conns.mySqlDataReader.Close();
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
            while (Conns.mySqlDataReader.Read())
            {
                i++;
                cboBranchProjectSearch.Items.Add(Conns.mySqlDataReader["category_code"].ToString());
            }
        }

        private void btnHideFilter_Click(object sender, EventArgs e)
        {
            transitionFilterBox.Hide(panelFilter);
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            transitionFilterBox.Hide(panelFilter);

            // Your codes here to filter your records
            //    //Filter based on Dropdown
            FilterLoad = "Filter";
            ucInventory_Products_DataLoad();

            cboInventoryTypeSearch.Items.Clear();
            cboCategoryTypeSearch.Items.Clear();
            cboBranchProjectSearch.Items.Clear();
        }

        private void btnAddNewItem_Click(object sender, EventArgs e)
        {
            frmInventory_Products_NewItem frmInventory_Products_NewItem = new frmInventory_Products_NewItem();
            frmInventory_Products_NewItem.AddOrEditorView = "Add";
            frmInventory_Products_NewItem.ShowDialog();
        }

        private void cboOption01_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            
            control_Docking.ClearUserControls(frmInventory_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_InventorySystem(new ucInventory_Products()); // Loads the target user control in docked mode

        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            MySqlConnect Conns = new MySqlConnect();

            //int productID = Convert.ToInt32(dgvRecords.Rows[e.RowIndex].Cells[4].Value);
            new classMsgBox().showMsgConfirmation_Delete("Do you really want to delete this record?"); 
            if (Global.msgConfirmation == true)
            {
                // your codes here when the OK button has been pressed
                Conns.mySqlCmd = new MySqlCommand("update tbl_inventory_products_masterlist set status = 'Deleted' WHERE product_id =" + productID, Conns.mySqlconn);
                Conns.mySqlCmd.ExecuteNonQuery();
                new classMsgBox().showMsgSuccessful("Deleted Successfully");
            }
            
            Application.OpenForms["frmInventory_ParentContainer"].Activate(); // Bring the parent form to the front


        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            strSearch = txtSearch.Text;

            if (strSearch != null)
            {
                Image Editicon = Image.FromFile("Resources/General/Datagrid_Images/edit.jpg");
                Image Deleteicon = Image.FromFile("Resources/General/Datagrid_Images/delete.jpg");
                Image Viewicon = Image.FromFile("Resources/General/Datagrid_Images/view.jpg");

                MySqlConnect Conns = new MySqlConnect();
                int i = 0;

                //Datagridview Display
                //SQLStatement = "SELECT T1.product_id, T1.bar_code, T1.sku, T1.inventory_type, T1.item_category, T1.item_name, T1.item_description, T1.unit_of_measure, T1.unit_cost, T1.selling_price, T1.item_color, T1.item_brand, T1.item_variant, T1.item_size, T1.beginning_inventory, T1.actual_count, T2.total_in FROM " +
                //    "(SELECT product_id, bar_code, sku, inventory_type, item_category, item_name, item_description, unit_of_measure, unit_cost, selling_price, item_color, item_brand, item_variant, item_size, beginning_inventory, actual_count  FROM tbl_inventory_products_masterlist) as T1 " +
                //    "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_in, status FROM tbl_inventory_in_transactions GROUP BY product_id) as T2 on T1.product_id = T2.product_id WHERE item_name LIKE " + "'%" + strSearch + "%'" + " AND status = 'Active' ORDER BY product_id ASC";

                SQLStatement = "SELECT T1.product_id, T1.bar_code, T1.sku, T1.inventory_type, T1.item_category, T1.item_name, T1.item_description, T1.unit_of_measure, T1.unit_cost, T1.selling_price, T1.item_color, T1.item_brand, T1.item_variant, T1.item_size, T1.beginning_inventory, T1.actual_count, T2.total_in, T3.total_out, T4.total_PO, T5.total_CustomerPO FROM " +
               "(SELECT product_id, bar_code, sku, inventory_type, item_category, item_name, item_description, unit_of_measure, unit_cost, selling_price, item_color, item_brand, item_variant, item_size, beginning_inventory, actual_count FROM tbl_inventory_products_masterlist WHERE item_name LIKE " + "'%" + strSearch + "%'" + " AND status = 'Active') as T1 " +
               "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_in, status FROM tbl_inventory_in_transactions  WHERE status = 'Active' GROUP BY product_id) as T2 on T1.product_id = T2.product_id " +
               "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_out, status FROM tbl_inventory_out_transactions WHERE status = 'Active' GROUP BY product_id) as T3 on T1.product_id = T3.product_id " +
               "LEFT JOIN (SELECT transaction_id, product_id, SUM(quantity) AS total_PO, status FROM tbl_purchase_order_transactions WHERE status = 'Active' GROUP BY product_id) AS T4 on T1.product_id = T4.product_id " +
               "LEFT JOIN (SELECT po_id, product_id, SUM(order_quantity) AS total_CustomerPO, record_status FROM tbl_inventory_customer_po WHERE record_status = 'Active' GROUP BY product_id) AS T5 on T1.product_id = T5.product_id ORDER BY T1.product_id ASC";

                dgvRecords.Rows.Clear();
                Conns.mySqlCmd = new MySqlCommand(SQLStatement, Conns.mySqlconn);
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();
                while (Conns.mySqlDataReader.Read())
                {
                    i++;
                    dgvRecords.Rows.Add(i, cledit.Image = Editicon, cldelete.Image = Deleteicon, clview.Image = Viewicon,
                        Conns.mySqlDataReader["product_id"].ToString(),
                        Conns.mySqlDataReader["bar_code"].ToString(),
                        Conns.mySqlDataReader["sku"].ToString(),
                        Conns.mySqlDataReader["inventory_type"].ToString(),
                        Conns.mySqlDataReader["item_category"].ToString(),
                        Conns.mySqlDataReader["item_name"].ToString(),
                        Conns.mySqlDataReader["item_description"].ToString(),
                        Conns.mySqlDataReader["unit_of_measure"].ToString(),
                        Conns.mySqlDataReader["unit_cost"].ToString(),
                        Conns.mySqlDataReader["selling_price"].ToString(),
                        Conns.mySqlDataReader["item_color"].ToString(),
                        Conns.mySqlDataReader["item_brand"].ToString(),
                        Conns.mySqlDataReader["item_variant"].ToString(),
                        Conns.mySqlDataReader["item_size"].ToString(),
                        Conns.mySqlDataReader["beginning_inventory"].ToString(),
                        Conns.mySqlDataReader["actual_count"].ToString(),
                        Conns.mySqlDataReader["total_in"].ToString());
                }
                Conns.mySqlconn.Close();
            }
            else
            {
                new classMsgBox().showMsgError("Please enter Item Name in search bar!");
            }
        }
    }
}
