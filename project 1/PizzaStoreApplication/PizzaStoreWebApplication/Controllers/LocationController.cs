using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStoreApplicationLibrary.Repos_and_Mapper;
using PizzaStoreWebApplication.Models;
using Lib = PizzaStoreApplicationLibrary;


namespace PizzaStoreWebApplication.Controllers
{
    public class LocationController : Controller
    {
        private readonly Lib.Project1PizzaApplicationContext _context;
        public LocationRepo Repo { get; }

        public LocationController(LocationRepo repo)
        {
            Repo = repo;
        }
        // GET: Location
        public ActionResult Index()
        {
            var libLoc = Repo.GetLocations();
            var webLoc = libLoc.Select(x => new Models.Location
            {
                Name = x.CityName,
                DoughRemaining = x.DoughRemaining,
                SauceRemaining = x.SauceRemaining,
                CheeseRemaining = x.CheeseRemaining,
                PepperoniRemaining = x.PepperoniRemaining,
                MeatRemaining = x.MeatRemaining,
                VeggiesRemaining = x.VeggiesRemaining
            });
            return View(webLoc);
        }

        // GET: Location/Details/5
        public ActionResult Details(string name)
        {
            var libLoc = Repo.GetLocationByCityname(name);
            var webLoc = new Location
            {
                Name = libLoc.Name,
                DoughRemaining = libLoc.Dough,
                SauceRemaining = libLoc.Sauce,
                CheeseRemaining = libLoc.Cheese,
                PepperoniRemaining = libLoc.Pepperoni,
                MeatRemaining = libLoc.HamAndMeatball,
                VeggiesRemaining = libLoc.PeppersAndOnions
            };

            return View(webLoc);
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
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

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Location/Edit/5
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

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Location/Delete/5
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