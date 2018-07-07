using System;
using System.Collections.Generic;

namespace PizzaStoreApplication
{
    public partial class StoreLocation
    {
        public StoreLocation()
        {
            Orders = new HashSet<Orders>();
            Users = new HashSet<Users>();
        }

        public string CityName { get; set; }
        public int DoughRemaining { get; set; }
        public int SauceRemaining { get; set; }
        public int CheeseRemaining { get; set; }
        public int PepperoniRemaining { get; set; }
        public int VeggiesRemaining { get; set; }
        public int MeatRemaining { get; set; }

        public ICollection<Orders> Orders { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
