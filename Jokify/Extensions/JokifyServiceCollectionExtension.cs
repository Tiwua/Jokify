namespace Jokify.Extensions
{
    using HouseRentingSystem.Infrastructure.Data.Common;
    using Jokify.Common.Contracts;
    using Jokify.Core.Contracts;
    using Jokify.Core.Contracts.Admin;
    using Jokify.Core.Services.Admin;
    using Jokify.Core.Services.AverageUser;
    using Jokify.Infrastructure.Data;
    using Jokify.Infrastructure.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Runtime.CompilerServices;

    public static class JokifyServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IJokeCategoryService, JokeCategoryService>();
            services.AddScoped<IJokeService, JokeService>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
