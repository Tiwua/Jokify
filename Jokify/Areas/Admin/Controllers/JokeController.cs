namespace Jokify.Areas.Admin.Controllers
{
    using Jokify.Common.Contracts;
	using Jokify.Core.Models.Joke;
    using Jokify.Models;
    using Microsoft.AspNetCore.Mvc;
    public class JokeController : BaseController
    {
        private readonly IJokeService jokeService;

        public JokeController(IJokeService jokeService)
        {
            this.jokeService = jokeService;
        }

        [HttpGet]
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
    }
}
