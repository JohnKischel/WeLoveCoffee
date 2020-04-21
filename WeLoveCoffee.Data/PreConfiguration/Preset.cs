using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WeLoveCoffee.Data.EntityModels;
using WeLoveCoffee.Data.PasswordManager;
using System.Text.Json;
namespace WeLoveCoffee.Data.PreConfiguration
{
    public class Preset
    {
        public static void SetProducts(DbContext _context)
        {
            List<Product> products = new List<Product>()
            {
                new Product {Name="Kaffee",ProductTypeId=1,Price=0.25M,RoastId=1,ImagePath="https://p7.hiclipart.com/preview/720/506/575/cuban-espresso-cappuccino-coffee-cup-coffee.jpg"},
                new Product {Name="Cafe Crema",ProductTypeId=1,Price=0.25M,RoastId=1,ImagePath = "https://library.kissclipart.com/20180904/lie/kissclipart-cafe-au-lait-creme-png-clipart-caf%C3%A9-au-lait-cappu-9dc59e01187a379b.jpg"},
                new Product {Name="Espresso",ProductTypeId=1,Price=0.25M,RoastId=1,ImagePath="https://p7.hiclipart.com/preview/65/101/74/cuban-espresso-turkish-coffee-ipoh-white-coffee-kop.jpg"},
                new Product {Name="DoubleEspresso",ProductTypeId=1,Price=0.50M,RoastId=1,ImagePath = "https://cdn.shopify.com/s/files/1/0995/3376/products/ESPRESSO2017_07_grande.png?v=1559205332"},
                new Product {Name="QuadroEspresso",ProductTypeId=1,Price=1.00M,RoastId=1,ImagePath = "https://image.stern.de/8523112/16x9-940-529/87dc7945c342e0b423a058ce4c145684/IZ/kaffee.jpg"},
            };

            _context.Set<Product>().AddRange(products);
            _context.SaveChanges();
        }

        public static void SetUsers(DbContext _context)
        {
            List<User> users = new List<User>()
            {
                new User {Id = Guid.NewGuid().ToString(), Name="default",PinCode="9421",Password = "WeLoveCoffee",Created = DateTime.Now, Consumed=0,ConsumedTotal=124,Claims= xClaim.GenerateClaim(new List<string> {"User" })},
                new User {Id = Guid.NewGuid().ToString(), Name="Kaffeewart",PinCode="9421",Password = "WeLoveCoffee",Created = DateTime.Now, Consumed=0,ConsumedTotal=155,Claims= xClaim.GenerateClaim(new List<string> {"Admin","User" })},
                new User {Id = Guid.NewGuid().ToString(), Name="ThomasWittenborg",PinCode="9421",Password = "WeLoveCoffee",Created = DateTime.Now, Consumed=0,ConsumedTotal=155,Claims= xClaim.GenerateClaim(new List<string> {"User" })},

            };

            _context.Set<User>().AddRange(users);
            _context.SaveChanges();
        }

        public static void SetProductTypes(DbContext _context)
        {
            ProductType productType = new ProductType() { ProductTypeId=1,Type="Coffee Normal"};
            _context.Set<ProductType>().Add(productType);
            _context.SaveChanges();
        }

        public static void SetRoasts(DbContext _context)
        {
            Roast roast = new Roast() { RoastId = 1, CurrentRoast = true, Name = "Classic", Price = 6.99M ,ImagePath= "https://images.unsplash.com/photo-1581191852946-c8b7c9caf935?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1000&q=60" };
            Roast roast1 = new Roast() { RoastId = 2, CurrentRoast = false, Name = "Crempresso Speacial", Price = 12.99M,ImagePath=""};
            _context.Set<Roast>().AddRange(roast, roast1);
            _context.SaveChanges();
        }

    }
}
