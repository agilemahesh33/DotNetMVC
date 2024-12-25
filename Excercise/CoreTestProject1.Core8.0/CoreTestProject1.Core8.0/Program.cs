namespace CoreTestProject1.Core8._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => ".NET Core Empty Web Application created using ASP.NET Core 8.0");

            app.Run();
        }
    }
}
