using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunctionalDatabase.Server.Data.Models;
using LanguageExt;
using LinqToDB;
using static LanguageExt.Prelude;

namespace FunctionalDatabase.Server.Data.Repository
{
    public class EmployeeData : IEmployeeData
    {
        private readonly AppDataConnection _db;

        public EmployeeData(AppDataConnection db) 
            => _db = db;

        public TryAsync<IEnumerable<Employee>> TryGetAsync()
            => TryAsync(async () => await GetAsync());

        public TryAsync<IEnumerable<Employee>> TryGetAsync(int page, int pageSize)
            => TryAsync(async () => await GetAsync(page, pageSize));

        public TryAsync<IEnumerable<Employee>> TryGetAsync(string search)
            => TryAsync(async () => await GetAsync(search));

        public TryAsync<Employee> TryGetAsync(int id)
            => TryAsync(async () => await GetAsync(id));

        public TryAsync<int> TryInsertAsync(Employee employee)
            => TryAsync(async () => await InsertAsync(employee));

        public TryAsync<int> TryUpdateAsync(Employee employee)
            => TryAsync(async () => await UpdateAsync(employee));

        public TryAsync<int> TryDeleteAsync(Employee employee)
            => TryAsync(async () => await DeleteAsync(employee));

        private async Task<IEnumerable<Employee>> GetAsync()
            => await _db.Employees.ToListAsync();

        private async Task<IEnumerable<Employee>> GetAsync(int page, int pageSize)
            => await _db.Employees
                .Skip((page -1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

        private async Task<IEnumerable<Employee>> GetAsync(string search)
            => await _db.Employees
                .Where(s => s.LastName
                    .Contains(search))
                .ToListAsync();
        
        private async Task<Employee> GetAsync(int id)
            => await _db.Employees.FindAsync(id);

        private async Task<int> InsertAsync(Employee employee) 
            => await _db.InsertAsync(employee);

        private async Task<int> UpdateAsync(Employee employee)
            => await _db.UpdateAsync(employee);

        private async Task<int> DeleteAsync(Employee employee)
            => await _db.DeleteAsync(employee);
        
    }
}