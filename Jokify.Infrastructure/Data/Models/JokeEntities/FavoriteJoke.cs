namespace Jokify.Infrastructure.Data.Models.Joke.Joke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Jokify.Infrastructure.Data.Models.Joke;

    public class FavoriteJoke
    {
        // Composite primary key
        public int UserId { get; set; }
        public int JokeId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Joke Joke { get; set; }
    }
}
