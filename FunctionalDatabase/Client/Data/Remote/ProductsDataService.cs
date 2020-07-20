using System.Collections.Generic;
using System.Threading.Tasks;
using FunctionalDatabase.Shared.Models;
using LanguageExt;
using static LanguageExt.Prelude;

namespace FunctionalDatabase.Client.Data.Remote
{
    public class ProductsDataService : IProductsDataService
    {
        private readonly IProductsApi _productsApi;

        public ProductsDataService(IProductsApi productsApi) => _productsApi = productsApi;


        public TryAsync<IEnumerable<Product>> TryGetAllAsync()
            => TryAsync(async () => await GetAllAsync());




        private async Task<IEnumerable<Product>> GetAllAsync()
            => await _productsApi.Get();
    }
}