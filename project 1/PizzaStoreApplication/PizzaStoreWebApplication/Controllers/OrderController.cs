using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public ActionResult Index(string user, string sortOrder)
        {
            if(user == null && TempData["User"] != null)
            {
                user = (string)TempData["User"];
            }
            ViewBag.TimeSortParm = String.IsNullOrEmpty(sortOrder) ? "time_desc" : "";
            ViewBag.CostSortParm = sortOrder == "Cost" ? "cost_desc" : "Cost";

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

            switch (sortOrder)
            {
                case "time_desc":
                    webOrders = webOrders.OrderByDescending(o => o.OrderTime);
                    break;
                case "Cost":
                    webOrders = webOrders.OrderBy(o => o.TotalCost);
                    break;
                case "cost_desc":
                    webOrders = webOrders.OrderByDescending(o => o.TotalCost);
                    break;
            }
            TempData["User"] = user;
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
            TempData["FavoriteLocation"] = "Your favorite location is " + newUser.Favorite;
            TempData["Recommend"] = "We recommend ordering " + newUser.FavoritePizza;

            List<SelectListItem> locations = new List<SelectListItem>();
            SelectListItem chooseLocation = new SelectListItem() { Text = "Choose A Location", Value = null, Selected = true };
            SelectListItem reston = new SelectListItem() { Text = "Reston", Value = "reston", Selected = false };
            SelectListItem herndon = new SelectListItem() { Text = "Herndon", Value = "herndon", Selected = false };
            SelectListItem dulles = new SelectListItem() { Text = "Dulles", Value = "dulles", Selected = false };
            SelectListItem hattontown = new SelectListItem() { Text = "Hattontown", Value = "hattontown", Selected = false };
            locations.Add(chooseLocation);
            locations.Add(reston);
            locations.Add(herndon);
            locations.Add(dulles);
            locations.Add(hattontown);

            List<SelectListItem> pizza1 = new List<SelectListItem>();
            SelectListItem smallCheese = new SelectListItem() { Text = "Small Cheese - $8.00", Value = "2", Selected = true };
            SelectListItem medCheese = new SelectListItem() { Text = "Medium Cheese - $9.00", Value = "3", Selected = false };
            SelectListItem largeCheese = new SelectListItem() { Text = "Large Cheese - $12.00", Value = "4", Selected = false };
            SelectListItem smallPepperoni = new SelectListItem() { Text = "Small Pepperoni - $9.00", Value = "5", Selected = false };
            SelectListItem medPepperoni = new SelectListItem() { Text = "Medium Pepperoni - $12.00", Value = "6", Selected = false };
            SelectListItem largePepperoni = new SelectListItem() { Text = "Large Pepperoni - $15.00", Value = "7", Selected = false };
            SelectListItem smallMeat = new SelectListItem() { Text = "Small Meat - $11.00", Value = "8", Selected = false };
            SelectListItem medMeat = new SelectListItem() { Text = "Medium Meat - $14.00", Value = "9", Selected = false };
            SelectListItem largeMeat = new SelectListItem() { Text = "Large Meat - $17.00", Value = "10", Selected = false };
            SelectListItem smallVeg = new SelectListItem() { Text = "Small Veggie - $11.00", Value = "11", Selected = false };
            SelectListItem medVeg = new SelectListItem() { Text = "Medium Veggie - $14.00", Value = "12", Selected = false };
            SelectListItem largeVeg = new SelectListItem() { Text = "Large Veggie - $17.00", Value = "13", Selected = false };
            pizza1.Add(smallCheese);
            pizza1.Add(medCheese);
            pizza1.Add(largeCheese);
            pizza1.Add(smallPepperoni);
            pizza1.Add(medPepperoni);
            pizza1.Add(largePepperoni);
            pizza1.Add(smallMeat);
            pizza1.Add(medMeat);
            pizza1.Add(largeMeat);
            pizza1.Add(smallVeg);
            pizza1.Add(medVeg);
            pizza1.Add(largeVeg);

            List<SelectListItem> pizza2 = new List<SelectListItem>();
            SelectListItem none = new SelectListItem() { Text = "None", Value = "1", Selected = true };
            SelectListItem otherSmallCheese = new SelectListItem() { Text = "Small Cheese - $8.00", Value = "2", Selected = false };
            pizza2.Add(none);
            pizza2.Add(otherSmallCheese);
            pizza2.Add(medCheese);
            pizza2.Add(largeCheese);
            pizza2.Add(smallPepperoni);
            pizza2.Add(medPepperoni);
            pizza2.Add(largePepperoni);
            pizza2.Add(smallMeat);
            pizza2.Add(medMeat);
            pizza2.Add(largeMeat);
            pizza2.Add(smallVeg);
            pizza2.Add(medVeg);
            pizza2.Add(largeVeg);

            List<SelectListItem> pizza3 = new List<SelectListItem>();
            pizza3.Add(none);
            pizza3.Add(otherSmallCheese);
            pizza3.Add(medCheese);
            pizza3.Add(largeCheese);
            pizza3.Add(smallPepperoni);
            pizza3.Add(medPepperoni);
            pizza3.Add(largePepperoni);
            pizza3.Add(smallMeat);
            pizza3.Add(medMeat);
            pizza3.Add(largeMeat);
            pizza3.Add(smallVeg);
            pizza3.Add(medVeg);
            pizza3.Add(largeVeg);

            List<SelectListItem> pizza4 = new List<SelectListItem>();
            pizza4.Add(none);
            pizza4.Add(otherSmallCheese);
            pizza4.Add(medCheese);
            pizza4.Add(largeCheese);
            pizza4.Add(smallPepperoni);
            pizza4.Add(medPepperoni);
            pizza4.Add(largePepperoni);
            pizza4.Add(smallMeat);
            pizza4.Add(medMeat);
            pizza4.Add(largeMeat);
            pizza4.Add(smallVeg);
            pizza4.Add(medVeg);
            pizza4.Add(largeVeg);

            List<SelectListItem> pizza5 = new List<SelectListItem>();
            pizza5.Add(none);
            pizza5.Add(otherSmallCheese);
            pizza5.Add(medCheese);
            pizza5.Add(largeCheese);
            pizza5.Add(smallPepperoni);
            pizza5.Add(medPepperoni);
            pizza5.Add(largePepperoni);
            pizza5.Add(smallMeat);
            pizza5.Add(medMeat);
            pizza5.Add(largeMeat);
            pizza5.Add(smallVeg);
            pizza5.Add(medVeg);
            pizza5.Add(largeVeg);

            List<SelectListItem> pizza6 = new List<SelectListItem>();
            pizza6.Add(none);
            pizza6.Add(otherSmallCheese);
            pizza6.Add(medCheese);
            pizza6.Add(largeCheese);
            pizza6.Add(smallPepperoni);
            pizza6.Add(medPepperoni);
            pizza6.Add(largePepperoni);
            pizza6.Add(smallMeat);
            pizza6.Add(medMeat);
            pizza6.Add(largeMeat);
            pizza6.Add(smallVeg);
            pizza6.Add(medVeg);
            pizza6.Add(largeVeg);

            List<SelectListItem> pizza7 = new List<SelectListItem>();
            pizza7.Add(none);
            pizza7.Add(otherSmallCheese);
            pizza7.Add(medCheese);
            pizza7.Add(largeCheese);
            pizza7.Add(smallPepperoni);
            pizza7.Add(medPepperoni);
            pizza7.Add(largePepperoni);
            pizza7.Add(smallMeat);
            pizza7.Add(medMeat);
            pizza7.Add(largeMeat);
            pizza7.Add(smallVeg);
            pizza7.Add(medVeg);
            pizza7.Add(largeVeg);

            List<SelectListItem> pizza8 = new List<SelectListItem>();
            pizza8.Add(none);
            pizza8.Add(otherSmallCheese);
            pizza8.Add(medCheese);
            pizza8.Add(largeCheese);
            pizza8.Add(smallPepperoni);
            pizza8.Add(medPepperoni);
            pizza8.Add(largePepperoni);
            pizza8.Add(smallMeat);
            pizza8.Add(medMeat);
            pizza8.Add(largeMeat);
            pizza8.Add(smallVeg);
            pizza8.Add(medVeg);
            pizza8.Add(largeVeg);

            List<SelectListItem> pizza9 = new List<SelectListItem>();
            pizza9.Add(none);
            pizza9.Add(otherSmallCheese);
            pizza9.Add(medCheese);
            pizza9.Add(largeCheese);
            pizza9.Add(smallPepperoni);
            pizza9.Add(medPepperoni);
            pizza9.Add(largePepperoni);
            pizza9.Add(smallMeat);
            pizza9.Add(medMeat);
            pizza9.Add(largeMeat);
            pizza9.Add(smallVeg);
            pizza9.Add(medVeg);
            pizza9.Add(largeVeg);

            List<SelectListItem> pizza10 = new List<SelectListItem>();
            pizza10.Add(none);
            pizza10.Add(otherSmallCheese);
            pizza10.Add(medCheese);
            pizza10.Add(largeCheese);
            pizza10.Add(smallPepperoni);
            pizza10.Add(medPepperoni);
            pizza10.Add(largePepperoni);
            pizza10.Add(smallMeat);
            pizza10.Add(medMeat);
            pizza10.Add(largeMeat);
            pizza10.Add(smallVeg);
            pizza10.Add(medVeg);
            pizza10.Add(largeVeg);

            List<SelectListItem> pizza11 = new List<SelectListItem>();
            pizza11.Add(none);
            pizza11.Add(otherSmallCheese);
            pizza11.Add(medCheese);
            pizza11.Add(largeCheese);
            pizza11.Add(smallPepperoni);
            pizza11.Add(medPepperoni);
            pizza11.Add(largePepperoni);
            pizza11.Add(smallMeat);
            pizza11.Add(medMeat);
            pizza11.Add(largeMeat);
            pizza11.Add(smallVeg);
            pizza11.Add(medVeg);
            pizza11.Add(largeVeg);

            List<SelectListItem> pizza12 = new List<SelectListItem>();
            pizza12.Add(none);
            pizza12.Add(otherSmallCheese);
            pizza12.Add(medCheese);
            pizza12.Add(largeCheese);
            pizza12.Add(smallPepperoni);
            pizza12.Add(medPepperoni);
            pizza12.Add(largePepperoni);
            pizza12.Add(smallMeat);
            pizza12.Add(medMeat);
            pizza12.Add(largeMeat);
            pizza12.Add(smallVeg);
            pizza12.Add(medVeg);
            pizza12.Add(largeVeg);

            ViewBag.Locations = locations;
            ViewBag.Pizza1 = pizza1;
            ViewBag.Pizza2 = pizza2;
            ViewBag.Pizza3 = pizza3;
            ViewBag.Pizza4 = pizza4;
            ViewBag.Pizza5 = pizza5;
            ViewBag.Pizza6 = pizza6;
            ViewBag.Pizza7 = pizza7;
            ViewBag.Pizza8 = pizza8;
            ViewBag.Pizza9 = pizza9;
            ViewBag.Pizza10 = pizza10;
            ViewBag.Pizza11 = pizza11;
            ViewBag.Pizza12 = pizza12;

            return View(new Order { Username = user, FirstName = newUser.FirstName});
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order webOrder, string Locations, string Pizza1, string Pizza2, string Pizza3, string Pizza4, string Pizza5,
            string Pizza6, string Pizza7, string Pizza8, string Pizza9, string Pizza10, string Pizza11, string Pizza12)
        {
            try
            {

                lib.User CurrentUser = UserRepo.GetUserByUsername(webOrder.Username);
                lib.Orders order;
                if (ModelState.IsValid)
                {
                    string loc = Locations;
                    lib.Location location = LocRepo.GetLocationByCityname(loc);
                    if (loc.ToLower().Equals("reston") || loc.ToLower().Equals("herndon") ||
                        loc.ToLower().Equals("hattontown") || loc.ToLower().Equals("dulles"))
                    {
                        if(Repo.GetOrdersByUser(webOrder.Username).LastOrDefault(o => o.StoreLocation.ToLower().Equals(loc.ToLower())) == null)
                        {
                            location.DecreaseInventory(int.Parse(Pizza1));
                            location.DecreaseInventory(int.Parse(Pizza2));
                            location.DecreaseInventory(int.Parse(Pizza3));
                            location.DecreaseInventory(int.Parse(Pizza4));
                            location.DecreaseInventory(int.Parse(Pizza5));
                            location.DecreaseInventory(int.Parse(Pizza6));
                            location.DecreaseInventory(int.Parse(Pizza7));
                            location.DecreaseInventory(int.Parse(Pizza8));
                            location.DecreaseInventory(int.Parse(Pizza9));
                            location.DecreaseInventory(int.Parse(Pizza10));
                            location.DecreaseInventory(int.Parse(Pizza11));
                            location.DecreaseInventory(int.Parse(Pizza12));

                            decimal total = (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza1))
                                            + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza2)))
                                            + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza3)))
                                            + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza4)))
                                            + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza5)))
                                            + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza6)))
                                            + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza7)))
                                            + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza8)))
                                            + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza9)))
                                            + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza10)))
                                            + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza11)))
                                            + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza12))));
                            if (total < 500)
                            {
                                int TotalPizzas = 1;
                                if (int.Parse(Pizza2) > 1)
                                {
                                    TotalPizzas++;
                                }
                                if (int.Parse(Pizza3) > 1)
                                {
                                    TotalPizzas++;
                                }
                                if (int.Parse(Pizza4) > 1)
                                {
                                    TotalPizzas++;
                                }
                                if (int.Parse(Pizza5) > 1)
                                {
                                    TotalPizzas++;
                                }
                                if (int.Parse(Pizza6) > 1)
                                {
                                    TotalPizzas++;
                                }
                                if (int.Parse(Pizza7) > 1)
                                {
                                    TotalPizzas++;
                                }
                                if (int.Parse(Pizza8) > 1)
                                {
                                    TotalPizzas++;
                                }
                                if (int.Parse(Pizza9) > 1)
                                {
                                    TotalPizzas++;
                                }
                                if (int.Parse(Pizza10) > 1)
                                {
                                    TotalPizzas++;
                                }
                                if (int.Parse(Pizza11) > 1)
                                {
                                    TotalPizzas++;
                                }
                                if (int.Parse(Pizza12) > 1)
                                {
                                    TotalPizzas++;
                                }
                                order = new lib.Orders
                                {
                                    NumPizzas = TotalPizzas,
                                    OrderTime = DateTime.Now,
                                    Username = webOrder.Username,
                                    FirstName = webOrder.FirstName,
                                    PizzaNum1 = int.Parse(Pizza1),
                                    PizzaNum2 = int.Parse(Pizza2),
                                    PizzaNum3 = int.Parse(Pizza3),
                                    PizzaNum4 = int.Parse(Pizza4),
                                    PizzaNum5 = int.Parse(Pizza5),
                                    PizzaNum6 = int.Parse(Pizza6),
                                    PizzaNum7 = int.Parse(Pizza7),
                                    PizzaNum8 = int.Parse(Pizza8),
                                    PizzaNum9 = int.Parse(Pizza9),
                                    PizzaNum10 = int.Parse(Pizza10),
                                    PizzaNum11 = int.Parse(Pizza11),
                                    PizzaNum12 = int.Parse(Pizza12),
                                    TotalCost = total,
                                    StoreLocation = loc
                                };
                                CurrentUser.UserFavoritePizza(order);
                                UserRepo.UpdateUser(lib.Mapper.Map(CurrentUser));

                                LocRepo.EditLocation(lib.Mapper.Map(location));

                                Repo.AddOrder(order);
                                TempData["SuccessMessage"] = "Order successfully placed!";
                                return RedirectToAction("Index", "User");
                            }
                            else
                            {
                                TempData["ErrorMessage"] = "Error: Cost is over the $500 limit. Please adjust order to meet limit.";
                                return View(webOrder.Username);
                            }
                        }
                        else { 
                            lib.Order OrderToCheck = lib.Mapper.Map(Repo.GetOrdersByUser(webOrder.Username).LastOrDefault(o => o.StoreLocation.ToLower().Equals(loc.ToLower())));
                            DateTime CurrentTime = DateTime.Now;
                            if ((CurrentTime - OrderToCheck.OrderPlaced) >= TimeSpan.FromHours(2))
                            {
                                location.DecreaseInventory(int.Parse(Pizza1));
                                location.DecreaseInventory(int.Parse(Pizza2));
                                location.DecreaseInventory(int.Parse(Pizza3));
                                location.DecreaseInventory(int.Parse(Pizza4));
                                location.DecreaseInventory(int.Parse(Pizza5));
                                location.DecreaseInventory(int.Parse(Pizza6));
                                location.DecreaseInventory(int.Parse(Pizza7));
                                location.DecreaseInventory(int.Parse(Pizza8));
                                location.DecreaseInventory(int.Parse(Pizza9));
                                location.DecreaseInventory(int.Parse(Pizza10));
                                location.DecreaseInventory(int.Parse(Pizza11));
                                location.DecreaseInventory(int.Parse(Pizza12));

                                decimal total = (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza1))
                                                + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza2)))
                                                + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza3)))
                                                + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza4)))
                                                + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza5)))
                                                + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza6)))
                                                + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza7)))
                                                + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza8)))
                                                + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza9)))
                                                + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza10)))
                                                + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza11)))
                                                + (Repo.GetPriceOfPizzaFromId(int.Parse(Pizza12))));
                                if (total < 500)
                                {
                                    int TotalPizzas = 1;
                                    if (int.Parse(Pizza2) > 1)
                                    {
                                        TotalPizzas++;
                                    }
                                    if (int.Parse(Pizza3) > 1)
                                    {
                                        TotalPizzas++;
                                    }
                                    if (int.Parse(Pizza4) > 1)
                                    {
                                        TotalPizzas++;
                                    }
                                    if (int.Parse(Pizza5) > 1)
                                    {
                                        TotalPizzas++;
                                    }
                                    if (int.Parse(Pizza6) > 1)
                                    {
                                        TotalPizzas++;
                                    }
                                    if (int.Parse(Pizza7) > 1)
                                    {
                                        TotalPizzas++;
                                    }
                                    if (int.Parse(Pizza8) > 1)
                                    {
                                        TotalPizzas++;
                                    }
                                    if (int.Parse(Pizza9) > 1)
                                    {
                                        TotalPizzas++;
                                    }
                                    if (int.Parse(Pizza10) > 1)
                                    {
                                        TotalPizzas++;
                                    }
                                    if (int.Parse(Pizza11) > 1)
                                    {
                                        TotalPizzas++;
                                    }
                                    if (int.Parse(Pizza12) > 1)
                                    {
                                        TotalPizzas++;
                                    }
                                    order = new lib.Orders
                                    {
                                        NumPizzas = TotalPizzas,
                                        OrderTime = DateTime.Now,
                                        Username = webOrder.Username,
                                        FirstName = webOrder.FirstName,
                                        PizzaNum1 = int.Parse(Pizza1),
                                        PizzaNum2 = int.Parse(Pizza2),
                                        PizzaNum3 = int.Parse(Pizza3),
                                        PizzaNum4 = int.Parse(Pizza4),
                                        PizzaNum5 = int.Parse(Pizza5),
                                        PizzaNum6 = int.Parse(Pizza6),
                                        PizzaNum7 = int.Parse(Pizza7),
                                        PizzaNum8 = int.Parse(Pizza8),
                                        PizzaNum9 = int.Parse(Pizza9),
                                        PizzaNum10 = int.Parse(Pizza10),
                                        PizzaNum11 = int.Parse(Pizza11),
                                        PizzaNum12 = int.Parse(Pizza12),
                                        TotalCost = total,
                                        StoreLocation = loc
                                    };
                                    CurrentUser.UserFavoritePizza(order);
                                    UserRepo.UpdateUser(lib.Mapper.Map(CurrentUser));

                                    LocRepo.EditLocation(lib.Mapper.Map(location));

                                    Repo.AddOrder(order);
                                    TempData["SuccessMessage"] = "Order successfully placed!";
                                    return RedirectToAction("Index", "User");
                                }
                                else
                                {
                                    TempData["ErrorMessage"] = "Error: Cost is over the $500 limit. Please adjust order to meet limit.";
                                    return View(webOrder.Username);
                                }
                            }
                            else
                            {
                                TempData["ErrorMessage"] = "Error: You have ordered from " + location.Name + " less than 2 hours ago." +
                                    "Either select a new location or wait 2 hours.";
                                return View(webOrder.Username);
                            }
                        }
                    }
                    TempData["ErrorMessage"] = "Please select a valid location: Reston, Herndon, Hattontown, or Dulles.";
                    return View(webOrder.Username);
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