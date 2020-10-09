using System;
using System.ComponentModel.DataAnnotations;
namespace ChefDish.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        public string Name { get; set; }
        public string ChefId { get; set; }
        public int Tastiness { get; set; }
        [Display(Name="Calories: ", Prompt="Fill in the Calories")]
        [Required(ErrorMessage="It is required.")]
        [Range(1, Int32.MaxValue)]
        public int Calories { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Chef Chefs {get; set; }
    }
}