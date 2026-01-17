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
using projekttest.Forms;

namespace projekttest.UserControls
{
    public partial class UserControlGoals : UserControl
    {
        private Managers.FinanceManager _financeManager;
        private BindingSource _bindingSource = new BindingSource();
        public UserControlGoals()
        {
            InitializeComponent();
            _financeManager = new Managers.FinanceManager();

            SetupButtons();

            SetupGrid();
            RefreshData();
        }

        private void SetupButtons()
        {
            btnContribute.BackColor = Color.SeaGreen;
            btnContribute.ForeColor = Color.White;
            btnContribute.FlatStyle = FlatStyle.Flat;
            btnContribute.FlatAppearance.BorderSize = 0;
        }

        private void SetupGrid()
        {
            this.BackColor = Color.FromArgb(248, 249, 250);

            dgvGoals.BackgroundColor = this.BackColor;
            dgvGoals.BorderStyle = BorderStyle.None;
            dgvGoals.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvGoals.GridColor = Color.FromArgb(230, 230, 230);

            dgvGoals.EnableHeadersVisualStyles = false;
            dgvGoals.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvGoals.ColumnHeadersDefaultCellStyle.BackColor = this.BackColor;
            dgvGoals.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
            dgvGoals.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvGoals.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvGoals.ColumnHeadersHeight = 50;

            dgvGoals.RowTemplate.Height = 60;

            dgvGoals.DefaultCellStyle.BackColor = Color.White;
            dgvGoals.DefaultCellStyle.ForeColor = Color.Black;
            dgvGoals.DefaultCellStyle.Font = new Font("Segoe UI", 11);

            dgvGoals.DefaultCellStyle.SelectionBackColor = Color.FromArgb(236, 245, 255);
            dgvGoals.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvGoals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGoals.AllowUserToAddRows = false;
            dgvGoals.RowHeadersVisible = false;

            dgvGoals.AutoGenerateColumns = false;
            dgvGoals.Columns.Clear();

            dgvGoals.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "NAZWA CELU", // Wielkie litery wyglądają prościej w nagłówkach
                Width = 220,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft, Padding = new Padding(15, 0, 0, 0) }
            });

            dgvGoals.Columns.Add(new DataGridViewImageColumn
            {
                Name = "ProgressBar",
                HeaderText = "POSTĘP",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvGoals.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StatusText",
                HeaderText = "POZOSTAŁO",
                Width = 180,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Padding = new Padding(0, 0, 20, 0), Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.DimGray }
            });

            dgvGoals.DataSource = _bindingSource;

            dgvGoals.CellFormatting -= DgvGoals_CellFormatting;
            dgvGoals.CellFormatting += DgvGoals_CellFormatting;

            dgvGoals.SelectionChanged -= dgvGoals_SelectionChanged;
            dgvGoals.SelectionChanged += dgvGoals_SelectionChanged;
        }

        private void RefreshData()
        {
            var goals = _financeManager.GetAllGoals();
            if (_bindingSource.DataSource != goals) _bindingSource.DataSource = goals;
            _bindingSource.ResetBindings(false);
        }

        private void btnContribute_Click(object sender, EventArgs e)
        {
            if (_financeManager.GetAllGoals().Count == 0)
            {
                MessageBox.Show("Najpierw dodaj jakiś cel oszczędnościowy");
                return;
            }

            SavingGoal preSelected = null;
            if (dgvGoals.SelectedRows.Count > 0)
            {
                preSelected = dgvGoals.SelectedRows[0].DataBoundItem as SavingGoal;
            }

            using (var form = new FormInputAmount(_financeManager.GetAllGoals(), preSelected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var targetGoal = form.SelectedGoal;
                    decimal amount = form.Amount;

                    if (targetGoal == null || amount <= 0) return;

                    targetGoal.CurrentAmount += amount;

                    var newExpense = new Expense
                    {
                        Id = GlobalData.AllExpenses.Count + 1,
                        Date = form.Date,
                        Amount = amount,
                        Category = new Category("Oszczędności", true), // Simplified handling, ideally fetch from manager
                        Person = new Person("Ja"), // Simplified
                        Description = $"Wpłata na cel: {targetGoal.Name}",
                        isRecurring = false
                    };

                    _financeManager.AddTransaction(newExpense);
                    _financeManager.SaveData(); // Update goal implicit save via repo ref or explicit save

                    RefreshData();
                    MessageBox.Show($"Wpłacono {amount:C2} na cel `{targetGoal.Name}`.\nDodano automatycznie wydatek.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void btnAddGoal_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Podaj nazwe celu:", "Nowy Cel", "Samochód");
            if (string.IsNullOrWhiteSpace(name)) return;

            string targetStr = Microsoft.VisualBasic.Interaction.InputBox("Podaj kwote docelową:", "Kwota Celu", "10000");
            if (decimal.TryParse(targetStr, out decimal target))
            {
                var newGoal = new SavingGoal
                {
                    Name = name,
                    TargetAmount = target,
                    CurrentAmount = 0
                };
                _financeManager.AddGoal(newGoal);
                RefreshData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is SavingGoal goal)
            {
                _financeManager.DeleteGoal(goal);
                RefreshData();
            }
        }

        private void DgvGoals_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvGoals.Columns[e.ColumnIndex].Name == "ProgressBar" && e.RowIndex >= 0)
            {
                if (e.RowIndex >= _bindingSource.Count) return;

                var goal = _bindingSource[e.RowIndex] as SavingGoal;
                
                if (goal != null)
                {
                    int w = dgvGoals.Columns[e.ColumnIndex].Width;
                    int h = dgvGoals.Rows[e.RowIndex].Height;

                    if (w <= 0 || h <= 0) return;

                    Bitmap bmp = new Bitmap(w, h);

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.White);

                        int margin = 12;
                        Rectangle rectFull = new Rectangle(margin, margin, w - 2 * margin, h - 2 * margin);

                        g.FillRectangle(new SolidBrush(Color.FromArgb(230, 230, 230)), rectFull);
                        //g.DrawRectangle(Pens.LightGray, rectFull);

                        int fillWidth = (int)((rectFull.Width * goal.ProgressPercentage) / 100.0);
                        if (fillWidth > 0)
                        {
                            Rectangle rectFill = new Rectangle(rectFull.X, rectFull.Y, fillWidth, rectFull.Height);

                            Brush color = Brushes.IndianRed;
                            if (goal.ProgressPercentage > 30) color = Brushes.Goldenrod;
                            if (goal.ProgressPercentage > 70) color = Brushes.SeaGreen;

                            g.FillRectangle(color, rectFill);
                        }

                        string text = $"{goal.ProgressPercentage}%";
                        Font f = new Font("Segoe UI", 9, FontStyle.Bold);
                        SizeF textSize = g.MeasureString(text, f);

                        float x = rectFull.X + (rectFull.Width - textSize.Width) / 2;
                        float y = rectFull.Y + (rectFull.Height - textSize.Height) / 2;

                        g.DrawString(text, f, Brushes.Black, x, y);
                    }

                    e.Value = bmp;
                }
            }
        }

        private void dgvGoals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var goal = dgvGoals.Rows[e.RowIndex].DataBoundItem as SavingGoal;
        }

        private void dgvGoals_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGoals.SelectedRows.Count == 0) return;

            var selectedGoal = dgvGoals.SelectedRows[0].DataBoundItem as SavingGoal;

            if (selectedGoal == null) return;
        }
    }
}
