using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using projekttest.Forms;
using projekttest.Models;
using System.Net.Sockets;

namespace projekttest.UserControls
{
    public partial class UserControlIncome : UserControl
    {
        private Managers.FinanceManager _financeManager;
        public UserControlIncome()
        {
            InitializeComponent();
            _financeManager = new Managers.FinanceManager();

            dgvExpenses.AutoGenerateColumns = false;

            SetupDataGridViewStyle();
            RefreshData();
        }

        private void RefreshData()
        {
            dgvExpenses.DataSource = null;
            var sortedList = _financeManager.GetRecentTransactions(1000, TimePeriod.AllTime)
                .OfType<Income>()
                .OrderByDescending(x => x.Date)
                .ToList();

            dgvExpenses.DataSource = sortedList;

            SetupDataGridViewStyle();
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            decimal total = 0;
            if (dgvExpenses.DataSource is List<Income> list)
            {
                total = list.Sum(x => x.Amount);
            }
            if (lblTotal != null)
            {
                lblTotal.Text = $"Suma przychodów: {total:C2}";
                lblTotal.ForeColor = Color.SeaGreen;
            }
        }

        private void SetupDataGridViewStyle()
        {
            dgvExpenses.BackgroundColor = Color.White;
            dgvExpenses.BorderStyle = BorderStyle.None;
            dgvExpenses.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvExpenses.EnableHeadersVisualStyles = false;
            dgvExpenses.RowHeadersVisible = false;
            dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpenses.ReadOnly = true;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.SeaGreen;
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.Padding = new Padding(5);
            dgvExpenses.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvExpenses.ColumnHeadersHeight = 40;

            dgvExpenses.DefaultCellStyle.BackColor = Color.White;
            dgvExpenses.DefaultCellStyle.ForeColor = Color.Black;
            dgvExpenses.DefaultCellStyle.Font = new Font("Segoe UI", 14);
            dgvExpenses.DefaultCellStyle.SelectionBackColor = Color.FromArgb(95, 255, 95);
            dgvExpenses.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvExpenses.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 250, 245);



            if (dgvExpenses.Columns.Count == 0)
            {
                // Data
                DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
                colDate.Name = "Date";
                colDate.DataPropertyName = "Date";
                colDate.HeaderText = "Data";
                colDate.Width = 100;
                colDate.DefaultCellStyle.Format = "dd.MM.yyyy";
                dgvExpenses.Columns.Add(colDate);

                // Kategoria
                DataGridViewTextBoxColumn colCat = new DataGridViewTextBoxColumn();
                colCat.Name = "Category";
                colCat.DataPropertyName = "Category";
                colCat.HeaderText = "Kategoria";
                colCat.Width = 120;
                dgvExpenses.Columns.Add(colCat);

                // Osoba
                DataGridViewTextBoxColumn colPerson = new DataGridViewTextBoxColumn();
                colPerson.Name = "Person";
                colPerson.DataPropertyName = "Person";
                colPerson.HeaderText = "Kto";
                colPerson.Width = 100;
                dgvExpenses.Columns.Add(colPerson);

                // Opis 
                DataGridViewTextBoxColumn colSource = new DataGridViewTextBoxColumn();
                colSource.Name = "Source";
                colSource.DataPropertyName = "Source";
                colSource.HeaderText = "Opis";
                colSource.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvExpenses.Columns.Add(colSource);

                // Kwota
                DataGridViewTextBoxColumn colAmount = new DataGridViewTextBoxColumn();
                colAmount.Name = "Amount";
                colAmount.DataPropertyName = "Amount";
                colAmount.HeaderText = "Kwota";
                colAmount.DefaultCellStyle.Format = "C2";
                colAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvExpenses.Columns.Add(colAmount);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new FormAddIncome())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var newIncome = new Income
                    {
                        Id = GlobalData.AllIncomes.Count + 1,
                        Source = form.IncomeSource,
                        Amount = form.Amount,
                        Date = form.Date,
                        Person = form.Person,
                        Category = form.Category,
                        isRecurring = form.isRecurring
                    };
                    _financeManager.AddTransaction(newIncome);
                    RefreshData();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvExpenses.SelectedRows.Count > 0)
            {
                Income selectedIncome = (Income)dgvExpenses.SelectedRows[0].DataBoundItem;

                using (var form = new Forms.FormAddIncome(selectedIncome))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        selectedIncome.Amount = form.Amount;
                        selectedIncome.Date = form.Date;
                        selectedIncome.Source = form.IncomeSource;
                        selectedIncome.Person = form.Person;
                        selectedIncome.Category = form.Category;

                        dgvExpenses.Refresh();
                        RefreshData();
                    }
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvExpenses.SelectedRows.Count > 0)
            {
                var confirm = MessageBox.Show("Usunąć zaznaczony przychód?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (confirm == DialogResult.Yes)
                {
                    var selected = (Income)dgvExpenses.SelectedRows[0].DataBoundItem;
                    _financeManager.DeleteTransaction(selected);
                    RefreshData();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                RefreshData();
                return;
            }

            var allIncomes = _financeManager.GetAllIncomes();
            var filtredList = allIncomes.Where(x =>
                (x.Source != null && x.Source.ToLower().Contains(searchText)) ||
                (x.Category != null && x.Category.Name.ToLower().Contains(searchText)) ||
                (x.Person != null && x.Person.Name.ToLower().Contains(searchText)) ||
                x.Amount.ToString().Contains(searchText)
            ).OrderByDescending(x => x.Date).ToList();

            dgvExpenses.DataSource = null;
            dgvExpenses.DataSource = filtredList;

            UpdateTotal();
        }
    }
}
