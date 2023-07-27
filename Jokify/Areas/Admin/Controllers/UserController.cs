namespace Jokify.Areas.Admin.Controllers
{
	using Jokify.Core.Contracts;
	using Jokify.Core.Contracts.Admin;
    using Jokify.Core.Models.Admin;
    using Microsoft.AspNetCore.Mvc;

	using static Jokify.Common.Constants.NotificationMsg;

	[Route("/Admin/[controller]/[Action]/{page}")]
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly ICommentService commentService;
        public UserController(
            IUserService userService,
            ICommentService commentService)
        {
            this.userService = userService;
            this.commentService = commentService;
        }


        public async Task<IActionResult> All(int page = 1)
        {
            var userId = GetUserId();

            var users = await userService.AllUsersAsync(userId);

            var model = userService.AllUsersPaginated(users, page);

            ViewBag.Class = "all";
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, int page)
        {
            await userService.DeleteUserAsync(id);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Forget(string id, int page)
        {
			bool result = await userService.ForgetUserAsync(id);

            await commentService.RemoveCommentsByUserAsync(id);

			if (result)
			{
				TempData[SuccessMessage] = "User is now forgotten";
			}
			else
			{
				TempData[ErrorMessage] = "User is unforgetable";
			}

			return RedirectToAction("");
        }
    }
}
