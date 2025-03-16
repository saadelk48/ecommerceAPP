using ecommerceAPP.Filters;
using ecommerceAPP.Interfaces;
using ecommerceAPP.ViewModels;
using EFpfa.Models;
using Microsoft.AspNetCore.Mvc;

namespace ecommerceAPP.Controllers.Admin
{
    [ServiceFilter(typeof(AuthorizationFilter))]
    public class CategoryController : Controller
    {
        private readonly ICategorieRepository _categorieRepository;

        public CategoryController(ICategorieRepository categorieRepository)
        {
            _categorieRepository = categorieRepository;
        }
        public IActionResult Index()
        {
            var categories = _categorieRepository.GetAll();
            return View(categories);
        }

        [HttpPost]
        public IActionResult Create(CategoryVM vm)
        {
            if (ModelState.IsValid)
            {
                var category = new Categorie
                {
                    Nom = vm.Nom
                };

                _categorieRepository.Add(category);
            }
            var categories = _categorieRepository.GetAll();
            return View("Index", categories);
        }

        [HttpPost]
        public IActionResult Edit(CategoryVM vm)
        {
            if (ModelState.IsValid)
            {
                var category = new Categorie
                {
                    Id = vm.Id,
                    Nom = vm.Nom
                };

                _categorieRepository.Update(category);
            }
            // ✅ Redirect to the category list after updating
            var categories = _categorieRepository.GetAll();
            return View("Index", categories);
        }

        public IActionResult Delete(int id)
        {
            _categorieRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
