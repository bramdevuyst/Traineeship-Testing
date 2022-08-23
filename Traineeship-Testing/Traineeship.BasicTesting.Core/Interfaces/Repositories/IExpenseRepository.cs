using Traineeship.BasicTesting.Core.Models;

namespace Traineeship.BasicTesting.Core.Interfaces.Repositories
{
    public interface IExpenseRepository
    {
        Expense Get(int Id);
        List<Expense> GetAll();
        void Add(Expense expense);
        void Update(Expense expense);

    }
}
