using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStoreApplicationLibrary.Repos_and_Mapper;
using lib = PizzaStoreApplicationLibrary;

namespace PizzaStoreWebApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly lib.Project1PizzaApplicationContext _context;
        public OrderRepo Repo { get; }

        public OrderController(OrderRepo repo)
        {
            Repo = repo;
        }
        // GET: Order
        public ActionResult Index()
        {
            var libOrders = Repo.GetOrders();
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

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
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

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
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