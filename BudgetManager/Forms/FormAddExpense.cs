using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projekttest.Models;

namespace projekttest.Forms
{
    public partial class FormAddExpense : Form
    {
        public Expense? CreateExpense { get; private set; }
        private Expense? _expenseToEdit;

        public Person Person => cmbPerson.SelectedItem as Person;



        // ... we need to be careful with line numbers.
        // Let's replace the property first.


        public FormAddExpense()
        {
            InitializeComponent();

            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;

            nudAmount.KeyPress += (s, e) =>
            {
                if (e.KeyChar == '.') e.KeyChar = ',';
            };

            nudAmount.Enter += (s, e) =>
            {
                nudAmount.Select(0, nudAmount.Text.Length);
            };

            cmbPerson.Items.Clear();
            foreach(var p in GlobalData.People) cmbPerson.Items.Add(p);
            if (cmbPerson.Items.Count > 0) cmbPerson.SelectedIndex = 0;

            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            SetupForm();
        }

        public FormAddExpense(Expense expense) : this()
        {
            _expenseToEdit = expense;
            this.Text = "Edytuj wydatek";
            btnSave.Text = "Zapisz zmiany";

            dtpDate.Value = _expenseToEdit.Date;
            nudAmount.Value = _expenseToEdit.Amount;
            txtDescription.Text = _expenseToEdit.Description;
            chkRecurring.Checked = _expenseToEdit.isRecurring;

            if (cmbCategory.Items.Contains(expense.Category)) cmbCategory.SelectedItem = expense.Category;
            if (cmbPerson.Items.Contains(expense.Person)) cmbPerson.SelectedItem = expense.Person;
        }

        private void SetupForm()
        {
            cmbCategory.Items.Clear();

            foreach (var cat in GlobalData.Categories) cmbCategory.Items.Add(cat);
            if (cmbCategory.Items.Count == 0) cmbCategory.Items.Add(Models.SystemCategories.Other);

            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
            if (cmbPerson.Items.Count > 0) cmbPerson.SelectedIndex = 0;

            dtpDate.Value = DateTime.Today;
            dtpDate.MaxDate = DateTime.Today.AddDays(1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Proszę podać opis wydatku", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
                return;
            }
            if (nudAmount.Value <= 0)
            {
                MessageBox.Show("Kwota musi być większa od zera.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }
            if (_expenseToEdit == null)
            {
                // TRYB: DODAWANIE
                CreateExpense = new Expense
                {
                    Date = dtpDate.Value,
                    Description = txtDescription.Text,
                    Amount = nudAmount.Value,
                    Category = cmbCategory.SelectedItem as Category ?? new Category("Inne", true),
                    isRecurring = chkRecurring.Checked,
                    Person = this.Person ?? new Person("Nieznany")
                };
            } else
            {
                // TRYB: EDYCJA
                _expenseToEdit.Date = dtpDate.Value;
                _expenseToEdit.Description = txtDescription.Text;
                _expenseToEdit.Amount = nudAmount.Value;
                _expenseToEdit.Category = cmbCategory.SelectedItem as Category ?? new Category("Inne", true);
                _expenseToEdit.isRecurring = chkRecurring.Checked;

                _expenseToEdit.Person = this.Person ?? new Person("Nieznany");

                CreateExpense = _expenseToEdit;
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
