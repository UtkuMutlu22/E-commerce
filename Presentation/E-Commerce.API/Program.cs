using E_Commerce.Infastructure;
using E_Commerce.Infastructure.ConfigurationSettings;
using E_Commerce.Persistance;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// The main entry point for the E-Commerce API application.
/// </summary>
internal class Program
{
    /// <summary>
    /// Configures and runs the web application.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddPersistanceServices();
        builder.Services.AddInfrastructureService();
        WebApplication app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("FrontendApp");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
