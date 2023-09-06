namespace Jokify.WebApi
{
    using Jokify.Infrastructure.Data.Common;
    using Jokify.Common.Contracts;
    using Jokify.Core.Contracts;
    using Jokify.Core.Services.AverageUser;
    using Jokify.Infrastructure.Data;
    using Jokify.Infrastructure.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<JokifyDbContext>(opt =>
                opt.UseSqlServer(connectionString));

            builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<JokifyDbContext>()
    .AddDefaultTokenProviders();

            builder.Services.AddScoped<IRepository, Repository>();
            builder.Services.AddScoped<ICommentService>(provider =>
            {
                var userManager = provider.GetRequiredService<UserManager<User>>();
                var repository = provider.GetRequiredService<IRepository>();
                return new CommentService(repository, userManager);
            });
            builder.Services.AddScoped<IJokeService, JokeService>();

            builder.Services.AddCors(setup =>
            {
                setup.AddPolicy("JokifySystem", policyBuilder =>
                {
                    policyBuilder.WithOrigins("https://localhost:7099")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var commentServiceDescriptor = builder.Services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(ICommentService));
            if (commentServiceDescriptor != null)
            {
                Console.WriteLine("CommentService registered.");
            }

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors("JokifySystem");

            app.Run();
        }
    }
}