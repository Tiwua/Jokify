﻿namespace Jokify.Core.Contracts
{
    using Jokify.Infrastructure.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICommentService
    {
        public Task AddCommentToJokeAsync(string title, string commentContent, string userId);

        public Task<bool> HasUserCommentedAsync(string title, string userId);

        public Task UpdateComment(Guid id, string content, UserManager<User> userManager);

        Task DeleteCommentAsync(Guid id, string userId, Guid jokeId);

        Task<bool> ExistsAsync(Guid id);

		Task RemoveCommentsByUserAsync(string id);
	}
}
