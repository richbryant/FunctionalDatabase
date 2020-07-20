using System.Collections.Generic;
using FunctionalDatabase.Shared.Models;
using LanguageExt;

namespace FunctionalDatabase.Server.Data.Repository
{
    public interface IProductData
    {
        TryAsync<IEnumerable<Product>> TryGetAsync();
        TryAsync<IEnumerable<Product>> TryGetAsync(int page, int pageSize);
        TryAsync<IEnumerable<Product>> TryGetAsync(string search);
        TryAsync<Product> TryGetAsync(int id);
        TryAsync<int> TryInsertAsync(Product product);
        TryAsync<int> TryUpdateAsync(Product product);
        TryAsync<int> TryDeleteAsync(Product product);
    }
}