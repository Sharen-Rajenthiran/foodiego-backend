using System.ComponentModel.DataAnnotations;

namespace FoodieGo.API.Models
{
    public class User
    {
        [Key]
        public string? Id { get; set; }
        public string Password { get; set; } = string.Empty;

    }
}
