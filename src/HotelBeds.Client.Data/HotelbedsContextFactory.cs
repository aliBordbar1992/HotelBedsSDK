using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HotelBeds.Client.Data
{
    public class HotelbedsContextFactory : IDesignTimeDbContextFactory<HotelbedsContext>
    {
        private static string DataConnectionString => new DatabaseConfiguration().GetDataConnectionString();

        public HotelbedsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HotelbedsContext>();
            optionsBuilder.UseSqlServer(DataConnectionString);
            return new HotelbedsContext(optionsBuilder.Options);
        }
    }
}