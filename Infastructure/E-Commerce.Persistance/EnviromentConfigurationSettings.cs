using Microsoft.Extensions.Configuration;

namespace E_Commerce.Persistance
{
    static class EnviromentConfigurationSettings
    {
        private static readonly IConfiguration _configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        public static string SqlServerConnection => _configuration.GetConnectionString("SqlServerConnection");
    }
}
