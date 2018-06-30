//Anthony Zoellner
//Project 1

using NLog;
using PizzaStoreApplicationLibrary;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PizzaStoreApplication
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static User CreateNewUser()
        {
            logger.Info("Begin CreateNewUser method");

            Console.WriteLine("Welcome to our Pizza Application! Please enter your first name:");
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

            User NewUser = new User(First, Last, Phone, Email, Address, City);
            logger.Info("Object Created");
            return NewUser;
        }

        public async static void DeserializeFile()
        {

        }

        static void Main(string[] args)
        {
            logger.Info("Beginning application");

            Console.WriteLine("Welcome! Please enter a username or enter 'new'");
            if (Console.ReadLine().Equals("new"))
            {
                logger.Info("Creating New User");
                CreateNewUser();
                logger.Info("New User Created");
            }

            else
            {
                try
                {

                }
                catch(Exception ex)
                {

                }
            }
            logger.Info("Exitting Application");
        }
    }
}
