using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lib = PizzaStoreApplicationLibrary;
using PizzaStoreApplicationLibrary.Repos_and_Mapper;
using PizzaStoreWebApplication.Models;

namespace PizzaStoreWebApplication.Controllers
{
    public class UserController : Controller
    {
        public UserRepo Repo { get; }

        public UserController(UserRepo repo)
        {
            Repo = repo;
        }
        // GET: User
        public ActionResult Index()
        {
            var libUsers = Repo.GetUsers();
            var webUsers = libUsers.Select(x => new User
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
        public ActionResult Details(int id)
        {
            return View();
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
                User user;
                if (ModelState.IsValid)
                {
                    user = new User();
                    user.Username = collection["Username"];
                    user.FirstName = collection["FirstName"];
                    user.LastName = collection["LastName"];
                    user.Email = collection["Email"];
                    user.PhoneNumber = collection["PhoneNumber"];
                    return RedirectToAction(nameof(Index));
                }
                return View();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
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