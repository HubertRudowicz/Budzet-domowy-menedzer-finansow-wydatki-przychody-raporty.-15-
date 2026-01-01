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

namespace projekttest.UserControls
{
    public partial class UserControlExpenses : UserControl
    {

        //private BindingList<Expense> _expenses = new BindingList<Expense>();



        public UserControlExpenses()
        {
            InitializeComponent();


            dgvExpenses.AutoGenerateColumns = false;

            SetupDataGridViewStyle();
            RefreshData();
        }

        private void RefreshData()
        {
            dgvExpenses.DataSource = null;
            var sortedList = GlobalData.AllExpenses.OrderByDescending(x => x.Date).ToList();

            dgvExpenses.DataSource = sortedList;

            SetupDataGridViewStyle();
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            decimal total = 0;
            if (dgvExpenses.DataSource is List<Expense> list)
            {
                total = list.Sum(x => x.Amount);
            }
            lblTotal.Text = $"Suma: {total:C2}";
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
            headerStyle.BackColor = Color.FromArgb(230, 230, 230);
            headerStyle.ForeColor = Color.Black;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.Padding = new Padding(5);
            dgvExpenses.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvExpenses.ColumnHeadersHeight = 40;

            dgvExpenses.DefaultCellStyle.BackColor = Color.White;
            dgvExpenses.DefaultCellStyle.ForeColor = Color.Black;
            dgvExpenses.DefaultCellStyle.Font = new Font("Segoe UI", 14);
            dgvExpenses.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 230, 255);
            dgvExpenses.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvExpenses.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            if (dgvExpenses.Columns.Count == 0)
            {
                // Kolumna DATA
                DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
                colDate.Name = "Date";
                colDate.DataPropertyName = "Date";
                colDate.HeaderText = "Data";
                colDate.Width = 100;
                colDate.DefaultCellStyle.Format = "dd.MM.yyyy";
                dgvExpenses.Columns.Add(colDate);

                // Kolumna KATEGORIA
                DataGridViewTextBoxColumn colCat = new DataGridViewTextBoxColumn();
                colCat.Name = "Category";
                colCat.DataPropertyName = "Category";
                colCat.HeaderText = "Kategoria";
                colCat.Width = 120;
                dgvExpenses.Columns.Add(colCat);

                // Kolumna OSOBA (Kto)
                DataGridViewTextBoxColumn colPerson = new DataGridViewTextBoxColumn();
                colPerson.Name = "Person";
                colPerson.DataPropertyName = "Person";
                colPerson.HeaderText = "Kto";
                colPerson.Width = 100;
                dgvExpenses.Columns.Add(colPerson);

                // Kolumna OPIS
                DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
                colDesc.Name = "Description";
                colDesc.DataPropertyName = "Description";
                colDesc.HeaderText = "Opis";
                colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Rozciągnij
                dgvExpenses.Columns.Add(colDesc);

                // Kolumna KWOTA
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
            using (var form = new FormAddExpense())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var newExpense = form.CreateExpense;

                    if (newExpense != null)
                    {
                        newExpense.Id = GlobalData.AllExpenses.Count + 1;
                        GlobalData.AllExpenses.Add(newExpense);
                        RefreshData();
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvExpenses.SelectedRows.Count > 0)
            {
                Expense selected = (Expense)dgvExpenses.SelectedRows[0].DataBoundItem;

                using (var form = new FormAddExpense(selected))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        RefreshData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Proszę najpierw zaznaczyć wydatek do edycji");
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvExpenses.SelectedRows.Count > 0)
            {
                var confirm = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczony wydatek?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (confirm == DialogResult.Yes)
                {
                    Expense selectedExpense = (Expense)dgvExpenses.SelectedRows[0].DataBoundItem;

                    GlobalData.AllExpenses.Remove(selectedExpense);
                    RefreshData();
                }
            }
            else
            {
                MessageBox.Show("Proszę najpierw zaznaczyć cały wiersz w tabeli");
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = dtpFrom.Value.Date;
            DateTime dateTo = dtpTo.Value.Date;

            if (dateTo < dateFrom)
            {
                MessageBox.Show("Data końcowa nie może być wcześniejsza niż początkowa.");
                return;
            }

            var filteredList = GlobalData.AllExpenses
                .Where(x => x.Date.Date >= dateFrom && x.Date.Date <= dateTo)
                .OrderByDescending(x => x.Date)
                .ToList();

            dgvExpenses.DataSource = filteredList;

            UpdateTotal();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today.AddMonths(-12);
            dtpTo.Value = DateTime.Today;

            RefreshData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                RefreshData();
                return;
            }

            var filtredList = GlobalData.AllExpenses.Where(x => 
                (x.Description != null && x.Description.ToLower().Contains(searchText)) ||
                (x.Category != null && x.Category.ToLower().Contains(searchText)) ||
                (x.Person != null && x.Person.ToLower().Contains(searchText)) ||
                x.Amount.ToString().Contains(searchText)
            ).OrderByDescending(x => x.Date).ToList();

            dgvExpenses.DataSource = null;
            dgvExpenses.DataSource = filtredList;

            UpdateTotal();
        }
    }
}
