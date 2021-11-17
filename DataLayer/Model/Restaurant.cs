using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required] public string RestaurantName { get; set; }
        [Required] public string RestaurantAdress { get; set; }
        public virtual ICollection<FoodBoxes> FoodBoxes { get; set; }
    }
}