﻿namespace Jokify.Infrastructure.Data
{
    using Jokify.Infrastructure.Data.Models;
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Jokify.Infrastructure.Data.Models.MappingTables;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<User>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

        public DbSet<Comment> Comments { get; set; } = null!;

        public DbSet<Joke> Jokes { get; set; } = null!;

        public DbSet<JokeCategory> JokeCategories { get; set; } = null!;

        public DbSet<JokeComment> JokesComments { get; set; } = null!;

        public DbSet<UserFavoriteJoke> UsersFavoritesJokes { get; set; } = null!;

        public DbSet<UserJoke> UsersJokes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<JokeComment>()
                .HasKey(jk => new { jk.CommentId, jk.JokeId });

            builder
                .Entity<UserFavoriteJoke>()
                .HasKey(ufj => new { ufj.UserId, ufj.JokeId });

            builder
                .Entity<UserJoke>()
                .HasKey(uj => new { uj.UserId, uj.JokeId });

            builder
                .Entity<Joke>()
                .Property(j => j.Rating)
                .HasColumnType("decimal(3,2)")
                .IsRequired(true);

            builder
                .Entity<UserFavoriteJoke>()
                .HasOne(u => u.User)
                .WithMany(j => j.FavoriteJokes)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Entity<UserJoke>()
               .HasOne(u => u.User)
               .WithMany(j => j.CreatedJokes)
               .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }
    }
}