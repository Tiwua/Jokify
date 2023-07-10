namespace Jokify.Common.Services
{
    using HouseRentingSystem.Infrastructure.Data.Common;
    using Jokify.Common.Contracts;
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

    public class JokeService : IJokeService
    {
        private readonly IRepository repository;
        private readonly JokifyDbContext context;

        public JokeService(IRepository repository, JokifyDbContext context)
        {
            this.repository = repository;
            this.context = context;
        }

        public async Task AddCommentToJokeAsync(string title, string commentContent, string userId)
        {
            var joke = await repository.AllReadonly<Joke>()
                .Where(j => !j.IsDeleted)
                .Where(j => j.Title == title)
                .FirstAsync();

            if (commentContent == null)
            {
                return;
            }

            var user = await repository.GetByIdAsync<User>(userId);

            var date = DateTime.Now.ToString("F");

            var comment = new Comment()
            {
                Content = commentContent,
                CreatedOn = DateTime.Parse(date),
                JokeId = joke.Id,
                UserId = userId
            };

            await context.JokesComments.AddAsync(new JokeComment()
            {
                JokeId = joke.Id,
                CommentId = comment.Id
            });

            joke.Comments.Add(comment);
            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();

        }

        public async Task AddJokeAsync(AddJokeViewModel model, string userId)
        {
            var user = await repository.GetByIdAsync<User>(userId);
            var joke = await repository.GetByTitleAsync<Joke>(model.Title);

            if (joke == null)
            {
                throw new ArgumentException("Cannot have multiple jokes with the same Title");
            }

            joke = new Joke()
            {
                Title = model.Title,
                Setup = model.Setup,
                Punchline = model.Punchline,
                UserId = userId,
                JokeCategoryId = model.CategoryId
            };



            user.CreatedJokes.Add(new UserJoke
            {
                User = user,
                UserId = userId,
                Joke = joke,
                JokeId = joke.Id
            });

            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<JokeQueryModel> GetAllJokesAsync(string? category = null, string? searchTerm = null, JokeSorting sorting = JokeSorting.PopularDescending, int currentPage = 1, int jokesPerPage = 6)
        {
            var result = new JokeQueryModel();
            var jokes = repository.AllReadonly<Joke>()
                .Where(j => !j.IsDeleted);

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
                     .OrderBy(j => j.FavoriteJokes.Count()),
                JokeSorting.PopularDescending => jokes
                     .OrderByDescending(j => j.FavoriteJokes.Count()),
                JokeSorting.Title => jokes
                     .OrderBy(j => j.Title),
                _ => jokes.OrderByDescending(j => j.Id)
            };

            result.Jokes = await jokes
                .Skip((currentPage - 1) * jokesPerPage)
                .Take(jokesPerPage)
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

            result.JokesCount = await jokes.CountAsync();

            return result;
        }

        public async Task<JokeDetailsViewModel> JokeDetailsByTitle(string title, int currentPage)
        {
            var comments = await repository.AllReadonly<Comment>()
                .Where(c => !c.IsDeleted)
                .Where(c => c.Joke.Title ==  title)
                .ToListAsync();

            var comment = comments.First();
            var user = await repository.AllReadonly<User>().Where(u => !u.IsDeleted).Where(u => u.Id == comment.UserId).FirstAsync();

            var paginatedComments = comments.Skip((currentPage - 1) * 1).Take(1).ToHashSet();

            var commentModel = paginatedComments
                    .Select(c => new CommentViewModel()
                    {
                        Content = c.Content,
                        CreatedOn = c.CreatedOn.ToString(),
                        User = user.UserName,
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
                    IsPopular = j.IsPopular,
                    IsEdited = j.IsEdited,
                    OwnerName = j.User.UserName,
                    CurrentPage = currentPage,
                    TotalPages = (int)Math.Ceiling((double)comments.Count / 1),
                    PageSize = 1,
                    TotalComments = comments.Count,
                    Comments = commentModel
                }).FirstAsync();

            ;

            return result;
        }
    }
}
