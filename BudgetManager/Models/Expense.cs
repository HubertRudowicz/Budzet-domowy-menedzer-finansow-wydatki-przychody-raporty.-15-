using System;

namespace projekttest.Models
{
    public class Expense : Transaction, IExportable
    {
        public string Description
        {
            get => Title;
            set => Title = value;
        }
        public Expense() : base() { }

        public Expense(DateTime date, string desc, decimal amount, string category, string person, bool isRecurring = false) : base(date, desc, amount, category,person, isRecurring)
        { }

        public string GetCSVFormat()
        {
            return $"{Date.ToShortDateString()};{Amount};{Category};{Description}";
        }
    }
}
