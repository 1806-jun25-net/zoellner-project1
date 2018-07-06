using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStoreApplicationLibrary
{
    public static class Mapper
    {
        public static Location Map(StoreLocation location)
        {
            return new Location
            {
                Name = location.CityName,
                Dough = location.DoughRemaining,
                Cheese = location.CheeseRemaining,
                Sauce = location.SauceRemaining,
                Pepperoni = location.PepperoniRemaining,
                PeppersAndOnions = location.VeggiesRemaining,
                HamAndMeatball = location.MeatRemaining
            };
        }

        public static StoreLocation Map(Location location)
        {
            return new StoreLocation
            {
                CityName = location.Name,
                DoughRemaining = location.Dough,
                CheeseRemaining = location.Cheese,
                SauceRemaining = location.Sauce,
                PepperoniRemaining = location.Pepperoni,
                MeatRemaining = location.HamAndMeatball,
                VeggiesRemaining = location.PeppersAndOnions
            };
        }

        public static User Map(Users user)
        {
            return new User
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.EmailAddress,
                Favorite = user.DefaultLocation,
                
            };
        }
    }
}
