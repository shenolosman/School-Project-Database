using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Backend
{
    public class UserBackend
    {
        static FoodboxContext db = new FoodboxContext();
        /*
         * en metod för att få ut en lista på alla oköpta matlådor i alla restauranger, sorterade på pris lägst först. Parameter: typ av matlåda (kött/fisk/vego)
         * en metod för att köpa ett givet lunchlåde objekt.
         */
        public List<FoodBoxes> SortingNotSoldFoodboxes(string FoodType)
        {
            var q = db.FoodBoxes.Include(x => x.Orders).Include(x => x.Restaurant).Include(x => x.Category)
                .Where(x => x.Category.CategoryName == FoodType && x.Orders.Id == null).OrderBy(x => x.UnitPrice);
            return q.ToList();
        }
        public List<FoodBoxes> AllFoodBoxesList()
        {
            var q = db.FoodBoxes.Include(x => x.Orders).Include(x => x.Restaurant).Include(x => x.Category)
                .Where(x => x.Orders.Id == null);
            return q.ToList();
        }
        public void AttactCustomerToOneFoodbox(int foodid, int customerid)
        {
            var food = db.FoodBoxes.Find(foodid);
            var user = db.Customers.Find(customerid);
            db.Orders.Add(new Order()
            {
                Customer = user,
                FoodBoxes = new[] { food }
            });
            db.SaveChanges();
        }
    }
}