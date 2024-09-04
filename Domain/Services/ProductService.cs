using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Domain.Interfaces.InterfacesServices;
using Domain.Notifications;

namespace Domain.Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;
        public async Task<Notifies> Add(Product product)
        {
            if (product == null)
                return Notifies.Error("Produto inválido");

            return await _productRepository.Add(product);
        }

        public async Task<Notifies> Delete(int id)
        {
            if (id <= 0)
                return Notifies.Error("Id inválido");

            var result = await _productRepository.GetById(id);
            if (result == null)
                return Notifies.Error("Produto não encontrado");

            return await _productRepository.Delete(result);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetById(int id)
        {
            if (id <= 0)
                return null;

            return await _productRepository.GetById(id);
        }

        public async Task<Notifies> Update(Product product)
        {
            if (product == null)
                return Notifies.Error("Produto inválido");

            var result = await _productRepository.GetById(product.Id);

            if (result == null)
                return Notifies.Error("Produto não encontrado");

            return await _productRepository.Update(result);
        }
    }
}