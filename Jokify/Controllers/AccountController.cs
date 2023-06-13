﻿namespace Jokify.Controllers
{
	using Jokify.Infrastructure.Data.Models;
	using Jokify.Core.Models.User;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;

	[AllowAnonymous]
	public class AccountController : Controller
	{

		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;

        public AccountController(
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

			return View(model);
		}


		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (!ModelState.IsValid) 
			{
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
		public IActionResult Login()
		{
			var model = new LoginViewModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var user = await userManager.FindByNameAsync(model.UserName);

			if (user != null)
			{
				var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
			}

			ModelState.AddModelError("", "Invalid login");

			return View(model);
		}
	}
}
