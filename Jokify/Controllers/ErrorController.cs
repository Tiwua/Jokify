namespace Jokify.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [AllowAnonymous]
    public class ErrorController : Controller
    {
        public IActionResult AccessDenied()
        {
            return RedirectToAction("HandleError", new { statusCode = 401 });
        }
        public IActionResult Error()
        {
            return RedirectToAction("HandleError");
        }
        public IActionResult HandleError(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("Error404");
            }
            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View("Error");
        }

    }
}
