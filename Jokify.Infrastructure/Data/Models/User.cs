namespace Jokify.Infrastructure.Data.Models
{
	using Microsoft.AspNetCore.Identity;

	public class User : IdentityUser
	{
        public string Role { get; set; }

        public List<Joke> Favorites { get; set; }

        public List<Joke> CreatedJokes { get; set; }
    }
}
