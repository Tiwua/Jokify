namespace Jokify.Extensions
{
    using HouseRentingSystem.Infrastructure.Data.Common;
    using Jokify.Common.Contracts;
    using Jokify.Common.Services;
    using Jokify.Core.Contracts;
    using Jokify.Core.Services;
    using System.Runtime.CompilerServices;

    public static class JokifyServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IJokeCategoryService, JokeCategoryService>();
            services.AddScoped<IJokeService, JokeService>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ILikeService, LikeService>();

            return services;
        }
    }
}
