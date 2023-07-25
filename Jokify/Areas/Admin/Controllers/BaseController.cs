namespace Jokify.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using static Jokify.Areas.Admin.Constants.AdminConstants;

    [Area(AreaName)]
    [Authorize(Roles = AdminRoleName)]
    [Route("/[controller]/[Action]/{id?}")]
    public class BaseController : Controller
    {
        protected string GetUserId()
        {
            string id = string.Empty;

            if (User != null)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return id;
        }

        protected bool IsAdmin()
        {
            if (User.Identity.IsAuthenticated)
            {
                return User.IsInRole(AdminRoleName);
            }

            return false;
        }

    }
}
