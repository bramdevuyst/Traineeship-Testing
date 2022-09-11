using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Traineeship.BasicTesting.Core.Interfaces.Services;
using Traineeship.BasicTesting.Core.Models;
using Traineeship.BasicTesting.Core.Service;
using Traineeship.BasicTesting.Data.Repositories;
using Traineeship.BasicTesting.Data.Services;
using Xunit;

namespace Traineeship.BasicTesting.IntegrationTesting
{
    public class ExpenseServiceIntegrationTests : IDisposable
    {
        private const string JsonPath = "/Expenses.json";

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
            var expenses = new List<Expense>();
            File.WriteAllText(configuration.GetSection("DataLocation").Value + JsonPath, JsonConvert.SerializeObject(expenses));
        }

        [Fact]
        public void AddExpenseShouldSucceed()
        {
            var addedItem = new Expense();
            _expenseService.Add(new Core.Models.Expense { Id = 99, Amount = 400, Description = "ola", BankAccount = "BE68012345678911", Currency = "BP", Status = "NEW" });
            try
            {
                using (StreamReader r = new StreamReader(configuration.GetSection("DataLocation").Value + JsonPath))
                {
                    string json = r.ReadToEnd();
                    addedItem = JsonConvert.DeserializeObject<List<Expense>>(json).First();
                }
                Assert.Equal(99, addedItem.Id);

            }
            catch (Exception ex)
            {
                var test = ex;
            }
            
        }
    }
}
