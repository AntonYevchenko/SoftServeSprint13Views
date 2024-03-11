using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ViewTask.Models;
using static System.Net.WebRequestMethods;

namespace ViewTask.Controllers
{
    [Route("Tasks")]
    public class TasksController : Controller
    {
        private readonly ILogger<TasksController> _logger;

        private List<Supermarket> SupermarketsList;
        private List<Product> ShoppingListElements;

        public TasksController(ILogger<TasksController> logger)
        {
            _logger = logger;

            SupermarketsList = new List<Supermarket>()
            {
                new("WellMart", "https://wellamart.ua/"),
                new("Silpo",    "https://silpo.ua/"),
                new("ATB",      "https://www.atbmarket.com/"),
                new("Auchan",   "https://auchan.ua/ua/"),
                new("Metro",    "https://www.metro.ua/"),
            };
            
            ShoppingListElements = new List<Product>()
            {
                new("Milk",      count:2),
                new("Bread",     count:2),
                new("Cake",      count: 1),
                new("Ice Cream", count: 5),
                new("Cola",      count: 10)
            };

        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("SprintTasks")]
        public IActionResult SprintTasks()
        {
            return View();
        }

        [Route("Greetings")]
        public IActionResult Greetings()
        {
            ViewData["myMessage"] = "Hello C# Marathon!";
            ViewData["greeting"] = "Welcome to our project!";
            return View();
        }

        [Route("Products")]
        public IActionResult Products()
        {
            List<Product> products = new List<Product>() { new Product("Bread", 10),
                                                           new Product("Milk", 11),
                                                           new Product("Cheese", 140),
                                                           new Product("Sausage", 110),
                                                           new Product("Potato", 7),
                                                           new Product("Banana",23),
                                                           new Product("Tomato",25),
                                                           new Product("Candy",75) };
            return View(products);
        }

        [Route("Supermarkets")]
        public IActionResult Supermarkets()
        {
            return View(SupermarketsList);
        }

        [Route("ShoppingList")]
        public IActionResult ShoppingList()
        {
            return View(ShoppingListElements);
        }

        public IActionResult GetTimeToBuy()
        {
            return PartialView("_TimeToBuy");
        }

        [HttpGet]
        [Route("ShoppingCart")]
        public IActionResult ShoppingCart()
        {
            List<SelectListItem> supermarketsSelectListItems = new List<SelectListItem>();
            foreach (Supermarket supermarket in SupermarketsList)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = supermarket.Name,
                    Selected = false
                };
                supermarketsSelectListItems.Add(selectList);
            }
            ViewBag.supermarkets = supermarketsSelectListItems;

            List<SelectListItem> productsSelectListItems = new List<SelectListItem>();
            foreach (Product product in ShoppingListElements)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = product.Name,
                    Selected = false
                };
                productsSelectListItems.Add(selectList);
            }
            ViewBag.products = productsSelectListItems;

            List<DateTime> deliveryTimes = new List<DateTime>();
            DateTime currentDate = DateTime.Now;
            DateTime day1 = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 0, 0, 0);
            DateTime nextDay = currentDate.AddDays(1);
            DateTime day2 = new DateTime(nextDay.Year, nextDay.Month, nextDay.Day, 0, 0, 0);
            DateTime lastDay = nextDay.AddDays(1);
            DateTime day3 = new DateTime(lastDay.Year, lastDay.Month, lastDay.Day, 0, 0, 0);
            deliveryTimes.Add(day1);
            deliveryTimes.Add(day2);
            deliveryTimes.Add(day3);
            ViewBag.deliveryTimes = deliveryTimes;
            return View();
        }

        [HttpPost]
        [Route("ShoppingCart")]
        public IActionResult ShoppingCart(Order order)
        {
            ViewData["message"] = $"Your products will be shipped at: {order.Address}. Bon appetite, {order.Name}!";
            return View("OrderStatus", order);
        }

        public IActionResult GetDeliveryTimeList()
        {
            return PartialView("_GetDeliveryTimeList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}