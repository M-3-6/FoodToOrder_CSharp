namespace FoodToOrderLibrary
{
    public class Data
    {
        public static List<User> Users = new List<User>();
        //public static List<Dish> DishesKFC = new List<Dish>();
        //public static List<Dish> DishesDominos = new List<Dish>();
        //public static List<Dish> DishesTruffles = new List<Dish>();
        //public static List<Dish> DishesNagarjuna = new List<Dish>();

        public Data() {
            // users
            Users.Add(new User(1, "Maria", "Viji", "Customer", "maria@tismo.com", "maria345"));
            Users.Add(new User(2, "Prajith", "Shetty", "Customer", "", "prajith345"));
            Users.Add(new User(3, "Adithyan", "S", "Customer", "adithyan@tismo.com", "adithyan345"));
            Users.Add(new User(4, "Praveen", "K", "Customer", "praveen@tismo.com", "praveen345"));
            Users.Add(new User(5, "John", "Doe", "Admin", "john@tismo.com", "john345"));
        }


    }
}
