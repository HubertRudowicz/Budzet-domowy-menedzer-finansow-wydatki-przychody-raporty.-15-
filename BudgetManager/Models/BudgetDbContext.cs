using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace projekttest.Models
{
    public class BudgetDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        // Transaction is abstract, so Incomes and Expenses sets handle it.
        // If we want a queryable Transactions set, we can add it, but usually not needed if we access via helpers.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<SavingGoal> SavingGoals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string dbPath = Path.Combine(docPath, "budget.db");
                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Transaction hierarchy (TPH is default)
            modelBuilder.Entity<Transaction>()
                .HasDiscriminator<string>("TransactionType")
                .HasValue<Income>("Income")
                .HasValue<Expense>("Expense");

            base.OnModelCreating(modelBuilder);
        }
    }
}
