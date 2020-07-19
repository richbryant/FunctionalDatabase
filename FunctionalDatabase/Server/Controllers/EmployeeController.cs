using System.Threading.Tasks;
using FunctionalDatabase.Server.Data.Models;
using FunctionalDatabase.Server.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FunctionalDatabase.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeData _data;

        public EmployeeController(IEmployeeData data) => _data = data;

        [HttpGet]
        public async Task<IActionResult> Get()
            => await _data.TryGetAsync()
                .ToActionResult();

        [HttpGet]
        [Route("find/{id}")]
        public async Task<IActionResult> Get(int id)
            => await _data.TryGetAsync(id)
                .ToActionResult();

        [HttpGet]
        [Route("{page}/{pageSize}")]
        public async Task<IActionResult> Get(int page, int pageSize)
            => await _data.TryGetAsync(page, pageSize)
                .ToActionResult();

        [HttpGet]
        [Route("search/{search}")]
        public async Task<IActionResult> Get(string search)
            => await _data.TryGetAsync(search)
                .ToActionResult();

        [HttpPost]
        public async Task<IActionResult> Insert(Employee employee)
            => await _data.TryInsertAsync(employee)
                .ToActionResult();

        [HttpPut]
        public async Task<IActionResult> Update(Employee employee)
            => await _data.TryUpdateAsync(employee)
                .ToActionResult();

        [HttpDelete]
        public async Task<IActionResult> Delete(Employee employee)
            => await _data.TryDeleteAsync(employee)
                .ToActionResult();
    }
}
