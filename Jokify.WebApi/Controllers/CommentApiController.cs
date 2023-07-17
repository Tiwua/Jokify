namespace Jokify.WebApi.Controllers
{
    using Jokify.Common.Contracts;
    using Jokify.Core.Contracts;
    using Jokify.Core.Models.Comment;
    using Jokify.Core.Models.Statistics;
    using Jokify.Core.Services;
    using Jokify.Infrastructure.Data;
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;

    [ApiController]
    [Route("api/content")]
    public class CommentApiController : Controller
    {
        private readonly JokifyDbContext context;
        private readonly IJokeService jokeService;

        public CommentApiController(JokifyDbContext context, IJokeService jokeService)
        {
            this.context = context;
            this.jokeService = jokeService;
        }

        [HttpPut, Route("{id:Guid}")]
        [Produces("application/json")]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public async Task<IActionResult> Update(Guid id, [FromBody] string content)
        {
            try
            {
                if (string.IsNullOrEmpty(content))
                {
                    throw new ArgumentException("Content is empty!");
                }

                var commentToEdit = await context.Comments.Where(c => c.Id == id ).FirstOrDefaultAsync();

                if (commentToEdit == null)
                {
                    throw new ArgumentNullException("Invalid Comment");
                }

                var userId = commentToEdit.UserId;

                commentToEdit.Content = content;
                commentToEdit.IsEdited = true;

                await context.SaveChangesAsync();

                return this.Ok(new { success = true });
            }
            catch (Exception)
            {

                return this.BadRequest(new { success = false });
            }
        }
    }
}
