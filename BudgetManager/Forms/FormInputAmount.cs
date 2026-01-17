using projekttest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekttest.Forms
{
    public partial class FormInputAmount : Form
    {
        public decimal Amount => nudAmount.Value;
        public DateTime Date => DateTime.Now;
        public SavingGoal SelectedGoal => (SavingGoal)cmbGoals.SelectedItem;


        public FormInputAmount(List<SavingGoal> availableGoals, SavingGoal defaultGoal = null)
        {
            InitializeComponent();
            InitializeComponentManual();
            LoadGoals(availableGoals, defaultGoal);
            nudAmount.KeyPress += (s, e) =>
            {
                if (e.KeyChar == '.') e.KeyChar = ',';
            };

            nudAmount.Enter += (s, e) =>
            {
                nudAmount.Select(0, nudAmount.Text.Length);
            };
        }

        private void LoadGoals(List<SavingGoal> goals, SavingGoal defaultGoal)
        {
            nudAmount.Minimum = 0;
            nudAmount.DecimalPlaces = 2;
            cmbGoals.DataSource = null;
            cmbGoals.DataSource = goals;
            cmbGoals.DisplayMember = "Name";

            if (defaultGoal != null)
            {
                cmbGoals.SelectedItem = defaultGoal;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (cmbGoals.SelectedItem == null)
            {
                MessageBox.Show("Musisz wybrać cel z listy!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudAmount.Value <= 0)
            {
                MessageBox.Show("Kwota wpłaty musi być większa niż 0!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InitializeComponentManual()
        {
            this.Text = "Wpłata na cel oszczędnościowy";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;
        }
    }
}
