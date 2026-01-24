using Xunit;
using projekttest.Models;
using System;

namespace BudgetManager.Tests
{
    public class TransactionTests
    {
        // Concrete implementation of abstract class for testing purposes
        private class TestTransaction : Transaction
        {
            public TestTransaction(decimal amount)
            {
                Amount = amount;
            }
        }

        [Fact]
        public void OperatorPlus_ShouldSumAmounts_WhenBothTransactionsExist()
        {
            // Arrange
            var t1 = new TestTransaction(100);
            var t2 = new TestTransaction(50);

            // Act
            decimal result = t1 + t2;

            // Assert
            Assert.Equal(150, result);
        }

        [Fact]
        public void OperatorPlus_ShouldReturnAmount_WhenOneTransactionIsNull()
        {
            // Arrange
            var t1 = new TestTransaction(100);
            TestTransaction t2 = null;

            // Act
            decimal result = t1 + t2;

            // Assert
            Assert.Equal(100, result);
        }

        [Fact]
        public void OperatorPlus_ShouldReturnZero_WhenBothTransactionsAreNull()
        {
            // Arrange
            TestTransaction t1 = null;
            TestTransaction t2 = null;

            // Act
            decimal result = t1 + t2;

            // Assert
            Assert.Equal(0, result);
        }
    }
}
