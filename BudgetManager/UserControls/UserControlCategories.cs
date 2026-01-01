using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.CompilerServices;

using projekttest.Managers;

namespace projekttest.UserControls
{
    public partial class UserControlCategories : UserControl
    {
        private const string PlaceholderText = "Wpisz nazwę kategorii...";
        public UserControlCategories()
        {
            InitializeComponent();
            RefreshList();

            SetupPlaceholder();
        }

        private void RefreshList()
        {
            lstCategories.Items.Clear();
            foreach (var cat in GlobalData.Categories)
            {
                lstCategories.Items.Add(cat);
            }
        }

        private void SetupPlaceholder()
        {
            txtNewCategory.Text = PlaceholderText;
            txtNewCategory.ForeColor = Color.Gray;

            txtNewCategory.Enter += TxtNewCategory_Enter;
            txtNewCategory.Leave += TxtNewCategory_Leave;

        }

        private void TxtNewCategory_Enter(object sender, EventArgs e)
        {
            if (txtNewCategory.Text == PlaceholderText)
            {
                txtNewCategory.Text = "";
                txtNewCategory.ForeColor = Color.Black;
            }
        }

        private void TxtNewCategory_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewCategory.Text))
            {
                txtNewCategory.Text = PlaceholderText;
                txtNewCategory.ForeColor = Color.Gray;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newCat = txtNewCategory.Text.Trim();

            if (string.IsNullOrEmpty(newCat) || newCat == "Wpisz nazwę kategorii..." || newCat == "Wpisz nazwe kategorii...")
            {
                MessageBox.Show("Wpisz nazwę kategorii.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (GlobalData.Categories.Contains(newCat))
            {
                MessageBox.Show("Taka kategoria już istnieje.", "Duplikat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            GlobalData.Categories.Add(newCat);
            RefreshList();

            txtNewCategory.Text = PlaceholderText;
            txtNewCategory.ForeColor = Color.Gray;
            this.ActiveControl = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem == null)
            {
                MessageBox.Show("Proszę zaznaczyć kategorię.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string selectedCat = lstCategories.SelectedItem.ToString();

            if (Models.SystemCategories.ProtectedCategories.Contains(selectedCat))
            {
                MessageBox.Show("Nie można usunąć kategorii systemowej.");
                return;
            }

            FinanceManager manager = new FinanceManager();
            int count = manager.GetCategoryUsageCount(selectedCat);

            if (count > 0)
            {
                var result = MessageBox.Show($"Kategoria '{selectedCat}' jest używana w {count} transakcjach. \n\n" +
                    $"Czy chcesz przenieść kategorie używanych transakcji na 'Inne'?",
                    "Wymagana Migracja Danych",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    manager.DeleteCategoryAndMigrate(selectedCat, Models.SystemCategories.Other);
                    RefreshList();
                }
            } else
            {
                if (MessageBox.Show($"Usunąć '{selectedCat}'?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    GlobalData.Categories.Remove(selectedCat);
                    RefreshList();
                }
            }
        }
    }
}