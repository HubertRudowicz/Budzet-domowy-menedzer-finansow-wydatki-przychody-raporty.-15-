using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekttest.Models
{
    public abstract class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public string Person {  get; set; }
        public bool isRecurring { get; set; }
        public virtual string Title { get; set; }

        protected Transaction() { }

        protected Transaction(DateTime date, string title, decimal amount, string category, string person, bool isRecurring)
        {
            Date = date;
            Title = title;
            Amount = amount;
            Category = category;    
            Person = person;
            this.isRecurring = isRecurring;
        }

        public static decimal operator +(Transaction a, Transaction b)
        {
            decimal amountA = (a != null) ? a.Amount : 0;
            decimal amountB = (b != null) ? b.Amount : 0;

            return amountA + amountB;
        }
    }
}
