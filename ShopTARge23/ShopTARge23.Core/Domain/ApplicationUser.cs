using Microsoft.AspNetCore.Identity;


namespace ShopTARge23.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
        public string Name { get; set; }
    }
}
