namespace Jokify.Infrastructure.Data.Models
{
	using Microsoft.AspNetCore.Identity;

	public class User : IdentityUser
	{
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public int MyProperty { get; set; }
    }
}
