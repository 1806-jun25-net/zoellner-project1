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
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Favorite Location")]
        public string Favorite { get; set; }

        [Required]
        [Display(Name = "Full Address")]
        public string Address { get; set; }

        public int? CheeseOrdered { get; set; }

        public int? PepperoniOrdered { get; set; }

        public int? MeatOrdered { get; set; }

        public int? VeggieOrdered { get; set; }

        public string FavoritePizza { get; set; }
    }
}
