using System;
using System.Net.Mime;
using System.Threading;
using DataLayer.Backend;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AdminBackend admin = new AdminBackend();
            RestaurantBackend restaurant = new RestaurantBackend();
            UserBackend user = new UserBackend();
            while (true)
            {
                Console.WriteLine("Pick an option");
                Console.WriteLine("R : Reset database");
                Console.WriteLine("1 : Alla oköpta matlådor");
                Console.WriteLine("2 : Köpa ett lunchlåde");
                Console.WriteLine("3 : Se alla användare");
                Console.WriteLine("4 : Inaktivera en användare");
                Console.WriteLine("5 : Se alla restauranger");
                Console.WriteLine("6 : Lägga till restaurang");
                Console.WriteLine("7 : Sålda matlådor för ett restaurang");
                Console.WriteLine("8 : Lägga till ett nytt matlåde");
                Console.WriteLine("9 : Se alla categories");
                Console.WriteLine("\nFor exit please press \"ESC\" button\n");
                var keyinfo = Console.ReadKey();
                Console.Clear();
                if (keyinfo.Key == ConsoleKey.R)
                {
                    AdminBackend.PrepDatabase();
                    Console.WriteLine("Database initialized!");
                    ClearScreen();
                }
                if (keyinfo.Key == ConsoleKey.D1)
                {
                    var allcat = admin.AllCategories();
                    foreach (var item in allcat) Console.WriteLine($"Category id: {item.Id}, name: {item.CategoryName}");
                    Console.WriteLine("\nPlease write in to see which foodboxes not sold by type:");
                    var type = Console.ReadLine();
                    var notsold = user.SortingNotSoldFoodboxes(type);
                    if (notsold.Count > 0)
                    {
                        foreach (var item in notsold)
                        {
                            Console.WriteLine($"Food that not sold name is {item.FoodName}, from {item.Restaurant.RestaurantName} with {item.Category.CategoryName} name, price: {item.UnitPrice:C}, expired at {item.ExpireDate:d}");
                        }
                    }
                    else
                        Console.WriteLine("In that category all foodboxes are sold!");
                    ClearScreen();
                }
                if (keyinfo.Key == ConsoleKey.D2)
                {
                    var myorders = user.AllFoodBoxesList();
                    foreach (var item in myorders)
                    {
                        Console.WriteLine($"Order havent sell: id: {item.Id}, date: {item.FoodName}");
                    }
                    Console.WriteLine("\n");
                    var mycustomer = admin.AllCustomer();
                    foreach (var item in mycustomer)
                    {
                        Console.WriteLine($"id: {item.Id} Name: {item.FirstName} {item.LastName}");
                    }
                    Console.WriteLine("\nWanna Buy food? y/n !");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        Console.WriteLine("\n\n\ntype in which order do you want to buy;");
                        Console.Write("\norder id: ");
                        var order = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\ncustomer id: ");
                        var customer = Convert.ToInt32(Console.ReadLine());
                        user.AttactCustomerToOneFoodbox(order, customer);
                        Console.WriteLine("\nYou have created new attact customer: {0} to mat{1}", customer, order);
                    }
                    else
                        Console.WriteLine("Next time!");
                    ClearScreen();
                }
                if (keyinfo.Key == ConsoleKey.D3)
                {
                    var mycustomer = admin.AllCustomer();
                    foreach (var item in mycustomer)
                    {
                        Console.WriteLine($"Name: {item.FirstName} {item.LastName} and username: {item.UserName}\n");
                    }
                    ClearScreen();
                }
                if (keyinfo.Key == ConsoleKey.D4)
                {
                    var mycustomer = admin.AllCustomer();
                    foreach (var item in mycustomer)
                    {
                        Console.WriteLine($"Name: {item.FirstName} {item.LastName}, username: {item.UserName}");
                    }
                    Console.WriteLine("\nWrite username for delete user");
                    var delete = Console.ReadLine();
                    admin.DeleteCustomer(delete);
                    Console.WriteLine("{0} user deleted!", delete);
                    ClearScreen();
                }
                if (keyinfo.Key == ConsoleKey.D5)
                {
                    var myrestaurant = admin.AllRestaurants();
                    foreach (var item in myrestaurant)
                    {
                        Console.WriteLine($"\nRestauran name: {item.RestaurantName} and adress: {item.RestaurantAdress}");
                    }
                    ClearScreen();
                }
                if (keyinfo.Key == ConsoleKey.D6)
                {
                    Console.WriteLine("Plese enter information to create new restaurant:");
                    Console.Write("Restaurant name: ");
                    var name = Console.ReadLine();
                    Console.Write("Restaurant adress: ");
                    var adress = Console.ReadLine();
                    admin.AddRestaurants(name, adress);
                    Console.WriteLine("You have created new restaurant! Name is {0}", name);
                    ClearScreen();
                }
                if (keyinfo.Key == ConsoleKey.D7)
                {
                    foreach (var item in admin.AllRestaurants()) Console.WriteLine($"Restaurant id: {item.Id}, name: {item.RestaurantName}");
                    Console.WriteLine("\nWrite restaurant for to see sold foodboxes");
                    var myrestaurant = restaurant.SoldFoodboxesForOneRestaurant(Console.ReadLine());
                    foreach (var item in myrestaurant)
                    {
                        Console.WriteLine($"\nRestaurant name: {item.Restaurant.RestaurantName}, foodname: {item.FoodName}, {item.UnitPrice}");
                    }
                    ClearScreen();
                }
                if (keyinfo.Key == ConsoleKey.D8)
                {
                    foreach (var item in admin.AllRestaurants()) Console.WriteLine($"Restaurant id: {item.Id}, name: {item.RestaurantName}");
                    var allcat = admin.AllCategories();
                    Console.WriteLine("\n");
                    foreach (var item in allcat) Console.WriteLine($"Category id: {item.Id}, name: {item.CategoryName}");
                    Console.WriteLine("\nPlease enter information to create new foodbox:");
                    Console.Write("Food name: ");
                    var foodname = Console.ReadLine();
                    Console.Write("unit price: ");
                    var unitprice = Convert.ToDouble(Console.ReadLine());
                    Console.Write("restaurant id: ");
                    var restid = Convert.ToInt32(Console.ReadLine());
                    Console.Write("category id: ");
                    var catid = Convert.ToInt32(Console.ReadLine());
                    restaurant.AddNewFoodboxForOneRestaurant(restid, catid, foodname, unitprice);
                    ClearScreen();
                }
                if (keyinfo.Key == ConsoleKey.D9)
                {
                    foreach (var item in admin.AllCategories()) Console.WriteLine($"Category id: {item.Id}, name: {item.CategoryName}");
                    ClearScreen();
                }
                if (keyinfo.Key == ConsoleKey.Escape)
                {
                    break;
                }

                void ClearScreen()
                {
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
