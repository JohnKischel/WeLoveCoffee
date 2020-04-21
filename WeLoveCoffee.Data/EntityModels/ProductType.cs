using System;
using System.Collections.Generic;

namespace WeLoveCoffee.Data.EntityModels
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public string Type { get; set; }
        public List<Product> Products { get; set; }
    }
}