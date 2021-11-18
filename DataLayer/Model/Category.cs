using System;
using System.Collections.Generic;

namespace DataLayer.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<FoodBoxes> FoodBoxes { get; set; }
    }
}