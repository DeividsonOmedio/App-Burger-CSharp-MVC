
using Domain.Entities;

namespace Domain.Interfaces.InterfacesRepositories
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<List<Cart>> GetByClientId(int clientId);
        Task<Cart> GetByClientIdAndByProduct(int clientId, int productId);
    }
}
