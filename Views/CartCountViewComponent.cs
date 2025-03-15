using ecommerceAPP.Models;
using ecommerceAPP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

public class CartCountViewComponent : ViewComponent
{
	public IViewComponentResult Invoke()
	{
		var cartJson = HttpContext.Session.GetString("Cart");
		var cart = cartJson != null ? JsonSerializer.Deserialize<List<CartItem>>(cartJson) : new List<CartItem>();

		int cartCount = cart.Sum(item => item.Quantity); // Count total items in cart
		return View(cartCount);
	}
}

