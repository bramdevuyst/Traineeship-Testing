using Traineeship.BasicTesting.Core.Models;

namespace Traineeship.BasicTesting.Core.Interfaces.Services
{
    public interface IExpenseService
    {
        void AddOrUpdate(Expense expense);
    }
}
