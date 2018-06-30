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

        Address deliveryAddress;

        public bool OrderedRecently = false;

        //constructors
        public User()
        {
            FirstName = "Anthony";
            LastName = "Zoellner";
            PhoneNumber = "802-782-7550";
            Email = "ajzoellner@gmail.com";
            deliveryAddress = new Address();
        }

        public User(string first, string second, string phone, string email, string address, string city, string state, string zip)
        {
            FirstName = first;
            LastName = second;
            PhoneNumber = phone;
            Email = email;
            deliveryAddress = new Address(address, city, state, zip);
        }

        //methods

        public Order CreateOrder(string ChosenLocation, int NumPizzas, int[] Sizes, int[] Types)
        {
            Order NewOrder = new Order(ChosenLocation, NumPizzas, Sizes, Types);

            return NewOrder;   
        }
    }
}
