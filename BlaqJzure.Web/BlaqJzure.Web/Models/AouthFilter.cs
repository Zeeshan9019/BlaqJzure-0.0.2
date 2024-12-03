using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlaqJzure.Web.Models
{
    public class AouthFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var controller = context.RouteData.Values["controller"]?.ToString();
            var action = context.RouteData.Values["action"]?.ToString();
            if (controller != "Account" || (action != "Login" && action != "logout"))
            {
                var session = context.HttpContext.Session;
                if (session.GetString("UserId") == null)
                {
                    context.Result = new RedirectToActionResult("login", "Account", null);
                }
            }
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
