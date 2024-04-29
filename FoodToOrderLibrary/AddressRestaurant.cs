using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderLibrary
{
    public class AddressRestaurant
    {
        private int addressId;
        private int restaurantId;

        public int AddressId { get => addressId; set => addressId = value; }
        public int RestaurantId { get => restaurantId; set => restaurantId = value; }

        public AddressRestaurant()
        {

        }

        public AddressRestaurant(int addressId, int restaurantId)
        {
            this.AddressId = addressId;
            this.RestaurantId= restaurantId;
        }
    }
}
