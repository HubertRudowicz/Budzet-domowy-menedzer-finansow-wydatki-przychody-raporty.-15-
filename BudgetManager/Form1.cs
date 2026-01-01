using projekttest.Models;
using projekttest.UserControls;
using System;
using System.Windows.Forms;

using projekttest.Managers;

namespace projekttest
{
    public partial class Form1 : Form
    {
        private Managers.FinanceManager _financeManager;
        public Form1()
        {
            InitializeComponent();
            _financeManager = new Managers.FinanceManager();

            panelMenu.Dock = DockStyle.Left;
            panelContent.Dock = DockStyle.Fill;
            panelContent.BringToFront();

            _financeManager.LoadTestData();
            _financeManager.ProcessRecurringTransactions();

            ShowUserControl(new UserControlExpenses());
        }

        

        private void ShowUserControl(UserControl control)
        {
            panelContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelContent.Controls.Add(control);
            control.BringToFront();
        }

        private void btnExpenses_Click(object sender, EventArgs e) => ShowUserControl(new UserControlExpenses());
        private void btnIncome_Click(object sender, EventArgs e) => ShowUserControl(new UserControlIncome());
        private void btnGoals_Click(object sender, EventArgs e) => ShowUserControl(new UserControlGoals());
        private void btnCategories_Click(object sender, EventArgs e) => ShowUserControl(new UserControlCategories());
        private void btnDashboard_Click(object sender, EventArgs e) => ShowUserControl(new UserControlDashboard());
        private void btnFamily_Click(object sender, EventArgs e)

        {
            using (var form = new Forms.FormManagePeople())
            {
                form.ShowDialog();
            }
        }
        private void btnReports_Click(object sender, EventArgs e)
        {
            var reports = new UserControls.UserControlReports();

            reports.LoadData();

            ShowUserControl(reports);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Managers.DataManager.ExportData();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Wczytanie danych nadpisze obecne transakcję. Czy chcesz kontynuować?", "Potwierdzenie importu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                Managers.DataManager.ImportData();

                ShowUserControl(new UserControlDashboard());
            }
        }
    }
}
