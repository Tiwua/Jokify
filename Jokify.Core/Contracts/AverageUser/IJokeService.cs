namespace Jokify.Common.Contracts
{
    using Jokify.Core.Models.Joke;
    using Jokify.Core.Models.Joke.Enums;
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static Jokify.Core.Common.Constants.Page;
    public interface IJokeService
    {
        public Task<JokeQueryModel> GetAllJokesAsync(
            string? userId = null,
            string? category = null,
            string? searchTerm = null,
            JokeSorting sorting = JokeSorting.PopularAscending,
            int currentPage = CurrentPage,
            int jokesPerPage = JokesPerPage);

        public Task AddJokeAsync(JokeViewModel model, string userId);

        public Task EditJokeAsync(JokeViewModel model, Guid jokeId);

        public Task<bool> ExistsAsync(Guid id);

        public Task<bool> ExistsByTitleAsync(string title);

        public Task<JokeDetailsViewModel> JokeDetailsByTitle(
            string title, 
            int currentPage,
            bool hasCommented, 
            bool hasLiked, 
            string userId);

        Task<JokeViewModel> GetJokeById(Guid id);

        Task<IEnumerable<JokeServiceModel>> AllJokesByUser(string userId);

        Task DeleteJokeAsync(string userId, Guid jokeId);

        Task<IEnumerable<JokeHomeView>> GetThreeMostPopularJokes();

        JokeViewModel GetJokeForEdit(JokeViewModel joke);

        //Task<JokeViewModel> GetRandomJoke();
    }
}
