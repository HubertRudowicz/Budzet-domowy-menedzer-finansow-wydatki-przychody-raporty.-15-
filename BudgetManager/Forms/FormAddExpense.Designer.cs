namespace projekttest.Forms
{
    partial class FormAddExpense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddExpense));
            nudAmount = new NumericUpDown();
            txtDescription = new TextBox();
            cmbCategory = new ComboBox();
            chkRecurring = new CheckBox();
            btnSave = new Button();
            dtpDate = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            panel1 = new Panel();
            label5 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            btnCancel = new Button();
            label6 = new Label();
            cmbPerson = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // nudAmount
            // 
            nudAmount.BorderStyle = BorderStyle.None;
            nudAmount.Location = new Point(124, 88);
            nudAmount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new Size(120, 21);
            nudAmount.TabIndex = 0;
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.None;
            txtDescription.Location = new Point(124, 182);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(440, 18);
            txtDescription.TabIndex = 3;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(124, 118);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(175, 25);
            cmbCategory.TabIndex = 1;
            // 
            // chkRecurring
            // 
            chkRecurring.AutoSize = true;
            chkRecurring.Font = new Font("Segoe UI", 14F);
            chkRecurring.Location = new Point(25, 247);
            chkRecurring.Name = "chkRecurring";
            chkRecurring.RightToLeft = RightToLeft.Yes;
            chkRecurring.Size = new Size(184, 29);
            chkRecurring.TabIndex = 3;
            chkRecurring.Text = "Wydatek cykliczny";
            chkRecurring.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.Cursor = Cursors.Hand;
            btnSave.DialogResult = DialogResult.OK;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(648, 303);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(144, 56);
            btnSave.TabIndex = 5;
            btnSave.Text = "Zapisz";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(128, 206);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 25);
            dtpDate.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(25, 88);
            label1.Name = "label1";
            label1.Size = new Size(72, 25);
            label1.TabIndex = 6;
            label1.Text = "Kwota: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(25, 118);
            label2.Name = "label2";
            label2.Size = new Size(93, 25);
            label2.TabIndex = 7;
            label2.Text = "Kategoria";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(24, 176);
            label3.Name = "label3";
            label3.Size = new Size(50, 25);
            label3.TabIndex = 8;
            label3.Text = "Opis";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(25, 206);
            label4.Name = "label4";
            label4.Size = new Size(51, 25);
            label4.TabIndex = 9;
            label4.Text = "Data";
            // 
            // panel1
            // 
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BackColor = Color.FromArgb(41, 128, 185);
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(804, 60);
            panel1.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label5.ForeColor = Color.White;
            label5.Location = new Point(25, 15);
            label5.Name = "label5";
            label5.Size = new Size(230, 30);
            label5.TabIndex = 0;
            label5.Text = "SZCZEGÓŁY WYDATKU";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gray;
            panel2.Location = new Point(124, 111);
            panel2.Name = "panel2";
            panel2.Size = new Size(120, 1);
            panel2.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Gray;
            panel3.Location = new Point(127, 202);
            panel3.Name = "panel3";
            panel3.Size = new Size(440, 1);
            panel3.TabIndex = 12;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderColor = Color.DarkGray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnCancel.ForeColor = Color.DimGray;
            btnCancel.Location = new Point(25, 300);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(135, 54);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Anuluj";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F);
            label6.Location = new Point(24, 149);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 14;
            label6.Text = "Osoba";
            // 
            // cmbPerson
            // 
            cmbPerson.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPerson.FormattingEnabled = true;
            cmbPerson.Location = new Point(124, 152);
            cmbPerson.Name = "cmbPerson";
            cmbPerson.Size = new Size(121, 25);
            cmbPerson.TabIndex = 2;
            // 
            // FormAddExpense
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(804, 371);
            Controls.Add(cmbPerson);
            Controls.Add(label6);
            Controls.Add(btnCancel);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpDate);
            Controls.Add(btnSave);
            Controls.Add(chkRecurring);
            Controls.Add(cmbCategory);
            Controls.Add(txtDescription);
            Controls.Add(nudAmount);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(820, 410);
            MinimumSize = new Size(820, 410);
            Name = "FormAddExpense";
            StartPosition = FormStartPosition.WindowsDefaultBounds;
            Text = "Szczegóły wydatku";
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown nudAmount;
        private TextBox txtDescription;
        private ComboBox cmbCategory;
        private CheckBox chkRecurring;
        private Button btnSave;
        private DateTimePicker dtpDate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Panel panel1;
        private Label label5;
        private Panel panel2;
        private Panel panel3;
        private Button btnCancel;
        private Label label6;
        private ComboBox cmbPerson;
    }
}