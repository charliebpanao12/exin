using EXIN.View.UserControls.Accounting_Reports;
using Guna.UI.WinForms;
using Guna.UI2.WinForms;
using System;
using System.Windows.Forms;


namespace EXIN
{
    public partial class frmController : Form
    {
        static frmController _obj;
        public static frmController Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new frmController();
                }
                return _obj;
            }
        }

        public GunaPanel PnlContainer
        {
            get { return pnlContainer; }
            set { pnlContainer = value; }
        }

        public Guna2ShadowPanel PnlTitle
        {
            get { return pnlTitle; }
            set { pnlTitle = value; }
        }

        public GunaImageButton BackButton
        {
            get { return btnBack; }
            set { btnBack = value; }
        }



        public frmController()
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void frmController_Load(object sender, EventArgs e)
        {

            pnlSettings.Hide();

            btnBack.Visible = false;
            _obj = this;

            var uc = new UCHomePage();
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);

            MySqlConnect MySQLConn = new MySqlConnect();

            lblUserName.Text = MySQLConn.myUser;



        }

        private void gunaImageButton3_Click(object sender, EventArgs e)
        {
            pnlSettings.Show();
            pnlSettings.BringToFront();
        }


        private void gunaImageButton2_Click(object sender, EventArgs e)
        {
            pnlSettings.BringToFront();
            pnlSettings.Show();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            //pnlContainer.Controls["UCAccounting"].BringToFront();
            //pnlContainer.Controls["UCDashboard"].BringToFront();
            //btnBack.Visible = false;
            //pnlSettings.Hide();

            this.Hide();

            frmUserLogin userlog = new frmUserLogin();
            userlog.Show();


        }

        private void pnlSettings_MouseLeave(object sender, EventArgs e)
        {
            pnlSettings.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            clearUserControls();

            UCDashboardGraph uDashBoard = new UCDashboardGraph();
            uDashBoard.Dock = DockStyle.Fill;
            frmController.Instance.PnlContainer.Controls.Add(uDashBoard);

            frmController.Instance.PnlContainer.Controls["UCDashboard"].BringToFront();

        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        public void showAccountingMenu()
        {
            UCAccounting uc = new UCAccounting();
            uc.Dock = DockStyle.Fill;
            frmController.Instance.PnlContainer.Controls.Add(uc);

            frmController.Instance.PnlContainer.Controls["UCAccounting"].BringToFront();
        }

        private void btnAccounting_Click(object sender, EventArgs e)
        {
            clearUserControls();

            MySqlConnect Conn = new MySqlConnect();
            Conn.mysqlQuery = "Select * FROM `tbl_credentials_role` WHERE User_ID = @userID " +
                "AND SF_Code = @SF_Code";

            Conn.checkCredentials(901, showAccountingMenu);

        }

        public void clearUserControls()
        {
            foreach (Control c in pnlContainer.Controls)
            {
                pnlContainer.Controls.Remove(c);
            }

            btnBack.Visible = false;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            clearUserControls();

            frmController.Instance.PnlTitle.Hide();


            frmController.Instance.PnlTitle.Hide();
            guna2Transition1.Show(frmController.Instance.PnlTitle);
            frmController.Instance.PnlTitle.Controls["lblPageTitle"].Text = "Accounting Menu";



        }

        public void SampleMSg()
        {

        }

        private void btnUserSettings_Click(object sender, EventArgs e)
        {
            //MySqlConnect Acctg = new MySqlConnect();
            //Acctg.getUserUpdate = "Save";

            //frmSignUp frmSignUp = new frmSignUp();
            //frmSignUp.ShowDialog();

        }

        private void btnVersion_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnMenuMin_Click(object sender, EventArgs e)
        {

            var point = new System.Drawing.Point(180, 54);
            this.pnlContainer.Location = point;
        }

        private void btnMenuMin2_Click(object sender, EventArgs e)
        {

            var point = new System.Drawing.Point(180, 54);
            this.pnlContainer.Location = point;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {

            var point = new System.Drawing.Point(221, 54);
            this.pnlContainer.Location = point;
        }

        private void btnDashboardMin_Click(object sender, EventArgs e)
        {
            frmController.Instance.pnlTitle.Hide();

            clearUserControls();

            var uc = new UCHomePage();
            uc.Dock = DockStyle.Fill;
            frmController.Instance.PnlContainer.Controls.Add(uc);


        }

        private void btnAccountingMin_Click(object sender, EventArgs e)
        {

            clearUserControls();

            MySqlConnect Conn = new MySqlConnect();
            Conn.mysqlQuery = "Select * FROM `tbl_credentials_role` WHERE User_ID = @userID " +
                "AND SF_Code = @SF_Code";

            Conn.checkCredentials(901, showAccountingMenu);

        }

        private void btnCommiTemp_Click(object sender, EventArgs e)
        {

        }

        private void btnCommiMin_Click(object sender, EventArgs e)
        {
            clearUserControls();

            MySqlConnect Conn = new MySqlConnect();
            Conn.mysqlQuery = "Select * FROM `tbl_credentials_role` WHERE User_ID = @userID " +
                "AND SF_Code = @SF_Code";

            Conn.checkCredentials(901, showUploadTemplates);


        }

        private void btnBudgetTemp_Click(object sender, EventArgs e)
        {

        }


        public void showUploadTemplates()
        {
            UCTemplates uc = new UCTemplates();
            uc.Dock = DockStyle.Fill;
            frmController.Instance.PnlContainer.Controls.Add(uc);

            frmController.Instance.PnlContainer.Controls["UCTemplates"].BringToFront();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            clearUserControls();

            MySqlConnect Conn = new MySqlConnect();
            Conn.mysqlQuery = "Select * FROM `tbl_credentials_role` WHERE User_ID = @userID " +
                "AND SF_Code = @SF_Code";

            Conn.checkCredentials(901, showUploadTemplates);
        }

        public void showImport()
        {
            clearUserControls();

            UCUpload uc = new UCUpload();
            uc.Dock = DockStyle.Fill;
            frmController.Instance.PnlContainer.Controls.Add(uc);

            frmController.Instance.PnlContainer.Controls["UCUpload"].BringToFront();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            clearUserControls();

            MySqlConnect Conn = new MySqlConnect();
            Conn.mysqlQuery = "Select * FROM `tbl_credentials_role` WHERE User_ID = @userID " +
                "AND SF_Code = @SF_Code";

            Conn.checkCredentials(901, showImport);
        }

        private void btnUploadMin_Click(object sender, EventArgs e)
        {
            clearUserControls();

            MySqlConnect Conn = new MySqlConnect();
            Conn.mysqlQuery = "Select * FROM `tbl_credentials_role` WHERE User_ID = @userID " +
                "AND SF_Code = @SF_Code";

            Conn.checkCredentials(901, showImport);
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnCharts_Click(object sender, EventArgs e)
        {
            clearUserControls();
            var uc = new UCDashboardGraph();
            uc.Dock = DockStyle.Fill;
            frmController.Instance.PnlContainer.Controls.Add(uc);
            frmController.Instance.PnlContainer.Controls["UCDashboard"].BringToFront();
        }
    }

}
