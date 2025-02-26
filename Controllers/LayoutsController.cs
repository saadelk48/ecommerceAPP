using Microsoft.AspNetCore.Mvc;

namespace ecommerceAPP.Controllers
{
    public class LayoutsController : Controller
    {
        public IActionResult Index()
        {
			ViewData["Title"] = "ALPHA SCOOTERS";
			return View();
        }

		public IActionResult About()
		{
			return View();
		}

		public IActionResult Shop()
		{
			return View();
		}

		public IActionResult Blog()
		{
			return View();
		}

		public IActionResult ContactUs()
		{
			return View();
		}

		public IActionResult Register()
		{
			return View();
		}

	}
}
