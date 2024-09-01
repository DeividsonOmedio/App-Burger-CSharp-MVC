using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Domain.Notifications;

namespace Infrastructure.Repositories
{
    public class SaleProductRepository : ISaleProductRepository
    {
        public Task<Notifies> Add(SaleProduct obj)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Delete(SaleProduct obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<SaleProduct>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SaleProduct> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Update(SaleProduct obj)
        {
            throw new NotImplementedException();
        }
    }
}