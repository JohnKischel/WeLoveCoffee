using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WeLoveCoffee.Data.EntityModels
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PinCode { get; set; }
        [Range(DataConstant.PasswordMinLength,DataConstant.PasswordMaxLength)]
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public int Consumed { get; set; }
        public int ConsumedTotal { get; set; }
        public string Claims { get; set; }
    }
}
