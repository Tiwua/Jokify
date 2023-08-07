namespace Jokify.Controllers
{
	using Jokify.Infrastructure.Data.Models;
	using Jokify.Core.Models.User;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;

	[AllowAnonymous]
	public class UserController : BaseController
	{

		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;

        public UserController(
			UserManager<User> _userManager,
			SignInManager<User> _signInManager)
        {
			userManager = _userManager;
			signInManager = _signInManager;
        }

		[HttpGet]
		public IActionResult Register()
		{
			var model = new RegisterViewModel();
            ViewBag.Class = "register";

            return View(model);
		}


		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (!ModelState.IsValid)
            {
                ViewBag.Class = "register";
                return View(model);
			}

			User user = new User()
			{
				UserName = model.UserName,
				Email = model.Email
			};

			var result = await userManager.CreateAsync(user, model.Password);

			if (result.Succeeded)
			{
				await signInManager.SignInAsync(user, isPersistent: false);

				return RedirectToAction("Index", "Home");
			}

			foreach (var item in result.Errors)
			{
				ModelState.AddModelError("", item.Description);
			}

			return View(model);
		}

		[HttpGet]
		public IActionResult Login(string returnUrl)
		{
			var model = new LoginViewModel()
			{
				ReturnUrl = returnUrl
			};

            ViewBag.Class = "login";

            return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
		{
			if (!ModelState.IsValid)
			{
                ViewBag.Class = "login";
                return View(model);
			}

			var user = await userManager.FindByNameAsync(model.UserName);

			if (user != null && user.Email != null)
			{
				var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

				if (result.Succeeded)
				{
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
			}

			ModelState.AddModelError("", "Invalid login");

			return View(model);
		}

		public IActionResult Logout()
		{
			signInManager.SignOutAsync();

			return RedirectToAction("Index", "Home");
		}
	}
}
