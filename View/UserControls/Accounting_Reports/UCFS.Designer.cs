namespace EXIN
{
    partial class UCFS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            Guna.UI.Animation.Animation animation1 = new Guna.UI.Animation.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCSOA));
            this.pnlContainer = new Guna.UI.WinForms.GunaPanel();
            this.grpFilter = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnApplyFilter = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI.WinForms.GunaImageButton();
            this.grpNormalCV = new System.Windows.Forms.GroupBox();
            this.gunaLabel4 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.dtpTo = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpFrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.cmbSupplier = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtChartofAccount = new Guna.UI.WinForms.GunaLabel();
            this.cmbCOA = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.btnResetBusUnit = new Guna.UI2.WinForms.Guna2CircleButton();
            this.cmbBusUnit = new Guna.UI2.WinForms.Guna2ComboBox();
            this.prgPreloader = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            this.dgvSOA = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.txtTotal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnFilter = new Guna.UI.WinForms.GunaImageButton();
            this.btnExcel = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.gunaHScrollBar1 = new Guna.UI.WinForms.GunaHScrollBar();
            this.gunaTransition1 = new Guna.UI.WinForms.GunaTransition(this.components);
            this.pnlContainer.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.grpNormalCV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSOA)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.grpFilter);
            this.pnlContainer.Controls.Add(this.prgPreloader);
            this.pnlContainer.Controls.Add(this.dgvSOA);
            this.pnlContainer.Controls.Add(this.guna2GradientPanel1);
            this.pnlContainer.Controls.Add(this.btnFilter);
            this.pnlContainer.Controls.Add(this.btnExcel);
            this.pnlContainer.Controls.Add(this.txtSearch);
            this.pnlContainer.Controls.Add(this.gunaHScrollBar1);
            this.gunaTransition1.SetDecoration(this.pnlContainer, Guna.UI.Animation.DecorationType.None);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1089, 676);
            this.pnlContainer.TabIndex = 5;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.btnApplyFilter);
            this.grpFilter.Controls.Add(this.btnClose);
            this.grpFilter.Controls.Add(this.grpNormalCV);
            this.grpFilter.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(84)))), ((int)(((byte)(70)))));
            this.gunaTransition1.SetDecoration(this.grpFilter, Guna.UI.Animation.DecorationType.None);
            this.grpFilter.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFilter.ForeColor = System.Drawing.Color.White;
            this.grpFilter.Location = new System.Drawing.Point(0, 0);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.ShadowDecoration.Parent = this.grpFilter;
            this.grpFilter.Size = new System.Drawing.Size(1089, 214);
            this.grpFilter.TabIndex = 61;
            this.grpFilter.Text = "Filter";
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.AutoRoundedCorners = true;
            this.btnApplyFilter.BackColor = System.Drawing.Color.Transparent;
            this.btnApplyFilter.BorderRadius = 12;
            this.btnApplyFilter.CheckedState.Parent = this.btnApplyFilter;
            this.btnApplyFilter.CustomImages.Parent = this.btnApplyFilter;
            this.gunaTransition1.SetDecoration(this.btnApplyFilter, Guna.UI.Animation.DecorationType.None);
            this.btnApplyFilter.DisabledState.Parent = this.btnApplyFilter;
            this.btnApplyFilter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(84)))), ((int)(((byte)(70)))));
            this.btnApplyFilter.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyFilter.ForeColor = System.Drawing.Color.White;
            this.btnApplyFilter.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(241)))), ((int)(((byte)(200)))));
            this.btnApplyFilter.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnApplyFilter.HoverState.Parent = this.btnApplyFilter;
            this.btnApplyFilter.Location = new System.Drawing.Point(1000, 182);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.ShadowDecoration.BorderRadius = 19;
            this.btnApplyFilter.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.btnApplyFilter.ShadowDecoration.Enabled = true;
            this.btnApplyFilter.ShadowDecoration.Parent = this.btnApplyFilter;
            this.btnApplyFilter.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.btnApplyFilter.Size = new System.Drawing.Size(56, 26);
            this.btnApplyFilter.TabIndex = 12;
            this.btnApplyFilter.Text = "Apply";
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransition1.SetDecoration(this.btnClose, Guna.UI.Animation.DecorationType.None);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageSize = new System.Drawing.Size(15, 15);
            this.btnClose.Location = new System.Drawing.Point(1066, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.OnHoverImage = null;
            this.btnClose.OnHoverImageOffset = new System.Drawing.Point(0, -2);
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 28;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // grpNormalCV
            // 
            this.grpNormalCV.BackColor = System.Drawing.Color.Transparent;
            this.grpNormalCV.Controls.Add(this.gunaLabel4);
            this.grpNormalCV.Controls.Add(this.gunaLabel3);
            this.grpNormalCV.Controls.Add(this.dtpTo);
            this.grpNormalCV.Controls.Add(this.dtpFrom);
            this.grpNormalCV.Controls.Add(this.gunaLabel2);
            this.grpNormalCV.Controls.Add(this.cmbSupplier);
            this.grpNormalCV.Controls.Add(this.txtChartofAccount);
            this.grpNormalCV.Controls.Add(this.cmbCOA);
            this.grpNormalCV.Controls.Add(this.gunaLabel1);
            this.grpNormalCV.Controls.Add(this.btnResetBusUnit);
            this.grpNormalCV.Controls.Add(this.cmbBusUnit);
            this.gunaTransition1.SetDecoration(this.grpNormalCV, Guna.UI.Animation.DecorationType.None);
            this.grpNormalCV.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpNormalCV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(84)))), ((int)(((byte)(70)))));
            this.grpNormalCV.Location = new System.Drawing.Point(40, 55);
            this.grpNormalCV.Name = "grpNormalCV";
            this.grpNormalCV.Size = new System.Drawing.Size(1014, 121);
            this.grpNormalCV.TabIndex = 29;
            this.grpNormalCV.TabStop = false;
            this.grpNormalCV.Text = "Select Filter";
            // 
            // gunaLabel4
            // 
            this.gunaLabel4.AutoSize = true;
            this.gunaTransition1.SetDecoration(this.gunaLabel4, Guna.UI.Animation.DecorationType.None);
            this.gunaLabel4.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel4.ForeColor = System.Drawing.Color.Black;
            this.gunaLabel4.Location = new System.Drawing.Point(805, 77);
            this.gunaLabel4.Name = "gunaLabel4";
            this.gunaLabel4.Size = new System.Drawing.Size(22, 15);
            this.gunaLabel4.TabIndex = 50;
            this.gunaLabel4.Text = "To";
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaTransition1.SetDecoration(this.gunaLabel3, Guna.UI.Animation.DecorationType.None);
            this.gunaLabel3.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel3.ForeColor = System.Drawing.Color.Black;
            this.gunaLabel3.Location = new System.Drawing.Point(805, 28);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(37, 15);
            this.gunaLabel3.TabIndex = 49;
            this.gunaLabel3.Text = "From";
            // 
            // dtpTo
            // 
            this.dtpTo.AutoRoundedCorners = true;
            this.dtpTo.BackColor = System.Drawing.Color.Transparent;
            this.dtpTo.BorderRadius = 12;
            this.dtpTo.CheckedState.Parent = this.dtpTo;
            this.gunaTransition1.SetDecoration(this.dtpTo, Guna.UI.Animation.DecorationType.None);
            this.dtpTo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(84)))), ((int)(((byte)(70)))));
            this.dtpTo.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9F);
            this.dtpTo.ForeColor = System.Drawing.Color.White;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.HoverState.Parent = this.dtpTo;
            this.dtpTo.Location = new System.Drawing.Point(879, 72);
            this.dtpTo.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTo.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShadowDecoration.BorderRadius = 7;
            this.dtpTo.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.dtpTo.ShadowDecoration.Depth = 7;
            this.dtpTo.ShadowDecoration.Enabled = true;
            this.dtpTo.ShadowDecoration.Parent = this.dtpTo;
            this.dtpTo.Size = new System.Drawing.Size(108, 26);
            this.dtpTo.TabIndex = 48;
            this.dtpTo.Value = new System.DateTime(2022, 5, 7, 11, 13, 16, 0);
            // 
            // dtpFrom
            // 
            this.dtpFrom.AutoRoundedCorners = true;
            this.dtpFrom.BackColor = System.Drawing.Color.Transparent;
            this.dtpFrom.BorderRadius = 12;
            this.dtpFrom.CheckedState.Parent = this.dtpFrom;
            this.gunaTransition1.SetDecoration(this.dtpFrom, Guna.UI.Animation.DecorationType.None);
            this.dtpFrom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(84)))), ((int)(((byte)(70)))));
            this.dtpFrom.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9F);
            this.dtpFrom.ForeColor = System.Drawing.Color.White;
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.HoverState.Parent = this.dtpFrom;
            this.dtpFrom.Location = new System.Drawing.Point(879, 23);
            this.dtpFrom.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFrom.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShadowDecoration.BorderRadius = 7;
            this.dtpFrom.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.dtpFrom.ShadowDecoration.Depth = 7;
            this.dtpFrom.ShadowDecoration.Enabled = true;
            this.dtpFrom.ShadowDecoration.Parent = this.dtpFrom;
            this.dtpFrom.Size = new System.Drawing.Size(108, 26);
            this.dtpFrom.TabIndex = 47;
            this.dtpFrom.Value = new System.DateTime(2022, 5, 7, 11, 13, 16, 0);
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaTransition1.SetDecoration(this.gunaLabel2, Guna.UI.Animation.DecorationType.None);
            this.gunaLabel2.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel2.ForeColor = System.Drawing.Color.Black;
            this.gunaLabel2.Location = new System.Drawing.Point(40, 77);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(54, 15);
            this.gunaLabel2.TabIndex = 44;
            this.gunaLabel2.Text = "Supplier";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.AutoRoundedCorners = true;
            this.cmbSupplier.BackColor = System.Drawing.Color.Transparent;
            this.cmbSupplier.BorderRadius = 12;
            this.gunaTransition1.SetDecoration(this.cmbSupplier, Guna.UI.Animation.DecorationType.None);
            this.cmbSupplier.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSupplier.DropDownHeight = 200;
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.cmbSupplier.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.cmbSupplier.FocusedState.Parent = this.cmbSupplier;
            this.cmbSupplier.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.cmbSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbSupplier.HoverState.Parent = this.cmbSupplier;
            this.cmbSupplier.IntegralHeight = false;
            this.cmbSupplier.ItemHeight = 20;
            this.cmbSupplier.ItemsAppearance.Parent = this.cmbSupplier;
            this.cmbSupplier.Location = new System.Drawing.Point(110, 72);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.ShadowDecoration.BorderRadius = 20;
            this.cmbSupplier.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.cmbSupplier.ShadowDecoration.Parent = this.cmbSupplier;
            this.cmbSupplier.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.cmbSupplier.Size = new System.Drawing.Size(280, 26);
            this.cmbSupplier.TabIndex = 43;
            this.cmbSupplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtChartofAccount
            // 
            this.txtChartofAccount.AutoSize = true;
            this.gunaTransition1.SetDecoration(this.txtChartofAccount, Guna.UI.Animation.DecorationType.None);
            this.txtChartofAccount.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChartofAccount.ForeColor = System.Drawing.Color.Black;
            this.txtChartofAccount.Location = new System.Drawing.Point(390, 28);
            this.txtChartofAccount.Name = "txtChartofAccount";
            this.txtChartofAccount.Size = new System.Drawing.Size(57, 15);
            this.txtChartofAccount.TabIndex = 42;
            this.txtChartofAccount.Text = "Account";
            // 
            // cmbCOA
            // 
            this.cmbCOA.AutoRoundedCorners = true;
            this.cmbCOA.BackColor = System.Drawing.Color.Transparent;
            this.cmbCOA.BorderRadius = 12;
            this.gunaTransition1.SetDecoration(this.cmbCOA, Guna.UI.Animation.DecorationType.None);
            this.cmbCOA.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCOA.DropDownHeight = 200;
            this.cmbCOA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCOA.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.cmbCOA.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.cmbCOA.FocusedState.Parent = this.cmbCOA;
            this.cmbCOA.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.cmbCOA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbCOA.HoverState.Parent = this.cmbCOA;
            this.cmbCOA.IntegralHeight = false;
            this.cmbCOA.ItemHeight = 20;
            this.cmbCOA.ItemsAppearance.Parent = this.cmbCOA;
            this.cmbCOA.Location = new System.Drawing.Point(460, 23);
            this.cmbCOA.Name = "cmbCOA";
            this.cmbCOA.ShadowDecoration.BorderRadius = 20;
            this.cmbCOA.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.cmbCOA.ShadowDecoration.Parent = this.cmbCOA;
            this.cmbCOA.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.cmbCOA.Size = new System.Drawing.Size(299, 26);
            this.cmbCOA.TabIndex = 41;
            this.cmbCOA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaTransition1.SetDecoration(this.gunaLabel1, Guna.UI.Animation.DecorationType.None);
            this.gunaLabel1.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.ForeColor = System.Drawing.Color.Black;
            this.gunaLabel1.Location = new System.Drawing.Point(40, 28);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(50, 15);
            this.gunaLabel1.TabIndex = 38;
            this.gunaLabel1.Text = "BusUnit";
            // 
            // btnResetBusUnit
            // 
            this.btnResetBusUnit.CheckedState.Parent = this.btnResetBusUnit;
            this.btnResetBusUnit.CustomImages.Parent = this.btnResetBusUnit;
            this.gunaTransition1.SetDecoration(this.btnResetBusUnit, Guna.UI.Animation.DecorationType.None);
            this.btnResetBusUnit.DisabledState.Parent = this.btnResetBusUnit;
            this.btnResetBusUnit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(84)))), ((int)(((byte)(70)))));
            this.btnResetBusUnit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnResetBusUnit.ForeColor = System.Drawing.Color.White;
            this.btnResetBusUnit.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(241)))), ((int)(((byte)(200)))));
            this.btnResetBusUnit.HoverState.Parent = this.btnResetBusUnit;
            this.btnResetBusUnit.Image = ((System.Drawing.Image)(resources.GetObject("btnResetBusUnit.Image")));
            this.btnResetBusUnit.ImageSize = new System.Drawing.Size(10, 10);
            this.btnResetBusUnit.Location = new System.Drawing.Point(12, 25);
            this.btnResetBusUnit.Name = "btnResetBusUnit";
            this.btnResetBusUnit.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnResetBusUnit.ShadowDecoration.Parent = this.btnResetBusUnit;
            this.btnResetBusUnit.Size = new System.Drawing.Size(20, 20);
            this.btnResetBusUnit.TabIndex = 37;
            this.btnResetBusUnit.Click += new System.EventHandler(this.btnResetBusUnit_Click);
            // 
            // cmbBusUnit
            // 
            this.cmbBusUnit.AutoRoundedCorners = true;
            this.cmbBusUnit.BackColor = System.Drawing.Color.Transparent;
            this.cmbBusUnit.BorderRadius = 12;
            this.gunaTransition1.SetDecoration(this.cmbBusUnit, Guna.UI.Animation.DecorationType.None);
            this.cmbBusUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBusUnit.DropDownHeight = 200;
            this.cmbBusUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusUnit.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.cmbBusUnit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.cmbBusUnit.FocusedState.Parent = this.cmbBusUnit;
            this.cmbBusUnit.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBusUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbBusUnit.HoverState.Parent = this.cmbBusUnit;
            this.cmbBusUnit.IntegralHeight = false;
            this.cmbBusUnit.ItemHeight = 20;
            this.cmbBusUnit.ItemsAppearance.Parent = this.cmbBusUnit;
            this.cmbBusUnit.Location = new System.Drawing.Point(110, 23);
            this.cmbBusUnit.Name = "cmbBusUnit";
            this.cmbBusUnit.ShadowDecoration.BorderRadius = 20;
            this.cmbBusUnit.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.cmbBusUnit.ShadowDecoration.Parent = this.cmbBusUnit;
            this.cmbBusUnit.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.cmbBusUnit.Size = new System.Drawing.Size(253, 26);
            this.cmbBusUnit.TabIndex = 31;
            this.cmbBusUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cmbBusUnit.SelectedIndexChanged += new System.EventHandler(this.cmbBusUnit_SelectedIndexChanged);
            // 
            // prgPreloader
            // 
            this.prgPreloader.AutoStart = true;
            this.gunaTransition1.SetDecoration(this.prgPreloader, Guna.UI.Animation.DecorationType.None);
            this.prgPreloader.Location = new System.Drawing.Point(88, 605);
            this.prgPreloader.Name = "prgPreloader";
            this.prgPreloader.ProgressColor = System.Drawing.Color.Teal;
            this.prgPreloader.ShadowDecoration.Parent = this.prgPreloader;
            this.prgPreloader.Size = new System.Drawing.Size(66, 54);
            this.prgPreloader.TabIndex = 94;
            // 
            // dgvSOA
            // 
            this.dgvSOA.AllowDrop = true;
            this.dgvSOA.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(254)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSOA.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSOA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvSOA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvSOA.BackgroundColor = System.Drawing.Color.White;
            this.dgvSOA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSOA.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSOA.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSOA.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSOA.ColumnHeadersHeight = 30;
            this.gunaTransition1.SetDecoration(this.dgvSOA, Guna.UI.Animation.DecorationType.None);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(254)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSOA.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSOA.EnableHeadersVisualStyles = false;
            this.dgvSOA.GridColor = System.Drawing.Color.LightGray;
            this.dgvSOA.Location = new System.Drawing.Point(88, 101);
            this.dgvSOA.Name = "dgvSOA";
            this.dgvSOA.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSOA.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSOA.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSOA.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSOA.RowTemplate.Height = 30;
            this.dgvSOA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSOA.Size = new System.Drawing.Size(915, 487);
            this.dgvSOA.TabIndex = 91;
            this.dgvSOA.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSOA.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSOA.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvSOA.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSOA.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSOA.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvSOA.ThemeStyle.GridColor = System.Drawing.Color.LightGray;
            this.dgvSOA.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvSOA.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSOA.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSOA.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSOA.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvSOA.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvSOA.ThemeStyle.ReadOnly = false;
            this.dgvSOA.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSOA.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSOA.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSOA.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSOA.ThemeStyle.RowsStyle.Height = 30;
            this.dgvSOA.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSOA.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.txtTotal);
            this.gunaTransition1.SetDecoration(this.guna2GradientPanel1, Guna.UI.Animation.DecorationType.None);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(208)))), ((int)(((byte)(199)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(84)))), ((int)(((byte)(122)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(884, 15);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.guna2GradientPanel1.ShadowDecoration.Enabled = true;
            this.guna2GradientPanel1.ShadowDecoration.Parent = this.guna2GradientPanel1;
            this.guna2GradientPanel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.guna2GradientPanel1.Size = new System.Drawing.Size(170, 55);
            this.guna2GradientPanel1.TabIndex = 65;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransition1.SetDecoration(this.txtTotal, Guna.UI.Animation.DecorationType.None);
            this.txtTotal.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.White;
            this.txtTotal.Location = new System.Drawing.Point(35, 15);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(47, 20);
            this.txtTotal.TabIndex = 0;
            this.txtTotal.Text = "00.00";
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransition1.SetDecoration(this.btnFilter, Guna.UI.Animation.DecorationType.None);
            this.btnFilter.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.ImageSize = new System.Drawing.Size(25, 25);
            this.btnFilter.Location = new System.Drawing.Point(549, 30);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.OnHoverImage = null;
            this.btnFilter.OnHoverImageOffset = new System.Drawing.Point(0, -2);
            this.btnFilter.Size = new System.Drawing.Size(36, 38);
            this.btnFilter.TabIndex = 62;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnExcel.BorderRadius = 5;
            this.btnExcel.CheckedState.Parent = this.btnExcel;
            this.btnExcel.CustomImages.Parent = this.btnExcel;
            this.gunaTransition1.SetDecoration(this.btnExcel, Guna.UI.Animation.DecorationType.None);
            this.btnExcel.DisabledState.Parent = this.btnExcel;
            this.btnExcel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(84)))), ((int)(((byte)(70)))));
            this.btnExcel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(241)))), ((int)(((byte)(200)))));
            this.btnExcel.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            this.btnExcel.HoverState.Parent = this.btnExcel;
            this.btnExcel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnExcel.ImageOffset = new System.Drawing.Point(5, 0);
            this.btnExcel.ImageSize = new System.Drawing.Size(15, 15);
            this.btnExcel.Location = new System.Drawing.Point(981, 617);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.ShadowDecoration.BorderRadius = 19;
            this.btnExcel.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.btnExcel.ShadowDecoration.Enabled = true;
            this.btnExcel.ShadowDecoration.Parent = this.btnExcel;
            this.btnExcel.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.btnExcel.Size = new System.Drawing.Size(57, 28);
            this.btnExcel.TabIndex = 30;
            this.btnExcel.Text = "Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AutoRoundedCorners = true;
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderColor = System.Drawing.Color.White;
            this.txtSearch.BorderRadius = 18;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gunaTransition1.SetDecoration(this.txtSearch, Guna.UI.Animation.DecorationType.None);
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.Parent = this.txtSearch;
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(135)))), ((int)(((byte)(100)))));
            this.txtSearch.FocusedState.Parent = this.txtSearch;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(135)))), ((int)(((byte)(100)))));
            this.txtSearch.HoverState.Parent = this.txtSearch;
            this.txtSearch.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtSearch.IconLeft")));
            this.txtSearch.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.txtSearch.Location = new System.Drawing.Point(44, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "SEARCH";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.BorderRadius = 19;
            this.txtSearch.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.txtSearch.ShadowDecoration.Enabled = true;
            this.txtSearch.ShadowDecoration.Parent = this.txtSearch;
            this.txtSearch.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.txtSearch.Size = new System.Drawing.Size(495, 38);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // gunaHScrollBar1
            // 
            this.gunaHScrollBar1.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransition1.SetDecoration(this.gunaHScrollBar1, Guna.UI.Animation.DecorationType.None);
            this.gunaHScrollBar1.LargeChange = 10;
            this.gunaHScrollBar1.Location = new System.Drawing.Point(752, 631);
            this.gunaHScrollBar1.Maximum = 100;
            this.gunaHScrollBar1.Name = "gunaHScrollBar1";
            this.gunaHScrollBar1.ScrollIdleColor = System.Drawing.Color.Silver;
            this.gunaHScrollBar1.Size = new System.Drawing.Size(251, 14);
            this.gunaHScrollBar1.TabIndex = 59;
            this.gunaHScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(84)))), ((int)(((byte)(70)))));
            this.gunaHScrollBar1.ThumbHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(135)))), ((int)(((byte)(100)))));
            this.gunaHScrollBar1.ThumbPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(135)))), ((int)(((byte)(100)))));
            // 
            // gunaTransition1
            // 
            this.gunaTransition1.AnimationType = Guna.UI.Animation.AnimationType.VertSlide;
            this.gunaTransition1.Cursor = null;
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
            this.gunaTransition1.DefaultAnimation = animation1;
            // 
            // UCSOA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContainer);
            this.gunaTransition1.SetDecoration(this, Guna.UI.Animation.DecorationType.None);
            this.Name = "UCSOA";
            this.Size = new System.Drawing.Size(1089, 676);
            this.Load += new System.EventHandler(this.UCSOA_Load);
            this.pnlContainer.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpNormalCV.ResumeLayout(false);
            this.grpNormalCV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSOA)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI.WinForms.GunaPanel pnlContainer;
        private Guna.UI.WinForms.GunaHScrollBar gunaHScrollBar1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnExcel;
        private Guna.UI2.WinForms.Guna2GroupBox grpFilter;
        private Guna.UI2.WinForms.Guna2Button btnApplyFilter;
        private Guna.UI.WinForms.GunaImageButton btnClose;
        private System.Windows.Forms.GroupBox grpNormalCV;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI2.WinForms.Guna2CircleButton btnResetBusUnit;
        private Guna.UI2.WinForms.Guna2ComboBox cmbBusUnit;
        private Guna.UI.WinForms.GunaImageButton btnFilter;
        private Guna.UI.WinForms.GunaLabel txtChartofAccount;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCOA;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtTotal;
        private Guna.UI.WinForms.GunaTransition gunaTransition1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSOA;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSupplier;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFrom;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTo;
        private Guna.UI.WinForms.GunaLabel gunaLabel4;
        private Guna.UI.WinForms.GunaLabel gunaLabel3;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator prgPreloader;
    }
}
