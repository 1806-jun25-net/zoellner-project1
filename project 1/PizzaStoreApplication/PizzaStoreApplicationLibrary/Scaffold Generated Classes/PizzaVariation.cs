using System;
using System.Collections.Generic;

namespace PizzaStoreApplicationLibrary
{
    public partial class PizzaVariation
    {
        public PizzaVariation()
        {
            OrdersPizzaNum10Navigation = new HashSet<Orders>();
            OrdersPizzaNum11Navigation = new HashSet<Orders>();
            OrdersPizzaNum12Navigation = new HashSet<Orders>();
            OrdersPizzaNum1Navigation = new HashSet<Orders>();
            OrdersPizzaNum2Navigation = new HashSet<Orders>();
            OrdersPizzaNum3Navigation = new HashSet<Orders>();
            OrdersPizzaNum4Navigation = new HashSet<Orders>();
            OrdersPizzaNum5Navigation = new HashSet<Orders>();
            OrdersPizzaNum6Navigation = new HashSet<Orders>();
            OrdersPizzaNum7Navigation = new HashSet<Orders>();
            OrdersPizzaNum8Navigation = new HashSet<Orders>();
            OrdersPizzaNum9Navigation = new HashSet<Orders>();
        }

        public int PizzaId { get; set; }
        public string PizzaSize { get; set; }
        public string PizzaType { get; set; }

        public ICollection<Orders> OrdersPizzaNum10Navigation { get; set; }
        public ICollection<Orders> OrdersPizzaNum11Navigation { get; set; }
        public ICollection<Orders> OrdersPizzaNum12Navigation { get; set; }
        public ICollection<Orders> OrdersPizzaNum1Navigation { get; set; }
        public ICollection<Orders> OrdersPizzaNum2Navigation { get; set; }
        public ICollection<Orders> OrdersPizzaNum3Navigation { get; set; }
        public ICollection<Orders> OrdersPizzaNum4Navigation { get; set; }
        public ICollection<Orders> OrdersPizzaNum5Navigation { get; set; }
        public ICollection<Orders> OrdersPizzaNum6Navigation { get; set; }
        public ICollection<Orders> OrdersPizzaNum7Navigation { get; set; }
        public ICollection<Orders> OrdersPizzaNum8Navigation { get; set; }
        public ICollection<Orders> OrdersPizzaNum9Navigation { get; set; }
    }
}
