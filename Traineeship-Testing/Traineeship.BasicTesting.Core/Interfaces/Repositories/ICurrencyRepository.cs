using Traineeship.BasicTesting.Core.Models;

namespace Traineeship.BasicTesting.Core.Interfaces.Repositories
{
    public interface ICurrencyRepository
    {
        Currency GetCurrency(string id);
    }
}
