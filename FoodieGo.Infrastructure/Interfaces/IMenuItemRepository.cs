using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodieGo.Domain.Entities;

namespace FoodieGo.Infrastructure.Interfaces
{
    public interface IMenuItemRepository
    {
        IEnumerable<MenuItem> GetAll();
        IEnumerable<MenuItem> GetByRestaurant(int restaurantId);
        MenuItem? GetById(int id);
    }
}
