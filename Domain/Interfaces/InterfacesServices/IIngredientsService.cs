using Domain.Entities;
using Domain.Notifications;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IIngredientsService
    {
        Task<IEnumerable<Ingredients>> GetByProductId(int productId);
        Task<IEnumerable<Ingredients>> GetByMaterialId(int materialId);
        Task<Ingredients> GetByMaterialIdByProductId(int materialId, int productId);
        Task<Dictionary<string, decimal>> GetMaterialsByProductId(int productId);
        Task<Notifies> Add(Ingredients ingredients);
        Task<Notifies> Update(Ingredients ingredients);
        Task<Notifies> Delete(int id);
    }
}