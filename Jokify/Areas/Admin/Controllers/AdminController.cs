namespace Jokify.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
