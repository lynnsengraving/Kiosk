using Microsoft.AspNetCore.Mvc;
using LynnEngraving.Api.Services;
using LynnEngraving.Api.Models;

namespace LynnEngraving.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orders;

        public OrdersController(OrderService orders)
        {
            _orders = orders;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
        {
            var order = new Order
            {
                ProductType = request.ProductType ?? "Other",
                Notes = request.Notes,
                Status = "Submitted",
                Customer = new Customer
                {
                    Name = request.CustomerName ?? "Unknown",
                    Email = request.Email,
                    Phone = request.Phone
                }
            };
            var created = await _orders.CreateAsync(order);
            return Ok(new { created.Id, created.Status });
        }
    }

    public class CreateOrderRequest
    {
        public string? ProductType { get; set; }
        public string? Notes { get; set; }
        public string? CustomerName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
