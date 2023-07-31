namespace Jokify.UnitTests.Services
{
    using HouseRentingSystem.Infrastructure.Data.Common;
    using Jokify.Common.Contracts;
    using Jokify.Core.Models.Joke;
    using Jokify.Core.Services.AverageUser;
    using Jokify.Infrastructure.Data;
    using Jokify.Infrastructure.Data.Models;
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Jokify.UnitTests.Mock;
    using Microsoft.Extensions.Logging;
    using Moq;
    using System;

    [TestFixture]
    public class JokeServiceTest
    {
        private IRepository repository;
        private IJokeService jokeService;
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

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task AddJokeWorksProperly()
        {
            var repo = new Repository(context);
            jokeService = new JokeService(repo, context);

            await repo.AddAsync(new Joke()
            {
                Id = new Guid("829046e9-9806-4886-907d-5950b73795e8"),
                Title = "Batman",
                Setup = "Where does Batman go to the bathroom?",
                Punchline = "The batroom.",
                UserId = "965a8773-bb8e-410e-a428-67798ffe2cda",
                JokeCategoryId = 2
            });

            await repo.SaveChangesAsync();

            var model = new JokeViewModel()
            {
                Title = "Batman",
                Setup = "Where does Batman go to the bathroom?",
                Punchline = "The batroom."
            };

            var jokeId = new Guid("829046e9-9806-4886-907d-5950b73795e8");

            await jokeService.EditJokeAsync(model, jokeId);

            var joke = await repo.GetByIdAsync<Joke>(jokeId);

            Assert.That(joke.IsEdited, Is.EqualTo(true));
        }
    }
}