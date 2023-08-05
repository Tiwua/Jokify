namespace Jokify.UnitTests.Services
{
    using HouseRentingSystem.Infrastructure.Data.Common;
    using Jokify.Common.Contracts;
    using Jokify.Core.Contracts;
    using Jokify.Core.Services.AverageUser;
    using Jokify.Infrastructure.Data;
    using Jokify.Infrastructure.Data.Models;
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Jokify.Infrastructure.Data.Models.MappingTables;
    using Jokify.UnitTests.Mock;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LikeServiceTests
    {
        private IRepository repository;
        private ILikeService likeService;
        private JokifyDbContext context;
        private Joke joke;
        private User user;

        [SetUp]
        public void Setup()
        {
            context = DbMock.Instance;

            joke = new Joke()
            {
                Id = new Guid("829046e9-9806-4886-907d-5950b73795e8"),
                Title = "Batman",
                Setup = "Where does Batman go to the bathroom?",
                Punchline = "The batroom.",
                UserId = "965a8773-bb8e-410e-a428-67798ffe2cda",
                JokeCategoryId = 2
            };

            user = new User()
            {
                Id = "965a8773-bb8e-410e-a428-67798ffe2cda",
                UserName = "testUser",
                Email = "test@gmail.com",

            };

            repository = new Repository(context);
            likeService = new LikeService(repository);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }


        [Test]
        public async Task LikeJokeWorksProperly()
        {
            //Arrange
            await repository.AddAsync(joke);
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            var userFavJoke = new UserFavoriteJoke()
            {
                UserId = "965a8773-bb8e-410e-a428-67798ffe2cda",
                JokeId = new Guid("829046e9-9806-4886-907d-5950b73795e8")
            };

            //Act

            await likeService.LikeJokeAsync(joke.Id, user.Id);
            //Assert

            var dbEntity = await repository.AllReadonly<UserFavoriteJoke>(ufj => ufj.UserId == user.Id && ufj.JokeId == joke.Id).FirstAsync();

            Assert.Multiple(() =>
            {
                Assert.That(dbEntity.UserId, Is.EqualTo(user.Id));
                Assert.That(dbEntity.JokeId, Is.EqualTo(joke.Id));
                Assert.That(user.FavoriteJokes, Has.Count.EqualTo(1));
                Assert.That(joke.UserFavoriteJokes, Has.Count.EqualTo(1));
                Assert.That(joke.LikesCount, Is.EqualTo(1));
            });    
        }

        [Test]
        public async Task LikeJokeWorksProperlyWhenUserHasAlreadyLiked()
        {
            //Arrange
            await repository.AddAsync(joke);
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            await likeService.LikeJokeAsync(joke.Id, user.Id);
            await repository.SaveChangesAsync();
       
            //Act
            await likeService.LikeJokeAsync(joke.Id, user.Id);

            //Assert

            Assert.Multiple(() =>
            {
                Assert.That(user.FavoriteJokes, Has.Count.EqualTo(1));
                Assert.That(joke.UserFavoriteJokes, Has.Count.EqualTo(1));
                Assert.That(joke.LikesCount, Is.EqualTo(1));
            });
        }

        [Test]
        public async Task DislikeJokeWorksProperly()
        {
            //Arrange
            await repository.AddAsync(joke);
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            await likeService.LikeJokeAsync(joke.Id, user.Id);
            await repository.SaveChangesAsync();

            var userFavJoke = new UserFavoriteJoke()
            {
                UserId = "965a8773-bb8e-410e-a428-67798ffe2cda",
                JokeId = new Guid("829046e9-9806-4886-907d-5950b73795e8")
            };

            //Act

            await likeService.DislikeJokeAsync(joke.Id, user.Id);
            //Assert

            var dbEntity = await repository.AllReadonly<UserFavoriteJoke>(ufj => ufj.UserId == user.Id && ufj.JokeId == joke.Id).FirstOrDefaultAsync();

            Assert.Multiple(() =>
            {
                Assert.That(dbEntity, Is.EqualTo(null));
                Assert.That(user.FavoriteJokes, Has.Count.EqualTo(0));
                Assert.That(joke.UserFavoriteJokes, Has.Count.EqualTo(0));
                Assert.That(joke.LikesCount, Is.EqualTo(0));
            });
        }

        [Test]
        public async Task DislikeDoesNothingWhenUserHasntLiked()
        {
            //Arrange
            await repository.AddAsync(joke);
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            var userFavJoke = new UserFavoriteJoke()
            {
                UserId = "965a8773-bb8e-410e-a428-67798ffe2cda",
                JokeId = new Guid("829046e9-9806-4886-907d-5950b73795e8")
            };

            //Act

            await likeService.DislikeJokeAsync(joke.Id, user.Id);
            //Assert

            var dbEntity = await repository.AllReadonly<UserFavoriteJoke>(ufj => ufj.UserId == user.Id && ufj.JokeId == joke.Id).FirstOrDefaultAsync();

            Assert.Multiple(() =>
            {
                Assert.That(dbEntity, Is.EqualTo(null));
                Assert.That(user.FavoriteJokes, Has.Count.EqualTo(0));
                Assert.That(joke.UserFavoriteJokes, Has.Count.EqualTo(0));
                Assert.That(joke.LikesCount, Is.EqualTo(0));
            });
        }

        [Test]
        public async Task HasUserLikedReturnsTrue()
        {
            //Arrange
            await repository.AddAsync(joke);
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            await likeService.LikeJokeAsync(joke.Id, user.Id);
            await repository.SaveChangesAsync();

            //Act

            var result = await likeService.HasLikedJoke(joke.Title, user.Id);
            //Assert

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(true));
                Assert.That(joke.LikesCount, Is.EqualTo(1));
            });
        }

        [Test]
        public async Task HasUserLikedReturnsFalse()
        {
            //Arrange
            await repository.AddAsync(joke);
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            //Act

            var result = await likeService.HasLikedJoke(joke.Title, user.Id);
            //Assert

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(false));
                Assert.That(joke.LikesCount, Is.EqualTo(0));
            });
        }

        [Test]
        public async Task GetLikesCountWorksProperly()
        {
            //Arrange
            joke.LikesCount += 10;
            await repository.AddAsync(joke);
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            //Act

            var result = await likeService.GetLikesCount(joke.Id);
            //Assert

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(10));
            });
        }
    }
}
