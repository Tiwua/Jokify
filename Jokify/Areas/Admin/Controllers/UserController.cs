namespace Jokify.Areas.Admin.Controllers
{
    using Jokify.Core.Contracts.Admin;
    using Jokify.Core.Models.Admin;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> All()
        {
            var model = new UserPageModel();

            model.Users = await userService.AllUsersAsync();

            ;
            return View(model);
        }
    }
}
