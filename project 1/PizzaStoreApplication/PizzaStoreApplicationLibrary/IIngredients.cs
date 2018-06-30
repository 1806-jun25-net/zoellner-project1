using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStoreApplicationLibrary
{
    public interface IIngredients
    {
        double Dough { get; set; }

        double Cheese { get; set; }

        double Sauce { get; set; }

        double Pepperoni { get; set; }

        double PeppersAndOnions { get; set; }

        double HamAndMeatball { get; set; }
    }
}
