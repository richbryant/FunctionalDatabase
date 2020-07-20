using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using FunctionalDatabase.Shared.Models;

namespace FunctionalDatabase.Client.Data.Remote
{
    public interface IProductsApi
    {
        [Get("/product")]
        Task<IEnumerable<Product>> Get();
    }
}