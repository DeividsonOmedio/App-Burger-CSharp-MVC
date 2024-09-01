using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Domain.Notifications;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<Notifies> Add(Product obj)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Delete(Product obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Update(Product obj)
        {
            throw new NotImplementedException();
        }
    }
}