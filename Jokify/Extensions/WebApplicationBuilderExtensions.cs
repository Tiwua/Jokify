namespace Jokify.Extensions
{
    using Jokify.Infrastructure.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Runtime.CompilerServices;
    using static Jokify.Areas.Admin.Constants.AdminConstants;
    public static class WebApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app, string email)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var serviceProvider = scopedServices.ServiceProvider;

            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    return;
                }

                var role = new IdentityRole(AdminRoleName);

                await roleManager.CreateAsync(role);

                var adminUser = await userManager.FindByEmailAsync(email);

                await userManager.AddToRoleAsync(adminUser, AdminRoleName);
            }).GetAwaiter().GetResult();

            return app;
        }
    }
}
