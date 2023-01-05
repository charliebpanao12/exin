namespace EXIN
{
    partial class UCAccountingEntries
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
            this.txtParticulars = new Guna.UI.WinForms.GunaTextBox();
            this.txtAmount = new Guna.UI.WinForms.GunaTextBox();
            this.cmbAcctDescription = new Guna.UI.WinForms.GunaComboBox();
            this.cmbAccount = new Guna.UI.WinForms.GunaComboBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.SuspendLayout();
            // 
            // txtParticulars
            // 
            this.txtParticulars.BackColor = System.Drawing.Color.Transparent;
            this.txtParticulars.BaseColor = System.Drawing.Color.White;
            this.txtParticulars.BorderColor = System.Drawing.Color.Silver;
            this.txtParticulars.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtParticulars.FocusedBaseColor = System.Drawing.Color.White;
            this.txtParticulars.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(171)))), ((int)(((byte)(0)))));
            this.txtParticulars.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(27)))), ((int)(((byte)(146)))));
            this.txtParticulars.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParticulars.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(27)))), ((int)(((byte)(146)))));
            this.txtParticulars.Location = new System.Drawing.Point(513, 13);
            this.txtParticulars.Name = "txtParticulars";
            this.txtParticulars.PasswordChar = '\0';
            this.txtParticulars.Radius = 10;
            this.txtParticulars.SelectedText = "";
            this.txtParticulars.Size = new System.Drawing.Size(264, 26);
            this.txtParticulars.TabIndex = 6;
            this.txtParticulars.Text = "Particulars";
            this.txtParticulars.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.Transparent;
            this.txtAmount.BaseColor = System.Drawing.Color.White;
            this.txtAmount.BorderColor = System.Drawing.Color.Silver;
            this.txtAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmount.FocusedBaseColor = System.Drawing.Color.White;
            this.txtAmount.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(171)))), ((int)(((byte)(0)))));
            this.txtAmount.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(27)))), ((int)(((byte)(146)))));
            this.txtAmount.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(27)))), ((int)(((byte)(146)))));
            this.txtAmount.Location = new System.Drawing.Point(363, 13);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PasswordChar = '\0';
            this.txtAmount.Radius = 10;
            this.txtAmount.SelectedText = "";
            this.txtAmount.Size = new System.Drawing.Size(144, 26);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.Text = "Amount";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbAcctDescription
            // 
            this.cmbAcctDescription.BackColor = System.Drawing.Color.Transparent;
            this.cmbAcctDescription.BaseColor = System.Drawing.Color.White;
            this.cmbAcctDescription.BorderColor = System.Drawing.Color.Silver;
            this.cmbAcctDescription.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAcctDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAcctDescription.FocusedColor = System.Drawing.Color.Empty;
            this.cmbAcctDescription.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAcctDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(27)))), ((int)(((byte)(146)))));
            this.cmbAcctDescription.FormattingEnabled = true;
            this.cmbAcctDescription.Items.AddRange(new object[] {
            "Cash in Bank",
            "Representation",
            "Travel Expense",
            "Office Supplies"});
            this.cmbAcctDescription.Location = new System.Drawing.Point(25, 15);
            this.cmbAcctDescription.Name = "cmbAcctDescription";
            this.cmbAcctDescription.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(84)))), ((int)(((byte)(164)))));
            this.cmbAcctDescription.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmbAcctDescription.Radius = 10;
            this.cmbAcctDescription.Size = new System.Drawing.Size(227, 24);
            this.cmbAcctDescription.TabIndex = 3;
            // 
            // cmbAccount
            // 
            this.cmbAccount.BackColor = System.Drawing.Color.Transparent;
            this.cmbAccount.BaseColor = System.Drawing.Color.White;
            this.cmbAccount.BorderColor = System.Drawing.Color.Silver;
            this.cmbAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccount.FocusedColor = System.Drawing.Color.Empty;
            this.cmbAccount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(27)))), ((int)(((byte)(146)))));
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Items.AddRange(new object[] {
            "150",
            "810",
            "820",
            "850"});
            this.cmbAccount.Location = new System.Drawing.Point(258, 13);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(84)))), ((int)(((byte)(164)))));
            this.cmbAccount.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmbAccount.Radius = 10;
            this.cmbAccount.Size = new System.Drawing.Size(89, 26);
            this.cmbAccount.TabIndex = 4;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Silver;
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 60);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(780, 1);
            this.guna2Panel1.TabIndex = 7;
            // 
            // UCAccountingEntries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.txtParticulars);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.cmbAcctDescription);
            this.Controls.Add(this.cmbAccount);
            this.Name = "UCAccountingEntries";
            this.Size = new System.Drawing.Size(780, 61);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaTextBox txtParticulars;
        private Guna.UI.WinForms.GunaTextBox txtAmount;
        private Guna.UI.WinForms.GunaComboBox cmbAcctDescription;
        private Guna.UI.WinForms.GunaComboBox cmbAccount;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}
