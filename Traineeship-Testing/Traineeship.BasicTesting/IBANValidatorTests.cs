using FluentAssertions;
using Traineeship.BasicTesting.Core;
using Xunit;

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

        [Fact]
        public void ValidateIBANWithMultipleIssues()
        {
            var ibanValidator = "FR78201589786";
            var result = IBANValidator.ValidateIBANNr(ibanValidator);
            result.Should().HaveCount(3);
            result.First().Should().Be("IBAN number is not Belgian");
            result.Should().ContainMatch("IBAN number is not Belgian");
            result.Should().ContainMatch("The IBAN check digits aren't correct");
            result.Should().ContainMatch("A Belgian IBAN needs to be exact 16 char long");


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
