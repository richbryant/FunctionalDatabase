using System.Threading.Tasks;
using FunctionalDatabase.Server.Data.Repository;
using FunctionalDatabase.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FunctionalDatabase.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierData _data;

        public SuppliersController(ISupplierData data)
            => _data = data;

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
        public async Task<IActionResult> Insert(Supplier supplier)
            => await _data.TryInsertAsync(supplier)
                .ToActionResult();

        [HttpPut]
        public async Task<IActionResult> Update(Supplier supplier)
            => await _data.TryUpdateAsync(supplier)
                .ToActionResult();

        [HttpDelete]
        public async Task<IActionResult> Delete(Supplier supplier)
            => await _data.TryDeleteAsync(supplier)
                .ToActionResult();


    }
}
