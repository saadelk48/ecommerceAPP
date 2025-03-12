using ecommerceAPP.Interfaces;
using ecommerceAPP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ecommerceAPP.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProduitRepository _produitRepository;
        private readonly ICategorieRepository _categorieRepository;

        public ShopController(IProduitRepository produitRepository, ICategorieRepository categorieRepository)
        {
            _produitRepository = produitRepository;
            _categorieRepository = categorieRepository;
        }

        public IActionResult Index()
        {
            var products = _produitRepository.GetAll()
                .Select(p => new ProductVM
                {
                    Id = p.Id,
                    Nom = p.Nom,
                    Description = p.Description,
                    Prix = p.Prix,
                    StockQuantites = p.StockQuantites,
                    CategorieId = p.CategorieId,
                    CategorieNom = _categorieRepository.GetById(p.CategorieId)?.Nom,
                    ImagePath = p.ImagePath
                }).ToList();

            ViewBag.Categories = _categorieRepository.GetAll().ToList();
            return View(products);
        }
        public IActionResult Details(int id)
        {
            var product = _produitRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            var productVM = new ProductVM
            {
                Id = product.Id,
                Nom = product.Nom,
                Description = product.Description,
                Prix = product.Prix,
                StockQuantites = product.StockQuantites,
                CategorieId = product.CategorieId,
                CategorieNom = _categorieRepository.GetById(product.CategorieId)?.Nom,
                ImagePath = product.ImagePath
            };

            return View(productVM);
        }

    }
}
