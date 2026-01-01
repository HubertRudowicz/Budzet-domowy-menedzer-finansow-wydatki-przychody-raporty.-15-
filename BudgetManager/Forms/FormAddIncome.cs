using projekttest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekttest.Forms
{
    public partial class FormAddIncome : Form
    {
        private Income? _incomeToEdit;

        public DateTime Date => dtpDate.Value;
        public decimal Amount => nudAmount.Value;
        public string IncomeSource => txtDescription.Text;
        public string Person => cmbPerson.SelectedItem?.ToString() ?? "";
        public string Category => cmbCategory.SelectedItem?.ToString() ?? Models.SystemCategories.Other;
        public bool isRecurring => chkRecurring.Checked;
        public FormAddIncome()
        {
            InitializeComponent();

            SetupForm();

        }

        public FormAddIncome(Income income) : this()
        {
            _incomeToEdit = income;

            this.Text = "Edytuj przychód";
            btnSave.Text = "Zapisz zmiany";

            dtpDate.Value = income.Date;
            nudAmount.Value = income.Amount;
            txtDescription.Text = income.Source;
            chkRecurring.Checked = income.isRecurring;

            if (cmbPerson.Items.Contains(income.Person))
            {
                cmbPerson.SelectedItem = income.Person;
            }

            if (cmbCategory.Items.Contains(income.Category))
            {
                cmbCategory.SelectedItem = income.Category;
            }

            nudAmount.KeyPress += (s, e) =>
            {
                if (e.KeyChar == '.') e.KeyChar = ',';
            };

            nudAmount.Enter += (s, e) =>
            {
                nudAmount.Select(0, nudAmount.Text.Length);
            };
        }

        private void SetupForm()
        {
            cmbPerson.Items.Clear();
            foreach(var person in GlobalData.People) cmbPerson.Items.Add(person);
            if (cmbPerson.Items.Count > 0) cmbPerson.SelectedIndex = 0;

            cmbCategory.Items.Clear();
            
            foreach(var category in GlobalData.Categories) cmbCategory.Items.Add(category);

            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;

            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
        }
        private void btnSave_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtDescription.Text)) {
                MessageBox.Show("Proszę podać opis przychodu", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
                return;
            }

            if (nudAmount.Value <= 0)
            {
                MessageBox.Show("Kwota musi być większa od zera.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            if (_incomeToEdit != null)
            {
                _incomeToEdit.Date = dtpDate.Value;
                _incomeToEdit.Amount = nudAmount.Value;
                _incomeToEdit.Source = txtDescription.Text;
                _incomeToEdit.Person = cmbPerson.SelectedItem?.ToString();
                _incomeToEdit.Category = cmbCategory.SelectedItem?.ToString();
                _incomeToEdit.isRecurring = chkRecurring.Checked;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
