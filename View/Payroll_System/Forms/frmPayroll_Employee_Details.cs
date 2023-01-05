using EXIN.Controller;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EXIN.Payroll_System
{
    public partial class frmPayroll_Employee_Details : Form
    {
        public frmPayroll_Employee_Details()
        {
            InitializeComponent();

            // Logo
            this.Icon = new Icon("Resources/General/Logo.ico");

            // Panel Title
            panelTitleBar.CustomBorderColor = Global.themeColor2;

            // Controls - Button 3
            btnSave.FillColor = Global.themeColor1;
            btnSave.FillColor2 = Global.themeColor2;

            // Controls - Button 3
            btnClose.FillColor = Global.themeColor1;
            btnClose.FillColor2 = Global.themeColor2;
        }

        private void frmPayroll_Employee_Details_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }
    }
}
