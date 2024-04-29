using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderLibrary
{
    public class CartDetail
    {
        private int cartDetailId;
        private int dishId;
        private int quantity;

        public int CartDetailId { get => cartDetailId; set => cartDetailId = value; }
        public int DishId { get => dishId; set => dishId = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public CartDetail()
        {

        }

        public CartDetail(int cartDetailId, int dishId, int quantity)
        {
            this.CartDetailId = cartDetailId;
            this.DishId = dishId;
            this.Quantity = quantity;
        }
    }
}
