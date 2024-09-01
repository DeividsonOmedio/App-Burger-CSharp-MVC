using Domain.Entities;
using Domain.Interfaces.InterfacesServices;
using Domain.Notifications;

namespace Domain.Services
{
    public class IngredientsService : IIngredientsService
    {
        public Task<Notifies> Add(Ingredients ingredients)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ingredients>> GetByMaterialId(int materialId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ingredients>> GetByProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Update(Ingredients ingredients)
        {
            throw new NotImplementedException();
        }
    }
}