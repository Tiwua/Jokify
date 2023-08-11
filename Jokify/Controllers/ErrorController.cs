namespace Jokify.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ErrorController : BaseController
    {
        public IActionResult HandleError(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("Error404");
            }
            // Handle other error cases here

            return View("Error");
        }
    }
}
