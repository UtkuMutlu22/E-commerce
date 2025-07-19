using E_Commerce.Persistance;

/// <summary>
/// The entry point of the application. Configures and runs the web application.
/// </summary>
/// <param name="args">Command-line arguments passed to the application.</param>
internal class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddPersistanceServices();

        WebApplication app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
