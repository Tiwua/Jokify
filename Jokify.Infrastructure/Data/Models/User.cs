namespace Jokify.Infrastructure.Data.Models
{
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
	{
        public User()
        {
            FavoriteJokes = new HashSet<Joke>();
            CreatedJokes = new HashSet<Joke>();
        }



        public ICollection<Joke> FavoriteJokes { get; set; }

        public ICollection<Joke> CreatedJokes { get; set; }
    }
}
