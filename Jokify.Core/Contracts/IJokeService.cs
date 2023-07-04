namespace Jokify.Common.Contracts
{
    using Jokify.Core.Models.Joke;
    using Jokify.Core.Models.Joke.Enums;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IJokeService
    {
        public Task<JokeQueryModel> GetAllJokesAsync(
            string? category = null,
            string? searchTerm = null,
            JokeSorting sorting = JokeSorting.PopularAscending,
            int currentPage = 1,
            int jokesPerPage = 6);

        public Task AddJokeAsync(AddJokeViewModel model, string userId);
    }
}
