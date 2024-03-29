﻿namespace Jokify.Extensions
{
    using Jokify.Infrastructure.Data.Common;
    using Jokify.Common.Contracts;
    using Jokify.Core.Contracts;
    using Jokify.Core.Contracts.Admin;
    using Jokify.Core.Services.Admin;
    using Jokify.Core.Services.AverageUser;

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
