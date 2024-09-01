using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Domain.Notifications;

namespace Infrastructure.Repositories
{
    public class IngredientsRepository : IIngredientsRepository
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
