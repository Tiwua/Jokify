namespace Jokify.Controllers
{
    using Jokify.Common.Contracts;
    using Jokify.Core.Models.Joke;
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;


    public class JokeController : BaseController
    {
        private readonly IJokeService jokeService;

        public JokeController(IJokeService jokeService)
        {
            this.jokeService = jokeService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var model = new AddJokeViewModel()
            {
                Categories = await jokeService.GetAllCategoriesAsync()
            };

            ViewBag.Class = "add";

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddJokeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await jokeService.GetAllCategoriesAsync();

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

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await jokeService.GetAllJokesAsync();

            return View(model);
        }
    }
}
