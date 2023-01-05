
namespace EXIN.Fixed_Assets_Management_System
{
    partial class frmFixedAssets_ParentContainer
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Guna.UI2.AnimatorNS.Animation animation2 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFixedAssets_ParentContainer));
            this.elpParent = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.transitionMenuTwo = new Guna.UI2.WinForms.Guna2Transition();
            this.pnlSideBar = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.btnMenuSettings = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnMasterlist = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnMenuHome = new Guna.UI2.WinForms.Guna2TileButton();
            this.picLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.logoBox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.panelTitleBar = new Guna.UI2.WinForms.Guna2Panel();
            this.panelTitleBar2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel15 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ControlBox4 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox5 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox6 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMainContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.panelContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel11 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel10 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel7 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.pnlSideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            this.panelTitleBar2.SuspendLayout();
            this.guna2Panel15.SuspendLayout();
            this.panelMainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // elpParent
            // 
            this.elpParent.BorderRadius = 15;
            this.elpParent.TargetControl = this;
            // 
            // transitionMenuTwo
            // 
            this.transitionMenuTwo.AnimationType = Guna.UI2.AnimatorNS.AnimationType.HorizSlide;
            this.transitionMenuTwo.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.transitionMenuTwo.DefaultAnimation = animation2;
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.BackColor = System.Drawing.Color.Transparent;
            this.pnlSideBar.BorderRadius = 5;
            this.pnlSideBar.Controls.Add(this.btnMenuSettings);
            this.pnlSideBar.Controls.Add(this.btnMasterlist);
            this.pnlSideBar.Controls.Add(this.btnMenuHome);
            this.pnlSideBar.Controls.Add(this.picLogo);
            this.pnlSideBar.Controls.Add(this.guna2Panel1);
            this.pnlSideBar.Controls.Add(this.logoBox);
            this.transitionMenuTwo.SetDecoration(this.pnlSideBar, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pnlSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideBar.FillColor = System.Drawing.Color.MidnightBlue;
            this.pnlSideBar.Location = new System.Drawing.Point(0, 0);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.ShadowDecoration.BorderRadius = 5;
            this.pnlSideBar.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.pnlSideBar.ShadowDecoration.Enabled = true;
            this.pnlSideBar.ShadowDecoration.Parent = this.pnlSideBar;
            this.pnlSideBar.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.pnlSideBar.Size = new System.Drawing.Size(197, 767);
            this.pnlSideBar.TabIndex = 2;
            // 
            // btnMenuSettings
            // 
            this.btnMenuSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuSettings.CheckedState.Parent = this.btnMenuSettings;
            this.btnMenuSettings.CustomImages.Parent = this.btnMenuSettings;
            this.transitionMenuTwo.SetDecoration(this.btnMenuSettings, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnMenuSettings.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuSettings.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuSettings.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuSettings.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuSettings.DisabledState.Parent = this.btnMenuSettings;
            this.btnMenuSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuSettings.FillColor = System.Drawing.Color.Transparent;
            this.btnMenuSettings.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuSettings.ForeColor = System.Drawing.Color.White;
            this.btnMenuSettings.HoverState.Parent = this.btnMenuSettings;
            this.btnMenuSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnMenuSettings.Image")));
            this.btnMenuSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMenuSettings.ImageOffset = new System.Drawing.Point(10, 12);
            this.btnMenuSettings.ImageSize = new System.Drawing.Size(27, 27);
            this.btnMenuSettings.Location = new System.Drawing.Point(0, 290);
            this.btnMenuSettings.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenuSettings.Name = "btnMenuSettings";
            this.btnMenuSettings.PressedColor = System.Drawing.Color.Silver;
            this.btnMenuSettings.ShadowDecoration.Parent = this.btnMenuSettings;
            this.btnMenuSettings.Size = new System.Drawing.Size(197, 50);
            this.btnMenuSettings.TabIndex = 25;
            this.btnMenuSettings.Text = "Settings";
            this.btnMenuSettings.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMenuSettings.TextOffset = new System.Drawing.Point(55, -15);
            this.btnMenuSettings.Click += new System.EventHandler(this.btnMenuSettings_Click);
            // 
            // btnMasterlist
            // 
            this.btnMasterlist.BackColor = System.Drawing.Color.Transparent;
            this.btnMasterlist.CheckedState.Parent = this.btnMasterlist;
            this.btnMasterlist.CustomImages.Parent = this.btnMasterlist;
            this.transitionMenuTwo.SetDecoration(this.btnMasterlist, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnMasterlist.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMasterlist.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMasterlist.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMasterlist.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMasterlist.DisabledState.Parent = this.btnMasterlist;
            this.btnMasterlist.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMasterlist.FillColor = System.Drawing.Color.Transparent;
            this.btnMasterlist.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasterlist.ForeColor = System.Drawing.Color.White;
            this.btnMasterlist.HoverState.Parent = this.btnMasterlist;
            this.btnMasterlist.Image = ((System.Drawing.Image)(resources.GetObject("btnMasterlist.Image")));
            this.btnMasterlist.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMasterlist.ImageOffset = new System.Drawing.Point(10, 12);
            this.btnMasterlist.ImageSize = new System.Drawing.Size(27, 27);
            this.btnMasterlist.Location = new System.Drawing.Point(0, 240);
            this.btnMasterlist.Margin = new System.Windows.Forms.Padding(0);
            this.btnMasterlist.Name = "btnMasterlist";
            this.btnMasterlist.PressedColor = System.Drawing.Color.Silver;
            this.btnMasterlist.ShadowDecoration.Parent = this.btnMasterlist;
            this.btnMasterlist.Size = new System.Drawing.Size(197, 50);
            this.btnMasterlist.TabIndex = 24;
            this.btnMasterlist.Text = "Employee List";
            this.btnMasterlist.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMasterlist.TextOffset = new System.Drawing.Point(55, -15);
            this.btnMasterlist.Click += new System.EventHandler(this.btnMasterlist_Click);
            // 
            // btnMenuHome
            // 
            this.btnMenuHome.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuHome.Checked = true;
            this.btnMenuHome.CheckedState.Parent = this.btnMenuHome;
            this.btnMenuHome.CustomImages.Parent = this.btnMenuHome;
            this.transitionMenuTwo.SetDecoration(this.btnMenuHome, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnMenuHome.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuHome.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuHome.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuHome.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuHome.DisabledState.Parent = this.btnMenuHome;
            this.btnMenuHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuHome.FillColor = System.Drawing.Color.Transparent;
            this.btnMenuHome.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuHome.ForeColor = System.Drawing.Color.White;
            this.btnMenuHome.HoverState.Parent = this.btnMenuHome;
            this.btnMenuHome.Image = ((System.Drawing.Image)(resources.GetObject("btnMenuHome.Image")));
            this.btnMenuHome.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMenuHome.ImageOffset = new System.Drawing.Point(10, 12);
            this.btnMenuHome.ImageSize = new System.Drawing.Size(27, 27);
            this.btnMenuHome.Location = new System.Drawing.Point(0, 190);
            this.btnMenuHome.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenuHome.Name = "btnMenuHome";
            this.btnMenuHome.PressedColor = System.Drawing.Color.Silver;
            this.btnMenuHome.ShadowDecoration.Parent = this.btnMenuHome;
            this.btnMenuHome.Size = new System.Drawing.Size(197, 50);
            this.btnMenuHome.TabIndex = 23;
            this.btnMenuHome.Text = "Home";
            this.btnMenuHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMenuHome.TextOffset = new System.Drawing.Point(55, -15);
            this.btnMenuHome.Click += new System.EventHandler(this.btnMenuHome_Click);
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.transitionMenuTwo.SetDecoration(this.picLogo, Guna.UI2.AnimatorNS.DecorationType.None);
            this.picLogo.Enabled = false;
            this.picLogo.ImageRotate = 0F;
            this.picLogo.Location = new System.Drawing.Point(34, 34);
            this.picLogo.Name = "picLogo";
            this.picLogo.ShadowDecoration.Parent = this.picLogo;
            this.picLogo.Size = new System.Drawing.Size(125, 125);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 22;
            this.picLogo.TabStop = false;
            this.picLogo.UseTransparentBackground = true;
            // 
            // guna2Panel1
            // 
            this.transitionMenuTwo.SetDecoration(this.guna2Panel1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 162);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(197, 28);
            this.guna2Panel1.TabIndex = 3;
            // 
            // logoBox
            // 
            this.logoBox.BackColor = System.Drawing.Color.Transparent;
            this.logoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.transitionMenuTwo.SetDecoration(this.logoBox, Guna.UI2.AnimatorNS.DecorationType.None);
            this.logoBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoBox.FillColor = System.Drawing.Color.Transparent;
            this.logoBox.Image = ((System.Drawing.Image)(resources.GetObject("logoBox.Image")));
            this.logoBox.ImageRotate = 0F;
            this.logoBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("logoBox.InitialImage")));
            this.logoBox.Location = new System.Drawing.Point(0, 0);
            this.logoBox.Name = "logoBox";
            this.logoBox.ShadowDecoration.Parent = this.logoBox;
            this.logoBox.Size = new System.Drawing.Size(197, 162);
            this.logoBox.TabIndex = 1;
            this.logoBox.TabStop = false;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.Controls.Add(this.panelTitleBar2);
            this.transitionMenuTwo.SetDecoration(this.panelTitleBar, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(197, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.ShadowDecoration.BorderRadius = 5;
            this.panelTitleBar.ShadowDecoration.Color = System.Drawing.Color.DarkGray;
            this.panelTitleBar.ShadowDecoration.Enabled = true;
            this.panelTitleBar.ShadowDecoration.Parent = this.panelTitleBar;
            this.panelTitleBar.Size = new System.Drawing.Size(1019, 79);
            this.panelTitleBar.TabIndex = 21;
            // 
            // panelTitleBar2
            // 
            this.panelTitleBar2.Controls.Add(this.guna2Panel15);
            this.panelTitleBar2.Controls.Add(this.label1);
            this.transitionMenuTwo.SetDecoration(this.panelTitleBar2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panelTitleBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar2.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar2.Name = "panelTitleBar2";
            this.panelTitleBar2.ShadowDecoration.BorderRadius = 5;
            this.panelTitleBar2.ShadowDecoration.Color = System.Drawing.Color.DarkGray;
            this.panelTitleBar2.ShadowDecoration.Enabled = true;
            this.panelTitleBar2.ShadowDecoration.Parent = this.panelTitleBar2;
            this.panelTitleBar2.Size = new System.Drawing.Size(1019, 76);
            this.panelTitleBar2.TabIndex = 28;
            // 
            // guna2Panel15
            // 
            this.guna2Panel15.Controls.Add(this.guna2ControlBox4);
            this.guna2Panel15.Controls.Add(this.guna2ControlBox5);
            this.guna2Panel15.Controls.Add(this.guna2ControlBox6);
            this.transitionMenuTwo.SetDecoration(this.guna2Panel15, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel15.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel15.Location = new System.Drawing.Point(877, 0);
            this.guna2Panel15.Name = "guna2Panel15";
            this.guna2Panel15.ShadowDecoration.Parent = this.guna2Panel15;
            this.guna2Panel15.Size = new System.Drawing.Size(142, 76);
            this.guna2Panel15.TabIndex = 119;
            // 
            // guna2ControlBox4
            // 
            this.guna2ControlBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox4.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox4.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox4.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.transitionMenuTwo.SetDecoration(this.guna2ControlBox4, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2ControlBox4.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox4.HoverState.Parent = this.guna2ControlBox4;
            this.guna2ControlBox4.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.guna2ControlBox4.Location = new System.Drawing.Point(9, 0);
            this.guna2ControlBox4.Name = "guna2ControlBox4";
            this.guna2ControlBox4.ShadowDecoration.Parent = this.guna2ControlBox4;
            this.guna2ControlBox4.Size = new System.Drawing.Size(44, 40);
            this.guna2ControlBox4.TabIndex = 118;
            // 
            // guna2ControlBox5
            // 
            this.guna2ControlBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox5.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox5.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox5.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.transitionMenuTwo.SetDecoration(this.guna2ControlBox5, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2ControlBox5.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox5.HoverState.Parent = this.guna2ControlBox5;
            this.guna2ControlBox5.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.guna2ControlBox5.Location = new System.Drawing.Point(53, 0);
            this.guna2ControlBox5.Name = "guna2ControlBox5";
            this.guna2ControlBox5.ShadowDecoration.Parent = this.guna2ControlBox5;
            this.guna2ControlBox5.Size = new System.Drawing.Size(44, 40);
            this.guna2ControlBox5.TabIndex = 116;
            // 
            // guna2ControlBox6
            // 
            this.guna2ControlBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox6.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox6.BorderColor = System.Drawing.Color.Transparent;
            this.transitionMenuTwo.SetDecoration(this.guna2ControlBox6, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2ControlBox6.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox6.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(74)))), ((int)(((byte)(37)))));
            this.guna2ControlBox6.HoverState.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox6.HoverState.Parent = this.guna2ControlBox6;
            this.guna2ControlBox6.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.guna2ControlBox6.Location = new System.Drawing.Point(97, 0);
            this.guna2ControlBox6.Name = "guna2ControlBox6";
            this.guna2ControlBox6.ShadowDecoration.Parent = this.guna2ControlBox6;
            this.guna2ControlBox6.Size = new System.Drawing.Size(44, 40);
            this.guna2ControlBox6.TabIndex = 117;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.transitionMenuTwo.SetDecoration(this.label1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(493, 36);
            this.label1.TabIndex = 115;
            this.label1.Text = "Fixed Assets Management System";
            // 
            // panelMainContainer
            // 
            this.panelMainContainer.Controls.Add(this.panelContainer);
            this.panelMainContainer.Controls.Add(this.guna2Panel11);
            this.panelMainContainer.Controls.Add(this.guna2Panel10);
            this.panelMainContainer.Controls.Add(this.guna2Panel7);
            this.panelMainContainer.Controls.Add(this.guna2Panel4);
            this.panelMainContainer.CustomizableEdges.TopLeft = false;
            this.panelMainContainer.CustomizableEdges.TopRight = false;
            this.transitionMenuTwo.SetDecoration(this.panelMainContainer, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panelMainContainer.FillColor = System.Drawing.Color.White;
            this.panelMainContainer.Location = new System.Drawing.Point(567, 158);
            this.panelMainContainer.Name = "panelMainContainer";
            this.panelMainContainer.ShadowDecoration.Parent = this.panelMainContainer;
            this.panelMainContainer.Size = new System.Drawing.Size(320, 212);
            this.panelMainContainer.TabIndex = 25;
            // 
            // panelContainer
            // 
            this.transitionMenuTwo.SetDecoration(this.panelContainer, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(20, 20);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.ShadowDecoration.Parent = this.panelContainer;
            this.panelContainer.Size = new System.Drawing.Size(280, 172);
            this.panelContainer.TabIndex = 4;
            // 
            // guna2Panel11
            // 
            this.transitionMenuTwo.SetDecoration(this.guna2Panel11, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel11.Location = new System.Drawing.Point(20, 192);
            this.guna2Panel11.Name = "guna2Panel11";
            this.guna2Panel11.ShadowDecoration.Parent = this.guna2Panel11;
            this.guna2Panel11.Size = new System.Drawing.Size(280, 20);
            this.guna2Panel11.TabIndex = 3;
            // 
            // guna2Panel10
            // 
            this.transitionMenuTwo.SetDecoration(this.guna2Panel10, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel10.Location = new System.Drawing.Point(20, 0);
            this.guna2Panel10.Name = "guna2Panel10";
            this.guna2Panel10.ShadowDecoration.Parent = this.guna2Panel10;
            this.guna2Panel10.Size = new System.Drawing.Size(280, 20);
            this.guna2Panel10.TabIndex = 2;
            // 
            // guna2Panel7
            // 
            this.transitionMenuTwo.SetDecoration(this.guna2Panel7, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel7.Location = new System.Drawing.Point(300, 0);
            this.guna2Panel7.Name = "guna2Panel7";
            this.guna2Panel7.ShadowDecoration.Parent = this.guna2Panel7;
            this.guna2Panel7.Size = new System.Drawing.Size(20, 212);
            this.guna2Panel7.TabIndex = 1;
            // 
            // guna2Panel4
            // 
            this.transitionMenuTwo.SetDecoration(this.guna2Panel4, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel4.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.ShadowDecoration.Parent = this.guna2Panel4;
            this.guna2Panel4.Size = new System.Drawing.Size(20, 212);
            this.guna2Panel4.TabIndex = 0;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.panelTitleBar2;
            this.guna2DragControl1.TransparentWhileDrag = true;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // frmFixedAssets_ParentContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 767);
            this.Controls.Add(this.panelMainContainer);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.pnlSideBar);
            this.transitionMenuTwo.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFixedAssets_ParentContainer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFixedAssets_ParentContainer";
            this.Load += new System.EventHandler(this.frmFixedAssets_ParentContainer_Load);
            this.pnlSideBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar2.ResumeLayout(false);
            this.panelTitleBar2.PerformLayout();
            this.guna2Panel15.ResumeLayout(false);
            this.panelMainContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse elpParent;
        private Guna.UI2.WinForms.Guna2Transition transitionMenuTwo;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlSideBar;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox logoBox;
        private Guna.UI2.WinForms.Guna2Panel panelTitleBar;
        private Guna.UI2.WinForms.Guna2Panel panelMainContainer;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel11;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel10;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel7;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2Panel panelContainer;
        private Guna.UI2.WinForms.Guna2PictureBox picLogo;
        private Guna.UI2.WinForms.Guna2TileButton btnMenuHome;
        private Guna.UI2.WinForms.Guna2TileButton btnMasterlist;
        private Guna.UI2.WinForms.Guna2TileButton btnMenuSettings;
        private Guna.UI2.WinForms.Guna2Panel panelTitleBar2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel15;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox4;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox5;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox6;
        private System.Windows.Forms.Label label1;
    }
}