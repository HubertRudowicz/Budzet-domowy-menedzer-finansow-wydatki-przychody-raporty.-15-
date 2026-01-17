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
        private readonly IBudgetRepository _repository;

        // Konstruktor domyślny
        // Zmiana na JsonBudgetRepository, aby od razu działał zapis do pliku
        public FinanceManager() : this(new JsonBudgetRepository()) { }

        // Konstruktor z wstrzykiwaniem zależności (dla testów)
        public FinanceManager(IBudgetRepository repository)
        {
            _repository = repository;
        }

        public void SaveData()
        {
            _repository.Save();
        }

        public void LoadTestData()
        {
            // 1. Przychody
            if (_repository.AllIncomes.Count == 0)
            {
                _repository.AllIncomes.Add(new Income { Id = 1, Date = DateTime.Now.AddDays(-10), Amount = 5000, Person = new Person("Tata"), Source = "Wypłata", Category = new Category("Wynagrodzenia", true), isRecurring = true });
                _repository.AllIncomes.Add(new Income { Id = 2, Date = DateTime.Now.AddDays(-5), Amount = 3500, Person = new Person("Mama"), Source = "Wypłata", Category = new Category("Wynagrodzenia", true), isRecurring = true });
                _repository.AllIncomes.Add(new Income { Id = 3, Date = DateTime.Now.AddDays(-2), Amount = 500, Person = new Person("Syn"), Source = "Urodziny", Category = new Category("Inne", true), isRecurring = false });
            }

            // 2. Wydatki
            if (_repository.AllExpenses.Count == 0)
            {
                _repository.AllExpenses.Add(new Expense { Id = 1, Date = DateTime.Now, Amount = 150, Category = new Category("Jedzenie", true), Description = "Biedronka", Person = new Person("Mama") });
                _repository.AllExpenses.Add(new Expense { Id = 2, Date = DateTime.Now.AddDays(-1), Amount = 200, Category = new Category("Transport", true), Description = "Orlen", Person = new Person("Tata") }); // Paliwo -> Transport
                _repository.AllExpenses.Add(new Expense { Id = 3, Date = DateTime.Now.AddDays(-2), Amount = 50, Category = new Category("Rozrywka", true), Description = "Kino", Person = new Person("Syn") });
            }

            // 3. Cele
            if (_repository.Goals.Count == 0)
            {
                _repository.Goals.Add(new SavingGoal { Id = 1, Name = "Wakacje 2026", TargetAmount = 8000, CurrentAmount = 2610 });
                _repository.Goals.Add(new SavingGoal { Id = 2, Name = "Samochód", TargetAmount = 25000, CurrentAmount = 18000 });
                _repository.Goals.Add(new SavingGoal { Id = 3, Name = "Nowy Telefon", TargetAmount = 4000, CurrentAmount = 500 });
            }

            _repository.Save();
        }
        public int ProcessRecurringTransactions()
        {
            DateTime today = DateTime.Now;
            int addedCount = 0;

            addedCount += ProcessList(
                _repository.AllExpenses,
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
                (oldExp, newDate) => _repository.AllExpenses.Any(e =>
                    e.Description == oldExp.Description &&
                    e.Amount == oldExp.Amount &&
                    e.Date.Year == newDate.Year &&
                    e.Date.Month == newDate.Month)
            );

            addedCount += ProcessList(
                _repository.AllIncomes,
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
                (oldInc, newDate) => _repository.AllIncomes.Any(i =>
                    i.Source == oldInc.Source &&
                    i.Amount == oldInc.Amount &&
                    i.Date.Year == newDate.Year &&
                    i.Date.Month == newDate.Month)
            );

            // Uwaga: Komunikat UI przeniesiony poza logikę biznesową byłby lepszym rozwiązaniem,
            // ale zostawiamy go tutaj dla zgodności, z ewentualnym sprawdzeniem czy to tryb UI.
            // W czystym modelu nie powinno być MessageBox. 
            // Zakomentuję lub zostawię zależnie od potrzeb - zostawiam dla zgodności z oryginałem
            // choć w testach będzie to problematyczne (MessageBox).
            // W refaktoryzacji "PRO" wyrzuciłbym to do warstwy UI.
            if (addedCount > 0)
            {
               _repository.Save();
               // System.Windows.Forms.MessageBox.Show - to wymaga referencji do WinForms.
               // Zakładamy, że ta klasa jest w projekcie WinForms, więc to zadziała.
               // Ale w testach jednostkowych to wywali błąd jeśli nie będzie interakcji.
               // TODO: Wyrzucić interakcję UI.
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
        private int GenerateExpenseId() => _repository.AllExpenses.Any() ? _repository.AllExpenses.Max(e => e.Id) + 1 : 1;
        private int GenerateIncomeId() => _repository.AllIncomes.Any() ? _repository.AllIncomes.Max(i => i.Id) + 1 : 1;


        public bool DeletePerson(string personName, out string errorMessage) => TryDeletePerson(personName, out errorMessage);

        public bool TryDeletePerson(string personName, out string errorMessage)
        {
            int expensesCount = _repository.AllExpenses.Count(e => e.Person.Name == personName);
            if (expensesCount > 0)
            {
                errorMessage = $"Nie można usunąć osoby '{personName}', ponieważ ma przypisane {expensesCount} wydatków. Najpierw usuń te wydatki lub przypisz je do kogoś innego.";
                return false; // Operacja nieudana
            }

            int incomesCount = _repository.AllIncomes.Count(e => e.Person.Name == personName);
            if (incomesCount > 0)
            {
                errorMessage = $"Nie można usunąć osoby '{personName}', ponieważ ma przypisane {incomesCount} przychodów.";
                return false;
            }

            var personToRemove = _repository.People.FirstOrDefault(p => p.Name == personName);
            if (personToRemove != null)
            {
                _repository.People.Remove(personToRemove);
                _repository.Save();
            }
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

            int usageCount = _repository.AllExpenses.Count(e => e.Category.Name == categoryName)
                + _repository.AllIncomes.Count(i => i.Category.Name == categoryName);

            if (usageCount > 0)
            {
                errorMessage = $"Kategoria '{categoryName}' jest używana w {usageCount} transakcjach. Operacja zakończona niepowodzeniem";
                return false;
            }

            var categoryToRemove = _repository.Categories.FirstOrDefault(c => c.Name == categoryName);
            if (categoryToRemove != null)
            {
                _repository.Categories.Remove(categoryToRemove);
                _repository.Save();
            }
            errorMessage = string.Empty;
            return true;
        }

        public int GetPersonTransactionCount(string personName)
        {
            return _repository.AllIncomes.Count(e => e.Person.Name == personName) + _repository.AllExpenses.Count(i => i.Person.Name == personName);
        }

        public void DeletePersonWithHistory(string personName)
        {
            _repository.AllExpenses.RemoveAll(e => e.Person.Name == personName);
            _repository.AllIncomes.RemoveAll(i => i.Person.Name == personName);
            var personToRemove = _repository.People.FirstOrDefault(p => p.Name == personName);
            if (personToRemove != null)
                _repository.People.Remove(personToRemove);
            
            _repository.Save();
        }
        public int GetCategoryUsageCount(string categoryName)
        {
            return _repository.AllIncomes.Count(e => e.Category.Name == categoryName) + _repository.AllExpenses.Count(e => e.Category.Name == categoryName);
        }

        public void DeleteCategoryAndMigrate(string oldCategory, string newCategory = Models.SystemCategories.Other)
        {
            if (!_repository.Categories.Any(c => c.Name == newCategory)) 
                _repository.Categories.Add(new Category(newCategory));

            var targetCategory = _repository.Categories.First(c => c.Name == newCategory);
            foreach (var expense in _repository.AllExpenses.Where(e => e.Category.Name == oldCategory)) expense.Category = targetCategory;
            foreach (var income in _repository.AllIncomes.Where(i => i.Category.Name == oldCategory)) income.Category = targetCategory;

            var categoryToRemove = _repository.Categories.FirstOrDefault(c => c.Name == oldCategory);
            if (categoryToRemove != null)
                _repository.Categories.Remove(categoryToRemove);

            _repository.Save();
        }

        public List<Models.Transaction> GetRecentTransactions(int count, Models.TimePeriod period)
        {
            DateTime cutoff = GetStartDate(period);

            var expenses = _repository.AllExpenses.Where(e => e.Date >= cutoff).Cast<Models.Transaction>();
            var incomes = _repository.AllIncomes.Where(i => i.Date >= cutoff).Cast<Models.Transaction>();

            return expenses.Concat(incomes).OrderByDescending(t => t.Date).Take(count).ToList();
        }

        public decimal GetCurrentBalance(Models.TimePeriod period)
        {
            DateTime cutoff = GetStartDate(period);

            decimal totalIncome = _repository.AllIncomes.Where(i => i.Date >= cutoff).Sum(i => i.Amount);
            decimal totalExpense = _repository.AllExpenses.Where(e => e.Date >= cutoff).Sum(e => e.Amount);
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

        public List<Expense> GetAllExpenses() => _repository.AllExpenses;
        public List<Income> GetAllIncomes() => _repository.AllIncomes;

        public void AddTransaction(Transaction transaction)
        {
            if (transaction is Expense expense)
            {
                expense.Id = GenerateExpenseId();
                _repository.AllExpenses.Add(expense);
            }
            else if (transaction is Income income)
            {
                income.Id = GenerateIncomeId();
                _repository.AllIncomes.Add(income);
            }
            _repository.Save();
        }

        public void DeleteTransaction(Transaction transaction)
        {
            if (transaction is Expense expense) _repository.AllExpenses.Remove(expense);
            else if (transaction is Income income) _repository.AllIncomes.Remove(income);
            _repository.Save();
        }

        public List<SavingGoal> GetAllGoals() => _repository.Goals;

        public void AddGoal(SavingGoal goal)
        {
            goal.Id = _repository.Goals.Any() ? _repository.Goals.Max(g => g.Id) + 1 : 1;
            _repository.Goals.Add(goal);
            _repository.Save();
        }

        public void DeleteGoal(SavingGoal goal)
        {
            _repository.Goals.Remove(goal);
            _repository.Save();
        }

    }
}


