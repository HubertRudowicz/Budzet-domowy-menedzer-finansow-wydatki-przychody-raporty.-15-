using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media.Animation;
using projekttest.Managers;
using projekttest.Models;

namespace projekttest.UserControls
{
    public partial class UserControlReports : UserControl
    {

        private Chart chartPie;
        private Chart chartBar;
        private Label lblBalance;
        private Panel pnlSummary;
        private ComboBox cmbTimeFilter;
        private TableLayoutPanel layoutPanel;

        private class ComboItem
        {
            public string Text { get; set; }
            public TimePeriod value { get; set; }
            public override string ToString() => Text;
        }
        public UserControlReports()
        {
            InitializeComponent();

            this.BackColor = Color.WhiteSmoke;
            this.Padding = new Padding(20);

            InitializeDashboard();

            LoadData();
        }

        private void InitializeDashboard()
        {
            pnlSummary = new Panel();
            pnlSummary.Dock = DockStyle.Top;
            pnlSummary.Height = 60;
            pnlSummary.BackColor = Color.White;
            pnlSummary.Margin = new Padding(0,0,0,20);

            lblBalance = new Label();
            lblBalance.AutoSize = false;
            lblBalance.Dock = DockStyle.Fill;
            lblBalance.TextAlign = ContentAlignment.MiddleCenter;
            lblBalance.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            pnlSummary.Controls.Add(lblBalance);
            this.Controls.Add(pnlSummary);

            cmbTimeFilter = new ComboBox();
            cmbTimeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTimeFilter.Width = 200;
            cmbTimeFilter.Location = new Point(this.Width - 220, 10);
            cmbTimeFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            foreach (TimePeriod period in Enum.GetValues(typeof(TimePeriod)))
            {
                cmbTimeFilter.Items.Add(new ComboItem
                {
                    Text = TimePeriodHelper.GetDisplayName(period),
                    value = period
                });
            }
            cmbTimeFilter.SelectedIndex = 0;
            cmbTimeFilter.SelectedIndexChanged += (s, e) => LoadData();

            this.Controls.Add(cmbTimeFilter);
            cmbTimeFilter.BringToFront();

            layoutPanel = new TableLayoutPanel();
            layoutPanel.Dock = DockStyle.Fill;
            layoutPanel.ColumnCount = 2;
            layoutPanel.RowCount = 1;
            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.Controls.Add(layoutPanel);
            layoutPanel.BringToFront();

            chartPie = CreateBaseChart("Struktura Wydatków");
            SetupPieSeries(chartPie);
            layoutPanel.Controls.Add(chartPie, 0, 0);

            chartBar = CreateBaseChart("Analiza w czasie");
            SetupBarSeries(chartBar);
            layoutPanel.Controls.Add(chartBar, 1, 0);
        }

        public void LoadData()
        {
            FinanceManager manager = new FinanceManager();

            var selectedItem = cmbTimeFilter.SelectedItem as ComboItem;
            var selectedPeriod = selectedItem != null ? selectedItem.value : TimePeriod.AllTime;

            var filtredExpenses = manager.GetFilteredList(GlobalData.AllExpenses, selectedPeriod);
            var filtredIncomes = manager.GetFilteredList(GlobalData.AllIncomes, selectedPeriod);

            decimal totalIncome = filtredIncomes.Sum(e => e.Amount);
            decimal totalExpense = filtredExpenses.Sum(i => i.Amount);
            decimal balance = totalIncome - totalExpense;

            lblBalance.Text = $"Bilans: {balance:C2}";
            lblBalance.ForeColor = balance >= 0 ? Color.SeaGreen : Color.IndianRed;

            LoadPieData(filtredExpenses, totalExpense);
            LoadDynamicBarChart(filtredIncomes, filtredExpenses, selectedPeriod);
        }

        private void LoadDynamicBarChart(List<Income> incomes, List<Expense> expenses, TimePeriod period)
        {
            chartBar.Series["Przychody"].Points.Clear();
            chartBar.Series["Wydatki"].Points.Clear();

            chartBar.Series["Przychody"].IsXValueIndexed = true;
            chartBar.Series["Wydatki"].IsXValueIndexed = true;

            chartBar.ChartAreas[0].AxisX.Interval = 1;
            chartBar.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.NotSet;
            chartBar.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

            string groupingType = DetermineGroupingStrategy(period);
            chartBar.Titles[0].Text = $"Analiza trendów ({GetGroupingName(groupingType)})";

            var groupedIncomes = GroupData(incomes, groupingType);
            var groupedExpenses = GroupData(expenses, groupingType);

            List<string> timeKeys = GenerateTimeKeys(period, groupingType);

            if (!timeKeys.Any())
            {
                timeKeys = groupedIncomes.Keys.Union(groupedExpenses.Keys).ToList();
                timeKeys.Sort((a, b) => CompareDateKeys(a, b, groupingType));
            }

            foreach (var key in timeKeys)
            {
                decimal incVal = groupedIncomes.ContainsKey(key) ? groupedIncomes[key] : 0;
                decimal expVal = groupedExpenses.ContainsKey(key) ? groupedExpenses[key] : 0;

                int i1 = chartBar.Series["Przychody"].Points.AddXY(key, incVal);
                int i2 = chartBar.Series["Wydatki"].Points.AddXY(key, expVal);

                chartBar.Series["Przychody"].Points[i1].ToolTip = "Przychód: #VALY{C2}";
                chartBar.Series["Wydatki"].Points[i2].ToolTip = "Wydatek: #VALY{C2}";
            }
        }

        private List<string> GenerateTimeKeys(TimePeriod period, string strategy)
        {
            List<string> keys = new List<string>();
            DateTime anchorDate = DateTime.Now;
            //var allDates = GlobalData.AllIncomes.Select(x => x.Date)
            //    .Concat(GlobalData.AllExpenses
            //    .Select(x => x.Date))
            //    .ToList();
            
            //if (allDates.Any())
            //{
            //    DateTime lastTransactionDate = allDates.Max();
            //    if (lastTransactionDate > anchorDate) anchorDate = lastTransactionDate;
            //}

            int itemsCount = 0;

            switch(period)
            {
                case TimePeriod.LastMonth: itemsCount = 1; break;
                case TimePeriod.Last3Months: itemsCount = 3; break;
                case TimePeriod.Last6Months: itemsCount = 6; break;
                case TimePeriod.LastYear: itemsCount = 4; break;
                case TimePeriod.Last2Years: itemsCount = 8; break;
                case TimePeriod.Last5Years: itemsCount = 5; break;
                default: return new List<string>();
            }

            for (int i = itemsCount - 1; i >= 0; i--)
            {
                DateTime date;
                if (strategy == "MONTH") date = DateTime.Now.AddMonths(-i);
                else if (strategy == "QUARTER") date = DateTime.Now.AddMonths(-i * 3);
                else date = DateTime.Now.AddYears(-i);

                keys.Add(GetKey(date, strategy));
            }
            return keys;
        }

        private string DetermineGroupingStrategy(TimePeriod period) {
            if (period == TimePeriod.LastMonth ||
                period == TimePeriod.Last3Months ||
                period == TimePeriod.Last6Months) return "MONTH";

            if (period == TimePeriod.LastYear ||
                period == TimePeriod.Last2Years) return "QUARTER";

            if (period == TimePeriod.Last5Years) return "YEAR";

            return "QUARTER";
        }

        private Dictionary<string, decimal> GroupData<T>(List<T> list, string strategy) where T : Transaction
        {
            return list.GroupBy(x => GetKey(x.Date, strategy))
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Amount));
        }

        private string GetKey(DateTime date, string strategy)
        {
            switch(strategy)
            {
                case "YEAR":
                    return date.Year.ToString();
                case "QUARTER":
                    int q = (date.Month - 1) / 3 + 1;
                    return $"Q{q} {date.Year}";
                case "MONTH":
                default:
                    return date.ToString("MM.yyyy");
            }
        }

        private string GetGroupingName(string strategy)
        {
            switch(strategy)
            {
                case "YEAR": return "Rocznie";
                case "QUARTER": return "Kwartalnie";
                default: return "Miesięcznie";
            }
        }

        private int CompareDateKeys(string a, string b, string strategy)
        {
            try
            {
                var culture = System.Globalization.CultureInfo.InvariantCulture;
                if (strategy == "YEAR") return int.Parse(a).CompareTo(int.Parse(b));
                if (strategy == "MONTH") return DateTime.ParseExact(a, "MM.yyyy", null).CompareTo(DateTime.ParseExact(b, "MM.yyyy", null));
                if (strategy == "QUARTER")
                {
                    var partsA = a.Split(' ');
                    var partsB = b.Split(' ');
                    int yearA = int.Parse(partsA[1]);
                    int yearB = int.Parse(partsB[1]);
                    if (yearA != yearB) return yearA.CompareTo(yearB);
                    return partsA[0].CompareTo(partsB[0]);
                }
            }
            catch { return 0; }
            return String.Compare(a, b);
        }

        private void LoadPieData(List<Expense> expenses, decimal totalExpense)
        {
            chartPie.Series["Categories"].Points.Clear();

            var expensesByCategory = expenses
                .GroupBy(i => i.Category)
                .Select(g => new { Category = g.Key, Amount = g.Sum(i => i.Amount) })
                .Where(x => x.Amount > 0)
                .OrderByDescending(x => x.Amount)
                .ToList();

            if (expensesByCategory.Count == 0)
            {
                chartPie.Titles[0].Text = "Brak danych";
                return;
            }

            chartPie.Titles[0].Text = "Struktura Wydatków";


            foreach (var item in expensesByCategory)
            {
                int index = chartPie.Series["Categories"].Points.AddXY(item.Category, item.Amount);
                double percent = totalExpense > 0 ? (double)item.Amount / (double)totalExpense : 0;
                chartPie.Series["Categories"].Points[index].LegendText = $"{item.Category} ({percent:P0})";
                chartPie.Series["Categories"].Points[index].ToolTip = $"{item.Amount:C2}";
            }
        }

        private Chart CreateBaseChart(string titleText)
        {
            Chart c = new Chart();
            c.Dock = DockStyle.Fill;
            c.BackColor = Color.White;

            ChartArea area = new ChartArea("MainArea");
            area.BackColor = Color.White;
            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            c.ChartAreas.Add(area);

            Legend l = new Legend("MainLegend");
            l.Docking = Docking.Bottom;
            l.Alignment = StringAlignment.Center;
            l.Font = new Font("Segoe UI", 10);
            c.Legends.Add(l);

            c.Titles.Add(new Title(titleText, Docking.Top, new Font("Segoe UI", 12, FontStyle.Bold), Color.DimGray));
            return c;
        }

        private void SetupPieSeries(Chart c)
        {
            Series s = new Series("Categories");
            s.ChartType = SeriesChartType.Doughnut;
            s["PieLabelStyle"] = "Disabled";
            c.Series.Add(s);
        }

        private void SetupBarSeries(Chart c)
        {
            Series sIncome = new Series("Przychody");
            sIncome.ChartType = SeriesChartType.Column;
            sIncome.Color = Color.SeaGreen;
            c.Series.Add(sIncome);

            Series sExpense = new Series("Wydatki");
            sExpense.ChartType = SeriesChartType.Column;
            sExpense.Color = Color.IndianRed;
            c.Series.Add(sExpense);
        }
    }
}
