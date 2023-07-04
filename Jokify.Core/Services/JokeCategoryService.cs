namespace Jokify.Core.Services
{
    using HouseRentingSystem.Infrastructure.Data.Common;
    using Jokify.Core.Contracts;
    using Jokify.Core.Models.Joke;
    using Jokify.Infrastructure.Data.Models.MappingTables;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class JokeCategoryService : IJokeCategoryService
    {
        private readonly IRepository repository;

        public JokeCategoryService(IRepository repository)
        {
            this.repository = repository;
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

        public async Task<IEnumerable<string>> GetAllCategoriesNamesAsync()
        {
            return await repository.AllReadonly<JokeCategory>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }
    }
}
