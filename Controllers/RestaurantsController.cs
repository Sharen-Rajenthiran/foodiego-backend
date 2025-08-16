using FoodieGo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodieGo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _svc;
        public RestaurantsController(IRestaurantService svc) => _svc = svc;

        [HttpGet]
        public IActionResult GetAll() => Ok(_svc.GetAll());

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var r = _svc.GetById(id);
            return r is null ? NotFound() : Ok(r);
        }

        [HttpGet("{id:int}/menuitems")]
        public IActionResult GetMenu(int id) => Ok(_svc.GetMenuByRestaurant(id));
    }
}

