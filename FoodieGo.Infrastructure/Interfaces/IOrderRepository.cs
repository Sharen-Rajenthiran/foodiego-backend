using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodieGo.Domain.Entities;

namespace FoodieGo.Infrastructure.Interfaces
{
    public interface IOrderRepository
    {
        int CreateOrder(Order order);
        void AddOrderItem(OrderItem item);
        Order? GetById(int id);
    }
}
