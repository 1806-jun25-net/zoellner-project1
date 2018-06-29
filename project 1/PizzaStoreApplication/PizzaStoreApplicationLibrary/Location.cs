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
        public string Name { get; set; }

        public Dictionary<string, double> Inventory;
    }
}
