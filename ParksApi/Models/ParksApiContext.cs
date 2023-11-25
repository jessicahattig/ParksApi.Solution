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
                    new StatePark { StateParkId = 1, Name = "Green Valley State Park", Location = "Arizona", Description = "A beautiful state park with lush greenery." },
                    new StatePark { StateParkId = 2, Name = "Mountain Ridge State Park", Location = "Colorado", Description = "A mountainous state park with breathtaking views." },
                    new StatePark { StateParkId = 3, Name = "Riverfront State Park", Location = "Georgia", Description = "A serene state park along the riverbanks." },
                    new StatePark { StateParkId = 4, Name = "Pine Grove State Park", Location = "Pennsylvania", Description = "A state park surrounded by tall pine trees." }
                );

            builder.Entity<NationalPark>()
                .HasData(
                    new NationalPark { NationalParkId = 1, Name = "Grand Canyon National Park", Location = "Arizona", Description = "A majestic national park known for the Grand Canyon." },
                    new NationalPark { NationalParkId = 2, Name = "Yellowstone National Park", Location = "Wyoming", Description = "The first national park with geothermal wonders." },
                    new NationalPark { NationalParkId = 3, Name = "Great Smoky Mountains National Park", Location = "North Carolina", Description = "A national park with diverse plant and animal life." },
                    new NationalPark { NationalParkId = 4, Name = "Yosemite National Park", Location = "California", Description = "Known for its waterfalls, giant sequoias, and diverse ecosystems." }
                );
        }
    }
}