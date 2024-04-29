using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderLibrary
{
    public class Restaurant
    {
        private int id;
        private string rName;
        private int userId;
        private bool open;
        private List<Dish> dishes;

        public int Id { get => id; set => id = value; }
        public string RName { get => rName; set => rName = value; }
        public int UserId { get => userId; set => userId = value; }
        public bool Open { get => open; set => open = value; }
        public List<Dish> Dishes { get => dishes; set => dishes = value; }

        public Restaurant() { }

        public Restaurant(int id, string rName, int userId, bool open, List<Dish> dishes)
        {
            this.Id = id;
            this.RName = rName;
            this.UserId = userId;
            this.Open = open;
            this.Dishes = dishes;
        }

      
    }
}
