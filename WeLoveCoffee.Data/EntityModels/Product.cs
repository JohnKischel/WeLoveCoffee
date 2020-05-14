using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WeLoveCoffee.Data.EntityModels
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public int? RoastId { get; set; }
        public Roast Roast { get; set; }
        [Url]
        public string ImagePath { get; set; }
    }
}

