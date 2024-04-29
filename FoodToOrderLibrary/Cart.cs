using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderLibrary { 
    public class Cart
    {
        private int id;
        private double amount;
        private int userId;
        private List<CartDetail> cartDetails = new List<CartDetail>();

        public int Id { get => id; set => id = value; }
        public double Amount { get => amount; set => amount = value; }
        public int UserId { get => userId; set => userId = value; }
        public List<CartDetail> CartDetails { get => cartDetails; set => cartDetails = value; }

        public Cart()
            {

            }

        public Cart(int id, double amount, int userId)
        {
            this.Id = id;
            this.Amount = amount;
            this.UserId = userId;
        }
    }
}
