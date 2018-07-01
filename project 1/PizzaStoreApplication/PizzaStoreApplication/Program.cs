//Anthony Zoellner
//Project 1

using NLog;
using PizzaStoreApplicationLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PizzaStoreApplication
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

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

        static void OrderPizzas()
        {

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
            }
            if (File.Exists("herndon.xml"))
            {
                Herndon = DeserializeLocation("herndon.xml");
            }
            else
            {
                Herndon = new Location("Herndon");
            }
            if (File.Exists("dulles.xml"))
            {
                Dulles = DeserializeLocation("dulles.xml");
            }
            else
            {
                Dulles = new Location("Dulles");
            }
            if (File.Exists("hattontown.xml"))
            {
                Hattontown = DeserializeLocation("hattontown.xml");
            }
            else
            {
                Hattontown = new Location("Hattontown");
            }

            Console.WriteLine("Welcome to our new pizza application!");
            string Input;
            bool UsernameEntered = false;
            while (!UsernameEntered)
            {
                Console.WriteLine("Please enter a valid username or enter 'new'");
                Input = Console.ReadLine();
                Input = Input.ToLower();
                if (Input.Equals("new"))
                {
                    logger.Info("Creating New User");
                    CurrentUser = CreateNewUser();
                    logger.Info("New User Created");
                    UsernameEntered = true;

                }
                else if (File.Exists(Input + ".xml"))
                {
                    logger.Info("Retrieving user information"); 
                    string path = Input + ".xml";
                    CurrentUser = DeserializeUser(path);
                    logger.Info("User information retrieved");
                    UsernameEntered = true;
                }
                else
                {
                    Console.WriteLine("Username not detected.");
                }
            }

            bool KeepOpen = true;
            while (KeepOpen)
            {
                Console.Clear();
                Console.WriteLine("Welcome! Let's get started!");
                Console.WriteLine("Please input one of the following:");
                Console.WriteLine("Order: place a new order; Exit: exit the application");
                Input = Console.ReadLine();
                Input = Input.ToLower();

                if(!Input.Equals("order") && !Input.Equals("exit"))
                {
                    Console.WriteLine("Please input an accepted command");
                    Console.WriteLine("Order: place a new order; Exit: exit the application");
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
                        Console.WriteLine("Your favorite store is:" + CurrentUser.Favorite);
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
                        switch (DeliveryLocation)
                        {
                            case "reston":
                                Reston.CreateOrder(CurrentUser, NumPizzas);
                                break;
                            case "herndon":
                                Herndon.CreateOrder(CurrentUser, NumPizzas);
                                break;
                            case "dulles":
                                Dulles.CreateOrder(CurrentUser, NumPizzas);
                                break;
                            case "hattontown":
                                Hattontown.CreateOrder(CurrentUser, NumPizzas);
                                break;
                            default:
                                break;
                        }

                        Console.Clear();
                        Console.WriteLine("Your order has been placed!");

                    }
                    else
                    {
                        Console.WriteLine("Error: There is a 12 pizza maximum. Please input a lower number of pizzas.");
                        Console.WriteLine("We're going to have to start over...");
                        continue;
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
            logger.Info("Exitting Application");
            Environment.Exit(0);
        }
    }
}
