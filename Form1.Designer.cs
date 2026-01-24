namespace projekttest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panelContent = new Panel();
            panelMenu = new Panel();
            btnExport = new Button();
            btnImport = new Button();
            btnDashboard = new Button();
            btnReports = new Button();
            btnCategories = new Button();
            btnGoals = new Button();
            btnFamily = new Button();
            btnIncome = new Button();
            btnExpenses = new Button();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1008, 729);
            panelContent.TabIndex = 0;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = SystemColors.ControlDarkDark;
            panelMenu.Controls.Add(btnExport);
            panelMenu.Controls.Add(btnImport);
            panelMenu.Controls.Add(btnDashboard);
            panelMenu.Controls.Add(btnReports);
            panelMenu.Controls.Add(btnCategories);
            panelMenu.Controls.Add(btnGoals);
            panelMenu.Controls.Add(btnFamily);
            panelMenu.Controls.Add(btnIncome);
            panelMenu.Controls.Add(btnExpenses);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(193, 729);
            panelMenu.TabIndex = 1;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 8F);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(12, 668);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(71, 26);
            btnExport.TabIndex = 8;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnImport
            // 
            btnImport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnImport.FlatStyle = FlatStyle.Flat;
            btnImport.Font = new Font("Segoe UI", 8F);
            btnImport.ForeColor = Color.White;
            btnImport.Location = new Point(12, 697);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(71, 26);
            btnImport.TabIndex = 7;
            btnImport.Text = "Import";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 14F);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(12, 18);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(167, 41);
            btnDashboard.TabIndex = 6;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnReports
            // 
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 14F);
            btnReports.ForeColor = Color.White;
            btnReports.Location = new Point(12, 300);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(167, 41);
            btnReports.TabIndex = 5;
            btnReports.Text = "Raporty";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnCategories
            // 
            btnCategories.FlatStyle = FlatStyle.Flat;
            btnCategories.Font = new Font("Segoe UI", 14F);
            btnCategories.ForeColor = Color.White;
            btnCategories.Location = new Point(12, 159);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(167, 41);
            btnCategories.TabIndex = 4;
            btnCategories.Text = "Kategorie";
            btnCategories.UseVisualStyleBackColor = true;
            btnCategories.Click += btnCategories_Click;
            // 
            // btnGoals
            // 
            btnGoals.FlatStyle = FlatStyle.Flat;
            btnGoals.Font = new Font("Segoe UI", 14F);
            btnGoals.ForeColor = Color.White;
            btnGoals.Location = new Point(12, 253);
            btnGoals.Name = "btnGoals";
            btnGoals.Size = new Size(167, 41);
            btnGoals.TabIndex = 3;
            btnGoals.Text = "Cele";
            btnGoals.UseVisualStyleBackColor = true;
            btnGoals.Click += btnGoals_Click;
            // 
            // btnFamily
            // 
            btnFamily.FlatStyle = FlatStyle.Flat;
            btnFamily.Font = new Font("Segoe UI", 14F);
            btnFamily.ForeColor = Color.White;
            btnFamily.Location = new Point(12, 206);
            btnFamily.Name = "btnFamily";
            btnFamily.Size = new Size(167, 41);
            btnFamily.TabIndex = 2;
            btnFamily.Text = "Rodzina";
            btnFamily.UseVisualStyleBackColor = true;
            btnFamily.Click += btnFamily_Click;
            // 
            // btnIncome
            // 
            btnIncome.FlatStyle = FlatStyle.Flat;
            btnIncome.Font = new Font("Segoe UI", 14F);
            btnIncome.ForeColor = Color.White;
            btnIncome.Location = new Point(12, 112);
            btnIncome.Name = "btnIncome";
            btnIncome.Size = new Size(167, 41);
            btnIncome.TabIndex = 1;
            btnIncome.Text = "Przychody";
            btnIncome.UseVisualStyleBackColor = true;
            btnIncome.Click += btnIncome_Click;
            // 
            // btnExpenses
            // 
            btnExpenses.FlatStyle = FlatStyle.Flat;
            btnExpenses.Font = new Font("Segoe UI", 14F);
            btnExpenses.ForeColor = Color.White;
            btnExpenses.Location = new Point(12, 65);
            btnExpenses.Name = "btnExpenses";
            btnExpenses.Size = new Size(167, 41);
            btnExpenses.TabIndex = 0;
            btnExpenses.Text = "Wydatki";
            btnExpenses.UseVisualStyleBackColor = true;
            btnExpenses.Click += btnExpenses_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(1008, 729);
            Controls.Add(panelMenu);
            Controls.Add(panelContent);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1024, 768);
            Name = "Form1";
            Text = "Budget Manager";
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContent;
        private Panel panelMenu;
        private Button btnExpenses;
        private Button btnIncome;
        private Button btnFamily;
        private Button btnGoals;
        private Button btnCategories;
        private Button btnReports;
        private Button btnDashboard;
        private Button btnImport;
        private Button btnExport;
    }
}
