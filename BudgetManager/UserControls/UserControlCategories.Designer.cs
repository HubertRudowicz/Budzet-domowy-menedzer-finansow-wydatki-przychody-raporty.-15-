namespace projekttest.UserControls
{
    partial class UserControlCategories
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
            lstCategories = new ListBox();
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            btnAdd = new Button();
            label2 = new Label();
            btnDelete = new Button();
            txtNewCategory = new TextBox();
            label3 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lstCategories
            // 
            lstCategories.BorderStyle = BorderStyle.None;
            lstCategories.Font = new Font("Segoe UI", 14F);
            lstCategories.FormattingEnabled = true;
            lstCategories.ItemHeight = 25;
            lstCategories.Location = new Point(30, 243);
            lstCategories.Name = "lstCategories";
            lstCategories.Size = new Size(741, 150);
            lstCategories.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SeaGreen;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(798, 60);
            panel1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.ForeColor = Color.White;
            label1.Location = new Point(21, 9);
            label1.Name = "label1";
            label1.Size = new Size(339, 40);
            label1.TabIndex = 0;
            label1.Text = "Zarządzanie kategoriami";
            // 
            // panel2
            // 
            panel2.BackColor = Color.DimGray;
            panel2.Location = new Point(34, 141);
            panel2.Name = "panel2";
            panel2.Size = new Size(736, 1);
            panel2.TabIndex = 16;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.SeaGreen;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 11F);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(677, 148);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(93, 31);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Dodaj";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(30, 78);
            label2.Name = "label2";
            label2.Size = new Size(197, 25);
            label2.TabIndex = 9;
            label2.Text = "Dodaj nową kategorie";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.White;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderColor = Color.IndianRed;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 12F);
            btnDelete.ForeColor = Color.IndianRed;
            btnDelete.Location = new Point(36, 399);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(736, 34);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Usuń zaznaczone";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtNewCategory
            // 
            txtNewCategory.Location = new Point(34, 112);
            txtNewCategory.Name = "txtNewCategory";
            txtNewCategory.Size = new Size(368, 23);
            txtNewCategory.TabIndex = 11;
            txtNewCategory.Text = "Wpisz kategorie";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(30, 203);
            label3.Name = "label3";
            label3.Size = new Size(193, 25);
            label3.TabIndex = 13;
            label3.Text = "Kategorie w systemie:";
            // 
            // UserControlCategories
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lstCategories);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(btnAdd);
            Controls.Add(label2);
            Controls.Add(btnDelete);
            Controls.Add(txtNewCategory);
            Controls.Add(label3);
            Name = "UserControlCategories";
            Size = new Size(798, 448);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstCategories;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Button btnAdd;
        private Button btnClose;
        private Label label2;
        private Button btnDelete;
        private TextBox txtNewCategory;
        private Label label3;
    }
}
