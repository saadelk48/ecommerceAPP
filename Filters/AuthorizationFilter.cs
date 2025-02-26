using ecommerceAPP.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ecommerceAPP.Filters
{
    public class AuthorizationFilter : IActionFilter
    {
        private readonly ISessionService _sessionService;
        private readonly string _requiredRole;

        public AuthorizationFilter(ISessionService sessionService, string requiredRole)
        {
            _sessionService = sessionService;
            _requiredRole = requiredRole;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var userRole = _sessionService.GetUserRole(context.HttpContext);

            if (userRole != _requiredRole)
            {
                context.Result = new RedirectToActionResult("Index", "Layouts", null);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Not needed here
        }
    }
}
