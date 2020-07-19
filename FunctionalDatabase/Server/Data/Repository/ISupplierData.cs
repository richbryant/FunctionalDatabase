using System.Collections.Generic;
using FunctionalDatabase.Server.Data.Models;
using LanguageExt;

namespace FunctionalDatabase.Server.Data.Repository
{
    public interface ISupplierData
    {
        TryAsync<IEnumerable<Supplier>> TryGetAsync();
        TryAsync<IEnumerable<Supplier>> TryGetAsync(int page, int pageSize);
        TryAsync<IEnumerable<Supplier>> TryGetAsync(string search);
        TryAsync<Supplier> TryGetAsync(int id);
        TryAsync<int> TryInsertAsync(Supplier supplier);
        TryAsync<int> TryUpdateAsync(Supplier supplier);
        TryAsync<int> TryDeleteAsync(Supplier supplier);
    }
}