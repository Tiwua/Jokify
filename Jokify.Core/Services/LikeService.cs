﻿namespace Jokify.Core.Services
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
        private readonly JokifyDbContext context;

        public LikeService(IRepository repository, JokifyDbContext context)
        {
            this.repository = repository;
            this.context = context;
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
            var joke = await repository.GetByIdAsync<Joke>(id);

            var user = await repository.GetByIdAsync<User>(userId);

            var userFavJoke = new UserFavoriteJoke()
            {
                UserId = userId,
                JokeId = joke.Id
            };

            if (user.FavoriteJokes.Contains(userFavJoke))
            {
                return;
            }

            joke.LikesCount++;
            user.FavoriteJokes.Add(userFavJoke);

            await repository.AddAsync(userFavJoke);
            await repository.SaveChangesAsync();
        }
        public async Task DislikeJokeAsync(Guid id, string userId)
        {
            var joke = await repository.GetByIdAsync<Joke>(id);

            var user = await context.Users
                .Where(u => !u.IsDeleted)
                .Where(u => u.Id == userId)
                .Include(j => j.FavoriteJokes)
                    .ThenInclude(j => j.Joke)
                .FirstAsync();

            var userFavJoke = await context.UsersFavoritesJokes.Where(u => u.UserId == userId && u.JokeId == id).FirstAsync();

            if (!user.FavoriteJokes.Contains(userFavJoke))
            {
                return;
            }

            joke.LikesCount--;
            user.FavoriteJokes.Remove(userFavJoke);
            joke.UserFavoriteJokes.Remove(userFavJoke);

            context.UsersFavoritesJokes.Remove(userFavJoke);
            await context.SaveChangesAsync();
        }

        public async Task<int> GetLikesCount(Guid id)
        {
            var joke = await repository.GetByIdAsync<Joke>(id);

            return joke.LikesCount;
        }

    }
}
