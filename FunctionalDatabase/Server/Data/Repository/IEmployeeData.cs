using System.Collections.Generic;
using FunctionalDatabase.Shared.Models;
using LanguageExt;

namespace FunctionalDatabase.Server.Data.Repository
{
    public interface IEmployeeData
    {
        TryAsync<IEnumerable<Employee>> TryGetAsync();
        TryAsync<IEnumerable<Employee>> TryGetAsync(int page, int pageSize);
        TryAsync<IEnumerable<Employee>> TryGetAsync(string search);
        TryAsync<Employee> TryGetAsync(int id);
        TryAsync<int> TryInsertAsync(Employee employee);
        TryAsync<int> TryUpdateAsync(Employee employee);
        TryAsync<int> TryDeleteAsync(Employee employee);
    }
}