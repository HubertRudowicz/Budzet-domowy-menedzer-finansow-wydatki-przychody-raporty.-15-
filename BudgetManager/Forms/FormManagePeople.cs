using projekttest.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekttest.Forms
{
    public partial class FormManagePeople : Form
    {
        private const string PlaceholderText = "Wpisz imię...";

        public FormManagePeople()
        {
            InitializeComponent();
            SetupPlaceholder();
            ReloadList();
        }

        private void ReloadList()
        {
            lstPeople.Items.Clear();
            foreach (var person in GlobalData.People) lstPeople.Items.Add(person);
        }

        private void SetupPlaceholder()
        {
            txtName.Text = PlaceholderText;
            txtName.ForeColor = Color.Gray;

            txtName.Enter += TxtName_Enter;
            txtName.Leave += TxtName_Leave;
        }

        private void TxtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == PlaceholderText)
            {
                txtName.Text = "";
                txtName.ForeColor = Color.Black;
            }
        }

        private void TxtName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.Text = PlaceholderText;
                txtName.ForeColor = Color.Gray;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();

            if (!string.IsNullOrWhiteSpace(name) && name != PlaceholderText)
            {
                if (!GlobalData.People.Contains(name))
                {
                    GlobalData.People.Add(name);

                    txtName.Text = PlaceholderText;
                    txtName.ForeColor = Color.Gray;

                    lstPeople.Focus();
                    ReloadList();
                }
                else
                {
                    MessageBox.Show("Ta osoba jest już na liście", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstPeople.SelectedItem == null)
            {
                MessageBox.Show("Proszę zaznaczyć członka rodziny.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string selected = lstPeople.SelectedItem.ToString();

            if (string.IsNullOrEmpty(selected)) return;

            FinanceManager manager = new FinanceManager();

            int usageCount = manager.GetPersonTransactionCount(selected);

            if (usageCount > 0)
            {
                var result = MessageBox.Show($"Osoba '{selected}' posiada {usageCount} przypisanych transakcji. \n\n" +
                    "Czy chcesz usunąć tę osobę WRAZ ZE WSZYSTKIMI jej wydatkami i przychodami?\n" +
                    "(Tej operacji nie da się cofnąć)",
                    "Wykryto powiązane dane",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, 
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    manager.DeletePersonWithHistory(selected); ;
                    MessageBox.Show("Osoba usunięta", "Sukces");
                }
            } else
            {
                var result = MessageBox.Show($"Czy chcesz usunąć osobę: {selected}?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes) GlobalData.People.Remove(selected);
            }
            ReloadList();         
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
