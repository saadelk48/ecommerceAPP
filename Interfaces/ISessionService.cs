using EFpfa.Models;

namespace ecommerceAPP.Interfaces
{
    public interface ISessionService
    {
        void SetUserSession(HttpContext httpContext, Utilisateur user);
        int? GetUserId(HttpContext httpContext);
        string GetUserEmail(HttpContext httpContext);
        string GetUserRole(HttpContext httpContext);
        string GetUserName(HttpContext httpContext);
        bool IsAuthenticated(HttpContext httpContext);
        void ClearSession(HttpContext httpContext);

    }
}
