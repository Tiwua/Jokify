namespace Jokify.Core.Services
{
    using HouseRentingSystem.Infrastructure.Data.Common;
    using Jokify.Core.Contracts;
    using Jokify.Infrastructure.Data.Models;
    using Jokify.Infrastructure.Data.Models.JokeEntities;
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

        public CommentService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task AddCommentToJokeAsync(string title, string commentContent, string userId)
        {
            var joke = await repository.AllReadonly<Joke>()
                .Where(j => !j.IsDeleted)
                .Where(j => j.Title == title)
            .FirstAsync();

            if (commentContent == null)
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

        public async Task UpdateComment(Guid id, string content)
        {
            var commentToEdit = await repository.GetByIdAsync<Comment>(id);

            if (commentToEdit == null)
            {
                throw new ArgumentNullException(InvalidComment);
            }

            commentToEdit.Content = content;
            commentToEdit.IsEdited = true;

            await repository.SaveChangesAsync();
        }
    }
}
