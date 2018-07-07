using System;
using System.Collections.Generic;

namespace PizzaStoreApplication
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public DateTime? OrderTime { get; set; }
        public string Username { get; set; }
        public int NumPizzas { get; set; }
        public string StoreLocation { get; set; }
        public int PizzaNum1 { get; set; }
        public int? PizzaNum2 { get; set; }
        public int? PizzaNum3 { get; set; }
        public int? PizzaNum4 { get; set; }
        public int? PizzaNum5 { get; set; }
        public int? PizzaNum6 { get; set; }
        public int? PizzaNum7 { get; set; }
        public int? PizzaNum8 { get; set; }
        public int? PizzaNum9 { get; set; }
        public int? PizzaNum10 { get; set; }
        public int? PizzaNum11 { get; set; }
        public int? PizzaNum12 { get; set; }
        public decimal? TotalCost { get; set; }
        public string FirstName { get; set; }

        public PizzaVariation PizzaNum10Navigation { get; set; }
        public PizzaVariation PizzaNum11Navigation { get; set; }
        public PizzaVariation PizzaNum12Navigation { get; set; }
        public PizzaVariation PizzaNum1Navigation { get; set; }
        public PizzaVariation PizzaNum2Navigation { get; set; }
        public PizzaVariation PizzaNum3Navigation { get; set; }
        public PizzaVariation PizzaNum4Navigation { get; set; }
        public PizzaVariation PizzaNum5Navigation { get; set; }
        public PizzaVariation PizzaNum6Navigation { get; set; }
        public PizzaVariation PizzaNum7Navigation { get; set; }
        public PizzaVariation PizzaNum8Navigation { get; set; }
        public PizzaVariation PizzaNum9Navigation { get; set; }
        public StoreLocation StoreLocationNavigation { get; set; }
    }
}
