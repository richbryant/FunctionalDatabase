using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunctionalDatabase.Server.Data.Models;
using LanguageExt;
using LinqToDB;
using static LanguageExt.Prelude;

namespace FunctionalDatabase.Server.Data.Repository
{
    public class CustomerData : ICustomerData
    {
        private readonly AppDataConnection _db;

        public CustomerData(AppDataConnection db) => _db = db;

        public TryAsync<IEnumerable<Customer>> TryGetAsync()
            => TryAsync(async () => await GetAsync());

        public TryAsync<IEnumerable<Customer>> TryGetAsync(int page, int pageSize)
            => TryAsync(async () => await GetAsync(page, pageSize));

        public TryAsync<Customer> TryGetAsync(string id)
            => TryAsync(async () => await GetAsync(id));

        public TryAsync<int> TryInsertAsync(Customer customer)
            => TryAsync(async () => await InsertAsync(customer));

        public TryAsync<int> TryUpdateAsync(Customer customer)
            => TryAsync(async () => await UpdateAsync(customer));

        public TryAsync<int> TryDeleteAsync(Customer customer)
            => TryAsync(async () => await DeleteAsync(customer));



        private async Task<IEnumerable<Customer>> GetAsync()
            => await _db.Customers.ToListAsync();

        private async Task<IEnumerable<Customer>> GetAsync(int page, int pageSize)
            => await _db.Customers
                .Skip((page -1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

        private async Task<Customer> GetAsync(string id)
            => await _db.Customers.FindAsync(id);

        private async Task<int> InsertAsync(Customer customer) 
            => await _db.InsertAsync(customer);

        private async Task<int> UpdateAsync(Customer customer)
            => await _db.UpdateAsync(customer);

        private async Task<int> DeleteAsync(Customer customer)
            => await _db.DeleteAsync(customer);
    }
}