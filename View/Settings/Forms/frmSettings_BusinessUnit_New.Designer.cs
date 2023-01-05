
namespace EXIN.Settings
{
    partial class frmSettings_BusinessUnit_New
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
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panelTitle = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.zeroitSmoothAnimator1 = new Zeroit.Framework.Transitions.SmoothTransitions.ZeroitSmoothAnimator();
            this.guna2PanelBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnClose = new Guna.UI2.WinForms.Guna2GradientButton();
            this.cboBusinessCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtBusinessUnitName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cboCorporation = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numtxtBusinessUnitCode = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.txtBusinessCategoryCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCorporationCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTIN = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDateOpened = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.panelTitle.SuspendLayout();
            this.guna2PanelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numtxtBusinessUnitCode)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.panelTitle;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(141)))));
            this.panelTitle.CustomBorderThickness = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(682, 51);
            this.panelTitle.TabIndex = 173;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(139, 25);
            this.lblTitle.TabIndex = 114;
            this.lblTitle.Text = "Business Unit";
            // 
            // zeroitSmoothAnimator1
            // 
            this.zeroitSmoothAnimator1.AnimationType = Zeroit.Framework.Transitions.SmoothTransitions.AnimationTypes.FadeIn;
            this.zeroitSmoothAnimator1.Control = this;
            this.zeroitSmoothAnimator1.Duration = 400;
            this.zeroitSmoothAnimator1.Mover = 10F;
            this.zeroitSmoothAnimator1.Offset = 10F;
            this.zeroitSmoothAnimator1.Reverse = true;
            this.zeroitSmoothAnimator1.SmoothOut = false;
            this.zeroitSmoothAnimator1.StartValue = 100;
            this.zeroitSmoothAnimator1.TimerInterval = 10;
            this.zeroitSmoothAnimator1.TimerPassed = 0;
            // 
            // guna2PanelBottom
            // 
            this.guna2PanelBottom.BackColor = System.Drawing.Color.Transparent;
            this.guna2PanelBottom.BorderColor = System.Drawing.Color.Transparent;
            this.guna2PanelBottom.Controls.Add(this.btnSave);
            this.guna2PanelBottom.Controls.Add(this.btnClose);
            this.guna2PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2PanelBottom.Location = new System.Drawing.Point(0, 452);
            this.guna2PanelBottom.Name = "guna2PanelBottom";
            this.guna2PanelBottom.Size = new System.Drawing.Size(682, 86);
            this.guna2PanelBottom.TabIndex = 174;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Animated = true;
            this.btnSave.AutoRoundedCorners = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderRadius = 16;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(158)))));
            this.btnSave.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(214)))), ((int)(((byte)(245)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(360, 23);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 35);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseTransparentBackground = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClose.Animated = true;
            this.btnClose.AutoRoundedCorners = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderRadius = 16;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(158)))));
            this.btnClose.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(214)))), ((int)(((byte)(245)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(199, 23);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 35);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseTransparentBackground = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cboBusinessCategory
            // 
            this.cboBusinessCategory.BackColor = System.Drawing.Color.Transparent;
            this.cboBusinessCategory.BorderRadius = 10;
            this.cboBusinessCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBusinessCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBusinessCategory.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(141)))));
            this.cboBusinessCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(141)))));
            this.cboBusinessCategory.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBusinessCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboBusinessCategory.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(141)))));
            this.cboBusinessCategory.ItemHeight = 30;
            this.cboBusinessCategory.Location = new System.Drawing.Point(316, 102);
            this.cboBusinessCategory.Name = "cboBusinessCategory";
            this.cboBusinessCategory.Size = new System.Drawing.Size(322, 36);
            this.cboBusinessCategory.TabIndex = 185;
            this.cboBusinessCategory.TextOffset = new System.Drawing.Point(10, 0);
            this.cboBusinessCategory.SelectedIndexChanged += new System.EventHandler(this.cboBusinessCategory_SelectedIndexChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.DimGray;
            this.label24.Location = new System.Drawing.Point(43, 111);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(127, 16);
            this.label24.TabIndex = 184;
            this.label24.Text = "Business Category";
            // 
            // txtBusinessUnitName
            // 
            this.txtBusinessUnitName.BorderRadius = 5;
            this.txtBusinessUnitName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBusinessUnitName.DefaultText = "";
            this.txtBusinessUnitName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBusinessUnitName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBusinessUnitName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBusinessUnitName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBusinessUnitName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(150)))), ((int)(((byte)(141)))));
            this.txtBusinessUnitName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtBusinessUnitName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBusinessUnitName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(150)))), ((int)(((byte)(141)))));
            this.txtBusinessUnitName.Location = new System.Drawing.Point(316, 192);
            this.txtBusinessUnitName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBusinessUnitName.Name = "txtBusinessUnitName";
            this.txtBusinessUnitName.PasswordChar = '\0';
            this.txtBusinessUnitName.PlaceholderText = "Business Unit Name";
            this.txtBusinessUnitName.SelectedText = "";
            this.txtBusinessUnitName.Size = new System.Drawing.Size(322, 33);
            this.txtBusinessUnitName.TabIndex = 186;
            this.txtBusinessUnitName.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.DimGray;
            this.label22.Location = new System.Drawing.Point(43, 204);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(90, 16);
            this.label22.TabIndex = 187;
            this.label22.Text = "Business Unit";
            // 
            // cboCorporation
            // 
            this.cboCorporation.BackColor = System.Drawing.Color.Transparent;
            this.cboCorporation.BorderRadius = 10;
            this.cboCorporation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCorporation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCorporation.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(141)))));
            this.cboCorporation.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(141)))));
            this.cboCorporation.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCorporation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboCorporation.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(141)))));
            this.cboCorporation.ItemHeight = 30;
            this.cboCorporation.Location = new System.Drawing.Point(316, 147);
            this.cboCorporation.Name = "cboCorporation";
            this.cboCorporation.Size = new System.Drawing.Size(322, 36);
            this.cboCorporation.TabIndex = 190;
            this.cboCorporation.TextOffset = new System.Drawing.Point(10, 0);
            this.cboCorporation.SelectedIndexChanged += new System.EventHandler(this.cboCorporation_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(43, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 189;
            this.label1.Text = "Corporation";
            // 
            // numtxtBusinessUnitCode
            // 
            this.numtxtBusinessUnitCode.BackColor = System.Drawing.Color.Transparent;
            this.numtxtBusinessUnitCode.BorderRadius = 5;
            this.numtxtBusinessUnitCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numtxtBusinessUnitCode.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numtxtBusinessUnitCode.ForeColor = System.Drawing.Color.DimGray;
            this.numtxtBusinessUnitCode.Location = new System.Drawing.Point(200, 191);
            this.numtxtBusinessUnitCode.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numtxtBusinessUnitCode.Name = "numtxtBusinessUnitCode";
            this.numtxtBusinessUnitCode.Size = new System.Drawing.Size(102, 35);
            this.numtxtBusinessUnitCode.TabIndex = 192;
            this.numtxtBusinessUnitCode.TextOffset = new System.Drawing.Point(5, 0);
            this.numtxtBusinessUnitCode.UpDownButtonFillColor = System.Drawing.Color.White;
            // 
            // txtBusinessCategoryCode
            // 
            this.txtBusinessCategoryCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(226)))));
            this.txtBusinessCategoryCode.BorderRadius = 5;
            this.txtBusinessCategoryCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBusinessCategoryCode.DefaultText = "";
            this.txtBusinessCategoryCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBusinessCategoryCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBusinessCategoryCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBusinessCategoryCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBusinessCategoryCode.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.txtBusinessCategoryCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(150)))), ((int)(((byte)(141)))));
            this.txtBusinessCategoryCode.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtBusinessCategoryCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBusinessCategoryCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(150)))), ((int)(((byte)(141)))));
            this.txtBusinessCategoryCode.Location = new System.Drawing.Point(200, 104);
            this.txtBusinessCategoryCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBusinessCategoryCode.Name = "txtBusinessCategoryCode";
            this.txtBusinessCategoryCode.PasswordChar = '\0';
            this.txtBusinessCategoryCode.PlaceholderText = "";
            this.txtBusinessCategoryCode.ReadOnly = true;
            this.txtBusinessCategoryCode.SelectedText = "";
            this.txtBusinessCategoryCode.Size = new System.Drawing.Size(102, 33);
            this.txtBusinessCategoryCode.TabIndex = 193;
            this.txtBusinessCategoryCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBusinessCategoryCode.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // txtCorporationCode
            // 
            this.txtCorporationCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(226)))));
            this.txtCorporationCode.BorderRadius = 5;
            this.txtCorporationCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCorporationCode.DefaultText = "";
            this.txtCorporationCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCorporationCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCorporationCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCorporationCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCorporationCode.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.txtCorporationCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(150)))), ((int)(((byte)(141)))));
            this.txtCorporationCode.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtCorporationCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCorporationCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(150)))), ((int)(((byte)(141)))));
            this.txtCorporationCode.Location = new System.Drawing.Point(200, 148);
            this.txtCorporationCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCorporationCode.Name = "txtCorporationCode";
            this.txtCorporationCode.PasswordChar = '\0';
            this.txtCorporationCode.PlaceholderText = "";
            this.txtCorporationCode.ReadOnly = true;
            this.txtCorporationCode.SelectedText = "";
            this.txtCorporationCode.Size = new System.Drawing.Size(102, 33);
            this.txtCorporationCode.TabIndex = 194;
            this.txtCorporationCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCorporationCode.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(74)))), ((int)(((byte)(20)))));
            this.label2.Location = new System.Drawing.Point(168, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 19);
            this.label2.TabIndex = 208;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(43, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 16);
            this.label3.TabIndex = 209;
            this.label3.Text = "TIN";
            // 
            // txtTIN
            // 
            this.txtTIN.BorderRadius = 5;
            this.txtTIN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTIN.DefaultText = "";
            this.txtTIN.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTIN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTIN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTIN.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTIN.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(150)))), ((int)(((byte)(141)))));
            this.txtTIN.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtTIN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTIN.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(150)))), ((int)(((byte)(141)))));
            this.txtTIN.Location = new System.Drawing.Point(200, 236);
            this.txtTIN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTIN.Name = "txtTIN";
            this.txtTIN.PasswordChar = '\0';
            this.txtTIN.PlaceholderText = "TIN";
            this.txtTIN.SelectedText = "";
            this.txtTIN.Size = new System.Drawing.Size(438, 33);
            this.txtTIN.TabIndex = 210;
            this.txtTIN.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // txtAddress
            // 
            this.txtAddress.BorderRadius = 5;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(150)))), ((int)(((byte)(141)))));
            this.txtAddress.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(150)))), ((int)(((byte)(141)))));
            this.txtAddress.Location = new System.Drawing.Point(200, 279);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.PlaceholderText = "Address";
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(438, 84);
            this.txtAddress.TabIndex = 212;
            this.txtAddress.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(43, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 211;
            this.label4.Text = "Address";
            // 
            // dtpDateOpened
            // 
            this.dtpDateOpened.BackColor = System.Drawing.Color.Transparent;
            this.dtpDateOpened.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(141)))));
            this.dtpDateOpened.BorderRadius = 5;
            this.dtpDateOpened.BorderThickness = 1;
            this.dtpDateOpened.Checked = true;
            this.dtpDateOpened.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(141)))));
            this.dtpDateOpened.FocusedColor = System.Drawing.Color.White;
            this.dtpDateOpened.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateOpened.ForeColor = System.Drawing.Color.White;
            this.dtpDateOpened.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOpened.Location = new System.Drawing.Point(199, 371);
            this.dtpDateOpened.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDateOpened.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDateOpened.Name = "dtpDateOpened";
            this.dtpDateOpened.Size = new System.Drawing.Size(438, 33);
            this.dtpDateOpened.TabIndex = 213;
            this.dtpDateOpened.Value = new System.DateTime(2022, 9, 18, 19, 7, 49, 308);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(42, 381);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 16);
            this.label5.TabIndex = 214;
            this.label5.Text = "Date Opened";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(74)))), ((int)(((byte)(20)))));
            this.label6.Location = new System.Drawing.Point(127, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 19);
            this.label6.TabIndex = 215;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(74)))), ((int)(((byte)(20)))));
            this.label7.Location = new System.Drawing.Point(132, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 19);
            this.label7.TabIndex = 216;
            this.label7.Text = "*";
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 12;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.DarkGray;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // frmSettings_BusinessUnit_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(682, 538);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDateOpened);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTIN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCorporationCode);
            this.Controls.Add(this.txtBusinessCategoryCode);
            this.Controls.Add(this.numtxtBusinessUnitCode);
            this.Controls.Add(this.cboCorporation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBusinessUnitName);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.cboBusinessCategory);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.guna2PanelBottom);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSettings_BusinessUnit_New";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSettings_BusinessUnit_New";
            this.Load += new System.EventHandler(this.frmSettings_BusinessUnit_New_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.guna2PanelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numtxtBusinessUnitCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Zeroit.Framework.Transitions.SmoothTransitions.ZeroitSmoothAnimator zeroitSmoothAnimator1;
        private Guna.UI2.WinForms.Guna2Panel guna2PanelBottom;
        private Guna.UI2.WinForms.Guna2GradientButton btnSave;
        private Guna.UI2.WinForms.Guna2GradientButton btnClose;
        private Guna.UI2.WinForms.Guna2Panel panelTitle;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2ComboBox cboBusinessCategory;
        private System.Windows.Forms.Label label24;
        private Guna.UI2.WinForms.Guna2TextBox txtBusinessUnitName;
        private System.Windows.Forms.Label label22;
        private Guna.UI2.WinForms.Guna2ComboBox cboCorporation;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2NumericUpDown numtxtBusinessUnitCode;
        private Guna.UI2.WinForms.Guna2TextBox txtBusinessCategoryCode;
        private Guna.UI2.WinForms.Guna2TextBox txtCorporationCode;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtTIN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDateOpened;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}