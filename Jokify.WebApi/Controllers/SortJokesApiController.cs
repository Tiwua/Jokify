namespace Jokify.WebApi.Controllers
{
    using Jokify.Common.Contracts;
    using Jokify.Core.Models.Joke.Enums;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/sort")]
    public class SortJokesApiController : ControllerBase
    {
        private readonly IJokeService jokeService;

        public SortJokesApiController(IJokeService jokeService)
        {
            this.jokeService = jokeService;
        }

        [HttpGet("{sorting}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetSortedJokes([FromRoute] JokeSorting sorting)
        {
            var jokes = await jokeService.GetAllJokesAsync(null, null, null, sorting, 1);

            return Ok(jokes.Jokes);
        }
    }
}