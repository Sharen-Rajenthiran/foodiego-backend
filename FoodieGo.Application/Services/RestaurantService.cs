using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodieGo.Application.Interfaces;
using FoodieGo.Domain.Entities;
using FoodieGo.Infrastructure.Interfaces;

namespace FoodieGo.Application.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurants;
        private readonly IMenuItemRepository _menuItems;
        public RestaurantService(IRestaurantRepository restaurants, IMenuItemRepository menuItems)
        {
            _restaurants = restaurants;
            _menuItems = menuItems;
        }
        public IEnumerable<Restaurant> GetAll() => _restaurants.GetAll();
        public Restaurant? GetById(int id) => _restaurants.GetById(id);
        public IEnumerable<MenuItem> GetMenuByRestaurant(int restaurantId) => _menuItems.GetByRestaurant(restaurantId);
        public IEnumerable<MenuItem> GetAllMenuItems() => _menuItems.GetAll();
        public MenuItem? GetMenuItemById(int id) => _menuItems.GetById(id);
    }
}
