using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AnimalManager.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Origin { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<AnimalFood> AnimalFood { get; set; }

    }
    public  class AnimalContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<AnimalFood> AnimalFoods { get; set; }

        public System.Data.Entity.DbSet<AnimalManager.Models.FoodTotal> FoodTotals { get; set; }
    }
}