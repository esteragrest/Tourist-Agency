using Microsoft.EntityFrameworkCore;
using TouristAgencyAPI.Entities;

namespace TouristAgencyAPI
{
    public class TouristAgencyContext : DbContext
    {
        public TouristAgencyContext(DbContextOptions<TouristAgencyContext> options) : base(options) { }

        public DbSet<TouristRoute> TouristRoutes { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<HotelRoom> HotelRooms { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TouristRoute>().ToTable("Routes");
        }
    }
}
