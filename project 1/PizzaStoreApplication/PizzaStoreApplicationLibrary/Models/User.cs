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
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Favorite { get; set; }

        public Location DefaultLocation = new Location();

        Address deliveryAddress;

        public int CheeseOrdered { get; set; } = 0;

        public int PepperoniOrdered { get; set; } = 0;

        public int MeatOrdered { get; set; } = 0;

        public int VeggieOrdered { get; set; } = 0;

        public string FavoritePizza { get; set; } = "Pepperoni Pizza";

        public bool OrderedRecently = false;

        //constructors
        public User()
        {
            FirstName = "Anthony";
            LastName = "Zoellner";
            PhoneNumber = "802-782-7550";
            Email = "ajzoellner@gmail.com";
            deliveryAddress = new Address();
            Favorite = "Herndon";
        }

        public User(string username, string first, string second, string phone, string email, string address, string city, string favorite)
        {
            Username = username;
            FirstName = first;
            LastName = second;
            PhoneNumber = phone;
            Email = email;
            deliveryAddress = new Address(address, city);
            Favorite = favorite;
        }

        //methods

        public void UserFavoritePizza(Order order)
        {
            List<int> PizzasOrdered = order.DesiredTypes;
            foreach (var item in PizzasOrdered)
            {
                switch (item)
                {
                    case 1:
                        CheeseOrdered++;
                        break;
                    case 2:
                        PepperoniOrdered++;
                        break;
                    case 3:
                        MeatOrdered++;
                        break;
                    case 4:
                        VeggieOrdered++;
                        break;
                    default:
                        break;
                }
            }

            if(CheeseOrdered > PepperoniOrdered && CheeseOrdered > MeatOrdered
                && CheeseOrdered > VeggieOrdered)
            {
                FavoritePizza = "Cheese Pizza";
            }

            else if (PepperoniOrdered > CheeseOrdered && PepperoniOrdered > MeatOrdered
                && PepperoniOrdered > VeggieOrdered)
            {
                FavoritePizza = "Pepperoni Pizza";
            }

            else if (MeatOrdered > CheeseOrdered && MeatOrdered > PepperoniOrdered
                && MeatOrdered > VeggieOrdered)
            {
                FavoritePizza = "Meat Pizza";
            }

            else if (VeggieOrdered > CheeseOrdered && VeggieOrdered > MeatOrdered
                && VeggieOrdered > PepperoniOrdered)
            {
                FavoritePizza = "Veggie Pizza";
            }
        }
    }
}
