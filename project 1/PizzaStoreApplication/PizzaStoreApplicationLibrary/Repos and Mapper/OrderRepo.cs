using Microsoft.EntityFrameworkCore;
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
            NewOrder.DesiredSizes.TrimExcess();
            NewOrder.DesiredTypes.TrimExcess();
            int id1 = 1;
            int id2 = 1;
            int id3 = 1;
            int id4 = 1;
            int id5 = 1;
            int id6 = 1;
            int id7 = 1;
            int id8 = 1;
            int id9 = 1;
            int id10 = 1;
            int id11 = 1;
            int id12 = 1;
            id1 = OrderRepoPizzaIDReturn(NewOrder.DesiredSizes[0], NewOrder.DesiredTypes[0]);
            if (NewOrder.DesiredSizes.Capacity > 1)
            {
                id2 = OrderRepoPizzaIDReturn(NewOrder.DesiredSizes[1], NewOrder.DesiredTypes[1]);

                if (NewOrder.DesiredSizes.Capacity > 2)
                {
                    id3 = OrderRepoPizzaIDReturn(NewOrder.DesiredSizes[2], NewOrder.DesiredTypes[2]);

                    if (NewOrder.DesiredSizes.Capacity > 3)
                    {
                        id4 = OrderRepoPizzaIDReturn(NewOrder.DesiredSizes[3], NewOrder.DesiredTypes[3]);

                        if (NewOrder.DesiredSizes.Capacity > 4)
                        {
                            id5 = OrderRepoPizzaIDReturn(NewOrder.DesiredSizes[4], NewOrder.DesiredTypes[4]);

                            if (NewOrder.DesiredSizes.Capacity > 5)
                            {
                                id6 = OrderRepoPizzaIDReturn(NewOrder.DesiredSizes[5], NewOrder.DesiredTypes[5]);

                                if (NewOrder.DesiredSizes.Capacity > 6)
                                {
                                    id7 = OrderRepoPizzaIDReturn(NewOrder.DesiredSizes[6], NewOrder.DesiredTypes[6]);

                                    if (NewOrder.DesiredSizes.Capacity > 7)
                                    {
                                        id8 = OrderRepoPizzaIDReturn(NewOrder.DesiredSizes[7], NewOrder.DesiredTypes[7]);

                                        if (NewOrder.DesiredSizes.Capacity > 8)
                                        {
                                            id9 = OrderRepoPizzaIDReturn(NewOrder.DesiredSizes[8], NewOrder.DesiredTypes[8]);

                                            if (NewOrder.DesiredSizes.Capacity > 9)
                                            {
                                                id10 = OrderRepoPizzaIDReturn(NewOrder.DesiredSizes[9], NewOrder.DesiredTypes[9]);

                                                if (NewOrder.DesiredSizes.Capacity > 10)
                                                {
                                                    id11 = OrderRepoPizzaIDReturn(NewOrder.DesiredSizes[10], NewOrder.DesiredTypes[10]);

                                                    if (NewOrder.DesiredSizes.Capacity > 11)
                                                    {
                                                        id12 = OrderRepoPizzaIDReturn(NewOrder.DesiredSizes[11], NewOrder.DesiredTypes[11]);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            var dbOrder = new Orders
            {
                Username = NewOrder.username,
                FirstName = NewOrder.name,
                OrderTime = NewOrder.OrderPlaced,
                NumPizzas = NewOrder.NumberOfPizzas,
                PizzaNum1 = id1,
                PizzaNum2 = id2,
                PizzaNum3 = id3,
                PizzaNum4 = id4,
                PizzaNum5 = id5,
                PizzaNum6 = id6,
                PizzaNum7 = id7,
                PizzaNum8 = id8,
                PizzaNum9 = id9,
                PizzaNum10 = id10,
                PizzaNum11 = id11,
                PizzaNum12 = id12,
            };
        }

        public static int OrderRepoPizzaIDReturn(int size, int type)
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
