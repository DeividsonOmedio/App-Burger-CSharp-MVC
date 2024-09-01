using Domain.Entities;
using Domain.Notifications;

namespace Domain.Interfaces.InterfacesRepositories
{
    public interface IIngredientsRepository
    {
        Task<IEnumerable<Ingredients>> GetByProductId(int productId);
        Task<IEnumerable<Ingredients>> GetByMaterialId(int materialId);
        Task<Notifies> Add(Ingredients ingredients);
        Task<Notifies> Update(Ingredients ingredients);
        Task<Notifies> Delete(int id);
    }
}