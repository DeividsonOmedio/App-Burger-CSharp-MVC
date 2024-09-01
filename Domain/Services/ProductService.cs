using Domain.Entities;
using Domain.Interfaces.InterfacesServices;

namespace Domain.Services
{
    public class ProductService : IProductService
    {
        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}