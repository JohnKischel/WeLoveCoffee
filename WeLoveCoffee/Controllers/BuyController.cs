using System;
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
    public class BuyController : Controller
    {

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public IActionResult BuyProduct()
        {
            var formdata = Request.Form;
            foreach (var data in formdata)
            {
                Console.WriteLine(data.Value);
            }
            //Console.WriteLine(userId);
            //Console.WriteLine(productId);
            //Buy.BuyProduct("1", productId);
            return View();
        }
    }
}