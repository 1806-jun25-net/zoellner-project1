//Anthony Zoellner
//Project 1

using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStoreApplicationLibrary
{
    public class Order
    {
        //fields
        public DateTime OrderPlaced => DateTime.Now;

        public int NumberOfPizzas;

        public int[] DesiredSizes { get; }

        public int[] DesiredTypes { get; }

        //constructors
        public Order()
        {
            
        }

        public Order (string ChosenLocation, int NumPizzas, int[] Sizes, int[] PizzaTypes)
        {
            NumberOfPizzas = NumPizzas;
            DesiredSizes = Sizes;
            DesiredTypes = PizzaTypes;
        }
    }
}
