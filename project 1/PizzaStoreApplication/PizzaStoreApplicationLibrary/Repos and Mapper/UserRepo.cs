using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStoreApplicationLibrary.Repos_and_Mapper
{
    public class UserRepo
    {
        public readonly Project1PizzaApplicationContext _db;

        public UserRepo(Project1PizzaApplicationContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public User GetUser(string username)
        {
            User CurrentUser = new User();

            CurrentUser = _db.Find(, username)

            return CurrentUser;
        }
    }
}
