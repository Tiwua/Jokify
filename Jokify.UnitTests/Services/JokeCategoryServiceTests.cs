namespace Jokify.UnitTests.Services
{
    using HouseRentingSystem.Infrastructure.Data.Common;
    using Jokify.Common.Contracts;
    using Jokify.Core.Contracts;
    using Jokify.Core.Models.Joke;
    using Jokify.Core.Services.AverageUser;
    using Jokify.Infrastructure.Data;
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Jokify.UnitTests.Mock;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class JokeCategoryServiceTests
    {
        private IRepository repository;
        private IJokeCategoryService jokeCategoryService;
        private JokifyDbContext context;

        [SetUp]
        public void Setup()
        {
            context = DbMock.Instance;

            repository = new Repository(context);
            jokeCategoryService = new JokeCategoryService(repository);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task CategoryExistsWorksProperly()
        {
            // Arrange

            // Act

            var result = await jokeCategoryService.CategoryExistsAsync(1);
            // Assert
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public async Task CategoryExistsWorksProperlyWhenWrongIdGiven()
        {
            // Arrange


            // Act

            var result = await jokeCategoryService.CategoryExistsAsync(11);
            // Assert
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public async Task GetCategoryNamesWorksProperly()
        {
            // Arrange
            var jokeCategory = new List<string> 
            {
                    "One-Liner", "Pun", "Knock-knock", "Wordplay", "Riddle", "Observational", "Dad joke", "Dark humor"        
            };

            // Act
            var result = await jokeCategoryService.GetAllCategoriesNamesAsync();
            var categoriesList = result.ToList();
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(categoriesList[0], Is.EqualTo(jokeCategory[0]));
                Assert.That(categoriesList[1], Is.EqualTo(jokeCategory[1]));
                Assert.That(categoriesList[2], Is.EqualTo(jokeCategory[2]));
                Assert.That(categoriesList[3], Is.EqualTo(jokeCategory[3]));
                Assert.That(categoriesList[4], Is.EqualTo(jokeCategory[4]));
                Assert.That(categoriesList[5], Is.EqualTo(jokeCategory[5]));
                Assert.That(categoriesList[6], Is.EqualTo(jokeCategory[6]));
                Assert.That(categoriesList[7], Is.EqualTo(jokeCategory[7]));
            });
        }

        [Test]
        public async Task GetCategoryWorksProperly()
        {
            // Arrange
            var jokeCategory = new List<JokeCategoryViewModel>
            {
                new JokeCategoryViewModel()
                {
                    Id = 1,
                    Name = "One-Liner"
                },
                new JokeCategoryViewModel()
                {
                    Id = 2,
                    Name = "Pun"
                },
                new JokeCategoryViewModel()
                {
                    Id = 3,
                    Name = "Knock-knock"
                },
                new JokeCategoryViewModel()
                {
                    Id = 4,
                    Name = "Wordplay"
                },
                new JokeCategoryViewModel()
                {
                    Id = 5,
                    Name = "Riddle"
                },
                new JokeCategoryViewModel()
                {
                    Id = 6,
                    Name = "Observational"
                },
                new JokeCategoryViewModel()
                {
                    Id = 7,
                    Name = "Dad joke"
                },
                new JokeCategoryViewModel()
                {
                    Id = 8,
                    Name = "Dark humor"
                }
            };

            // Act
            var result = await jokeCategoryService.GetAllCategoriesAsync();
            var categoriesList = result.ToList();
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(categoriesList[0].Name, Is.EqualTo(jokeCategory[0].Name));
                Assert.That(categoriesList[0].Id, Is.EqualTo(jokeCategory[0].Id));
                Assert.That(categoriesList[4].Name, Is.EqualTo(jokeCategory[4].Name));
                Assert.That(categoriesList[4].Id, Is.EqualTo(jokeCategory[4].Id));
                Assert.That(categoriesList[7].Name, Is.EqualTo(jokeCategory[7].Name));
                Assert.That(categoriesList[7].Id, Is.EqualTo(jokeCategory[7].Id));
            });
        }

        [Test]
        public async Task GetCategoryIdFromJokeWorksProperly()
        {
            // Arrange
            var joke = new Joke()
            {
                Id = new Guid("829046e9-9806-4886-907d-5950b73795e8"),
                Title = "Batman",
                Setup = "Where does Batman go to the bathroom?",
                Punchline = "The batroom.",
                UserId = "965a8773-bb8e-410e-a428-67798ffe2cda",
                JokeCategoryId = 2
            };

            await context.AddAsync(joke);
            await context.SaveChangesAsync();

            // Act

            var result = await jokeCategoryService.GetCategoryIdAsync(joke.Id);

            // Assert
            Assert.That(result, Is.EqualTo(2));
        }
    }
}
