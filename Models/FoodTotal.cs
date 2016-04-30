using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalManager.Models
{
    public class FoodTotal
    {
   
        public FoodTotal (AnimalFood animalFood)
        {
            Foodname = animalFood.Food.Name;
            Foodprice = animalFood.Food.Price;
            Foodquantity = animalFood.Animal.Quantity * animalFood.Quantity;
            Totalprice = Foodquantity * Foodprice;
         
        }

        public FoodTotal()
        {
            // TODO: Complete member initialization
        }
        public int Id { get; set; }

        public string Foodname { get; set; }

        public double Foodprice { get; set; }

        public double Foodquantity { get; set; }

        public double Totalprice { get; set; }

    }
}