using System;
using System.Collections.Generic;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Data
{
    internal class FoodboxContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FoodBoxes> FoodBoxes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FoodBoxModelFirstDB");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasIndex(u => new
                {
                    u.Email,
                    u.Adress,
                    u.UserName
                }).IsUnique();
            modelBuilder.Entity<Category>()
                .HasIndex(u => new
                {
                    u.CategoryName
                }).IsUnique();
            modelBuilder.Entity<Restaurant>()
                .HasIndex(u => new
                {
                    u.RestaurantAdress
                }).IsUnique();
        }

        public void Seed()
        {
            var categories = new Category[]
            {
                new () { CategoryName = "vegan"}, //category[0]
                new () { CategoryName ="meat"},//category[1]
                new () { CategoryName ="fish"},//category[2]
                new(){CategoryName = "bakery"}//category[3]
            };
            AddRange(categories);
            var restaurans = new Restaurant[]
            {
                new () { RestaurantName = "Vegan Chark",RestaurantAdress = "Stockholm Street"}, //restauran[0]
                new () { RestaurantName = "Meat Industri",RestaurantAdress = "Malmö Highway"},//restauran[1]
                new () { RestaurantName = "Turkish Table",RestaurantAdress = "Markaryd Squat"},//restauran[2]
                new () { RestaurantName = "Fish & Fish",RestaurantAdress = "Halmstad Center"},//restauran[3]
                new () { RestaurantName = "Vegetable Vegie",RestaurantAdress = "Helsingborg E6"},//restauran[4]
                new () { RestaurantName = "Fresh Baking",RestaurantAdress = "Goteborg West"}//restauran[5]
            };
            AddRange(restaurans);

            var customers = new List<Customer>
            {
                new (){FirstName = "Shenol",LastName = "Osman",Adress = "Markaryd",Email = "shenol@mail.com",IsActive = true,BannedDate = null,Password = "123",UserName = "sosman"},//user[0]
                new (){FirstName = "Andreas",LastName = "Larsson",Adress = "Helsingborg",Email = "andreas@mail.com",IsActive = true,BannedDate = null,Password = "1234",UserName = "andreas"},//user[1]
                new (){FirstName = "Dennis",LastName = "Lif",Adress = "Stockholm",Email = "dennis@mail.com",IsActive = true,BannedDate = null,Password = "12345",UserName = "denlif"},//user[2]
                new (){FirstName = "Emmanuel",LastName = "Hjalmarsson",Adress = "Umeå",Email = "emmanuel@mail.com",IsActive = true,BannedDate = null,Password = "123456",UserName = "emm"},//user[3]
                new (){FirstName = "Anna",LastName = "Zhutava",Adress = "Halmstad",Email = "anna@mail.com",IsActive = true,BannedDate = null,Password = "1231",UserName = "annaz"},//user[4]
                new (){FirstName = "Samir",LastName = "Pakar",Adress = "Halmstad West",Email = "samir@mail.com",IsActive = true,BannedDate = null,Password = "1232",UserName = "pakar"},//user[5]
                new (){FirstName = "Björn",LastName = "S",Adress = "Sverige",Email = "bjorn@mail.com",IsActive = true,BannedDate = null,Password = "123123",UserName = "bjorn"}//user[6]
            };
            AddRange(customers);
            var orders = new Order[]
            {
                new(){OrderDate = DateTime.Now,Customer =  customers[0]}, //order[0]
                new(){OrderDate = DateTime.Now.AddDays(-11),Customer = customers[1]}, //order[1]
                new(){OrderDate = DateTime.Now.AddDays(-12),Customer = customers[2]}, //order[2]
                new(){OrderDate = DateTime.Now.AddDays(-13),Customer = customers[3]}, //order[3]
                new(){OrderDate = DateTime.Now.AddDays(-14),Customer = customers[4]}, //order[4]
                new(){OrderDate = DateTime.Now,Customer = customers[5]}, //order[5]
                new(){OrderDate = DateTime.Now,Customer = customers[4]}, //order[6]
                new(){OrderDate = DateTime.Now.AddDays(-1),Customer = customers[5]}, //order[7]
                new(){OrderDate = DateTime.Now.AddDays(-2),Customer = customers[2]}, //order[8]
                new(){OrderDate = DateTime.Now.AddDays(-3),Customer = customers[1]}, //order[9]
                new(){OrderDate = DateTime.Now.AddDays(-4),Customer = customers[0]}, //order[10]
                new(){OrderDate = DateTime.Now,Customer =  customers[3]}, //order[11]
            };
            AddRange(orders);

            var foodboxes = new FoodBoxes[]
            {
                new() {FoodName = "Vegan Spiecy", UnitPrice = 79.88, ExpireDate = DateTime.Now.AddDays(4), Restaurant = restaurans[0], Category = categories[0], Orders = orders[0]},
                new() {FoodName = "Vegan Rulle", UnitPrice = 89.88, ExpireDate = DateTime.Now.AddDays(5), Restaurant = restaurans[0], Category = categories[0], Orders = orders[1]},
                new() {FoodName = "Kött bullar", UnitPrice = 99.88, ExpireDate = DateTime.Now.AddDays(3), Restaurant = restaurans[1], Category = categories[1], Orders = orders[2]},
                new() {FoodName = "Fishchips", UnitPrice = 79.88, ExpireDate = DateTime.Now.AddDays(4), Restaurant = restaurans[3], Category = categories[2], Orders = orders[3]},
                new() {FoodName = "Dolma", UnitPrice = 69.98, ExpireDate = DateTime.Now.AddDays(10), Restaurant = restaurans[2], Category = categories[0], Orders = orders[4]},
                new() {FoodName = "Rotten Fish", UnitPrice = 29.88, ExpireDate = DateTime.Now.AddDays(99), Restaurant = restaurans[5], Category = categories[2], Orders = orders[5]},
                new() {FoodName = "Fralle", UnitPrice = 39.88, ExpireDate = DateTime.Now.AddDays(4), Restaurant = restaurans[4], Category = categories[3], Orders = orders[5]},
                new() {FoodName = "Cheese Sandwich", UnitPrice = 49.88, ExpireDate = DateTime.Now.AddDays(-14), Restaurant = restaurans[3], Category = categories[3], Orders = null},
                new() {FoodName = "Vegan Spiecy", UnitPrice = 79.88, ExpireDate = DateTime.Now.AddDays(4), Restaurant = restaurans[0], Category = categories[0], Orders = orders[0]},
                new() {FoodName = "Vegan Rulle", UnitPrice = 99.98, ExpireDate = DateTime.Now.AddDays(4), Restaurant = restaurans[0], Category = categories[0], Orders = orders[1]},
                new() {FoodName = "Kött bullar", UnitPrice = 119.88, ExpireDate = DateTime.Now.AddDays(4), Restaurant = restaurans[1], Category = categories[1], Orders = orders[2]},
                new() {FoodName = "Fish chips", UnitPrice = 79.88, ExpireDate = DateTime.Now.AddDays(5), Restaurant = restaurans[3], Category = categories[2], Orders = orders[3]},
                new() {FoodName = "Dolma", UnitPrice = 69.88, ExpireDate = DateTime.Now.AddDays(5), Restaurant = restaurans[2], Category = categories[1], Orders = orders[4]},
                new() {FoodName = "Rotten Fish", UnitPrice = 39.88, ExpireDate = DateTime.Now.AddDays(-22), Restaurant = restaurans[3], Category = categories[2], Orders = null},
                new() {FoodName = "Fralle", UnitPrice = 49.88, ExpireDate = DateTime.Now.AddDays(-15), Restaurant = restaurans[2], Category = categories[3], Orders = null},
                new() {FoodName = "Cheese Sandwich", UnitPrice = 59.88, ExpireDate = DateTime.Now.AddDays(-14), Restaurant = restaurans[0], Category = categories[3],Orders = null},

            };
            /*  vegan  /category[0] 0
                meat   /category[1] 0
                fish   /category[2] 1
                bakery /category[3] 3           */
            AddRange(foodboxes);
            SaveChanges();

        }

    }
}
