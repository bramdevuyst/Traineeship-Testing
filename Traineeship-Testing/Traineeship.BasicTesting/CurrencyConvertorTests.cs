using Traineeship.BasicTesting.Core;

namespace Traineeship.BasicTesting
{
    public class CurrencyConvertorTests : IDisposable
    {
        public CurrencyConverter convertor { get; set; }
        public CurrencyConvertorTests()
        {
            convertor = new CurrencyConverter ();
        }
        [Fact]
        public void ConvertFromUSD()
        {
            Assert.Equal(20.2, convertor.ConvertToEuro(20, "USD"),1);
        }
        [Fact]
        public void ConvertFromAUD()
        {
            Assert.Equal(23.8, convertor.ConvertToEuro(20, "BP"),1);
        }
        [Fact]
        public void ConvertFromBP()
        {
            Assert.Equal(20.8, convertor.ConvertToEuro(20, "CHF"),1);
        }
        [Fact]
        public void ConvertFromEURO()
        {
            Assert.Equal(13.80, convertor.ConvertToEuro(20, "AUD"),1);
        }
        [Theory]
        [InlineData(20, "USD", 20.2)]
        [InlineData(20, "BP", 23.8)]
        [InlineData(20, "CHF", 20.8)]
        [InlineData(20, "AUD", 13.80)]
        [InlineData(20, "EURO", 20.0)]
        public void ConvertToEeuro(double value, string currency, double result)
        {
            Assert.Equal(result, convertor.ConvertToEuro(value, currency), 1);
        }

        public void Dispose()
        {
        }
    }
}
