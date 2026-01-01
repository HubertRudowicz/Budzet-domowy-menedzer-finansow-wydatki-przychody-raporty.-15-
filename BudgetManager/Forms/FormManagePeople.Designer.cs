namespace projekttest.Forms
{
    partial class FormManagePeople
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManagePeople));
            panel1 = new Panel();
            label1 = new Label();
            lstPeople = new ListBox();
            label3 = new Label();
            btnDelete = new Button();
            btnClose = new Button();
            txtName = new TextBox();
            label2 = new Label();
            btnAdd = new Button();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.SeaGreen;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(806, 60);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.ForeColor = Color.White;
            label1.Location = new Point(21, 9);
            label1.Name = "label1";
            label1.Size = new Size(280, 40);
            label1.TabIndex = 0;
            label1.Text = "Zarządzanie rodziną";
            label1.Click += label1_Click;
            // 
            // lstPeople
            // 
            lstPeople.BorderStyle = BorderStyle.None;
            lstPeople.Font = new Font("Segoe UI", 14F);
            lstPeople.FormattingEnabled = true;
            lstPeople.ItemHeight = 25;
            lstPeople.Location = new Point(30, 280);
            lstPeople.Name = "lstPeople";
            lstPeople.Size = new Size(741, 150);
            lstPeople.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(30, 240);
            label3.Name = "label3";
            label3.Size = new Size(175, 25);
            label3.TabIndex = 4;
            label3.Text = "Obecni członkowie:";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.White;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderColor = Color.IndianRed;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 12F);
            btnDelete.ForeColor = Color.IndianRed;
            btnDelete.Location = new Point(36, 436);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(736, 34);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Usuń zaznaczone";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.OK;
            btnClose.Font = new Font("Segoe UI", 14F);
            btnClose.Location = new Point(642, 495);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(130, 46);
            btnClose.TabIndex = 4;
            btnClose.Text = "Zamknij";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(36, 119);
            txtName.Name = "txtName";
            txtName.Size = new Size(368, 23);
            txtName.TabIndex = 0;
            txtName.Text = "Wpisz imie..";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(32, 85);
            label2.Name = "label2";
            label2.Size = new Size(169, 25);
            label2.TabIndex = 0;
            label2.Text = "Dodaj nową osobę";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.SeaGreen;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 11F);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(679, 155);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(93, 31);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Dodaj";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DimGray;
            panel2.Location = new Point(36, 148);
            panel2.Name = "panel2";
            panel2.Size = new Size(736, 1);
            panel2.TabIndex = 7;
            // 
            // FormManagePeople
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(806, 553);
            Controls.Add(panel2);
            Controls.Add(btnAdd);
            Controls.Add(btnClose);
            Controls.Add(label2);
            Controls.Add(btnDelete);
            Controls.Add(txtName);
            Controls.Add(label3);
            Controls.Add(lstPeople);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(822, 592);
            Name = "FormManagePeople";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Zarządzanie rodziną";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private ListBox lstPeople;
        private Label label3;
        private Button btnDelete;
        private Button btnClose;
        private TextBox txtName;
        private Label label2;
        private Button btnAdd;
        private Panel panel2;
    }
}