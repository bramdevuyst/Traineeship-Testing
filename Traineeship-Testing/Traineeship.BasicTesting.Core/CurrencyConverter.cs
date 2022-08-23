namespace Traineeship.BasicTesting.Core
{
    public class CurrencyConverter
    {
        public double ConvertToEuro(double amount, string currency)
        {
            switch(currency)
            {
                case "USD":
                    return amount * 1.01;

                case "BP":
                    return amount * 1.19;
                case "CHF":
                    return amount * 1.04;
                case "AUD":
                    return amount * 0.69;
                default :
                    return amount;
            }
        }
    }
}
