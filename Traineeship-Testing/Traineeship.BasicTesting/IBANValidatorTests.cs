using Traineeship.BasicTesting.Core;

namespace Traineeship.BasicTesting
{
    public class IBANValidatorTests
    {
        [Fact]
        public void ValidateNotBelgianIBAN()
        {
            var ibanValidator = "FR68201589785610";
            var result = IBANValidator.ValidateIBANNr(ibanValidator);
            Assert.Equal("IBAN number is not Belgian", result.First());
        }
        [Fact]
        public void ValidateIncorrectSecurityIBAN()
        {
            var ibanValidator = "BE72201589785610";
            var result = IBANValidator.ValidateIBANNr(ibanValidator);
            Assert.Equal("The IBAN check digits aren't correct", result.First());
        }

        [Fact]
        public void ValidateIncorrectLengthIBAN()
        {
            var ibanValidator = "BE682015897856";
            var result = IBANValidator.ValidateIBANNr(ibanValidator);
            Assert.Equal("A Belgian IBAN needs to be exact 16 char long", result.First());
        }

        [Theory]
        [InlineData("FR68201589785610", "IBAN number is not Belgian")]
        [InlineData("BE72201589785610", "The IBAN check digits aren't correct")]
        [InlineData("BE682015897856", "A Belgian IBAN needs to be exact 16 char long")]

        public void ValidateIBANs(string Iban, string error)
        {
            var ibanValidator = "BE682015897856";
            var result = IBANValidator.ValidateIBANNr(Iban);
            Assert.Equal(error, result.First());
        }
    }
}
