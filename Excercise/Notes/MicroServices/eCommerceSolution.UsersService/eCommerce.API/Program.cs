using eCommerce.Infrastructure;
using eCommerce.Core;
namespace eCommerce.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add Infrastructur services.
        builder.Services.AddInfrastructure();
        // Add Core services.
        builder.Services.AddCore();

        // Add Controllers to service collection 
        //we dont want to create views, wey want to create APIs
        builder.Services.AddControllers();

        var app = builder.Build();
        // Configure the HTTP request pipeline.
        app.UseRouting();
        // Enable CORS (Cross-Origin Resource Sharing) if needed
        app.UseAuthentication();
        // Enable Authentication middleware to handle user authentication
        app.UseAuthorization();
        // Map Controllers to the app
        app.MapControllers();

        app.Run();
    }
}
