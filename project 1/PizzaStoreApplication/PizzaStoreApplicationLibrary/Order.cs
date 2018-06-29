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

        public string[,] PizzaOrder;

        //constructors
        public Order()
        {
            PizzaOrder = new string[1, 4] { { "medium", "pepperoni", "green pepper", "onion" } };
        }

        //nested 'for' loops included for user input
        public Order (int NumPizzas)
        {
            PizzaOrder = new string[NumPizzas, 4];

            for(int i = 0; i < NumPizzas; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if(j == 0)
                    {
                        Console.WriteLine("Type in a pizza size: small, medium, large");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Type in a desired topping");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
