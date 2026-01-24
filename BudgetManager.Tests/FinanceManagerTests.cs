using Xunit;
using projekttest.Managers;
using projekttest.Models;
using System;
using System.Linq;

namespace BudgetManager.Tests
{
    public class FinanceManagerTests
    {
        [Fact]
        public void GetCurrentBalance_ShouldCalculateCorrectly()
        {
            // Arrange
            var mockRepo = new MockBudgetRepository();
            mockRepo.AllIncomes.Add(new Income { Amount = 1000, Date = DateTime.Now });
            mockRepo.AllExpenses.Add(new Expense { Amount = 200, Date = DateTime.Now });

            var manager = new FinanceManager(mockRepo);

            // Act
            decimal balance = manager.GetCurrentBalance(TimePeriod.AllTime);

            // Assert
            Assert.Equal(800, balance);
        }

        [Fact]
        public void AddTransaction_ShouldAddToRepository_AndSave()
        {
            // Arrange
            var mockRepo = new MockBudgetRepository();
            var manager = new FinanceManager(mockRepo);
            var income = new Income { Amount = 500, Title = "Bonus" };

            // Act
            manager.AddTransaction(income);

            // Assert
            Assert.Single(mockRepo.AllIncomes);
            Assert.True(mockRepo.SaveCalled);
        }

        [Fact]
        public void ProcessRecurringTransactions_ShouldAddTransaction_WhenDatePassed()
        {
            // Arrange
            var mockRepo = new MockBudgetRepository();
            var pastDate = DateTime.Now.AddMonths(-1); // 1 month ago
            
            mockRepo.AllIncomes.Add(new Income 
            { 
                Amount = 2000, 
                Date = pastDate, 
                isRecurring = true, 
                Source = "Salary",
                Category = new Category("Work"),
                Person = new Person("Me")
            });

            var manager = new FinanceManager(mockRepo);

            // Act
            int addedCount = manager.ProcessRecurringTransactions();

            // Assert
            // It should add one new transaction for the current month
            Assert.True(addedCount > 0, $"Expected > 0, got {addedCount}");
            Assert.Equal(2, mockRepo.AllIncomes.Count); // Original + New
        }
    }
}
