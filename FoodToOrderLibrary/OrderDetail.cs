using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderLibrary
{
    public class OrderDetail
    {
        private int id;
        private int dishId;
        private int orderId;
        private int quantity;

        public int Id { get => id; set => id = value; }
        public int DishId { get => dishId; set => dishId = value; }
        public int OrderId { get => orderId; set => orderId = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public OrderDetail() { }

        public OrderDetail(int id, int dishId, int orderId, int quantity)
        {
            this.Id = id;
            this.DishId = dishId;
            this.OrderId = orderId;
            this.Quantity = quantity;
        }
    }
}
