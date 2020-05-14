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
    public class RoastController : Controller
    {
        public IActionResult Index()
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            ViewBag.Roast = _context
                .Set<Roast>()
                .ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([Bind("RoastId","Name","Price","CurrentRoast","Strength","ImagePath")] Roast roast)
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            var _roast = _context.Add(roast);
            _context.SaveChanges();
            return Redirect("/Roast");
        }

        [HttpPost]
        public IActionResult Edit(int RoastId)
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            var _roast = _context.Set<Roast>().Where(p => p.RoastId == RoastId).FirstOrDefault();
            return View(_roast);
        }


        [HttpPost]
        public IActionResult Update([Bind("RoastId","Name","Price","CurrentRoast","Strength","ImagePath")] Roast roast)
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            var _dbRoast = _context.Set<Roast>().Where(p => p.RoastId == roast.RoastId).FirstOrDefault();
            _dbRoast.Name = roast.Name;
            _dbRoast.Price = roast.Price;
            _dbRoast.CurrentRoast = roast.CurrentRoast;
            _dbRoast.Strength = roast.Strength;
            _dbRoast.ImagePath = roast.ImagePath;
            _context.SaveChanges();
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult Delete(int roastId)
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            var dbRoast = _context.Set<Roast>().Where(id => id.RoastId == roastId).FirstOrDefault();
            _context.Remove<Roast>(dbRoast);
            _context.SaveChanges();
            return Redirect("/Roast");
        }
    }
}