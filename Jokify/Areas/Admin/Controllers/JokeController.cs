namespace Jokify.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class JokeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
