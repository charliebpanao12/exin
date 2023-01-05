using EXIN.Controller;
using System;
using System.Windows.Forms;

namespace EXIN.Settings
{
    public partial class ucSettings_UserCredentials_SystemFeatures : UserControl
    {
        public string systemModule;
        public string category;
        public string systemFeature;

        public ucSettings_UserCredentials_SystemFeatures()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {
            // Controls - Toggle Switch
            toggleControl.CheckedState.FillColor = Global.themeColor1;
        }

        private void ucSettings_UserCredentials_Load(object sender, EventArgs e)
        {
            lblCategory.Text = category;
            lblSystemFeature.Text = systemFeature;
        }
    }
}
