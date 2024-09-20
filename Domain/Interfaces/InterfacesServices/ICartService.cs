using Domain.Entities;
using Domain.Notifications;

namespace Domain.Interfaces.InterfacesServices
{
    public interface ICartService
    {
        Task<List<Cart>> GetByClientId(int clientId);
        Task<Cart> GetByClientIdAndByProduct(int clientId, int productId);
        Task<Cart> GetById(int id);
        Task<Notifies> Add(Cart cart);
        Task<Notifies> Update(Cart cart);
        Task<Notifies> Delete(int id);
    }
}
