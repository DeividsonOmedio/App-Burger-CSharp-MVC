using Domain.Interfaces.InterfacesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;

namespace Mvc.Controllers
{
    public class ManagerController(ISaleService saleService, ISaleProductService saleProductService) : Controller
    {
        private readonly ISaleService _saleService = saleService;
        private readonly ISaleProductService _saleProductService = saleProductService;

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var result = await _saleService.GetAll();

            // Lista que vai armazenar o ViewModel para ser exibido na View
            var saleProductsViewModel = new List<Sale>();

            // Percorre todas as vendas e cria um ViewModel para cada venda
            foreach (var sale in result)
            {

                var saleViewModel = new Sale
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

                // Obtém os produtos relacionados a cada venda
                var resultProducts = await _saleProductService.GetBySale(sale.Id);

                // Adiciona os nomes dos produtos no ViewModel
                foreach (var saleProduct in resultProducts)
                {
                    saleViewModel.SaleProductsName.Add(saleProduct.Product.Name);
                }

                // Adiciona o ViewModel da venda na lista principal
                saleProductsViewModel.Add(saleViewModel);
            }

            // Retorna a View com o ViewModel
            return View(saleProductsViewModel);
        }

        public ActionResult ChangeStatus(Sale sale)
        {
            // Método para alterar status da venda, a lógica aqui depende do que deseja implementar
            return View(sale);
        }
    }
}