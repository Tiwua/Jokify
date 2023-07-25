namespace Jokify.Areas.Admin.Controllers
{
	using Jokify.Common.Contracts;
	using Microsoft.AspNetCore.Mvc;

    public class AdminController : BaseController
    {
        private readonly IJokeService jokeService;

        public AdminController(IJokeService jokeService)
        {
            this.jokeService = jokeService;
        }

        public async Task<IActionResult> Index()
        {
			var model = await jokeService.GetThreeMostPopularJokes();

			return View(model);
        }
    }
}
