using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PizzaStoreApplication;

namespace PizzaStoreApplicationLibrary.Repos_and_Mapper
{
    public class UserRepo
    {
        public readonly Project1PizzaApplicationContext _db;

        public UserRepo(Project1PizzaApplicationContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<Users> GetUsers()
        {
            List<Users> UserList = _db.Users.AsNoTracking().ToList();
            return UserList;
        }

        public void AddUser(string username, string First, string Last, string Phone, string email, string FavoriteLocation, string Address)
        {
            var NewUser = new Users
            {
                Username = username,
                FirstName = First,
                LastName = Last,
                PhoneNumber = Phone,
                EmailAddress = email,
                DefaultLocation = FavoriteLocation,
                PhysicalAddress = Address,
                RecommendedPizza = "Cheese"
            };

            _db.Add(NewUser);
            _db.SaveChanges();
        }

        public void UpdateUser(Users user)
        {
            _db.Update(user);
            _db.SaveChanges();
        }
    }
}
