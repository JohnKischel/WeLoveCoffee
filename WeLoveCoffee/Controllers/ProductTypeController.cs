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
    public class ProductTypeController : Controller
    {
        public IActionResult Index()
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            ViewBag.ProductType = _context
                .Set<ProductType>()
                .ToList();
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([Bind("Type")] ProductType productType)
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            _context.Add<ProductType>(productType);
            _context.SaveChanges();
            return Redirect("/ProductType");
        }

        [HttpPost]
        public IActionResult Edit(int ProductTypeId)
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            var _product = _context.Set<ProductType>().Where(p => p.ProductTypeId == ProductTypeId).FirstOrDefault();
            return View(_product);
        }

        [HttpPost]
        public IActionResult Update([Bind("ProductTypeId","Type")] ProductType productType)
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            var _dbProduct = _context.Set<ProductType>().Where(p => p.ProductTypeId == productType.ProductTypeId).FirstOrDefault();
            _dbProduct.Type = productType.Type;
            _context.SaveChanges();
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult Delete(int productTypeId)
        {
            if (productTypeId == 1) {
                return StatusCode(403, Json("Cannot Remove 'None' frome Database."));
            }
            DbContext _context = new WeLoveCoffeeDbContext();
            var _dbProductType = _context.Set<ProductType>().Where(p => p.ProductTypeId == productTypeId).FirstOrDefault();
            _context.Remove(_dbProductType);
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                return StatusCode(403, Json("You cannot delete associated items"));
            }
            
            return Redirect("Index");
        }
    }
}