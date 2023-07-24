namespace Jokify.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static Jokify.Areas.Admin.Constants.AdminConstants;

    [Area(AreaName)]
    [Authorize(Roles = AdminRoleName)]
    [Route("/Admin/[controller]/[Action]/{id?}")]
    public class BaseController : Controller
    {

    }
}
