using Newtonsoft.Json;
using Traineeship.BasicTesting.Core.Interfaces.Repositories;
using Traineeship.BasicTesting.Core.Models;

namespace Traineeship.BasicTesting.Data.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {       
        public Currency GetCurrency(string id)
        {
            using (StreamReader r = new StreamReader("../Data/Currencies.json"))
            {
                string json = r.ReadToEnd();
                List<Currency> items = JsonConvert.DeserializeObject<List<Currency>>(json);
                return items.FirstOrDefault(x => x.Id == id);
            }
        }       
    }
}
