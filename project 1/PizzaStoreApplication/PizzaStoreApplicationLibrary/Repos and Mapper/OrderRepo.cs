using Microsoft.EntityFrameworkCore;
using PizzaStoreApplicationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaStoreApplicationLibrary.Repos_and_Mapper
{
    public class OrderRepo
    {
        private readonly Project1PizzaApplicationContext _db;

        public OrderRepo(Project1PizzaApplicationContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<Orders> GetOrders()
        {
            List<Orders> orders = _db.Orders.AsNoTracking().ToList();
            return orders;
        }

        public void AddOrder(Order NewOrder)
        {
            var dbOrder = Mapper.Map(NewOrder);
            _db.Add(dbOrder);
            _db.SaveChanges();
        }

        public void AddOrder(Orders NewOrder)
        {
            _db.Add(NewOrder);
            _db.SaveChanges();
        }

        public IEnumerable<Orders> GetOrdersByUser(string user)
        {
            List<Orders> Orders = _db.Orders.AsNoTracking().Where(o => o.Username == user).Select(o => o).ToList();
            return Orders;
        }

        public Orders GetSingleOrderById(int id)
        {
            Orders order = _db.Orders.AsNoTracking().First(o => o.OrderId == id);
            return order;
        }

        public int OrderRepoPizzaIDReturn(int size, int type)
        {
            int PizzaID = 1;
            switch (size)
            {
                case 1:
                    switch (type)
                    {
                        case 1:
                            PizzaID = 2;
                            break;
                        case 2:
                            PizzaID = 5;
                            break;
                        case 3:
                            PizzaID = 8;
                            break;
                        case 4:
                            PizzaID = 11;
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    switch (type)
                    {
                        case 1:
                            PizzaID = 3;
                            break;
                        case 2:
                            PizzaID = 6;
                            break;
                        case 3:
                            PizzaID = 9;
                            break;
                        case 4:
                            PizzaID = 12;
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    switch (type)
                    {
                        case 1:
                            PizzaID = 4;
                            break;
                        case 2:
                            PizzaID = 7;
                            break;
                        case 3:
                            PizzaID = 10;
                            break;
                        case 4:
                            PizzaID = 13;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            return PizzaID;
        }

        public string GetPizzaSizeAndTypeFromPizzaId(int? id)
        {
            string pizza = "";

            switch (id)
            {
                case 1:
                    pizza = "none";
                    break;
                case 2:
                    pizza = "Small Cheese - $8.00";
                    break;
                case 3:
                    pizza = "Medium Cheese - $11.00";
                    break;
                case 4:
                    pizza = "Large Cheese - $14.00";
                    break;
                case 5:
                    pizza = "Small Pepperoni - $9.00";
                    break;
                case 6:
                    pizza = "Medium Pepperoni - $12.00";
                    break;
                case 7:
                    pizza = "Large Pepperoni - $15.00";
                    break;
                case 8:
                    pizza = "Small Meat - $11.00";
                    break;
                case 9:
                    pizza = "Medium Meat - $14.00";
                    break;
                case 10:
                    pizza = "Large Meat - $17.00";
                    break;
                case 11:
                    pizza = "Small Veggie - $11.00";
                    break;
                case 12:
                    pizza = "Medium Veggie - $14.00";
                    break;
                case 13:
                    pizza = "Large Veggie - $17.00";
                    break;
                default:
                    break;
            }

            return pizza;
        }

        public decimal GetPriceOfPizzaFromId(int id)
        {
            int price = 0;

            switch (id)
            {
                case 1:
                    price = 0;
                    break;
                case 2:
                    price = 8;
                    break;
                case 3:
                    price = 11;
                    break;
                case 4:
                    price = 14;
                    break;
                case 5:
                    price = 9;
                    break;
                case 6:
                    price = 12;
                    break;
                case 7:
                    price = 15;
                    break;
                case 8:
                    price = 11;
                    break;
                case 9:
                    price = 14;
                    break;
                case 10:
                    price = 17;
                    break;
                case 11:
                    price = 11;
                    break;
                case 12:
                    price = 14;
                    break;
                case 13:
                    price = 17;
                    break;
                default:
                    break;
            }
            return price;
        }
    }
}
