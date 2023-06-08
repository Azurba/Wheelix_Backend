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

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            /*
             * This code configures the relationship between the Rental and Car entities using the Fluent API in Entity Framework. 
             * Here's what each method call does:
             * 1) modelBuilder.Entity<Rental>(): Specifies that we are configuring the Rental entity.
             * 2) .HasOne(r => r.Car): Indicates that the Rental entity has a navigation property called Car which represents a single related Car entity.
             * 3) .WithOne(c => c.Rental): Specifies that the Car entity also has a navigation property called Rental which represents a single related Rental entity.
             * 4) .HasForeignKey<Car>(c => c.RentalId): Specifies that the foreign key property used for the relationship between Car and Rental is RentalId in the Car entity.
             * 
             * In other words, this configuration states that a Rental can be associated with only one Car (via the Car navigation property), and a Car can 
             * be associated with only one Rental (via the Rental navigation property). The foreign key property RentalId in the Car entity is used to establish 
             * this relationship.
             */

            modelBuilder.Entity<Rental>().HasOne(r => r.car).WithOne(c => c.Rental).HasForeignKey<Car>(c => c.RentalId);

            // Configure the relationship between Rental and Driver
            modelBuilder.Entity<Rental>()
                .HasOne(r => r.driver)
                .WithOne(d => d.Rental)
                .HasForeignKey<Driver>(d => d.RentalId);

            // Configure the relationship between Additionals and Rental

            modelBuilder.Entity<Rental>()
                .HasMany(r => r.additionals)
                .WithOne(a => a.Rental)
                .HasForeignKey(a => a.RentalId);

            // Configure the cascade delete behavior

            /*
             * The OnDelete method is optional and allows you to configure the cascade delete behavior. In this example, DeleteBehavior.Restrict 
             * is used to prevent cascading deletes.
             */
            modelBuilder.Entity<Rental>()
                .HasOne(r => r.car)
                .WithOne(c => c.Rental)
                .HasForeignKey<Car>(c => c.RentalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.driver)
                .WithOne(d => d.Rental)
                .HasForeignKey<Driver>(d => d.RentalId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
 
}
    