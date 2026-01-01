using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using projekttest.Managers;
using projekttest.Models;

namespace projekttest.UserControls
{
    public partial class UserControlDashboard : UserControl
    {

        public UserControlDashboard()
        {
            InitializeComponent();
            SetupTimeFilter();
            CustomizeGridAppearance();
            LoadDashboardData();
        }

        private void SetupTimeFilter()
        {
            cmbTimeFilter.Items.Clear();
            foreach (TimePeriod period in Enum.GetValues(typeof(TimePeriod))) cmbTimeFilter.Items.Add(period);

            cmbTimeFilter.Format += (s, args) =>
            {
                if (args.Value is TimePeriod tp) args.Value = TimePeriodHelper.GetDisplayName(tp);
            };

            cmbTimeFilter.SelectedIndex = 0;

            cmbTimeFilter.SelectedIndexChanged -= CmbTimeFilter_SelectedIndexChanged;
            cmbTimeFilter.SelectedIndexChanged += CmbTimeFilter_SelectedIndexChanged;
        }

        private void CmbTimeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        public void LoadDashboardData()
        {
            if (cmbTimeFilter.SelectedItem == null) return;

            var selectedPeriod = (TimePeriod)cmbTimeFilter.SelectedItem;
            FinanceManager manager = new FinanceManager();

            decimal balance = manager.GetCurrentBalance(selectedPeriod);

            lblBalanceValue.Text = $"{balance:C2}";

            if (balance >= 0) lblBalanceValue.ForeColor = Color.SeaGreen;
            else lblBalanceValue.ForeColor = Color.Crimson;

            var transactions = manager.GetRecentTransactions(100, selectedPeriod);
            var displayList = transactions.Select(t => new
            {
                Data = t.Date.ToShortDateString(),
                Typ = t is Income ? "Przychód" : "Wydatek",
                Tytuł = t.Title,
                Kwota = t.Amount,
                Kategoria = t.Category,
            }).ToList();

            dgvRecent.DataSource = displayList;

            if (dgvRecent.Columns["Kwota"] != null)
            {
                dgvRecent.Columns["Kwota"].DefaultCellStyle.Format = "C2";
                dgvRecent.Columns["Kwota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void CustomizeGridAppearance()
        {
            dgvRecent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecent.RowHeadersVisible = false;
            dgvRecent.ReadOnly = true;
            dgvRecent.BackgroundColor = Color.WhiteSmoke;
            dgvRecent.BorderStyle = BorderStyle.None;
        }

        private void lblBalanceTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
