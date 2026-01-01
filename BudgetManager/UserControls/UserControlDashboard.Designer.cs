namespace projekttest.UserControls
{
    partial class UserControlDashboard
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
            pnlHeader = new Panel();
            cmbTimeFilter = new ComboBox();
            label1 = new Label();
            dgvRecent = new DataGridView();
            lblBalanceTitle = new Label();
            lblBalanceValue = new Label();
            pnlBalance = new Panel();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecent).BeginInit();
            pnlBalance.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.Beige;
            pnlHeader.Controls.Add(cmbTimeFilter);
            pnlHeader.Controls.Add(label1);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1220, 60);
            pnlHeader.TabIndex = 0;
            // 
            // cmbTimeFilter
            // 
            cmbTimeFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbTimeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTimeFilter.Font = new Font("Segoe UI", 11F);
            cmbTimeFilter.FormattingEnabled = true;
            cmbTimeFilter.Location = new Point(1023, 14);
            cmbTimeFilter.Name = "cmbTimeFilter";
            cmbTimeFilter.Size = new Size(180, 28);
            cmbTimeFilter.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(15, 14);
            label1.Name = "label1";
            label1.Size = new Size(449, 37);
            label1.TabIndex = 1;
            label1.Text = "Podsumowanie wpływów/wydatków";
            // 
            // dgvRecent
            // 
            dgvRecent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecent.Dock = DockStyle.Fill;
            dgvRecent.Location = new Point(0, 124);
            dgvRecent.Name = "dgvRecent";
            dgvRecent.Size = new Size(1220, 562);
            dgvRecent.TabIndex = 1;
            // 
            // lblBalanceTitle
            // 
            lblBalanceTitle.AutoSize = true;
            lblBalanceTitle.Dock = DockStyle.Top;
            lblBalanceTitle.Font = new Font("Segoe UI", 16F);
            lblBalanceTitle.Location = new Point(0, 0);
            lblBalanceTitle.Name = "lblBalanceTitle";
            lblBalanceTitle.Size = new Size(86, 30);
            lblBalanceTitle.TabIndex = 2;
            lblBalanceTitle.Text = "SALDO:";
            lblBalanceTitle.Click += lblBalanceTitle_Click;
            // 
            // lblBalanceValue
            // 
            lblBalanceValue.AutoSize = true;
            lblBalanceValue.Dock = DockStyle.Top;
            lblBalanceValue.Font = new Font("Segoe UI", 16F);
            lblBalanceValue.Location = new Point(0, 30);
            lblBalanceValue.Name = "lblBalanceValue";
            lblBalanceValue.Size = new Size(71, 30);
            lblBalanceValue.TabIndex = 3;
            lblBalanceValue.Text = "label2";
            // 
            // pnlBalance
            // 
            pnlBalance.Controls.Add(lblBalanceValue);
            pnlBalance.Controls.Add(lblBalanceTitle);
            pnlBalance.Dock = DockStyle.Top;
            pnlBalance.Location = new Point(0, 60);
            pnlBalance.Name = "pnlBalance";
            pnlBalance.Size = new Size(1220, 64);
            pnlBalance.TabIndex = 2;
            // 
            // UserControlDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Snow;
            Controls.Add(dgvRecent);
            Controls.Add(pnlBalance);
            Controls.Add(pnlHeader);
            Name = "UserControlDashboard";
            Size = new Size(1220, 686);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecent).EndInit();
            pnlBalance.ResumeLayout(false);
            pnlBalance.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label label1;
        private DataGridView dgvRecent;
        private Label lblBalanceTitle;
        private Label lblBalanceValue;
        private ComboBox cmbTimeFilter;
        private Panel pnlBalance;
    }
}
