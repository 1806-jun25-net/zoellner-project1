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

        public string State { get; set; }

        public string ZipCode { get; set; }

        //constructors
        public Address()
        {
            AddressLine = "123 Pickastreet Lane";

            City = "Anytown";

            State = "VT";

            ZipCode = "12345";
        }

        public Address(string address, string city, string state, string zip)
        {
            AddressLine = address;

            City = city;

            State = state;

            ZipCode = zip;
        }
        
    }
}
