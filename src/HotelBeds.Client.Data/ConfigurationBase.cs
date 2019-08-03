using Microsoft.Extensions.Configuration;
using System;

namespace HotelBeds.Client.Data
{
    public abstract class ConfigurationBase
    {
        protected IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("dbSettings.json")
                .Build();
        }

        protected void RaiseValueNotFoundException(string configurationKey)
        {
            throw new Exception($"appsettings key {configurationKey} could not be found.");
        }
    }
}
