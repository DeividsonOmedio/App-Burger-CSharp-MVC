using Domain.Entities;

namespace Domain.Interfaces.InterfacesRepositories
{
    public interface IMaterialRepository : IGenericRepository<Material>
    {
        Task<IEnumerable<Material>> GetByAmount(decimal amount);
        Task<IEnumerable<Material>> GetByMinimumQuantity(decimal minimumQuantity);
        Task<IEnumerable<Material>> GetByPurchasePrice(decimal purchasePrice);
    }
}