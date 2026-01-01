using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekttest.Models
{
    public static class AppConstants
    {

    }

    public static class SystemCategories
    {
        public const string Other = "Inne";
        public const string Salery = "Wynagrodzenia";
        public const string Food = "Jedzenie";
        public const string Savings = "Oszczędności";
        public const string Bonus = "Premia";
        public const string Sales = "Sprzedaż";

        public static readonly string[] ProtectedCategories = {Other, Salery, Food, Savings};
    }

    public enum TimePeriod
    {
        AllTime,
        Last5Years,
        Last2Years,
        LastYear,
        Last6Months,
        Last3Months,
        LastMonth
    }

    public static class TimePeriodHelper
    {
        public static string GetDisplayName(TimePeriod timePeriod)
        {
            switch(timePeriod)
            {
                case TimePeriod.AllTime: return "Cały okres";
                case TimePeriod.Last5Years: return "Ostatnie 5 lat";
                case TimePeriod.Last2Years: return "Ostatnie 2 lata";
                case TimePeriod.LastYear: return "Ostatni rok";
                case TimePeriod.Last6Months: return "Ostatnie 6 m-cy";
                case TimePeriod.Last3Months: return "Ostatnie 3 m-ce";
                case TimePeriod.LastMonth: return "Ostatni miesiąc";
                default: return timePeriod.ToString();
            }
        }
    }
}
