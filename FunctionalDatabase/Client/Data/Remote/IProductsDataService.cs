using System.Collections.Generic;
using FunctionalDatabase.Shared.Models;
using LanguageExt;

namespace FunctionalDatabase.Client.Data.Remote
{
    public interface IProductsDataService
    {
        TryAsync<IEnumerable<Product>> TryGetAllAsync();
    }
}