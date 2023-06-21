namespace Jokify.Common.Contracts
{
    using Jokify.Core.Models.Joke;
    using Jokify.Infrastructure.Data.Models.MappingTables;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IJokeService
    {
        public Task<IEnumerable<JokeCategoryViewModel>> GetAllCategoriesAsync();

        public Task<IEnumerable<JokeViewModel>> GetAllJokesAsync();

        public Task AddJokeAsync(AddJokeViewModel model, string userId);
    }
}
