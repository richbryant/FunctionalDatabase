using System.Collections.Generic;
using FunctionalDatabase.Shared.Models;
using LanguageExt;

namespace FunctionalDatabase.Server.Data.Repository
{
    public interface IOrderData
    {
        TryAsync<IEnumerable<Order>> TryGetAsync();
        TryAsync<IEnumerable<Order>> TryGetAsync(int page, int pageSize);
        TryAsync<Order> TryGetAsync(int id);
        TryAsync<int> TryInsertAsync(Order order);
        TryAsync<int> TryUpdateAsync(Order order);
        TryAsync<int> TryDeleteAsync(Order order);
    }
}