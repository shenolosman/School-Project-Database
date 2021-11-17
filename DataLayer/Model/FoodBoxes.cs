#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class FoodBoxes
    {
        public int Id { get; set; }
        [Required] public string FoodName { get; set; }
        public DateTime ExpireDate { get; set; }
        public double UnitPrice { get; set; }
        [Required] public virtual Category Category { get; set; }
        [Required] public virtual Restaurant Restaurant { get; set; }
        public virtual Order? Orders { get; set; }
    }
}