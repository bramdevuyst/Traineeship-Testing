using Traineeship.BasicTesting.Core.Exceptions;
using Traineeship.BasicTesting.Core.Interfaces.Repositories;
using Traineeship.BasicTesting.Core.Interfaces.Services;

namespace Traineeship.BasicTesting.Data.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;
        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }
        public double CalculateConvertedValue(string Id, double amount)
        {
            var currency = _currencyRepository.GetCurrency(Id);
            if (currency == null)
                throw new CurrencyNotFoundException("No currency found");
            return currency.ConvertValue * amount;
        }
    }
}
