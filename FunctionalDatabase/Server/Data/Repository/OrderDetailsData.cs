using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunctionalDatabase.Shared.Models;
using LanguageExt;
using LinqToDB;
using static LanguageExt.Prelude;

namespace FunctionalDatabase.Server.Data.Repository
{
    public class OrderDetailsData : IOrderDetailsData
    {
        private readonly AppDataConnection _db;

        public OrderDetailsData(AppDataConnection db) 
            => _db = db;

        public TryAsync<IEnumerable<OrderDetail>> TryGetAsync()
            => TryAsync(async () => await GetAsync());

        public TryAsync<IEnumerable<OrderDetail>> TryGetAsync(int page, int pageSize)
            => TryAsync(async () => await GetAsync(page, pageSize));

        public TryAsync<int> TryInsertAsync(OrderDetail orderDetail)
            => TryAsync(async () => await InsertAsync(orderDetail));

        public TryAsync<int> TryUpdateAsync(OrderDetail orderDetail)
            => TryAsync(async () => await UpdateAsync(orderDetail));

        public TryAsync<int> TryDeleteAsync(OrderDetail orderDetail)
            => TryAsync(async () => await DeleteAsync(orderDetail));

        private async Task<IEnumerable<OrderDetail>> GetAsync()
            => await _db.OrderDetails.ToListAsync();

        private async Task<IEnumerable<OrderDetail>> GetAsync(int page, int pageSize)
            => await _db.OrderDetails
                .Skip((page -1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

        private async Task<int> InsertAsync(OrderDetail orderDetail) 
            => await _db.InsertAsync(orderDetail);

        private async Task<int> UpdateAsync(OrderDetail orderDetail)
            => await _db.UpdateAsync(orderDetail);

        private async Task<int> DeleteAsync(OrderDetail orderDetail)
            => await _db.DeleteAsync(orderDetail);
    }
}