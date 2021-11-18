using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Data;
using DataLayer.Model;

namespace DataLayer.Backend
{
    public class AdminBackend
    {/*
         *en metod för att skapa om och seeda databasen med testdata
         * en metod för att se alla användare
         * en metod för att kunna ta bort/inaktivera en användare utifrån användarnamn
         * en metod för att se alla restauranger
         * en metod för att kunna lägga till ett nytt restaurang objekt
         */
        static FoodboxContext db = new FoodboxContext();
        public static void PrepDatabase()
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            db.Seed();
        }
        public List<Customer> AllCustomer()
        {
            var q = db.Customers.Where(x => x.IsActive).Select(x => x);
            return q.ToList();
        }
        public void DeleteCustomer(string username)
        {
            var getuser = db.Customers.Where(x => x.UserName == username);
            if (getuser != null)
            {
                foreach (var item in getuser)
                {
                    item.IsActive = false;
                    item.BannedDate = DateTime.Now;
                }
            }
            db.SaveChanges();
        }
        public List<Restaurant> AllRestaurants()
        {
            var q = db.Restaurants.Select(x => x);
            return q.ToList();
        }
        public List<Category> AllCategories()
        {
            var q = db.Categories.Select(x => x);
            return q.ToList();
        }
        public void AddRestaurants(string name, string adress)
        {
            db.Restaurants.Add(new Restaurant() { RestaurantName = name, RestaurantAdress = adress });
            db.SaveChanges();
        }
    }

}
