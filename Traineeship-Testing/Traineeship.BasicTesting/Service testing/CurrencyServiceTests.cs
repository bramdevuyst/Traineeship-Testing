using FluentAssertions;
using Moq;
using Traineeship.BasicTesting.Core.Exceptions;
using Traineeship.BasicTesting.Core.Interfaces.Repositories;
using Traineeship.BasicTesting.Core.Models;
using Traineeship.BasicTesting.Data.Services;
using Xunit;

namespace Traineeship.BasicTesting.Service_testing
{
    public class CurrencyServiceTests
    {
        [Fact]
        public void UnKnownCurrencyShouldThrowNotFoundException()
        {
            var currencyRepository = new Mock<ICurrencyRepository>();
            currencyRepository.Setup(p => p.GetCurrency("DE")).Returns((Currency) null);
            var currencyService = new CurrencyService(currencyRepository.Object);

            Action act = () => currencyService.CalculateConvertedValue("DE", 20);
            act.Should().Throw<CurrencyNotFoundException>()
    .WithMessage("No currency found for DE");

        }

        [Fact]
        public void CalculatedValueWithKnownCurrencyShouldSucceed()
        {
            var currency = new Currency { Id = "BP", ConvertValue = 40 };
            var currencyRepository = new Mock<ICurrencyRepository>();
            currencyRepository.Setup(p => p.GetCurrency("BP")).Returns(currency);
            var currencyService = new CurrencyService(currencyRepository.Object);

            Assert.Equal(800,currencyService.CalculateConvertedValue(currency.Id, 20));

        }
    }
}
