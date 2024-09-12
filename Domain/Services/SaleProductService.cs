using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Domain.Interfaces.InterfacesServices;
using Domain.Notifications;

namespace Domain.Services
{
    public class SaleProductService(ISaleProductRepository saleProductRepository, IProductRepository productRepository) : ISaleProductService
    {
        private readonly ISaleProductRepository _saleProductRepository = saleProductRepository;
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<Notifies> Add(SaleProduct saleProduct)
        {
            if (saleProduct == null)
                return Notifies.Error("Produto inválido");

            return await _saleProductRepository.Add(saleProduct);
        }

        public async Task<Notifies> Delete(int id)
        {
            if (id <= 0)
                return Notifies.Error("Id inválido");

            var result = await _saleProductRepository.GetById(id);
            if (result == null)
                return Notifies.Error("Produto não encontrado");

            return await _saleProductRepository.Delete(result);
        }

        public async Task<IEnumerable<SaleProduct>> GetAll()
        {
            var result = await _saleProductRepository.GetAll();
            if (result == null)
                return null;
            var resulWithDetails = new List<SaleProduct>();
            foreach ( var item in result)
            {
                item.Product = await _productRepository.GetById(item.ProductId);
                resulWithDetails.Add(item);
            }
            return resulWithDetails;
        }

        public async Task<SaleProduct> GetById(int id)
        {
            if (id <= 0)
                return null;

            return await _saleProductRepository.GetById(id);
        }

        public async Task<IEnumerable<SaleProduct>> GetBySale(int idSale)
        {
            var result = await _saleProductRepository.GetBySale(idSale);
            if (result == null)
                return null;
            var resulWithDetails = new List<SaleProduct>();
            foreach (var item in result)
            {
                item.Product = await _productRepository.GetById(item.ProductId);
                resulWithDetails.Add(item);
            }
            return resulWithDetails;
        }

        public async Task<Notifies> Update(SaleProduct saleProduct)
        {
            if (saleProduct == null)
                return Notifies.Error("Produto inválido");

            var result = await _saleProductRepository.GetById(saleProduct.Id);

            if (result == null)
                return Notifies.Error("Produto não encontrado");

            return await _saleProductRepository.Update(result);
        }
    }
}