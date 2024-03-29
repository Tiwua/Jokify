﻿namespace Jokify.Core.Services.AverageUser
{
	using Jokify.Infrastructure.Data.Common;
	using Jokify.Common.Contracts;
	using Jokify.Core.Models.Admin;
	using Jokify.Core.Models.Comment;
	using Jokify.Core.Models.Joke;
	using Jokify.Core.Models.Joke.Enums;
	using Jokify.Infrastructure.Data;
	using Jokify.Infrastructure.Data.Models;
	using Jokify.Infrastructure.Data.Models.JokeEntities;
	using Jokify.Infrastructure.Data.Models.MappingTables;
	using Microsoft.EntityFrameworkCore;
	using System;
	using System.Collections.Generic;
	using System.Collections.Immutable;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using static Jokify.Core.Common.Constants.Page;
	public class JokeService : IJokeService
	{
		private readonly IRepository repository;

		public JokeService(IRepository repository)
		{
			this.repository = repository;
		}

		public async Task AddJokeAsync(JokeViewModel model, string userId)
		{
			var user = await repository.GetByIdAsync<User>(userId);
			var joke = await repository.AllReadonly<Joke>()
				.Where(j => !j.IsDeleted)
				.Where(j => j.Title == model.Title)
				.FirstOrDefaultAsync();

			if (joke != null)
			{
				throw new ArgumentException("Cannot have multiple jokes with the same Title");
			}

			var newJoke = new Joke()
			{
				Title = model.Title,
				Setup = model.Setup,
				Punchline = model.Punchline,
				UserId = userId,
				JokeCategoryId = model.CategoryId
			};


			var userJoke = new UserJoke
			{
				UserId = userId,
				JokeId = newJoke.Id
			};

			user.CreatedJokes.Add(userJoke);

			await repository.AddAsync(newJoke);
			await repository.AddAsync(userJoke);
			await repository.SaveChangesAsync();
		}

		public async Task<bool> ExistsAsync(Guid id)
		{
			return await repository.AllReadonly<Joke>().AnyAsync(j => j.Id == id);
		}

		public async Task<JokeQueryModel> GetAllJokesAsync(
			string? userId = null,
			string? category = null,
			string? searchTerm = null,
			JokeSorting sorting = JokeSorting.PopularDescending,
			int currentPage = CurrentPage,
			int jokesPerPage = JokesPerPage)
		{

			var result = new JokeQueryModel();
			var jokes = repository.AllReadonly<Joke>()
				.Where(j => !j.IsDeleted);

			if (userId != null)
			{
				jokes = jokes.Where(j => j.UserId == userId);
			}

			if (!string.IsNullOrEmpty(category))
			{
				jokes = jokes.Where(j => j.Category.Name == category);
			}

			if (!string.IsNullOrEmpty(searchTerm))
			{
				searchTerm = $"%{searchTerm.ToLower()}%";

				jokes = jokes
					.Where(j => EF.Functions.Like(j.Title.ToLower(), searchTerm) ||
					EF.Functions.Like(j.Setup.ToLower(), searchTerm) ||
					EF.Functions.Like(j.Punchline.ToLower(), searchTerm));
			}

			jokes = sorting switch
			{
				JokeSorting.PopularAscending => jokes
					 .OrderBy(j => j.LikesCount),
				JokeSorting.PopularDescending => jokes
					 .OrderByDescending(j => j.LikesCount),
				JokeSorting.Title => jokes
					 .OrderBy(j => j.Title),
				_ => jokes.OrderByDescending(j => j.Id)
			};

			result.Jokes = await jokes
				.Skip((currentPage - 1) * jokesPerPage)
				.Take(jokesPerPage)
				.Where(j => !j.IsDeleted)
				.Select(j => new JokeServiceModel()
				{
					Id = j.Id,
					Title = j.Title,
					Setup = j.Setup,
					Punchline = j.Punchline,
					IsPopular = j.IsPopular,
					IsEdited = j.IsEdited,
					IsDeleted = j.IsDeleted,
				}).ToListAsync();

			result.JokesCount = jokes.Count();

			return result;
		}

		public async Task<JokeDetailsViewModel> JokeDetailsByTitle(string title, int currentPage, bool hasCommented, bool hasLiked, string userId)
		{
			var comments = await repository.AllReadonly<Comment>()
				.Where(c => !c.IsDeleted)
				.Where(c => c.Joke.Title == title)
					.Include(u => u.User)
					.OrderByDescending(c => c.CreatedOn)
				.ToListAsync();

			var user = await repository.AllReadonly<User>()
				.Where(u => !u.IsDeleted)
				.Where(u => u.Id == userId)
				.FirstAsync();

			bool isUserOwner = false;
			if (comments.Any(c => c.UserId == userId))
			{
				isUserOwner = true;
			}

			var paginatedComments = comments.Skip((currentPage - 1) * CommentsPerPage)
				.Take(CommentsPerPage)
				.ToHashSet();

			var commentModel = paginatedComments
					.Where(c => !c.IsDeleted)
					.Select(c => new CommentViewModel()
					{
						Id = c.Id,
						Content = c.Content,
						CreatedOn = c.CreatedOn.ToString(),
						User = c.User.UserName,
						UserId = c.UserId,
						IsUserOwner = isUserOwner,
						IsEdited = c.IsEdited
					}).ToHashSet();

			var result = await repository.AllReadonly<Joke>()
				.Where(j => !j.IsDeleted)
				.Where(j => j.Title == title)
				.Select(j => new JokeDetailsViewModel()
				{
					Id = j.Id,
					Title = j.Title,
					Setup = j.Setup,
					Punchline = j.Punchline,
					IsEdited = j.IsEdited,
					HasUserCommented = hasCommented,
					LikesCount = j.LikesCount,
					OwnerName = j.User.UserName,
					CurrUser = userId,
					CurrentPage = currentPage,
					TotalPages = (int)Math.Ceiling((double)comments.Count / CommentsPerPage),
					PageSize = CommentsPerPage,
					TotalComments = comments.Count,
					Comments = commentModel
				}).FirstAsync();

			return result;
		}

		public async Task<JokeViewModel> GetJokeById(Guid id)
		{
			return await repository.AllReadonly<Joke>()
				.Where(j => !j.IsDeleted)
				.Where(j => j.Id == id)
				.Select(j => new JokeViewModel()
				{
					Punchline = j.Punchline,
					Setup = j.Setup,
					Title = j.Title
				}).FirstAsync();
		}

		public async Task EditJokeAsync(JokeViewModel model, Guid jokeId)
		{
			var joke = await repository.GetByIdAsync<Joke>(jokeId);

			joke.Title = model.Title;
			joke.Setup = model.Setup;
			joke.Punchline = model.Punchline;
			joke.IsEdited = true;

			await repository.SaveChangesAsync();
		}

		public async Task DeleteJokeAsync(string userId, Guid jokeId, bool isAdmin)
		{
			var joke = await repository.GetByIdAsync<Joke>(jokeId);

			if (joke == null)
			{
				throw new ArgumentNullException("Invalid joke!");
			}

			if(joke.UserId != userId && !isAdmin)
			{
				throw new ArgumentException("You are not the owner of this joke!");
			}

			joke.IsDeleted = true;

			var user = await repository.GetByIdAsync<User>(userId);

			var userJoke = new UserJoke()
			{
				JokeId = joke.Id,
				UserId = userId,
			};

			user.CreatedJokes.Remove(userJoke);

			await repository.SaveChangesAsync();
		}

		public async Task<IEnumerable<JokeHomeView>> GetThreeMostPopularJokes()
		{
			return await repository.AllReadonly<Joke>()
				.Where(j => !j.IsDeleted)
				.GroupBy(j => j.Category.Name)
				.Select(j => new JokeHomeView()
				{
					Category = j.Key,
					Count = j.Count()
				})
				.OrderByDescending(j => j.Count)
				.ThenBy(j => j.Category)
				.Take(3)
				.ToListAsync();
		}

		public async Task<bool> ExistsByTitleAsync(string title)
		{
			var jokeExists = await repository.AllReadonly<Joke>()
				.Where(j => !j.IsDeleted)
				.Where(j => j.Title == title)
				.FirstOrDefaultAsync();

			if (jokeExists == null)
			{
				return false;
			}

			return true;
		}

		public JokeViewModel GetJokeForEdit(JokeViewModel joke)
		{
			var model = new JokeViewModel()
			{
				Title = joke.Title,
				Setup = joke.Setup,
				Punchline = joke.Punchline,
				IsEdited = joke.IsEdited,
				IsEditMode = true
			};

			return model;
		}

		public async Task<AdminJokeHomeView> GetAllJokesCountAsync()
		{
			var jokes = await repository.AllReadonly<Joke>().Where(j => !j.IsDeleted).CountAsync();

			var jokesCount = new AdminJokeHomeView()
			{
				JokesCount = jokes
			};

			return jokesCount;
		}

		//public async Task<JokeViewModel> GetRandomJoke(string category)
		//{
		//    Random random = new Random();
		//    var jokes = await repository.AllReadonly<Joke>();

		//    int index = random.Next(jokes.Length);

		//    return jokes[index];
		//}
	}
}
