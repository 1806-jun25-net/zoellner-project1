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

        public async static Task<IEnumerable<Object>> DeserializeLocationsAsync(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Object>));
            using(var memoryStream = new MemoryStream())
            {
                using (var fileStream = new FileStream(fileName, FileMode.Open))
                {
                    await fileStream.CopyToAsync(memoryStream);
                }
                memoryStream.Position = 0;
                return (List<Object>)serializer.Deserialize(memoryStream);
            }
        }

        public async static Task<List<User>> DeserializeUserObjectAsync(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<User>));
            using (var memoryStream = new MemoryStream())
            {
                using (var fileStream = new FileStream(fileName, FileMode.Open))
                {
                    await fileStream.CopyToAsync(memoryStream);
                }
                memoryStream.Position = 0;
                return (List<User>)serializer.Deserialize(memoryStream);
            }
        }

        public static void SerializeToFile(string fileName, User user)
        {
            var serializer = new XmlSerializer(typeof(List<Object>));
            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(fileName, FileMode.Create);
                serializer.Serialize(fileStream, user);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Exception occured during serialization: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected exception was thrown: {ex.Message}");
                throw;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Dispose();
                }
            }
        }

        public static void SerializeToFile(string fileName, List<Location> list)
        {
            var serializer = new XmlSerializer(typeof(List<Object>));
            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(fileName, FileMode.Create);
                serializer.Serialize(fileStream, list);
            }
            catch(IOException ex)
            {
                Console.WriteLine($"Exception occured during serialization: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Unexpected exception was thrown: {ex.Message}");
                throw;
            }
            finally
            {
                if(fileStream != null)
                {
                    fileStream.Dispose();
                }
            }
        }

        static void Main(string[] args)
        {
            logger.Info("Beginning application");
            
            User CurrentUser;

            List<Location> LocationsList = new List<Location>();
            Location Reston = new Location("Reston");
            Location Herndon = new Location("Herndon");
            Location Hattontown = new Location("Hattontown");
            Location Dulles = new Location("Dulles");
            LocationsList.Add(Reston);
            LocationsList.Add(Herndon);
            LocationsList.Add(Hattontown);
            LocationsList.Add(Dulles);

            if (File.Exists("locations.xml"))
            {
                var desList = DeserializeLocationsAsync("locations.xml");
                
                LocationsList.Clear();
                LocationsList = (List<Location>)desList.Result;
            }
            
            Console.WriteLine("Welcome! Please enter a username or enter 'new'");
            string Input = Console.ReadLine();
            IEnumerable<User> result = new List<User>();
            if (Input.Equals("new"))
            {
                logger.Info("Creating New User");
                User newUser = CreateNewUser();
                List<User> users = new List<User>();
                users.Add(newUser);
                result = users;
                logger.Info("New User Created");

            }
            else
            {
                var UserList = DeserializeUserObjectAsync("" + Input + ".xml");
                
                try
                {
                    result = UserList.Result;
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine("file wasn't found");
                }
            }
            

            bool KeepOpen = true;
            while (KeepOpen)
            {
                Console.Clear();
                Console.WriteLine("Welcome " + CurrentUser.FirstName);
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
            logger.Info("Beginning serialization of locations and user");
            SerializeToFile("locations.xml", LocationsList);
            SerializeToFile(CurrentUser.Username + ".xml", CurrentUser);
            logger.Info("Exitting Application");
            Environment.Exit(0);
        }
    }
}
