using ecommerceAPP.Data;
using ecommerceAPP.Interfaces;
using ecommerceAPP.ViewModels;
using EFpfa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Assure-toi que cette ligne est présente

namespace ecommerceAPP.Controllers
{
	public class AuthController : Controller
	{
		private readonly IAuthService _authService;
		private readonly ISessionService _sessionService;

		public AuthController(IAuthService authService, ISessionService sessionService)
		{
			_authService = authService;
			_sessionService = sessionService;
		}

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(LoginVM vm)
		{
			if (ModelState.IsValid)
			{
				var user = _authService.Authenticate(vm.Email, vm.Password);

				if (user != null)
				{
					_sessionService.SetUserSession(HttpContext, user);
					HttpContext.Session.SetString("UserEmail", user.Email);
					HttpContext.Session.SetString("UserType", user.Type);

					string role = _sessionService.GetUserRole(HttpContext);

					if (role == "Admin")
					{
						return RedirectToAction("Index", "Category");
					}
					else if (role == "Client")
					{
						return RedirectToAction("Index", "Layouts"); // Redirection correcte pour les clients
					}

					return RedirectToAction("Index", "Layouts");
				}
			}

			ModelState.AddModelError("", "Email ou mot de passe incorrect");
			return View(vm);
		}

		[HttpPost]
		public IActionResult Register(RegisterVM vm)
		{
			if (ModelState.IsValid)
			{
				var existingUser = _authService.GetByEmail(vm.Email);
				if (existingUser != null)
				{
					ModelState.AddModelError("Email", "Cet e-mail est déjà enregistré.");
					return View("Login");
				}

				var newUser = _authService.RegisterUser(vm);

				// Connexion automatique après l'inscription
				if (newUser != null)
				{
					_sessionService.SetUserSession(HttpContext, newUser);
					HttpContext.Session.SetString("UserEmail", newUser.Email);
					HttpContext.Session.SetString("UserType", newUser.Type);

					string role = _sessionService.GetUserRole(HttpContext);

					if (role == "Admin")
					{
						return RedirectToAction("Index", "Category");
					}
					else if (role == "Client")
					{
						return RedirectToAction("Index", "Home");
					}
				}

				return RedirectToAction("Login");
			}
			return View("Login", vm);
		}

		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Login");
		}
	}
}
