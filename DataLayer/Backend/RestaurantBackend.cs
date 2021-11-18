using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Backend
{
    public class RestaurantBackend
    {
        /*
         *en metod för att få en lista över alla sålda matlådor för ett restaurang objekt
         * en metod för att lägga till ett nytt matlådeobjekt för en restaurang
         */
        static FoodboxContext db = new FoodboxContext();
        public List<FoodBoxes> SoldFoodboxesForOneRestaurant(string restaurantname)
        {
            var q = db.FoodBoxes.Include(x => x.Restaurant).Where(x => x.Restaurant.RestaurantName == restaurantname).OrderByDescending(x => x.UnitPrice);
            return q.ToList();
        }

        public void AddNewFoodboxForOneRestaurant(int restaurantid, int categoryid
            , string foodname, double unitprice)
        {
            var restid = db.Restaurants.Find(restaurantid);
            var catid = db.Categories.Find(categoryid);
            var foodbox = new FoodBoxes()
            {
                FoodName = foodname,
                UnitPrice = unitprice,
                ExpireDate = DateTime.Now.AddDays(5),
                Restaurant = restid,
                Category = catid,
                Orders = null
            };
            db.FoodBoxes.Add(foodbox);
            db.SaveChanges();
        }
    }
}