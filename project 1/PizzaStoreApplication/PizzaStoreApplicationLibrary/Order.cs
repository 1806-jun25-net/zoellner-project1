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

        public List<int> DesiredSizes { get; }

        public List<int> DesiredTypes { get; }

        public string location { get; set; }

        public string name;

        public string username;

        //constructors
        public Order()
        {
            
        }

        public Order (User CurrentUser, string ChosenLocation, int NumPizzas, List<int> Sizes, List<int> PizzaTypes)
        {
            NumberOfPizzas = NumPizzas;
            DesiredSizes = Sizes;
            DesiredTypes = PizzaTypes;
            location = ChosenLocation;
            name = CurrentUser.FirstName;
            username = CurrentUser.Username;
        }
    }
}
