using Moq;
using Traineeship.BasicTesting.Core.Exceptions;
using Traineeship.BasicTesting.Core.Interfaces.Repositories;
using Traineeship.BasicTesting.Core.Models;
using Traineeship.BasicTesting.Core.Service;
using Traineeship.BasicTesting.Data.Services;
using Xunit;

namespace Traineeship.BasicTesting.Service_testing
{
    public class ExpenseServiceTests
    {
        [Fact]
        public void ExpenseServiceShouldThrowNotFoundExceptionOnUpdate()
        {
            var currency = new Currency() { Id = "BP", ConvertValue = 2 };
            var expense = new Expense { Amount = 10, Currency = "BP", Description = "Jetbrains", AmountInEuro = 40, Id = 5, Status = "NEW", BankAccount = "BE682345678911" };
            var expenseRepository = new Mock<IExpenseRepository>();
            expenseRepository.Setup(x => x.Get(expense.Id)).Returns((Expense) null);
            var currencyRepository = new Mock<ICurrencyRepository>();
            currencyRepository.Setup(x => x.GetCurrency("BP")).Returns(currency);
            var currencyService = new CurrencyService(currencyRepository.Object);
            var expenseService = new ExpenseService(expenseRepository.Object, currencyService);
            Assert.Throws<ExpenseNotFoundException>(() => expenseService.Update(expense));
        }
        [Fact]
        public void ExpenseServiceShouldThrowAlreadyExistingExceptionOnAdding()
        {
            var currency = new Currency() { Id = "BP", ConvertValue = 2 };
            var expense = new Expense { Amount = 10, Currency = "BP", Description = "Jetbrains", AmountInEuro = 40, Id = 5, Status = "NEW", BankAccount = "BE682345678911" };
            var expenseRepository = new Mock<IExpenseRepository>();
            expenseRepository.Setup(x => x.Get(expense.Id)).Returns((Expense)expense);
            var currencyRepository = new Mock<ICurrencyRepository>();
            currencyRepository.Setup(x => x.GetCurrency("BP")).Returns(currency);
            var currencyService = new CurrencyService(currencyRepository.Object);
            var expenseService = new ExpenseService(expenseRepository.Object, currencyService);
            Assert.Throws<ExpenseAlreadyExistingException>(() => expenseService.Add(expense));
        }
        [Fact]
        public void ExpenseServiceShouldThrowInvalidIBANExceptionOnAdd()
        {
            var currency = new Currency() { Id = "BP", ConvertValue = 2 };
            var expense = new Expense { Amount = 10, Currency = "BP", Description = "Jetbrains", AmountInEuro = 40, Id = 5, Status = "NEW",BankAccount="BE012345678911" };
            var expenseRepository = new Mock<IExpenseRepository>();
            expenseRepository.Setup(x => x.Get(expense.Id)).Returns((Expense)null);
            var currencyRepository = new Mock<ICurrencyRepository>();
            currencyRepository.Setup(x => x.GetCurrency("BP")).Returns(currency);
            var currencyService = new CurrencyService(currencyRepository.Object);
            var expenseService = new ExpenseService(expenseRepository.Object, currencyService);
            Assert.Throws<InvalidIBANException>(() => expenseService.Add(expense));
        }
        [Fact]
        public void ExpenseServiceShouldThrowInvalidIBANExceptionOnUpdate()
        {
            var currency = new Currency() { Id = "BP", ConvertValue = 2 };
            var expense = new Expense { Amount = 10, Currency = "BP", Description = "Jetbrains", AmountInEuro = 40, Id = 5, Status = "NEW", BankAccount = "BE012345678911" };
            var expenseRepository = new Mock<IExpenseRepository>();
            expenseRepository.Setup(x => x.Get(expense.Id)).Returns((Expense)expense);
            var currencyRepository = new Mock<ICurrencyRepository>();
            currencyRepository.Setup(x => x.GetCurrency("BP")).Returns(currency);
            var currencyService = new CurrencyService(currencyRepository.Object);
            var expenseService = new ExpenseService(expenseRepository.Object, currencyService);
            Assert.Throws<InvalidIBANException>(() => expenseService.Update(expense));
        }
    }
}
