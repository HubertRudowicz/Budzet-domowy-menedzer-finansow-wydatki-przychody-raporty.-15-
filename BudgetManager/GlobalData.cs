using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using projekttest.Models;

namespace projekttest
{
    public static class GlobalData
    {
        public static List<Person> People = new List<Person>()
        {
            new Person("Tata"),
            new Person("Mama"),
            new Person("Syn"),
            new Person("Córka")
        };

        public static List<Expense> AllExpenses = new List<Expense>();
        public static List<Income> AllIncomes = new List<Income>();
        public static List<SavingGoal> Goals = new List<SavingGoal>();
        public static List<Category> Categories = new List<Category>()
        {
            new Category("Jedzenie", true),
            new Category("Dom", true),
            new Category("Transport", true),
            new Category("Rozrywka", true), 
            new Category("Zdrowie", true),
            new Category("Edukacja", true),
            new Category("Inne", true)
        };
    }
}
