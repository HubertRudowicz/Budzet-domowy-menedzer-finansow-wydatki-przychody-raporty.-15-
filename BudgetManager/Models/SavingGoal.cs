using System;

namespace projekttest.Models
{
    public class SavingGoal
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }

        public int ProgressPercentage
        {
            get
            {
                if (TargetAmount == 0) return 0;
                int percent = (int)((CurrentAmount / TargetAmount) * 100);
                return Math.Min(percent, 100);
            }
        }

        public string StatusText => $"{CurrentAmount:C0} z {TargetAmount:C0}";
    }
}
