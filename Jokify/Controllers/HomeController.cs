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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return View("Error404");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}