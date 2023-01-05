namespace EXIN
{
    partial class UCBudgetInputs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCBudgetInputs));
            this.gunaLinePanel1 = new Guna.UI.WinForms.GunaLinePanel();
            this.cmbAccountClass = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2VSeparator2 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.btnAddInput = new Guna.UI.WinForms.GunaImageButton();
            this.btnDeleteInput = new Guna.UI.WinForms.GunaImageButton();
            this.guna2VSeparator1 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.txtClassCode = new Guna.UI.WinForms.GunaTextBox();
            this.txtBudgetAmount = new Guna.UI.WinForms.GunaTextBox();
            this.SuspendLayout();
            // 
            // gunaLinePanel1
            // 
            this.gunaLinePanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gunaLinePanel1.LineBottom = 1;
            this.gunaLinePanel1.LineColor = System.Drawing.Color.DarkGray;
            this.gunaLinePanel1.LineStyle = System.Windows.Forms.BorderStyle.None;
            this.gunaLinePanel1.Location = new System.Drawing.Point(0, 74);
            this.gunaLinePanel1.Name = "gunaLinePanel1";
            this.gunaLinePanel1.Size = new System.Drawing.Size(816, 10);
            this.gunaLinePanel1.TabIndex = 34;
            // 
            // cmbAccountClass
            // 
            this.cmbAccountClass.AutoRoundedCorners = true;
            this.cmbAccountClass.BackColor = System.Drawing.Color.Transparent;
            this.cmbAccountClass.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            this.cmbAccountClass.BorderRadius = 17;
            this.cmbAccountClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAccountClass.DropDownHeight = 200;
            this.cmbAccountClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountClass.DropDownWidth = 234;
            this.cmbAccountClass.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.cmbAccountClass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.cmbAccountClass.FocusedState.Parent = this.cmbAccountClass;
            this.cmbAccountClass.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccountClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbAccountClass.HoverState.Parent = this.cmbAccountClass;
            this.cmbAccountClass.IntegralHeight = false;
            this.cmbAccountClass.ItemHeight = 30;
            this.cmbAccountClass.ItemsAppearance.Parent = this.cmbAccountClass;
            this.cmbAccountClass.Location = new System.Drawing.Point(254, 25);
            this.cmbAccountClass.Name = "cmbAccountClass";
            this.cmbAccountClass.ShadowDecoration.Parent = this.cmbAccountClass;
            this.cmbAccountClass.Size = new System.Drawing.Size(234, 36);
            this.cmbAccountClass.TabIndex = 1;
            this.cmbAccountClass.TabStop = false;
            this.cmbAccountClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cmbAccountClass.SelectedIndexChanged += new System.EventHandler(this.cmbAccountClass_SelectedIndexChanged);
            // 
            // guna2VSeparator2
            // 
            this.guna2VSeparator2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            this.guna2VSeparator2.FillThickness = 3;
            this.guna2VSeparator2.Location = new System.Drawing.Point(778, 16);
            this.guna2VSeparator2.Name = "guna2VSeparator2";
            this.guna2VSeparator2.Size = new System.Drawing.Size(10, 57);
            this.guna2VSeparator2.TabIndex = 33;
            this.guna2VSeparator2.TabStop = false;
            // 
            // btnAddInput
            // 
            this.btnAddInput.BackColor = System.Drawing.Color.Transparent;
            this.btnAddInput.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddInput.Image = ((System.Drawing.Image)(resources.GetObject("btnAddInput.Image")));
            this.btnAddInput.ImageSize = new System.Drawing.Size(20, 20);
            this.btnAddInput.Location = new System.Drawing.Point(13, 24);
            this.btnAddInput.Name = "btnAddInput";
            this.btnAddInput.OnHoverImage = null;
            this.btnAddInput.OnHoverImageOffset = new System.Drawing.Point(0, -2);
            this.btnAddInput.Size = new System.Drawing.Size(51, 36);
            this.btnAddInput.TabIndex = 31;
            this.btnAddInput.TabStop = false;
            this.btnAddInput.Click += new System.EventHandler(this.btnAddInput_Click);
            // 
            // btnDeleteInput
            // 
            this.btnDeleteInput.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteInput.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDeleteInput.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteInput.Image")));
            this.btnDeleteInput.ImageSize = new System.Drawing.Size(20, 20);
            this.btnDeleteInput.Location = new System.Drawing.Point(70, 24);
            this.btnDeleteInput.Name = "btnDeleteInput";
            this.btnDeleteInput.OnHoverImage = null;
            this.btnDeleteInput.OnHoverImageOffset = new System.Drawing.Point(0, -2);
            this.btnDeleteInput.Size = new System.Drawing.Size(38, 36);
            this.btnDeleteInput.TabIndex = 30;
            this.btnDeleteInput.TabStop = false;
            this.btnDeleteInput.Click += new System.EventHandler(this.btnDeleteInput_Click);
            // 
            // guna2VSeparator1
            // 
            this.guna2VSeparator1.Location = new System.Drawing.Point(216, 24);
            this.guna2VSeparator1.Name = "guna2VSeparator1";
            this.guna2VSeparator1.Size = new System.Drawing.Size(8, 37);
            this.guna2VSeparator1.TabIndex = 32;
            // 
            // txtClassCode
            // 
            this.txtClassCode.BackColor = System.Drawing.Color.Transparent;
            this.txtClassCode.BaseColor = System.Drawing.Color.White;
            this.txtClassCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            this.txtClassCode.BorderSize = 1;
            this.txtClassCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtClassCode.FocusedBaseColor = System.Drawing.Color.White;
            this.txtClassCode.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.txtClassCode.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtClassCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtClassCode.Location = new System.Drawing.Point(131, 24);
            this.txtClassCode.Name = "txtClassCode";
            this.txtClassCode.PasswordChar = '\0';
            this.txtClassCode.Radius = 5;
            this.txtClassCode.ReadOnly = true;
            this.txtClassCode.SelectedText = "";
            this.txtClassCode.Size = new System.Drawing.Size(63, 36);
            this.txtClassCode.TabIndex = 36;
            this.txtClassCode.TabStop = false;
            this.txtClassCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBudgetAmount
            // 
            this.txtBudgetAmount.BackColor = System.Drawing.Color.Transparent;
            this.txtBudgetAmount.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            this.txtBudgetAmount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            this.txtBudgetAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBudgetAmount.FocusedBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(84)))), ((int)(((byte)(70)))));
            this.txtBudgetAmount.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.txtBudgetAmount.FocusedForeColor = System.Drawing.Color.White;
            this.txtBudgetAmount.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBudgetAmount.ForeColor = System.Drawing.Color.White;
            this.txtBudgetAmount.Location = new System.Drawing.Point(527, 24);
            this.txtBudgetAmount.Name = "txtBudgetAmount";
            this.txtBudgetAmount.PasswordChar = '\0';
            this.txtBudgetAmount.Radius = 5;
            this.txtBudgetAmount.SelectedText = "";
            this.txtBudgetAmount.Size = new System.Drawing.Size(234, 36);
            this.txtBudgetAmount.TabIndex = 1;
            this.txtBudgetAmount.Text = "0.00";
            this.txtBudgetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBudgetAmount.Leave += new System.EventHandler(this.txtBudgetAmount_Leave);
            // 
            // UCBudgetInputs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.txtBudgetAmount);
            this.Controls.Add(this.txtClassCode);
            this.Controls.Add(this.guna2VSeparator1);
            this.Controls.Add(this.gunaLinePanel1);
            this.Controls.Add(this.btnDeleteInput);
            this.Controls.Add(this.btnAddInput);
            this.Controls.Add(this.guna2VSeparator2);
            this.Controls.Add(this.cmbAccountClass);
            this.Name = "UCBudgetInputs";
            this.Size = new System.Drawing.Size(816, 84);
            this.Load += new System.EventHandler(this.UCBudgetInputs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaLinePanel gunaLinePanel1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbAccountClass;
        private Guna.UI2.WinForms.Guna2VSeparator guna2VSeparator2;
        private Guna.UI.WinForms.GunaImageButton btnAddInput;
        private Guna.UI.WinForms.GunaImageButton btnDeleteInput;
        private Guna.UI2.WinForms.Guna2VSeparator guna2VSeparator1;
        private Guna.UI.WinForms.GunaTextBox txtClassCode;
        private Guna.UI.WinForms.GunaTextBox txtBudgetAmount;
    }
}
