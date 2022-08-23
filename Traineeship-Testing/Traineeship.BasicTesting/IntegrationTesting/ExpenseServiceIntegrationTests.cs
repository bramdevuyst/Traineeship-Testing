using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Traineeship.BasicTesting.Core.Models;
using Traineeship.BasicTesting.Core.Service;
using Traineeship.BasicTesting.Data.Repositories;
using Traineeship.BasicTesting.Data.Services;
using Xunit;

namespace Traineeship.BasicTesting.IntegrationTesting
{
    public class ExpenseServiceIntegrationTests : IDisposable
    {
        private const string JsonPath = ".../Data/Expenses.json";

        public ExpenseService _expenseService { get; set; }
        public CurrencyService _currencyService { get; set; }
        private readonly IConfiguration configuration;

        public ExpenseServiceIntegrationTests()
        {
            configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@"appsettings.json", false, false)
                .Build();
            var test = configuration.GetSection("DataLocation");
            _currencyService = new CurrencyService(new CurrencyRepository());
            var expenseRepository = new ExpenseRepository(configuration);
            _expenseService = new ExpenseService(expenseRepository, _currencyService);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void AddExpenseShouldSucceed()
        {
            var addedItems = new List<Expense>();
            _expenseService.Add(new Core.Models.Expense { Id = 1, Amount = 400, Description = "ola", BankAccount = "BE68012345678911", Currency = "BP", Status = "NEW" });
            try
            {
                using (StreamReader r = new StreamReader(JsonPath))
                {
                    string json = r.ReadToEnd();
                    addedItems = JsonConvert.DeserializeObject<List<Expense>>(json);
                }
                var test = addedItems;
            }
            catch(Exception ex)
            {
                var test = ex;
            }
            
        }
    }
}
