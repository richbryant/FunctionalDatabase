using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunctionalDatabase.Shared.Models;
using LanguageExt;
using LinqToDB;
using static LanguageExt.Prelude;

namespace FunctionalDatabase.Server.Data.Repository
{
    public class CategoriesData : ICategoriesData
    {
        private readonly AppDataConnection _db;

        public CategoriesData(AppDataConnection db) 
            => _db = db;

        public TryAsync<IEnumerable<Category>> TryGetAsync()
            => TryAsync(async () => await GetAsync());

        public TryAsync<IEnumerable<Category>> TryGetAsync(int page, int pageSize)
            => TryAsync(async () => await GetAsync(page, pageSize));

        public TryAsync<IEnumerable<Category>> TryGetAsync(string search)
            => TryAsync(async () => await GetAsync(search));

        public TryAsync<Category> TryGetAsync(int id)
            => TryAsync(async () => await GetAsync(id));

        public TryAsync<int> TryInsertAsync(Category category)
            => TryAsync(async () => await InsertAsync(category));

        public TryAsync<int> TryUpdateAsync(Category category)
            => TryAsync(async () => await UpdateAsync(category));

        public TryAsync<int> TryDeleteAsync(Category category)
            => TryAsync(async () => await DeleteAsync(category));

        private async Task<IEnumerable<Category>> GetAsync()
            => await _db.Categories.ToListAsync();

        private async Task<IEnumerable<Category>> GetAsync(int page, int pageSize)
            => await _db.Categories
                .Skip((page -1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

        private async Task<IEnumerable<Category>> GetAsync(string search)
            => await _db.Categories
                .Where(s => s.CategoryName
                    .Contains(search))
                .ToListAsync();
        
        private async Task<Category> GetAsync(int id)
            => await _db.Categories.FindAsync(id);

        private async Task<int> InsertAsync(Category category) 
            => await _db.InsertAsync(category);

        private async Task<int> UpdateAsync(Category category)
            => await _db.UpdateAsync(category);

        private async Task<int> DeleteAsync(Category category)
            => await _db.DeleteAsync(category);
    }
}