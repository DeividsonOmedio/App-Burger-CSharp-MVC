using Domain.Entities;

namespace Domain.Interfaces.InterfacesRepositories
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<List<Address>> GetByClientId(int clientId);
    }
}
