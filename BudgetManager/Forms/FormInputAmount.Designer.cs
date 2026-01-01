namespace projekttest.Forms
{
    partial class FormInputAmount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInputAmount));
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            nudAmount = new NumericUpDown();
            label3 = new Label();
            dtpDate = new DateTimePicker();
            label4 = new Label();
            cmbGoals = new ComboBox();
            btnOk = new Button();
            btnCancel = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Chocolate;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(554, 60);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.ForeColor = Color.White;
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(401, 37);
            label1.TabIndex = 0;
            label1.Text = "Wpłata na cel oszczędnościowy";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(137, 92);
            label2.Name = "label2";
            label2.Size = new Size(127, 25);
            label2.TabIndex = 1;
            label2.Text = "Kwota wpłaty:";
            // 
            // nudAmount
            // 
            nudAmount.DecimalPlaces = 2;
            nudAmount.Location = new Point(270, 92);
            nudAmount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new Size(120, 23);
            nudAmount.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(209, 127);
            label3.Name = "label3";
            label3.Size = new Size(55, 25);
            label3.TabIndex = 3;
            label3.Text = "Data:";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(270, 129);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 23);
            dtpDate.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(71, 165);
            label4.Name = "label4";
            label4.Size = new Size(193, 25);
            label4.TabIndex = 5;
            label4.Text = "Cel oszczędnościowy:";
            // 
            // cmbGoals
            // 
            cmbGoals.FormattingEnabled = true;
            cmbGoals.Location = new Point(270, 167);
            cmbGoals.Name = "cmbGoals";
            cmbGoals.Size = new Size(121, 23);
            cmbGoals.TabIndex = 6;
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.SeaGreen;
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Segoe UI", 14F);
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(397, 218);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(145, 51);
            btnOk.TabIndex = 7;
            btnOk.Text = "Zatwierdź";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += BtnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Firebrick;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 14F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(14, 224);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(145, 51);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Anuluj";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // FormInputAmount
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 281);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(cmbGoals);
            Controls.Add(label4);
            Controls.Add(dtpDate);
            Controls.Add(label3);
            Controls.Add(nudAmount);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(570, 320);
            Name = "FormInputAmount";
            Text = "Wpłata na cel oszczędnościowy";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private NumericUpDown nudAmount;
        private Label label3;
        private DateTimePicker dtpDate;
        private Label label4;
        private ComboBox cmbGoals;
        private Button btnOk;
        private Button btnCancel;
    }
}