namespace Jokify.Infrastructure.Data
{
    using Jokify.Infrastructure.Data.Configuration;
    using Jokify.Infrastructure.Data.Models;
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Jokify.Infrastructure.Data.Models.MappingTables;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using static Jokify.Infrastructure.Common.DataConstants.Joke;

    public class JokifyDbContext : IdentityDbContext<User>
    {
        public JokifyDbContext(DbContextOptions<JokifyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; } = null!;

        public DbSet<Joke> Jokes { get; set; } = null!;

        public DbSet<JokeCategory> JokeCategories { get; set; } = null!;

        public DbSet<UserFavoriteJoke> UsersFavoritesJokes { get; set; } = null!;

        public DbSet<UserJoke> UsersJokes { get; set; } = null!;

        public DbSet<JokeComment> JokesComments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Configuration
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new JokeCategoryConfiguration());
            builder.ApplyConfiguration(new JokeConfiguration());

            //Fluent api
            builder
                .Entity<JokeComment>()
                .HasKey(jc => new { jc.JokeId, jc.CommentId });

            builder
                .Entity<UserFavoriteJoke>()
                .HasKey(ufj => new { ufj.UserId, ufj.JokeId });

            builder
                .Entity<UserJoke>()
                .HasKey(uj => new { uj.UserId, uj.JokeId });


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

            builder
                .Entity<Comment>()
                .HasOne(u => u.User)
                .WithMany(c => c.CreatedComments)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Entity<Comment>()
                .HasOne(j => j.Joke)
                .WithMany(c => c.Comments)
                .HasForeignKey(j => j.JokeId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Comment>()
                    .Property(e => e.CreatedOn)
                    .HasColumnType("datetime2(0)");

            base.OnModelCreating(builder);
        }
    }
}