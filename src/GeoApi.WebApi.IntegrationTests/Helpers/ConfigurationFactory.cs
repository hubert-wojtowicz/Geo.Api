using Microsoft.Extensions.Configuration;

namespace GeoApi.WebApi.IntegrationTests.Helpers
{
    public static class ConfigurationFactory
    {
        public static IConfigurationRoot Build()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddInMemoryCollection(new Dictionary<string, string>
            {
                { "Host", "https://localhost:7088" } 
            });

            return configurationBuilder.Build();
        }
    }
}
