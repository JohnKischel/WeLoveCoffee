using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WeLoveCoffee.Data;
using WeLoveCoffee.Data.EntityModels;
using WeLoveCoffee.Models;

namespace WeLoveCoffee.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            var products = _context.Set<Product>()
                .Include(p => p.ProductType)
                .OrderBy(n => n.Name)
                .ToList();

            ViewBag.Roast = _context.Set<Roast>().Where(c => c.CurrentRoast == true).Select(n => n).FirstOrDefault();
            ViewBag.Users = _context.Set<User>().ToList();
            return View(products);
        }

     
        public IActionResult BuyProduct()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
