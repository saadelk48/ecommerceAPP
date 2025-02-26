using ecommerceAPP.Data;
using ecommerceAPP.Interfaces;
using ecommerceAPP.ViewModels;
using EFpfa.Models;
using Microsoft.AspNetCore.Mvc;

namespace ecommerceAPP.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ISessionService _sessionService;

        public LoginController(IAuthService authService , ISessionService sessionService)
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
                    // Set user session
                    _sessionService.SetUserSession(HttpContext, user);

                    // Redirect based on role
                    string role = _sessionService.GetUserRole(HttpContext);

                    if (role == "Admin")
                    {
                        return RedirectToAction("Index", "Admin"); // Redirect to Admin Dashboard
                    }
                    else if (role == "Client")
                    {
                        return RedirectToAction("Index", "Layouts"); // Redirect to Client Home Page
                    }
                }
            }
            return View();
        }
        
    }
}
