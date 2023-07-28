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

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var model = await jokeService.GetAllJokesCountAsync();

			return View(model);
		}
	}
}
