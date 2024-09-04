using Domain.Entities;
using Domain.Interfaces.InterfacesServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;

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


        // GET: CartController1
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

        // GET: CartController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController1/AddToCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(Domain.Entities.Cart cart)
        {
            // Obtendo o ID do cliente logado (por exemplo, do HttpContext)
            var clientId = 1; // Supondo que você tenha uma forma de pegar o cliente logado

            // Verifica se a quantidade é maior que zero
            

           

        

            // Adiciona o produto ao carrinho usando o serviço
            await _cartService.Add(cart);

            return RedirectToAction("Index");
        }
        // GET: CartController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController1/Edit/5
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

        // GET: CartController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController1/Delete/5
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
