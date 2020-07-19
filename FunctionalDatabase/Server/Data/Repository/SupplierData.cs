using FunctionalDatabase.Server.Data.Models;
using LinqToDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageExt;
using static LanguageExt.Prelude;

namespace FunctionalDatabase.Server.Data.Repository
{
    public class SupplierData : ISupplierData
    {
        private readonly AppDataConnection _db;

        public SupplierData(AppDataConnection db) => _db = db;

        public TryAsync<IEnumerable<Supplier>> TryGetAsync()
            => TryAsync(async () => await GetAsync());

        public TryAsync<IEnumerable<Supplier>> TryGetAsync(int page, int pageSize)
            => TryAsync(async () => await GetAsync(page, pageSize));

        public TryAsync<IEnumerable<Supplier>> TryGetAsync(string search)
            => TryAsync(async () => await GetAsync(search));

        public TryAsync<Supplier> TryGetAsync(int id)
            => TryAsync(async () => await GetAsync(id));

        public TryAsync<int> TryInsertAsync(Supplier supplier)
            => TryAsync(async () => await InsertAsync(supplier));

        public TryAsync<int> TryUpdateAsync(Supplier supplier)
            => TryAsync(async () => await UpdateAsync(supplier));

        public TryAsync<int> TryDeleteAsync(Supplier supplier)
            => TryAsync(async () => await DeleteAsync(supplier));



        private async Task<IEnumerable<Supplier>> GetAsync()
            => await _db.Suppliers.ToListAsync();

        private async Task<IEnumerable<Supplier>> GetAsync(int page, int pageSize)
            => await _db.Suppliers
                .Skip((page -1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

        private async Task<IEnumerable<Supplier>> GetAsync(string search)
            => await _db.Suppliers
                .Where(s => s.CompanyName
                    .Contains(search))
                .ToListAsync();
        
        private async Task<Supplier> GetAsync(int id)
            => await _db.Suppliers.FindAsync(id);

        private async Task<int> InsertAsync(Supplier supplier) 
            => await _db.InsertAsync(supplier);

        private async Task<int> UpdateAsync(Supplier supplier)
            => await _db.UpdateAsync(supplier);

        private async Task<int> DeleteAsync(Supplier supplier)
            => await _db.DeleteAsync(supplier);
    }
}