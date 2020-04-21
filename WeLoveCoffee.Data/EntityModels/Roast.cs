using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WeLoveCoffee.Data.EntityModels
{
    public class Roast
    {
        public int RoastId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool CurrentRoast { get; set; }

        [Range(DataConstant.StrengthMin,DataConstant.StrengthMax)]
        public int Strength { get; set; }

        public List<Product> Products { get; set; }

        [Url]
        public string ImagePath { get; set; }

        [Range(DataConstant.RatingMin, DataConstant.RatingMax)]
        public int Rating { get; set; }

    }
}
