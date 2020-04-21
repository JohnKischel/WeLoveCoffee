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
    public class AccountController : Controller
    {
        public object ClaimType { get; private set; }

        [AllowAnonymous]
        public IActionResult SignIn(string returnurl = "/")
        {
            return View(new LoginModel { ReturnUrl = returnurl});
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(LoginModel loginModel)
        {
            Console.WriteLine("Creating Claims");

            DbContext _context = new WeLoveCoffeeDbContext();
            var user = _context.Set<User>().Where(u => u.Name == loginModel.Username && u.Password == loginModel.Password).Select(o => o).FirstOrDefault();
            if (user is null) {
                return Unauthorized();
            }

            var userClaims = JsonSerializer.Deserialize<xClaim>(user.Claims);
            var claims = new List<System.Security.Claims.Claim>
            {
                new System.Security.Claims.Claim(ClaimTypes.NameIdentifier,userClaims.NameIdentifier),
                new System.Security.Claims.Claim(ClaimTypes.Name,user.Name)
            };

            foreach (var claim in userClaims.Role)
            {
                claims.Add(new System.Security.Claims.Claim(ClaimTypes.Role, claim));
            }

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties { IsPersistent = true }
                );
            
           return LocalRedirect(loginModel.ReturnUrl);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/Account/SignIn");
        }
    }
}