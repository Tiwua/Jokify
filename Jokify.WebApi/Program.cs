namespace Jokify.WebApi
{
    using HouseRentingSystem.Infrastructure.Data.Common;
    using Jokify.Common.Contracts;
    using Jokify.Common.Services;
    using Jokify.Core.Contracts;
    using Jokify.Core.Services;
    using Jokify.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<JokifyDbContext>(opt =>
                opt.UseSqlServer(connectionString));

            builder.Services.AddScoped<ILikeService, LikeService>();
            builder.Services.AddScoped<IJokeService, JokeService>();
            builder.Services.AddScoped<IRepository, Repository>();

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