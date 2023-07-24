namespace Jokify.Areas.Admin.Controllers
{
    using Jokify.Common.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class JokeController : Controller
    {
        private readonly IJokeService jokeService;

        public JokeController(IJokeService jokeService)
        {
            this.jokeService = jokeService;
        }

        public async Task<IActionResult> Mine()
        {


            var jokes = jokeService.AllJokesByUser("finish");


            return View(jokes);
        }

        
    }
}
