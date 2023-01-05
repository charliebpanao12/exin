
namespace EXIN.Voucher_System
{
    partial class ucVoucher_Home
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Guna.UI2.AnimatorNS.Animation animation1 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucVoucher_Home));
            this.btnSelect = new Guna.UI2.WinForms.Guna2GradientButton();
            this.transitionFilterBox = new Guna.UI2.WinForms.Guna2Transition();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSelect.Animated = true;
            this.btnSelect.AutoRoundedCorners = true;
            this.btnSelect.BackColor = System.Drawing.Color.Transparent;
            this.btnSelect.BorderRadius = 30;
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transitionFilterBox.SetDecoration(this.btnSelect, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnSelect.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(158)))));
            this.btnSelect.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(214)))), ((int)(((byte)(245)))));
            this.btnSelect.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.White;
            this.btnSelect.Location = new System.Drawing.Point(248, 206);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(238, 62);
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "HOME";
            this.btnSelect.UseTransparentBackground = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // transitionFilterBox
            // 
            this.transitionFilterBox.AnimationType = Guna.UI2.AnimatorNS.AnimationType.HorizSlide;
            this.transitionFilterBox.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.transitionFilterBox.DefaultAnimation = animation1;
            // 
            // ucVoucher_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnSelect);
            this.transitionFilterBox.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucVoucher_Home";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Size = new System.Drawing.Size(761, 445);
            this.Load += new System.EventHandler(this.ucVoucher_Home_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton btnSelect;
        private Guna.UI2.WinForms.Guna2Transition transitionFilterBox;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
