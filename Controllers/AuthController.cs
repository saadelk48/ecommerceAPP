using Microsoft.AspNetCore.Mvc;

namespace ecommerceAPP.Controllers
{
	public class AuthController : Controller	
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(string emaill, string password)
		{
			if (emaill == "admin" && password == "admin")
			{
				return View();
			}
			else
			{
				return RedirectToAction("Register", "Layouts");
			}
		}
	}
}
