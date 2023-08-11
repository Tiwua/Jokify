namespace Jokify.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ErrorController : BaseController
    {
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("Error404");
            }
            else if (statusCode == 401)
            {
                return View("Error401");
            }

            return View("Error");
        }
    }
}
