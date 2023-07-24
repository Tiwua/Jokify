namespace Jokify.Controllers
{
    using Jokify.Common.Contracts;
    using Jokify.Core.Contracts;
    using Jokify.Core.Models.Joke;
    using Jokify.Core.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class CommentController : BaseController
    {
        private readonly ICommentService commentService;
        private readonly IJokeService jokeService;

        public CommentController(
            ICommentService commentService,
            IJokeService jokeService)
        {
            this.commentService = commentService;
            this.jokeService = jokeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(string title, int page, JokeDetailsViewModel model)
        {
            if (await jokeService.ExistsAsync(model.Id) == false)
            {
                return RedirectToAction("All", "Joke");
            }

            if (IsCommentValid(model.CommentContent))
            {
                return RedirectToAction("Details", "Joke", new { title, page });
            }

            var userId = GetUserId();
            var commentContent = model.CommentContent;

            await commentService.AddCommentToJokeAsync(title, commentContent, userId);

            return RedirectToAction("Details", "Joke", new { title, page });
        }

        private bool IsCommentValid(string commentContent)
        {
            return commentContent.Length < 5 || commentContent.Length > 195;
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id, string title, int page, Guid jokeId)
        {
            if (await commentService.ExistsAsync(id) == false)
            {
                return RedirectToAction("All", "Joke");
            }

            var userId = GetUserId();

            await commentService.DeleteCommentAsync(id, userId, jokeId);

            return RedirectToAction("Details", "Joke", new { title, page });
        }
    }
}
