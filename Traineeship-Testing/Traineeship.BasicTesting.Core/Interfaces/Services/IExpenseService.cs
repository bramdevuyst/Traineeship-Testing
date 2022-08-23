using Traineeship.BasicTesting.Core.Models;

namespace Traineeship.BasicTesting.Core.Interfaces.Services
{
    public interface IExpenseService
    {
        //TODO:
        //
        // Check if expense exists
        // Check if all fields are filled in
        // Check if status is new when you want to change the amount or bank account
        // Validate the IBAN number

        void Add(Expense expense);
        void Update(Expense expense);

    }
}
