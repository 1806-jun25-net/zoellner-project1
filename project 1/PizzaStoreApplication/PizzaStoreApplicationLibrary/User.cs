//Anthony Zoellner
//Project 1

using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStoreApplicationLibrary
{
    public class User : Address
    {
        //fields
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public Location DefaultLocation = new Location();

        //methods
    }
}
