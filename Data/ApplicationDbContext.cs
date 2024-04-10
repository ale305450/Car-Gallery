using Learing_Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Learing_Core.ViewModels;

namespace Learing_Core.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users","secuirty");
            builder.Entity<IdentityRole>().ToTable("Roles", "secuirty");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "secuirty");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "secuirty");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins","secuirty");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims","secuirty");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "secuirty");
        }
        public DbSet<Car> car { get; set; }
        public DbSet<Company> company { get; set; }
        public DbSet<RentalCar> rentalCar { get; set; }
        public DbSet<Gallery> gallery { get; set; }
        public DbSet<Learing_Core.ViewModels.GalleryViewModel>? GalleryViewModel { get; set; }
     }
}