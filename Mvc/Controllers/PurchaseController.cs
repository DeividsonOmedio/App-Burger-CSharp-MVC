using Domain.Interfaces.InterfacesServices;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ICartService _cartService;

        public PurchaseController(ILogger<HomeController> logger, ICartService cartService)
        {
            _logger = logger;
            _cartService = cartService;
        }

        public async Task<ActionResult> Index()
        {
            var cart = await _cartService.GetById(1);

            Models.Cart cart1 = new Models.Cart
            {
                Id = cart.Id,
                ProductId = cart.Id
            };
            return View(cart1);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(Domain.Entities.Cart cart)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("https://localhost:7169/Identity/Account/Login");
            }

            var clientEmailClaim = User.Identities.FirstOrDefault().Claims.FirstOrDefault(x => x.Type.Contains("mail")).Value;
            var clientNameClaim = User.Identity.Name;
            await _cartService.Add(cart);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
