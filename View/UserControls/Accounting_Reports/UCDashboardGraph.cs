using EXIN.Controller.Accounting_Report;
using EXIN.Model;
using Guna.Charts.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EXIN.View.UserControls.Accounting_Reports
{
    public partial class UCDashboardGraph : UserControl
    {
        public UCDashboardGraph()
        {
            InitializeComponent();

        }

        private void UCDashboardGraph_Load(object sender, EventArgs e)
        {
            frmController.Instance.PnlTitle.Hide();
            guna2Transition1.Show(frmController.Instance.PnlTitle);
            frmController.Instance.PnlTitle.Controls["lblPageTitle"].Text = "Dashboard";


            dtpFromDate.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpToDate.Value = DateTime.Today;

            fillComboBoxes();

            grpFilter.Hide();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {

            var loader = new WaitFormFunc();

            loader.Show();

            clearDataSets();

            getSalesbyBrand();

            getSalesbyStores();

            getSalesbyDate();

            lblPanelOne.Text = cmbPNLAccount.GetItemText(cmbPNLAccount.SelectedItem) + " from " + dtpFromDate.Value.ToShortDateString() + " to " + dtpToDate.Value.ToShortDateString() + " by Brand (Amount in Thousands)";
            lblPanelTwo.Text = cmbPNLAccount.GetItemText(cmbPNLAccount.SelectedItem) + " from " + dtpFromDate.Value.ToShortDateString() + " to " + dtpToDate.Value.ToShortDateString() + " by " + cmbCategory.GetItemText(cmbCategory.SelectedItem) + " Stores (Amount in Thousands)";
            lblPanelThree.Text = cmbPNLAccount.GetItemText(cmbPNLAccount.SelectedItem) + " last 7 days for " + cmbPNLAccount.GetItemText(cmbStores.SelectedItem) + " from " + dtpToDate.Value.ToShortDateString() + " (Amount in Thousands)";

            guna2Transition2.HideSync(grpFilter);

            loader.Close();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            grpFilter.BringToFront();
            guna2Transition2.ShowSync(grpFilter);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            guna2Transition2.HideSync(grpFilter);
        }

        private void getSalesbyBrand()
        {

            var connDashboard = new ctrlDashboard();

            connDashboard.mysqlQuery = mdlDashboard.MdlSalesbyBrand;

            var salesByBrand = connDashboard.ReadSalesbyBrand(lblPNLId.Text, dtpFromDate.Value.ToShortDateString(), dtpToDate.Value.ToShortDateString());

            var points = new LPointCollection();

            for (var i = 0; i < salesByBrand.Count; i += 5)
            {
                points.Add(salesByBrand[i].ToString(), double.Parse(salesByBrand[i + 1].ToString()));
            }

            dataSetSalesbyBrand.DataPoints.AddRange(points);

            chartSalesbyBrand.Legend.Position = Guna.Charts.WinForms.LegendPosition.Right;

            chartSalesbyBrand.PaletteCustomColors.FillColors.Add(Color.FromArgb(255, 136, 75)); //CK
            chartSalesbyBrand.PaletteCustomColors.FillColors.Add(Color.FromArgb(118, 186, 153)); //GW
            chartSalesbyBrand.PaletteCustomColors.FillColors.Add(Color.FromArgb(250, 112, 112)); //JB
            chartSalesbyBrand.PaletteCustomColors.FillColors.Add(Color.FromArgb(89, 206, 143)); //MI
            chartSalesbyBrand.PaletteCustomColors.FillColors.Add(Color.FromArgb(255, 196, 196)); //RR
        }

        private void getSalesbyStores()
        {

            var connDashboard = new ctrlDashboard();

            connDashboard.mysqlQuery = mdlDashboard.MdlSalesbyStores;

            var salesByStore = connDashboard.ReadSalesbyStore(lblPNLId.Text, dtpFromDate.Value.ToShortDateString(), dtpToDate.Value.ToShortDateString(), lblBrandId.Text);

            var points = new LPointCollection();

            for (var i = 0; i < salesByStore.Count; i += 6)
            {
                points.Add(salesByStore[i + 1].ToString(), double.Parse(salesByStore[i + 2].ToString()));
            }

            dataSetSalesbyStore.DataPoints.AddRange(points);

            //chartSalesbyStore.Legend.Position = Guna.Charts.WinForms.LegendPosition.Right;

            // chartSalesbyStore.PaletteCustomColors.FillColors.Add(Color.FromArgb(118, 186, 153)); 

        }

        private void getSalesbyDate()
        {

            var connDashboard = new ctrlDashboard();

            connDashboard.mysqlQuery = mdlDashboard.MdlSalesbyDate;

            var salesByDate = connDashboard.ReadSalesbyDate(lblPNLId.Text, dtpFromDate.Value.ToShortDateString(), dtpToDate.Value.ToShortDateString(), lblBrandId.Text, lblStoreId.Text);

            var points = new LPointCollection();

            for (var i = 0; i < salesByDate.Count; i += 6)
            {
                points.Add(salesByDate[i + 2].ToString(), double.Parse(salesByDate[i + 3].ToString()));
            }

            dataSetSalesbyDate.DataPoints.AddRange(points);

        }


        private void clearDataSets()
        {
            dataSetSalesbyBrand.DataPoints.Clear();
            dataSetSalesbyStore.DataPoints.Clear();
            dataSetSalesbyDate.DataPoints.Clear();
        }

        public void fillComboBoxes()
        {
            var fillCmb = new ctrlFillComboBoxes();

            fillCmb.getBusUnitsName(cmbStores);
            fillCmb.getPNLAccountName(cmbPNLAccount);
            fillCmb.getBrandName(cmbCategory);
        }

        private void cmbStores_SelectedValueChanged(object sender, EventArgs e)
        {
            var fillCmb = new ctrlFillComboBoxes();
            fillCmb.getUnitCode(cmbStores.GetItemText(cmbStores.SelectedItem), lblStoreId);
        }

        private void cmbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            var fillCmb = new ctrlFillComboBoxes();
            fillCmb.getBrandCode(cmbCategory.GetItemText(cmbCategory.SelectedItem), lblBrandId);
        }

        private void cmbPNLAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            var fillCmb = new ctrlFillComboBoxes();
            fillCmb.getPNLCode(cmbPNLAccount.GetItemText(cmbPNLAccount.SelectedItem), lblPNLId);
        }


    }
}

/*
 * * NOTESSSSSSSSSSSSSS
 */
//gunaBarDataset1.DataPoints.Add(new LPoint("Apple", 50));
//gunaBarDataset1.DataPoints.Add(new LPoint("Orange", 20));

//var points = new LPointCollection();
//points.Add("Apple", 50);
//points.Add("Orange", 80);
//points.Add("Grapes", 100);

//gunaDoughnutDataset1.DataPoints.AddRange(points);

//gunaChart2.PaletteCustomColors.FillColors.Add(Color.FromArgb(6, 84, 70));
//gunaChart2.PaletteCustomColors.FillColors.Add(Color.FromArgb(40, 223, 153));
//gunaChart2.PaletteCustomColors.FillColors.Add(Color.Teal);
