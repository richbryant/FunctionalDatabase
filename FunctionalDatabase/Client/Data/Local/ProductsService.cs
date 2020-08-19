using System.Collections.Generic;
using System.Threading.Tasks;
using FunctionalDatabase.Shared.Models;

namespace FunctionalDatabase.Client.Data.Local
{
    public interface IProductsService
    {
        Task<List<Product>> GetProductsAsync();
        Task LoadProductsAsync(List<Product> products);
    }

    public class ProductsService : IProductsService
    {
        private readonly NorthwindDb _db;

        public ProductsService(NorthwindDb db) => _db = db;

        public async Task<List<Product>> GetProductsAsync()
        {
            await _db.OpenIndexedDb();
            return await _db.GetAll<Product>("Product");
        }

        public async Task LoadProductsAsync(List<Product> products)
        {
            await _db.OpenIndexedDb();
            await _db.AddItems<Product>("Product", products);
        }
    }
}