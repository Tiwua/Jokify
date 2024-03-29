﻿namespace Jokify.Core.Services.AverageUser
{
    using Jokify.Infrastructure.Data.Common;
    using Jokify.Core.Contracts;
    using Jokify.Infrastructure.Data.Models;
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static Jokify.Core.Common.Constants.Error;

    public class CommentService : ICommentService
    {
        private readonly IRepository repository;
        private readonly UserManager<User> userManager;

        public CommentService(
            IRepository repository,
            UserManager<User> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;

        }

        public async Task AddCommentToJokeAsync(string title, string commentContent, string userId)
        {
            var joke = await repository.AllReadonly<Joke>()
                .Where(j => !j.IsDeleted)
                .Where(j => j.Title == title)
                .FirstAsync();

            if (string.IsNullOrWhiteSpace(commentContent))
            {
                return;
            }

            var user = await repository.GetByIdAsync<User>(userId);

            var date = DateTime.Now.ToString("F");

            var comment = new Comment()
            {
                Content = commentContent,
                CreatedOn = DateTime.Parse(date),
                JokeId = joke.Id,
                UserId = userId
            };

            var jokeComment = new JokeComment()
            {
                JokeId = joke.Id,
                CommentId = comment.Id
            };

            joke.Comments.Add(comment);

            await repository.AddAsync(jokeComment);
            await repository.AddAsync(comment);
            await repository.SaveChangesAsync();
        }

        public async Task<bool> HasUserCommentedAsync(string title, string userId)
        {
            var joke = await repository.AllReadonly<Joke>()
                .Where(j => !j.IsDeleted)
                .Where(j => j.Title == title)
                .Include(j => j.Comments)
                .FirstAsync();

            if (joke.Comments.Any(u => u.UserId == userId))
            {
                return true;
            }

            return false;
        }

        public async Task UpdateComment(Guid id, string content, UserManager<User> manager)
        {
            var commentToEdit = await repository.GetByIdAsync<Comment>(id);

            if (commentToEdit == null)
            {
                throw new ArgumentNullException(InvalidComment);
            }

            if (commentToEdit.Content == content)
            {
                throw new ArgumentException(SameComment);
            }

            commentToEdit.Content = content;
            commentToEdit.IsEdited = true;

            await repository.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(Guid id, string userId, Guid jokeId)
        {
            var comment = await repository.GetByIdAsync<Comment>(id);

            if (comment.UserId != userId)
            {
                return;
            }

            comment.IsDeleted = true;
            var user = await repository.GetByIdAsync<User>(userId);
            var joke = await repository.GetByIdAsync<Joke>(jokeId);

            user.CreatedComments.Remove(comment);
            joke.Comments.Remove(comment);

            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await repository.AllReadonly<Comment>().AnyAsync(c => c.Id == id);
        }

		public async Task RemoveCommentsByUserAsync(string id)
		{
            var user = await repository.All<User>().Where(u => u.Id == id).FirstAsync();

            var isAdmin = await userManager.IsInRoleAsync(user, "Admin");
            if (isAdmin)
            {
                return;
            }

            var userComments = await repository.All<Comment>().Where(c => c.UserId == id).Include(u => u.User).ToListAsync();

            if (userComments.Count == 0)
            {
                return;
            }

            foreach (var comment in userComments)
            {
                comment.IsDeleted = true;
            }

            await repository.SaveChangesAsync();
		}
	}
}
