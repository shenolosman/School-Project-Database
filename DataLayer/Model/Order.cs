#nullable enable
using System;
using System.Collections.Generic;

namespace DataLayer.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<FoodBoxes> FoodBoxes { get; set; }
        public Customer? Customer { get; set; }
    }
}