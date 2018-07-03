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
        public DateTime OrderPlaced = new DateTime();

        public int NumberOfPizzas;

        public List<int> DesiredSizes { get; set; }

        public List<int> DesiredTypes { get; set; }

        public string location { get; set; }

        public string name;

        public string username;

        public double cost;

        //constructors
        public Order()
        {
            
        }

        public Order (User CurrentUser, string ChosenLocation, int NumPizzas, List<int> Sizes, List<int> PizzaTypes, double Cost)
        {
            NumberOfPizzas = NumPizzas;
            DesiredSizes = Sizes;
            DesiredTypes = PizzaTypes;
            location = ChosenLocation;
            name = CurrentUser.FirstName;
            username = CurrentUser.Username;
            cost = Cost;
            OrderPlaced = DateTime.Now;
        }

        public string PrintPizza(int size, int type)
        {
            string WhatToPrint = "";
            switch (size)
            {
                case 1:
                    switch (type)
                    {
                        case 1:
                            WhatToPrint = "Small Cheese Pizza $8.00";
                            break;
                        case 2:
                            WhatToPrint = "Small Pepperoni Pizza $9.00";
                            break;
                        case 3:
                            WhatToPrint = "Small Meat Pizza $11.00";
                            break;
                        case 4:
                            WhatToPrint = "Small Veggie Pizza $11.00";
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    switch (type)
                    {
                        case 1:
                            WhatToPrint = "Medium Cheese Pizza $11.00";
                            break;
                        case 2:
                            WhatToPrint = "Medium Pepperoni Pizza $12.00";
                            break;
                        case 3:
                            WhatToPrint = "Medium Meat Pizza $14.00";
                            break;
                        case 4:
                            WhatToPrint = "Medium Veggie Pizza $14.00";
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    switch (type)
                    {
                        case 1:
                            WhatToPrint = "Large Cheese Pizza $14.00";
                            break;
                        case 2:
                            WhatToPrint = "Large Pepperoni Pizza $15.00";
                            break;
                        case 3:
                            WhatToPrint = "Large Meat Pizza $17.00";
                            break;
                        case 4:
                            WhatToPrint = "Large Veggie Pizza $17.00";
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            return WhatToPrint;
        }
    }
}
