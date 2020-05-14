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
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            ViewBag.Product = _context
                .Set<Product>()
                .Include(r => r.Roast)
                .Include(p => p.ProductType)
                .ToList();
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            ViewBag.ProductTypes = _context.Set<ProductType>().ToList();
            ViewBag.Roasts = _context.Set<Roast>().ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add([Bind("Id", "Name", "Price", "ProductTypeId", "RoastId", "ImagePath")] Product product)
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            _context.Add(product);
            _context.SaveChanges();
            return Redirect("/Product");
        }

        public IActionResult Edit(int productId)
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            var _product = _context.Set<Product>().Where(p => p.Id == productId).FirstOrDefault();
            ViewBag.ProductTypes = _context.Set<ProductType>().ToList();
            ViewBag.Roasts = _context.Set<Roast>().ToList();
            return View(_product);
        }

        public IActionResult Update([Bind("Id", "Name", "Price", "ProductTypeId", "RoastId", "ImagePath")] Product _product)
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            var _dbProduct = _context.Set<Product>().Where(p => p.Id == _product.Id).FirstOrDefault();
            _dbProduct.Name = _product.Name;
            _dbProduct.Price = _product.Price;
            _dbProduct.ProductTypeId = Convert.ToInt32(Request.Form["ProductType"]);
            _dbProduct.RoastId = Convert.ToInt32(Request.Form["RoastId"]);
            _dbProduct.ImagePath = _product.ImagePath;
            _context.SaveChanges();
            return Redirect("/Product");
        }

        public IActionResult Delete(int productId)
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            var dbProduct = _context.Set<Product>().Where(id => id.Id == productId).FirstOrDefault();
            _context.Remove<Product>(dbProduct);
            _context.SaveChanges();
            return LocalRedirect("/Product");
        }
    }
}