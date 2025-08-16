using FoodieGo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodieGo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemsController : ControllerBase
    {
        private readonly IRestaurantService _svc;
        public MenuItemsController(IRestaurantService svc) => _svc = svc;

        [HttpGet]
        public IActionResult GetAll() => Ok(_svc.GetAllMenuItems());

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var m = _svc.GetMenuItemById(id);
            return m is null ? NotFound() : Ok(m);
        }
    }
}
