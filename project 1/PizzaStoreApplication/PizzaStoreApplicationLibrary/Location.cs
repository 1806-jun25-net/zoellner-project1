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

        public List<Order> OrderHistory;

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
            double TotalCost = 0;
            List<int> PizzaSizes = new List<int>(NumPizzas);
            List<int> PizzaType = new List<int>(NumPizzas);
            bool ConfirmedOrder = false;
            bool ContinueOrder = true;
            bool OrderSubmitted = false;
            bool DidNotFinishOrder = false;
            while (!ConfirmedOrder)
            {
                for (int i = 0; i < NumPizzas; i++)
                {
                    if (!ContinueOrder)
                    {
                        continue;
                    }

                    bool Incomplete = true;
                    while (Incomplete)
                    {
                        int currentSize;
                        int currentType;
                        string size = "";
                        Console.WriteLine("What size will pizza " + (i + 1) + " be?");
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
                        Console.WriteLine("We recommend " + CurrentUser.FavoritePizza);
                        
                        string pizzaType = "1";
                        ValidInput = false;
                        while (!ValidInput)
                        {
                            if (currentSize == 1)
                            {
                                Console.WriteLine("Please select 1 for Cheese($8.00), 2 for Pepperoni($9.00), 3 for Meat($11.00), or 4 for Veggie($11.00)");
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
                            if (currentSize == 2)
                            {
                                Console.WriteLine("Please select 1 for Cheese($11.00), 2 for Pepperoni($12.00), 3 for Meat($14.00), or 4 for Veggie($14.00)");
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
                            if (currentSize == 3)
                            {
                                Console.WriteLine("Please select 1 for Cheese($14.00), 2 for Pepperoni($15.00), 3 for Meat($17.00), or 4 for Veggie($17.00)");
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
                        currentType = int.Parse(pizzaType);
                        bool OverLimit = CostCalculator(currentSize, currentType, TotalCost);
                        if (OverLimit)
                        {
                            Console.WriteLine("We're sorry. We have a $500.00 cost limit. Your current total price is $" + TotalCost);
                            Console.WriteLine("Would you like to keep ordering? Y/N");
                            string RepeatPizza = Console.ReadLine().ToLower();
                            if (RepeatPizza.Equals("y"))
                            {
                                Console.Clear();
                                Console.WriteLine("Restarting current pizza");
                                continue;
                            }
                            if(!RepeatPizza.Equals("y") && !RepeatPizza.Equals("n"))
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Restarting current pizza");
                                continue;
                            }
                            if (RepeatPizza.Equals("n"))
                            {
                                Console.WriteLine("We understand. Finishing order.");
                                ContinueOrder = false;
                            }

                        }

                        bool Makeable = CanMakePizza(currentSize, currentType);
                        if (Makeable)
                        {
                            PizzaSizes.Add(currentSize);
                            PizzaType.Add(currentType);
                            Incomplete = false;
                        }
                        else
                        {
                            Console.WriteLine("We're sorry. We cannot currently make that pizza. We're running low on ingredients.");
                            Console.WriteLine("Would you like to keep ordering? Y/N");
                            string RepeatPizza = Console.ReadLine().ToLower();
                            if (RepeatPizza.Equals("y"))
                            {
                                Console.Clear();
                                Console.WriteLine("Restarting current pizza");
                                continue;
                            }
                            if (!RepeatPizza.Equals("y") && !RepeatPizza.Equals("n"))
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Restarting current pizza");
                                continue;
                            }
                            if (RepeatPizza.Equals("n"))
                            {
                                Console.WriteLine("We understand. Finishing order.");
                                ContinueOrder = false;
                                DidNotFinishOrder = true;
                            }
                        }
                        if (!ContinueOrder)
                        {
                            Incomplete = false;
                        }
                    }
                }
                if (!DidNotFinishOrder)
                {
                    Console.Clear();
                    Console.WriteLine("Does this look good to you?");
                    Console.WriteLine("");
                }

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
                        PizzaSizes.Clear();
                        PizzaType.Clear();
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
            DecreaseInventory(NewOrder);
            OrderHistory.Add(NewOrder);

            return NewOrder;
        }

        public bool CanMakePizza(int size, int type)
        {
            bool Makeable = true;
            Pizza CurrentPizza = new Pizza(size, type);
            if(CurrentPizza.DoughUsage > Dough || CurrentPizza.SauceUsage > Sauce || CurrentPizza.CheeseUsage > Cheese || CurrentPizza.PepperoniUsage > Pepperoni ||
                CurrentPizza.HamAndMeatballUsage > HamAndMeatball || CurrentPizza.PepperAndOnionUsage > PeppersAndOnions)
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
                switch (Sizes[i])
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

                switch (Types[i])
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

        public void ViewOrderHistory()
        {
            Console.Clear();
            Console.WriteLine("Order history for " + Name + " location:");
            foreach (var item in OrderHistory)
            {
                Console.WriteLine("     " + item.OrderPlaced + " " + item.name + " ordered the following:");
                CurrentOrder(item.DesiredSizes, item.DesiredTypes, item.NumberOfPizzas);
                Console.WriteLine("");
            }
        }

        public void DecreaseInventory(Order CurrentOrder)
        {
            for(int i = 0; i < CurrentOrder.DesiredSizes.Capacity; i++)
            {
                Pizza CurrentPizza = new Pizza(CurrentOrder.DesiredSizes[i], CurrentOrder.DesiredTypes[i]);
                Dough = Dough - CurrentPizza.DoughUsage;
                Sauce = Sauce - CurrentPizza.SauceUsage;
                Cheese = Cheese - CurrentPizza.CheeseUsage;
                Pepperoni = Pepperoni - CurrentPizza.PepperoniUsage;
                HamAndMeatball = HamAndMeatball - CurrentPizza.HamAndMeatballUsage;
                PeppersAndOnions = PeppersAndOnions - CurrentPizza.PepperAndOnionUsage;
            }
        }

        public bool CostCalculator(int size, int type, double totalCost)
        {
            bool OverLimit = false;
            if(size == 1 && type == 1)
            {
                double pizzaCost = 8.00;
                if((totalCost + pizzaCost) > 500)
                {
                    OverLimit = true;
                }
            }
            if (size == 2 && type == 1)
            {
                double pizzaCost = 11.00;
                if ((totalCost + pizzaCost) > 500)
                {
                    OverLimit = true;
                }
            }
            if (size == 3 && type == 1)
            {
                double pizzaCost = 14.00;
                if ((totalCost + pizzaCost) > 500)
                {
                    OverLimit = true;
                }
            }

            if (size == 1 && type == 2)
            {
                double pizzaCost = 9.00;
                if ((totalCost + pizzaCost) > 500)
                {
                    OverLimit = true;
                }
            }
            if (size == 2 && type == 2)
            {
                double pizzaCost = 12.00;
                if ((totalCost + pizzaCost) > 500)
                {
                    OverLimit = true;
                }
            }
            if (size == 3 && type == 2)
            {
                double pizzaCost = 15.00;
                if ((totalCost + pizzaCost) > 500)
                {
                    OverLimit = true;
                }
            }

            if (size == 1 && type == 3)
            {
                double pizzaCost = 11.00;
                if ((totalCost + pizzaCost) > 500)
                {
                    OverLimit = true;
                }
            }
            if (size == 2 && type == 3)
            {
                double pizzaCost = 14.00;
                if ((totalCost + pizzaCost) > 500)
                {
                    OverLimit = true;
                }
            }
            if (size == 3 && type == 3)
            {
                double pizzaCost = 17.00;
                if ((totalCost + pizzaCost) > 500)
                {
                    OverLimit = true;
                }
            }

            if (size == 1 && type == 4)
            {
                double pizzaCost = 11.00;
                if ((totalCost + pizzaCost) > 500)
                {
                    OverLimit = true;
                }
            }
            if (size == 2 && type == 4)
            {
                double pizzaCost = 14.00;
                if ((totalCost + pizzaCost) > 500)
                {
                    OverLimit = true;
                }
            }
            if (size == 3 && type == 4)
            {
                double pizzaCost = 17.00;
                if ((totalCost + pizzaCost) > 500)
                {
                    OverLimit = true;
                }
            }
            return OverLimit;
        }

        public bool LastOrderOverTwoHoursAgo(User user)
        {
            bool CanOrderAgain = true;

            string UserName = user.Username;

            if (OrderHistory.Exists(x => x.username == UserName))
            {
                Order LastOrder = OrderHistory.FindLast(x => x.username == UserName);
                DateTime TimeToCheck = LastOrder.OrderPlaced;

                if ((DateTime.Now - TimeToCheck) < TimeSpan.FromHours(2))
                {
                    CanOrderAgain = false;
                }
            }

            return CanOrderAgain;
        }
    }
}
