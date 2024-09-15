using Domain.Entities;
using Domain.Interfaces.InterfacesServices;
using Domain.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Mvc.Models;
using Mvc.Models.Enums;

namespace Mvc.Controllers
{
    
    public class PurchaseController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ICartService _cartService;

        private readonly IClientService _clientService;
        
        private readonly IAddressServices _addressService;
        
        private readonly IProductService _productService;

        private readonly IEmployeeService _employeeService;

        private readonly ISaleService _saleService;

        private readonly ISaleProductService _saleProductService;

        public PurchaseController(ILogger<HomeController> logger, ICartService cartService,
            IClientService clientService, IProductService productService, IAddressServices addressService,
            ISaleService saleService, IEmployeeService employeeService, ISaleProductService saleProductService)
        {
            _logger = logger;
            _cartService = cartService;
            _clientService = clientService;
            _productService = productService;
            _addressService = addressService;
            _saleService = saleService;
            _employeeService = employeeService;
            _saleProductService = saleProductService;
        }

        [Authorize(Roles = "Client")]
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
                Id = item.Id,
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
            Domain.Entities.Client client = new();

            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("https://localhost:7169/Identity/Account/Login");
            }

            var clientEmailClaim = User.Identities.FirstOrDefault().Claims.FirstOrDefault(x => x.Type.Contains("mail")).Value;
            
            try
            {
                client = await _clientService.GetByEmail(clientEmailClaim);
                if (client == null)
                    return RedirectToAction("Index", "User");
                cart.ClientId = client.Id;
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }

            var resultCart = await _cartService.GetByClientIdAndByProduct(client.Id, cart.ProductId);
            if (resultCart != null)
            {
                return RedirectToAction("IncreaseProduct", new { id = resultCart.Id });
            }

            var result = await _cartService.Add(cart);

            return RedirectToAction("Index");
        }

      
        [Route("IncreaseProduct/{id}")]
        public async Task<IActionResult> IncreaseProduct(int id)
        {
            var cart = await _cartService.GetById(id);
            cart.Amount++;
            await _cartService.Update(cart);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Decrement(int id)
        {
            var cart = await _cartService.GetById(id);
            if (cart.Amount > 1)
            {
                cart.Amount--;
                await _cartService.Update(cart);
            }
            return RedirectToAction("Index");
        }
        
        public async Task<ActionResult> RemoveFromCart(int id)
        {
            var cart = await _cartService.GetById(id);
            await _cartService.Delete(cart.Id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Checkout()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("https://localhost:7169/Identity/Account/Login");
            }

            var userId = await UserIdLogged();

            // Obtenha os itens do carrinho do cliente
            var cart = await _cartService.GetByClientId(userId);

            // Obtenha os endereços cadastrados do cliente
            var addresses = await _addressService.GetByClientId(userId);

            // Crie o ViewModel para o Checkout
            var checkoutViewModel = new Checkout
            {
                CartItems = cart.Select(item => new Models.Cart
                {
                    ProductName = item.Product.Name,
                    ProductPrice = item.Product.Price,
                    Amount = item.Amount,
                    TotalPrice = item.Product.Price * item.Amount
                }).ToList(),
                Addresses = addresses.Select(address => new Cadastre
                {
                    Id = address.Id,
                    Street = address.Street,
                    City = address.City,
                    State = address.State,
                    ZipCode = address.ZipCode
                }).ToList()
            };

            return View(checkoutViewModel);
        }

        public async Task<IActionResult> ConfirmCheckout(int SelectedAddressId, string NewStreet, int Number, string Referency, string NewCity, string NewState, string NewZipCode, bool Primary, EnumTypePayment PaymentMethod)
        {
            var userId = await UserIdLogged();

            // Valide se um novo endereço foi inserido, senão use o endereço selecionado
            int addressId = SelectedAddressId;

            if (!string.IsNullOrWhiteSpace(NewStreet))
            {
                var newAddress = new Address
                {
                    Street = NewStreet,
                    Number = Number,
                    Referency = Referency,
                    City = NewCity,
                    State = NewState,
                    ZipCode = NewZipCode,
                    Primary = Primary,
                    ClientId = userId
                };

                // Salve o novo endereço no banco de dados
                var result = await _addressService.Add(newAddress);
                addressId = newAddress.Id;
            }

            // Obter os itens do carrinho para o cliente atual
            var cartItems = await _cartService.GetByClientId(userId);

            List<Domain.Entities.SaleProduct> products = new List<Domain.Entities.SaleProduct>();
            foreach (var product in cartItems)
            {
                products.Add(new Domain.Entities.SaleProduct
                {
                    ProductId = product.ProductId,
                    Amount = product.Amount
                });
            }


            // Calcular o valor total da compra
            decimal totalValue = cartItems.Sum(item => item.Product.Price * item.Amount);

            // Criar uma nova venda
            var sale = new Domain.Entities.Sale
            {
                SaleDate = DateTime.Now,
                ClientId = userId,
                TotalValue = totalValue,
                TypePayment = (Domain.Entities.Enums.EnumTypePayment)PaymentMethod,  // Converta o método de pagamento para o enum
                StatusSale = (Domain.Entities.Enums.EnumStatusSale)EnumStatusSale.pendente,  // Definir como em progresso, pode ajustar conforme necessidade
                StatusPayment = (Domain.Entities.Enums.EnumStatusPayment)EnumStatusPayment.pendente,  // Definir como pagamento pendente
                EmployeeId = 1,  // Defina um ID de funcionário padrão se necessário
                Discount = null  // Ajuste conforme sua lógica de descontos
            };

            // Salvar a venda no banco de dados
            await _saleService.Add(sale, products);

            // Após salvar a venda, você pode remover os itens do carrinho
            foreach (var item in cartItems)
            {
                await _cartService.Delete(item.Id);
            }

            // Redirecionar para a página de confirmação da compra com o ID da venda
            return RedirectToAction("OrderConfirmation", new { saleId = sale.Id });
        }



        public async Task<IActionResult> OrderConfirmation(int saleId)
        {
            var sale = await _saleService.GetById(saleId);

            var orderConfirmationViewModel = new Models.Sale
            {
                Id = sale.Id,
                ClientName = "",
                SaleDate = sale.SaleDate,
                TotalValue = sale.TotalValue,
                TypePayment = (EnumTypePayment)sale.TypePayment,
                StatusSale = (EnumStatusSale)sale.StatusSale,
                StatusPayment = (EnumStatusPayment)sale.StatusPayment
            };

            var clientName = await _clientService.GetById(sale.ClientId);
            orderConfirmationViewModel.ClientName = clientName.Name;

            var employeeName = await _employeeService.GetById(sale.EmployeeId);
            orderConfirmationViewModel.EmployeeName = employeeName.Name;

            var saleProducts = await _saleProductService.GetBySale(saleId);
            foreach (var product in saleProducts)
            {
                var productName = await _productService.GetById(product.ProductId);
                orderConfirmationViewModel.SaleProductsName.Add(productName.Name);
            }

            return View(orderConfirmationViewModel);
        }


        public async Task<int> UserIdLogged()
        {
            var userEmail = User.Identities.FirstOrDefault().Claims.FirstOrDefault(x => x.Type.Contains("mail")).Value;
            var result = await _clientService.GetByEmail(userEmail);
            return result.Id;
        }
    }
}
