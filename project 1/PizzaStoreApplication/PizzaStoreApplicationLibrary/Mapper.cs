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

            }
        }
    }
}
