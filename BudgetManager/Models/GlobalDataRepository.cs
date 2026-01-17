using System.Collections.Generic;

namespace projekttest.Models
{
    public class GlobalDataRepository : IBudgetRepository
    {
        public List<Income> AllIncomes => GlobalData.AllIncomes;
        public List<Expense> AllExpenses => GlobalData.AllExpenses;
        public List<SavingGoal> Goals => GlobalData.Goals;
        public List<Category> Categories => GlobalData.Categories;
        public List<Person> People => GlobalData.People;

        public void Save()
        {
            // W obecnej architekturze opartej na danych w pamięci (GlobalData),
            // zapis nie jest wymagany lub jest realizowany gdzie indziej.
        }
    }
}
