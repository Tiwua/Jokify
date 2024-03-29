﻿namespace Jokify.WebApi.Controllers
{
    using Jokify.Common.Contracts;
    using Jokify.Core.Contracts;
    using Jokify.Core.Models.Comment;
    using Jokify.Core.Models.Statistics;
    using Jokify.Core.Services;
    using Jokify.Infrastructure.Data;
    using Jokify.Infrastructure.Data.Models;
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;
    using static Jokify.Common.Constants.Error;

    [ApiController]
    [Route("api/content")]
    public class CommentApiController : Controller
    {
        private readonly ICommentService commentService;
        private readonly UserManager<User> userManager;

        public CommentApiController(
            ICommentService commentService,
            UserManager<User> userManager)
        {
            this.commentService = commentService;
            this.userManager = userManager;
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
                    throw new ArgumentException(EmptyCommentUpdate);
                }

                await commentService.UpdateComment(id, content, userManager);

                return this.Ok(new { success = true });
            }
            catch (Exception)
            {

                return this.BadRequest(new { success = false });
            }
        }
    }
}