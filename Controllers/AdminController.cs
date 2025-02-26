using ecommerceAPP.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ecommerceAPP.Controllers
{
    public class AdminController : Controller
    {
        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult Index()
        {
            return View();
        }
    }
}
