using FoodToOrderLibrary;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Transactions;

int adminId = 5;

// TODO - implement generic class here.
void generateMenuCardForCustomers(Restaurant r)
{
    Console.WriteLine(format: "\nGenerating the Menu Card for Restaurant - {0}...", arg0: r.RName);
    int flag = 0;
    foreach (Dish d in r.Dishes)
    {
        if (d.Available)
        {
            flag = 1;
            Console.WriteLine($"ID:{d.Id}. {d.DishName} - Rs.{d.Price}");
        }
    }
    if (flag == 0) Console.WriteLine("No dish available currently!");
}

void generateMenuCardForAdmin(Restaurant r)
{
    if (r.Dishes.Count == 0 ) { Console.WriteLine("No dish available currently!"); return; }
    foreach (Dish d in r.Dishes)
    {
        Console.WriteLine($"ID:{d.Id}. {d.DishName} - Rs.{d.Price}");
    }
}

void Compare(List<Restaurant> r)
{
    if (r.Count > 0)
    {
        List<Dish> dishes = r[0].Dishes;
        if (dishes.Count > 0 && dishes.Count > 0)
        {
            dishes[0].Price.CompareTo(dishes[1].Price);
        } 
    }
}

void displayRestaurantsIfOpen(List<Restaurant> restaurantsList)
{
    Console.WriteLine("\nDisplaying the nearby Restaurants...\n");

    foreach (Restaurant r in restaurantsList)
    {
        if (r.Open)
        {
            Console.WriteLine($"ID:{r.Id}. {r.RName}");
        }
    }
}

void displayAllRestaurants(List<Restaurant> restaurantsList)
{
    Console.WriteLine("\nDisplaying all the Restaurants...\n");

    foreach (Restaurant r in restaurantsList)
    {
        Console.WriteLine($"ID:{r.Id}. {r.RName}");
    }
}

void displayWelcomeMessage()
{
    Console.WriteLine("\t\t\t\t\t---------------");
    Console.WriteLine("\t\t\t\t\tFOODTOORDER APP");
    Console.WriteLine("\t\t\t\t\t---------------");
    Console.WriteLine("\nWelcome to the  FoodToOrder App! Please Sign in to order your food...\n");
}

void displayLoginMessage()
{
    Console.WriteLine("SIGN IN");
    Console.WriteLine("-------");
}

// TO-DO : implement try-catch : bool, null check
(string, string) getUserCredentials() {
    string email;
    string password;

    Console.Write("Email: ");
    email = Console.ReadLine();

    Console.Write("Password: ");
    password = Console.ReadLine();

    return (email, password);
}

// user login
User getVerifiedUser(string email, string password, List<User> users) {
    foreach (User user in users)
    {
        if (user.Email == email && user.Password == password)
        {
            Console.WriteLine("\nUser Verified!\n");
            return user;
        }
    }
    Console.WriteLine("\nInvalid user! Exiting...\n");
    Environment.Exit(0);
    return null;
}

Restaurant ChooseRestaurantCustomer(List<Restaurant> restaurantsList)
{
    int rChoice;
    Restaurant currentRestaurant = null;
    string rName, proceed = "y";

    while (proceed == "y")
    {
        displayRestaurantsIfOpen(restaurantsList); 

        Console.WriteLine("\nEnter the Restaurant ID. to view the menu: ");

        rChoice = Int32.Parse(Console.ReadLine());
        currentRestaurant = restaurantsList.Where(r => r.Id == rChoice).ToList()[0];
        rName = currentRestaurant.RName;

        generateMenuCardForCustomers(currentRestaurant);

        Console.WriteLine("\nDo you want to browse other restaurants? Enter y for Yes and n for No:");
        proceed = Console.ReadLine();
    }
    return currentRestaurant;
}

Dish getDish(List<Dish> dishList, int id)
{
    foreach (Dish dish in dishList)
    {
        if (dish.Id == id) return dish;
    }
    return null;
}

Cart ChooseDishesAndAddToCart(Restaurant currentRestaurant)
{
    int itemNo, quantity, cartDetailId = 1;
    CartDetail cartDetail;
    List<Dish> dishList;
    Cart cart = new(); ;
    string proceed = "y";
    Console.WriteLine($"\nRestaurant - {currentRestaurant.RName}");

    while (proceed == "y")
    {
        Console.WriteLine("Enter the item no. to place order: ");
        itemNo = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Enter the quantity: ");
        quantity = Int32.Parse(Console.ReadLine());

        dishList = currentRestaurant.Dishes;
        cartDetail = new();
        cartDetail.CartDetailId = cartDetailId;
        cartDetail.DishId = dishList.Where(d => d.Id == itemNo).ToList()[0].Id;
        cartDetail.Quantity =  quantity;
        cartDetailId++;

        cart.CartDetails.Add(cartDetail);

        Console.WriteLine("Do you wish to order anything else? Enter y for Yes and n for No:");
        proceed = Console.ReadLine();
    }

    return cart;
}

double calculateTotalBill(List<Dish> dishList, Cart cart)
{
    double total = 0;
    int quantity;
    Dish dish;

    Console.WriteLine("\nDisplaying bill...");
    Console.WriteLine("BILL");
    Console.WriteLine("----");

    foreach (CartDetail item in cart.CartDetails)
    { 
        quantity = item.Quantity;
        dish = getDish(dishList, item.DishId);
        total += quantity * dish.Price;

        Console.WriteLine($"DISH NAME:{dish.DishName}\tQUANTITY:{quantity}\tPRICE:{dish.Price}");
    }
    return total;
}

void placeOrder(List<Dish> dishList, Cart cart)
{
    double total;
    Console.WriteLine("\nPlacing order...");

    // Lambda expression to print total
    var printTotal = (double x) => Console.WriteLine($"TOTAL: RS:{x}");

    cart.Amount = calculateTotalBill(dishList, cart);
    printTotal(cart.Amount);
}

void performCustomerActions()
{

}

List<Restaurant> getRestaurants()
{
    using(StreamReader sw = new StreamReader("restaurants.json"))
    {
        string data = sw.ReadToEnd();
        List<Restaurant> restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(data);
        return restaurants;
    }
}

void populateDish(Dish d, int rId)
{
    double oldPrice = 0.0;
    
    Console.WriteLine("Enter the dish Id:");
    d.Id = Int32.Parse(Console.ReadLine());
    Console.WriteLine("Enter the dish name:");
    d.DishName = Console.ReadLine();
    Console.WriteLine("Is this dish currently available? Enter true or false:");
    d.Available = bool.Parse(Console.ReadLine());
    Console.WriteLine("Enter the price of the dish:");
    if (d.Price != 0.0) oldPrice = d.Price;
    d.Price = Convert.ToDouble(Console.ReadLine());
    if (d.Price < oldPrice)
    {
        d.PriceDrop += Display;
        d.DisplayOffer();
    }

    d.RestaurantId = rId;
    
}

void deleteDish(List<Dish> dishes, Dish d)
{
    try
    {
        dishes.Remove(d);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Unable to find dish: ", ex.Message);
    }
}
void deleteDishes(Restaurant r)
{
    string proceed = "y", dName;
    int id;
    Dish currentDish;

    while (proceed == "y")
    {
        Console.WriteLine("Enter the current dish Id:");
        id = Int32.Parse(Console.ReadLine());
        // LINQ to get the current dish
        currentDish = r.Dishes.Where(d => d.Id == id).ToArray()[0];
        dName = currentDish.DishName;
        deleteDish(r.Dishes, currentDish);
        Console.WriteLine("Deleted dish: " + dName);

        Console.WriteLine("Do you wish to delete more dishes? Enter y for Yes and n for No:");
        proceed = Console.ReadLine();
    }
}

void editDishes(Restaurant r)
{
    string proceed = "y";
    int id;
    Dish currentDish;

    while (proceed == "y")
    {
        Console.WriteLine("Enter the current dish Id:");
        id = Int32.Parse(Console.ReadLine());
        currentDish = r.Dishes.Where(d => d.Id == id).ToArray()[0];
        populateDish(currentDish, r.Id);

        Console.WriteLine("Do you wish to edit more dishes? Enter y for Yes and n for No:");
        proceed = Console.ReadLine();
    }
}

void addDishes(Restaurant r)
{
    string proceed = "y";
    Console.WriteLine("Add the dishes:");
    while (proceed == "y")
    {
        Dish d = new();
        populateDish(d, r.Id);
        r.Dishes.Add(d);
        Console.WriteLine("Added dish: " + d.DishName);

        Console.WriteLine("Do you wish to add more dishes? Enter y for Yes and n for No:");
        proceed = Console.ReadLine();
    }
}

void actionDishes(Restaurant r)
{
    int dChoice;
    string proceed = "y";

    while (proceed == "y")
    {
        Console.WriteLine("\nChoose the dish edit action:\n1.Add Dish\n2.Edit Dish\n3.Delete Dish\n4.Display Dishes");
        dChoice = Int32.Parse(Console.ReadLine());
        switch (dChoice)
        {
            case 1:
                addDishes(r);
                break;
            case 2:
                editDishes(r);
                break;
            case 3:
                deleteDishes(r);
                break;
            case 4:
                generateMenuCardForAdmin(r);
                break;
            default:
                Console.WriteLine("Invalid choice! Exiting...");
                break;
        }
        Console.WriteLine("Do you wish to continue adding/deleting/editing dishes? Enter y for yes and n for No: ");
        proceed = Console.ReadLine();
    }
}

void populateRestaurant(Restaurant r)
{
    Console.WriteLine("Enter the restaurant Id:");
    r.Id = Int32.Parse(Console.ReadLine());
    Console.WriteLine("Enter the restaurant name:");
    r.RName = Console.ReadLine();
    r.UserId = adminId;
    Console.WriteLine("Is the restaurant open? Enter true or false:");
    r.Open = bool.Parse(Console.ReadLine());
    if (r.Dishes is null || r.Dishes.Count == 0)
    {
        Console.WriteLine($"Restaurant {r.RName} has no dish currently.");
        r.Dishes = new List<Dish>();
        addDishes(r);
    }
    else
    {
        Console.WriteLine($"Restaurant {r.RName} has {r.Dishes.Count} dishes currently.");
        actionDishes(r);
    }
}

void addRestaurants(List<Restaurant> restaurants)
{
    string proceed = "y";

    while (proceed == "y")
    {
        Restaurant r = new();
        populateRestaurant(r);
        Console.WriteLine("Added new restaurant: " + r.RName);
        restaurants.Add(r);        

        Console.WriteLine("Do you wish to add more restaurants? Enter y for Yes and n for No:");
        proceed = Console.ReadLine();
    }

    //TODO - Add to json-append

    //appendDataToFile(@"C:\\Users\\Maria Viji George\\source\\repos\\FoodToOrder\\FoodToOrder\\restaurants.json", restaurant);

}

void editRestaurants(List<Restaurant> restaurants)
{
    string proceed = "y";
    int id;
    Restaurant currentRestaurant;

    while (proceed == "y")
    {
        Console.WriteLine("Enter the current restaurant Id:");
        id = Int32.Parse(Console.ReadLine());
        currentRestaurant = restaurants.Where(r => r.Id == id).ToArray()[0];
        populateRestaurant(currentRestaurant);
        Console.WriteLine($"Edited restaurant: {currentRestaurant.RName}");

        Console.WriteLine("\nDo you wish to edit more restaurants? Enter y for Yes and n for No:");
        proceed = Console.ReadLine();
    }
}
//TO-DO abs filepath

void deleteRestaurant(List<Restaurant> restaurants, Restaurant restaurant)
{
    try
    {
        restaurants.Remove(restaurant);
    }
    catch (Exception ex) { Console.WriteLine("Restaurant not found:" + ex.Message); }
}
void deleteRestaurants(List<Restaurant> restaurants)
{
    string proceed = "y";
    int id;
    Restaurant currentRestaurant;

    while (proceed == "y")
    {
        string rName;
        Console.WriteLine("Enter the current restaurant Id:");
        id = Int32.Parse(Console.ReadLine());
        currentRestaurant = restaurants.Where(r => r.Id == id).ToArray()[0];
        rName = currentRestaurant.RName;
        deleteRestaurant(restaurants, currentRestaurant);
        Console.WriteLine($"Deleted restaurant: {rName}");

        Console.WriteLine("\nDo you wish to delete more restaurants? Enter y for Yes and n for No:");
        proceed = Console.ReadLine();
    }
}

void performAdminAction(List<Restaurant> restaurants)
{
    int aChoice;
    string proceed = "y";
    displayAllRestaurants(restaurants);

    while (proceed == "y")
    {
        Console.WriteLine("\nChoose the action you need to perform:\n1.Add Restaurant\n2.Edit Restaurant\n3.Delete Restaurant\n4.Display Restaurants");
        aChoice = Int32.Parse(Console.ReadLine());
        switch (aChoice)
        {
            case 1:
                addRestaurants(restaurants);
                break;
            case 2:
                editRestaurants(restaurants); 
                break;
            case 3:
                deleteRestaurants(restaurants);
                break;
            case 4:
                displayAllRestaurants(restaurants);
                break;
            default:
                Console.WriteLine("Invalid choice! Exiting...");
                break;
        }
        Console.WriteLine("\nDo you wish to continue adding/deleting/editing restaurants? Enter y for yes and n for No: ");
        proceed = Console.ReadLine();
    }
    string json = JsonConvert.SerializeObject(restaurants, Formatting.Indented);
    File.WriteAllText(@"C:\\Users\\Maria Viji George\\source\\repos\\FoodToOrder\\FoodToOrder\\restaurants.json", json);

}

void Display()
{
    Console.WriteLine($"Offer!! Price dropped!");
}

// main 
Data data = new Data();
User currentUser;
Cart cart;
Dish d = new Dish();
bool isValidUser;
string email, password;
string currentUserRole;
Restaurant currentRestaurant;
List<Restaurant> restaurantsList;

displayWelcomeMessage();
displayLoginMessage();

// Login User
(email, password)  = getUserCredentials();
currentUser = getVerifiedUser(email, password, Data.Users);

// Checking if user is a customer
currentUserRole = currentUser.Role;
restaurantsList = getRestaurants();

if (currentUserRole == "Customer")
{
    // performCustomerActions();
    // TODO - null check
    // TODO - ORder table
    currentRestaurant = ChooseRestaurantCustomer(restaurantsList);
    // TODO - remove from cart 
    cart = ChooseDishesAndAddToCart(currentRestaurant);
    placeOrder(currentRestaurant.Dishes, cart);
}

// Checking if user is an admin
else if (currentUserRole == "Admin")
{
    performAdminAction(restaurantsList);
}