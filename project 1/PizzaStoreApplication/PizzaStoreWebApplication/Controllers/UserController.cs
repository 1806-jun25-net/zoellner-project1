using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lib = PizzaStoreApplicationLibrary;
using PizzaStoreApplicationLibrary.Repos_and_Mapper;
using PizzaStoreWebApplication.Models;
using Lib = PizzaStoreApplicationLibrary;
using System.Data.SqlClient;

namespace PizzaStoreWebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly lib.Project1PizzaApplicationContext _context;
        public UserRepo Repo { get; }

        public UserController(UserRepo repo)
        {
            Repo = repo;
        }
        // GET: User
        public ActionResult Index()
        {
            var libUsers = Repo.GetUsers();
            var webUsers = libUsers.Select(x => new Models.User
            {
                Username = x.Username,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                Email = x.EmailAddress,
                Address = x.PhysicalAddress,
                PepperoniOrdered = x.NumPepperoniOrdered,
                CheeseOrdered = x.NumCheeseOrdered,
                MeatOrdered = x.NumMeatOrdered,
                VeggieOrdered = x.NumVeggieOrdered,
                FavoritePizza = x.RecommendedPizza,
                Favorite = x.DefaultLocation
            });
            return View(webUsers);
        }

        // GET: User/Details/5
        public ActionResult Details(string username)
        {
            var libUser = Repo.GetUserByUsername(username);
            var webUser = new User
            {
                Username = libUser.Username,
                FirstName = libUser.FirstName,
                LastName = libUser.LastName,
                Email = libUser.Email,
                PhoneNumber = libUser.PhoneNumber,
                Address = libUser.Address,
                Favorite = libUser.Favorite,
                FavoritePizza = libUser.FavoritePizza,
                CheeseOrdered = libUser.CheeseOrdered,
                PepperoniOrdered = libUser.PepperoniOrdered,
                MeatOrdered = libUser.MeatOrdered,
                VeggieOrdered = libUser.VeggieOrdered
            };
            return View(webUser);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                lib.User user;
                if (ModelState.IsValid)
                {
                    user = new lib.User
                    {
                        Username = collection["Username"],
                        FirstName = collection["FirstName"],
                        LastName = collection["LastName"],
                        Email = collection["Email"],
                        PhoneNumber = collection["PhoneNumber"],
                        Address = collection["Address"],
                        Favorite = collection["Favorite"]
                    };

                    Repo.AddUser(user);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                ModelState.AddModelError("Username", "Username is already taken. Please select another username.");
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}