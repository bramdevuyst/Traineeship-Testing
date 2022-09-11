using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Traineeship.BasicTesting.Core.Interfaces.Repositories;
using Traineeship.BasicTesting.Core.Models;

namespace Traineeship.BasicTesting.Data.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        public string JsonPath = "/Expenses.json";
        private readonly IConfiguration configuration;
        public ExpenseRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void Add(Expense expense)
        {
            var expenses = GetAll();
            expenses.Add(expense);
            File.WriteAllText(configuration.GetSection("DataLocation").Value + JsonPath, JsonConvert.SerializeObject(expenses));
        }

        public Expense Get(int Id)
        {

            return GetAll().FirstOrDefault(x => x.Id == Id);
        }

        public List<Expense> GetAll()
        {
            using (StreamReader r = new StreamReader(configuration.GetSection("DataLocation").Value + JsonPath))
            {
                string json = r.ReadToEnd();
                List<Expense> items = JsonConvert.DeserializeObject<List<Expense>>(json);
                return items;
            }
        }

        public void Update(Expense expense)
        {
            var expenses = GetAll();
            var expenseToUpdate = expenses.First(x => x.Id == expense.Id);
            expenses.Remove(expenseToUpdate);
            expenses.Add(expense);
            File.WriteAllText(configuration.GetSection("DataLocation").Value + JsonPath, JsonConvert.SerializeObject(expenses));
        }
        public void DeleteAll()
        {
            var expenses = GetAll();
            expenses.Clear();
            File.WriteAllText(configuration.GetSection("DataLocation").Value + JsonPath, JsonConvert.SerializeObject(expenses));
        }
    }
}
