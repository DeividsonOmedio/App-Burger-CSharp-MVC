using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Domain.Notifications;

namespace Infrastructure.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        public Task<Notifies> Add(Material obj)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Delete(Material obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<Material>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Material>> GetByAmount(decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task<Material> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Material>> GetByMinimumQuantity(decimal minimumQuantity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Material>> GetByPurchasePrice(decimal purchasePrice)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Update(Material obj)
        {
            throw new NotImplementedException();
        }
    }
}
