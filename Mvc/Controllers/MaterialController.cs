using Domain.Interfaces.InterfacesServices;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        public async Task<IActionResult> Index()
        {
            var materials = await _materialService.GetAll();
            var materialsView = materials.Select(material => new Models.Material
            {
                Id = material.Id,
                Name = material.Name,
                PurchasePrice = material.PurchasePrice,
                MinimumQuantity = material.MinimumQuantity,
                Amount = material.Amount
            }).ToList();

            return View(materialsView);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.Material material)
        {
            try
            {
                material.PurchasePrice = Convert.ToDecimal(material.PurchasePrice);
            }
            catch (Exception)
            {
                ModelState.AddModelError("Preço", "O campo preço deve ser um número decimal");
            }

            if (ModelState.IsValid)
            {
                var materialDomain = new Domain.Entities.Material
                {
                    Name = material.Name,
                    PurchasePrice = material.PurchasePrice,
                    MinimumQuantity = material.MinimumQuantity,
                    Amount = material.Amount
                };

                await _materialService.Add(materialDomain);
                return RedirectToAction("Index");
            }

            return View(material);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInIngredients(Models.Material material)
        {
            //pegar o id do produto passado por parametro
            int productId = Convert.ToInt32(RouteData.Values["id"]);
            try
            {
                material.PurchasePrice = Convert.ToDecimal(material.PurchasePrice);
            }
            catch (Exception)
            {
                ModelState.AddModelError("Preço", "O campo preço deve ser um número decimal");
            }

            if (ModelState.IsValid)
            {
                var materialDomain = new Domain.Entities.Material
                {
                    Name = material.Name,
                    PurchasePrice = material.PurchasePrice,
                    MinimumQuantity = material.MinimumQuantity,
                    Amount = material.Amount
                };

                await _materialService.Add(materialDomain);
                return RedirectToAction("AddIngredients", "Ingredients", new { productId = productId });
            }

            return RedirectToAction("AddIngredients", "Ingredients", new { productId = productId });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var material = await _materialService.GetById(id);
            if (material == null)
            {
                return NotFound();
            }

            var materialView = new Models.Material
            {
                Id = material.Id,
                Name = material.Name,
                PurchasePrice = material.PurchasePrice,
                MinimumQuantity = material.MinimumQuantity,
                Amount = material.Amount
            };

            return View(materialView);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Models.Material material)
        {
            try
            {
                material.PurchasePrice = Convert.ToDecimal(material.PurchasePrice);
            }
            catch (Exception)
            {
                ModelState.AddModelError("Preço", "O campo preço deve ser um número decimal");
            }

            if (ModelState.IsValid)
            {
                var materialDomain = new Domain.Entities.Material
                {
                    Id = material.Id,
                    Name = material.Name,
                    PurchasePrice = material.PurchasePrice,
                    MinimumQuantity = material.MinimumQuantity,
                    Amount = material.Amount
                };

                var result = await _materialService.Update(materialDomain);
                return RedirectToAction("Index");
            }

            return View(material);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var material = await _materialService.GetById(id);
            if (material == null)
            {
                return NotFound();
            }

            var materialView = new Models.Material
            {
                Id = material.Id,
                Name = material.Name,
                PurchasePrice = material.PurchasePrice,
                MinimumQuantity = material.MinimumQuantity,
                Amount = material.Amount
            };

            return View(materialView);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _materialService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
