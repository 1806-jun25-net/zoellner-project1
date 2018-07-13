using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStoreWebApplication.Models
{
    public class Order
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

        public string Pizza1 { get; set; }
        public string Pizza2 { get; set; }
        public string Pizza3 { get; set; }
        public string Pizza4 { get; set; }
        public string Pizza5 { get; set; }
        public string Pizza6 { get; set; }
        public string Pizza7 { get; set; }
        public string Pizza8 { get; set; }
        public string Pizza9 { get; set; }
        public string Pizza10 { get; set; }
        public string Pizza11 { get; set; }
        public string Pizza12 { get; set; }
    }
}
