namespace Jokify.UnitTests.Services
{
    using HouseRentingSystem.Infrastructure.Data.Common;
    using Jokify.Core.Contracts;
    using Jokify.Core.Services.AverageUser;
    using Jokify.Infrastructure.Data;
    using Jokify.Infrastructure.Data.Models;
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Jokify.UnitTests.Mock;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Claims;
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
        private User adminUser;

        [SetUp]
        public void Setup()
        {
            context = DbMock.Instance;

            repository = new Repository(context);
            var userStore = new Mock<IUserStore<User>>();

            adminUser = new User
            {
                Id = "12bab976-a6d3-44c2-bdce-51c3b6b0412c",
                UserName = "adminUser",
                Email = "admin@example.com"
            };

            userManager = new Mock<UserManager<User>>(userStore.Object, null, null, null, null, null, null, null, null);
            userManager.Setup(m => m.IsInRoleAsync(adminUser, "Admin"))
                       .ReturnsAsync(true);

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
            var content = "test comment";

            await repository.AddAsync(user);
            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();

            //Act
            await commentService.AddCommentToJokeAsync(joke.Title, content, user.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(joke.Comments.Count, Is.EqualTo(1));
                Assert.That(joke.Comments.First().Content, Is.EqualTo(content));
            });
        }

        [Test]
        public async Task AddCommentToJokeWorksProperlyWithNullContent()
        {
            //Arrange
            await repository.AddAsync(user);
            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();

            //Act
            await commentService.AddCommentToJokeAsync(joke.Title, null, user.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(joke.Comments.Count, Is.EqualTo(0));
                Assert.That(user.CreatedComments.Count, Is.EqualTo(1));
            });
        }

        [Test]
        public async Task AddCommentToJokeWorksProperlyWithWhitespaceContent()
        {
            //Arrange
            await repository.AddAsync(user);
            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();

            //Act
            await commentService.AddCommentToJokeAsync(joke.Title, " ", user.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(joke.Comments.Count, Is.EqualTo(0));
            });
        }

        [Test]
        public async Task HasUserCommentedReturnsTrue()
        {
            //Arrange
            await repository.AddAsync(user);
            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();

            await commentService.AddCommentToJokeAsync(joke.Title, "test comment", user.Id);
            await repository.SaveChangesAsync();

            //Act
            var result = await commentService.HasUserCommentedAsync(joke.Title, user.Id);

            //Assert

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public async Task HasUserCommentedReturnsFalse()
        {
            //Arrange
            await repository.AddAsync(user);
            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();

            //Act
            var result = await commentService.HasUserCommentedAsync(joke.Title, user.Id);

            //Assert

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public async Task DeleteCommentWorksProperly()
        {
            //Arrange
            string dateString = "2023-08-01 01:52:14";
            string format = "yyyy-MM-dd HH:mm:ss";
            DateTime date = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);

            await repository.AddAsync(user);
            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();

            var comment = new Comment()
            {
                Id = new Guid("f909f97e-49b3-4fd5-96ee-e8330d2d9763"),
                Content = "text content",
                UserId = user.Id,
                JokeId = joke.Id,
                CreatedOn = date

            };

            await repository.AddAsync(comment);
            await repository.SaveChangesAsync();

            //Act
            await commentService.DeleteCommentAsync(comment.Id, user.Id, joke.Id);

            //Assert

            Assert.Multiple(() =>
            {
                Assert.That(comment.IsDeleted, Is.EqualTo(true));
                Assert.That(joke.Comments.Count, Is.EqualTo(0));
                Assert.That(user.CreatedComments.Count, Is.EqualTo(0));
            });
        }

        [Test]
        public async Task DeleteCommentDoesNothingWithWrongUserId()
        {
            //Arrange
            string dateString = "2023-08-01 01:52:14";
            string format = "yyyy-MM-dd HH:mm:ss";
            DateTime date = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);

            await repository.AddAsync(user);
            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();

            var comment = new Comment()
            {
                Id = new Guid("f909f97e-49b3-4fd5-96ee-e8330d2d9763"),
                Content = "text content",
                UserId = user.Id,
                JokeId = joke.Id,
                CreatedOn = date

            };

            await repository.AddAsync(comment);
            await repository.SaveChangesAsync();

            //Act
            await commentService.DeleteCommentAsync(comment.Id, "965a8773-1234-410e-a428-67798ffe2cda", joke.Id);

            //Assert

            Assert.Multiple(() =>
            {
                Assert.That(comment.IsDeleted, Is.EqualTo(false));
                Assert.That(joke.Comments.Count, Is.EqualTo(1));
                Assert.That(user.CreatedComments.Count, Is.EqualTo(1));
            });
        }

        [Test]
        public async Task ExistsReturnsTrueProperly()
        {
            //Arrange
            string dateString = "2023-08-01 01:52:14";
            string format = "yyyy-MM-dd HH:mm:ss";
            DateTime date = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);

            await repository.AddAsync(user);
            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();

            var comment = new Comment()
            {
                Id = new Guid("f909f97e-49b3-4fd5-96ee-e8330d2d9763"),
                Content = "text content",
                UserId = user.Id,
                JokeId = joke.Id,
                CreatedOn = date

            };

            await repository.AddAsync(comment);
            await repository.SaveChangesAsync();

            //Act
            var result = await commentService.ExistsAsync(comment.Id);

            //Assert
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public async Task ExistsReturnsFalseProperly()
        {
            //Arrange
            string dateString = "2023-08-01 01:52:14";
            string format = "yyyy-MM-dd HH:mm:ss";
            DateTime date = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);

            var comment = new Comment()
            {
                Id = new Guid("f909f97e-49b3-4fd5-96ee-e8330d2d9763"),
                Content = "text content",
                UserId = user.Id,
                JokeId = joke.Id,
                CreatedOn = date

            };

            //Act
            //The comment doesnt exist in the context so the id is invalid
            var result = await commentService.ExistsAsync(comment.Id);

            //Assert
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public async Task RemoveCommentsByUserWorksProperly()
        {
            //Arrange
            string dateString = "2023-08-01 01:52:14";
            string format = "yyyy-MM-dd HH:mm:ss";
            DateTime date = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);

            await repository.AddAsync(user);
            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();

            var comment = new Comment()
            {
                Id = new Guid("f909f97e-49b3-4fd5-96ee-e8330d2d9763"),
                Content = "text content",
                UserId = user.Id,
                JokeId = joke.Id,
                CreatedOn = date

            };

            var secondComment = new Comment()
            {
                Id = new Guid("f909f97e-1253-4fd5-96ee-e8330d2d9763"),
                Content = "text content again",
                UserId = user.Id,
                //JokeId taken from db seed
                JokeId = new Guid("996AB34D-316B-414E-AF7A-013EEEEEEEBA"),
                CreatedOn = date

            };

            await repository.AddAsync(comment);
            await repository.AddAsync(secondComment);
            await repository.SaveChangesAsync();

            //Act
            await commentService.RemoveCommentsByUserAsync(user.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(comment.IsDeleted, Is.EqualTo(true));
                Assert.That(secondComment.IsDeleted, Is.EqualTo(true));
            });
        }

        [Test]
        public async Task RemoveCommentsByUserDoesntRemoveWhenUserIsAdmin()
        {
            //Arrange
            string dateString = "2023-08-01 01:52:14";
            string format = "yyyy-MM-dd HH:mm:ss";
            DateTime date = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);

            await repository.AddAsync(joke);
            await repository.AddAsync(adminUser);
            await repository.SaveChangesAsync();

            var comment = new Comment()
            {
                Id = new Guid("f909f97e-49b3-4fd5-96ee-e8330d2d9763"),
                Content = "text content",
                UserId = adminUser.Id,
                JokeId = joke.Id,
                CreatedOn = date

            };

            var secondComment = new Comment()
            {
                Id = new Guid("f909f97e-1253-4fd5-96ee-e8330d2d9763"),
                Content = "text content again",
                UserId = adminUser.Id,
                //JokeId taken from db seed
                JokeId = new Guid("996AB34D-316B-414E-AF7A-013EEEEEEEBA"),
                CreatedOn = date

            };

            await repository.AddAsync(comment);
            await repository.AddAsync(secondComment);
            await repository.SaveChangesAsync();

            //Act
            await commentService.RemoveCommentsByUserAsync(adminUser.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(comment.IsDeleted, Is.EqualTo(false));
                Assert.That(secondComment.IsDeleted, Is.EqualTo(false));
            });
        }
    }
}
