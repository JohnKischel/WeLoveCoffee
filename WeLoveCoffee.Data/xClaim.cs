using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WeLoveCoffee.Data.EntityModels;

namespace WeLoveCoffee.Data
{
    public class xClaim
    {
        public string NameIdentifier { get; set; }
        public List<string> Role { get; set; }

        public static string GenerateClaim(List<string> role)
        {
            xClaim cClaim = new xClaim { NameIdentifier = $"{Guid.NewGuid().ToString()}", Role =  role };
            return JsonSerializer.Serialize<xClaim>(cClaim);
        }

        public static List<string> GetClaims(User user) => JsonSerializer.Deserialize<xClaim>(user.Claims).Role;

        public static string AddClaim(User user, string role)
        {
            var cClaim = JsonSerializer.Deserialize<xClaim>(user.Claims);
            cClaim.Role.Add(role);
            return JsonSerializer.Serialize<xClaim>(cClaim);
        }

        public static string RemoveClaim(User user, string role)
        {
            var cClaim = JsonSerializer.Deserialize<xClaim>(user.Claims);
            cClaim.Role.Remove(role);
            return JsonSerializer.Serialize<xClaim>(cClaim);
        }

    }
}