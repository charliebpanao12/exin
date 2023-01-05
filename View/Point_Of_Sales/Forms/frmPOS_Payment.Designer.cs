
namespace EXIN.Point_Of_Sales
{
    partial class frmPOS_Payment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOS_Payment));
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.zeroitSmoothAnimator1 = new Zeroit.Framework.Transitions.SmoothTransitions.ZeroitSmoothAnimator();
            this.guna2PanelBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.btnBilling = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnClose = new Guna.UI2.WinForms.Guna2GradientButton();
            this.panelCart = new Guna.UI2.WinForms.Guna2Panel();
            this.panelCartItems = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTransactionID = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.picCart = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.panelMenuTitle = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.lblChooseItems = new System.Windows.Forms.Label();
            this.panelTransactionDetails = new Guna.UI2.WinForms.Guna2Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.numtxtChange = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.numtxtPaymentAmount = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.numtxtDiscountAmount = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBills_1000 = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnBills_500 = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnBills_200 = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnBills_100 = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnBills_50 = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnBills_20 = new Guna.UI2.WinForms.Guna2TileButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDiscount = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboPaymentMethod = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2PanelBottom.SuspendLayout();
            this.panelCart.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCart)).BeginInit();
            this.panelMenuTitle.SuspendLayout();
            this.panelTransactionDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numtxtChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numtxtPaymentAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numtxtDiscountAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.UseTransparentDrag = true;
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
            this.guna2PanelBottom.Controls.Add(this.btnBilling);
            this.guna2PanelBottom.Controls.Add(this.btnSave);
            this.guna2PanelBottom.Controls.Add(this.btnClose);
            this.guna2PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2PanelBottom.Location = new System.Drawing.Point(6, 433);
            this.guna2PanelBottom.Name = "guna2PanelBottom";
            this.guna2PanelBottom.Size = new System.Drawing.Size(371, 63);
            this.guna2PanelBottom.TabIndex = 174;
            // 
            // btnBilling
            // 
            this.btnBilling.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBilling.Animated = true;
            this.btnBilling.AutoRoundedCorners = true;
            this.btnBilling.BackColor = System.Drawing.Color.Transparent;
            this.btnBilling.BorderRadius = 20;
            this.btnBilling.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBilling.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(158)))));
            this.btnBilling.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(214)))), ((int)(((byte)(245)))));
            this.btnBilling.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilling.ForeColor = System.Drawing.Color.White;
            this.btnBilling.Location = new System.Drawing.Point(129, 11);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Size = new System.Drawing.Size(113, 43);
            this.btnBilling.TabIndex = 13;
            this.btnBilling.Text = "Billing";
            this.btnBilling.UseTransparentBackground = true;
            this.btnBilling.Click += new System.EventHandler(this.btnBilling_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Animated = true;
            this.btnSave.AutoRoundedCorners = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderRadius = 20;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(158)))));
            this.btnSave.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(214)))), ((int)(((byte)(245)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(248, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 43);
            this.btnSave.TabIndex = 12;
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
            this.btnClose.BorderRadius = 20;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(158)))));
            this.btnClose.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(214)))), ((int)(((byte)(245)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(11, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 43);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseTransparentBackground = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelCart
            // 
            this.panelCart.AutoScroll = true;
            this.panelCart.BackColor = System.Drawing.Color.Transparent;
            this.panelCart.BorderRadius = 7;
            this.panelCart.Controls.Add(this.panelCartItems);
            this.panelCart.Controls.Add(this.guna2Separator2);
            this.panelCart.Controls.Add(this.guna2Panel2);
            this.panelCart.Controls.Add(this.guna2Panel1);
            this.panelCart.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelCart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(230)))), ((int)(((byte)(244)))));
            this.panelCart.Location = new System.Drawing.Point(15, 12);
            this.panelCart.Name = "panelCart";
            this.panelCart.Padding = new System.Windows.Forms.Padding(2);
            this.panelCart.ShadowDecoration.BorderRadius = 20;
            this.panelCart.ShadowDecoration.Color = System.Drawing.Color.DarkGray;
            this.panelCart.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 2, 5, 9);
            this.panelCart.Size = new System.Drawing.Size(404, 560);
            this.panelCart.TabIndex = 175;
            // 
            // panelCartItems
            // 
            this.panelCartItems.AutoScroll = true;
            this.panelCartItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCartItems.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(247)))));
            this.panelCartItems.Location = new System.Drawing.Point(2, 58);
            this.panelCartItems.Name = "panelCartItems";
            this.panelCartItems.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.panelCartItems.Size = new System.Drawing.Size(400, 427);
            this.panelCartItems.TabIndex = 181;
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Separator2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(247)))));
            this.guna2Separator2.Location = new System.Drawing.Point(2, 485);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(400, 6);
            this.guna2Separator2.TabIndex = 179;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderRadius = 7;
            this.guna2Panel2.Controls.Add(this.lblTotalAmount);
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(2, 491);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(400, 67);
            this.guna2Panel2.TabIndex = 178;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAmount.Font = new System.Drawing.Font("DejaVu Sans Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(144)))), ((int)(((byte)(50)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(211, 11);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(185, 45);
            this.lblTotalAmount.TabIndex = 117;
            this.lblTotalAmount.Text = "100.00";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("DejaVu Sans Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(81)))), ((int)(((byte)(122)))));
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 45);
            this.label2.TabIndex = 116;
            this.label2.Text = "TOTAL:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.lblTransactionID);
            this.guna2Panel1.Controls.Add(this.Label10);
            this.guna2Panel1.Controls.Add(this.picCart);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(247)))));
            this.guna2Panel1.Location = new System.Drawing.Point(2, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(400, 56);
            this.guna2Panel1.TabIndex = 0;
            // 
            // lblTransactionID
            // 
            this.lblTransactionID.BackColor = System.Drawing.Color.Transparent;
            this.lblTransactionID.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(81)))), ((int)(((byte)(122)))));
            this.lblTransactionID.Location = new System.Drawing.Point(178, 8);
            this.lblTransactionID.Name = "lblTransactionID";
            this.lblTransactionID.Size = new System.Drawing.Size(219, 24);
            this.lblTransactionID.TabIndex = 186;
            this.lblTransactionID.Text = "Transaction ID";
            this.lblTransactionID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label10
            // 
            this.Label10.BackColor = System.Drawing.Color.Transparent;
            this.Label10.Font = new System.Drawing.Font("DejaVu Sans Condensed", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(81)))), ((int)(((byte)(122)))));
            this.Label10.Location = new System.Drawing.Point(177, 27);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(219, 24);
            this.Label10.TabIndex = 185;
            this.Label10.Text = "Trans. ID";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picCart
            // 
            this.picCart.BackColor = System.Drawing.Color.Transparent;
            this.picCart.FillColor = System.Drawing.Color.Transparent;
            this.picCart.Image = ((System.Drawing.Image)(resources.GetObject("picCart.Image")));
            this.picCart.ImageRotate = 0F;
            this.picCart.Location = new System.Drawing.Point(10, 13);
            this.picCart.Name = "picCart";
            this.picCart.Size = new System.Drawing.Size(32, 28);
            this.picCart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCart.TabIndex = 184;
            this.picCart.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("DejaVu Sans Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(81)))), ((int)(((byte)(122)))));
            this.label1.Location = new System.Drawing.Point(49, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 24);
            this.label1.TabIndex = 116;
            this.label1.Text = "Cart";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Separator1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Separator1.Location = new System.Drawing.Point(419, 12);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(15, 560);
            this.guna2Separator1.TabIndex = 176;
            // 
            // panelMenuTitle
            // 
            this.panelMenuTitle.BorderRadius = 7;
            this.panelMenuTitle.Controls.Add(this.guna2Button1);
            this.panelMenuTitle.Controls.Add(this.lblChooseItems);
            this.panelMenuTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenuTitle.FillColor = System.Drawing.Color.White;
            this.panelMenuTitle.Location = new System.Drawing.Point(434, 12);
            this.panelMenuTitle.Name = "panelMenuTitle";
            this.panelMenuTitle.Size = new System.Drawing.Size(383, 58);
            this.panelMenuTitle.TabIndex = 177;
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(264, 1);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(68, 57);
            this.guna2Button1.TabIndex = 0;
            this.guna2Button1.Text = "guna2Button1";
            this.guna2Button1.Visible = false;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // lblChooseItems
            // 
            this.lblChooseItems.BackColor = System.Drawing.Color.Transparent;
            this.lblChooseItems.Font = new System.Drawing.Font("DejaVu Sans Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(81)))), ((int)(((byte)(122)))));
            this.lblChooseItems.Location = new System.Drawing.Point(12, 9);
            this.lblChooseItems.Name = "lblChooseItems";
            this.lblChooseItems.Size = new System.Drawing.Size(272, 45);
            this.lblChooseItems.TabIndex = 116;
            this.lblChooseItems.Text = "Transaction Details";
            this.lblChooseItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelTransactionDetails
            // 
            this.panelTransactionDetails.AutoScroll = true;
            this.panelTransactionDetails.BackColor = System.Drawing.Color.Transparent;
            this.panelTransactionDetails.BorderRadius = 7;
            this.panelTransactionDetails.Controls.Add(this.label8);
            this.panelTransactionDetails.Controls.Add(this.numtxtChange);
            this.panelTransactionDetails.Controls.Add(this.numtxtPaymentAmount);
            this.panelTransactionDetails.Controls.Add(this.numtxtDiscountAmount);
            this.panelTransactionDetails.Controls.Add(this.label7);
            this.panelTransactionDetails.Controls.Add(this.btnBills_1000);
            this.panelTransactionDetails.Controls.Add(this.btnBills_500);
            this.panelTransactionDetails.Controls.Add(this.btnBills_200);
            this.panelTransactionDetails.Controls.Add(this.btnBills_100);
            this.panelTransactionDetails.Controls.Add(this.btnBills_50);
            this.panelTransactionDetails.Controls.Add(this.btnBills_20);
            this.panelTransactionDetails.Controls.Add(this.label6);
            this.panelTransactionDetails.Controls.Add(this.label5);
            this.panelTransactionDetails.Controls.Add(this.cboDiscount);
            this.panelTransactionDetails.Controls.Add(this.label4);
            this.panelTransactionDetails.Controls.Add(this.cboPaymentMethod);
            this.panelTransactionDetails.Controls.Add(this.label3);
            this.panelTransactionDetails.Controls.Add(this.guna2PanelBottom);
            this.panelTransactionDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTransactionDetails.FillColor = System.Drawing.Color.White;
            this.panelTransactionDetails.Location = new System.Drawing.Point(434, 70);
            this.panelTransactionDetails.Name = "panelTransactionDetails";
            this.panelTransactionDetails.Padding = new System.Windows.Forms.Padding(6);
            this.panelTransactionDetails.ShadowDecoration.BorderRadius = 20;
            this.panelTransactionDetails.ShadowDecoration.Color = System.Drawing.Color.DarkGray;
            this.panelTransactionDetails.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 2, 5, 9);
            this.panelTransactionDetails.Size = new System.Drawing.Size(383, 502);
            this.panelTransactionDetails.TabIndex = 178;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("DejaVu Sans Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(13, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 18);
            this.label8.TabIndex = 203;
            this.label8.Text = "Select Bills";
            // 
            // numtxtChange
            // 
            this.numtxtChange.BackColor = System.Drawing.Color.Transparent;
            this.numtxtChange.BorderRadius = 5;
            this.numtxtChange.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numtxtChange.DecimalPlaces = 2;
            this.numtxtChange.Enabled = false;
            this.numtxtChange.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numtxtChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(81)))), ((int)(((byte)(122)))));
            this.numtxtChange.Location = new System.Drawing.Point(201, 189);
            this.numtxtChange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numtxtChange.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numtxtChange.Name = "numtxtChange";
            this.numtxtChange.Size = new System.Drawing.Size(166, 38);
            this.numtxtChange.TabIndex = 4;
            this.numtxtChange.TextOffset = new System.Drawing.Point(12, 0);
            this.numtxtChange.ThousandsSeparator = true;
            this.numtxtChange.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numtxtPaymentAmount
            // 
            this.numtxtPaymentAmount.BackColor = System.Drawing.Color.Transparent;
            this.numtxtPaymentAmount.BorderRadius = 5;
            this.numtxtPaymentAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numtxtPaymentAmount.DecimalPlaces = 2;
            this.numtxtPaymentAmount.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numtxtPaymentAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(81)))), ((int)(((byte)(122)))));
            this.numtxtPaymentAmount.Location = new System.Drawing.Point(201, 143);
            this.numtxtPaymentAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numtxtPaymentAmount.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numtxtPaymentAmount.Name = "numtxtPaymentAmount";
            this.numtxtPaymentAmount.Size = new System.Drawing.Size(166, 38);
            this.numtxtPaymentAmount.TabIndex = 3;
            this.numtxtPaymentAmount.TextOffset = new System.Drawing.Point(12, 0);
            this.numtxtPaymentAmount.ThousandsSeparator = true;
            this.numtxtPaymentAmount.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numtxtPaymentAmount.ValueChanged += new System.EventHandler(this.numtxtPaymentAmount_ValueChanged);
            this.numtxtPaymentAmount.Enter += new System.EventHandler(this.numtxtPaymentAmount_Enter);
            // 
            // numtxtDiscountAmount
            // 
            this.numtxtDiscountAmount.BackColor = System.Drawing.Color.Transparent;
            this.numtxtDiscountAmount.BorderRadius = 5;
            this.numtxtDiscountAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numtxtDiscountAmount.DecimalPlaces = 2;
            this.numtxtDiscountAmount.Enabled = false;
            this.numtxtDiscountAmount.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numtxtDiscountAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(81)))), ((int)(((byte)(122)))));
            this.numtxtDiscountAmount.Location = new System.Drawing.Point(201, 97);
            this.numtxtDiscountAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numtxtDiscountAmount.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numtxtDiscountAmount.Name = "numtxtDiscountAmount";
            this.numtxtDiscountAmount.Size = new System.Drawing.Size(166, 38);
            this.numtxtDiscountAmount.TabIndex = 2;
            this.numtxtDiscountAmount.TextOffset = new System.Drawing.Point(12, 0);
            this.numtxtDiscountAmount.ThousandsSeparator = true;
            this.numtxtDiscountAmount.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("DejaVu Sans Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(13, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 18);
            this.label7.TabIndex = 199;
            this.label7.Text = "Change";
            // 
            // btnBills_1000
            // 
            this.btnBills_1000.BackColor = System.Drawing.Color.Transparent;
            this.btnBills_1000.BorderRadius = 7;
            this.btnBills_1000.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBills_1000.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBills_1000.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBills_1000.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBills_1000.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBills_1000.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(28)))), ((int)(((byte)(165)))));
            this.btnBills_1000.Font = new System.Drawing.Font("SansSerif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnBills_1000.ForeColor = System.Drawing.Color.White;
            this.btnBills_1000.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(44)))), ((int)(((byte)(180)))));
            this.btnBills_1000.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBills_1000.ImageOffset = new System.Drawing.Point(5, 11);
            this.btnBills_1000.ImageSize = new System.Drawing.Size(17, 17);
            this.btnBills_1000.Location = new System.Drawing.Point(254, 358);
            this.btnBills_1000.Name = "btnBills_1000";
            this.btnBills_1000.Size = new System.Drawing.Size(113, 71);
            this.btnBills_1000.TabIndex = 10;
            this.btnBills_1000.Text = "1000";
            this.btnBills_1000.Click += new System.EventHandler(this.btnBills_1000_Click);
            // 
            // btnBills_500
            // 
            this.btnBills_500.BackColor = System.Drawing.Color.Transparent;
            this.btnBills_500.BorderRadius = 7;
            this.btnBills_500.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBills_500.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBills_500.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBills_500.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBills_500.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBills_500.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(28)))), ((int)(((byte)(165)))));
            this.btnBills_500.Font = new System.Drawing.Font("SansSerif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnBills_500.ForeColor = System.Drawing.Color.White;
            this.btnBills_500.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(44)))), ((int)(((byte)(180)))));
            this.btnBills_500.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBills_500.ImageOffset = new System.Drawing.Point(5, 11);
            this.btnBills_500.ImageSize = new System.Drawing.Size(17, 17);
            this.btnBills_500.Location = new System.Drawing.Point(135, 358);
            this.btnBills_500.Name = "btnBills_500";
            this.btnBills_500.Size = new System.Drawing.Size(113, 71);
            this.btnBills_500.TabIndex = 9;
            this.btnBills_500.Text = "500";
            this.btnBills_500.Click += new System.EventHandler(this.btnBills_500_Click);
            // 
            // btnBills_200
            // 
            this.btnBills_200.BackColor = System.Drawing.Color.Transparent;
            this.btnBills_200.BorderRadius = 7;
            this.btnBills_200.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBills_200.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBills_200.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBills_200.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBills_200.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBills_200.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(28)))), ((int)(((byte)(165)))));
            this.btnBills_200.Font = new System.Drawing.Font("SansSerif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnBills_200.ForeColor = System.Drawing.Color.White;
            this.btnBills_200.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(44)))), ((int)(((byte)(180)))));
            this.btnBills_200.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBills_200.ImageOffset = new System.Drawing.Point(5, 11);
            this.btnBills_200.ImageSize = new System.Drawing.Size(17, 17);
            this.btnBills_200.Location = new System.Drawing.Point(16, 358);
            this.btnBills_200.Name = "btnBills_200";
            this.btnBills_200.Size = new System.Drawing.Size(113, 71);
            this.btnBills_200.TabIndex = 8;
            this.btnBills_200.Text = "200";
            this.btnBills_200.Click += new System.EventHandler(this.btnBills_200_Click);
            // 
            // btnBills_100
            // 
            this.btnBills_100.BackColor = System.Drawing.Color.Transparent;
            this.btnBills_100.BorderRadius = 7;
            this.btnBills_100.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBills_100.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBills_100.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBills_100.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBills_100.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBills_100.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(28)))), ((int)(((byte)(165)))));
            this.btnBills_100.Font = new System.Drawing.Font("SansSerif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnBills_100.ForeColor = System.Drawing.Color.White;
            this.btnBills_100.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(44)))), ((int)(((byte)(180)))));
            this.btnBills_100.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBills_100.ImageOffset = new System.Drawing.Point(5, 11);
            this.btnBills_100.ImageSize = new System.Drawing.Size(17, 17);
            this.btnBills_100.Location = new System.Drawing.Point(254, 281);
            this.btnBills_100.Name = "btnBills_100";
            this.btnBills_100.Size = new System.Drawing.Size(113, 71);
            this.btnBills_100.TabIndex = 7;
            this.btnBills_100.Text = "100";
            this.btnBills_100.Click += new System.EventHandler(this.btnBills_100_Click);
            // 
            // btnBills_50
            // 
            this.btnBills_50.BackColor = System.Drawing.Color.Transparent;
            this.btnBills_50.BorderRadius = 7;
            this.btnBills_50.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBills_50.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBills_50.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBills_50.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBills_50.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBills_50.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(28)))), ((int)(((byte)(165)))));
            this.btnBills_50.Font = new System.Drawing.Font("SansSerif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnBills_50.ForeColor = System.Drawing.Color.White;
            this.btnBills_50.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(44)))), ((int)(((byte)(180)))));
            this.btnBills_50.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBills_50.ImageOffset = new System.Drawing.Point(5, 11);
            this.btnBills_50.ImageSize = new System.Drawing.Size(17, 17);
            this.btnBills_50.Location = new System.Drawing.Point(135, 281);
            this.btnBills_50.Name = "btnBills_50";
            this.btnBills_50.Size = new System.Drawing.Size(113, 71);
            this.btnBills_50.TabIndex = 6;
            this.btnBills_50.Text = "50";
            this.btnBills_50.Click += new System.EventHandler(this.btnBills_50_Click);
            // 
            // btnBills_20
            // 
            this.btnBills_20.BackColor = System.Drawing.Color.Transparent;
            this.btnBills_20.BorderRadius = 7;
            this.btnBills_20.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBills_20.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBills_20.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBills_20.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBills_20.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBills_20.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(28)))), ((int)(((byte)(165)))));
            this.btnBills_20.Font = new System.Drawing.Font("SansSerif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnBills_20.ForeColor = System.Drawing.Color.White;
            this.btnBills_20.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(44)))), ((int)(((byte)(180)))));
            this.btnBills_20.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBills_20.ImageOffset = new System.Drawing.Point(5, 11);
            this.btnBills_20.ImageSize = new System.Drawing.Size(17, 17);
            this.btnBills_20.Location = new System.Drawing.Point(16, 281);
            this.btnBills_20.Name = "btnBills_20";
            this.btnBills_20.Size = new System.Drawing.Size(113, 71);
            this.btnBills_20.TabIndex = 5;
            this.btnBills_20.Text = "20";
            this.btnBills_20.Click += new System.EventHandler(this.btnBills_20_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("DejaVu Sans Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(13, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 18);
            this.label6.TabIndex = 191;
            this.label6.Text = "Payment Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("DejaVu Sans Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(13, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 18);
            this.label5.TabIndex = 190;
            this.label5.Text = "Discount Amount";
            // 
            // cboDiscount
            // 
            this.cboDiscount.BackColor = System.Drawing.Color.Transparent;
            this.cboDiscount.BorderRadius = 10;
            this.cboDiscount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiscount.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboDiscount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboDiscount.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboDiscount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboDiscount.IntegralHeight = false;
            this.cboDiscount.ItemHeight = 30;
            this.cboDiscount.Items.AddRange(new object[] {
            "No Discount",
            "Senior Discount",
            "PWD Discount"});
            this.cboDiscount.Location = new System.Drawing.Point(201, 12);
            this.cboDiscount.MaxDropDownItems = 10;
            this.cboDiscount.Name = "cboDiscount";
            this.cboDiscount.Size = new System.Drawing.Size(166, 36);
            this.cboDiscount.TabIndex = 0;
            this.cboDiscount.TextOffset = new System.Drawing.Point(10, 0);
            this.cboDiscount.SelectedIndexChanged += new System.EventHandler(this.cboDiscount_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("DejaVu Sans Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(13, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 18);
            this.label4.TabIndex = 188;
            this.label4.Text = "Discount";
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.BackColor = System.Drawing.Color.Transparent;
            this.cboPaymentMethod.BorderRadius = 10;
            this.cboPaymentMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPaymentMethod.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPaymentMethod.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPaymentMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboPaymentMethod.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPaymentMethod.IntegralHeight = false;
            this.cboPaymentMethod.ItemHeight = 30;
            this.cboPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "GCash",
            "PayMaya",
            "BDO",
            "BPI",
            "Security Bank",
            "ChinaBank",
            "PS Bank",
            "GateBank",
            "EastWest"});
            this.cboPaymentMethod.Location = new System.Drawing.Point(201, 54);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(166, 36);
            this.cboPaymentMethod.TabIndex = 1;
            this.cboPaymentMethod.TextOffset = new System.Drawing.Point(10, 0);
            this.cboPaymentMethod.SelectedIndexChanged += new System.EventHandler(this.cboPaymentMethod_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("DejaVu Sans Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(13, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 18);
            this.label3.TabIndex = 186;
            this.label3.Text = "Payment Method";
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 12;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.DarkGray;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // frmPOS_Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(832, 584);
            this.Controls.Add(this.panelTransactionDetails);
            this.Controls.Add(this.panelMenuTitle);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.panelCart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPOS_Payment";
            this.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPOS_Payment";
            this.Load += new System.EventHandler(this.frmPOS_Payment_Load);
            this.guna2PanelBottom.ResumeLayout(false);
            this.panelCart.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCart)).EndInit();
            this.panelMenuTitle.ResumeLayout(false);
            this.panelTransactionDetails.ResumeLayout(false);
            this.panelTransactionDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numtxtChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numtxtPaymentAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numtxtDiscountAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Zeroit.Framework.Transitions.SmoothTransitions.ZeroitSmoothAnimator zeroitSmoothAnimator1;
        private Guna.UI2.WinForms.Guna2Panel guna2PanelBottom;
        private Guna.UI2.WinForms.Guna2GradientButton btnSave;
        private Guna.UI2.WinForms.Guna2GradientButton btnClose;
        private Guna.UI2.WinForms.Guna2Panel panelCart;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox picCart;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Panel panelMenuTitle;
        private System.Windows.Forms.Label lblChooseItems;
        private Guna.UI2.WinForms.Guna2Panel panelTransactionDetails;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalAmount;
        private Guna.UI2.WinForms.Guna2Panel panelCartItems;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2ComboBox cboDiscount;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox cboPaymentMethod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TileButton btnBills_20;
        private Guna.UI2.WinForms.Guna2TileButton btnBills_1000;
        private Guna.UI2.WinForms.Guna2TileButton btnBills_500;
        private Guna.UI2.WinForms.Guna2TileButton btnBills_200;
        private Guna.UI2.WinForms.Guna2TileButton btnBills_100;
        private Guna.UI2.WinForms.Guna2TileButton btnBills_50;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2NumericUpDown numtxtChange;
        private Guna.UI2.WinForms.Guna2NumericUpDown numtxtPaymentAmount;
        private Guna.UI2.WinForms.Guna2NumericUpDown numtxtDiscountAmount;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2GradientButton btnBilling;
        private System.Windows.Forms.Label Label10;
        private System.Windows.Forms.Label lblTransactionID;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}