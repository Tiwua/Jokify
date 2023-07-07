namespace Jokify.Controllers
{
    using Jokify.Common.Contracts;
    using Jokify.Core.Contracts;
    using Jokify.Core.Models.Joke;
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Jokify.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Mvc;


    public class JokeController : BaseController
    {
        private readonly IJokeService jokeService;
        private readonly IJokeCategoryService jokeCategoryService;

        public JokeController(
            IJokeService jokeService,
            IJokeCategoryService jokeCategoryService)
        {
            this.jokeService = jokeService;
            this.jokeCategoryService = jokeCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var model = new AddJokeViewModel()
            {
                Categories = await jokeCategoryService.GetAllCategoriesAsync()
            };

            ViewBag.Class = "add";

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddJokeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await jokeCategoryService.GetAllCategoriesAsync();

                return View(model);
            }

            try
            {
                string userId = GetUserId();

                await jokeService.AddJokeAsync(model, userId);

            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("All", "Joke");
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery]AllJokesQueryModel query)
        {
            var result = await jokeService.GetAllJokesAsync(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.JokesPerPage);

            query.TotalJokesCount = result.JokesCount;
            query.Categories = await jokeCategoryService.GetAllCategoriesNamesAsync();
            query.Jokes = result.Jokes;

            return View(query);
        }

        [HttpGet("Joke/Details/{title}")]
        public async Task<IActionResult> Details(string title)
        {          
            var model = await jokeService.JokeDetailsByTitle(title);

            return View(model);
        }
    }
}
