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

        public IActionResult Index()
        {
            // Buscar todos os produtos
            var products = _productService.GetAll().Result;

            // Mapear os produtos para o ViewModel
            var viewModelProducts = products.Select(p => new Mvc.Models.Product
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Amount = p.Amount,

                // Para cada produto, buscar os ingredientes e obter os nomes dos materiais
                Ingredients = _ingredientsService.GetByMaterialId(p.Id).Result.Select(i => i.Material.Name).ToList()
                                                 
            });

            // Retornar a view com os produtos mapeados
            return View(viewModelProducts);
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
