namespace Jokify.Infrastructure.Data.Configuration
{
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class JokeConfiguration : IEntityTypeConfiguration<Joke>
    {
        public void Configure(EntityTypeBuilder<Joke> builder)
        {
            builder.HasData(AddJokes());
        }

        private HashSet<Joke> AddJokes()
        {
            var jokes = new HashSet<Joke>();

            var joke = new Joke()
            {
                Id = Guid.NewGuid()
            };

            return jokes;
        }
    }
}
