using FoodieGo.Application.DTOs;
using FoodieGo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodieGo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _svc;
        public OrdersController(IOrderService svc) => _svc = svc;

        [HttpPost]
        public IActionResult Place(PlaceOrderRequest req)
        {
            if (req.Items is null || req.Items.Count == 0) return BadRequest("Order must contain at least one item.");
            var order = _svc.PlaceOrder(req);
            return Ok(order);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var order = _svc.GetOrder(id);
            return order is null ? NotFound() : Ok(order);
        }
    }
}
