using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekttest.Models
{
    public class AppData
    {
        public List<Income> Incomes { get; set; }
        public List<Expense> Expenses { get; set; }
        public List<string> Categories { get; set; }
        public List<string> People { get; set; }
        public List<SavingGoal> Goals { get; set; }

        public AppData()
        {
            Incomes = new List<Income>();
            Expenses = new List<Expense>(); 
            Categories = new List<string>();
            People = new List<string>();
            Goals = new List<SavingGoal>();
        }
    }
}
