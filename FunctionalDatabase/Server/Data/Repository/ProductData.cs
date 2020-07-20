using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunctionalDatabase.Shared.Models;
using LanguageExt;
using LinqToDB;
using static LanguageExt.Prelude;

namespace FunctionalDatabase.Server.Data.Repository
{
    public class ProductData : IProductData
    {
        private readonly AppDataConnection _db;

        public ProductData(AppDataConnection db) 
            => _db = db;

        public TryAsync<IEnumerable<Product>> TryGetAsync()
            => TryAsync(async () => await GetAsync());

        public TryAsync<IEnumerable<Product>> TryGetAsync(int page, int pageSize)
            => TryAsync(async () => await GetAsync(page, pageSize));

        public TryAsync<IEnumerable<Product>> TryGetAsync(string search)
            => TryAsync(async () => await GetAsync(search));

        public TryAsync<Product> TryGetAsync(int id)
            => TryAsync(async () => await GetAsync(id));

        public TryAsync<int> TryInsertAsync(Product product)
            => TryAsync(async () => await InsertAsync(product));

        public TryAsync<int> TryUpdateAsync(Product product)
            => TryAsync(async () => await UpdateAsync(product));

        public TryAsync<int> TryDeleteAsync(Product product)
            => TryAsync(async () => await DeleteAsync(product));

        private async Task<IEnumerable<Product>> GetAsync()
            => await _db.Products.ToListAsync();

        private async Task<IEnumerable<Product>> GetAsync(int page, int pageSize)
            => await Queryable.Skip<Product>(_db.Products, (page -1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

        private async Task<IEnumerable<Product>> GetAsync(string search)
            => await Queryable.Where<Product>(_db.Products, s => s.ProductName
                    .Contains(search))
                .ToListAsync();
        
        private async Task<Product> GetAsync(int id)
            => await _db.Products.FindAsync(id);

        private async Task<int> InsertAsync(Product product) 
            => await DataExtensions.InsertAsync(_db, product);

        private async Task<int> UpdateAsync(Product product)
            => await DataExtensions.UpdateAsync(_db, product);

        private async Task<int> DeleteAsync(Product product)
            => await DataExtensions.DeleteAsync(_db, product);
    }
}