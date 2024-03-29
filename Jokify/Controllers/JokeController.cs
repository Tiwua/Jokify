﻿namespace Jokify.Controllers
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
    using static Jokify.Core.Common.Constants;
    using static Jokify.Infrastructure.Common.DataConstants;
    using static Jokify.Common.Constants.Error;
    using static Jokify.Areas.Admin.Constants.AdminConstants;
    using static Jokify.Common.Constants.NotificationMsg;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
	using Microsoft.AspNetCore.Mvc.Filters;
    using Jokify.Core.Services.AverageUser;


    public class JokeController : BaseController
    {
        private readonly IJokeService jokeService;
        private readonly IJokeCategoryService jokeCategoryService;
        private readonly ILikeService likeService;
        private readonly ICommentService commentService;

        public JokeController(
            IJokeService jokeService,
            IJokeCategoryService jokeCategoryService,
            ILikeService likeService,
            ICommentService commentService)
        {
            this.jokeService = jokeService;
            this.jokeCategoryService = jokeCategoryService;
            this.likeService = likeService;
            this.commentService = commentService;
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

            if ((await jokeCategoryService.CategoryExistsAsync(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), InvalidCategory);

                return View(model);
            }

            try
            {
                string userId = GetUserId();

                await jokeService.AddJokeAsync(model, userId);

                TempData[SuccessMessage] = "Joke has been added successfully!";
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Mine", "Joke");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllJokesQueryModel query)
        {
            var result = await jokeService.GetAllJokesAsync(
                query.UserId,
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.JokesPerPage);

            query.TotalJokesCount = result.JokesCount;
            query.Categories = await jokeCategoryService.GetAllCategoriesNamesAsync();
            query.Jokes = result.Jokes;

            ViewBag.Class = "jokes";
            return View(query);
        }

        [HttpGet("Joke/Details/{title}/{page}")]
        public async Task<IActionResult> Details(string title, int page = 1)
        {
            if (await jokeService.ExistsByTitleAsync(title) == false)
            {
                TempData[ErrorMessage] = "Joke does not exist";

                return RedirectToAction("All", "Joke");
            }

            try
            {
                var userId = GetUserId();

                var hasLiked = await likeService.HasLikedJoke(title, userId);
                var hasCommented = await commentService.HasUserCommentedAsync(title, userId);

                var model = await jokeService.JokeDetailsByTitle(title, page, hasCommented, hasLiked, userId);

                model.HasLiked = hasLiked;
                model.HasUserCommented = hasCommented;

                return View(model);
            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, "Invalid joke title");

                return RedirectToAction("All", "Joke");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Like(Guid id, string title, int page)
        {
            if (await JokeExists(id) == false)
            {
                return RedirectToAction("All", "Joke");
            }

            var userId = GetUserId();

            await likeService.LikeJokeAsync(id, userId);

            return RedirectToAction("Details", "Joke", new { title, page });
        }

        [HttpPost]
        public async Task<IActionResult> Dislike(Guid id, string title, int page)
        {
            if (await JokeExists(id) == false)
            {
                return RedirectToAction("All", "Joke");
            }

            var userId = GetUserId();

            await likeService.DislikeJokeAsync(id, userId);

            return RedirectToAction("Details", "Joke", new { title, page });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (await JokeExists(id) == false)
            {
                TempData[ErrorMessage] = "Joke does not exist";

                return RedirectToAction("Mine", "Joke");
            }

            var joke = await jokeService.GetJokeById(id);

            var categoryId = await jokeCategoryService.GetCategoryIdAsync(id);

            var model = jokeService.GetJokeForEdit(joke);

            model.CategoryId = categoryId;
            model.Categories = await jokeCategoryService.GetAllCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(JokeViewModel model, Guid id, string title, int page = 1)
        {

            if (await JokeExists(id) == false)
            {
                TempData[ErrorMessage] = "Joke does not exist";
                model.Categories = await jokeCategoryService.GetAllCategoriesAsync();

                return RedirectToAction("Mine", "Joke");
            }

            if ((await jokeCategoryService.CategoryExistsAsync(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
                model.Categories = await jokeCategoryService.GetAllCategoriesAsync();

                return View(model);
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await jokeCategoryService.GetAllCategoriesAsync();

                return View(model);
            }

            try
            {
                string userId = GetUserId();

                await jokeService.EditJokeAsync(model, id);

            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Details", "Joke", new { title, page });
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

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await JokeExists(id) == false)
            {
                return RedirectToAction("Mine", "Joke");
            }

            try
            {
                var userId = GetUserId();

                await jokeService.DeleteJokeAsync(userId, id, IsAdmin());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }


            return RedirectToAction("Mine", "Joke");
        }

        public async Task<bool> JokeExists(Guid id)
        {
            return await jokeService.ExistsAsync(id);
        }

		
	}
}
