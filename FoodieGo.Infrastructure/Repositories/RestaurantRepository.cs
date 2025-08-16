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
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly SqlConnectionFactory _factory;
        public RestaurantRepository(SqlConnectionFactory factory) => _factory = factory;

        public IEnumerable<Restaurant> GetAll()
        {
            var list = new List<Restaurant>();
            using var con = _factory.Create();
            con.Open();
            using var cmd = new MySqlCommand("SELECT Id, Name, Location FROM Restaurants ORDER BY Name", con);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new Restaurant
                {
                    Id = r.GetInt32("Id"),
                    Name = r.GetString("Name"),
                    Location = r.IsDBNull(r.GetOrdinal("Location")) ? null : r.GetString("Location")
                });
            }
            return list;
        }

        public Restaurant? GetById(int id)
        {
            using var con = _factory.Create();
            con.Open();
            using var cmd = new MySqlCommand("SELECT Id, Name, Location FROM Restaurants WHERE Id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            using var r = cmd.ExecuteReader();
            if (r.Read())
            {
                return new Restaurant
                {
                    Id = r.GetInt32("Id"),
                    Name = r.GetString("Name"),
                    Location = r.IsDBNull(r.GetOrdinal("Location")) ? null : r.GetString("Location")
                };
            }
            return null;
        }
    }
}
