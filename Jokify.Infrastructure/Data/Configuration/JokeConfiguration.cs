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
                Id = Guid.NewGuid(),
                Title = "Fat DNA?",
                Setup = "What did the Dna say to the other DNA?",
                Punchline = "Do these genes make me look fat?",
                JokeCategoryId = 1,
                UserId = "cfbab976-a6d3-44c2-bdce-51c3b6b0412c"

            };

            jokes.Add(joke);

            joke = new Joke()
            {
                Id = Guid.NewGuid(),
                Title = "Bicycle",
                Setup = "A bicycle can't stand on its own",
                Punchline = "Because its two - tired.",
                JokeCategoryId = 2,
                UserId = "cfbab976-a6d3-44c2-bdce-51c3b6b0412c"
            };

            jokes.Add(joke);

            joke = new Joke()
            {
                Id = Guid.NewGuid(),
                Title = "Owl",
                Setup = $"Knock, knock.{Environment.NewLine} Who’s there?",
                Punchline = $"Who. {Environment.NewLine} Who who? {Environment.NewLine} What are you, an owl?",
                JokeCategoryId = 3,
                UserId = "cfbab976-a6d3-44c2-bdce-51c3b6b0412c"
            };

            jokes.Add(joke);

            joke = new Joke()
            {
                Id = Guid.NewGuid(),
                Title = "Outside",
                Setup = "I'm going to stand outside.",
                Punchline = "So if anyone asks, I’m outstanding.",
                JokeCategoryId = 4,
                UserId = "cfbab976-a6d3-44c2-bdce-51c3b6b0412c"
            };

            jokes.Add(joke);

            joke = new Joke()
            {
                Id = Guid.NewGuid(),
                Title = "Parrot",
                Setup = "What is orange and sounds like a parrot?",
                Punchline = "A Carrot.",
                JokeCategoryId = 5,
                UserId = "cfbab976-a6d3-44c2-bdce-51c3b6b0412c"
            };

            jokes.Add(joke);

            joke = new Joke()
            {
                Id = Guid.NewGuid(),
                Title = "Trust Issues",
                Setup = "Why don't scientists trust atoms?",
                Punchline = "Because they make up everything!",
                JokeCategoryId = 6,
                UserId = "cfbab976-a6d3-44c2-bdce-51c3b6b0412c"
            };

            jokes.Add(joke);

            joke = new Joke()
            {
                Id = Guid.NewGuid(),
                Title = "Favorite PC Part",
                Setup = "What’s an astronaut’s favorite part of a computer?",
                Punchline = "The Space Bar!",
                JokeCategoryId = 7,
                UserId = "cfbab976-a6d3-44c2-bdce-51c3b6b0412c"
            };

            jokes.Add(joke);

            joke = new Joke()
            {
                Id = Guid.NewGuid(),
                Title = "Skeletons",
                Setup = "Why don't skeletons fight each other?",
                Punchline = "They don't have the guts!",
                JokeCategoryId = 8,
                UserId = "cfbab976-a6d3-44c2-bdce-51c3b6b0412c"
            };

            jokes.Add(joke);

            return jokes;
        }
    }
}
