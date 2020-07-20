using System.Threading.Tasks;
using FunctionalDatabase.Server.Data.Repository;
using FunctionalDatabase.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FunctionalDatabase.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductData _data;

        public ProductController(IProductData data) => _data = data;

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
        public async Task<IActionResult> Insert(Product product)
            => await _data.TryInsertAsync(product)
                .ToActionResult();

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
            => await _data.TryUpdateAsync(product)
                .ToActionResult();

        [HttpDelete]
        public async Task<IActionResult> Delete(Product product)
            => await _data.TryDeleteAsync(product)
                .ToActionResult();

    }
}
