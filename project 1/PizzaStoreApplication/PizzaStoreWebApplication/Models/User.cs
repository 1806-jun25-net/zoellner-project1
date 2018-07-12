using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStoreWebApplication.Models
{
    public class User
    {
        [Required]
        [Key]
        public string Username { get; set; }

        [Required]

        public string FirstName { get; set; }

        [Required]

        public string LastName { get; set; }

        [Required]

        public string PhoneNumber { get; set; }

        [Required]

        public string Email { get; set; }

        [Required]

        public string Favorite { get; set; }

        [Required]

        public string Address { get; set; }

        public int? CheeseOrdered { get; set; }

        public int? PepperoniOrdered { get; set; }

        public int? MeatOrdered { get; set; }

        public int? VeggieOrdered { get; set; }

        public string FavoritePizza { get; set; }
    }
}
