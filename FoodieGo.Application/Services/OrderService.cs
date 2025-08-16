using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodieGo.Application.DTOs;
using FoodieGo.Application.Interfaces;
using FoodieGo.Domain.Entities;
using FoodieGo.Infrastructure.Interfaces;

namespace FoodieGo.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orders;
        private readonly IMenuItemRepository _menuItems;

        public OrderService(IOrderRepository orders, IMenuItemRepository menuItems)
        {
            _orders = orders;
            _menuItems = menuItems;
        }

        public Order PlaceOrder(PlaceOrderRequest request)
        {
            if (request.Items.Count == 0) throw new ArgumentException("Order requires at least one item");

            // Create order record
            var order = new Order { RestaurantId = request.RestaurantId, Status = "Pending", CreatedAt = DateTime.UtcNow };
            var orderId = _orders.CreateOrder(order);

            // Create order items with price lookup
            foreach (var item in request.Items)
            {
                var menu = _menuItems.GetById(item.MenuItemId) ?? throw new InvalidOperationException($"MenuItem {item.MenuItemId} not found");
                _orders.AddOrderItem(new OrderItem
                {
                    OrderId = orderId,
                    MenuItemId = item.MenuItemId,
                    Quantity = item.Quantity,
                    UnitPrice = menu.Price
                });
            }

            order.Id = orderId;
            return order;
        }

        public Order? GetOrder(int id) => _orders.GetById(id);
    }
}
