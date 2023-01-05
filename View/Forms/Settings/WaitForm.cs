using System.Drawing;
using System.Windows.Forms;

namespace EXIN
{
    public partial class WaitForm : Form
    {
        public WaitForm()
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
            this.StartPosition = FormStartPosition.CenterParent;
        }

        public WaitForm(Form parent)
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
            if (parent != null)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(parent.Location.X + parent.Width / 2 - this.Width / 2,
                parent.Location.Y + parent.Height / 2 - this.Height / 2);

            }
            else
                this.StartPosition = FormStartPosition.CenterParent;
        }

        public void CloseWaitForm()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


    }
}
