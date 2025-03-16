using ecommerceAPP.Filters;
using ecommerceAPP.Interfaces;
using ecommerceAPP.Services;
using ecommerceAPP.ViewModels;
using EFpfa.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ecommerceAPP.Controllers.Admin
{
    [ServiceFilter(typeof(AuthorizationFilter))]
    public class ProductController : Controller
    {
        private readonly IProduitRepository _produitRepository;
        private readonly ICategorieRepository _categorieRepository;
        private readonly IFileUploadService _fileUploadService;

        public ProductController(IProduitRepository produitRepository, ICategorieRepository categorieRepository, IFileUploadService fileUploadService)
        {
            _produitRepository = produitRepository;
            _categorieRepository = categorieRepository;
            _fileUploadService = fileUploadService;
        }


        public IActionResult Index(int? categoryId)
        {
            Console.WriteLine("📌 [DEBUG] Entering Index() method...");

            var categories = _categorieRepository.GetAll();
            ViewBag.Categories = categories; // ✅ Store all categories in ViewBag

            var produits = _produitRepository.GetAll();

            if (categoryId.HasValue)
            {
                Console.WriteLine($"📌 [DEBUG] Filtering products by category ID: {categoryId.Value}");
                produits = produits.Where(p => p.CategorieId == categoryId.Value).ToList();
            }

            if (produits == null || !produits.Any())
            {
                Console.WriteLine("⚠️ [DEBUG] No products found.");
                ViewBag.Products = null;
                return View();
            }

            var productsVM = produits.Select(p => new ProductVM
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

            ViewBag.Products = productsVM;
            ViewBag.SelectedCategory = categoryId; // ✅ Store selected category in ViewBag
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _categorieRepository.GetAll().ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductVM vm)
        {
            Console.WriteLine("📌 [DEBUG] Create() method called.");

            Console.WriteLine($"[DEBUG] Received Data:");
            Console.WriteLine($"  Nom: {vm.Nom}");
            Console.WriteLine($"  Description: {vm.Description}");
            Console.WriteLine($"  Prix: {vm.Prix}");
            Console.WriteLine($"  Stock: {vm.StockQuantites}");
            Console.WriteLine($"  CategorieId: {vm.CategorieId}");
            Console.WriteLine($"  Image: {(vm.Image != null ? "Uploaded" : "Not Uploaded")}");

            // ✅ Manually set `CategorieNom`
            var category = _categorieRepository.GetById(vm.CategorieId);
            vm.CategorieNom = category?.Nom;

            string filePath = null;
            if (vm.Image != null)
            {
                try
                {
                    filePath = _fileUploadService.UploadFile(vm.Image, "uploads/products");
                    Console.WriteLine($"✅ [DEBUG] File uploaded successfully: {filePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ [DEBUG] File upload failed: {ex.Message}");
                    ModelState.AddModelError("Image", ex.Message);
                    ViewBag.Categories = _categorieRepository.GetAll().ToList();
                    return View(vm);
                }
            }

            vm.ImagePath = filePath; // ✅ Set the image path

            Console.WriteLine($"✅ [DEBUG] ImagePath set: {vm.ImagePath}");
            Console.WriteLine($"✅ [DEBUG] CategorieNom set: {vm.CategorieNom}");

            // ✅ Remove only problematic fields instead of clearing everything
            ModelState.Remove("ImagePath");
            ModelState.Remove("CategorieNom");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("❌ [DEBUG] Model is still invalid after removing fields. Listing errors:");

                foreach (var error in ModelState)
                {
                    string fieldName = error.Key;
                    string errorMessages = string.Join(", ", error.Value.Errors.Select(e => e.ErrorMessage));
                    Console.WriteLine($"❌ [DEBUG] Field: {fieldName}, Error(s): {errorMessages}");
                }

                ViewBag.Categories = _categorieRepository.GetAll().ToList();
                return View(vm);
            }

            var product = new Produit
            {
                Nom = vm.Nom,
                Description = vm.Description,
                Prix = vm.Prix,
                StockQuantites = vm.StockQuantites,
                CategorieId = vm.CategorieId,
                ImagePath = vm.ImagePath
            };

            Console.WriteLine($"✅ [DEBUG] Product created with ImagePath: {product.ImagePath}, CategorieNom: {vm.CategorieNom}");
            _produitRepository.Add(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
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

            ViewBag.Categories = _categorieRepository.GetAll().ToList();
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Edit(ProductVM vm)
        {
            Console.WriteLine("📌 [DEBUG] Edit() method called.");

            Console.WriteLine($"[DEBUG] Received Data:");
            Console.WriteLine($"  Nom: {vm.Nom}");
            Console.WriteLine($"  Description: {vm.Description}");
            Console.WriteLine($"  Prix: {vm.Prix}");
            Console.WriteLine($"  Stock: {vm.StockQuantites}");
            Console.WriteLine($"  CategorieId: {vm.CategorieId}");
            Console.WriteLine($"  Image: {(vm.Image != null ? "Uploaded" : "Not Uploaded")}");

            var product = _produitRepository.GetById(vm.Id);
            if (product == null)
            {
                return NotFound();
            }

            // ✅ Manually set `CategorieNom`
            var category = _categorieRepository.GetById(vm.CategorieId);
            vm.CategorieNom = category?.Nom;

            string filePath = product.ImagePath; // Keep existing image path
            if (vm.Image != null)
            {
                try
                {
                    filePath = _fileUploadService.UploadFile(vm.Image, "uploads/products");
                    Console.WriteLine($"✅ [DEBUG] File uploaded successfully: {filePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ [DEBUG] File upload failed: {ex.Message}");
                    ModelState.AddModelError("Image", ex.Message);
                    ViewBag.Categories = _categorieRepository.GetAll().ToList();
                    return View(vm);
                }
            }

            vm.ImagePath = filePath; // ✅ Update ImagePath only if new image is uploaded

            Console.WriteLine($"✅ [DEBUG] ImagePath set: {vm.ImagePath}");
            Console.WriteLine($"✅ [DEBUG] CategorieNom set: {vm.CategorieNom}");

            // ✅ Remove only problematic fields instead of clearing everything
            ModelState.Remove("ImagePath");
            ModelState.Remove("CategorieNom");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("❌ [DEBUG] Model is still invalid after removing fields. Listing errors:");
                foreach (var error in ModelState)
                {
                    string fieldName = error.Key;
                    string errorMessages = string.Join(", ", error.Value.Errors.Select(e => e.ErrorMessage));
                    Console.WriteLine($"❌ [DEBUG] Field: {fieldName}, Error(s): {errorMessages}");
                }

                ViewBag.Categories = _categorieRepository.GetAll().ToList();
                return View(vm);
            }

            // ✅ Update product details
            product.Nom = vm.Nom;
            product.Description = vm.Description;
            product.Prix = vm.Prix;
            product.StockQuantites = vm.StockQuantites;
            product.CategorieId = vm.CategorieId;
            product.ImagePath = vm.ImagePath;

            _produitRepository.Update(product);
            Console.WriteLine($"✅ [DEBUG] Product updated successfully!");

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _produitRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product); // This will open a confirmation page
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Console.WriteLine($"📌 [DEBUG] DeleteConfirmed() method called for product ID: {id}");

            var product = _produitRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            // ✅ Remove the product image from the server
            if (!string.IsNullOrEmpty(product.ImagePath))
            {
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", product.ImagePath.TrimStart('/'));
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                    Console.WriteLine($"✅ [DEBUG] Deleted product image: {fullPath}");
                }
            }

            _produitRepository.Delete(product.Id);
            Console.WriteLine($"✅ [DEBUG] Product deleted successfully!");

            return RedirectToAction("Index");
        }


    }
}
