using Domain.Interfaces.InterfacesServices;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using System.Diagnostics;

namespace Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProductService _productService;

        private readonly IMaterialService _materialService;

        private readonly IIngredientsService _ingredientsService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IMaterialService materialService, IIngredientsService ingredientsService)
        {
            _logger = logger;
            _productService = productService;
            _materialService = materialService;
            _ingredientsService = ingredientsService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Manager");
            }
            List<Product> listProductViewModel = new List<Product>();

            // Buscar todos os produtos
            var products = await _productService.GetAll();

            foreach (var product in products)
            {
                Product productViewModel = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Amount = product.Amount,
                    Category = (Models.Enums.EnumCategoryProducts?)product.Category,
                    Image = product.Image,
                    Ingredients = new List<string>()
                };

                // Para cada produto, buscar os ingredientes e obter os nomes dos materiais
                var ingredients = await _ingredientsService.GetMaterialsByProductId(product.Id);
                
                foreach (var ingredient in ingredients)
                {
                    productViewModel.Ingredients.Add(ingredient.Key);
                }

                listProductViewModel.Add(productViewModel);
            }

            return View(listProductViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
