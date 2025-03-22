using ecommerceAPP.Interfaces;
using EFpfa.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ecommerceAPP.Services
{
	public class SessionService : ISessionService
	{
		private const string SessionKey = "UserSession";

		public void SetUserSession(HttpContext context, Utilisateur user)
		{
			var sessionData = JsonConvert.SerializeObject(user);
			context.Session.SetString(SessionKey, sessionData);
			context.Session.SetInt32("UserId", user.Id);
			context.Session.SetString("UserEmail", user.Email);
			context.Session.SetString("UserRole", user.Type);
			context.Session.SetString("UserName", user.Nom);
			context.Session.SetString("IsAuthenticated", "true");
		}

		public Utilisateur GetUserFromSession(HttpContext context)
		{
			var sessionData = context.Session.GetString(SessionKey);
			return sessionData != null ? JsonConvert.DeserializeObject<Utilisateur>(sessionData) : null;
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
