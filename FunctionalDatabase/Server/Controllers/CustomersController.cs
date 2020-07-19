using System.Threading.Tasks;
using FunctionalDatabase.Server.Data.Models;
using FunctionalDatabase.Server.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FunctionalDatabase.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerData _data;

        public CustomersController(ICustomerData data) => _data = data;

        [HttpGet]
        public async Task<IActionResult> Get()
            => await _data.TryGetAsync()
                .ToActionResult();

        [HttpGet]
        [Route("find/{id}")]
        public async Task<IActionResult> Get(string id)
            => await _data.TryGetAsync(id)
                .ToActionResult();

        [HttpGet]
        [Route("{page}/{pageSize}")]
        public async Task<IActionResult> Get(int page, int pageSize)
            => await _data.TryGetAsync(page, pageSize)
                .ToActionResult();

        
        [HttpPost]
        public async Task<IActionResult> Insert(Customer customer)
            => await _data.TryInsertAsync(customer)
                .ToActionResult();

        [HttpPut]
        public async Task<IActionResult> Update(Customer customer)
            => await _data.TryUpdateAsync(customer)
                .ToActionResult();

        [HttpDelete]
        public async Task<IActionResult> Delete(Customer customer)
            => await _data.TryDeleteAsync(customer)
                .ToActionResult();
    }
}
