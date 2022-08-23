namespace Traineeship.BasicTesting.Core.Exceptions
{
    public class ExpenseAlreadyExistingException : ApplicationException
    {
        public ExpenseAlreadyExistingException(string message) : base(message)
        {

        }
    }
}
