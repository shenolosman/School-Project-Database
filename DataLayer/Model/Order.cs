#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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