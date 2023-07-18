namespace Jokify.Controllers
{
    using Jokify.Core.Contracts;
    using Jokify.Core.Models.Joke;
    using Jokify.Core.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class CommentController : BaseController
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
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
            var userId = GetUserId();

            await commentService.DeleteCommentAsync(id, userId, jokeId);

            return RedirectToAction("Details", "Joke", new { title, page });
        }
    }
}
