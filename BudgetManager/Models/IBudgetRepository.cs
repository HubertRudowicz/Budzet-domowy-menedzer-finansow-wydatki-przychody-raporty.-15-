using System;
using System.Collections.Generic;

namespace projekttest.Models
{
    public interface IBudgetRepository
    {
        List<Income> AllIncomes { get; }
        List<Expense> AllExpenses { get; }
        List<SavingGoal> Goals { get; }
        List<Category> Categories { get; }
        List<Person> People { get; }
        
        // Opcjonalnie metoda Save, jeśli w przyszłości będziemy zapisywać do pliku/bazy
        void Save();
    }
}
