using Domain.Entities;
using Domain.Interfaces.InterfacesServices;
using Domain.Notifications;

namespace Domain.Services
{
    public class MaterialService : IMaterialService
    {
        public Task<Notifies> Add(Material material)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Material>> GetAll()
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

        public Task<Notifies> Update(Material material)
        {
            throw new NotImplementedException();
        }
    }
}