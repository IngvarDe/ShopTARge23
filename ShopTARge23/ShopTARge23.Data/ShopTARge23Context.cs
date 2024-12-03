using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopTARge23.Core.Domain;


namespace ShopTARge23.Data
{
    public class ShopTARge23Context : IdentityDbContext<ApplicationUser>
    {
        public ShopTARge23Context(DbContextOptions<ShopTARge23Context> options) 
        : base(options) { }

        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<FileToApi> FileToApis { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<FileToDatabase> FileToDatabases { get; set; }
        
        public DbSet<IdentityRole> IdentityRoles{ get; set; }




    }
}
