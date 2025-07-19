namespace E_Commerce.Persistance
{
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Provides access to environment-specific configuration settings.
    /// Reads configuration from the appsettings.json file.
    /// Provides access to environment-specific configuration settings.
    /// Reads configuration from the appsettings.json file.
    /// </summary>
    internal static class EnviromentConfigurationSettings
    {
        /// <summary>
        /// The configuration object built from the appsettings.json file located in the application's base directory.
        /// </summary>
        private static readonly IConfiguration _configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        /// <summary>
        /// Gets the SQL Server connection string defined in the appsettings.json under the key "SqlServerConnection".
        /// </summary>
        public static string SqlServerConnection
        {
            get
            {
                return _configuration.GetConnectionString("SqlServerConnection")
                    ?? throw new InvalidOperationException("SqlServerConnection string is not configured.");
            }
        }
    }
}
