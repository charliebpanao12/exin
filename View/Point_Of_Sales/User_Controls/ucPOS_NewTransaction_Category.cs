using System;
using System.Linq;
using System.Windows.Forms;

namespace EXIN.Point_Of_Sales
{
    public partial class ucPOS_NewTransaction_Category : UserControl
    {
        public static string category;
        public ucPOS_NewTransaction_Category()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {

        }

        private void ucPOS_NewTransaction_Category_Load(object sender, EventArgs e)
        {
            btnCategory.Text = category;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            var targetForm = Application.OpenForms.OfType<frmPOS_ParentContainer>().Single();
            targetForm.Controls["panelContainer"].Controls["ucPOS_NewTransaction"].Controls["panelMenuTitle"].Controls["lblChooseItems"].Text = "" + btnCategory.Text;

            for (var i = targetForm.Controls.Count - 1; i >= 0; i--)
            {
                if (targetForm.Controls[i].Name == "panelContainer")
                {
                    Panel contentPanel = targetForm.Controls[i] as Panel;
                    for (var j = contentPanel.Controls.Count - 1; j >= 0; j--)
                    {
                        if (contentPanel.Controls[j] is ucPOS_NewTransaction)
                        {
                            //MessageBox.Show("Hello: " + contentPanel.Controls[j].Name);                            
                            ucPOS_NewTransaction ucPOS_NewTransaction = contentPanel.Controls[j] as ucPOS_NewTransaction;
                            ucPOS_NewTransaction.filterCategory = btnCategory.Text;
                            ucPOS_NewTransaction.loadItems_Menu();
                            return;
                        }
                    }
                }
            }
        }
    }
}
