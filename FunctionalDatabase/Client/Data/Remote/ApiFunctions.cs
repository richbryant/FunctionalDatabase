using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using FunctionalDatabase.Shared.Models;
using LanguageExt;
using static LanguageExt.Prelude;

namespace FunctionalDatabase.Client.Data.Remote
{
    public static class ApiFunctions
    {
        public static TryAsync<List<Product>> TryGetProducts()
            => TryAsync(async () => await GetProductsAsync()
                .ConfigureAwait(false));


        public static async Task<List<Product>> GetProductsAsync()
            => await ApiConstants.ProductsApi
                .GetJsonAsync<List<Product>>();

    }
}