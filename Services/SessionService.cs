using ecommerceAPP.Interfaces;
using EFpfa.Models;

namespace ecommerceAPP.Services
{
    public class SessionService : ISessionService
    {
        public void SetUserSession(HttpContext httpContext, Utilisateur user)
        {
            httpContext.Session.SetInt32("UserId", user.Id);
            httpContext.Session.SetString("UserEmail", user.Email);
            httpContext.Session.SetString("UserRole", user.Type);
            httpContext.Session.SetString("UserName", user.Nom);
            httpContext.Session.SetString("IsAuthenticated", "true");
        }

        public int? GetUserId(HttpContext httpContext)
        {
            return httpContext.Session.GetInt32("UserId");
        }

        public string GetUserEmail(HttpContext httpContext)
        {
            return httpContext.Session.GetString("UserEmail");
        }

        public string GetUserRole(HttpContext httpContext)
        {
            return httpContext.Session.GetString("UserRole");
        }

        public string GetUserName(HttpContext httpContext)
        {
            return httpContext.Session.GetString("UserName");
        }

        public bool IsAuthenticated(HttpContext httpContext)
        {
            return httpContext.Session.GetString("IsAuthenticated") == "true";
        }

        public void ClearSession(HttpContext httpContext)
        {
            httpContext.Session.Clear();
        }
    }
}
