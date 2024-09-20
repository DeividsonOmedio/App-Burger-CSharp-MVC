using Domain.Interfaces.InterfacesServices;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class IngredientsController(IIngredientsService ingredientsService, IProductService productService, IMaterialService materialService) : Controller
    {
        private readonly IIngredientsService _ingredientsService = ingredientsService;
        private readonly IProductService _productService = productService;
        private readonly IMaterialService _materialService = materialService;

        public async Task<IActionResult> Index(int id)
        {
            return View();
        }

        public async Task<IActionResult> AddIngredients(int productId)
        {
            if (productId == 0)
            {
                productId = Convert.ToInt32(RouteData.Values["id"]);
            }

            // Buscar o produto pelo ID
            var product = await _productService.GetById(productId);

            // Buscar todos os materiais disponíveis
            var materials = await _materialService.GetAll();

            // Buscar materiais já associados ao produto
            var materialInProducts = await _ingredientsService.GetMaterialsByProductId(productId);

            // Criar uma lista de materiais para exibir na view
            var materialsViewModel = materials.Select(material => new Models.Material
            {
                Id = material.Id,
                Name = material.Name,
                MinimumQuantity = material.MinimumQuantity,
                PurchasePrice = material.PurchasePrice
            }).ToList();

            // Criar o ViewModel que contém o produto, os materiais disponíveis e os materiais associados ao produto
            var viewModel = new Models.Ingredients
            {
                NameProduct = product.Name,
                PriceProduct = product.Price,
                ProductId = product.Id,
                AmountProduct = product.Amount,
                Materials = materialsViewModel, // Lista de materiais disponíveis
                MaterialsProducts = materialInProducts // Materiais associados ao produto e suas quantidades
            };
            // Retornar para a view chamada AddInProduct.cshtml
            return View("AddInProduct", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredients(int productId, int MaterialId, int Amount)
        {
            if (productId == 0 || MaterialId == 0)
                return RedirectToAction("Index", "Product");

            Domain.Entities.Ingredients ingredient = new Domain.Entities.Ingredients
            {
                MaterialId = MaterialId,
                ProductId = productId,
                Amount = Amount
            };
            var result = await _ingredientsService.Add(ingredient);

            return RedirectToAction("AddIngredients", new { productId });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAmount(int productId, string name, decimal amount)
        {
            if (string.IsNullOrEmpty(name))
                return RedirectToAction("Index", "Product");

            var material = await _materialService.GetByName(name);

            var ingredients = await _ingredientsService.GetByMaterialIdByProductId(material.Id, productId);

            ingredients.Amount = amount;

            var result = await _ingredientsService.Update(ingredients);

            return RedirectToAction("AddIngredients", new { productId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteInProduct(int productId, string name)
        {
            if (name == null)
                return RedirectToAction("Index", "Product");

            var material = await _materialService.GetByName(name);

            var ingredients = await _ingredientsService.GetByMaterialIdByProductId(material.Id, productId);

            var result = await _ingredientsService.Delete(ingredients.Id);

            return RedirectToAction("AddIngredients", new { productId });
        }
    }
}
