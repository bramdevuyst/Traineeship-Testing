using Traineeship.BasicTesting.Core.Models;

namespace Traineeship.BasicTesting.Core.Interfaces.Services
{
    public interface ICurrencyService
    {
        double CalculateConvertedValue(string Id, double amount);
    }
}
