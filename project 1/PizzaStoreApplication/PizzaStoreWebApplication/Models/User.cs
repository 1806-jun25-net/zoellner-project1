using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStoreWebApplication.Models
{
    public class User
    {
        public string Username { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string DefaultLocation { get; set; }
        public string PhysicalAddress { get; set; }
        public string RecommendedPizza { get; set; }
        public int? NumCheeseOrdered { get; set; }
        public int? NumPepperoniOrdered { get; set; }
        public int? NumMeatOrdered { get; set; }
        public int? NumVeggieOrdered { get; set; }
    }
}
