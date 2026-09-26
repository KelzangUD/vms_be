using Microsoft.EntityFrameworkCore;
using vms_be.Models;

namespace vms_be
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            { }

        // tables to be created in db
        public DbSet<Users> Users { get; set; }
        public DbSet<VehicleDetails> VehicleDetails { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<VehicleCategory> VehicleCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed admin user
            modelBuilder.Entity<Users>().HasData(
                new Users { Id = 1, UserName = "admin", Password = "admin" }
                );

            // seed predefined manufacturers
            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { Id = 1, Name = "Mazda" },
                new Manufacturer { Id = 2, Name = "Mercedes" },
                new Manufacturer { Id = 3, Name = "Honda" },
                new Manufacturer { Id = 4, Name = "Ferrari" },
                new Manufacturer { Id = 5, Name = "Toyota" }
                );

            // seed cateory
            modelBuilder.Entity<VehicleCategory>().HasData(
                new VehicleCategory { Id = 1, CategoryName = "Light", StartWeight = 0, IconName = "fa-motorcycle" },
                new VehicleCategory { Id = 2, CategoryName = "Medium", StartWeight = 500, IconName = "fa-car" },
                new VehicleCategory { Id = 3, CategoryName = "Heavy", StartWeight = 2500, IconName = "fa-truck" }
                );
        }
    }
}
