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
            bool ConfirmedOrder = false;
            while (!ConfirmedOrder)
            {
                for (int i = 0; i < NumPizzas; i++)
                {
                    bool Incomplete = true;
                    while (Incomplete)
                    {
                        int currentSize;
                        int currentType;
                        string size = "";
                        Console.WriteLine("What size will pizza" + (i + 1) + "be?");
                        bool ValidInput = false;
                        while (!ValidInput)
                        {
                            Console.WriteLine("Please input 1 for small, 2 for medium, and 3 for large.");
                            size = Console.ReadLine();
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
                        currentSize = int.Parse(size);

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
                        currentType = int.Parse(pizzaType);
                        bool Makeable = CanMakePizza(currentSize, currentType);
                        if (Makeable)
                        {
                            PizzaSizes.Add(currentSize);
                            PizzaType.Add(currentType);
                            Incomplete = false;
                        }
                        else
                        {
                            Console.WriteLine("We're sorry. We cannot currently make that pizza. Please recreate the current pizza.");
                        }
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("Does this look good to you?");
                Console.WriteLine("");

                CurrentOrder(PizzaSizes, PizzaType, NumPizzas);

                bool SubmitOrder = false;
                while (!SubmitOrder)
                {
                    Console.WriteLine("Shall we submit the order? Y/N");
                    string Input = Console.ReadLine().ToLower();

                    if (Input.Equals("y") && Input.Equals("n"))
                    {
                        Console.WriteLine("Please input either 'y' for yes or 'n' for no.");
                        continue;
                    }
                    else if (Input.Equals("n"))
                    {
                        Console.Clear();
                        Console.WriteLine("You have indicated that you were not satisfied with your order. We're sorry about that. Please resubmit your order from the beginning.");
                        SubmitOrder = true;
                    }
                    else if (Input.Equals("y"))
                    {
                        Console.WriteLine("Excellent! We shall submit your order for you!");
                        SubmitOrder = true;
                        ConfirmedOrder = true;
                    }
                }
            }
            Order NewOrder = new Order(CurrentUser, Name, NumPizzas, PizzaSizes, PizzaType);

        }

        public bool CanMakePizza(int size, int type)
        {
            bool Makeable = true;
            Pizza CurrentPizza = new Pizza(size, type);
            if(CurrentPizza.DoughUsage < Dough || CurrentPizza.SauceUsage < Sauce || CurrentPizza.CheeseUsage < Cheese || CurrentPizza.PepperoniUsage < Pepperoni ||
                CurrentPizza.HamAndMeatballUsage < HamAndMeatball || CurrentPizza.PepperAndOnionUsage < PeppersAndOnions)
            {
                Makeable = false;
            }
            return Makeable;
        }

        public void CurrentOrder(List<int> Sizes, List<int> Types, int NumPizzas)
        {
            for(int i = 0; i < NumPizzas; i++)
            {
                string currentPizza = "One ";
                switch (Sizes.IndexOf(i))
                {
                    case 1:
                        currentPizza = currentPizza + "small ";
                        break;
                    case 2:
                        currentPizza = currentPizza + "medium ";
                        break;
                    case 3:
                        currentPizza = currentPizza + "large ";
                        break;
                    default:
                        break;
                }

                switch (Types.IndexOf(i))
                {
                    case 1:
                        currentPizza = currentPizza + "cheese pizza.";
                        break;
                    case 2:
                        currentPizza = currentPizza + "pepperoni pizza.";
                        break;
                    case 3:
                        currentPizza = currentPizza + "meat pizza.";
                        break;
                    case 4:
                        currentPizza = currentPizza + "veggie pizza.";
                        break;
                    default:
                        break;
                }
                Console.WriteLine(currentPizza);
            }
        }
    }
}
