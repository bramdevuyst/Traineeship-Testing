using Newtonsoft.Json;
using Traineeship.BasicTesting.Core.Interfaces.Repositories;
using Traineeship.BasicTesting.Core.Models;

namespace Traineeship.BasicTesting.Data.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private const string JsonPath = "../Data/Expenses.json";
        public void Add(Expense expense)
        {
            var expenses = GetAll();
            expenses.Add(expense);
            File.WriteAllText(JsonPath, JsonConvert.SerializeObject(expenses));
        }

        public Expense Get(int Id)
        {
           
               return GetAll().FirstOrDefault(x => x.Id == Id);            
        }

        public List<Expense> GetAll()
        {
            using (StreamReader r = new StreamReader(JsonPath))
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
            File.WriteAllText(JsonPath,JsonConvert.SerializeObject(expenses));
        }
    }
}
