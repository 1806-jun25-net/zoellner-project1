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

        //methods
        public Order CreateOrder(User CurrentUser, int NumPizzas)
        {
            List<int> PizzaSizes = new List<int>();
            List<int> PizzaType = new List<int>();
            for (int i = 0; i < NumPizzas; i++)
            {
                Console.WriteLine("What size will pizza" + (i + 1) + "be?");
                bool ValidInput = false;
                while (!ValidInput)
                {
                    Console.WriteLine("Please input 1 for small, 2 for medium, and 3 for large.");
                    string size = Console.ReadLine();
                    if (!size.Equals("1") && !size.Equals("2") && !size.Equals("3"))
                    {
                        Console.WriteLine("Invalid input. Try again.");
                            continue;
                    }
                    else
                    {
                        ValidInput = true;
                    }
                }

                Console.WriteLine("And what type of pizza would you like?");
                Console.WriteLine("The options are: Cheese, Pepperoni, Meat (Pepperoni, Ham, and Meatball), or Veggie (Pepperoni, Green Peppers, and Onions)");

                string pizzaType = "1";
                ValidInput = false;
                while (!ValidInput)
                {
                    Console.WriteLine("Please select 1 for Cheese, 2 for Pepperoni, 3 for Meat, or 4 for Veggie");
                    pizzaType = Console.ReadLine();
                    if (!pizzaType.Equals("1") && !pizzaType.Equals("2") && !pizzaType.Equals("3") && !pizzaType.Equals("4"))
                    {
                        Console.WriteLine("Invalid input. Try again.");
                        continue;
                    }
                    else
                    {
                        ValidInput = true;
                    }
                }

            }
        }

        public bool CanMakePizza(int size, int type)
        {
            bool Makeable = true;
            Pizza(size, type);
            return Makeable;
        }
    }
}
