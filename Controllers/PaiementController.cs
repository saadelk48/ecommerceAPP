using Microsoft.AspNetCore.Mvc;

namespace ecommerceAPP.Controllers
{
    public class PaiementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConfirmerPaiement(string modePaiement)
        {
            if (string.IsNullOrEmpty(modePaiement))
            {
                TempData["Message"] = "Veuillez sélectionner un mode de paiement.";
                return RedirectToAction("Index");
            }

            TempData["Message"] = $"Paiement réussi avec le mode : {modePaiement}.";
            return RedirectToAction("Confirmation");
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}

