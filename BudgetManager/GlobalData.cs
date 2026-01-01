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
        public static List<string> People = new List<string>()
        {
            "Tata",
            "Mama",
            "Syn",
            "Córka"
        };

        public static List<Expense> AllExpenses = new List<Expense>();
        public static List<Income> AllIncomes = new List<Income>();
        public static List<SavingGoal> Goals = new List<SavingGoal>();
        public static List<string> Categories = new List<string>()
        {
            "Jedzenie",
            "Dom",
            "Transport",
            "Rozrywka",
            "Zdrowie",
            "Edukacja",
            "Inne"
        };
    }
}
