using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using projekttest.Models;

namespace projekttest.Managers
{
    public class FinanceManager
    {
        public FinanceManager() { }

        public void LoadTestData()
        {
            // 1. Przychody (To naprawi Twój problem z Raportami!)
            if (GlobalData.AllIncomes.Count == 0)
            {
                GlobalData.AllIncomes.Add(new Income { Id = 1, Date = DateTime.Now.AddDays(-10), Amount = 5000, Person = "Tata", Source = "Wypłata", Category = "Wynagrodzenia", isRecurring = true });
                GlobalData.AllIncomes.Add(new Income { Id = 2, Date = DateTime.Now.AddDays(-5), Amount = 3500, Person = "Mama", Source = "Wypłata", Category = "Wynagrodzenia", isRecurring = true });
                GlobalData.AllIncomes.Add(new Income { Id = 3, Date = DateTime.Now.AddDays(-2), Amount = 500, Person = "Syn", Source = "Urodziny", Category = "Inne", isRecurring = false });
            }

            // 2. Wydatki (Też warto tu wrzucić)
            if (GlobalData.AllExpenses.Count == 0)
            {
                GlobalData.AllExpenses.Add(new Expense { Id = 1, Date = DateTime.Now, Amount = 150, Category = "Jedzenie", Description = "Biedronka", Person = "Mama" });
                GlobalData.AllExpenses.Add(new Expense { Id = 2, Date = DateTime.Now.AddDays(-1), Amount = 200, Category = "Paliwo", Description = "Orlen", Person = "Tata" });
                GlobalData.AllExpenses.Add(new Expense { Id = 3, Date = DateTime.Now.AddDays(-2), Amount = 50, Category = "Rozrywka", Description = "Kino", Person = "Syn" });
            }

            // 3. Cele (Żeby też były od razu w raportach)
            if (GlobalData.Goals.Count == 0)
            {
                GlobalData.Goals.Add(new SavingGoal { Id = 1, Name = "Wakacje 2026", TargetAmount = 8000, CurrentAmount = 2610 });
                GlobalData.Goals.Add(new SavingGoal { Id = 2, Name = "Samochód", TargetAmount = 25000, CurrentAmount = 18000 });
                GlobalData.Goals.Add(new SavingGoal { Id = 3, Name = "Nowy Telefon", TargetAmount = 4000, CurrentAmount = 500 });
            }
        }
        public int ProcessRecurringTransactions()
        {
            DateTime today = DateTime.Now;
            int addedCount = 0;

            addedCount += ProcessList(
                GlobalData.AllExpenses,
                e => e.isRecurring,
                e => e.Date,
                (oldExp, newDate) => new Expense
                {
                    Id = GenerateExpenseId(),
                    Date = newDate,
                    Amount = oldExp.Amount,
                    Category = oldExp.Category,
                    Person = oldExp.Person,
                    Description = oldExp.Description,
                    isRecurring = true
                },
                (oldExp, newDate) => GlobalData.AllExpenses.Any(e =>
                    e.Description == oldExp.Description &&
                    e.Amount == oldExp.Amount &&
                    e.Date.Year == newDate.Year &&
                    e.Date.Month == newDate.Month)
            );

            addedCount += ProcessList(
                GlobalData.AllIncomes,
                i => i.isRecurring,
                i => i.Date,
                (oldInc, newDate) => new Income
                {
                    Id = GenerateIncomeId(),
                    Date = newDate,
                    Amount = oldInc.Amount,
                    Person = oldInc.Person,
                    Source = oldInc.Source,
                    Category = oldInc.Category,
                    isRecurring = true
                },
                (oldInc, newDate) => GlobalData.AllIncomes.Any(i =>
                    i.Source == oldInc.Source &&
                    i.Amount == oldInc.Amount &&
                    i.Date.Year == newDate.Year &&
                    i.Date.Month == newDate.Month)
            );

            if (addedCount > 0)
            {
                MessageBox.Show($"Asystent Finansowy:\nDodano automatycznie {addedCount} cyklicznych transakcji na ten miesiąc.",
                                "Aktualizacja Danych", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
            return addedCount;
        }

        private int ProcessList<T>(
            List<T> list,
            Func<T, bool> isRecurringChecker,
            Func<T, DateTime> dateSelector,
            Func<T, DateTime, T> itemFactory,
            Func<T, DateTime, bool> duplicateChecker
        )
        {
            DateTime today = DateTime.Now;
            int count = 0;

            var recurringItems = list.Where(isRecurringChecker).ToList();
            foreach (var item in recurringItems)
            {
                DateTime oldDate = dateSelector(item);
                DateTime targetDate = CalculateTargetDate(today, oldDate);

                if (targetDate <= today && targetDate > oldDate)
                {
                    if (!duplicateChecker(item, targetDate))
                    {
                        T newItem = itemFactory(item, targetDate);

                        list.Add(newItem);
                        count++;
                    }
                }
            }
            return count;
        }

        private DateTime CalculateTargetDate(DateTime today, DateTime originalDate)
        {
            try { return new DateTime(today.Year, today.Month, originalDate.Day); }
            catch { return new DateTime(today.Year, today.Month, 1).AddMonths(1).AddDays(-1); }
        }
        private int GenerateExpenseId() => GlobalData.AllExpenses.Any() ? GlobalData.AllExpenses.Max(e => e.Id) + 1 : 1;
        private int GenerateIncomeId() => GlobalData.AllIncomes.Any() ? GlobalData.AllIncomes.Max(i => i.Id) + 1 : 1;


        public bool DeletePerson(string personName, out string errorMessage) => TryDeletePerson(personName, out errorMessage);

        public bool TryDeletePerson(string personName, out string errorMessage)
        {
            int expensesCount = GlobalData.AllExpenses.Count(e => e.Person == personName);
            if (expensesCount > 0)
            {
                errorMessage = $"Nie można usunąć osoby '{personName}', ponieważ ma przypisane {expensesCount} wydatków. Najpierw usuń te wydatki lub przypisz je do kogoś innego.";
                return false; // Operacja nieudana
            }

            int incomesCount = GlobalData.AllIncomes.Count(e => e.Person == personName);
            if (incomesCount > 0)
            {
                errorMessage = $"Nie można usunąć osoby '{personName}', ponieważ ma przypisane {incomesCount} przychodów.";
                return false;
            }

            GlobalData.People.Remove(personName);
            errorMessage = string.Empty;
            return true;
        }

        public bool TryDeleteCategory(string categoryName, out string errorMessage)
        {
            if (Models.SystemCategories.ProtectedCategories.Contains(categoryName))
            {
                errorMessage = "To jest kategoria systemowa. Operacja zakończona niepowodzeniem.";
                return false;
            }

            int usageCount = GlobalData.AllExpenses.Count(e => e.Category == categoryName)
                + GlobalData.AllIncomes.Count(i => i.Category == categoryName);

            if (usageCount > 0)
            {
                errorMessage = $"Kategoria '{categoryName}' jest używana w {usageCount} transakcjach. Operacja zakończona niepowodzeniem";
                return false;
            }

            GlobalData.Categories.Remove(categoryName);
            errorMessage = string.Empty;
            return true;
        }

        public int GetPersonTransactionCount(string personName)
        {
            return GlobalData.AllIncomes.Count(e => e.Person == personName) + GlobalData.AllExpenses.Count(i => i.Person == personName);
        }

        public void DeletePersonWithHistory(string personName)
        {
            GlobalData.AllExpenses.RemoveAll(e => e.Person == personName);
            GlobalData.AllIncomes.RemoveAll(i => i.Person == personName);
            GlobalData.People.Remove(personName);
        }
        public int GetCategoryUsageCount(string categoryName)
        {
            return GlobalData.AllIncomes.Count(e => e.Category == categoryName) + GlobalData.AllExpenses.Count(e => e.Category == categoryName);
        }

        public void DeleteCategoryAndMigrate(string oldCategory, string newCategory = Models.SystemCategories.Other)
        {
            if (!GlobalData.Categories.Contains(newCategory)) GlobalData.Categories.Add(newCategory);

            foreach (var expense in GlobalData.AllExpenses.Where(e => e.Category == oldCategory)) expense.Category = newCategory;
            foreach (var income in GlobalData.AllIncomes.Where(i => i.Category == oldCategory)) income.Category = newCategory;

            GlobalData.Categories.Remove(oldCategory);
        }

        public List<Models.Transaction> GetRecentTransactions(int count, Models.TimePeriod period)
        {
            DateTime cutoff = GetStartDate(period);

            var expenses = GlobalData.AllExpenses.Where(e => e.Date >= cutoff).Cast<Models.Transaction>();
            var incomes = GlobalData.AllIncomes.Where(i => i.Date >= cutoff).Cast<Models.Transaction>();

            return expenses.Concat(incomes).OrderByDescending(t => t.Date).Take(count).ToList();
        }

        public decimal GetCurrentBalance(Models.TimePeriod period)
        {
            DateTime cutoff = GetStartDate(period);

            decimal totalIncome = GlobalData.AllIncomes.Where(i => i.Date >= cutoff).Sum(i => i.Amount);
            decimal totalExpense = GlobalData.AllExpenses.Where(e => e.Date >= cutoff).Sum(e => e.Amount);
            return totalIncome - totalExpense;
        }

        private DateTime GetStartDate(Models.TimePeriod period)
        {
            DateTime now = DateTime.Now;
            switch(period)
            {
                case Models.TimePeriod.LastMonth: return now.AddMonths(-1);
                case Models.TimePeriod.Last3Months: return now.AddMonths(-3);
                case Models.TimePeriod.Last6Months: return now.AddMonths(-6);
                case Models.TimePeriod.LastYear: return now.AddYears(-1);
                case Models.TimePeriod.Last2Years: return now.AddYears(-2);
                case Models.TimePeriod.Last5Years: return now.AddYears(-5);
                case Models.TimePeriod.AllTime:
                default: return DateTime.MinValue;
            }
        }

        public List<T> GetFilteredList<T>(List<T> list, Models.TimePeriod period) where T : Models.Transaction
        {
            DateTime cutoff = GetStartDate(period);
            return list.Where(item => item.Date >= cutoff).ToList();
        }

    }
}

