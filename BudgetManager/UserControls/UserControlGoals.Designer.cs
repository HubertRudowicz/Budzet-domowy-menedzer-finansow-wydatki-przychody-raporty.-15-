namespace projekttest.UserControls
{
    partial class UserControlGoals
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
            dgvGoals = new DataGridView();
            panel1 = new Panel();
            btnDelete = new Button();
            btnContribute = new Button();
            btnAddGoal = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvGoals).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvGoals
            // 
            dgvGoals.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvGoals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGoals.Location = new Point(0, 60);
            dgvGoals.Name = "dgvGoals";
            dgvGoals.Size = new Size(715, 419);
            dgvGoals.TabIndex = 0;
            dgvGoals.CellClick += dgvGoals_CellClick;
            dgvGoals.SelectionChanged += dgvGoals_SelectionChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DimGray;
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnContribute);
            panel1.Controls.Add(btnAddGoal);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(715, 60);
            panel1.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.Menu;
            btnDelete.FlatAppearance.BorderColor = Color.DimGray;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 14F);
            btnDelete.Location = new Point(298, 11);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(134, 38);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Usuń cel";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnContribute
            // 
            btnContribute.BackColor = Color.SeaGreen;
            btnContribute.FlatAppearance.BorderColor = Color.DimGray;
            btnContribute.FlatStyle = FlatStyle.Flat;
            btnContribute.Font = new Font("Segoe UI", 14F);
            btnContribute.Location = new Point(158, 11);
            btnContribute.Name = "btnContribute";
            btnContribute.Size = new Size(134, 38);
            btnContribute.TabIndex = 1;
            btnContribute.Text = "Wpłać na cel";
            btnContribute.UseVisualStyleBackColor = false;
            btnContribute.Click += btnContribute_Click;
            // 
            // btnAddGoal
            // 
            btnAddGoal.BackColor = SystemColors.Menu;
            btnAddGoal.FlatAppearance.BorderColor = Color.DimGray;
            btnAddGoal.FlatStyle = FlatStyle.Flat;
            btnAddGoal.Font = new Font("Segoe UI", 14F);
            btnAddGoal.Location = new Point(18, 11);
            btnAddGoal.Name = "btnAddGoal";
            btnAddGoal.Size = new Size(134, 38);
            btnAddGoal.TabIndex = 0;
            btnAddGoal.Text = "Nowy Cel";
            btnAddGoal.UseVisualStyleBackColor = false;
            btnAddGoal.Click += btnAddGoal_Click;
            // 
            // UserControlGoals
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(dgvGoals);
            Controls.Add(panel1);
            Name = "UserControlGoals";
            Size = new Size(715, 479);
            ((System.ComponentModel.ISupportInitialize)dgvGoals).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvGoals;
        private Panel panel1;
        private Button btnDelete;
        private Button btnContribute;
        private Button btnAddGoal;
    }
}
