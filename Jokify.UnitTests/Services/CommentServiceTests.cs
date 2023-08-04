namespace Jokify.UnitTests.Services
{
    using HouseRentingSystem.Infrastructure.Data.Common;
    using Jokify.Core.Contracts;
    using Jokify.Core.Services.AverageUser;
    using Jokify.Infrastructure.Data;
    using Jokify.Infrastructure.Data.Models;
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Jokify.UnitTests.Mock;
    using Microsoft.AspNetCore.Identity;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommentServiceTests
    {
        private IRepository repository;
        private ICommentService commentService;
        private Mock<UserManager<User>> userManager;
        private JokifyDbContext context;
        private Joke joke;
        private User user;

        [SetUp]
        public void Setup()
        {
            context = DbMock.Instance;

            repository = new Repository(context);
            var userStore = new Mock<IUserStore<User>>();
            userManager = new Mock<UserManager<User>>(userStore.Object, null, null, null, null, null, null, null, null);
            userManager.Setup(m => m.IsInRoleAsync(It.IsAny<User>(), It.IsAny<string>()))
                   .ReturnsAsync(false);

            commentService = new CommentService(repository, userManager.Object);

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
        public async Task AddCommentToJokeWorksProperly()
        {
            //Arrange

            DateTime date = DateTime.ParseExact("2023-08-01 01:52:14","yyyy-M-d h:m:ss", CultureInfo.InvariantCulture);

            var comment = new Comment()
            {
                Id = new Guid("f909f97e-49b3-4fd5-96ee-e8330d2d9763"),
                Content = "test comment",
                UserId = user.Id,
                JokeId = joke.Id,
                CreatedOn = date

            };

            await repository.AddAsync(user);
            await repository.AddAsync(joke);
            await repository.AddAsync(comment);
            //Act

            await commentService.AddCommentToJokeAsync(joke.Title, comment.Content, user.Id);

            //Assert
        }
    }
}
