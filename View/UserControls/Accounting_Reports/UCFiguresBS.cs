using System;
using System.Windows.Forms;

namespace EXIN
{
    public partial class UCFiguresBS : UserControl
    {
        public UCFiguresBS()
        {
            InitializeComponent();
        }

        private void UCFiguresBS_Load(object sender, EventArgs e)
        {
            if (!txtAmount.Enabled)
            {
                //txtAmount.BackColor = Color.White;
                //txtAmount.ForeColor = Color.Red;
            }
        }


    }
}
