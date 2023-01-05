using System;
using System.Drawing;
using System.Windows.Forms;



namespace EXIN
{
    public partial class frmEXIN : Form
    {
        public frmEXIN()
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            zeroitSmoothAnimator1.Start();
            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);
            Guna.UI.Lib.GraphicsHelper.DrawLineShadow(pnlParent, Color.Black, 20, 10, Guna.UI.WinForms.VerHorAlign.HoriziontalTop);
            //pnlGradient.GradientColor1 = Color.FromArgb(150, 40, 223, 153);
            //pnlGradient.GradientColor2 = Color.FromArgb(200, 6, 84, 70);
            gunaProgressBar1.Value = 0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gunaProgressBar1.Increment(2);
            gunaLabel2.Text = gunaProgressBar1.ProgressPercentText;
            if (gunaProgressBar1.Value == 100)
            {
                timer1.Stop();
                frmUserLogin frmUserLogin = new frmUserLogin();
                frmUserLogin.Show();
                this.Hide();

            }
        }
    }
}
