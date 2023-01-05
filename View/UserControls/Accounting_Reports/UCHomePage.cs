using System;
using System.Windows.Forms;

namespace EXIN
{
    public partial class UCHomePage : UserControl
    {
        public UCHomePage()
        {
            InitializeComponent();

            frmController.Instance.PnlTitle.Hide();

        }

        public void Alert(string msg, frmAlert.alertTypeEnum type)
        {
            frmAlert f = new frmAlert();
            f.setAlert(msg, type);
        }

        private void UCHomePage_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
            gunaCircleProgressBar1.Value = 0;
            gunaCircleProgressBar2.Value = 0;
            gunaCircleProgressBar1.Animated = gunaCircleProgressBar1.Enabled;
            gunaCircleProgressBar2.Animated = gunaCircleProgressBar2.Enabled;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            gunaCircleProgressBar1.Increment(1);
            gunaCircleProgressBar2.Increment(1);

        }

        private void gunaCircleProgressBar1_Click(object sender, EventArgs e)
        {
            gunaCircleProgressBar1.Value = 0;
            gunaCircleProgressBar2.Value = 0;
            gunaCircleProgressBar1.Animated = gunaCircleProgressBar1.Enabled;
            gunaCircleProgressBar2.Animated = gunaCircleProgressBar2.Enabled;
        }

        private void gunaCircleProgressBar2_Click(object sender, EventArgs e)
        {
            gunaCircleProgressBar1.Value = 0;
            gunaCircleProgressBar2.Value = 0;
            gunaCircleProgressBar1.Animated = gunaCircleProgressBar1.Enabled;
            gunaCircleProgressBar2.Animated = gunaCircleProgressBar2.Enabled;
        }


    }
}
