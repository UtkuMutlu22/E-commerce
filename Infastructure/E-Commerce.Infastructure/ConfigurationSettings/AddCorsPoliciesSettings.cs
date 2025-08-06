namespace E_Commerce.Infastructure.ConfigurationSettings
{
    using System.Configuration;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Cors.Infrastructure;
    public static class AddCorsPoliciesSettings
    {
        public static void AddCorsPoliciesFromConfiguration(this IServiceCollection services)
        {
            string path = Path.GetFullPath(@"..\..\Infastructure\E-Commerce.Infastructure\ConfigurationFiles");
            IConfiguration _configuration = new ConfigurationBuilder()
           .SetBasePath(path)
           .AddJsonFile("CorsPolicies.json", optional: false, reloadOnChange: true)
           .Build();
            IConfigurationSection[] corsPolicies = _configuration.GetSection("CorsPolicies").GetChildren().ToArray();

            foreach (IConfigurationSection policySection in corsPolicies)
            {
                var policyName = policySection.Key;
                var origins = policySection.GetSection("Origins")
                                           .GetChildren()
                                           .Select(x => x.Value)
                                           .Where(x => !string.IsNullOrWhiteSpace(x))
                                           .ToArray();

                services.AddCors(options =>
                {
                    options.AddPolicy(policyName, policy =>
                    {
                        policy.WithOrigins(origins)
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
                });
            }
        }
    }
}
