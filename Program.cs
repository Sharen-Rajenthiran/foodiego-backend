
using FoodieGo.API.Data;
using FoodieGo.API.SQL;
using FoodieGo.Application.Interfaces;
using FoodieGo.Application.Services;
using FoodieGo.Infrastructure.Database;
using FoodieGo.Infrastructure.Interfaces;
using FoodieGo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodieGo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            
            builder.Services.AddSingleton(new SqlConnectionFactory(connectionString));
            builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddScoped<IRestaurantService, RestaurantService>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            var app = builder.Build();


            //var sqlHandler = new SqlHandler();
            //sqlHandler.DbStartup();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
