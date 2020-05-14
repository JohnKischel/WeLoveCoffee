using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace WeLoveCoffee.Data.EntityModels
{
    public class Buy
    {
        public string UserId { get; set; }
        public int ProductId { get; set; }

        public static void BuyProduct(string userId,string productId)
        {
            DbContext _context = new WeLoveCoffeeDbContext();
            var dbUser = _context.Set<User>().Where(u => u.Id == userId).FirstOrDefault();
            var dbProductPrice = _context.Set<Product>().Where(p => p.ProductTypeId == Convert.ToInt32(productId)).Select(pr => pr.Price).FirstOrDefault();
            dbUser.AccountBalance += dbProductPrice;
            _context.SaveChanges();
         }
    }
}
