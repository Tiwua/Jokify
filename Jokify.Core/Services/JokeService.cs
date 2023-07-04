namespace Jokify.Common.Services
{
    using HouseRentingSystem.Infrastructure.Data.Common;
    using Jokify.Common.Contracts;
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

        public async Task AddJokeAsync(AddJokeViewModel model, string userId)
        {

            var joke = new Joke()
            {
                Title = model.Title,
                Setup = model.Setup,
                Punchline = model.Punchline,
                UserId = userId,
                JokeCategoryId = model.CategoryId
            };

            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();
        }

        public async Task<JokeQueryModel> GetAllJokesAsync(string? category = null, string? searchTerm = null, JokeSorting sorting = JokeSorting.PopularAscending, int currentPage = 1, int jokesPerPage = 6)
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

    }
}
