using HotelBeds.Client.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelBeds.Client.Data
{
    public class DatabaseConfiguration : ConfigurationBase
    {
        private string DataConnectionKey = nameof(HotelbedsContext);

        public string GetDataConnectionString()
        {
            var configs = base.GetConfiguration();
            return configs.GetConnectionString(DataConnectionKey);
        }
    }

    public static class RegisterContext
    {
        public static void AddContext(this IServiceCollection serviceCollection)
        {
            string connectionString = new DatabaseConfiguration().GetDataConnectionString();
            serviceCollection.AddDbContext<HotelbedsContext>(options => options.UseSqlServer(connectionString));
            serviceCollection.AddScoped<DbContext, HotelbedsContext>();

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddScoped<IRepository<Booking>, Repository<Booking>>();
        }

    }
}