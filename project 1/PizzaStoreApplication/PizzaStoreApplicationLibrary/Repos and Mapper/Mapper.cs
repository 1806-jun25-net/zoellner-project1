﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStoreApplicationLibrary
{
    public static class Mapper
    {
        public static Location Map(StoreLocation location)
        {
            return new Location
            {
                Name = location.CityName,
                Dough = location.DoughRemaining,
                Cheese = location.CheeseRemaining,
                Sauce = location.SauceRemaining,
                Pepperoni = location.PepperoniRemaining,
                PeppersAndOnions = location.VeggiesRemaining,
                HamAndMeatball = location.MeatRemaining
            };
        }

        public static StoreLocation Map(Location location)
        {
            return new StoreLocation
            {
                CityName = location.Name,
                DoughRemaining = location.Dough,
                CheeseRemaining = location.Cheese,
                SauceRemaining = location.Sauce,
                PepperoniRemaining = location.Pepperoni,
                MeatRemaining = location.HamAndMeatball,
                VeggiesRemaining = location.PeppersAndOnions
            };
        }

        public static User Map(Users user)
        {
            return new User
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.EmailAddress,
                Favorite = user.DefaultLocation,
                Address = user.PhysicalAddress
            };
        }

        public static Users Map(User user)
        {
            return new Users
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                EmailAddress = user.Email,
                DefaultLocation = user.Favorite,
                PhysicalAddress = user.Address
            };
        }

        public static Order Map(Orders order)
        {
            return new Order
            {
                OrderPlaced = (DateTime)order.OrderTime,
                NumberOfPizzas = order.NumPizzas,
                DesiredSizes = GetDesiredSizes(order),
                DesiredTypes = GetDesiredTypes(order),
                //cost = order.TotalCost
            };
        }

        public static Orders Map(Order order)
        {
            order.DesiredSizes.TrimExcess();
            order.DesiredTypes.TrimExcess();
            int id1 = 0;
            int id2 = 0;
            int id3 = 0;
            int id4 = 0;
            int id5 = 0;
            int id6 = 0;
            int id7 = 0;
            int id8 = 0;
            int id9 = 0;
            int id10 = 0;
            int id11 = 0;
            int id12 = 0;
            id1 = PizzaIDReturn(order.DesiredSizes[0], order.DesiredTypes[0]);
            if(order.DesiredSizes.Capacity > 1)
            {
                id2 = PizzaIDReturn(order.DesiredSizes[1], order.DesiredTypes[1]);

                if (order.DesiredSizes.Capacity > 2)
                {
                    id3 = PizzaIDReturn(order.DesiredSizes[2], order.DesiredTypes[2]);

                    if (order.DesiredSizes.Capacity > 3)
                    {
                        id4 = PizzaIDReturn(order.DesiredSizes[3], order.DesiredTypes[3]);

                        if (order.DesiredSizes.Capacity > 4)
                        {
                            id5 = PizzaIDReturn(order.DesiredSizes[4], order.DesiredTypes[4]);

                            if (order.DesiredSizes.Capacity > 5)
                            {
                                id6 = PizzaIDReturn(order.DesiredSizes[5], order.DesiredTypes[5]);

                                if (order.DesiredSizes.Capacity > 6)
                                { 
                                    id7 = PizzaIDReturn(order.DesiredSizes[6], order.DesiredTypes[6]);

                                    if (order.DesiredSizes.Capacity > 7)
                                    {
                                        id8 = PizzaIDReturn(order.DesiredSizes[7], order.DesiredTypes[7]);

                                        if (order.DesiredSizes.Capacity > 8)
                                        {
                                            id9 = PizzaIDReturn(order.DesiredSizes[8], order.DesiredTypes[8]);

                                            if (order.DesiredSizes.Capacity > 9)
                                            {
                                                id10 = PizzaIDReturn(order.DesiredSizes[9], order.DesiredTypes[9]);

                                                if (order.DesiredSizes.Capacity > 10)
                                                {
                                                    id11 = PizzaIDReturn(order.DesiredSizes[10], order.DesiredTypes[10]);

                                                    if (order.DesiredSizes.Capacity > 11)
                                                    {
                                                        id12 = PizzaIDReturn(order.DesiredSizes[11], order.DesiredTypes[11]);
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
            return new Orders
            {
                OrderTime = order.OrderPlaced,
                NumPizzas = order.NumberOfPizzas,
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

        public static List<int> GetDesiredSizes(Orders order)
        {
            List<int> sizes = new List<int>();
            int pizza1 = order.PizzaNum1;
            sizes.Add(Sizes(pizza1));

            if(order.PizzaNum2 != null)
            {
                sizes.Add(Sizes((int)order.PizzaNum2));
            }
            if (order.PizzaNum3 != null)
            {
                sizes.Add(Sizes((int)order.PizzaNum3));
            }
            if (order.PizzaNum4 != null)
            {
                sizes.Add(Sizes((int)order.PizzaNum4));
            }
            if (order.PizzaNum5 != null)
            {
                sizes.Add(Sizes((int)order.PizzaNum5));
            }
            if (order.PizzaNum6 != null)
            {
                sizes.Add(Sizes((int)order.PizzaNum6));
            }
            if (order.PizzaNum7 != null)
            {
                sizes.Add(Sizes((int)order.PizzaNum7));
            }
            if (order.PizzaNum8 != null)
            {
                sizes.Add(Sizes((int)order.PizzaNum8));
            }
            if (order.PizzaNum9 != null)
            {
                sizes.Add(Sizes((int)order.PizzaNum9));
            }
            if (order.PizzaNum10 != null)
            {
                sizes.Add(Sizes((int)order.PizzaNum10));
            }
            if (order.PizzaNum11 != null)
            {
                sizes.Add(Sizes((int)order.PizzaNum11));
            }
            if (order.PizzaNum12 != null)
            {
                sizes.Add(Sizes((int)order.PizzaNum12));
            }

            return sizes;
        }

        public static List<int> GetDesiredTypes(Orders order)
        {
            List<int> types = new List<int>();
            int pizza1 = order.PizzaNum1;
            types.Add(Types(pizza1));

            if (order.PizzaNum2 != null)
            {
                types.Add(Types((int)order.PizzaNum2));
            }
            if (order.PizzaNum3 != null)
            {
                types.Add(Types((int)order.PizzaNum3));
            }
            if (order.PizzaNum4 != null)
            {
                types.Add(Types((int)order.PizzaNum4));
            }
            if (order.PizzaNum5 != null)
            {
                types.Add(Types((int)order.PizzaNum5));
            }
            if (order.PizzaNum6 != null)
            {
                types.Add(Types((int)order.PizzaNum6));
            }
            if (order.PizzaNum7 != null)
            {
                types.Add(Types((int)order.PizzaNum7));
            }
            if (order.PizzaNum8 != null)
            {
                types.Add(Types((int)order.PizzaNum8));
            }
            if (order.PizzaNum9 != null)
            {
                types.Add(Types((int)order.PizzaNum9));
            }
            if (order.PizzaNum10 != null)
            {
                types.Add(Types((int)order.PizzaNum10));
            }
            if (order.PizzaNum11 != null)
            {
                types.Add(Types((int)order.PizzaNum11));
            }
            if (order.PizzaNum12 != null)
            {
                types.Add(Types((int)order.PizzaNum12));
            }

            return types;
        }

        public static int Sizes(int ID)
        {
            int CurrentSize = 0;
            switch (ID)
            {
                case 1:
                case 4:
                case 7:
                case 10:
                    CurrentSize = 1;
                    break;
                case 2:
                case 5:
                case 8:
                case 11:
                    CurrentSize = 2;
                    break;
                case 3:
                case 6:
                case 9:
                case 12:
                    CurrentSize = 3;
                    break;
                default:
                    break;
            }
            return CurrentSize;
        }

        public static int Types(int ID)
        {
            int CurrentType = 0;
            switch (ID)
            {
                case 1:
                case 2:
                case 3:
                    CurrentType = 1;
                    break;
                case 4:
                case 5:
                case 6:
                    CurrentType = 2;
                    break;
                case 7:
                case 8:
                case 9:
                    CurrentType = 3;
                    break;
                case 10:
                case 11:
                case 12:
                    CurrentType = 4;
                    break;
                default:
                    break;
            }
            return CurrentType;
        }

        public static int PizzaIDReturn(int size, int type)
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
