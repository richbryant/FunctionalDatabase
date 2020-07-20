using System.Threading.Tasks;
using FunctionalDatabase.Server.Data.Repository;
using FunctionalDatabase.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FunctionalDatabase.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsData _data;

        public OrderDetailsController(IOrderDetailsData data) => _data = data;

        [HttpGet]
        public async Task<IActionResult> Get()
            => await _data.TryGetAsync()
                .ToActionResult();

        [HttpGet]
        [Route("{page}/{pageSize}")]
        public async Task<IActionResult> Get(int page, int pageSize)
            => await _data.TryGetAsync(page, pageSize)
                .ToActionResult();

        [HttpPost]
        public async Task<IActionResult> Insert(OrderDetail orderDetail)
            => await _data.TryInsertAsync(orderDetail)
                .ToActionResult();

        [HttpPut]
        public async Task<IActionResult> Update(OrderDetail orderDetail)
            => await _data.TryUpdateAsync(orderDetail)
                .ToActionResult();

        [HttpDelete]
        public async Task<IActionResult> Delete(OrderDetail orderDetail)
            => await _data.TryDeleteAsync(orderDetail)
                .ToActionResult();
    }
}
