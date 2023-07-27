namespace Jokify.ActionFilters.FIlters
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Filters;

	public class DynamicLayoutActionFilter : IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext context)
		{
			var controller = context.Controller as Controller;

			if (controller != null && controller.User.Identity.IsAuthenticated)
			{
				if (controller.User.IsInRole("Administrator"))
				{
					controller.ViewData["Layout"] = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";
                }
				else
				{
					controller.ViewData["Layout"] = "~/Views/Shared/_Layout.cshtml";
				}
			}
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			
		}
	}
}
