using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderLibrary
{
    public class Order
    {
        private int id;
        private int userId;
        private string orderDate;
        private double orderAmount;

        public int Id { get => id; set => id = value; }
        public int UserId { get => userId; set => userId = value; }
        public string OrderDate { get => orderDate; set => orderDate = value; }
        public double OrderAmount { get => orderAmount; set => orderAmount = value; }

        public Order() { }

        public Order(int id, int userId, string orderDate, double orderAmount)
        {
            this.Id = id;
            this.UserId = userId;
            this.OrderDate = orderDate;
            this.OrderAmount = orderAmount;
        }
    }
}
