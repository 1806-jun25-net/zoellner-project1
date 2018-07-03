//Anthony Zoellner
//Project 1

using NLog;
using PizzaStoreApplicationLibrary;
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
        public static List<User> UserList = new List<User>();

        public static User CreateNewUser()
        {
            logger.Info("Begin CreateNewUser method");
            bool NewUsername = false;
            string Username = "";
            while (!NewUsername)
            {
                Console.WriteLine("Welcome! Please enter a new username:");
                Username = Console.ReadLine();
                string PossiblePath = Username + ".xml";
                if (File.Exists(PossiblePath))
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

            Console.WriteLine("We only deliver within Virginia! Please enter your street address:");
            string Address = Console.ReadLine();

            Console.WriteLine("Please enter your city:");
            string City = Console.ReadLine();

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


            User NewUser = new User(Username, First, Last, Phone, Email, Address, City, Favorite);
            logger.Info("Object Created");

            UserList.Add(NewUser);
            
            return NewUser;
        }

        public static Location DeserializeLocation(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(Location));
                return (Location)serializer.Deserialize(stream);
            }

        }

        public static User DeserializeUser(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(User));
                return (User)serializer.Deserialize(stream);
            }
        }

        public static void DeserializeUserList(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(List<User>));
                IEnumerable<User> desList = (IEnumerable<User>)serializer.Deserialize(stream);
                foreach (var item in desList)
                {
                    User user = (User)item;
                    UserList.Add(user);
                }
            }
            
        }

        public static void SerializeLocation(string fileName, Location location)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(Location));
                serializer.Serialize(stream, location);
            }
        }

        public static void SerializeUser(string fileName, User user)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(User));
                serializer.Serialize(stream, user);
            }
        }

        public static void SerializeUserList(string fileName, List<User> list)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(List<User>));
                serializer.Serialize(stream, list);
            }
        }

        public static void ViewCurrentUsers()
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
            logger.Info("Beginning application");
            User CurrentUser = new User();
            Location Reston;
            Location Herndon;
            Location Dulles;
            Location Hattontown;
            int NumPizzas;

            if (File.Exists("reston.xml"))
            {
                Reston = DeserializeLocation("reston.xml");
            }
            else
            {
                Reston = new Location("Reston");
                SerializeLocation("reston.xml", Reston);
                Reston = DeserializeLocation("reston.xml");
            }
            if (File.Exists("herndon.xml"))
            {
                Herndon = DeserializeLocation("herndon.xml");
            }
            else
            {
                Herndon = new Location("Herndon");
                SerializeLocation("herndon.xml", Herndon);
                Reston = DeserializeLocation("herndon.xml");
            }
            if (File.Exists("dulles.xml"))
            {
                Dulles = DeserializeLocation("dulles.xml");
            }
            else
            {
                Dulles = new Location("Dulles");
                SerializeLocation("dulles.xml", Dulles);
                Reston = DeserializeLocation("dulles.xml");
            }
            if (File.Exists("hattontown.xml"))
            {
                Hattontown = DeserializeLocation("hattontown.xml");
            }
            else
            {
                Hattontown = new Location("Hattontown");
                SerializeLocation("hattontown.xml", Hattontown);
                Reston = DeserializeLocation("hattontown.xml");
            }

            if (File.Exists("userlist.xml"))
            {
                DeserializeUserList("userlist.xml");
            }

            Console.WriteLine("Welcome to our new pizza application!");
            string Input;
            bool UsernameEntered = false;
            while (!UsernameEntered)
            {
                Console.WriteLine("Please enter a valid username, type 'users' to see all current users, or enter 'new'");
                Input = Console.ReadLine();
                Input = Input.ToLower();
                if (Input.Equals("new"))
                {
                    logger.Info("Creating New User");
                    CurrentUser = CreateNewUser();
                    logger.Info("New User Created");
                    UsernameEntered = true;
                    Console.Clear();

                }
                else if (File.Exists(Input + ".xml"))
                {
                    logger.Info("Retrieving user information"); 
                    string path = Input + ".xml";
                    CurrentUser = DeserializeUser(path);
                    logger.Info("User information retrieved");
                    UsernameEntered = true;
                    Console.Clear();
                }
                else if (Input.Equals("users"))
                {
                    ViewCurrentUsers();
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
                Input = Console.ReadLine();
                Input = Input.ToLower();

                if(!Input.Equals("order") && !Input.Equals("exit") && !Input.Equals("history"))
                {
                    Console.WriteLine("Please input an accepted command");
                    Console.WriteLine("Order: place a new order; History : view your order history; Exit: exit the application");
                    Input = Console.ReadLine();
                    Input = Input.ToLower();
                }
                else if (Input.Equals("order"))
                {
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

                    if(NumPizzas < 0)
                    {
                        Console.WriteLine("Error: Invalid input detected (we can't make negative pizzas)");
                        Console.WriteLine("Let's try this again from the top.");
                        continue;
                    }
                    else if(NumPizzas == 0)
                    {
                        Console.WriteLine("Wait...didn't you want to order at least one pizza? We have to start over...");
                        continue;
                    }
                    else if(NumPizzas > 0 && NumPizzas <= 12)
                    {
                        Console.WriteLine("Are we delivering from your favorite store? Y/N");
                        Console.WriteLine("Your favorite store is: " + CurrentUser.Favorite);
                        Input = Console.ReadLine().ToLower();
                        bool ValidLocation = false;
                        bool AcceptedInput = false;
                        string DeliveryLocation = "";
                        if(Input != "y" && Input != "n")
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
                                    Console.WriteLine("Please input a valid favorite location.");
                                }
                                else
                                {
                                    ValidLocation = true;
                                }
                            }
                        }
                        if(Input == "y")
                        {
                            DeliveryLocation = CurrentUser.Favorite;
                        }
                        DeliveryLocation = DeliveryLocation.ToLower();

                        Order CurrentOrder = new Order();
                        bool CanOrder = true;
                        switch (DeliveryLocation)
                        {
                            case "reston":
                                if (File.Exists("reston.xml"))
                                {
                                    CanOrder = Reston.LastOrderOverTwoHoursAgo(CurrentUser);
                                }
                                if (CanOrder)
                                {
                                    CurrentOrder = Reston.CreateOrder(CurrentUser, NumPizzas);
                                }
                                break;
                            case "herndon":
                                if (File.Exists("herndon.xml") && Herndon.OrderHistory.Capacity > 0)
                                {
                                    CanOrder = Herndon.LastOrderOverTwoHoursAgo(CurrentUser);
                                }
                                if (CanOrder)
                                {
                                    CurrentOrder = Herndon.CreateOrder(CurrentUser, NumPizzas);
                                }
                                break;
                            case "dulles":
                                if (File.Exists("dulles.xml"))
                                {
                                    CanOrder = Dulles.LastOrderOverTwoHoursAgo(CurrentUser);
                                }
                                if (CanOrder)
                                {
                                    CurrentOrder = Dulles.CreateOrder(CurrentUser, NumPizzas);
                                }
                                break;
                            case "hattontown":
                                if (File.Exists("hattontown.xml"))
                                {
                                    CanOrder = Hattontown.LastOrderOverTwoHoursAgo(CurrentUser);
                                }
                                if (CanOrder)
                                {
                                    CurrentOrder = Hattontown.CreateOrder(CurrentUser, NumPizzas);
                                }
                                break;
                            default:
                                break;
                        }
                        if (CanOrder)
                        {
                            CurrentUser.UserFavoritePizza(CurrentOrder);

                            Console.Clear();
                            Console.WriteLine("Your order has been placed!");
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("We're sorry, but you have already placed an order at this location within the past two hours.");
                            Console.WriteLine("Please begin the order again selecting another location or wait two hours");
                            Console.WriteLine("");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Error: There is a 12 pizza maximum. Please input a lower number of pizzas.");
                        Console.WriteLine("We're going to have to start over...");
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

                    List<Order> UserOrderHistory = new List<Order>();
                    UserOrderHistory.AddRange(DisplayUserOrderHistory(CurrentUser, Sort, Reston));
                    UserOrderHistory.AddRange(DisplayUserOrderHistory(CurrentUser, Sort, Herndon));
                    UserOrderHistory.AddRange(DisplayUserOrderHistory(CurrentUser, Sort, Dulles));
                    UserOrderHistory.AddRange(DisplayUserOrderHistory(CurrentUser, Sort, Hattontown));

                    switch (Sort)
                    {
                        case "1":
                            UserOrderHistory.OrderBy(x => x.OrderPlaced).Select(x => x.OrderPlaced);
                            break;
                        case "2":
                            UserOrderHistory.OrderByDescending(x => x.OrderPlaced);
                            break;
                        case "3":
                            UserOrderHistory.OrderBy(x => x.cost);
                            break;
                        case "4":
                            UserOrderHistory.OrderByDescending(x => x.cost);
                            break;
                        default:
                            break;
                    }

                    foreach (var item in UserOrderHistory)
                    {
                        Console.WriteLine(item.OrderPlaced + " Total cost: $" + item.cost + ".00  Total pizzas:" + item.NumberOfPizzas );
                        Console.WriteLine("You ordered:");
                        Console.WriteLine("");
                        for (int i = 0; i < item.NumberOfPizzas; i++)
                        {
                            Console.WriteLine("     " + item.PrintPizza(item.DesiredSizes[i], item.DesiredTypes[i]));
                        }
                        Console.WriteLine("");
                    }
                    
                }
                else if (Input.Equals("exit"))
                {
                    KeepOpen = false;
                }
            }
            logger.Info("Beginning serialization of locations");
            SerializeLocation("reston.xml", Reston);
            SerializeLocation("herndon.xml", Herndon);
            SerializeLocation("dulles.xml", Dulles);
            SerializeLocation("hattontown.xml", Hattontown);

            logger.Info("Locations serialized. Serializing user.");
            string name = CurrentUser.Username;
            string NewFile = name + ".xml";
            SerializeUser(NewFile, CurrentUser);
            SerializeUserList("userlist.xml", UserList);
            logger.Info("Exitting Application");
            Environment.Exit(0);
        }
    }
}
