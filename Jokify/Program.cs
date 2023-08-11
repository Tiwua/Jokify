namespace Jokify
{
    using Jokify.Extensions;
    using Jokify.Infrastructure.Data;
    using Jokify.Infrastructure.Data.Models;
    using static Jokify.Areas.Admin.Constants.AdminConstants;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;
    using Jokify.ActionFilters.FIlters;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<JokifyDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<JokifyDbContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/User/Login";
                options.AccessDeniedPath = "/Home/Error/404";
            });

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(DynamicLayoutActionFilter));
            });

            builder.Services.AddApplicationServices();
            builder.Services.Configure<IdentityOptions>(options => options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error/Error");
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.SeedAdmin(AdminEmail);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "error",
                    pattern: "Error/{statusCode}",
                    defaults: new { controller = "Error", action = "Error" });

                endpoints.MapControllerRoute(
                    name: "error",
                    pattern: "{*url}",
                    defaults: new { controller = "Error", action = "Error" });
            });

            app.MapRazorPages();

            app.Run();
        }
    }
}