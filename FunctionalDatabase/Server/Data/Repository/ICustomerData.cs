using System.Collections.Generic;
using FunctionalDatabase.Server.Data.Models;
using LanguageExt;

namespace FunctionalDatabase.Server.Data.Repository
{
    public interface ICustomerData
    {
        TryAsync<IEnumerable<Customer>> TryGetAsync();
        TryAsync<IEnumerable<Customer>> TryGetAsync(int page, int pageSize);
        TryAsync<Customer> TryGetAsync(string id);
        TryAsync<int> TryInsertAsync(Customer customer);
        TryAsync<int> TryUpdateAsync(Customer customer);
        TryAsync<int> TryDeleteAsync(Customer customer);
    }
}