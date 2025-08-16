using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodieGo.Domain.Entities;
using FoodieGo.Infrastructure.Database;
using FoodieGo.Infrastructure.Interfaces;
using MySql.Data.MySqlClient;

namespace FoodieGo.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SqlConnectionFactory _factory;
        public OrderRepository(SqlConnectionFactory factory) => _factory = factory;

        public int CreateOrder(Order order)
        {
            using var con = _factory.Create();
            con.Open();
            using var cmd = new MySqlCommand(@"INSERT INTO Orders(RestaurantId, Status, CreatedAt) VALUES(@rid, @st, @ca); SELECT LAST_INSERT_ID();", con);
            cmd.Parameters.AddWithValue("@rid", order.RestaurantId);
            cmd.Parameters.AddWithValue("@st", order.Status);
            cmd.Parameters.AddWithValue("@ca", order.CreatedAt);
            var id = Convert.ToInt32(cmd.ExecuteScalar());
            return id;
        }

        public void AddOrderItem(OrderItem item)
        {
            using var con = _factory.Create();
            con.Open();
            using var cmd = new MySqlCommand(@"INSERT INTO OrderItems(OrderId, MenuItemId, Quantity, UnitPrice) VALUES(@oid, @mid, @q, @p)", con);
            cmd.Parameters.AddWithValue("@oid", item.OrderId);
            cmd.Parameters.AddWithValue("@mid", item.MenuItemId);
            cmd.Parameters.AddWithValue("@q", item.Quantity);
            cmd.Parameters.AddWithValue("@p", item.UnitPrice);
            cmd.ExecuteNonQuery();
        }

        public Order? GetById(int id)
        {
            using var con = _factory.Create();
            con.Open();
            using var cmd = new MySqlCommand("SELECT Id, RestaurantId, Status, CreatedAt FROM Orders WHERE Id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            using var r = cmd.ExecuteReader();
            if (r.Read())
            {
                return new Order
                {
                    Id = r.GetInt32("Id"),
                    RestaurantId = r.GetInt32("RestaurantId"),
                    Status = r.GetString("Status"),
                    CreatedAt = r.GetDateTime("CreatedAt")
                };
            }
            return null;
        }
    }
}
