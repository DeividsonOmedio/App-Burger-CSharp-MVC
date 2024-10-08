using Domain.Entities;
using Domain.Notifications;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IMaterialService
    {
        Task<IEnumerable<Material>> GetAll();
        Task<Material> GetById(int id);
        Task<IEnumerable<Material>> GetByAmount(decimal amount);
        Task<IEnumerable<Material>> GetByMinimumQuantity(decimal minimumQuantity);
        Task<IEnumerable<Material>> GetByPurchasePrice(decimal purchasePrice);
        Task<Material> GetByName(string name);
        Task<Notifies> Add(Material material);
        Task<Notifies> Update(Material material);
        Task<Notifies> Delete(int id);
    }
}