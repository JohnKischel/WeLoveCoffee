using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WeLoveCoffee.Data.EntityModels;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WeLoveCoffee.Data;
using WeLoveCoffee.Data.PreConfiguration;

namespace WeLoveCoffee
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.IO.File.Delete(".\\WeLoveCoffee.db");
            DbContext _context = new WeLoveCoffeeDbContext();

            _context.Database.EnsureCreated();
            Preset.SetProductTypes(_context);
            Preset.SetUsers(_context);
            Preset.SetRoasts(_context);
            Preset.SetProducts(_context);
            

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

