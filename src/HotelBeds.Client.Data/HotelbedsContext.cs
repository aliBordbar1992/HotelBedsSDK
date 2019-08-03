using System;
using HotelBeds.Client.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBeds.Client.Data
{
    public class HotelbedsContext : DbContext
    {
        public HotelbedsContext()
        {
        }

        public HotelbedsContext(DbContextOptions<HotelbedsContext> options)
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
    }
}
