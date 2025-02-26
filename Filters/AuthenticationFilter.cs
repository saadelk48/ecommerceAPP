using ecommerceAPP.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ecommerceAPP.Filters
{
    public class AuthenticationFilter:IActionFilter
    {
        private readonly ISessionService _sessionService;

        public AuthenticationFilter(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Check if user is authenticated
            if (!_sessionService.IsAuthenticated(context.HttpContext))
            {
                context.Result = new RedirectToActionResult("Login", "Login", null);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Not needed here
        }
    }
}
