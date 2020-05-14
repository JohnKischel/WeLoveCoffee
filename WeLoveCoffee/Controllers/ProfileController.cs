using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeLoveCoffee.Models;
using WeLoveCoffee.Data.EntityModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using WeLoveCoffee.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeLoveCoffee.Views.Account
{
    public class ProfileController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Profile()
        {
            var Username = User.Identity.Name;
            return View();
        }

    }
}