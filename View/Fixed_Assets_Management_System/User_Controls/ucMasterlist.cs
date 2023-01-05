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
using Microsoft.Office.Interop;

namespace EXIN.Fixed_Assets_Management_System
{
    public partial class ucMasterlist : UserControl
    {
        
        public string Query;
        public string FilterLoad;

        int i = 0;
        string xmonth = null;

        double x = 0;
        int span = 0;
        double modep = 0;
        double accudep = 0;
        double netbook = 0;

        double amortizationx = 0;
        int amortizationspan = 0;
        double amortizationmodep = 0;
        double amortizationaccudep = 0;
        double amortizationnetbook = 0;

        classControl_Docking control_Docking = new classControl_Docking(); //Declare Control_Docking Class         

        public ucMasterlist()
        {
            InitializeComponent();
            dtpfilterdate.Value = DateTime.Now;

            panelRecords.CustomBorderColor = Global.themeColor1;
            panelFilter_Header.FillColor = Global.themeColor1;

            // Controls - Textbox 2
            txtSearch.BorderColor = Global.themeColor1;
            txtSearch.FocusedState.BorderColor = Global.themeColor2;
            txtSearch.HoverState.BorderColor = Global.themeColor2;

            // Controls - Button 1
            btnadd.FillColor = Global.themeColor1;
            btnadd.HoverState.FillColor = Global.themeColor2;
            btnadd.HoverState.ForeColor = Global.themeForeColor;

            // Controls - Button 1
            btncreatejournal.FillColor = Global.themeColor1;
            btncreatejournal.HoverState.FillColor = Global.themeColor2;
            btncreatejournal.HoverState.ForeColor = Global.themeForeColor;

            // Controls - Button 1
            btnjournalentries.FillColor = Global.themeColor1;
            btnjournalentries.HoverState.FillColor = Global.themeColor2;
            btnjournalentries.HoverState.ForeColor = Global.themeForeColor;

            btnApplyFilter.FillColor = Global.themeColor1;
            btnApplyFilter.FillColor2 = Global.themeColor2;

            dtpfilterdate.FillColor = Global.themeColor1;
            dtpfilterdate.BorderColor = Global.themeColor1;
            dtpfilterdate.CustomFormat = "MMMM dd, yyyy";

            // Controls - Combobox
            cbofilassettype.BorderColor = Global.themeColor1;
            cbofilassettype.FocusedState.BorderColor = Global.themeColor2;
            cbofilassettype.HoverState.BorderColor = Global.themeColor2;

            // Controls - Combobox
            cbofilcategory.BorderColor = Global.themeColor1;
            cbofilcategory.FocusedState.BorderColor = Global.themeColor2;
            cbofilcategory.HoverState.BorderColor = Global.themeColor2;

            // Controls - Combobox
            cbofilstatus.BorderColor = Global.themeColor1;
            cbofilstatus.FocusedState.BorderColor = Global.themeColor2;
            cbofilstatus.HoverState.BorderColor = Global.themeColor2;


        }

        private void ucMasterlist_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            double countrecord = 0;

            DateTime filterdate = Convert.ToDateTime(dtpfilterdate.Value);

            if (FilterLoad == "Filter")
            {
                Query = "SELECT * FROM `tbl_fix_assets_item_masterlist` WHERE asset_type LIKE '" + cbofilassettype.Text + "%' AND asset_category LIKE '" + cbofilcategory.Text + "%' AND record_status LIKE '" + cbofilstatus.Text + "%'";
                filterdate.ToShortDateString();
            }
            else
            {
                Query = "SELECT * FROM `tbl_fix_assets_item_masterlist` WHERE `record_status` = 'Active'";
                filterdate = DateTime.Now;
            }

            Image Viewicon = Image.FromFile("Resources/General/Datagrid_Images/view.jpg");
            Image Editicon = Image.FromFile("Resources/General/Datagrid_Images/edit.jpg");
            Image Deleteicon = Image.FromFile("Resources/General/Datagrid_Images/delete.jpg");
            Image Clearicon = Image.FromFile("Resources/General/Datagrid_Images/Capture.jpg");

            double totalamount = 0;
            double totalvat = 0;
            double totalnetvat = 0;
            double totalmodep = 0;
            double totalaccudep = 0;
            double totalnetbook = 0;

            double amortizationtotalamount = 0;
            double amortizationtotalvat = 0;
            double amortizationtotalnetvat = 0;
            double amortizationtotalmodep = 0;
            double amortizationtotalaccudep = 0;
            double amortizationtotalnetbook = 0;

            dgvRecords.Rows.Clear();

            MySqlConnect Conns = new MySqlConnect();

            //Conns.mySqlCmd = new MySqlCommand("SELECT `asset_category`,`asset_name`, `acquisition_date`, `life`, `reference`, `amount`, `vat_amount`, `AutoNum`, `record_status` FROM `tbl_fix_assets_item_masterlist` WHERE record_status = Active", Conns.mySqlconn);
            Conns.mySqlCmd = new MySqlCommand(Query, Conns.mySqlconn);
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(Conns.mySqlDataReader);
            double numberOfResults = dt.Rows.Count;

            if (numberOfResults > 0)
            {
                Conns.mySqlDataReader.Close();
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();

                while (Conns.mySqlDataReader.Read())
                {
                    i++;
                    countrecord++;

                    double prbcount = countrecord / numberOfResults * 100;
                    double prbcountpercent = Math.Round(prbcount, 0, MidpointRounding.ToEven);

                    lblProgressPercent.Text = prbcountpercent + "%";
                    prbrecord.Value = Convert.ToInt32(prbcountpercent);

                    DateTime nows = filterdate;
                    DateTime lifes = Convert.ToDateTime(Conns.mySqlDataReader["acquisition_date"]);

                    if (Conns.mySqlDataReader["asset_type"].ToString() == "Depreciation") {
                        totalamount = totalamount + Convert.ToDouble(Conns.mySqlDataReader["amount"].ToString());
                        totalvat = totalvat + Convert.ToDouble(Conns.mySqlDataReader["vat_amount"].ToString());
                        totalnetvat = totalnetvat + x;
                        totalmodep = totalmodep + modep;
                        totalaccudep = totalaccudep + accudep;
                        totalnetbook = totalnetbook + netbook;
                        //totalnetvat = totalnetvat + amortizationx;
                        //totalmodep = totalmodep + amortizationmodep;
                        //totalaccudep = totalaccudep + amortizationaccudep;
                        //totalnetbook = totalnetbook + amortizationnetbook;

                        x = Convert.ToDouble(Conns.mySqlDataReader["amount"].ToString()) - Convert.ToDouble(Conns.mySqlDataReader["vat_amount"].ToString());
                        span = nows.Month - lifes.Month;
                        if (nows.Day >= lifes.Day)
                        {
                            xmonth = Convert.ToString(span);
                        }
                        else
                        {
                            xmonth = Convert.ToString(span - 1);
                        }
                        modep = x / Convert.ToDouble(Conns.mySqlDataReader["life"].ToString());
                        accudep = modep * span;
                        netbook = x - accudep;

                        dgvRecords.Rows.Add(i, clview.Image = Viewicon,
                        cledit.Image = Deleteicon, 
                        cldelete.Image = Editicon,
                        Conns.mySqlDataReader["asset_category"].ToString(),
                        Conns.mySqlDataReader["asset_name"].ToString(),
                        //Conns.mySqlDataReader["acquisition_date"].ToString(),
                        lifes.ToString("d"),
                        Conns.mySqlDataReader["life"].ToString(),
                        Conns.mySqlDataReader["reference"].ToString(),
                        Convert.ToDouble(Conns.mySqlDataReader["amount"].ToString()),
                        Math.Round(Convert.ToDouble(Conns.mySqlDataReader["vat_amount"].ToString()), 2),
                        Math.Round(x, 2),
                        xmonth,
                        Math.Round(modep, 2),
                        Math.Round(accudep, 2),
                        Math.Round(netbook, 2),
                        Conns.mySqlDataReader["AutoNum"].ToString());
                    }
                    else
                    {

                        amortizationx = Convert.ToDouble(Conns.mySqlDataReader["amount"].ToString()) - Convert.ToDouble(Conns.mySqlDataReader["vat_amount"].ToString());
                        amortizationspan = nows.Month - lifes.Month;
                        if (nows.Day >= lifes.Day)
                        {
                            xmonth = Convert.ToString(amortizationspan);
                        }
                        else
                        {
                            xmonth = Convert.ToString(amortizationspan - 1);
                        }

                        if (amortizationx != 0)
                        {
                            amortizationmodep = amortizationx / Convert.ToDouble(Conns.mySqlDataReader["life"].ToString());
                            amortizationaccudep = amortizationmodep * amortizationspan;
                            amortizationnetbook = amortizationx - amortizationaccudep;

                            amortizationtotalamount = amortizationtotalamount + Convert.ToDouble(Conns.mySqlDataReader["amount"].ToString());
                            amortizationtotalvat = amortizationtotalvat + Convert.ToDouble(Conns.mySqlDataReader["vat_amount"].ToString());
                            amortizationtotalnetvat = amortizationtotalnetvat + amortizationx;
                            amortizationtotalmodep = amortizationtotalmodep + amortizationmodep;
                            amortizationtotalaccudep = amortizationtotalaccudep + amortizationaccudep;
                            amortizationtotalnetbook = amortizationtotalnetbook + amortizationnetbook;
                        }
                        else
                        {
                            amortizationtotalamount = amortizationtotalamount + Convert.ToDouble(Conns.mySqlDataReader["amount"].ToString());
                            amortizationtotalvat = amortizationtotalvat + Convert.ToDouble(Conns.mySqlDataReader["vat_amount"].ToString());
                            amortizationtotalnetvat = amortizationtotalnetvat + amortizationx;
                            amortizationtotalmodep = amortizationtotalmodep + amortizationmodep;
                            amortizationtotalaccudep = amortizationtotalaccudep + amortizationaccudep;
                            amortizationtotalnetbook = amortizationtotalnetbook + amortizationnetbook;

                            amortizationmodep = amortizationx / Convert.ToDouble(Conns.mySqlDataReader["life"].ToString());
                            amortizationaccudep = amortizationmodep * amortizationspan;
                            amortizationnetbook = amortizationx - amortizationaccudep;
                        }

                        dgvRecords.Rows.Add(i, clview.Image = Viewicon,
                        cledit.Image = Deleteicon,
                        cldelete.Image = Editicon,
                        Conns.mySqlDataReader["asset_category"].ToString(),
                        Conns.mySqlDataReader["asset_name"].ToString(),
                        //Conns.mySqlDataReader["acquisition_date"].ToString(),
                        lifes.ToString("d"),
                        Conns.mySqlDataReader["life"].ToString(),
                        Conns.mySqlDataReader["reference"].ToString(),
                        Convert.ToDouble(Conns.mySqlDataReader["amount"].ToString()),
                        Math.Round(Convert.ToDouble(Conns.mySqlDataReader["vat_amount"].ToString()), 2),
                        Math.Round(amortizationx, 2),
                        xmonth,
                        Math.Round(amortizationmodep, 2),
                        Math.Round(amortizationaccudep, 2),
                        Math.Round(amortizationnetbook, 2),
                        Conns.mySqlDataReader["AutoNum"].ToString());
                    }
                }

                if (FilterLoad == "Filter")
                {
                    
                }
                else
                {
                    if (Conns.mySqlDataReader["asset_type"].ToString() == "Depreciation")
                    {
                        totalamount = totalamount + Convert.ToDouble(Conns.mySqlDataReader["amount"].ToString());
                        totalvat = totalvat + Convert.ToDouble(Conns.mySqlDataReader["vat_amount"].ToString());
                        totalnetvat = totalnetvat + x;
                        totalmodep = totalmodep + modep;
                        totalaccudep = totalaccudep + accudep;
                        totalnetbook = totalnetbook + netbook;
                    }
                    else
                    {
                        //amortizationtotalamount = amortizationtotalamount + Convert.ToDouble(Conns.mySqlDataReader["amount"].ToString());
                        //amortizationtotalvat = amortizationtotalvat + Convert.ToDouble(Conns.mySqlDataReader["vat_amount"].ToString());
                        //amortizationtotalnetvat = amortizationtotalnetvat + amortizationx;
                        //amortizationtotalmodep = amortizationtotalmodep + amortizationmodep;
                        //amortizationtotalaccudep = amortizationtotalaccudep + amortizationaccudep;
                        //amortizationtotalnetbook = amortizationtotalnetbook + amortizationnetbook;
                    }
                    //totalamount = totalamount + Convert.ToDouble(Conns.mySqlDataReader["amount"].ToString());
                    //totalvat = totalvat + Convert.ToDouble(Conns.mySqlDataReader["vat_amount"].ToString());
                    //totalnetvat = totalnetvat + x;
                    //totalmodep = totalmodep + modep;
                    //totalaccudep = totalaccudep + accudep;
                    //totalnetbook = totalnetbook + netbook;
                }
                totalamount = totalamount + Convert.ToDouble(Conns.mySqlDataReader["amount"].ToString());
                totalvat = totalvat + Convert.ToDouble(Conns.mySqlDataReader["vat_amount"].ToString());
                totalnetvat = totalnetvat + x;
                totalmodep = totalmodep + modep;
                totalaccudep = totalaccudep + accudep;
                totalnetbook = totalnetbook + netbook;

                dgvRecords.Rows.Add(1, clview.Image = Clearicon, cledit.Image = Clearicon, cldelete.Image = Clearicon);
                dgvRecords.Rows.Add(2, clview.Image = Clearicon, cledit.Image = Clearicon, cldelete.Image = Clearicon, "Total Depreciation", "", "", "", "", Math.Round(totalamount, 2), Math.Round(totalvat, 2), Math.Round(totalnetvat, 2), "", Math.Round(totalmodep, 2), Math.Round(totalaccudep, 2), Math.Round(totalnetbook, 2));
                dgvRecords.Rows.Add(3, clview.Image = Clearicon, cledit.Image = Clearicon, cldelete.Image = Clearicon, "Total Amortization", "", "", "", "", Math.Round(amortizationtotalamount, 2), Math.Round(amortizationtotalvat, 2), Math.Round(amortizationtotalnetvat, 2), "", Math.Round(amortizationtotalmodep, 2), Math.Round(amortizationtotalaccudep, 2), Math.Round(amortizationtotalnetbook, 2));
                dgvRecords.Rows.Add(4, clview.Image = Clearicon, cledit.Image = Clearicon, cldelete.Image = Clearicon, "Grand Total", "", "", "", "", Math.Round(totalamount, 2) + Math.Round(amortizationtotalamount, 2), Math.Round(totalvat, 2) + Math.Round(amortizationtotalvat, 2) , Math.Round(totalnetvat, 2) + Math.Round(amortizationtotalnetvat, 2) , "", Math.Round(totalmodep, 2) + Math.Round(amortizationtotalmodep, 2) , Math.Round(totalaccudep, 2) + Math.Round(amortizationtotalaccudep, 2) , Math.Round(totalnetbook, 2) + Math.Round(amortizationtotalnetbook, 2));
                lblRecordCount.Text = "Count: " + countrecord;
            }
            else
            {
                new classMsgBox().showMsgError("No record found!");
                Application.OpenForms["frmFixedAssets_ParentContainer"].Activate(); // Bring the parent form to the front
            }

            Conns.mySqlconn.Close();
        }

        private void dgvRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MySqlConnect Conns = new MySqlConnect();
            frmAdditem adding = new frmAdditem();
            classControl_Docking control_Docking = new classControl_Docking(); //Declare Control_Docking Class  

            if (e.ColumnIndex == 3) {
                
                adding.addOrEdit = "Edit";

                int xRecords = 0;

                Conns.mySqlCmd = new MySqlCommand("SELECT distinct `asset_type` FROM `tbl_fix_assets_item_masterlist`", Conns.mySqlconn);
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();

                while (Conns.mySqlDataReader.Read())
                {
                    xRecords++;
                    adding.cboassettype.Items.Add(Conns.mySqlDataReader["asset_type"].ToString());
                }

                Conns.mySqlCmd = new MySqlCommand("SELECT distinct `asset_category` FROM `tbl_fix_assets_item_masterlist`", Conns.mySqlconn);
                Conns.mySqlDataReader.Close();
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();

                while (Conns.mySqlDataReader.Read())
                {
                    xRecords++;
                    adding.cboassetcat.Items.Add(Conns.mySqlDataReader["asset_category"].ToString());
                }

                adding.assetId = Convert.ToInt32(dgvRecords.SelectedRows[0].Cells[16].Value.ToString());

                if (adding.numvats.Value == 0)
                {
                    adding.cbovat.Text = "0";
                }
                else
                {
                    adding.cbovat.Text = "12";
                }


                adding.ShowDialog();
            }
            else if (e.ColumnIndex == 2)
            {
                adding.assetId = Convert.ToInt32(dgvRecords.SelectedRows[0].Cells[16].Value.ToString());

                new classMsgBox().showMsgConfirmation_Delete("Confirmation Message");
                if (Global.msgConfirmation == true)
                {
                    // your codes here when the OK button has been pressed

                    Conns.mySqlCmd = new MySqlCommand("update tbl_fix_assets_item_masterlist set record_status = @record_status where AutoNum =" + adding.assetId + "", Conns.mySqlconn);

                    Conns.mySqlCmd.Parameters.AddWithValue("@record_status", "Deleted");

                    Conns.mySqlCmd.ExecuteNonQuery();
                    Conns.mySqlconn.Close();

                    new classMsgBox().showMsgSuccessful("You pressed OK button");

                    control_Docking.ClearUserControls(frmFixedAssets_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
                    control_Docking.DockControl_FixedAssets(new ucMasterlist()); // Loads the target user control in docked mode
                }
                else
                {
                    // your codes here when the NO button has been pressed
                    new classMsgBox().showMsgSuccessful("You pressed NO button");
                }
            }
            Application.OpenForms["frmFixedAssets_ParentContainer"].Activate(); // Bring the parent form to the front
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {


            int filterx = 0;

            if (cbofilstatus.Text == "")
            {
                MySqlConnect Conns = new MySqlConnect();

                Conns.mySqlCmd = new MySqlCommand("SELECT distinct `asset_type` FROM `tbl_fix_assets_item_masterlist`", Conns.mySqlconn);
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();

                while (Conns.mySqlDataReader.Read())
                {
                    filterx++;
                    cbofilassettype.Items.Add(Conns.mySqlDataReader["asset_type"].ToString());
                }

                Conns.mySqlCmd = new MySqlCommand("SELECT distinct `asset_category` FROM `tbl_fix_assets_item_masterlist`", Conns.mySqlconn);
                Conns.mySqlDataReader.Close();
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();

                while (Conns.mySqlDataReader.Read())
                {
                    filterx++;
                    cbofilcategory.Items.Add(Conns.mySqlDataReader["asset_category"].ToString());
                }

                Conns.mySqlCmd = new MySqlCommand("SELECT distinct `record_status` FROM `tbl_fix_assets_item_masterlist`", Conns.mySqlconn);
                Conns.mySqlDataReader.Close();
                Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();

                while (Conns.mySqlDataReader.Read())
                {
                    filterx++;
                    cbofilstatus.Items.Add(Conns.mySqlDataReader["record_status"].ToString());
                }

                cbofilassettype.Text = cbofilassettype.Items[0].ToString();
                cbofilcategory.Text = cbofilcategory.Items[0].ToString();
                cbofilstatus.Text = cbofilstatus.Items[0].ToString();

                Conns.mySqlconn.Close();
            }
            else
            {
                transitionFilterBox.Show(panelFilter);
                panelFilter.BringToFront();
            }
        }

        private void btnHideFilter_Click(object sender, EventArgs e)
        {
            transitionFilterBox.Hide(panelFilter);
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            transitionFilterBox.Hide(panelFilter);

            FilterLoad = "Filter";

            loadData();

            //control_Docking.ClearUserControls(frmFixedAssets_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            //control_Docking.DockControl_FixedAssets(new ucMasterlist()); // Loads the target user control in docked mode


            // Your codes here to filter your records
        }
        private void btnadd_Click_1(object sender, EventArgs e)
        {
            frmAdditem adding = new frmAdditem();

            int x = 0;

            MySqlConnect Conns = new MySqlConnect();

            Conns.mySqlCmd = new MySqlCommand("SELECT distinct `asset_type` FROM `tbl_fix_assets_item_masterlist`", Conns.mySqlconn);
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();

            while (Conns.mySqlDataReader.Read())
            {
                x++;
                adding.cboassettype.Items.Add(Conns.mySqlDataReader["asset_type"].ToString());
            }

            Conns.mySqlCmd = new MySqlCommand("SELECT distinct `asset_category` FROM `tbl_fix_assets_item_masterlist`", Conns.mySqlconn);
            Conns.mySqlDataReader.Close();
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();

            while (Conns.mySqlDataReader.Read())
            {
                x++;
                adding.cboassetcat.Items.Add(Conns.mySqlDataReader["asset_category"].ToString());
            }

            adding.cboassetcat.Text = adding.cboassetcat.Items[1].ToString();
            adding.cboassettype.Text = adding.cboassettype.Items[0].ToString();
            adding.cbovat.Text = adding.cbovat.Items[0].ToString();

            adding.addOrEdit = "Add";
            adding.ShowDialog();

            Conns.mySqlconn.Close();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            FilterLoad = "";
            loadData();
        }

        private void panelRecords_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
           

            //using (SaveFileDialog sft = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            //{
            //    if (sft.ShowDialog() == DialogResult.OK)
            //    {
            //        using (XLWorkbook wb = new XLWorkbook())
            //        {
            //            var ws = wb.Worksheets.Add("Fixed Asset Upload Template");

            //            // Adding HeaderRow.
            //            ws.Cell("A1").Value = "Asset Category";
            //            ws.Cell("B1").Value = "Asset Type";
            //            ws.Cell("C1").Value = "Asset Name";
            //            ws.Cell("D1").Value = "Acquisition Date";
            //            ws.Cell("E1").Value = "Life (Months)";
            //            ws.Cell("F1").Value = "Refference No. / Serial No.";
            //            ws.Cell("G1").Value = "Gross Amount";
            //            ws.Cell("H1").Value = "Barcode";

            //            ws.Cell("A1").Style.Font.Bold = true;
            //            ws.Cell("B1").Style.Font.Bold = true;
            //            ws.Cell("C1").Style.Font.Bold = true;
            //            ws.Cell("D1").Style.Font.Bold = true;
            //            ws.Cell("E1").Style.Font.Bold = true;
            //            ws.Cell("F1").Style.Font.Bold = true;
            //            ws.Cell("G1").Style.Font.Bold = true;
            //            ws.Cell("H1").Style.Font.Bold = true;

            //            ws.Columns().AdjustToContents();
            //            wb.SaveAs(sft.FileName);
            //        }
            //    }
            //}

            string fileName = "Template.xlsx";
            string sourcePath = @"C:\Users\PC3\Desktop\Template";
            string targetPath = @"C:\Users\PC3\Desktop";

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            // To copy a folder's contents to a new location:
            // Create a new target folder.
            // If the directory already exists, this method does not create a new directory.
            System.IO.Directory.CreateDirectory(targetPath);

            // To copy a file to another location and
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);

            // To copy all the files in one directory to another directory.
            // Get the files in the source folder. (To recursively iterate through
            // all subfolders under the current directory, see
            // "How to: Iterate Through a Directory Tree.")
            // Note: Check for target path was performed previously
            //       in this code example.
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);

                    MessageBox.Show("Export Files Created");
                }
            }
            else
            {
                MessageBox.Show("Source path does not exist!");
            }
        }

            private void guna2Panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelFilter_Header_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
