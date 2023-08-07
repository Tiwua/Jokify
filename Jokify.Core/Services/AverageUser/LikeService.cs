namespace Jokify.Core.Services.AverageUser
{
    using HouseRentingSystem.Infrastructure.Data.Common;
    using Jokify.Core.Contracts;
    using Jokify.Infrastructure.Data;
    using Jokify.Infrastructure.Data.Models;
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Jokify.Infrastructure.Data.Models.MappingTables;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class LikeService : ILikeService
    {
        private readonly IRepository repository;

        public LikeService(IRepository repository)
        {
            this.repository = repository;
        }


        public async Task<bool> HasLikedJoke(string title, string userId)
        {
            var joke = await repository.AllReadonly<Joke>()
                .Where(j => !j.IsDeleted)
                .Where(j => j.Title == title)
                .Include(j => j.UserFavoriteJokes)
                    .ThenInclude(ufj => ufj.User)
                .FirstAsync();

            var user = await repository.GetByIdAsync<User>(userId);

            if (joke.UserFavoriteJokes.Any(u => u.UserId == user.Id))
            {
                return true;
            }

            return false;
        }

        public async Task LikeJokeAsync(Guid id, string userId)
        {
            var user = await repository.All<User>()
                .Where(u => !u.IsDeleted)
                .Where(u => u.Id == userId)
                .Include(j => j.FavoriteJokes)
                    .ThenInclude(j => j.Joke)
                .FirstAsync();

            var userFavJoke = new UserFavoriteJoke()
            {
                UserId = userId,
                JokeId = id
            };

            if (user.FavoriteJokes.Any(fj => fj.UserId == userId && fj.JokeId == id))
            {
                return;
            }

            var joke = await repository.GetByIdAsync<Joke>(id);

            joke.LikesCount++;
            user.FavoriteJokes.Add(userFavJoke);
            joke.UserFavoriteJokes.Add(userFavJoke);

            await repository.AddAsync(userFavJoke);
            await repository.SaveChangesAsync();
        }
        public async Task DislikeJokeAsync(Guid id, string userId)
        {
            var user = await repository.All<User>()
                .Where(u => !u.IsDeleted)
                .Where(u => u.Id == userId)
                .Include(j => j.FavoriteJokes)
                    .ThenInclude(j => j.Joke)
                .FirstAsync();

            var userFavJoke = user.FavoriteJokes.FirstOrDefault(fj => fj.JokeId == id);

            if (userFavJoke == null)
            {
                return;
            }

            var joke = await repository.GetByIdAsync<Joke>(id);


            joke.LikesCount--;
            user.FavoriteJokes.Remove(userFavJoke);
            joke.UserFavoriteJokes.Remove(userFavJoke);

            repository.Delete(userFavJoke);
            await repository.SaveChangesAsync();
        }

        public async Task<int> GetLikesCount(Guid id)
        {
            var joke = await repository.GetByIdAsync<Joke>(id);

            return joke.LikesCount;
        }

    }
}
