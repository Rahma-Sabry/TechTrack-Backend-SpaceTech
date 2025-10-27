using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechPathNavigator.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required, MaxLength(200)]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        // Navigation
        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
