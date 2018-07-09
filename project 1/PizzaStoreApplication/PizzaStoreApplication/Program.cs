//Anthony Zoellner
//Project 1

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog;
using PizzaStoreApplicationLibrary;
using PizzaStoreApplicationLibrary.Repos_and_Mapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PizzaStoreApplication
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static User CreateNewUser(IEnumerable<Users> UserList, UserRepo userRepo)
        {
            logger.Info("Begin CreateNewUser method");
            bool NewUsername = false;
            string Username = "";
            while (!NewUsername)
            {
                Console.WriteLine("Welcome! Please enter a new username:");
                Username = Console.ReadLine();
                bool TakenName = false;
                foreach (var item in UserList)
                {
                    if(item.Username == Username)
                    {
                        TakenName = true;
                    }
                }
                if (TakenName)
                {
                    Console.WriteLine("Username taken. Please select a different username.");
                }
                else
                {
                    NewUsername = true;
                }
            }

            Console.WriteLine("Please enter your first name:");
            string First = Console.ReadLine();

            Console.WriteLine("Please enter your last name:");
            string Last = Console.ReadLine();

            Console.WriteLine("Please enter a phone number we can contact:");
            string Phone = Console.ReadLine();

            Console.WriteLine("Please enter an email address we can contact:");
            string Email = Console.ReadLine();

            Console.WriteLine("We only deliver within Virginia! Please enter your full address (city included):");
            string Address = Console.ReadLine();

            bool ValidFavorite = false;
            string Favorite = "";
            Console.WriteLine("Which store would you like to mark as your favorite?");
            while (!ValidFavorite)
            {
                Console.WriteLine("Available stores: Reston, Herndon, Dulles, Hattontown");
                Favorite = Console.ReadLine().ToLower();

                if (Favorite != "reston" && Favorite != "herndon" && Favorite != "dulles" && Favorite != "hattontown")
                {
                    Console.WriteLine("Please input a valid favorite location.");
                }
                else
                {
                    ValidFavorite = true;
                }
            }

            Console.WriteLine("Excellent! We have all of your information!");
            logger.Info("Creating User object");


            User NewUser = new User(Username, First, Last, Phone, Email, Address, Favorite);
            logger.Info("New User Created");

            userRepo.AddUser(NewUser);
            
            return NewUser;
        }

        //public static Location DeserializeLocation(string fileName)
        //{
        //    using (var stream = new FileStream(fileName, FileMode.Open))
        //    {
        //        var serializer = new XmlSerializer(typeof(Location));
        //        return (Location)serializer.Deserialize(stream);
        //    }

        //}

        //public static User DeserializeUser(string fileName)
        //{
        //    using (var stream = new FileStream(fileName, FileMode.Open))
        //    {
        //        var serializer = new XmlSerializer(typeof(User));
        //        return (User)serializer.Deserialize(stream);
        //    }
        //}

        //public static void DeserializeUserList(string fileName)
        //{
        //    using (var stream = new FileStream(fileName, FileMode.Open))
        //    {
        //        var serializer = new XmlSerializer(typeof(List<User>));
        //        IEnumerable<User> desList = (IEnumerable<User>)serializer.Deserialize(stream);
        //        foreach (var item in desList)
        //        {
        //            User user = (User)item;
        //            UserList.Add(user);
        //        }
        //    }
            
        //}

        //public static void SerializeLocation(string fileName, Location location)
        //{
        //    using (var stream = new FileStream(fileName, FileMode.Create))
        //    {
        //        var serializer = new XmlSerializer(typeof(Location));
        //        serializer.Serialize(stream, location);
        //    }
        //}

        //public static void SerializeUser(string fileName, User user)
        //{
        //    using (var stream = new FileStream(fileName, FileMode.Create))
        //    {
        //        var serializer = new XmlSerializer(typeof(User));
        //        serializer.Serialize(stream, user);
        //    }
        //}

        //public static void SerializeUserList(string fileName, List<User> list)
        //{
        //    using (var stream = new FileStream(fileName, FileMode.Create))
        //    {
        //        var serializer = new XmlSerializer(typeof(List<User>));
        //        serializer.Serialize(stream, list);
        //    }
        //}

        public static void ViewCurrentUsers(IEnumerable<Users> UserList)
        {
            Console.WriteLine("Listing current users:");
            foreach (var item in UserList)
            {
                Console.WriteLine("     " + item.Username);
            }
            Console.WriteLine("");
        }

        public static List<Order> DisplayUserOrderHistory(User user, string Sort, Location location)
        {
            string username = user.Username;
            List<Order> OrdersFromThisLocation = location.RetrieveUserOrderHistory(username);
            switch (Sort)
            {
                case "1":
                    break;
                case "2":
                    OrdersFromThisLocation.Reverse();
                    break;
                case "3":
                    OrdersFromThisLocation.OrderBy(x => x.cost);
                    break;
                case "4":
                    OrdersFromThisLocation.OrderByDescending(x => x.cost);
                    break;
                default:
                    break;
            }
            return OrdersFromThisLocation;
        }

        static void Main(string[] args)
        {
            logger.Info("Beginning data retrieval");

            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configBuilder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<Project1PizzaApplicationContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Project1PizzaApplication"));
            var options = optionsBuilder.Options;

            logger.Info("Creating repo objects");
            var userRepo = new UserRepo(new Project1PizzaApplicationContext(optionsBuilder.Options));
            var locationRepo = new LocationRepo(new Project1PizzaApplicationContext(optionsBuilder.Options));
            var orderRepo = new OrderRepo(new Project1PizzaApplicationContext(optionsBuilder.Options));
            logger.Info("Repo objects created");

            logger.Info("Beginning application");
            User CurrentUser = new User();
            Location Reston = new Location("Reston");
            Location Herndon = new Location("Herndon");
            Location Dulles = new Location("Dulles");
            Location Hattontown = new Location("Hattontown");
            int NumPizzas;

            logger.Info("Obtaining information from database");
            var UserList = userRepo.GetUsers();
            var LocationList = locationRepo.GetLocations();
            var OrderList = orderRepo.GetOrders();
            logger.Info("Information obtained");

            logger.Info("Setting location information");
            foreach (var item in LocationList)
            {
                if(item.CityName.ToLower() == "reston")
                {
                    Reston = Mapper.Map(item);
                }
                if (item.CityName.ToLower() == "herndon")
                {
                    Herndon = Mapper.Map(item);
                }
                if (item.CityName.ToLower() == "hattontown")
                {
                    Hattontown = Mapper.Map(item);
                }
                if (item.CityName.ToLower() == "dulles")
                {
                    Dulles = Mapper.Map(item);
                }
            }

            logger.Info("Setting location order history");
            foreach (var item in OrderList)
            {
                if(item.StoreLocation.ToLower() == "reston")
                {
                    Reston.OrderHistory.Add(Mapper.Map(item));
                }
                if (item.StoreLocation.ToLower() == "herndon")
                {
                    Herndon.OrderHistory.Add(Mapper.Map(item));
                }
                if (item.StoreLocation.ToLower() == "hattontown")
                {
                    Hattontown.OrderHistory.Add(Mapper.Map(item));
                }
                if (item.StoreLocation.ToLower() == "dulles")
                {
                    Dulles.OrderHistory.Add(Mapper.Map(item));
                }
            }
            logger.Info("All information obtained and set");

            Console.WriteLine("Welcome to our new pizza application!");
            string Input;
            bool UsernameEntered = false;
            while (!UsernameEntered)
            {
                Console.WriteLine("Please enter a valid username, type 'users' to see all current users, or enter 'new'");
                logger.Info("Obtaining username");
                Input = Console.ReadLine();
                Input = Input.ToLower();
                if (Input.Equals("new"))
                {
                    logger.Info("Creating New User");
                    CurrentUser = CreateNewUser(UserList, userRepo);
                    logger.Info("New User Created");
                    UsernameEntered = true;
                    Console.Clear();

                }
                else if (UserList.Any(u => u.Username.ToLower() == Input))
                {
                    logger.Info("Retrieving user information");
                    foreach (var item in UserList)
                    {
                        if(item.Username.ToLower() == Input)
                        {
                            CurrentUser = Mapper.Map(item);
                        }
                    }
                    logger.Info("User information retrieved");
                    UsernameEntered = true;
                    Console.Clear();
                }
                else if (Input.Equals("users"))
                {
                    logger.Info("Listing current users");
                    ViewCurrentUsers(UserList);
                    logger.Info("Users listed");
                }
                else
                {
                    Console.WriteLine("Username not detected.");
                }
            }

            bool KeepOpen = true;
            while (KeepOpen)
            {
                Console.WriteLine("Welcome! Let's get started!");
                Console.WriteLine("Please input one of the following:");
                Console.WriteLine("Order: place a new order; History: view your order history; Exit: exit the application");
                logger.Info("Recieving use input");
                Input = Console.ReadLine();
                Input = Input.ToLower();

                if (!Input.Equals("order") && !Input.Equals("exit") && !Input.Equals("history") && !Input.Equals("resupply"))
                {
                    Console.WriteLine("Please input an accepted command");
                    Console.WriteLine("Order: place a new order; History : view your order history; Exit: exit the application");
                    Input = Console.ReadLine();
                    Input = Input.ToLower();
                }
                else if (Input.Equals("order"))
                {
                    logger.Info("Order selected");
                    Console.Clear();
                    Console.WriteLine("How many pizzas would you like to order (max of 12)? Please input a number.");
                    Input = Console.ReadLine();
                    try
                    {
                        NumPizzas = int.Parse(Input);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: Input was not an integer. Please input a number.");
                        continue;
                    }

                    if (NumPizzas < 0)
                    {
                        Console.WriteLine("Error: Invalid input detected (we can't make negative pizzas)");
                        Console.WriteLine("Let's try this again from the top.");
                        continue;
                    }
                    else if (NumPizzas == 0)
                    {
                        Console.WriteLine("Wait...didn't you want to order at least one pizza? We have to start over...");
                        continue;
                    }
                    else if (NumPizzas > 0 && NumPizzas <= 12)
                    {
                        logger.Info("Beginning order creation");
                        Console.WriteLine("Are we delivering from your favorite store? Y/N");
                        Console.WriteLine("Your favorite store is: " + CurrentUser.Favorite);
                        Input = Console.ReadLine().ToLower();
                        bool ValidLocation = false;
                        bool AcceptedInput = false;
                        string DeliveryLocation = "";
                        if (Input != "y" && Input != "n")
                        {
                            while (!AcceptedInput)
                            {
                                Console.WriteLine("Please input either 'y' for yes or 'n' for no.");
                                Input = Console.ReadLine().ToLower();
                                if (Input != "y" && Input != "n")
                                {
                                    continue;
                                }
                                else
                                {
                                    AcceptedInput = true;
                                }
                            }
                        }
                        if (Input == "n")
                        {
                            while (!ValidLocation)
                            {
                                Console.WriteLine("Which location shall we send the order to?");
                                DeliveryLocation = Console.ReadLine().ToLower();
                                if (DeliveryLocation != "reston" && DeliveryLocation != "herndon" && DeliveryLocation != "dulles" && DeliveryLocation != "hattontown")
                                {
                                    Console.WriteLine("Please input a valid location.");
                                }
                                else
                                {
                                    ValidLocation = true;
                                }
                            }
                        }
                        if (Input == "y")
                        {
                            DeliveryLocation = CurrentUser.Favorite;
                            DeliveryLocation.ToLower();
                        }

                        Order CurrentOrder = new Order();
                        bool CanOrder = true;
                        logger.Info("Checking if user ordered more than 2 hours ago");
                        switch (DeliveryLocation)
                        {
                            case "reston":
                                CanOrder = Reston.LastOrderOverTwoHoursAgo(CurrentUser);

                                if (CanOrder)
                                {
                                    CurrentOrder = Reston.CreateOrder(CurrentUser, NumPizzas);
                                }
                                break;
                            case "herndon":
                                CanOrder = Herndon.LastOrderOverTwoHoursAgo(CurrentUser);

                                if (CanOrder)
                                {
                                    CurrentOrder = Herndon.CreateOrder(CurrentUser, NumPizzas);
                                }
                                break;
                            case "dulles":
                                CanOrder = Dulles.LastOrderOverTwoHoursAgo(CurrentUser);

                                if (CanOrder)
                                {
                                    CurrentOrder = Dulles.CreateOrder(CurrentUser, NumPizzas);
                                }
                                break;
                            case "hattontown":
                                CanOrder = Hattontown.LastOrderOverTwoHoursAgo(CurrentUser);

                                if (CanOrder)
                                {
                                    CurrentOrder = Hattontown.CreateOrder(CurrentUser, NumPizzas);
                                }
                                break;
                            default:
                                break;
                        }
                        logger.Info("Check complete");
                        if (CanOrder)
                        {
                            logger.Info("Creating order");
                            CurrentUser.UserFavoritePizza(CurrentOrder);
                            orderRepo.AddOrder(CurrentOrder);

                            Console.Clear();
                            Console.WriteLine("Your order has been placed!");
                            Console.WriteLine("");
                            logger.Info("Order placed");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("We're sorry, but you have already placed an order at this location within the past two hours.");
                            Console.WriteLine("Please begin the order again selecting another location or wait two hours");
                            Console.WriteLine("");
                            logger.Info("User unable to order from chosen location");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Error: There is a 12 pizza maximum. Please input a lower number of pizzas.");
                        Console.WriteLine("We're going to have to start over...");
                        logger.Info("User attempted to go over pizza limit");
                        continue;
                    }
                }
                else if (Input.Equals("history"))
                {
                    string username = CurrentUser.Username;
                    Console.Clear();
                    Console.WriteLine("How would you like the information displayed?");
                    Console.WriteLine("We can sort by: earliest, latest, cheapest, most expensive.");
                    Console.WriteLine("Type '1' for earliest, '2' for latest, '3' for cheapest, or '4' for most expensive.");
                    string Sort = Console.ReadLine();
                    Console.WriteLine("");

                    logger.Info("Displaying order history for user");
                    List<Order> UserOrderHistory = new List<Order>();
                    dynamic SortedHistory = "";
                    UserOrderHistory.AddRange(DisplayUserOrderHistory(CurrentUser, Sort, Reston));
                    UserOrderHistory.AddRange(DisplayUserOrderHistory(CurrentUser, Sort, Herndon));
                    UserOrderHistory.AddRange(DisplayUserOrderHistory(CurrentUser, Sort, Dulles));
                    UserOrderHistory.AddRange(DisplayUserOrderHistory(CurrentUser, Sort, Hattontown));

                    switch (Sort)
                    {
                        case "1":
                            SortedHistory = UserOrderHistory.OrderBy(x => x.OrderPlaced).Select(x => x);
                            break;
                        case "2":
                            SortedHistory = UserOrderHistory.OrderByDescending(x => x.OrderPlaced).Select(x => x);
                            break;
                        case "3":
                            SortedHistory = UserOrderHistory.OrderBy(x => x.cost);
                            break;
                        case "4":
                            SortedHistory = UserOrderHistory.OrderByDescending(x => x.cost);
                            break;
                        default:
                            break;
                    }

                    foreach (var item in SortedHistory)
                    {
                        Console.WriteLine(item.OrderPlaced + " Total cost: $" + item.cost + ".00  Total pizzas:" + item.NumberOfPizzas +
                                          " from our " + item.location + " location.");
                        Console.WriteLine("You ordered:");
                        Console.WriteLine("");
                        for (int i = 0; i < item.NumberOfPizzas; i++)
                        {
                            Console.WriteLine("     " + item.PrintPizza(item.DesiredSizes[i], item.DesiredTypes[i]));
                        }
                        Console.WriteLine("");
                    }
                    logger.Info("History displayed");
                }

                else if (Input.Equals("resupply"))
                {
                    logger.Info("Resupplying location");
                    Console.Clear();
                    Console.WriteLine("Which store shall we resupply?");
                    Console.WriteLine("Enter 'Reston', 'Herndon', 'Dulles', or 'Hattontown'.");
                    string ResupplyLoc = Console.ReadLine().ToLower();

                    switch (ResupplyLoc)
                    {
                        case "reston":
                            Reston.Resupply();
                            break;
                        case "herndon":
                            Herndon.Resupply();
                            break;
                        case "dulles":
                            Dulles.Resupply();
                            break;
                        case "hattontown":
                            Hattontown.Resupply();
                            break;
                        default:
                            break;
                    }
                }

                else if (Input.Equals("exit"))
                {
                    KeepOpen = false;
                }
            }

            logger.Info("Updating user favorite pizza");
            foreach (var item in UserList)
            {
                if(item.Username == CurrentUser.Username)
                {
                    item.RecommendedPizza = CurrentUser.FavoritePizza;
                    item.NumCheeseOrdered = CurrentUser.CheeseOrdered;
                    item.NumPepperoniOrdered = CurrentUser.PepperoniOrdered;
                    item.NumMeatOrdered = CurrentUser.MeatOrdered;
                    item.NumVeggieOrdered = CurrentUser.VeggieOrdered;
                    userRepo.UpdateUser(item);
                }
            }
            logger.Info("Update complete");

            logger.Info("Updating location inventories");
            foreach (var item in LocationList)
            {
                if(item.CityName.ToLower() == "reston")
                {
                    item.DoughRemaining = Reston.Dough;
                    item.SauceRemaining = Reston.Sauce;
                    item.CheeseRemaining = Reston.Cheese;
                    item.PepperoniRemaining = Reston.Pepperoni;
                    item.MeatRemaining = Reston.HamAndMeatball;
                    item.VeggiesRemaining = Reston.PeppersAndOnions;
                    locationRepo.EditLocation(item);
                }
                if (item.CityName.ToLower() == "herndon")
                {
                    item.DoughRemaining = Herndon.Dough;
                    item.SauceRemaining = Herndon.Sauce;
                    item.CheeseRemaining = Herndon.Cheese;
                    item.PepperoniRemaining = Herndon.Pepperoni;
                    item.MeatRemaining = Herndon.HamAndMeatball;
                    item.VeggiesRemaining = Herndon.PeppersAndOnions;
                    locationRepo.EditLocation(item);
                }
                if (item.CityName.ToLower() == "hattontown")
                {
                    item.DoughRemaining = Hattontown.Dough;
                    item.SauceRemaining = Hattontown.Sauce;
                    item.CheeseRemaining = Hattontown.Cheese;
                    item.PepperoniRemaining = Hattontown.Pepperoni;
                    item.MeatRemaining = Hattontown.HamAndMeatball;
                    item.VeggiesRemaining = Hattontown.PeppersAndOnions;
                    locationRepo.EditLocation(item);
                }
                if (item.CityName.ToLower() == "dulles")
                {
                    item.DoughRemaining = Dulles.Dough;
                    item.SauceRemaining = Dulles.Sauce;
                    item.CheeseRemaining = Dulles.Cheese;
                    item.PepperoniRemaining = Dulles.Pepperoni;
                    item.MeatRemaining = Dulles.HamAndMeatball;
                    item.VeggiesRemaining = Dulles.PeppersAndOnions;
                    locationRepo.EditLocation(item);
                }
            }
            logger.Info("update complete, closing application");

            Environment.Exit(0);
        }

        //public static void OldCode()
        //{
        //    logger.Info("Beginning application");
        //    User CurrentUser = new User();
        //    Location Reston = new Location("Reston");
        //    Location Herndon = new Location("Herndon");
        //    Location Dulles = new Location("Dulles");
        //    Location Hattontown = new Location("Hattontown");
        //    int NumPizzas;
        //    //if (File.Exists("reston.xml"))
        //    //{
        //    //    Reston = DeserializeLocation("reston.xml");
        //    //    Reston.Name = "Reston";
        //    //}
        //    //else
        //    //{
        //    //    Reston = new Location("Reston");
        //    //}
        //    //if (File.Exists("herndon.xml"))
        //    //{
        //    //    Herndon = DeserializeLocation("herndon.xml");
        //    //    Herndon.Name = "Herndon";
        //    //}
        //    //else
        //    //{
        //    //    Herndon = new Location("Herndon");
        //    //}
        //    //if (File.Exists("dulles.xml"))
        //    //{
        //    //    Dulles = DeserializeLocation("dulles.xml");
        //    //    Dulles.Name = "Dulles";
        //    //}
        //    //else
        //    //{
        //    //    Dulles = new Location("Dulles");
        //    //}
        //    //if (File.Exists("hattontown.xml"))
        //    //{
        //    //    Hattontown = DeserializeLocation("hattontown.xml");
        //    //    Hattontown.Name = "Hattontown";
        //    //}
        //    //else
        //    //{
        //    //    Hattontown = new Location("Hattontown");
        //    //}

        //    if (File.Exists("userlist.xml"))
        //    {
        //        DeserializeUserList("userlist.xml");
        //    }

        //    Console.WriteLine("Welcome to our new pizza application!");
        //    string Input;
        //    bool UsernameEntered = false;
        //    while (!UsernameEntered)
        //    {
        //        Console.WriteLine("Please enter a valid username, type 'users' to see all current users, or enter 'new'");
        //        Input = Console.ReadLine();
        //        Input = Input.ToLower();
        //        if (Input.Equals("new"))
        //        {
        //            logger.Info("Creating New User");
        //            CurrentUser = CreateNewUser();
        //            logger.Info("New User Created");
        //            UsernameEntered = true;
        //            Console.Clear();

        //        }
        //        else if (File.Exists(Input + ".xml"))
        //        {
        //            logger.Info("Retrieving user information");
        //            string path = Input + ".xml";
        //            CurrentUser = DeserializeUser(path);
        //            logger.Info("User information retrieved");
        //            UsernameEntered = true;
        //            Console.Clear();
        //        }
        //        else if (Input.Equals("users"))
        //        {
        //            ViewCurrentUsers();
        //        }
        //        else
        //        {
        //            Console.WriteLine("Username not detected.");
        //        }
        //    }

        //    bool KeepOpen = true;
        //    while (KeepOpen)
        //    {
        //        Console.WriteLine("Welcome! Let's get started!");
        //        Console.WriteLine("Please input one of the following:");
        //        Console.WriteLine("Order: place a new order; History: view your order history; Exit: exit the application");
        //        Input = Console.ReadLine();
        //        Input = Input.ToLower();

        //        if (!Input.Equals("order") && !Input.Equals("exit") && !Input.Equals("history") && !Input.Equals("resupply"))
        //        {
        //            Console.WriteLine("Please input an accepted command");
        //            Console.WriteLine("Order: place a new order; History : view your order history; Exit: exit the application");
        //            Input = Console.ReadLine();
        //            Input = Input.ToLower();
        //        }
        //        else if (Input.Equals("order"))
        //        {
        //            Console.Clear();
        //            Console.WriteLine("How many pizzas would you like to order (max of 12)? Please input a number.");
        //            Input = Console.ReadLine();
        //            try
        //            {
        //                NumPizzas = int.Parse(Input);
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine("Error: Input was not an integer. Please input a number.");
        //                continue;
        //            }

        //            if (NumPizzas < 0)
        //            {
        //                Console.WriteLine("Error: Invalid input detected (we can't make negative pizzas)");
        //                Console.WriteLine("Let's try this again from the top.");
        //                continue;
        //            }
        //            else if (NumPizzas == 0)
        //            {
        //                Console.WriteLine("Wait...didn't you want to order at least one pizza? We have to start over...");
        //                continue;
        //            }
        //            else if (NumPizzas > 0 && NumPizzas <= 12)
        //            {
        //                Console.WriteLine("Are we delivering from your favorite store? Y/N");
        //                Console.WriteLine("Your favorite store is: " + CurrentUser.Favorite);
        //                Input = Console.ReadLine().ToLower();
        //                bool ValidLocation = false;
        //                bool AcceptedInput = false;
        //                string DeliveryLocation = "";
        //                if (Input != "y" && Input != "n")
        //                {
        //                    while (!AcceptedInput)
        //                    {
        //                        Console.WriteLine("Please input either 'y' for yes or 'n' for no.");
        //                        Input = Console.ReadLine().ToLower();
        //                        if (Input != "y" && Input != "n")
        //                        {
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            AcceptedInput = true;
        //                        }
        //                    }
        //                }
        //                if (Input == "n")
        //                {
        //                    while (!ValidLocation)
        //                    {
        //                        Console.WriteLine("Which location shall we send the order to?");
        //                        DeliveryLocation = Console.ReadLine().ToLower();
        //                        if (DeliveryLocation != "reston" && DeliveryLocation != "herndon" && DeliveryLocation != "dulles" && DeliveryLocation != "hattontown")
        //                        {
        //                            Console.WriteLine("Please input a valid favorite location.");
        //                        }
        //                        else
        //                        {
        //                            ValidLocation = true;
        //                        }
        //                    }
        //                }
        //                if (Input == "y")
        //                {
        //                    DeliveryLocation = CurrentUser.Favorite;
        //                    DeliveryLocation.ToLower();
        //                }

        //                Order CurrentOrder = new Order();
        //                bool CanOrder = true;
        //                switch (DeliveryLocation)
        //                {
        //                    case "reston":
        //                        if (File.Exists("reston.xml"))
        //                        {
        //                            CanOrder = Reston.LastOrderOverTwoHoursAgo(CurrentUser);
        //                        }
        //                        if (CanOrder)
        //                        {
        //                            CurrentOrder = Reston.CreateOrder(CurrentUser, NumPizzas);
        //                        }
        //                        break;
        //                    case "herndon":
        //                        if (File.Exists("herndon.xml") && Herndon.OrderHistory.Capacity > 0)
        //                        {
        //                            CanOrder = Herndon.LastOrderOverTwoHoursAgo(CurrentUser);
        //                        }
        //                        if (CanOrder)
        //                        {
        //                            CurrentOrder = Herndon.CreateOrder(CurrentUser, NumPizzas);
        //                        }
        //                        break;
        //                    case "dulles":
        //                        if (File.Exists("dulles.xml"))
        //                        {
        //                            CanOrder = Dulles.LastOrderOverTwoHoursAgo(CurrentUser);
        //                        }
        //                        if (CanOrder)
        //                        {
        //                            CurrentOrder = Dulles.CreateOrder(CurrentUser, NumPizzas);
        //                        }
        //                        break;
        //                    case "hattontown":
        //                        if (File.Exists("hattontown.xml"))
        //                        {
        //                            CanOrder = Hattontown.LastOrderOverTwoHoursAgo(CurrentUser);
        //                        }
        //                        if (CanOrder)
        //                        {
        //                            CurrentOrder = Hattontown.CreateOrder(CurrentUser, NumPizzas);
        //                        }
        //                        break;
        //                    default:
        //                        break;
        //                }
        //                if (CanOrder)
        //                {
        //                    CurrentUser.UserFavoritePizza(CurrentOrder);

        //                    Console.Clear();
        //                    Console.WriteLine("Your order has been placed!");
        //                    Console.WriteLine("");
        //                }
        //                else
        //                {
        //                    Console.Clear();
        //                    Console.WriteLine("We're sorry, but you have already placed an order at this location within the past two hours.");
        //                    Console.WriteLine("Please begin the order again selecting another location or wait two hours");
        //                    Console.WriteLine("");
        //                }

        //            }
        //            else
        //            {
        //                Console.WriteLine("Error: There is a 12 pizza maximum. Please input a lower number of pizzas.");
        //                Console.WriteLine("We're going to have to start over...");
        //                continue;
        //            }
        //        }
        //        else if (Input.Equals("history"))
        //        {
        //            string username = CurrentUser.Username;
        //            Console.Clear();
        //            Console.WriteLine("How would you like the information displayed?");
        //            Console.WriteLine("We can sort by: earliest, latest, cheapest, most expensive.");
        //            Console.WriteLine("Type '1' for earliest, '2' for latest, '3' for cheapest, or '4' for most expensive.");
        //            string Sort = Console.ReadLine();
        //            Console.WriteLine("");

        //            List<Order> UserOrderHistory = new List<Order>();
        //            dynamic SortedHistory = "";
        //            UserOrderHistory.AddRange(DisplayUserOrderHistory(CurrentUser, Sort, Reston));
        //            UserOrderHistory.AddRange(DisplayUserOrderHistory(CurrentUser, Sort, Herndon));
        //            UserOrderHistory.AddRange(DisplayUserOrderHistory(CurrentUser, Sort, Dulles));
        //            UserOrderHistory.AddRange(DisplayUserOrderHistory(CurrentUser, Sort, Hattontown));

        //            switch (Sort)
        //            {
        //                case "1":
        //                    SortedHistory = UserOrderHistory.OrderBy(x => x.OrderPlaced).Select(x => x);
        //                    break;
        //                case "2":
        //                    SortedHistory = UserOrderHistory.OrderByDescending(x => x.OrderPlaced).Select(x => x);
        //                    break;
        //                case "3":
        //                    SortedHistory = UserOrderHistory.OrderBy(x => x.cost);
        //                    break;
        //                case "4":
        //                    SortedHistory = UserOrderHistory.OrderByDescending(x => x.cost);
        //                    break;
        //                default:
        //                    break;
        //            }

        //            foreach (var item in SortedHistory)
        //            {
        //                Console.WriteLine(item.OrderPlaced + " Total cost: $" + item.cost + ".00  Total pizzas:" + item.NumberOfPizzas +
        //                                  " from our " + item.location + " location.");
        //                Console.WriteLine("You ordered:");
        //                Console.WriteLine("");
        //                for (int i = 0; i < item.NumberOfPizzas; i++)
        //                {
        //                    Console.WriteLine("     " + item.PrintPizza(item.DesiredSizes[i], item.DesiredTypes[i]));
        //                }
        //                Console.WriteLine("");
        //            }

        //        }

        //        else if (Input.Equals("resupply"))
        //        {
        //            Console.Clear();
        //            Console.WriteLine("Which store shall we resupply?");
        //            Console.WriteLine("Enter 'Reston', 'Herndon', 'Dulles', or 'Hattontown'.");
        //            string ResupplyLoc = Console.ReadLine().ToLower();

        //            switch (ResupplyLoc)
        //            {
        //                case "reston":
        //                    Reston.Resupply();
        //                    break;
        //                case "herndon":
        //                    Herndon.Resupply();
        //                    break;
        //                case "dulles":
        //                    Dulles.Resupply();
        //                    break;
        //                case "hattontown":
        //                    Hattontown.Resupply();
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }

        //        else if (Input.Equals("exit"))
        //        {
        //            KeepOpen = false;
        //        }
        //    }
        //    logger.Info("Beginning serialization of locations");
        //    SerializeLocation("reston.xml", Reston);
        //    SerializeLocation("herndon.xml", Herndon);
        //    SerializeLocation("dulles.xml", Dulles);
        //    SerializeLocation("hattontown.xml", Hattontown);

        //    logger.Info("Locations serialized. Serializing user.");
        //    string name = CurrentUser.Username;
        //    string NewFile = name + ".xml";
        //    SerializeUser(NewFile, CurrentUser);
        //    SerializeUserList("userlist.xml", UserList);
        //    logger.Info("Exitting Application");
        //    Environment.Exit(0);
        //}
    }
}
