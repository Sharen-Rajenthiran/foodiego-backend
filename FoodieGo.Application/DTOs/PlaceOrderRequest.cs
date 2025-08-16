using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieGo.Application.DTOs
{
    public class PlaceOrderRequest
    {
        public int RestaurantId { get; set; }
        public List<PlaceOrderItem> Items { get; set; } = new();
    }

    public class PlaceOrderItem
    {
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
    }
}
