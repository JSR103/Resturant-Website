using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Repositories;
using Restaurant.Models;
using Microsoft.AspNetCore.Authorization;
using Restaurant.Models.ViewModels;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Controllers
{
    public class CartController : Controller
    {
        private IRestaurantRepository restrepo;

        public CartController(IRestaurantRepository repo)
        {
            restrepo = repo;
        }

        [Route("Cart/Index")]
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        //[HttpPost]
        public RedirectToActionResult AddToCart(Menu1 m, string returnUrl)
        {
            Menu1 product = restrepo.Foods
                .FirstOrDefault(p => p.Menu1ID == m.Menu1ID);

            if (product != null)
            {
                Cart cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(Menu1 m,
                string returnUrl)
        {
            Menu1 product = restrepo.Foods
                .FirstOrDefault(p => p.Menu1ID == m.Menu1ID);

            if (product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
    }
}
