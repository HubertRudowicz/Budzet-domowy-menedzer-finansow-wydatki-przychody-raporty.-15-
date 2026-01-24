using projekttest.Models;
using System.Collections.Generic;

namespace BudgetManager.Tests
{
    public class MockBudgetRepository : IBudgetRepository
    {
        public List<Income> AllIncomes { get; } = new List<Income>();
        public List<Expense> AllExpenses { get; } = new List<Expense>();
        public List<SavingGoal> Goals { get; } = new List<SavingGoal>();
        public List<Category> Categories { get; } = new List<Category>();
        public List<Person> People { get; } = new List<Person>();

        public bool SaveCalled { get; private set; } = false;

        public void Save()
        {
            SaveCalled = true;
        }
    }
}
