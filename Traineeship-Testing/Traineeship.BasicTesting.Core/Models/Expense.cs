namespace Traineeship.BasicTesting.Core.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public double AmountInEuro { get; set; }

        public string Currency { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

    }
}
