namespace Jokify.WebApi.Controllers
{
    using Jokify.Core.Contracts;
    using Jokify.Core.Models.Statistics;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/statistics/{id}")]
    [ApiController]
    public class StatisticsApiController : ControllerBase
    {
        private readonly ILikeService likeService;

        public StatisticsApiController(ILikeService likeService)
        {
            this.likeService = likeService;
        }


        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(StatisticsServiceModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStatistics(Guid id)
        {
            try
            {
                var model = await likeService.GetLikesCount(id);

                return this.Ok(model);
            }
            catch (Exception)
            {

                return this.BadRequest();
            }
        }

    }
}
