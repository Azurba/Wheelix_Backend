using Microsoft.EntityFrameworkCore;
using Wheelix_Backend.Model;

namespace Wheelix_Backend

{
    public class WheelixDBContext : DbContext
    {
        public WheelixDBContext(DbContextOptions<WheelixDBContext> options) : base(options) {   }

        public DbSet<Car> Car { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Rental> Rental { get; set; }

        public DbSet<Additionals> Additionals { get; set; }

        public DbSet<IPStackAPI> IPStackAPI { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Rental>()
        //    .HasOne(r => r.car)
        //    .WithMany(c => c.Rentals)
        //    .HasForeignKey(r => r.CarId);

        //    modelBuilder.Entity<Rental>()
        //    .HasOne(r => r.driver)
        //    .WithMany(d => d.Rentals)
        //    .HasForeignKey(r => r.DriverId);
        //}

    }

}
    