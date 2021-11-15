using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    internal class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        //public virtual ICollection<FoodBoxes> FoodBoxes { get; set; }
    }
}
