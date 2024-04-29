using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderLibrary
{
    public class Dish: IComparable<Dish>
    {
        private int id;
        private string dishName;
        private bool available;
        private double price;
        private int restaurantId;

        public delegate void PriceDroppedHandler();
        public event PriceDroppedHandler PriceDrop;

        public void DisplayOffer()
        {
            PriceDrop();
        }
        public int Id { get => id; set => id = value; }
        public string DishName { get => dishName; set => dishName = value; }
        public bool Available { get => available; set => available = value; }
        public double Price { get => price; set { price = value; } } 
        public int RestaurantId { get => restaurantId; set => restaurantId = value; }

        public Dish() { }

        public Dish(int id, string dishName, bool available, double price, int restaurantId)
        {
            this.Id = id;
            this.DishName = dishName;
            this.Available = available;
            this.Price = price;
            this.RestaurantId=restaurantId;
        }

        public int CompareTo(Dish obj)
        {
            if (this.Price == obj.Price) { Console.WriteLine($"Dish {this.DishName}'s price  = Dish {this.DishName}'s price"); return 0; }
            else if (this.Price > obj.Price) { Console.WriteLine($"Dish {this.DishName}'s price  > Dish {this.DishName}'s price"); return 1; }
            else { Console.WriteLine($"Dish {this.DishName}'s price  < Dish {this.DishName}'s price"); return -1; };
        }
    }
}
