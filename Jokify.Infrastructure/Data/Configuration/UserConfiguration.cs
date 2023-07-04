namespace Jokify.Infrastructure.Data.Configuration
{
	using Jokify.Infrastructure.Data.Models;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	internal class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasData(SeedUsers());
		
		}

		private static HashSet<User> SeedUsers()
		{
			var users = new HashSet<User>();

			var hasher = new PasswordHasher<User>();

			var user = new User()
			{
				Id = "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
				UserName = "admin",
				NormalizedUserName = "ADMIN",
				Email = "admin@gmail.com",
				NormalizedEmail = "ADMIN@GMAIL.COM",
			};

			user.PasswordHash = hasher.HashPassword(user, "admin123");
			users.Add(user);

		    user = new User()
			{
				Id = "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
				UserName = "someone",
				NormalizedUserName = "SOMEONE",
				Email = "someone@gmail.com",
				NormalizedEmail = "SOMEONE@GMAIL.COM",
			};

			user.PasswordHash = hasher.HashPassword(user, "someone123");
			users.Add(user);

			return users;
		}
	}
}
