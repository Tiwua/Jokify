namespace Jokify.Core.Services.Admin
{
	using HouseRentingSystem.Infrastructure.Data.Common;
	using Jokify.Core.Contracts.Admin;
	using Jokify.Core.Models.Admin;
	using Jokify.Infrastructure.Data.Models;
	using Microsoft.EntityFrameworkCore;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using static Jokify.Core.Common.Constants.Page;
	using static Jokify.Core.Common.Constants.Forgotten;
	using Microsoft.AspNetCore.Identity;
	using System.Security.Claims;
	using Jokify.Infrastructure.Data.Models.JokeEntities;
	using Jokify.Infrastructure.Data.Models.MappingTables;
	using Jokify.Infrastructure.Data;

	public class UserService : IUserService
	{
		private readonly IRepository repository;
		private readonly UserManager<User> userManager;
		private readonly JokifyDbContext context;

		public UserService(
			IRepository repository,
			UserManager<User> userManager,
			JokifyDbContext context)
		{
			this.repository = repository;
			this.userManager = userManager;
			this.context = context;
		}

		public async Task<UserViewModel[]> AllUsersAsync(string userId)
		{
			var users = await repository.AllReadonly<User>()
				.Where(u => u.Id != userId)
				.Select(u => new UserViewModel()
				{
					UserId = u.Id,
					Email = u.Email,
					IsDeleted = u.IsDeleted,
					Username = u.UserName
				}).ToArrayAsync();

			return users;
		}

		public UserPageModel AllUsersPaginated(UserViewModel[] users, int currentPage)
		{
			var paginatedUsers = users.Skip((currentPage - 1) * UsersPerPage)
				.Take(UsersPerPage)
				.ToHashSet();

			var result = paginatedUsers.Select(u => new UserPageModel
			{
				CurrentPage = currentPage,
				PageSize = UsersPerPage,
				TotalUsers = users.Length,
				TotalPages = (int)Math.Ceiling((double)users.Length / UsersPerPage),
				Users = paginatedUsers
			}).First();

			return result;
		}

		public async Task DeleteUserAsync(string id)
		{
			var user = await repository.GetByIdAsync<User>(id);

			user.IsDeleted = true;
		}

		public async Task<bool> ForgetUserAsync(string id)
		{
			var user = await context.Users
				.Where(u => u.Id == id)
				.Include(c => c.CreatedComments)
				.Include(j => j.CreatedJokes)
					
				.FirstAsync();

			var isAdmin = await userManager.IsInRoleAsync(user, "Admin");

			if (isAdmin)
			{
				return false;
			}

			user.PhoneNumber = null;
			user.Email = ForgottenEmail;
			user.IsDeleted = true;
			user.NormalizedEmail = null;
			user.NormalizedUserName = null;
			user.PasswordHash = null;
            user.CreatedJokes.Clear();
			user.CreatedComments.Clear();

			
		    repository.DeleteRange<UserJoke>(user.CreatedJokes);


			var result = await userManager.UpdateAsync(user);

			var error = result.Errors;
			
			return result.Succeeded;
		}
	}
}
