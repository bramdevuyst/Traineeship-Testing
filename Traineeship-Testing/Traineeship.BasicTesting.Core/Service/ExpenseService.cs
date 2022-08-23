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
        public void AddOrUpdate(Expense expense)
        {
        }
    }
}
