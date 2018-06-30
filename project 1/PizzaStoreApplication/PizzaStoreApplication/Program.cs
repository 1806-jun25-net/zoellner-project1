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
            Console.WriteLine("Welcome! Please enter a new username:");
            string Username = Console.ReadLine();

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

            Console.WriteLine("Excellent! We have all of your information!");
            logger.Info("Creating User object");

            User NewUser = new User(Username, First, Last, Phone, Email, Address, City);
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

        static void Main(string[] args)
        {
            logger.Info("Beginning application");
            User CurrentUser = new User();
            Location Reston;
            Location Herndon;
            Location Dulles;
            Location Hattontown;

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
                Input.ToLower();

                if(!Input.Equals("order") && !Input.Equals("exit"))
                {
                    Console.WriteLine("Please input an accepted command");
                    Console.WriteLine("Order: place a new order; Exit: exit the application");
                    Input = Console.ReadLine();
                    Input.ToLower();
                }
                else if (Input.Equals("order"))
                {

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
