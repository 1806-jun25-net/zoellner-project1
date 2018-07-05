//Anthony Zoellner
//Project 1

using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStoreApplicationLibrary
{
    public class Address
    {
        //fields
        public string AddressLine { get; set; }

        public string City { get; set; }

        //constructors
        public Address()
        {
            AddressLine = "123 Pickastreet Lane";

            City = "Anytown";
        }

        public Address(string address, string city)
        {
            AddressLine = address;

            City = city;
        }
        
    }
}
