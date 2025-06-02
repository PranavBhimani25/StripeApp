using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StripeApp.Helper;
using StripeApp.Models;
using System.Globalization;

namespace StripeApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;


        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public IActionResult Shop()
        {
            var products = new List<Product>
            {
                new Product{ProductId = 1, Name="T-Shirt in Gray",Description = "Cotton T-Shirts New ",Price = 1000, Stock= 1001,ImageUrl="/Images/227871e7-4fb7-4a10-b526-34d7b28f28dc.webp"},
                new Product{ProductId = 2, Name="Sukuna T-shirt",Description = "Demon King T-shirt",Price = 3000, Stock= 100,ImageUrl="/Images/5d75c96f-37b2-4f08-800d-78e847117e69.jpeg"},
                new Product{ProductId = 3, Name="Shorts",Description = "White Shorts",Price = 2000, Stock= 150,ImageUrl="/Images/c1032c90-b572-4124-b0b7-c0441129c782.webp"},
                new Product{ProductId = 4, Name="Shorts V_2",Description = "Black Shorts",Price = 5500, Stock= 300,ImageUrl="/Images/c015c844-7f8d-4b79-8590-d4120336c417.webp"},
                new Product{ProductId = 5, Name="Buy TwoGet one Free T-Shirts",Description = "Total 3 T-Shiirt",Price = 1500, Stock= 2100,ImageUrl="/Images/46c1eb72-6a58-4073-9da5-e0648cbd3014.webp"},
                new Product{ProductId = 6, Name="Jacket",Description = "JVX men jackets ",Price = 3500, Stock= 1100,ImageUrl="/Images/1d8e9c1e-3660-464e-bd7b-e6a669401fb7.jpg"}


            };
            
            //SessionExtensions.Add(products);
            HttpContext.Session.SetObjectAsJson("Products",products);
            return View(products);
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            const string productSessionKey = "Products";
            const string cartSessionKey = "Cart";

            // Retrieve the product list from session
            var productList = HttpContext.Session.GetObjectFromJson<List<Product>>(productSessionKey);
            if (productList == null || !productList.Any())
            {
                // Optionally handle the case when no products are available
                return RedirectToAction("Shop");
            }

            // Find the product by ID
            var product = productList.Find(p => p.ProductId == id);
            if (product == null)
            {
                // Optionally handle the case when the product is not found
                return RedirectToAction("Shop");
            }

            // Get existing cart from session or create a new one
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(cartSessionKey) ?? new List<CartItem>();

            // Check if the item is already in the cart
            var existingItem = cart.FirstOrDefault(x => x.ProductId == id);
            if (existingItem != null)
            {
                existingItem.Quantity += 1;
            }
            else
            {
                cart.Add(new CartItem
                {
                    Id = cart.Count + 1, // Optional: You can auto-increment ID like this if needed
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Quantity = 1
                });
            }

            // Save the updated cart back to session
            HttpContext.Session.SetObjectAsJson(cartSessionKey, cart);

            return RedirectToAction("Shop");

        }

        public IActionResult Cart()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            return View(cart);
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId, bool increase)
        {
            string cartKey = "Cart";
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(cartKey) ?? new List<CartItem>();

            var item = cart.FirstOrDefault(c => c.ProductId == productId);
            if (item != null)
            {
                if (increase)
                    item.Quantity += 1;
                else if (item.Quantity > 1)
                    item.Quantity -= 1;
            }

            HttpContext.Session.SetObjectAsJson(cartKey, cart);
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public IActionResult RemoveItem(int cartItemId)
        {
            string cartKey = "Cart";

            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(cartKey);
            if (cart != null)
            {
                var itemToRemove = cart.FirstOrDefault(i => i.Id == cartItemId);
                if (itemToRemove != null)
                {
                    cart.Remove(itemToRemove);
                    HttpContext.Session.SetObjectAsJson(cartKey, cart);
                }
            }

            return RedirectToAction("Cart");
        }

    }
}
