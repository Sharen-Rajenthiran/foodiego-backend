using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodieGo.Application.DTOs;
using FoodieGo.Domain.Entities;

namespace FoodieGo.Application.Interfaces
{
    public interface IOrderService
    {
        Order PlaceOrder(PlaceOrderRequest request);
        Order? GetOrder(int id);
    }
}
