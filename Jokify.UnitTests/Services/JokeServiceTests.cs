namespace Jokify.UnitTests.Services
{
    using HouseRentingSystem.Infrastructure.Data.Common;
    using Jokify.Common.Contracts;
    using Jokify.Core.Models.Comment;
    using Jokify.Core.Models.Joke;
    using Jokify.Core.Models.Joke.Enums;
    using Jokify.Core.Services.AverageUser;
    using Jokify.Infrastructure.Data;
    using Jokify.Infrastructure.Data.Models;
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Jokify.Infrastructure.Data.Models.MappingTables;
    using Jokify.UnitTests.Mock;
    using Microsoft.EntityFrameworkCore;
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

            repository = new Repository(context);
            jokeService = new JokeService(repository);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task EditJokeWorksProperly()
        {
            //Arrange

            await repository.AddAsync(joke);

            await repository.SaveChangesAsync();

            var model = new JokeViewModel()
            {
                Title = "Batman editted",
                Setup = "Where does Batman go to the bathroom?",
                Punchline = "The batroom."
            };

            //Act 
            await jokeService.EditJokeAsync(model, joke.Id);

            //Assert
            Assert.That(joke.IsEdited, Is.EqualTo(true));
        }

        [Test]
        public async Task AddJokeWithSameTitleThrowsException()
        {
            //Arrange

            await repository.AddAsync(joke);

            await repository.SaveChangesAsync();

            var model = new JokeViewModel()
            {
                Id = new Guid("123456e9-9806-4886-907d-5950b73795e8"),
                Title = "Batman",
                Setup = "Where does Batman go to the bathroom?",
                Punchline = "The batroom.",
                CategoryId = 2
            };


            var userId = "bafba8c1-ec24-4539-943e-78fa6e880d4b";

            //Act
            var ex = Assert.ThrowsAsync<ArgumentException>(
                async () => await jokeService.AddJokeAsync(model, userId));

            //Assert
            StringAssert.Contains("Cannot have multiple jokes with the same Title", ex.Message);
        }

        [Test]
        public async Task AddJokeAddsJokeInUserCollectionWorksProperly()
        {
            //Arrange

            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            var model = new JokeViewModel()
            {
                Id = new Guid("829046e9-9806-4886-907d-5950b73795e8"),
                Title = "Batman",
                Setup = "Where does Batman go to the bathroom?",
                Punchline = "The batroom."
            };

            //Act
            await jokeService.AddJokeAsync(model, user.Id);

            //Assert
            Assert.That(user.CreatedJokes, Has.Count.EqualTo(1));

        }


        [Test]
        public async Task ExistsWorksProperly()
        {
            //Arrange

            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();

            //Act
            var result = await jokeService.ExistsAsync(joke.Id);

            //Assert
            Assert.That(result, Is.EqualTo(true));

        }

        [Test]
        public async Task ExistsByTitleWorksProperly()
        {
            //Arrange

            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();

            //Act
            var result = await jokeService.ExistsByTitleAsync(joke.Title);

            //Assert
            Assert.That(result, Is.EqualTo(true));

        }

        [Test]
        public async Task GetAllJokesReturnsCorrectJokes()
        {
            // Arrange

            var jokes = new List<Joke>
            {
                joke,
                new Joke
                {
                    Id = new Guid("123456e9-9806-4886-907d-5950b73795e8"),
                    Title = "Title test",
                    Setup = "Setup test",
                    Punchline = "Punchline test",
                    UserId = "965a8773-bb8e-410e-a428-67798ffe2cda",
                    JokeCategoryId = 2
                },
            };

            await repository.AddRangeAsync(jokes);
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            // Act
            var result = await jokeService.GetAllJokesAsync(
            userId: null,
            category: null,
            searchTerm: null,
            sorting: JokeSorting.PopularDescending,
            currentPage: 1,
            jokesPerPage: 10);

            // Assert

            var jokesList = result.Jokes.ToList();

            Assert.That(result, Is.Not.Null);
            Assert.That(jokesList, Has.Count.EqualTo(10));
            Assert.Multiple(() =>
            {
                Assert.That(jokesList[0].Title, Is.EqualTo("Fat DNA?"));
                Assert.That(jokesList[0].Setup, Is.EqualTo("What did the Dna say to the other DNA?"));
                Assert.That(jokesList[0].Punchline, Is.EqualTo("Do these genes make me look fat?"));
            });
        }

        [Test]
        public async Task GetAllUserJokesReturnsCorrectJokes()
        {
            // Arrange

            var jokes = new List<Joke>
            {
                joke,
                new Joke
                {
                    Id = new Guid("123456e9-9806-4886-907d-5950b73795e8"),
                    Title = "Title test",
                    Setup = "Setup test",
                    Punchline = "Punchline test",
                    UserId = "965a8773-bb8e-410e-a428-67798ffe2cda",
                    JokeCategoryId = 2
                }
            };

            await repository.AddRangeAsync(jokes);
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            // Act
            var result = await jokeService.GetAllJokesAsync(
            userId: "965a8773-bb8e-410e-a428-67798ffe2cda",
            category: null,
            searchTerm: null,
            sorting: JokeSorting.PopularDescending,
            currentPage: 1,
            jokesPerPage: 10);

            // Assert

            var jokesList = result.Jokes.ToList();

            Assert.That(result, Is.Not.Null);
            Assert.That(jokesList, Has.Count.EqualTo(2));

            Assert.Multiple(() =>
            {
                Assert.That(jokesList[0].Title, Is.EqualTo(joke.Title));
                Assert.That(jokesList[0].Setup, Is.EqualTo(joke.Setup));
                Assert.That(jokesList[0].Punchline, Is.EqualTo(joke.Punchline));
                Assert.That(jokesList[1].Title, Is.EqualTo("Title test"));
                Assert.That(jokesList[1].Setup, Is.EqualTo("Setup test"));
                Assert.That(jokesList[1].Punchline, Is.EqualTo("Punchline test"));
            });
        }

        [Test]
        public async Task GetAllJokesAsyncUnderCategoryReturnsCorrectJokes()
        {
            // Arrange

            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();

            // Act
            var result = await jokeService.GetAllJokesAsync(
            userId: null,
            category: "Pun",
            searchTerm: null,
            sorting: JokeSorting.PopularDescending,
            currentPage: 1,
            jokesPerPage: 10);

            // Assert

            var jokesList = result.Jokes.ToList();

            Assert.That(result, Is.Not.Null);
            Assert.That(jokesList, Has.Count.EqualTo(2));
        }
        [Test]
        public async Task GetAllJokesAsyncWithSearchReturnsCorrectJokes()
        {
            // Arrange

            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();

            // Act
            var result = await jokeService.GetAllJokesAsync(
            userId: null,
            category: null,
            searchTerm: "Batman",
            sorting: JokeSorting.PopularDescending,
            currentPage: 1,
            jokesPerPage: 10);

            // Assert

            var jokesList = result.Jokes.ToList();

            Assert.That(result, Is.Not.Null);
            Assert.That(jokesList, Has.Count.EqualTo(1));
        }

        [Test]
        public async Task GetAllJokesAsyncWithSortingReturnsCorrectJokes()
        {
            // Arrange

            // Act
            var result = await jokeService.GetAllJokesAsync(
            userId: null,
            category: null,
            searchTerm: null,
            sorting: JokeSorting.Title,
            currentPage: 1,
            jokesPerPage: 10);

            // Assert

            var jokesList = result.Jokes.ToList();

            Assert.That(result, Is.Not.Null);
            Assert.That(jokesList, Has.Count.EqualTo(8));

            Assert.Multiple(() =>
            {
                Assert.That(jokesList[0].Title, Is.EqualTo("Bicycle"));
                Assert.That(jokesList[1].Title, Is.EqualTo("Fat DNA?"));
                Assert.That(jokesList[2].Title, Is.EqualTo("Favorite PC Part"));
                Assert.That(jokesList[3].Title, Is.EqualTo("Outside"));
                Assert.That(jokesList[4].Title, Is.EqualTo("Owl"));
                Assert.That(jokesList[5].Title, Is.EqualTo("Parrot"));
                Assert.That(jokesList[6].Title, Is.EqualTo("Skeletons"));
                Assert.That(jokesList[7].Title, Is.EqualTo("Trust Issues"));
            });
        }

        [Test]
        public async Task GetMostPopularJokesReturnsCorrectJokes()
        {
            // Arrange
            joke.LikesCount++;
            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();

            // Act
            var result = await jokeService.GetAllJokesAsync(
            userId: null,
            category: null,
            searchTerm: null,
            sorting: JokeSorting.PopularDescending,
            currentPage: 1,
            jokesPerPage: 10);

            // Assert

            var jokesList = result.Jokes.ToList();

            Assert.That(result, Is.Not.Null);
            Assert.That(jokesList, Has.Count.EqualTo(9));

            Assert.That(jokesList[0].Title, Is.EqualTo(joke.Title));
        }

        [Test]
        public async Task JokeDetailsReturnsCorrectInformation()
        {
            // Arrange
            await repository.AddAsync(user);
            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();

            // Act
            var result = await jokeService.JokeDetailsByTitle(
            title: joke.Title,
            currentPage: 1,
            hasCommented: false,
            hasLiked: false,
            userId: user.Id);

            ;
            // Assert

            var detailsViewModel = new JokeDetailsViewModel()
            {
                CurrUser = user.Id,
                CurrentPage = 1,
                HasCreatedComment = false,
                HasLiked = false,
                HasUserCommented = false,
                Id = joke.Id,
                IsDeleted = false,
                IsEdited = false,
                LikesCount = 0,
                OwnerName = user.UserName,
                PageSize = 3,
                Punchline = joke.Punchline,
                Setup = joke.Setup,
                Title = joke.Title,
                TotalComments = 0,
                TotalPages = 0
            };

            Assert.Multiple(() =>
            {
                Assert.That(result.Title, Is.EqualTo(detailsViewModel.Title));
                Assert.That(result.Setup, Is.EqualTo(detailsViewModel.Setup));
                Assert.That(result.Punchline, Is.EqualTo(detailsViewModel.Punchline));
                Assert.That(result.HasLiked, Is.EqualTo(detailsViewModel.HasLiked));
                Assert.That(result.OwnerName, Is.EqualTo(detailsViewModel.OwnerName));
                Assert.That(result.CurrUser, Is.EqualTo(detailsViewModel.CurrUser));
            });
        }

        [Test]
        public async Task GetJokeByIdReturnsCorrectId()
        {
            // Arrange
            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();

            // Act
            var jokeViewModel = await jokeService.GetJokeById(joke.Id);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(jokeViewModel.Title, Is.EqualTo(joke.Title));
                Assert.That(jokeViewModel.Setup, Is.EqualTo(joke.Setup));
                Assert.That(jokeViewModel.Punchline, Is.EqualTo(joke.Punchline));
            });

        }

        [Test]
        public async Task DeleteJokeWorksProperly()
        {
            // Arrange
            await context.AddAsync(joke);
            await context.AddAsync(user);
            await context.SaveChangesAsync();

            // Act
            await jokeService.DeleteJokeAsync(user.Id, joke.Id);

            // Assert
            Assert.That(joke.IsDeleted, Is.EqualTo(true));
            Assert.That(user.CreatedJokes, Has.Count.EqualTo(0));

        }

        [Test]
        public async Task DeletingNonExistantJokeThrowsException()
        {
            //Arrange
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            //Act
            var ex = Assert.ThrowsAsync<ArgumentNullException>(
                async () => await jokeService.DeleteJokeAsync(user.Id, joke.Id));

            //Assert
            StringAssert.Contains("Invalid joke!", ex.Message);
        }

        [Test]
        public async Task DeleteJokeFromWrongUserThrowsException()
        {
            //Arrange
            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();

            //Act
            var ex = Assert.ThrowsAsync<ArgumentException>(
                async () => await jokeService.DeleteJokeAsync("123a8773-bb8e-410e-a428-67798ffe2cda", joke.Id));

            //Assert
            StringAssert.Contains("You are not the owner of this joke!", ex.Message);

        }

        [Test]
        public async Task GetMostPopularCategoriesWorksProperly()
        {
            // Arrange
            var jokes = new List<Joke>
            {
                joke,
                new Joke
                {
                    Id = new Guid("123456e9-9806-4886-907d-5950b73795e8"),
                    Title = "Title test",
                    Setup = "Setup test",
                    Punchline = "Punchline test",
                    UserId = "965a8773-bb8e-410e-a428-67798ffe2cda",
                    JokeCategoryId = 2
                },
                new Joke
                {
                    Id = new Guid("abc456e9-9806-4886-907d-5950b73795e8"),
                    Title = "test",
                    Setup = "test",
                    Punchline = "test",
                    UserId = "965a8773-bb8e-410e-a428-67798ffe2cda",
                    JokeCategoryId = 2
                },
                new Joke
                {
                    Id = new Guid("12345678-9806-4886-907d-5950b73795e8"),
                    Title = "Another Title test",
                    Setup = "Another Setup test",
                    Punchline = "Another Punchline test",
                    UserId = "965a8773-bb8e-410e-a428-67798ffe2cda",
                    JokeCategoryId = 1
                },
                new Joke
                {
                    Id = new Guid("12345678-1234-4886-907d-5950b73795e8"),
                    Title = "Cool test",
                    Setup = "Cool Setup test",
                    Punchline = "Cool Punchline test",
                    UserId = "965a8773-bb8e-410e-a428-67798ffe2cda",
                    JokeCategoryId = 1
                },
                new Joke
                {
                    Id = new Guid("12345678-9806-abcd-907d-5950b73795e8"),
                    Title = "Yet Another Title test",
                    Setup = "Yet Another Setup test",
                    Punchline = "Yet Another Punchline test",
                    UserId = "965a8773-bb8e-410e-a428-67798ffe2cda",
                    JokeCategoryId = 3
                }
            };

            var expected = new List<JokeHomeView>()
            {
                new JokeHomeView()
                {
                    Category = "Pun",
                    Count = 4
                },
                new JokeHomeView()
                {
                    Category = "One-Liner",
                    Count = 3
                },
                new JokeHomeView()
                {
                    Category = "Knock-knock",
                    Count = 2
                }
            };

            await context.AddRangeAsync(jokes);
            await context.AddAsync(user);
            await context.SaveChangesAsync();

            // Act
            var result = await jokeService.GetThreeMostPopularJokes();

            // Assert

            var jokesList = result.ToList();

            Assert.That(jokesList, Is.Not.Null);
            Assert.That(jokesList, Has.Count.EqualTo(3));
            Assert.Multiple(() =>
            {
                Assert.That(jokesList[0].Category, Is.EqualTo(expected[0].Category));
                Assert.That(jokesList[0].Count, Is.EqualTo(expected[0].Count));
                Assert.That(jokesList[1].Category, Is.EqualTo(expected[1].Category));
                Assert.That(jokesList[2].Category, Is.EqualTo(expected[2].Category));
            });
        }

        [Test]
        public async Task GetJokeByTitleReturnsTrue()
        {
            // Arrange
            await repository.AddAsync(joke);
            await repository.SaveChangesAsync();

            // Act
            var result = await jokeService.ExistsByTitleAsync(joke.Title);

            // Assert

            Assert.That(result, Is.EqualTo(true));

        }

        [Test]
        public async Task GetJokeByTitleReturnsFalse()
        {
            // Arrange

            // Act
            var result = await jokeService.ExistsByTitleAsync("Title");

            // Assert

            Assert.That(result, Is.EqualTo(false));

        }

        [Test]
        public async Task GetJokeForEditReturnsCorrectModel()
        {
            // Arrange
            await context.AddAsync(joke);
            await context.SaveChangesAsync();

            var jokeViewModel = new JokeViewModel()
            {

                Title = joke.Title,
                Setup = joke.Setup,
                Punchline = joke.Punchline,
                IsEdited = false
            };

            // Act
            var result = jokeService.GetJokeForEdit(jokeViewModel);

            var expected = new JokeViewModel()
            {
                Title = "Batman",
                Setup = "Where does Batman go to the bathroom?",
                Punchline = "The batroom.",
                IsEdited = false,
                IsEditMode = true
            };
            // Assert

            Assert.Multiple(() =>
            {
                Assert.That(result.IsEdited, Is.EqualTo(expected.IsEdited));
                Assert.That(result.IsEditMode, Is.EqualTo(expected.IsEditMode));
            });

        }

        [Test]
        public async Task GetAllJokesCountReturnsCorrectCount()
        {
            // Arrange
            await context.AddAsync(joke);
            await context.SaveChangesAsync();

            // Act
            var result = await jokeService.GetAllJokesAsync();

            // Assert
            Assert.That(result.JokesCount, Is.EqualTo(9));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}