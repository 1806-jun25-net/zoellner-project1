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

        public IEnumerable<Orders> GetOrdersByUser(string user)
        {
            List<Orders> Orders = _db.Orders.AsNoTracking().Where(o => o.Username == user).Select(o => o).ToList();
            return Orders;
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
    }
}
