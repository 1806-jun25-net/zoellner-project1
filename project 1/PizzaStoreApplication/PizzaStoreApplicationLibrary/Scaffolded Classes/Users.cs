using System;
using System.Collections.Generic;

namespace PizzaStoreApplicationLibrary
{
    public partial class Users
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string DefaultLocation { get; set; }
        public string PhysicalAddress { get; set; }
        public string RecommendedPizza { get; set; }
        public int? NumCheeseOrdered { get; set; }
        public int? NumPepperoniOrdered { get; set; }
        public int? NumMeatOrdered { get; set; }
        public int? NumVeggieOrdered { get; set; }

        public StoreLocation DefaultLocationNavigation { get; set; }
    }
}
