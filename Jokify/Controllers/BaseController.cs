﻿namespace Jokify.Controllers
{
    using Jokify.Common.Contracts;
    using Jokify.Core.Models.Joke;
    using Jokify.Infrastructure.Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Filters;
	using System.Security.Claims;
    using static Jokify.Areas.Admin.Constants.AdminConstants;

    [Authorize]
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
