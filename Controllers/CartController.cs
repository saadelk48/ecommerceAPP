using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ecommerceAPP.Interfaces;
using ecommerceAPP.Models;
using ecommerceAPP.ViewModels;

namespace ecommerceAPP.Controllers
{
    public class CartController : Controller
    {
        private const string CartSessionKey = "Cart";
        private readonly IProduitRepository _produitRepository;

        public CartController(IProduitRepository produitRepository)
        {
            _produitRepository = produitRepository;
        }

        public IActionResult Index()
        {
            var cart = GetCartFromSession();
            return View(cart);
        }

        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            var cart = GetCartFromSession();
            var product = _produitRepository.GetById(productId);

            if (product == null)
            {
                return NotFound();
            }

            var existingItem = cart.FirstOrDefault(p => p.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity; // Correctly updates quantity
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    Nom = product.Nom,
                    Prix = product.Prix,
                    ImagePath = product.ImagePath,
                    Quantity = quantity // Stores the selected quantity
                });
            }

            SaveCartToSession(cart);
            TempData["SuccessMessage"] = $"{product.Nom} a été ajouté au panier !";
            return RedirectToAction("Index","Shop"); // Redirect to cart page
        }
        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            var cart = GetCartFromSession();
            var cartItem = cart.FirstOrDefault(p => p.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity = quantity; // Update the quantity
                SaveCartToSession(cart);
            }

            return RedirectToAction("Index"); // Reload the cart page
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var cart = GetCartFromSession();
            var itemToRemove = cart.FirstOrDefault(p => p.ProductId == productId);

            if (itemToRemove != null)
            {
                cart.Remove(itemToRemove);
                SaveCartToSession(cart);
            }

            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove(CartSessionKey);
            return RedirectToAction("Index");
        }

        private List<CartItem> GetCartFromSession()
        {
            var cartJson = HttpContext.Session.GetString(CartSessionKey);
            return cartJson != null ? JsonSerializer.Deserialize<List<CartItem>>(cartJson) : new List<CartItem>();
        }

        private void SaveCartToSession(List<CartItem> cart)
        {
            HttpContext.Session.SetString(CartSessionKey, JsonSerializer.Serialize(cart));
        }
    }
}
