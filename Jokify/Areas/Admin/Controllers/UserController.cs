namespace Jokify.Areas.Admin.Controllers
{
    using Jokify.Core.Contracts.Admin;
    using Jokify.Core.Models.Admin;
    using Microsoft.AspNetCore.Mvc;


    [Route("/Admin/[controller]/[Action]/{page}")]
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }


        public async Task<IActionResult> All(int page = 1)
        {
            var userId = GetUserId();

            var users = await userService.AllUsersAsync(userId);

            var model = userService.AllUsersPaginated(users, page);
       
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            var userId = GetUserId();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Forget()
        {
            var userId = GetUserId();

            return View();
        }
    }
}
