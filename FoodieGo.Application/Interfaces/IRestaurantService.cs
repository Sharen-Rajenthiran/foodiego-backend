using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodieGo.Domain.Entities;
using FoodieGo.Application.DTOs;

namespace FoodieGo.Application.Interfaces
{
    public interface IRestaurantService
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant? GetById(int id);
        IEnumerable<MenuItem> GetMenuByRestaurant(int restaurantId);
        IEnumerable<MenuItem> GetAllMenuItems();
        MenuItem? GetMenuItemById(int id);
    }
}
