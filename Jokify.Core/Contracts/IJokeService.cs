﻿namespace Jokify.Common.Contracts
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

        public Task<bool> Exists(int id);

        public Task<JokeDetailsViewModel> JokeDetailsByTitle(string title);

        public Task AddCommentToJokeAsync(string title, string commentContent, string userId);
    }
}
