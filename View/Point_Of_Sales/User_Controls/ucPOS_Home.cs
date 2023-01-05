using System;
using System.Drawing;
using System.Windows.Forms;

namespace EXIN.Point_Of_Sales
{
    public partial class ucPOS_Home : UserControl
    {
        public ucPOS_Home()
        {
            InitializeComponent();

            InitializeThemes();
        }

        public void InitializeThemes()
        {

        }

        private void ucPOS_Home_Load(object sender, EventArgs e)
        {
            picBackground.Image = Image.FromFile("Resources/Point_Of_Sales/Background.jpg");
        }
    }
}
