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
            string? category = null,
            string? searchTerm = null,
            JokeSorting sorting = JokeSorting.PopularAscending,
            int currentPage = CurrentPage,
            int jokesPerPage = EntitiesPerPage);

        public Task AddJokeAsync(JokeViewModel model, string userId);
        public Task EditJokeAsync(JokeViewModel model, Guid jokeId);

        public Task<bool> Exists(int id);

        public Task<JokeDetailsViewModel> JokeDetailsByTitle(
            string title, 
            int currentPage,
            bool hasCommented, 
            bool hasLiked, 
            string userId);

        Task<JokeViewModel> GetJokeById(Guid id);    
    }
}
