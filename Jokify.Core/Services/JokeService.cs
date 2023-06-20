namespace Jokify.Common.Services
{
    using HouseRentingSystem.Infrastructure.Data.Common;
    using Jokify.Common.Contracts;
    using Jokify.Core.Models.Joke;
    using Jokify.Infrastructure.Data;
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Jokify.Infrastructure.Data.Models.MappingTables;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class JokeService : IJokeService
    {
        private readonly IRepository repository;

        public JokeService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task AddJokeAsync(AddJokeViewModel model, string userId)
        {
            var joke = new Joke()
            {
                Setup = model.Setup,
                Punchline = model.Punchline,
                UserId = userId
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
    }
}
