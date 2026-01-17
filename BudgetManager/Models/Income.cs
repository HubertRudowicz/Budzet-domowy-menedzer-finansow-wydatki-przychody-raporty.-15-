using System;

namespace projekttest.Models
{
    public class Income : Transaction, IExportable
    {
        public string Source
        {
            get => Title;
            set => Title = value;
        }

        public Income() : base() { }

        public Income(DateTime date, string desc, decimal amount, Category category, Person person, bool isRecurring)
            : base(date, desc, amount, category, person, isRecurring)
        { }

        public string GetCSVFormat()
        {
            return $"{Date.ToShortDateString()};{Amount};{Category};{Source}";
        }
    }
}
