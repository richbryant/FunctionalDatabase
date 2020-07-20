using System.Collections.Generic;
using FunctionalDatabase.Shared.Models;
using LanguageExt;

namespace FunctionalDatabase.Server.Data.Repository
{
    public interface ICategoriesData
    {
        TryAsync<IEnumerable<Category>> TryGetAsync();
        TryAsync<IEnumerable<Category>> TryGetAsync(int page, int pageSize);
        TryAsync<IEnumerable<Category>> TryGetAsync(string search);
        TryAsync<Category> TryGetAsync(int id);
        TryAsync<int> TryInsertAsync(Category category);
        TryAsync<int> TryUpdateAsync(Category category);
        TryAsync<int> TryDeleteAsync(Category category);
    }
}