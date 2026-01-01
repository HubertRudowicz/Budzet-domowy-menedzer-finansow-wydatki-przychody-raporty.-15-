namespace projekttest.Forms
{
    partial class FormAddIncome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddIncome));
            panel1 = new Panel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dtpDate = new DateTimePicker();
            btnSave = new Button();
            chkRecurring = new CheckBox();
            cmbCategory = new ComboBox();
            txtDescription = new TextBox();
            nudAmount = new NumericUpDown();
            btnCancel = new Button();
            panel3 = new Panel();
            panel2 = new Panel();
            label6 = new Label();
            cmbPerson = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BackColor = Color.SeaGreen;
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(804, 60);
            panel1.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label5.ForeColor = Color.White;
            label5.Location = new Point(25, 15);
            label5.Name = "label5";
            label5.Size = new Size(253, 30);
            label5.TabIndex = 0;
            label5.Text = "SZCZEGÓŁY PRZYCHODU";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(25, 248);
            label4.Name = "label4";
            label4.Size = new Size(51, 25);
            label4.TabIndex = 23;
            label4.Text = "Data";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(25, 208);
            label3.Name = "label3";
            label3.Size = new Size(50, 25);
            label3.TabIndex = 22;
            label3.Text = "Opis";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(25, 133);
            label2.Name = "label2";
            label2.Size = new Size(93, 25);
            label2.TabIndex = 21;
            label2.Text = "Kategoria";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(25, 94);
            label1.Name = "label1";
            label1.Size = new Size(72, 25);
            label1.TabIndex = 20;
            label1.Text = "Kwota: ";
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(128, 248);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 23);
            dtpDate.TabIndex = 4;
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
            btnSave.Location = new Point(648, 357);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(144, 56);
            btnSave.TabIndex = 5;
            btnSave.Text = "Zapisz";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // chkRecurring
            // 
            chkRecurring.AutoSize = true;
            chkRecurring.Font = new Font("Segoe UI", 14F);
            chkRecurring.Location = new Point(25, 289);
            chkRecurring.Name = "chkRecurring";
            chkRecurring.RightToLeft = RightToLeft.Yes;
            chkRecurring.Size = new Size(261, 29);
            chkRecurring.TabIndex = 17;
            chkRecurring.Text = "Przychód stały (miesięczny)";
            chkRecurring.UseVisualStyleBackColor = true;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(124, 133);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(175, 23);
            cmbCategory.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.None;
            txtDescription.Location = new Point(125, 214);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(440, 16);
            txtDescription.TabIndex = 3;
            // 
            // nudAmount
            // 
            nudAmount.BorderStyle = BorderStyle.None;
            nudAmount.Location = new Point(124, 94);
            nudAmount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new Size(175, 19);
            nudAmount.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderColor = Color.DarkGray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnCancel.ForeColor = Color.DimGray;
            btnCancel.Location = new Point(25, 354);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(135, 54);
            btnCancel.TabIndex = 27;
            btnCancel.Text = "Anuluj";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Gray;
            panel3.Location = new Point(128, 234);
            panel3.Name = "panel3";
            panel3.Size = new Size(440, 1);
            panel3.TabIndex = 26;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gray;
            panel2.Location = new Point(124, 117);
            panel2.Name = "panel2";
            panel2.Size = new Size(175, 1);
            panel2.TabIndex = 25;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F);
            label6.Location = new Point(25, 172);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 28;
            label6.Text = "Osoba";
            // 
            // cmbPerson
            // 
            cmbPerson.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPerson.FormattingEnabled = true;
            cmbPerson.Location = new Point(124, 177);
            cmbPerson.Name = "cmbPerson";
            cmbPerson.Size = new Size(175, 23);
            cmbPerson.TabIndex = 2;
            // 
            // FormAddIncome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 425);
            Controls.Add(cmbPerson);
            Controls.Add(label6);
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
            Controls.Add(btnCancel);
            Controls.Add(panel3);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(820, 464);
            MinimumSize = new Size(820, 464);
            Name = "FormAddIncome";
            Text = "Szczegóły przychodu";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpDate;
        private Button btnSave;
        private CheckBox chkRecurring;
        private ComboBox cmbCategory;
        private TextBox txtDescription;
        private NumericUpDown nudAmount;
        private Button btnCancel;
        private Panel panel3;
        private Panel panel2;
        private Label label6;
        private ComboBox cmbPerson;
    }
}