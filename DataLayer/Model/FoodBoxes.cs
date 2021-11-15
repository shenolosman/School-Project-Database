#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    internal class FoodBoxes
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public DateTime ExpireName { get; set; }
        public double UnitPrice { get; set; }
        [ForeignKey("Id")]
        public virtual Category Category { get; set; }
        [ForeignKey("Id")]
        public virtual Restaurant Restaurant { get; set; }
        [ForeignKey("Id")]
        public virtual Order Orders { get; set; }
    }
}
