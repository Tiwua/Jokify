namespace Jokify.Infrastructure.Data.Configuration
{
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Jokify.Infrastructure.Data.Models.MappingTables;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class UsersJokesConfiguration : IEntityTypeConfiguration<UserJoke>
    {
        public void Configure(EntityTypeBuilder<UserJoke> builder)
        {
            builder.HasData(SeedUserJokeData());
        }

        private HashSet<UserJoke> SeedUserJokeData()
        {
            var userJoke = new HashSet<UserJoke>();

            var relation = new UserJoke()
            {
                UserId = "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                JokeId = new Guid("03D4C03E-A747-4D63-A240-16B2BF4CBDFC")
            };

            userJoke.Add(relation);

            relation = new UserJoke()
            {

            };

            return userJoke;
        }
    }
}
