using Traineeship.BasicTesting.Core.Exceptions;
using Traineeship.BasicTesting.Core.Interfaces.Repositories;
using Traineeship.BasicTesting.Core.Interfaces.Services;
using Traineeship.BasicTesting.Core.Models;

namespace Traineeship.BasicTesting.Core.Service
{
    public class ExpenseService : IExpenseService
    {
        private IExpenseRepository _expenseRepository { get; set; }
        private ICurrencyService _currencyService { get; set; }
        public ExpenseService(IExpenseRepository expenseRepository, ICurrencyService currencyService)
        {
            _expenseRepository = expenseRepository;
            _currencyService = currencyService;
        }
        public void Add(Expense expense)
        {
            var existingExpense = _expenseRepository.Get(expense.Id);
            if (existingExpense != null)
                throw new ExpenseAlreadyExistingException("Expense already existing with same Id");
            if (IBANValidator.ValidateIBANNr(expense.BankAccount).Any())
                throw new InvalidIBANException("IBAN banknumber is invalid");
        }
        public void Update(Expense expense)
        {
            var existingExpense = _expenseRepository.Get(expense.Id);
            if (existingExpense == null)
                throw new ExpenseNotFoundException("Expense not yet existing");
            if (IBANValidator.ValidateIBANNr(expense.BankAccount).Any())
                throw new InvalidIBANException("IBAN banknumber is invalid");
        }
    }
}
