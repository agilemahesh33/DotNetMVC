using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using MVCDHProject.Models;

namespace MVCDHProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(configure =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                configure.Filters.Add(new AuthorizeFilter(policy));
            });

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<MVCCoreDbContext>().AddDefaultTokenProviders();

            builder.Services.AddDbContext<MVCCoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));
            //builder.Services.AddScoped<ICustomerDAL, CustomerXmlDAL>();
            builder.Services.AddScoped<ICustomerDAL, CustomerSqlDAL>();

            //Need to install two packages to work with Open Authentication
            //Microsoft.AspNetCore.Authentication.Google
            //Microsoft.AspNetCore.Authentication.Facebook
            //setup Google App and Facebook App write ID and Secrete Generated here
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                //app.UseStatusCodePages();
                app.UseStatusCodePagesWithRedirects("/ClientError/{0}");
                //app.UseStatusCodePagesWithReExecute("/ClientError/{0}"); 
                app.UseExceptionHandler("/ServerError");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
