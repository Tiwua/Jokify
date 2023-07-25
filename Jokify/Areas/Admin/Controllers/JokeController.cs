namespace Jokify.Areas.Admin.Controllers
{
    using Jokify.Common.Contracts;
    using Jokify.Core.Contracts;
    using Jokify.Core.Models.Joke;
    using Jokify.Core.Services.AverageUser;
    using Jokify.Models;
    using Microsoft.AspNetCore.Mvc;
    public class JokeController : BaseController
    {
        private readonly IJokeService jokeService;
        private readonly IJokeCategoryService jokeCategoryService;

        public JokeController(
            IJokeService jokeService,
            IJokeCategoryService jokeCategoryService
            )
        {
            this.jokeService = jokeService;
            this.jokeCategoryService = jokeCategoryService;
        }

        [HttpGet]
        [Route("/Admin/[controller]/[Action]/{page}")]
        public async Task<IActionResult> Mine([FromQuery] AllJokesQueryModel query)
        {
            var result = await jokeService.GetAllJokesAsync(
                query.UserId = GetUserId(),
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.JokesPerPage);

            query.TotalJokesCount = result.JokesCount;
            query.Jokes = result.Jokes;

            ViewBag.Class = "mine";

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var model = new JokeViewModel()
            {
                IsEditMode = false,
                Categories = await jokeCategoryService.GetAllCategoriesAsync()
            };

            ViewBag.Class = "add";

            return View(model);
        }
    }
}
