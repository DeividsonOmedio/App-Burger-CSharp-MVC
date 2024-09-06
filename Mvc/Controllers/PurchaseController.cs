using Domain.Interfaces.InterfacesServices;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Mvc.Models;

namespace Mvc.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ICartService _cartService;

        private readonly IClientService _clientService;
        
        private readonly IProductService _productService;

        public PurchaseController(ILogger<HomeController> logger, ICartService cartService, IClientService clientService, IProductService productService)
        {
            _logger = logger;
            _cartService = cartService;
            _clientService = clientService;
            _productService = productService;
        }

        public async Task<ActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("https://localhost:7169/Identity/Account/Login");
            }
            var userId = await UserIdLogged();

            var cart = await _cartService.GetByClientId(userId);

            var cartViewModel = cart.Select(item => new Models.Cart
            {
                ProductId = item.ProductId,
                ProductName = item.Product.Name,
                ProductPrice = item.Product.Price,
                Amount = item.Amount,
                TotalPrice = item.Product.Price * item.Amount,
                ClientId = item.ClientId
            }).ToList();

            return View(cartViewModel);



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
            
            try
            {
                var client = await _clientService.GetByEmail(clientEmailClaim);
                cart.ClientId = client.Id;
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }

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

        public async Task<int> UserIdLogged()
        {
            var userEmail = User.Identities.FirstOrDefault().Claims.FirstOrDefault(x => x.Type.Contains("mail")).Value;
            var result = await _clientService.GetByEmail(userEmail);
            return result.Id;
        }
    }
}
