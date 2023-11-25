using Microsoft.EntityFrameworkCore;

namespace ParksApi.Models
{
    public class ParksApiContext : DbContext
    {
        public DbSet<StatePark> StateParks { get; set; }
        public DbSet<NationalPark> NationalParks { get; set; }

        public ParksApiContext(DbContextOptions<ParksApiContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StatePark>()
                .HasData(
                    new StatePark { ParkId = 1, Name = "State Park 1", Location = "Location 1", Description = "Description 1" },
                    new StatePark { ParkId = 2, Name = "State Park 2", Location = "Location 2", Description = "Description 2" },
                    new StatePark { ParkId = 3, Name = "State Park 3", Location = "Location 3", Description = "Description 3" },
                    new StatePark { ParkId = 4, Name = "State Park 4", Location = "Location 4", Description = "Description 4" }
                );

            builder.Entity<NationalPark>()
                .HasData(
                    new NationalPark { ParkId = 1, Name = "National Park 1", Location = "Location 1", Description = "Description 1" },
                    new NationalPark { ParkId = 2, Name = "National Park 2", Location = "Location 2", Description = "Description 2" },
                    new NationalPark { ParkId = 3, Name = "National Park 3", Location = "Location 3", Description = "Description 3" },
                    new NationalPark { ParkId = 4, Name = "National Park 4", Location = "Location 4", Description = "Description 4" }
                );
        }
    }
}