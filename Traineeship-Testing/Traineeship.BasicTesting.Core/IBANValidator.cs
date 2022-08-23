namespace Traineeship.BasicTesting.Core
{
    public static class IBANValidator
    {
        public static List<string> ValidateIBANNr(string IbanNumber)
        {
            var errors = new List<string>();
            if (!IbanNumber.StartsWith("BE"))
                errors.Add("IBAN number is not Belgian");
            if (IbanNumber.Substring(2, 2) != "68")
                errors.Add("The IBAN check digits aren't correct");
            if (IbanNumber.Length != 16)
                errors.Add("A Belgian IBAN needs to be exact 16 char long");
            return errors;
        }
    }
}
