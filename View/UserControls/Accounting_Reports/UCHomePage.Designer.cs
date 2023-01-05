namespace EXIN
{
    partial class UCHomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCHomePage));
            this.gunaCircleProgressBar1 = new Guna.UI.WinForms.GunaCircleProgressBar();
            this.gunaCircleProgressBar2 = new Guna.UI.WinForms.GunaCircleProgressBar();

            this.gunaImageButton5 = new Guna.UI.WinForms.GunaImageButton();
            this.gunaSeparator1 = new Guna.UI.WinForms.GunaSeparator();
            this.lblDate = new Guna.UI.WinForms.GunaLabel();
            this.lblTime = new Guna.UI.WinForms.GunaLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlExinnov = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2GradientPanel5 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2Transition1 = new Guna.UI2.WinForms.Guna2Transition();
            this.guna2ColorTransition1 = new Guna.UI2.WinForms.Guna2ColorTransition(this.components);
            this.gunaCircleProgressBar1.SuspendLayout();
            this.guna2GradientPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaCircleProgressBar1
            // 
            this.gunaCircleProgressBar1.Animated = true;
            this.gunaCircleProgressBar1.AnimationSpeed = 0.4F;
            this.gunaCircleProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.gunaCircleProgressBar1.BaseColor = System.Drawing.Color.Teal;
            this.gunaCircleProgressBar1.Controls.Add(this.gunaCircleProgressBar2);
            this.guna2Transition1.SetDecoration(this.gunaCircleProgressBar1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.gunaCircleProgressBar1.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaCircleProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(41)))), ((int)(((byte)(144)))));
            this.gunaCircleProgressBar1.IdleColor = System.Drawing.Color.Teal;
            this.gunaCircleProgressBar1.IdleOffset = 25;
            this.gunaCircleProgressBar1.IdleThickness = 10;
            this.gunaCircleProgressBar1.Image = null;
            this.gunaCircleProgressBar1.ImageSize = new System.Drawing.Size(52, 52);
            this.gunaCircleProgressBar1.LineEndCap = System.Drawing.Drawing2D.LineCap.Round;
            this.gunaCircleProgressBar1.LineStartCap = System.Drawing.Drawing2D.LineCap.Round;
            this.gunaCircleProgressBar1.Location = new System.Drawing.Point(626, 3);
            this.gunaCircleProgressBar1.Name = "gunaCircleProgressBar1";
            this.gunaCircleProgressBar1.ProgressMaxColor = System.Drawing.Color.White;
            this.gunaCircleProgressBar1.ProgressMinColor = System.Drawing.Color.Teal;
            this.gunaCircleProgressBar1.ProgressOffset = 40;
            this.gunaCircleProgressBar1.ProgressThickness = 15;
            this.gunaCircleProgressBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gunaCircleProgressBar1.Size = new System.Drawing.Size(154, 150);
            this.gunaCircleProgressBar1.TabIndex = 2;
            this.gunaCircleProgressBar1.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.ClearTypeGridFit;
            this.gunaCircleProgressBar1.Value = 80;
            this.gunaCircleProgressBar1.Click += new System.EventHandler(this.gunaCircleProgressBar1_Click);
            // 
            // gunaCircleProgressBar2
            // 
            this.gunaCircleProgressBar2.Animated = true;
            this.gunaCircleProgressBar2.AnimationSpeed = 0.8F;
            this.gunaCircleProgressBar2.BackColor = System.Drawing.Color.Transparent;
            this.gunaCircleProgressBar2.BaseColor = System.Drawing.Color.Teal;
            this.guna2Transition1.SetDecoration(this.gunaCircleProgressBar2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.gunaCircleProgressBar2.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaCircleProgressBar2.ForeColor = System.Drawing.Color.White;
            this.gunaCircleProgressBar2.IdleColor = System.Drawing.Color.Teal;
            this.gunaCircleProgressBar2.IdleOffset = 25;
            this.gunaCircleProgressBar2.IdleThickness = 10;
            this.gunaCircleProgressBar2.Image = null;
            this.gunaCircleProgressBar2.ImageSize = new System.Drawing.Size(52, 52);
            this.gunaCircleProgressBar2.LineEndCap = System.Drawing.Drawing2D.LineCap.Round;
            this.gunaCircleProgressBar2.LineStartCap = System.Drawing.Drawing2D.LineCap.Round;
            this.gunaCircleProgressBar2.Location = new System.Drawing.Point(30, 28);
            this.gunaCircleProgressBar2.Name = "gunaCircleProgressBar2";
            this.gunaCircleProgressBar2.ProgressMaxColor = System.Drawing.Color.White;
            this.gunaCircleProgressBar2.ProgressMinColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.gunaCircleProgressBar2.ProgressOffset = 30;
            this.gunaCircleProgressBar2.ProgressThickness = 11;
            this.gunaCircleProgressBar2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gunaCircleProgressBar2.Size = new System.Drawing.Size(91, 92);
            this.gunaCircleProgressBar2.TabIndex = 3;
            this.gunaCircleProgressBar2.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.ClearTypeGridFit;
            this.gunaCircleProgressBar2.UseProgressPercentText = true;
            this.gunaCircleProgressBar2.Value = 30;
            this.gunaCircleProgressBar2.Click += new System.EventHandler(this.gunaCircleProgressBar2_Click);
            // 
            // gunaImageButton5
            // 
            this.gunaImageButton5.BackColor = System.Drawing.Color.Transparent;
            this.gunaImageButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2Transition1.SetDecoration(this.gunaImageButton5, Guna.UI2.AnimatorNS.DecorationType.None);
            this.gunaImageButton5.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaImageButton5.Image = ((System.Drawing.Image)(resources.GetObject("gunaImageButton5.Image")));
            this.gunaImageButton5.ImageSize = new System.Drawing.Size(30, 30);
            this.gunaImageButton5.Location = new System.Drawing.Point(7, 0);
            this.gunaImageButton5.Name = "gunaImageButton5";
            this.gunaImageButton5.OnHoverImage = null;
            this.gunaImageButton5.OnHoverImageOffset = new System.Drawing.Point(0, -2);
            this.gunaImageButton5.Size = new System.Drawing.Size(37, 52);
            this.gunaImageButton5.TabIndex = 2;
            // 
            // gunaSeparator1
            // 
            this.gunaSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.gunaSeparator1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.gunaSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(79)))));
            this.gunaSeparator1.Location = new System.Drawing.Point(118, 73);
            this.gunaSeparator1.Name = "gunaSeparator1";
            this.gunaSeparator1.Size = new System.Drawing.Size(231, 14);
            this.gunaSeparator1.TabIndex = 4;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblDate, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblDate.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(79)))));
            this.lblDate.Location = new System.Drawing.Point(98, 23);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(281, 47);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblTime, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblTime.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(79)))));
            this.lblTime.Location = new System.Drawing.Point(198, 90);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(46, 18);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "Time";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlExinnov
            // 
            this.pnlExinnov.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlExinnov.BackColor = System.Drawing.Color.Transparent;
            this.pnlExinnov.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlExinnov.BackgroundImage")));
            this.pnlExinnov.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlExinnov.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.pnlExinnov, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pnlExinnov.Location = new System.Drawing.Point(344, 159);
            this.pnlExinnov.Name = "pnlExinnov";
            this.pnlExinnov.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.pnlExinnov.ShadowDecoration.Parent = this.pnlExinnov;
            this.pnlExinnov.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.pnlExinnov.Size = new System.Drawing.Size(740, 217);
            this.pnlExinnov.TabIndex = 2;
            // 
            // guna2GradientPanel5
            // 
            this.guna2GradientPanel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2GradientPanel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel5.BorderRadius = 8;
            this.guna2GradientPanel5.Controls.Add(this.gunaCircleProgressBar1);
            this.guna2GradientPanel5.Controls.Add(this.lblDate);
            this.guna2GradientPanel5.Controls.Add(this.gunaImageButton5);
            this.guna2GradientPanel5.Controls.Add(this.lblTime);
            this.guna2GradientPanel5.Controls.Add(this.gunaSeparator1);
            this.guna2Transition1.SetDecoration(this.guna2GradientPanel5, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2GradientPanel5.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel5.FillColor2 = System.Drawing.Color.White;
            this.guna2GradientPanel5.Location = new System.Drawing.Point(295, 464);
            this.guna2GradientPanel5.Name = "guna2GradientPanel5";
            this.guna2GradientPanel5.ShadowDecoration.BorderRadius = 8;
            this.guna2GradientPanel5.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.guna2GradientPanel5.ShadowDecoration.Enabled = true;
            this.guna2GradientPanel5.ShadowDecoration.Parent = this.guna2GradientPanel5;
            this.guna2GradientPanel5.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.guna2GradientPanel5.Size = new System.Drawing.Size(823, 165);
            this.guna2GradientPanel5.TabIndex = 35;
            // 
            // guna2Transition1
            // 
            this.guna2Transition1.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Particles;
            this.guna2Transition1.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 1;
            animation1.Padding = new System.Windows.Forms.Padding(100, 50, 100, 150);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 2F;
            animation1.TransparencyCoeff = 0F;
            this.guna2Transition1.DefaultAnimation = animation1;
            // 
            // guna2ColorTransition1
            // 
            this.guna2ColorTransition1.AutoTransition = true;
            this.guna2ColorTransition1.ColorArray = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Blue,
        System.Drawing.Color.Orange};
            this.guna2ColorTransition1.EndColor = System.Drawing.Color.White;
            this.guna2ColorTransition1.StartColor = System.Drawing.Color.MediumAquamarine;
            // 
            // UCDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2GradientPanel5);
            this.Controls.Add(this.pnlExinnov);
            this.guna2Transition1.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.Name = "UCHomePage";
            this.Size = new System.Drawing.Size(1310, 730);
            this.Load += new System.EventHandler(this.UCHomePage_Load);
            this.gunaCircleProgressBar1.ResumeLayout(false);
            this.guna2GradientPanel5.ResumeLayout(false);
            this.guna2GradientPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI.WinForms.GunaCircleProgressBar gunaCircleProgressBar1;
        private Guna.UI.WinForms.GunaLabel lblTime;
        private Guna.UI.WinForms.GunaLabel lblDate;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI.WinForms.GunaSeparator gunaSeparator1;
        private Guna.UI.WinForms.GunaCircleProgressBar gunaCircleProgressBar2;
        private Guna.UI.WinForms.GunaImageButton gunaImageButton5;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlExinnov;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel5;
        private Guna.UI2.WinForms.Guna2Transition guna2Transition1;
        private Guna.UI2.WinForms.Guna2ColorTransition guna2ColorTransition1;
    }
}
