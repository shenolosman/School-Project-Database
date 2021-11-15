using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    internal class Order 
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        // public FoodBoxes FoodBoxes { get; set; }
        [ForeignKey("Id")]
        public Customer? Customer { get; set; }
    }
}
