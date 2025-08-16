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
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly SqlConnectionFactory _factory;
        public MenuItemRepository(SqlConnectionFactory factory) => _factory = factory;

        public IEnumerable<MenuItem> GetAll()
        {
            var list = new List<MenuItem>();
            using var con = _factory.Create();
            con.Open();
            using var cmd = new MySqlCommand("SELECT Id, RestaurantId, Name, Price FROM MenuItems", con);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(ReadMenuItem(r));
            }
            return list;
        }

        public IEnumerable<MenuItem> GetByRestaurant(int restaurantId)
        {
            var list = new List<MenuItem>();
            using var con = _factory.Create();
            con.Open();
            using var cmd = new MySqlCommand("SELECT Id, RestaurantId, Name, Price FROM MenuItems WHERE RestaurantId=@rid", con);
            cmd.Parameters.AddWithValue("@rid", restaurantId);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(ReadMenuItem(r));
            }
            return list;
        }

        public MenuItem? GetById(int id)
        {
            using var con = _factory.Create();
            con.Open();
            using var cmd = new MySqlCommand("SELECT Id, RestaurantId, Name, Price FROM MenuItems WHERE Id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            using var r = cmd.ExecuteReader();
            if (r.Read()) return ReadMenuItem(r);
            return null;
        }

        private static MenuItem ReadMenuItem(MySqlDataReader r) => new MenuItem
        {
            Id = r.GetInt32("Id"),
            RestaurantId = r.GetInt32("RestaurantId"),
            Name = r.GetString("Name"),
            Price = r.GetDecimal("Price")
        };
    }
}
