﻿namespace Jokify.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
