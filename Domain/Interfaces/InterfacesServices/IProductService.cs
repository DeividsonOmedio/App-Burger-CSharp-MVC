using Domain.Entities;
using Domain.Notifications;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Notifies> Add(Product product);
        Task<Notifies> Update(Product product);
        Task<Notifies> Delete(int id);

    }
}