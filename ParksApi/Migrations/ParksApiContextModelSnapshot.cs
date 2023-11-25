﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParksApi.Models;

#nullable disable

namespace ParksApi.Migrations
{
    [DbContext(typeof(ParksApiContext))]
    partial class ParksApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ParksApi.Models.NationalPark", b =>
                {
                    b.Property<int>("NationalParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("NationalParkId");

                    b.ToTable("NationalParks");

                    b.HasData(
                        new
                        {
                            NationalParkId = 1,
                            Description = "A majestic national park known for the Grand Canyon.",
                            Location = "Arizona",
                            Name = "Grand Canyon National Park"
                        },
                        new
                        {
                            NationalParkId = 2,
                            Description = "The first national park with geothermal wonders.",
                            Location = "Wyoming",
                            Name = "Yellowstone National Park"
                        },
                        new
                        {
                            NationalParkId = 3,
                            Description = "A national park with diverse plant and animal life.",
                            Location = "North Carolina",
                            Name = "Great Smoky Mountains National Park"
                        },
                        new
                        {
                            NationalParkId = 4,
                            Description = "Known for its waterfalls, giant sequoias, and diverse ecosystems.",
                            Location = "California",
                            Name = "Yosemite National Park"
                        });
                });

            modelBuilder.Entity("ParksApi.Models.StatePark", b =>
                {
                    b.Property<int>("StateParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("StateParkId");

                    b.ToTable("StateParks");

                    b.HasData(
                        new
                        {
                            StateParkId = 1,
                            Description = "A beautiful state park with lush greenery.",
                            Location = "Arizona",
                            Name = "Green Valley State Park"
                        },
                        new
                        {
                            StateParkId = 2,
                            Description = "A mountainous state park with breathtaking views.",
                            Location = "Colorado",
                            Name = "Mountain Ridge State Park"
                        },
                        new
                        {
                            StateParkId = 3,
                            Description = "A serene state park along the riverbanks.",
                            Location = "Georgia",
                            Name = "Riverfront State Park"
                        },
                        new
                        {
                            StateParkId = 4,
                            Description = "A state park surrounded by tall pine trees.",
                            Location = "Pennsylvania",
                            Name = "Pine Grove State Park"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
