namespace Jokify.Common.Services
{
    using HouseRentingSystem.Infrastructure.Data.Common;
    using Jokify.Common.Contracts;
    using Jokify.Core.Models.Joke;
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
                Setup = model.Setup,
                Punchline = model.Punchline,
                UserId = userId,
                JokeCategoryId = model.CategoryId
            };

            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<JokeCategoryViewModel>> GetAllCategoriesAsync()
        {
            return await repository.AllReadonly<JokeCategory>()
                .Select(c => new JokeCategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

        public async Task<IEnumerable<JokeViewModel>> GetAllJokesAsync()
        {
            return await context.Jokes
                .Select(j => new JokeViewModel()
            {
                Id = j.Id.ToString(),
                Setup = j.Setup,
                Punchline = j.Punchline,
                Owner = j.User.UserName,
                Category = j.Category.ToString()!,
                LikesCount = j.FavoriteJokes.Count()
            }).ToListAsync();
        }
    }
}
