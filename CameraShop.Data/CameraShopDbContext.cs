using CameraShop.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CameraShop.Data
{
    public class CameraShopDbContext : IdentityDbContext<User>
    {
        public CameraShopDbContext(DbContextOptions<CameraShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Camera> Cameras { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Camera>().ToTable("Cameras");
        }
    }
}
