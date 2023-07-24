namespace Jokify.Areas.Admin.Controllers
{
    using Jokify.Core.Contracts.Admin;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await userService.AllUsersAsync();

            return View(model);
        }
    }
}
