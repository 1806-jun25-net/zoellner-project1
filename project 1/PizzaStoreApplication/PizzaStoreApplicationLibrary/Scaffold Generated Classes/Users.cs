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

        public StoreLocation DefaultLocationNavigation { get; set; }
        public Orders Orders { get; set; }
    }
}
