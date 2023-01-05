namespace EXIN
{
    partial class UCARAging
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            Guna.UI2.AnimatorNS.Animation animation1 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCARAging));
            this.pnlContainer = new Guna.UI.WinForms.GunaPanel();
            this.prgPreloader = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            this.pnlFilter = new Guna.UI2.WinForms.Guna2Panel();
            this.btnFilter = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2VSeparator2 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.dtpToDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpFromDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnFilterReset = new Guna.UI2.WinForms.Guna2CircleButton();
            this.cmbfltrBusUnit = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gunaLabel6 = new Guna.UI.WinForms.GunaLabel();
            this.cmbClearingStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gunaLabel7 = new Guna.UI.WinForms.GunaLabel();
            this.txtClearingStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtBranchName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnShowFilter = new Guna.UI.WinForms.GunaImageButton();
            this.dgvARAging = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnCheckUncheck = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnBatchDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnExcel = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Transition1 = new Guna.UI2.WinForms.Guna2Transition();
            this.lblTransId = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlContainer.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.guna2GradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvARAging)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.prgPreloader);
            this.pnlContainer.Controls.Add(this.pnlFilter);
            this.pnlContainer.Controls.Add(this.txtClearingStatus);
            this.pnlContainer.Controls.Add(this.txtBranchName);
            this.pnlContainer.Controls.Add(this.btnShowFilter);
            this.pnlContainer.Controls.Add(this.dgvARAging);
            this.pnlContainer.Controls.Add(this.btnCancel);
            this.pnlContainer.Controls.Add(this.btnCheckUncheck);
            this.pnlContainer.Controls.Add(this.btnBatchDelete);
            this.pnlContainer.Controls.Add(this.btnExcel);
            this.guna2Transition1.SetDecoration(this.pnlContainer, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1089, 676);
            this.pnlContainer.TabIndex = 5;
            // 
            // prgPreloader
            // 
            this.prgPreloader.AutoStart = true;
            this.guna2Transition1.SetDecoration(this.prgPreloader, Guna.UI2.AnimatorNS.DecorationType.None);
            this.prgPreloader.Location = new System.Drawing.Point(1023, 0);
            this.prgPreloader.Name = "prgPreloader";
            this.prgPreloader.ProgressColor = System.Drawing.Color.Teal;
            this.prgPreloader.ShadowDecoration.Parent = this.prgPreloader;
            this.prgPreloader.Size = new System.Drawing.Size(66, 54);
            this.prgPreloader.TabIndex = 93;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Controls.Add(this.guna2GradientPanel2);
            this.pnlFilter.Controls.Add(this.cmbfltrBusUnit);
            this.pnlFilter.Controls.Add(this.gunaLabel6);
            this.pnlFilter.Controls.Add(this.cmbClearingStatus);
            this.pnlFilter.Controls.Add(this.gunaLabel7);
            this.pnlFilter.CustomizableEdges.BottomLeft = false;
            this.pnlFilter.CustomizableEdges.BottomRight = false;
            this.guna2Transition1.SetDecoration(this.pnlFilter, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pnlFilter.Location = new System.Drawing.Point(3, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.pnlFilter.ShadowDecoration.Enabled = true;
            this.pnlFilter.ShadowDecoration.Parent = this.pnlFilter;
            this.pnlFilter.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.pnlFilter.Size = new System.Drawing.Size(315, 233);
            this.pnlFilter.TabIndex = 82;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.Transparent;
            this.btnFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(201)))), ((int)(((byte)(195)))));
            this.btnFilter.BorderRadius = 5;
            this.btnFilter.BorderThickness = 1;
            this.btnFilter.CheckedState.Parent = this.btnFilter;
            this.btnFilter.CustomImages.Parent = this.btnFilter;
            this.guna2Transition1.SetDecoration(this.btnFilter, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnFilter.DisabledState.Parent = this.btnFilter;
            this.btnFilter.FillColor = System.Drawing.Color.White;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(201)))), ((int)(((byte)(195)))));
            this.btnFilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.btnFilter.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(84)))), ((int)(((byte)(70)))));
            this.btnFilter.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnFilter.HoverState.Parent = this.btnFilter;
            this.btnFilter.Location = new System.Drawing.Point(229, 190);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.btnFilter.ShadowDecoration.Parent = this.btnFilter;
            this.btnFilter.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.btnFilter.Size = new System.Drawing.Size(66, 36);
            this.btnFilter.TabIndex = 81;
            this.btnFilter.Text = "Apply";
            this.btnFilter.Click += new System.EventHandler(this.btnFilterAgingReport_Click);
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel2.Controls.Add(this.guna2VSeparator2);
            this.guna2GradientPanel2.Controls.Add(this.dtpToDate);
            this.guna2GradientPanel2.Controls.Add(this.dtpFromDate);
            this.guna2GradientPanel2.Controls.Add(this.guna2HtmlLabel2);
            this.guna2GradientPanel2.Controls.Add(this.guna2HtmlLabel1);
            this.guna2GradientPanel2.Controls.Add(this.btnFilterReset);
            this.guna2Transition1.SetDecoration(this.guna2GradientPanel2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(84)))), ((int)(((byte)(70)))));
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.guna2GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.guna2GradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.guna2GradientPanel2.ShadowDecoration.Enabled = true;
            this.guna2GradientPanel2.ShadowDecoration.Parent = this.guna2GradientPanel2;
            this.guna2GradientPanel2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.guna2GradientPanel2.Size = new System.Drawing.Size(315, 32);
            this.guna2GradientPanel2.TabIndex = 74;
            // 
            // guna2VSeparator2
            // 
            this.guna2Transition1.SetDecoration(this.guna2VSeparator2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2VSeparator2.Location = new System.Drawing.Point(240, 7);
            this.guna2VSeparator2.Name = "guna2VSeparator2";
            this.guna2VSeparator2.Size = new System.Drawing.Size(12, 18);
            this.guna2VSeparator2.TabIndex = 90;
            // 
            // dtpToDate
            // 
            this.dtpToDate.AutoRoundedCorners = true;
            this.dtpToDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(204)))), ((int)(((byte)(30)))));
            this.dtpToDate.BorderRadius = 12;
            this.dtpToDate.BorderThickness = 2;
            this.dtpToDate.CheckedState.Parent = this.dtpToDate;
            this.guna2Transition1.SetDecoration(this.dtpToDate, Guna.UI2.AnimatorNS.DecorationType.None);
            this.dtpToDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(31)))));
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(84)))), ((int)(((byte)(70)))));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpToDate.HoverState.Parent = this.dtpToDate;
            this.dtpToDate.Location = new System.Drawing.Point(280, 3);
            this.dtpToDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpToDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.ShadowDecoration.Parent = this.dtpToDate;
            this.dtpToDate.Size = new System.Drawing.Size(32, 27);
            this.dtpToDate.TabIndex = 89;
            this.dtpToDate.Value = new System.DateTime(2021, 9, 2, 17, 4, 40, 977);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.AutoRoundedCorners = true;
            this.dtpFromDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(204)))), ((int)(((byte)(30)))));
            this.dtpFromDate.BorderRadius = 12;
            this.dtpFromDate.BorderThickness = 2;
            this.dtpFromDate.CheckedState.Parent = this.dtpFromDate;
            this.guna2Transition1.SetDecoration(this.dtpFromDate, Guna.UI2.AnimatorNS.DecorationType.None);
            this.dtpFromDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(31)))));
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(84)))), ((int)(((byte)(70)))));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFromDate.HoverState.Parent = this.dtpFromDate;
            this.dtpFromDate.Location = new System.Drawing.Point(204, 3);
            this.dtpFromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.ShadowDecoration.Parent = this.dtpFromDate;
            this.dtpFromDate.Size = new System.Drawing.Size(32, 27);
            this.dtpFromDate.TabIndex = 88;
            this.dtpFromDate.Value = new System.DateTime(2021, 9, 2, 17, 4, 40, 977);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.guna2HtmlLabel2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(258, 7);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(19, 14);
            this.guna2HtmlLabel2.TabIndex = 87;
            this.guna2HtmlLabel2.Text = "To";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.guna2HtmlLabel1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(167, 7);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(32, 14);
            this.guna2HtmlLabel1.TabIndex = 86;
            this.guna2HtmlLabel1.Text = "From";
            // 
            // btnFilterReset
            // 
            this.btnFilterReset.CheckedState.Parent = this.btnFilterReset;
            this.btnFilterReset.CustomImages.Parent = this.btnFilterReset;
            this.guna2Transition1.SetDecoration(this.btnFilterReset, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnFilterReset.DisabledState.Parent = this.btnFilterReset;
            this.btnFilterReset.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(84)))), ((int)(((byte)(70)))));
            this.btnFilterReset.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFilterReset.ForeColor = System.Drawing.Color.White;
            this.btnFilterReset.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(241)))), ((int)(((byte)(200)))));
            this.btnFilterReset.HoverState.Parent = this.btnFilterReset;
            this.btnFilterReset.Image = ((System.Drawing.Image)(resources.GetObject("btnFilterReset.Image")));
            this.btnFilterReset.ImageSize = new System.Drawing.Size(10, 10);
            this.btnFilterReset.Location = new System.Drawing.Point(12, 3);
            this.btnFilterReset.Name = "btnFilterReset";
            this.btnFilterReset.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnFilterReset.ShadowDecoration.Parent = this.btnFilterReset;
            this.btnFilterReset.Size = new System.Drawing.Size(20, 20);
            this.btnFilterReset.TabIndex = 37;
            this.btnFilterReset.Click += new System.EventHandler(this.btnFilterReset_Click);
            // 
            // cmbfltrBusUnit
            // 
            this.cmbfltrBusUnit.AutoRoundedCorners = true;
            this.cmbfltrBusUnit.BackColor = System.Drawing.Color.Transparent;
            this.cmbfltrBusUnit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(201)))), ((int)(((byte)(195)))));
            this.cmbfltrBusUnit.BorderRadius = 17;
            this.guna2Transition1.SetDecoration(this.cmbfltrBusUnit, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cmbfltrBusUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbfltrBusUnit.DropDownHeight = 200;
            this.cmbfltrBusUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfltrBusUnit.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.cmbfltrBusUnit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.cmbfltrBusUnit.FocusedState.Parent = this.cmbfltrBusUnit;
            this.cmbfltrBusUnit.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbfltrBusUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbfltrBusUnit.HoverState.Parent = this.cmbfltrBusUnit;
            this.cmbfltrBusUnit.IntegralHeight = false;
            this.cmbfltrBusUnit.ItemHeight = 30;
            this.cmbfltrBusUnit.ItemsAppearance.Parent = this.cmbfltrBusUnit;
            this.cmbfltrBusUnit.Location = new System.Drawing.Point(36, 60);
            this.cmbfltrBusUnit.Name = "cmbfltrBusUnit";
            this.cmbfltrBusUnit.ShadowDecoration.BorderRadius = 20;
            this.cmbfltrBusUnit.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.cmbfltrBusUnit.ShadowDecoration.Parent = this.cmbfltrBusUnit;
            this.cmbfltrBusUnit.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.cmbfltrBusUnit.Size = new System.Drawing.Size(241, 36);
            this.cmbfltrBusUnit.TabIndex = 31;
            this.cmbfltrBusUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cmbfltrBusUnit.DropDown += new System.EventHandler(this.cmbfltrBusUnit_DropDown);
            // 
            // gunaLabel6
            // 
            this.gunaLabel6.AutoSize = true;
            this.guna2Transition1.SetDecoration(this.gunaLabel6, Guna.UI2.AnimatorNS.DecorationType.None);
            this.gunaLabel6.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel6.ForeColor = System.Drawing.Color.Black;
            this.gunaLabel6.Location = new System.Drawing.Point(33, 42);
            this.gunaLabel6.Name = "gunaLabel6";
            this.gunaLabel6.Size = new System.Drawing.Size(54, 15);
            this.gunaLabel6.TabIndex = 38;
            this.gunaLabel6.Text = "Bus Unit";
            // 
            // cmbClearingStatus
            // 
            this.cmbClearingStatus.AutoRoundedCorners = true;
            this.cmbClearingStatus.BackColor = System.Drawing.Color.Transparent;
            this.cmbClearingStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(201)))), ((int)(((byte)(195)))));
            this.cmbClearingStatus.BorderRadius = 17;
            this.guna2Transition1.SetDecoration(this.cmbClearingStatus, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cmbClearingStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbClearingStatus.DropDownHeight = 200;
            this.cmbClearingStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClearingStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.cmbClearingStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.cmbClearingStatus.FocusedState.Parent = this.cmbClearingStatus;
            this.cmbClearingStatus.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.cmbClearingStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbClearingStatus.HoverState.Parent = this.cmbClearingStatus;
            this.cmbClearingStatus.IntegralHeight = false;
            this.cmbClearingStatus.ItemHeight = 30;
            this.cmbClearingStatus.Items.AddRange(new object[] {
            "Cleared",
            "Uncleared"});
            this.cmbClearingStatus.ItemsAppearance.Parent = this.cmbClearingStatus;
            this.cmbClearingStatus.Location = new System.Drawing.Point(36, 138);
            this.cmbClearingStatus.Name = "cmbClearingStatus";
            this.cmbClearingStatus.ShadowDecoration.BorderRadius = 20;
            this.cmbClearingStatus.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.cmbClearingStatus.ShadowDecoration.Parent = this.cmbClearingStatus;
            this.cmbClearingStatus.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.cmbClearingStatus.Size = new System.Drawing.Size(241, 36);
            this.cmbClearingStatus.TabIndex = 41;
            this.cmbClearingStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gunaLabel7
            // 
            this.gunaLabel7.AutoSize = true;
            this.guna2Transition1.SetDecoration(this.gunaLabel7, Guna.UI2.AnimatorNS.DecorationType.None);
            this.gunaLabel7.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel7.ForeColor = System.Drawing.Color.Black;
            this.gunaLabel7.Location = new System.Drawing.Point(33, 120);
            this.gunaLabel7.Name = "gunaLabel7";
            this.gunaLabel7.Size = new System.Drawing.Size(95, 15);
            this.gunaLabel7.TabIndex = 42;
            this.gunaLabel7.Text = "Clearing Status";
            // 
            // txtClearingStatus
            // 
            this.txtClearingStatus.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.txtClearingStatus, Guna.UI2.AnimatorNS.DecorationType.None);
            this.txtClearingStatus.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClearingStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(79)))));
            this.txtClearingStatus.Location = new System.Drawing.Point(87, 63);
            this.txtClearingStatus.Name = "txtClearingStatus";
            this.txtClearingStatus.Size = new System.Drawing.Size(122, 19);
            this.txtClearingStatus.TabIndex = 92;
            this.txtClearingStatus.Text = "Clearing Status";
            // 
            // txtBranchName
            // 
            this.txtBranchName.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.txtBranchName, Guna.UI2.AnimatorNS.DecorationType.None);
            this.txtBranchName.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(79)))));
            this.txtBranchName.Location = new System.Drawing.Point(87, 38);
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.Size = new System.Drawing.Size(108, 19);
            this.txtBranchName.TabIndex = 91;
            this.txtBranchName.Text = "Branch Name";
            // 
            // btnShowFilter
            // 
            this.btnShowFilter.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.btnShowFilter, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnShowFilter.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnShowFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnShowFilter.Image")));
            this.btnShowFilter.ImageSize = new System.Drawing.Size(25, 25);
            this.btnShowFilter.Location = new System.Drawing.Point(969, 61);
            this.btnShowFilter.Name = "btnShowFilter";
            this.btnShowFilter.OnHoverImage = null;
            this.btnShowFilter.OnHoverImageOffset = new System.Drawing.Point(0, -2);
            this.btnShowFilter.Size = new System.Drawing.Size(36, 38);
            this.btnShowFilter.TabIndex = 82;
            this.btnShowFilter.Click += new System.EventHandler(this.btnShowFilter_Click);
            // 
            // dgvARAging
            // 
            this.dgvARAging.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(254)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvARAging.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvARAging.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvARAging.BackgroundColor = System.Drawing.Color.White;
            this.dgvARAging.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvARAging.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvARAging.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvARAging.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvARAging.ColumnHeadersHeight = 30;
            this.guna2Transition1.SetDecoration(this.dgvARAging, Guna.UI2.AnimatorNS.DecorationType.None);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(254)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvARAging.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvARAging.EnableHeadersVisualStyles = false;
            this.dgvARAging.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvARAging.Location = new System.Drawing.Point(87, 105);
            this.dgvARAging.Name = "dgvARAging";
            this.dgvARAging.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvARAging.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvARAging.RowHeadersVisible = false;
            this.dgvARAging.RowTemplate.Height = 30;
            this.dgvARAging.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvARAging.Size = new System.Drawing.Size(915, 487);
            this.dgvARAging.TabIndex = 90;
            this.dgvARAging.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvARAging.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvARAging.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvARAging.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvARAging.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvARAging.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvARAging.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvARAging.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvARAging.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvARAging.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvARAging.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvARAging.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvARAging.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvARAging.ThemeStyle.ReadOnly = false;
            this.dgvARAging.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvARAging.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvARAging.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvARAging.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvARAging.ThemeStyle.RowsStyle.Height = 30;
            this.dgvARAging.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvARAging.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvARAging.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvARAging_CellContentClick_1);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.CheckedState.Parent = this.btnCancel;
            this.btnCancel.CustomImages.Parent = this.btnCancel;
            this.btnCancel.CustomizableEdges.TopLeft = false;
            this.guna2Transition1.SetDecoration(this.btnCancel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnCancel.DisabledState.Parent = this.btnCancel;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(84)))), ((int)(((byte)(70)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(241)))), ((int)(((byte)(200)))));
            this.btnCancel.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            this.btnCancel.HoverState.Parent = this.btnCancel;
            this.btnCancel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCancel.ImageOffset = new System.Drawing.Point(5, 0);
            this.btnCancel.ImageSize = new System.Drawing.Size(15, 15);
            this.btnCancel.Location = new System.Drawing.Point(768, 630);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.BorderRadius = 5;
            this.btnCancel.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.btnCancel.ShadowDecoration.CustomizableEdges.TopLeft = false;
            this.btnCancel.ShadowDecoration.Enabled = true;
            this.btnCancel.ShadowDecoration.Parent = this.btnCancel;
            this.btnCancel.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.btnCancel.Size = new System.Drawing.Size(74, 30);
            this.btnCancel.TabIndex = 88;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCheckUncheck
            // 
            this.btnCheckUncheck.AutoSize = true;
            this.btnCheckUncheck.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            this.btnCheckUncheck.CheckedState.BorderRadius = 0;
            this.btnCheckUncheck.CheckedState.BorderThickness = 0;
            this.btnCheckUncheck.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            this.guna2Transition1.SetDecoration(this.btnCheckUncheck, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnCheckUncheck.Location = new System.Drawing.Point(137, 14);
            this.btnCheckUncheck.Name = "btnCheckUncheck";
            this.btnCheckUncheck.Size = new System.Drawing.Size(114, 17);
            this.btnCheckUncheck.TabIndex = 87;
            this.btnCheckUncheck.Text = "Toggle Check Box";
            this.btnCheckUncheck.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.btnCheckUncheck.UncheckedState.BorderRadius = 0;
            this.btnCheckUncheck.UncheckedState.BorderThickness = 0;
            this.btnCheckUncheck.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.btnCheckUncheck.CheckedChanged += new System.EventHandler(this.btnCheckUncheck_CheckedChanged);
            // 
            // btnBatchDelete
            // 
            this.btnBatchDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnBatchDelete.BorderRadius = 5;
            this.btnBatchDelete.CheckedState.Parent = this.btnBatchDelete;
            this.btnBatchDelete.CustomImages.Parent = this.btnBatchDelete;
            this.btnBatchDelete.CustomizableEdges.TopLeft = false;
            this.guna2Transition1.SetDecoration(this.btnBatchDelete, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnBatchDelete.DisabledState.Parent = this.btnBatchDelete;
            this.btnBatchDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(84)))), ((int)(((byte)(70)))));
            this.btnBatchDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBatchDelete.ForeColor = System.Drawing.Color.White;
            this.btnBatchDelete.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(241)))), ((int)(((byte)(200)))));
            this.btnBatchDelete.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            this.btnBatchDelete.HoverState.Parent = this.btnBatchDelete;
            this.btnBatchDelete.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBatchDelete.ImageOffset = new System.Drawing.Point(5, 0);
            this.btnBatchDelete.ImageSize = new System.Drawing.Size(15, 15);
            this.btnBatchDelete.Location = new System.Drawing.Point(848, 630);
            this.btnBatchDelete.Name = "btnBatchDelete";
            this.btnBatchDelete.ShadowDecoration.BorderRadius = 5;
            this.btnBatchDelete.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.btnBatchDelete.ShadowDecoration.CustomizableEdges.TopLeft = false;
            this.btnBatchDelete.ShadowDecoration.Enabled = true;
            this.btnBatchDelete.ShadowDecoration.Parent = this.btnBatchDelete;
            this.btnBatchDelete.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.btnBatchDelete.Size = new System.Drawing.Size(94, 30);
            this.btnBatchDelete.TabIndex = 86;
            this.btnBatchDelete.Text = "Batch Delete";
            this.btnBatchDelete.Click += new System.EventHandler(this.btnBatchDelete_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnExcel.BorderRadius = 5;
            this.btnExcel.CheckedState.Parent = this.btnExcel;
            this.btnExcel.CustomImages.Parent = this.btnExcel;
            this.btnExcel.CustomizableEdges.TopLeft = false;
            this.guna2Transition1.SetDecoration(this.btnExcel, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.btnExcel.Location = new System.Drawing.Point(948, 630);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.ShadowDecoration.BorderRadius = 5;
            this.btnExcel.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.btnExcel.ShadowDecoration.CustomizableEdges.TopLeft = false;
            this.btnExcel.ShadowDecoration.Enabled = true;
            this.btnExcel.ShadowDecoration.Parent = this.btnExcel;
            this.btnExcel.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.btnExcel.Size = new System.Drawing.Size(57, 30);
            this.btnExcel.TabIndex = 30;
            this.btnExcel.Text = "Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // guna2Transition1
            // 
            this.guna2Transition1.AnimationType = Guna.UI2.AnimatorNS.AnimationType.HorizSlide;
            this.guna2Transition1.Cursor = null;
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
            this.guna2Transition1.DefaultAnimation = animation1;
            // 
            // lblTransId
            // 
            this.lblTransId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            this.lblTransId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.guna2Transition1.SetDecoration(this.lblTransId, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblTransId.Font = new System.Drawing.Font("Lucida Sans", 9F);
            this.lblTransId.ForeColor = System.Drawing.Color.White;
            this.lblTransId.Location = new System.Drawing.Point(24, 187);
            this.lblTransId.Name = "lblTransId";
            this.lblTransId.Size = new System.Drawing.Size(17, 19);
            this.lblTransId.TabIndex = 82;
            this.lblTransId.Text = "ID";
            // 
            // UCARAging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContainer);
            this.guna2Transition1.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.Name = "UCARAging";
            this.Size = new System.Drawing.Size(1089, 676);
            this.Load += new System.EventHandler(this.UCARAging_Load);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvARAging)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI.WinForms.GunaPanel pnlContainer;
        private Guna.UI2.WinForms.Guna2Button btnExcel;
        private Guna.UI2.WinForms.Guna2Transition guna2Transition1;
        private Guna.UI2.WinForms.Guna2Panel pnlFilter;
        private Guna.UI2.WinForms.Guna2Button btnFilter;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private Guna.UI2.WinForms.Guna2CircleButton btnFilterReset;
        private Guna.UI2.WinForms.Guna2ComboBox cmbfltrBusUnit;
        private Guna.UI.WinForms.GunaLabel gunaLabel6;
        private Guna.UI2.WinForms.Guna2ComboBox cmbClearingStatus;
        private Guna.UI.WinForms.GunaLabel gunaLabel7;
        private Guna.UI2.WinForms.Guna2VSeparator guna2VSeparator2;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpToDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFromDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2CheckBox btnCheckUncheck;
        private Guna.UI2.WinForms.Guna2Button btnBatchDelete;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTransId;
        private Guna.UI2.WinForms.Guna2DataGridView dgvARAging;
        private Guna.UI.WinForms.GunaImageButton btnShowFilter;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtClearingStatus;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtBranchName;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator prgPreloader;
    }
}
