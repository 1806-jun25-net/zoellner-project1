using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStoreWebApplication.Models
{
    public class Location
    {
        public string Name { get; set; }
        public int DoughRemaining { get; set; }
        public int SauceRemaining { get; set; }
        public int CheeseRemaining { get; set; }
        public int PepperoniRemaining { get; set; }
        public int VeggiesRemaining { get; set; }
        public int MeatRemaining { get; set; }
    }
}
