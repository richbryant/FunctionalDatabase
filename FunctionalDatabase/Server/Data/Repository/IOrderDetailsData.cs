using System.Collections.Generic;
using FunctionalDatabase.Shared.Models;
using LanguageExt;

namespace FunctionalDatabase.Server.Data.Repository
{
    public interface IOrderDetailsData
    {
        TryAsync<IEnumerable<OrderDetail>> TryGetAsync();
        TryAsync<IEnumerable<OrderDetail>> TryGetAsync(int page, int pageSize);
        TryAsync<int> TryInsertAsync(OrderDetail orderDetail);
        TryAsync<int> TryUpdateAsync(OrderDetail orderDetail);
        TryAsync<int> TryDeleteAsync(OrderDetail orderDetail);
    }
}