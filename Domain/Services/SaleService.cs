using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Interfaces.InterfacesRepositories;
using Domain.Interfaces.InterfacesServices;
using Domain.Notifications;

namespace Domain.Services
{
    public class SaleService(ISaleRepository saleRepository, ISaleProductRepository saleProductRepository, IEmployeeService employeeService, IClientService clientService) : ISaleService
    {
        private readonly ISaleRepository _saleRepository = saleRepository;
        private readonly ISaleProductRepository _saleProductRepository = saleProductRepository;
        private readonly IEmployeeService _employeeService = employeeService;
        private readonly IClientService _clientService = clientService;

        public async Task<Notifies> Add(Sale sale, List<SaleProduct> saleProducts)
        {
            if (sale == null)
                return Notifies.Error("Venda inválida");

            if (saleProducts == null || saleProducts.Count == 0)
                return Notifies.Error("Produtos inválidos");

            var result = await _saleRepository.Add(sale);
            if (result == null)
                return Notifies.Error("Erro ao adicionar a venda");

            foreach (var saleProduct in saleProducts)
            {
                if (saleProduct == null)
                    return Notifies.Error("Produto inválido");

                saleProduct.SaleId = sale.Id;

                var productResult = await _saleProductRepository.Add(saleProduct);
                if (productResult == null)
                    return Notifies.Error("Erro ao adicionar produto: " + productResult.Message);
            }

            return Notifies.Success("Venda e produtos adicionados com sucesso!");
        }


        public async Task<Notifies> Update(Sale sale, List<SaleProduct> saleProducts)
        {
            if (sale == null)
                return Notifies.Error("Venda inválida");

            // Verifica se a venda existe
            var existingSale = await _saleRepository.GetById(sale.Id);
            if (existingSale == null)
                return Notifies.Error("Venda não encontrada");

            // Atualiza a venda
            var result = await _saleRepository.Update(sale);
            if (result == null)
                return result;

            // Removendo produtos antigos associados à venda (opcional, depende da lógica de negócios)
            var existingProducts = await _saleProductRepository.GetBySale(sale.Id);
            foreach (var product in existingProducts)
            {
                if (!saleProducts.Any(sp => sp.Id == product.Id))
                {
                    await _saleProductRepository.Delete(product);
                }
            }

            foreach (var saleProduct in saleProducts)
            {
                saleProduct.SaleId = sale.Id;

                if (saleProduct.Id == 0) // Novo produto
                {
                    var productResult = await _saleProductRepository.Add(saleProduct);
                    if (productResult == null)
                        return Notifies.Error("Erro ao adicionar produto: " + productResult.Message);
                }
                else
                {
                    var existingProduct = await _saleProductRepository.GetById(saleProduct.Id);
                    if (existingProduct != null)
                    {
                        existingProduct.Amount = saleProduct.Amount;
                        var updateResult = await _saleProductRepository.Update(existingProduct);
                        if (updateResult == null)
                            return Notifies.Error("Erro ao atualizar produto: " + updateResult.Message);
                    }
                }
            }

            return Notifies.Success("Venda e produtos atualizados com sucesso!");
        }


        public async Task<Notifies> Delete(int id)
        {
            if (id <= 0)
                return Notifies.Error("Id inválido");

            var result = await _saleRepository.GetById(id);
            if (result == null)
                return Notifies.Error("Venda não encontrada");

            return await _saleRepository.Delete(result);
        }

        public async Task<IEnumerable<Sale>> GetAll()
        {
            var result = await _saleRepository.GetAll();
            var resultWithDetails = new List<Sale>();
            foreach (var sale in result)
            {
                sale.Client = await _clientService.GetById(sale.ClientId);
                sale.Employee = await _employeeService.GetById(sale.EmployeeId);
                resultWithDetails.Add(sale);
            }
            return resultWithDetails;
        }

        public async Task<IEnumerable<Sale>> GetByClient(int idClient)
        {
            return await _saleRepository.GetByClient(idClient);
        }

        public async Task<IEnumerable<Sale>> GetByDate(DateTime date)
        {
            return await _saleRepository.GetByDate(date);
        }

        public async Task<IEnumerable<Sale>> GetByEmployee(int idEmployee)
        {
            return await _saleRepository.GetByEmployee(idEmployee);
        }

        public async Task<Sale> GetById(int id)
        {
            if (id <= 0)
                return null;

            return await _saleRepository.GetById(id);
        }

        public async Task<IEnumerable<Sale>> GetByStatusPayment(EnumStatusPayment statusPayment)
        {
            return await _saleRepository.GetByStatusPayment(statusPayment);
        }

        public async Task<IEnumerable<Sale>> GetByStatusSale(EnumStatusSale statusSale)
        {
            return await _saleRepository.GetByStatusSale(statusSale);
        }

        public async Task<IEnumerable<Sale>> GetByTypePayment(EnumTypePayment typePayment)
        {
            return await _saleRepository.GetByTypePayment(typePayment);
        }
    }
}