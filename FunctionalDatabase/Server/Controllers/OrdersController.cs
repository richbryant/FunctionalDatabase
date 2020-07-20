using System.Threading.Tasks;
using FunctionalDatabase.Server.Data.Repository;
using FunctionalDatabase.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FunctionalDatabase.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderData _data;

        public OrdersController(IOrderData data) => _data = data;

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

        
        [HttpPost]
        public async Task<IActionResult> Insert(Order order)
            => await _data.TryInsertAsync(order)
                .ToActionResult();

        [HttpPut]
        public async Task<IActionResult> Update(Order order)
            => await _data.TryUpdateAsync(order)
                .ToActionResult();

        [HttpDelete]
        public async Task<IActionResult> Delete(Order order)
            => await _data.TryDeleteAsync(order)
                .ToActionResult();
    }
}
