using Microsoft.EntityFrameworkCore;
using FoodieGo.API.Models;

namespace FoodieGo.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<User> Users { get; set; }


    }
}
