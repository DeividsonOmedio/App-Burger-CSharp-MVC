using Domain.Entities;
using Domain.Interfaces.InterfacesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;

namespace Mvc.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ISaleService _saleService;
        private readonly ISaleProductService _saleProductService;

        public ManagerController(ISaleService saleService, ISaleProductService saleProductService)
        {
            _saleService = saleService;
            _saleProductService = saleProductService;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var result = await _saleService.GetAll();

            var saleProductsViewModel = new List<Models.Sale>();

            foreach (var sale in result)
            {
                var saleViewModel = new Models.Sale
                {
                    Id = sale.Id,
                    SaleDate = sale.SaleDate,
                    ClientId = sale.ClientId,
                    ClientName = sale.Client.Name,
                    PhoneNumber = sale.Client.PhoneNumber,
                    TotalValue = sale.TotalValue,
                    TypePayment = (Models.Enums.EnumTypePayment)sale.TypePayment,
                    StatusSale = (Models.Enums.EnumStatusSale)sale.StatusSale,
                    StatusPayment = (Models.Enums.EnumStatusPayment)sale.StatusPayment,
                    Discount = sale.Discount,
                    EmployeeId = sale.EmployeeId,
                    EmployeeName = sale.Employee.Name,
                    SaleProductsName = new List<string>()
                };

                var resultProducts = await _saleProductService.GetBySale(sale.Id);

                foreach (var saleProduct in resultProducts)
                {
                    saleViewModel.SaleProductsName.Add(saleProduct.Product.Name);
                }

                saleProductsViewModel.Add(saleViewModel);
            }

            return View(saleProductsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatusSale(int SaleId, Models.Enums.EnumStatusSale StatusSale)
        {
            var result = await _saleService.GetById(SaleId);
            if (result == null)
            {
                return NotFound();
            }

            result.StatusSale = (Domain.Entities.Enums.EnumStatusSale)StatusSale;
            var response = await _saleService.Update(result, new List<SaleProduct>());

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatusPayment(int SaleId, Models.Enums.EnumStatusPayment StatusPayment)
        {
            var result = await _saleService.GetById(SaleId);
            if (result == null)
            {
                return NotFound();
            }

            result.StatusPayment = (Domain.Entities.Enums.EnumStatusPayment)StatusPayment;
            var response = await _saleService.Update(result, new List<SaleProduct>());

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeTypePayment(int SaleId, Models.Enums.EnumTypePayment TypePayment)
        {
            var result = await _saleService.GetById(SaleId);
            if (result == null)
            {
                return NotFound();
            }

            result.TypePayment = (Domain.Entities.Enums.EnumTypePayment)TypePayment;
            var response = await _saleService.Update(result, new List<SaleProduct>());

            return RedirectToAction("Index");
        }
    }
}
