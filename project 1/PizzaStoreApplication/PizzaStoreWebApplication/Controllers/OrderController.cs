using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStoreApplicationLibrary.Repos_and_Mapper;
using PizzaStoreWebApplication.Models;
using lib = PizzaStoreApplicationLibrary;

namespace PizzaStoreWebApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly lib.Project1PizzaApplicationContext _context;
        public OrderRepo Repo { get; }
        public LocationRepo locRepo { get; }
        public UserRepo userRepo { get; }

        public OrderController(OrderRepo repo)
        {
            Repo = repo;
        }
        // GET: Order
        public ActionResult Index(string user)
        {
            var libOrders = Repo.GetOrdersByUser(user);
            var webOrders = libOrders.Select(x => new Models.Order
            {
                OrderId = x.OrderId,
                OrderTime = x.OrderTime,
                Username = x.Username,
                FirstName = x.FirstName,
                TotalCost = x.TotalCost,
                StoreLocation = x.StoreLocation,
                NumPizzas = x.NumPizzas
            });
            return View(webOrders);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            var libOrder = Repo.GetSingleOrderById(id);
            var webOrder = new Models.Order
            {
                OrderId = libOrder.OrderId,
                OrderTime = libOrder.OrderTime,
                Username = libOrder.Username,
                FirstName = libOrder.FirstName,
                TotalCost = libOrder.TotalCost,
                StoreLocation = libOrder.StoreLocation,
                NumPizzas = libOrder.NumPizzas,
                Pizza1 = Repo.GetPizzaSizeAndTypeFromPizzaId(libOrder.PizzaNum1),
                Pizza2 = Repo.GetPizzaSizeAndTypeFromPizzaId(libOrder.PizzaNum2),
                Pizza3 = Repo.GetPizzaSizeAndTypeFromPizzaId(libOrder.PizzaNum3),
                Pizza4 = Repo.GetPizzaSizeAndTypeFromPizzaId(libOrder.PizzaNum4),
                Pizza5 = Repo.GetPizzaSizeAndTypeFromPizzaId(libOrder.PizzaNum5),
                Pizza6 = Repo.GetPizzaSizeAndTypeFromPizzaId(libOrder.PizzaNum6),
                Pizza7 = Repo.GetPizzaSizeAndTypeFromPizzaId(libOrder.PizzaNum7),
                Pizza8 = Repo.GetPizzaSizeAndTypeFromPizzaId(libOrder.PizzaNum8),
                Pizza9 = Repo.GetPizzaSizeAndTypeFromPizzaId(libOrder.PizzaNum9),
                Pizza10 = Repo.GetPizzaSizeAndTypeFromPizzaId(libOrder.PizzaNum10),
                Pizza11 = Repo.GetPizzaSizeAndTypeFromPizzaId(libOrder.PizzaNum11),
                Pizza12 = Repo.GetPizzaSizeAndTypeFromPizzaId(libOrder.PizzaNum12)
            };
            return View(webOrder);
        }

        // GET: Order/Create
        public ActionResult Create(string user)
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, string user)
        {
            try
            {
                lib.Order order;
                List<lib.Order> OrderHistory;
                lib.User CurrentUser = userRepo.GetUserByUsername(user);
                if (ModelState.IsValid)
                {
                    lib.Location location;
                    string loc = collection["Location"];
                    if(loc.ToLower().Equals("reston") || loc.ToLower().Equals("herndon") || 
                        loc.ToLower().Equals("hattontown") || loc.ToLower().Equals("dulles"))
                    {
                        lib.Order OrderToCheck = lib.Mapper.Map(Repo.GetOrdersByUser(user).First(o => o.StoreLocation.ToLower().Equals(loc.ToLower())));
                        DateTime CurrentTime = DateTime.Now;
                        if(OrderToCheck.OrderPlaced - CurrentTime >= TimeSpan.FromHours(2))
                        {
                            order = new lib.Order
                            {
                                OrderPlaced = DateTime.Now,
                                username = user,
                                name = CurrentUser.FirstName,

                            };
                        }
                    }
                }

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