using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieGo.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string Status { get; set; } = "Pending"; // Pending | Preparing | OutForDelivery | Delivered
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
