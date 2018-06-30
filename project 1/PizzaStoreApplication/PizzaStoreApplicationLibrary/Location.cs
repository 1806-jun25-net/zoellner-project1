//Anthony Zoellner
//Project 1

using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStoreApplicationLibrary
{
    public class Location : IIngredients
    {
        //fields
        public string Name { get; }

        public double Dough { get; set; } = 1000;
        public double Cheese { get; set; } = 1000;
        public double Sauce { get; set; } = 1000;
        public double Pepperoni { get; set; } = 1000;
        public double PeppersAndOnions { get; set; } = 1000;
        public double HamAndMeatball { get; set; } = 1000;

        public Location()
        {
            Name = "Close Store";
        }

        public Location(string name)
        {
            Name = name;
        }
    }
}
