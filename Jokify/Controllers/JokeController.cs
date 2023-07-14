namespace Jokify.Controllers
{
    using Jokify.Common.Contracts;
    using Jokify.Core.Contracts;
    using Jokify.Core.Models.Comment;
    using Jokify.Core.Models.Joke;
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Jokify.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;


    public class JokeController : BaseController
    {
        private readonly IJokeService jokeService;
        private readonly IJokeCategoryService jokeCategoryService;
        private readonly ILikeService likeService;

        public JokeController(
            IJokeService jokeService,
            IJokeCategoryService jokeCategoryService,
            ILikeService likeService)
        {
            this.jokeService = jokeService;
            this.jokeCategoryService = jokeCategoryService;
            this.likeService = likeService;
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

        [HttpPost]
        public async Task<IActionResult> Add(JokeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await jokeCategoryService.GetAllCategoriesAsync();

                ViewBag.Class = "add";

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
        public async Task<IActionResult> All([FromQuery] AllJokesQueryModel query)
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

        [HttpGet("Joke/Details/{title}/{page}")]
        public async Task<IActionResult> Details(string title, int page = 1)
        {
            try
            {
                var userId = GetUserId();
                var hasLiked = await likeService.HasLikedJoke(title, userId);

                var model = await jokeService.JokeDetailsByTitle(title, page, hasLiked, userId);

                model.HasLiked = hasLiked;

                return View(model);
            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, "Invalid joke title");

                return RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(string title, int page, JokeDetailsViewModel model)
        {
            if (IsCommentValid(model.CommentContent))
            {

                return RedirectToAction("Details", "Joke", new { title, page });
            }

            var userId = GetUserId();

            var commentContent = model.CommentContent;

            await jokeService.AddCommentToJokeAsync(title, commentContent, userId);

            return RedirectToAction("Details", "Joke", new { title, page });
        }

        private bool IsCommentValid(string commentContent)
        {
            return commentContent.Length < 5 || commentContent.Length > 195;
        }

        [HttpPost]
        public async Task<IActionResult> Like(Guid id, string title, int page)
        {
            var userId = GetUserId();

            await likeService.LikeJokeAsync(id, userId);

            return RedirectToAction("Details", "Joke", new { title, page });
        }

        [HttpPost]
        public async Task<IActionResult> Dislike(Guid id, string title, int page)
        {
            var userId = GetUserId();

            await likeService.DislikeJokeAsync(id, userId);

            return RedirectToAction("Details", "Joke", new { title, page });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var categoryId = await jokeCategoryService.GetCategoryIdAsync(id);
            var joke = await jokeService.GetJokeById(id);

            var model = new JokeViewModel()
            {
                Title = joke.Title,
                Setup = joke.Setup,
                Punchline = joke.Punchline,
                CategoryId = categoryId,
                Categories = await jokeCategoryService.GetAllCategoriesAsync(),
                IsEditMode = true
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(JokeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await jokeCategoryService.GetAllCategoriesAsync();

                ViewBag.Class = "add";

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
    }
}
