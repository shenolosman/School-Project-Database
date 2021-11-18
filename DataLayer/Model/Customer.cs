using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Model
{
    public class Customer
    {
        public int Id { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string UserName { get; set; }
        [Required] public string Adress { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime? BannedDate { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}