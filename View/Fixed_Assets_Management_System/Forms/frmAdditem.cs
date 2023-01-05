using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXIN.Controller;
using MySql.Data.MySqlClient;

namespace EXIN.Fixed_Assets_Management_System
{
    public partial class frmAdditem : Form
    {
        public string addOrEdit;
        public int assetId;

        classControl_Docking control_Docking = new classControl_Docking(); //Declare Control_Docking Class

        public frmAdditem()
        {
            InitializeComponent();

            pnlTitle.CustomBorderColor = Global.themeColor1;

            // Controls - Textbox 2
            txtassetcat.BorderColor = Global.themeColor1;
            txtassetcat.FocusedState.BorderColor = Global.themeColor2;
            txtassetcat.HoverState.BorderColor = Global.themeColor2;

            // Controls - Textbox 2
            txtassetname.BorderColor = Global.themeColor1;
            txtassetname.FocusedState.BorderColor = Global.themeColor2;
            txtassetname.HoverState.BorderColor = Global.themeColor2;

            // Controls - Textbox 2
            txtref.BorderColor = Global.themeColor1;
            txtref.FocusedState.BorderColor = Global.themeColor2;
            txtref.HoverState.BorderColor = Global.themeColor2;

            // Controls - Textbox 2
            txtbarcode.BorderColor = Global.themeColor1;
            txtbarcode.FocusedState.BorderColor = Global.themeColor2;
            txtbarcode.HoverState.BorderColor = Global.themeColor2;

            btnSave.FillColor = Global.themeColor1;
            btnSave.HoverState.FillColor = Global.themeColor2;
            btnSave.HoverState.ForeColor = Global.themeForeColor;

            btnClose.FillColor = Global.themeColor1;
            btnClose.HoverState.FillColor = Global.themeColor2;
            btnClose.HoverState.ForeColor = Global.themeForeColor;

            dtpacqdate.FillColor = Global.themeColor1;
            dtpacqdate.BorderColor = Global.themeColor1;
            dtpacqdate.CustomFormat = "MMMM dd, yyyy";

            // Controls - Combobox
            cbocomname.BorderColor = Global.themeColor1;
            cbocomname.FocusedState.BorderColor = Global.themeColor2;
            cbocomname.HoverState.BorderColor = Global.themeColor2;

            // Controls - Combobox
            cbobusiname.BorderColor = Global.themeColor1;
            cbobusiname.FocusedState.BorderColor = Global.themeColor2;
            cbobusiname.HoverState.BorderColor = Global.themeColor2;

            // Controls - Combobox
            cboassetcat.BorderColor = Global.themeColor1;
            cboassetcat.FocusedState.BorderColor = Global.themeColor2;
            cboassetcat.HoverState.BorderColor = Global.themeColor2;

            // Controls - Combobox
            cboassettype.BorderColor = Global.themeColor1;
            cboassettype.FocusedState.BorderColor = Global.themeColor2;
            cboassettype.HoverState.BorderColor = Global.themeColor2;

            // Controls - Combobox
            cbovat.BorderColor = Global.themeColor1;
            cbovat.FocusedState.BorderColor = Global.themeColor2;
            cbovat.HoverState.BorderColor = Global.themeColor2;

            numlife.BorderColor = Global.themeColor1;
            numlife.UpDownButtonFillColor = Global.themeColor1;

            numgross.BorderColor = Global.themeColor1;
            numgross.UpDownButtonFillColor = Global.themeColor1;

            numvats.BorderColor = Global.themeColor1;
            numvats.UpDownButtonFillColor = Global.themeColor1;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmAdditem_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);

            txtassetcat.Visible = false;

            cbocomname.Items.Add(Global.fixedAssetsBusinessCategoryCode);
            cbocomname.Text = Global.fixedAssetsBusinessCategoryCode;
            cbobusiname.Items.Add(Global.fixedAssetsBusinessUnitCode);
            cbobusiname.Text = Global.fixedAssetsBusinessUnitCode;

            MySqlConnect Conns = new MySqlConnect();

            Conns.mySqlCmd = new MySqlCommand("SELECT * FROM `tbl_fix_assets_item_masterlist` WHERE AutoNum = " + assetId + " LIMIT 1", Conns.mySqlconn);
            Conns.mySqlDataReader = Conns.mySqlCmd.ExecuteReader();

            while (Conns.mySqlDataReader.Read())
            {
                cbocomname.Text = Conns.mySqlDataReader["category_code"].ToString();
                cbobusiname.Text = Conns.mySqlDataReader["unit_code"].ToString();
                cboassetcat.Text = Conns.mySqlDataReader["asset_category"].ToString();
                cboassettype.Text = Conns.mySqlDataReader["asset_type"].ToString();
                txtassetname.Text = Conns.mySqlDataReader["asset_name"].ToString();
                dtpacqdate.Text = Conns.mySqlDataReader["acquisition_date"].ToString();
                numlife.Text = Conns.mySqlDataReader["life"].ToString();
                numgross.Text = Conns.mySqlDataReader["amount"].ToString();
                cbovat.Text = Conns.mySqlDataReader["vat_percent"].ToString();
                numvats.Text = Conns.mySqlDataReader["vat_amount"].ToString();
                txtbarcode.Text = Conns.mySqlDataReader["bar_code"].ToString();
            }
            Conns.mySqlconn.Close();
        }

        private void cboassetcat_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cboassetcat.Text == "Others"){
                txtassetcat.Visible = true;
                txtassetcat.Text = "";
            }
            else{
                txtassetcat.Visible = false;
                txtassetcat.Text = "";
            }
        }

        private void cbovat_SelectionChangeCommitted(object sender, EventArgs e)
        {


            if (cbovat.Text == "12")
            {
                double sa = 0;
                double per = 0;

                sa = Convert.ToDouble(numgross.Value);
                per = (sa / 1.12)*0.12;

                numvats.Value = Convert.ToDecimal(per);
            }
            else
            {
                numvats.Value = 0;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            MySqlConnect Conns = new MySqlConnect();

            if (addOrEdit == "Add")
            {
                new classMsgBox().showMsgConfirmation("Confirmation Message");
                if (Global.msgConfirmation == true)
                {
                    // your codes here when the OK button has been pressed
                    if(txtassetname.Text != "")
                    {
                        if (numlife.Value != 0)
                        {
                                if (numgross.Value != 0)
                                {
                                    Conns.mySqlCmd = new MySqlCommand("insert into tbl_fix_assets_item_masterlist(category_code,unit_code,asset_category,asset_type,asset_name,acquisition_date,life,reference,amount,vat_percent,vat_amount,bar_code)values(@category_code,@unit_code,@asset_category,@asset_type,@asset_name,@acquisition_date,@life,@reference,@amount,@vat_percent,@vat_amount,@bar_code)", Conns.mySqlconn);

                                    Conns.mySqlCmd.Parameters.AddWithValue("@category_code", cbocomname.Text);
                                    Conns.mySqlCmd.Parameters.AddWithValue("@unit_code", cbobusiname.Text);
                                    if(txtassetcat.Visible == true)
                                {
                                    Conns.mySqlCmd.Parameters.AddWithValue("@asset_category", txtassetcat.Text);
                                }
                                else
                                {
                                    Conns.mySqlCmd.Parameters.AddWithValue("@asset_category", cboassetcat.Text);
                                }
                                    Conns.mySqlCmd.Parameters.AddWithValue("@asset_type", cboassettype.Text);
                                    Conns.mySqlCmd.Parameters.AddWithValue("@asset_name", txtassetname.Text);
                                    Conns.mySqlCmd.Parameters.AddWithValue("@acquisition_date", dtpacqdate.Value);
                                    Conns.mySqlCmd.Parameters.AddWithValue("@life", numlife.Value);
                                    Conns.mySqlCmd.Parameters.AddWithValue("@reference", txtref.Text);
                                    Conns.mySqlCmd.Parameters.AddWithValue("@amount", numgross.Value);
                                    Conns.mySqlCmd.Parameters.AddWithValue("@vat_percent", cbovat.Text);
                                    Conns.mySqlCmd.Parameters.AddWithValue("@vat_amount", numvats.Value);
                                    Conns.mySqlCmd.Parameters.AddWithValue("@bar_code", txtbarcode.Text);

                                    Conns.mySqlCmd.ExecuteNonQuery();
                                    Conns.mySqlconn.Close();


                                    new classMsgBox().showMsgSuccessful("You pressed OK button");
                                    this.Hide();
                            }
                                else
                                {
                                    new classMsgBox().showMsgError("Enter Gross Amount");
                                }
                        }
                        else
                        {
                            new classMsgBox().showMsgError("Enter Life(Months)");
                        }
                    }
                    else
                    {
                        new classMsgBox().showMsgError("Enter Asset Name");
                    }

                }
                else
                {
                    // your codes here when the NO button has been pressed
                    //new classMsgBox().showMsgSuccessful("You pressed NO button");
                    Application.OpenForms["frmAdditem"].Activate(); // Bring the parent form to the front
                    return;
                }
                

            }
            else if (addOrEdit == "Edit")
            {
                new classMsgBox().showMsgConfirmation("Confirmation Message");
                if (Global.msgConfirmation == true)
                {
                    // your codes here when the OK button has been pressed
                    if (txtassetname.Text != "")
                    {
                        if (numlife.Value != 0)
                        {
                                if (numgross.Value != 0)
                                {
                                    Conns.mySqlCmd = new MySqlCommand("update tbl_fix_assets_item_masterlist set category_code = @category_code, unit_code = @unit_code ,asset_category = @asset_category, asset_type = @asset_type, asset_name = @asset_name ,acquisition_date = @acquisition_date ,life = @life ,reference = @reference,amount = @amount,vat_percent = @vat_percent, vat_amount = @vat_amount ,bar_code = @bar_code where AutoNum =" + assetId + "", Conns.mySqlconn);

                                    Conns.mySqlCmd.Parameters.AddWithValue("@category_code", cbocomname.Text);
                                    Conns.mySqlCmd.Parameters.AddWithValue("@unit_code", cbobusiname.Text);

                                if (txtassetcat.Visible == true)
                                {
                                    Conns.mySqlCmd.Parameters.AddWithValue("@asset_category", txtassetcat.Text);
                                }
                                else
                                {
                                    Conns.mySqlCmd.Parameters.AddWithValue("@asset_category", cboassetcat.Text);
                                }
                                    Conns.mySqlCmd.Parameters.AddWithValue("@asset_type", cboassettype.Text);
                                    Conns.mySqlCmd.Parameters.AddWithValue("@asset_name", txtassetname.Text);
                                    Conns.mySqlCmd.Parameters.AddWithValue("@acquisition_date", dtpacqdate.Value);
                                    Conns.mySqlCmd.Parameters.AddWithValue("@life", numlife.Value);
                                    Conns.mySqlCmd.Parameters.AddWithValue("@reference", txtref.Text);
                                    Conns.mySqlCmd.Parameters.AddWithValue("@amount", numgross.Value);
                                    Conns.mySqlCmd.Parameters.AddWithValue("@vat_percent", cbovat.Text);
                                    Conns.mySqlCmd.Parameters.AddWithValue("@vat_amount", numvats.Value);
                                    Conns.mySqlCmd.Parameters.AddWithValue("@bar_code", txtbarcode.Text);

                                    Conns.mySqlCmd.ExecuteNonQuery();
                                    Conns.mySqlconn.Close();


                                    new classMsgBox().showMsgSuccessful("You pressed OK button");
                                this.Hide();
                            }
                                else
                                {
                                    new classMsgBox().showMsgError("Enter Gross Amount");
                                }
                        }
                        else
                        {
                            new classMsgBox().showMsgError("Enter Life(Months)");
                        }
                    }
                    else
                    {
                        new classMsgBox().showMsgError("Enter Asset Name");
                    }


                }
                else
                {
                    // your codes here when the NO button has been pressed
                    new classMsgBox().showMsgSuccessful("You pressed NO button");
                }
                Application.OpenForms["frmFixedAssets_ParentContainer"].Activate(); // Bring the parent form to the front
            }

            control_Docking.ClearUserControls(frmFixedAssets_ParentContainer.Instance.panelContainer2); // Closes other opened user controls
            control_Docking.DockControl_FixedAssets(new ucMasterlist()); // Loads the target user control in docked mode
            Application.OpenForms["frmFixedAssets_ParentContainer"].Activate(); // Bring the parent form to the front
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.OpenForms["frmFixedAssets_ParentContainer"].Activate(); // Bring the parent form to the front
        }

        private void numvats_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}