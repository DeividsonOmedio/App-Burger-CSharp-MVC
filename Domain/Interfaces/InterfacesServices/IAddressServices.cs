using Domain.Entities;
using Domain.Notifications;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IAddressServices
    {
        Task<Notifies> Add(Address address);
        Task<Notifies> Update(Address address);
        Task<Notifies> Delete(int id);
        Task<Address> GetById(int id);
        Task<List<Address>> GetByClientId(int clientId);
        Task<List<Address>> GetAll();
    }
}
