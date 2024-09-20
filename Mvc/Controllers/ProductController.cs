using Domain.Interfaces.InterfacesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;

namespace Mvc.Controllers
{
    public class ProductController(IProductService productService, IIngredientsService ingredientsService, IMaterialService materialService) : Controller
    {
        private readonly IProductService _productService = productService;
        private readonly IIngredientsService _ingredientsService = ingredientsService;
        private readonly IMaterialService _materialService = materialService;

        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> Index()
        {
            List<Product> listProductViewModel = new List<Product>();

            var products = await _productService.GetAll();

            foreach (var product in products)
            {
                Product productViewModel = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Amount = product.Amount,
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

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = _productService.GetById(id);
            return View(product);
        }

        // GET: ProductController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create(Product productModel)
        {
            try
            {
                productModel.Price = Convert.ToDecimal(productModel.Price);
            }
            catch (Exception)
            {
                ModelState.AddModelError("Preço", "O campo preço deve ser um número decimal");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    Domain.Entities.Product product = new Domain.Entities.Product
                    {
                        Name = productModel.Name,
                        Price = productModel.Price,
                        Amount = productModel.Amount
                    };

                    var result = await _productService.Add(product);

                    return RedirectToAction("AddIngredients", "Ingredients", new { productId = product.Id });
                
                }
                return View(productModel);
            }
            catch
            {
                return View();
            }
        }

      
        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var product = await _productService.GetById(id);
            Product productModel = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Amount = product.Amount
            };
            return View(productModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(Product productModel)
        {
            try
            {
                productModel.Price = Convert.ToDecimal(productModel.Price);
            }
            catch (Exception)
            {
                ModelState.AddModelError("Preço", "O campo preço deve ser um número decimal");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    Domain.Entities.Product product = new Domain.Entities.Product
                    {
                        Name = productModel.Name,
                        Price = productModel.Price,
                        Amount = productModel.Amount
                    };

                    var result = await _productService.Update(product);
                    return RedirectToAction(nameof(Index));
                }
                return View(productModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productService.GetById(id);
            Product productModel = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Amount = product.Amount
            };
            return View(productModel);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var result = await _productService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
