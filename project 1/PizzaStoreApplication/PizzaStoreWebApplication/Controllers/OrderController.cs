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
        public LocationRepo LocRepo { get; }
        public UserRepo UserRepo { get; }

        public OrderController(OrderRepo repo, UserRepo userRepo, LocationRepo locationRepo)
        {
            Repo = repo;
            UserRepo = userRepo;
            LocRepo = locationRepo;
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
            lib.User newUser = UserRepo.GetUserByUsername(user);
            return View(new Order { Username = user, FirstName = newUser.FirstName});
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order webOrder)
        {
            try
            {
                lib.Orders order;
                if (ModelState.IsValid)
                {
                    string loc = webOrder.StoreLocation;
                    lib.Location location = LocRepo.GetLocationByCityname(loc);
                    if (loc.ToLower().Equals("reston") || loc.ToLower().Equals("herndon") ||
                        loc.ToLower().Equals("hattontown") || loc.ToLower().Equals("dulles"))
                    {
                        if(Repo.GetOrdersByUser(webOrder.Username).LastOrDefault(o => o.StoreLocation.ToLower().Equals(loc.ToLower())) == null)
                        {
                            location.DecreaseInventory(webOrder.PizzaNum1);
                            location.DecreaseInventory(webOrder.PizzaNum2);
                            location.DecreaseInventory(webOrder.PizzaNum3);
                            location.DecreaseInventory(webOrder.PizzaNum4);
                            location.DecreaseInventory(webOrder.PizzaNum5);
                            location.DecreaseInventory(webOrder.PizzaNum6);
                            location.DecreaseInventory(webOrder.PizzaNum7);
                            location.DecreaseInventory(webOrder.PizzaNum8);
                            location.DecreaseInventory(webOrder.PizzaNum9);
                            location.DecreaseInventory(webOrder.PizzaNum10);
                            location.DecreaseInventory(webOrder.PizzaNum11);
                            location.DecreaseInventory(webOrder.PizzaNum12);

                            int TotalPizzas = 1;
                            if (webOrder.PizzaNum2 > 1)
                            {
                                TotalPizzas++;
                            }
                            if (webOrder.PizzaNum3 > 1)
                            {
                                TotalPizzas++;
                            }
                            if (webOrder.PizzaNum4 > 1)
                            {
                                TotalPizzas++;
                            }
                            if (webOrder.PizzaNum5 > 1)
                            {
                                TotalPizzas++;
                            }
                            if (webOrder.PizzaNum6 > 1)
                            {
                                TotalPizzas++;
                            }
                            if (webOrder.PizzaNum7 > 1)
                            {
                                TotalPizzas++;
                            }
                            if (webOrder.PizzaNum8 > 1)
                            {
                                TotalPizzas++;
                            }
                            if (webOrder.PizzaNum9 > 1)
                            {
                                TotalPizzas++;
                            }
                            if (webOrder.PizzaNum10 > 1)
                            {
                                TotalPizzas++;
                            }
                            if (webOrder.PizzaNum11 > 1)
                            {
                                TotalPizzas++;
                            }
                            if (webOrder.PizzaNum12 > 1)
                            {
                                TotalPizzas++;
                            }
                            order = new lib.Orders
                            {
                                NumPizzas = TotalPizzas,
                                OrderTime = DateTime.Now,
                                Username = webOrder.Username,
                                FirstName = webOrder.FirstName,
                                PizzaNum1 = webOrder.PizzaNum1,
                                PizzaNum2 = webOrder.PizzaNum2,
                                PizzaNum3 = webOrder.PizzaNum3,
                                PizzaNum4 = webOrder.PizzaNum4,
                                PizzaNum5 = webOrder.PizzaNum5,
                                PizzaNum6 = webOrder.PizzaNum6,
                                PizzaNum7 = webOrder.PizzaNum7,
                                PizzaNum8 = webOrder.PizzaNum8,
                                PizzaNum9 = webOrder.PizzaNum9,
                                PizzaNum10 = webOrder.PizzaNum10,
                                PizzaNum11 = webOrder.PizzaNum11,
                                PizzaNum12 = webOrder.PizzaNum12,
                                TotalCost = (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum1)
                                            + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum2))
                                            + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum3))
                                            + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum4))
                                            + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum5))
                                            + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum6))
                                            + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum7))
                                            + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum8))
                                            + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum9))
                                            + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum10))
                                            + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum11))
                                            + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum12))),
                                StoreLocation = loc
                            };
                            LocRepo.EditLocation(lib.Mapper.Map(location));
                            Repo.AddOrder(order);
                            TempData["SuccessMessage"] = "Order successfully placed!";
                            return RedirectToAction("Index", "User");
                        }
                        else { 
                            lib.Order OrderToCheck = lib.Mapper.Map(Repo.GetOrdersByUser(webOrder.Username).LastOrDefault(o => o.StoreLocation.ToLower().Equals(loc.ToLower())));
                            DateTime CurrentTime = DateTime.Now;
                            if ((CurrentTime - OrderToCheck.OrderPlaced) >= TimeSpan.FromHours(2))
                            {
                                location.DecreaseInventory(webOrder.PizzaNum1);
                                location.DecreaseInventory(webOrder.PizzaNum2);
                                location.DecreaseInventory(webOrder.PizzaNum3);
                                location.DecreaseInventory(webOrder.PizzaNum4);
                                location.DecreaseInventory(webOrder.PizzaNum5);
                                location.DecreaseInventory(webOrder.PizzaNum6);
                                location.DecreaseInventory(webOrder.PizzaNum7);
                                location.DecreaseInventory(webOrder.PizzaNum8);
                                location.DecreaseInventory(webOrder.PizzaNum9);
                                location.DecreaseInventory(webOrder.PizzaNum10);
                                location.DecreaseInventory(webOrder.PizzaNum11);
                                location.DecreaseInventory(webOrder.PizzaNum12);

                                int TotalPizzas = 1;
                                if (webOrder.PizzaNum2 > 1)
                                {
                                    TotalPizzas++;
                                }
                                if (webOrder.PizzaNum3 > 1)
                                {
                                    TotalPizzas++;
                                }
                                if (webOrder.PizzaNum4 > 1)
                                {
                                    TotalPizzas++;
                                }
                                if (webOrder.PizzaNum5 > 1)
                                {
                                    TotalPizzas++;
                                }
                                if (webOrder.PizzaNum6 > 1)
                                {
                                    TotalPizzas++;
                                }
                                if (webOrder.PizzaNum7 > 1)
                                {
                                    TotalPizzas++;
                                }
                                if (webOrder.PizzaNum8 > 1)
                                {
                                    TotalPizzas++;
                                }
                                if (webOrder.PizzaNum9 > 1)
                                {
                                    TotalPizzas++;
                                }
                                if (webOrder.PizzaNum10 > 1)
                                {
                                    TotalPizzas++;
                                }
                                if (webOrder.PizzaNum11 > 1)
                                {
                                    TotalPizzas++;
                                }
                                if (webOrder.PizzaNum12 > 1)
                                {
                                    TotalPizzas++;
                                }
                                order = new lib.Orders
                                {
                                    NumPizzas = TotalPizzas,
                                    OrderTime = DateTime.Now,
                                    Username = webOrder.Username,
                                    FirstName = webOrder.FirstName,
                                    PizzaNum1 = webOrder.PizzaNum1,
                                    PizzaNum2 = webOrder.PizzaNum2,
                                    PizzaNum3 = webOrder.PizzaNum3,
                                    PizzaNum4 = webOrder.PizzaNum4,
                                    PizzaNum5 = webOrder.PizzaNum5,
                                    PizzaNum6 = webOrder.PizzaNum6,
                                    PizzaNum7 = webOrder.PizzaNum7,
                                    PizzaNum8 = webOrder.PizzaNum8,
                                    PizzaNum9 = webOrder.PizzaNum9,
                                    PizzaNum10 = webOrder.PizzaNum10,
                                    PizzaNum11 = webOrder.PizzaNum11,
                                    PizzaNum12 = webOrder.PizzaNum12,
                                    TotalCost = (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum1)
                                                + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum2))
                                                + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum3))
                                                + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum4))
                                                + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum5))
                                                + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum6))
                                                + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum7))
                                                + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum8))
                                                + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum9))
                                                + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum10))
                                                + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum11))
                                                + (Repo.GetPriceOfPizzaFromId(webOrder.PizzaNum12))),
                                    StoreLocation = loc
                                };
                                LocRepo.EditLocation(lib.Mapper.Map(location));
                                Repo.AddOrder(order);
                                TempData["SuccessMessage"] = "Order successfully placed!";
                                return RedirectToAction("Index", "User");
                            }
                            else
                            {
                                TempData["ErrorMessage"] = "Error: You have ordered from " + location.Name + " less than 2 hours ago." +
                                    "Either select a new location or wait 2 hours.";
                                return View();
                            }
                        }
                    }
                    TempData["ErrorMessage"] = "Please select a valid location: Reston, Herndon, Hattontown, or Dulles.";
                    return View();

                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
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