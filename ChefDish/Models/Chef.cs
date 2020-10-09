using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefDish.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name="Birthday: ")]
        [DateValidator]
        public int Birthday { get; set; }
        
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<Dish> Dishes {get; set; }
    }

    public class DateValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if((DateTime)value< DateTime.Now)
            {
                return new ValidationResult("Posted time must be a previous time.");
            }
            return ValidationResult.Success;
        }
    }
}