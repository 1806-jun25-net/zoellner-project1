using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStoreWebApplication.Models
{
    public class User
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Favorite { get; set; }

        public string Address { get; set; }

        public int? CheeseOrdered { get; set; }

        public int? PepperoniOrdered { get; set; }

        public int? MeatOrdered { get; set; }

        public int? VeggieOrdered { get; set; }

        public string FavoritePizza { get; set; }
    }
}
