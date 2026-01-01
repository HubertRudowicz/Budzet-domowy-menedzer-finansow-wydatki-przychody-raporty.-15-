namespace projekttest.UserControls
{
    partial class UserControlIncome
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvExpenses = new DataGridView();
            btnDelete = new FontAwesome.Sharp.IconButton();
            btnEdit = new FontAwesome.Sharp.IconButton();
            btnAdd = new FontAwesome.Sharp.IconButton();
            btnClearFilter = new Button();
            btnFilter = new Button();
            label1 = new Label();
            dtpTo = new DateTimePicker();
            dtpFrom = new DateTimePicker();
            lblTotal = new Label();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).BeginInit();
            SuspendLayout();
            // 
            // dgvExpenses
            // 
            dgvExpenses.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dgvExpenses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvExpenses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExpenses.BackgroundColor = Color.FromArgb(248, 249, 250);
            dgvExpenses.BorderStyle = BorderStyle.None;
            dgvExpenses.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvExpenses.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.Menu;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvExpenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExpenses.EnableHeadersVisualStyles = false;
            dgvExpenses.Location = new Point(28, 130);
            dgvExpenses.MultiSelect = false;
            dgvExpenses.Name = "dgvExpenses";
            dgvExpenses.RowHeadersVisible = false;
            dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpenses.Size = new Size(799, 297);
            dgvExpenses.TabIndex = 14;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.SeaGreen;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 14F);
            btnDelete.ForeColor = Color.White;
            btnDelete.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnDelete.IconColor = Color.White;
            btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDelete.IconSize = 24;
            btnDelete.Location = new Point(404, 13);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(178, 46);
            btnDelete.TabIndex = 23;
            btnDelete.Text = "Usuń przychód";
            btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.SeaGreen;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 14F);
            btnEdit.ForeColor = Color.White;
            btnEdit.IconChar = FontAwesome.Sharp.IconChar.Pen;
            btnEdit.IconColor = Color.White;
            btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEdit.IconSize = 24;
            btnEdit.Location = new Point(211, 13);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(187, 46);
            btnEdit.TabIndex = 22;
            btnEdit.Text = "Edytuj przychód";
            btnEdit.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.SeaGreen;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 14F);
            btnAdd.ForeColor = Color.White;
            btnAdd.IconChar = FontAwesome.Sharp.IconChar.Add;
            btnAdd.IconColor = Color.White;
            btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAdd.IconSize = 24;
            btnAdd.Location = new Point(28, 13);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(177, 46);
            btnAdd.TabIndex = 21;
            btnAdd.Text = "Dodaj przychód";
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnClearFilter
            // 
            btnClearFilter.BackColor = Color.WhiteSmoke;
            btnClearFilter.FlatAppearance.BorderColor = Color.LightGray;
            btnClearFilter.FlatStyle = FlatStyle.Flat;
            btnClearFilter.Location = new Point(521, 98);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(75, 26);
            btnClearFilter.TabIndex = 20;
            btnClearFilter.Text = "Wyczyść";
            btnClearFilter.UseVisualStyleBackColor = false;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.WhiteSmoke;
            btnFilter.FlatAppearance.BorderColor = Color.LightGray;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Location = new Point(440, 98);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(75, 26);
            btnFilter.TabIndex = 19;
            btnFilter.Text = "Filtruj";
            btnFilter.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 83);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 18;
            label1.Text = "Filtrowanie po dacie";
            // 
            // dtpTo
            // 
            dtpTo.Location = new Point(234, 101);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(200, 23);
            dtpTo.TabIndex = 17;
            // 
            // dtpFrom
            // 
            dtpFrom.Location = new Point(28, 101);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(200, 23);
            dtpFrom.TabIndex = 16;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 14F);
            lblTotal.Location = new Point(613, 430);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(56, 25);
            lblTotal.TabIndex = 15;
            lblTotal.Text = "Total:";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Location = new Point(610, 101);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Szukaj przychodu...";
            txtSearch.Size = new Size(217, 23);
            txtSearch.TabIndex = 24;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // UserControlIncome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtSearch);
            Controls.Add(dgvExpenses);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(btnClearFilter);
            Controls.Add(btnFilter);
            Controls.Add(label1);
            Controls.Add(dtpTo);
            Controls.Add(dtpFrom);
            Controls.Add(lblTotal);
            Name = "UserControlIncome";
            Size = new Size(868, 459);
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvExpenses;
        private FontAwesome.Sharp.IconButton btnDelete;
        private FontAwesome.Sharp.IconButton btnEdit;
        private FontAwesome.Sharp.IconButton btnAdd;
        private Button btnClearFilter;
        private Button btnFilter;
        private Label label1;
        private DateTimePicker dtpTo;
        private DateTimePicker dtpFrom;
        private Label lblTotal;
        private TextBox txtSearch;
    }
}
