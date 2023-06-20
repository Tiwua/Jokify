namespace Jokify.Controllers
{
	using Jokify.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
	using System.Diagnostics;

	[AllowAnonymous]
	public class HomeController : BaseController
	{

		public IActionResult Index()
		{
			return View();
		}
	}
}