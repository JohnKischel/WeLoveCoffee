﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeLoveCoffee.Data;
using WeLoveCoffee.Data.EntityModels;

namespace WeLoveCoffee.Controllers
{
    public class ManageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Policy = "Admin")]
        public IActionResult Products()
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            ViewBag.ProductTypes = _context.Set<ProductType>();
            return View();
        }
        public IActionResult Profile()
        {
            return View();

        }

        [Authorize(Policy = "Admin")]
        public IActionResult Roast()
        {
            return View();
        }

        [Authorize(Policy = "Admin")]
        public IActionResult Users()
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            var  users =_context.Set<User>().ToList();
            ViewBag.User = users;
            return View();
        }

        [Authorize(Policy = "Admin")]
        public IActionResult Edit(string userId)
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            var user = _context.Set<User>().Where(id => id.Id == userId).FirstOrDefault();

            if (user is null) { return StatusCode(400); }

            var claims = JsonSerializer.Deserialize<xClaim>(user.Claims);
            ViewBag.Claims = claims.Role;
            return Ok(user);
        }

        [Authorize(Policy = "Admin")]
        public IActionResult Remove(string userId)
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            var user = _context.Set<User>().Where(id => id.Id == userId).FirstOrDefault();
            if (user is null) {return StatusCode(400); }
            if (!xClaim.GetClaims(user).Contains("Admin"))
            {
                _context.Remove<User>(user);
                _context.SaveChanges();
                return LocalRedirect("/Manage/Users");
            }

            return StatusCode(403, Json("Cant remove admin. Remove role 'Admin' first"));
        }
    }
}