//Anthony Zoellner
//Project 1

using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStoreApplicationLibrary
{
    public class Order : IIngredients
    {
        //fields
        public DateTime OrderPlaced => DateTime.Now;

        public int NumberOfPizzas;

        public IEnumerable<string[]> OrderedPizzas;

        //constructors
        public Order()
        {
            
        }

        //Ultimately, the pizzas will have up to 3 toppings. Thus, for testing, the chosen topping will
        //iterate 3 times per pizza
        public Order (int NumPizzas)
        {
            
        }
    }
}
