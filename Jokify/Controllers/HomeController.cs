namespace Jokify.Controllers
{
    using Jokify.Common.Contracts;
    using Jokify.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
	using System.Diagnostics;

	[AllowAnonymous]
	public class HomeController : BaseController
	{
		private readonly IJokeService jokeService;

        public HomeController(IJokeService jokeService)
        {
			this.jokeService = jokeService;    
        }

        public async Task<IActionResult> Index()
		{
			var model = await jokeService.GetThreeMostPopularJokes();

			ViewBag.Class = "home";

			return View(model);
		}
	}
}