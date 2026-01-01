namespace projekttest.UserControls
{
    partial class UserControlExpenses
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
            lblTotal = new Label();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            label1 = new Label();
            btnFilter = new Button();
            btnClearFilter = new Button();
            btnAdd = new FontAwesome.Sharp.IconButton();
            btnEdit = new FontAwesome.Sharp.IconButton();
            btnDelete = new FontAwesome.Sharp.IconButton();
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
            dgvExpenses.Location = new Point(30, 130);
            dgvExpenses.MultiSelect = false;
            dgvExpenses.Name = "dgvExpenses";
            dgvExpenses.RowHeadersVisible = false;
            dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpenses.Size = new Size(799, 287);
            dgvExpenses.TabIndex = 2;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 14F);
            lblTotal.Location = new Point(612, 428);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(56, 25);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Total:";
            // 
            // dtpFrom
            // 
            dtpFrom.Location = new Point(30, 101);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(200, 23);
            dtpFrom.TabIndex = 5;
            // 
            // dtpTo
            // 
            dtpTo.Location = new Point(236, 101);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(200, 23);
            dtpTo.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 83);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 7;
            label1.Text = "Filtrowanie po dacie";
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.WhiteSmoke;
            btnFilter.FlatAppearance.BorderColor = Color.LightGray;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Location = new Point(442, 98);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(75, 26);
            btnFilter.TabIndex = 8;
            btnFilter.Text = "Filtruj";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnClearFilter
            // 
            btnClearFilter.BackColor = Color.WhiteSmoke;
            btnClearFilter.FlatAppearance.BorderColor = Color.LightGray;
            btnClearFilter.FlatStyle = FlatStyle.Flat;
            btnClearFilter.Location = new Point(523, 98);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(75, 26);
            btnClearFilter.TabIndex = 9;
            btnClearFilter.Text = "Wyczyść";
            btnClearFilter.UseVisualStyleBackColor = false;
            btnClearFilter.Click += btnClearFilter_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(52, 152, 219);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 14F);
            btnAdd.ForeColor = Color.White;
            btnAdd.IconChar = FontAwesome.Sharp.IconChar.Add;
            btnAdd.IconColor = Color.White;
            btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAdd.IconSize = 24;
            btnAdd.Location = new Point(30, 13);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(177, 46);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Dodaj wydatek";
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(52, 152, 219);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 14F);
            btnEdit.ForeColor = Color.White;
            btnEdit.IconChar = FontAwesome.Sharp.IconChar.Pen;
            btnEdit.IconColor = Color.White;
            btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEdit.IconSize = 24;
            btnEdit.Location = new Point(213, 13);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(176, 46);
            btnEdit.TabIndex = 12;
            btnEdit.Text = "Edytuj wydatek";
            btnEdit.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(52, 152, 219);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 14F);
            btnDelete.ForeColor = Color.White;
            btnDelete.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnDelete.IconColor = Color.White;
            btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDelete.IconSize = 24;
            btnDelete.Location = new Point(395, 13);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(167, 46);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Usuń wydatek";
            btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearch.Location = new Point(612, 98);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Szukaj wydatku...";
            txtSearch.Size = new Size(217, 23);
            txtSearch.TabIndex = 14;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // UserControlExpenses
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(txtSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(btnClearFilter);
            Controls.Add(btnFilter);
            Controls.Add(label1);
            Controls.Add(dtpTo);
            Controls.Add(dtpFrom);
            Controls.Add(lblTotal);
            Controls.Add(dgvExpenses);
            Name = "UserControlExpenses";
            Size = new Size(867, 458);
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvExpenses;
        private Label lblTotal;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Label label1;
        private Button btnFilter;
        private Button btnClearFilter;
        private FontAwesome.Sharp.IconButton btnAdd;
        private FontAwesome.Sharp.IconButton btnEdit;
        private FontAwesome.Sharp.IconButton btnDelete;
        private TextBox txtSearch;
    }
}
