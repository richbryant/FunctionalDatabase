using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunctionalDatabase.Shared.Models;
using LanguageExt;
using LinqToDB;
using static LanguageExt.Prelude;

namespace FunctionalDatabase.Server.Data.Repository
{
    public class OrderData : IOrderData
    {
        private readonly AppDataConnection _db;

        public OrderData(AppDataConnection db) => _db = db;

        public TryAsync<IEnumerable<Order>> TryGetAsync()
            => TryAsync(async () => await GetAsync());

        public TryAsync<IEnumerable<Order>> TryGetAsync(int page, int pageSize)
            => TryAsync(async () => await GetAsync(page, pageSize));

        public TryAsync<Order> TryGetAsync(int id)
            => TryAsync(async () => await GetAsync(id));

        public TryAsync<int> TryInsertAsync(Order order)
            => TryAsync(async () => await InsertAsync(order));

        public TryAsync<int> TryUpdateAsync(Order order)
            => TryAsync(async () => await UpdateAsync(order));

        public TryAsync<int> TryDeleteAsync(Order order)
            => TryAsync(async () => await DeleteAsync(order));



        private async Task<IEnumerable<Order>> GetAsync()
            => await _db.Orders.ToListAsync();

        private async Task<IEnumerable<Order>> GetAsync(int page, int pageSize)
            => await _db.Orders
                .Skip((page -1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

        private async Task<Order> GetAsync(int id)
            => await _db.Orders.FindAsync(id);

        private async Task<int> InsertAsync(Order order) 
            => await _db.InsertAsync(order);

        private async Task<int> UpdateAsync(Order order)
            => await _db.UpdateAsync(order);

        private async Task<int> DeleteAsync(Order order)
            => await _db.DeleteAsync(order);
    }
}