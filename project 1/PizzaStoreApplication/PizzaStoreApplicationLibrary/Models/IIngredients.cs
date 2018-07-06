using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStoreApplicationLibrary
{
    public interface IIngredients
    {
        int Dough { get; set; }

        int Cheese { get; set; }

        int Sauce { get; set; }

        int Pepperoni { get; set; }

        int PeppersAndOnions { get; set; }

        int HamAndMeatball { get; set; }
    }
}
