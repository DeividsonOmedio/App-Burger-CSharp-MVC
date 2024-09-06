using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Infrastructure.Configuration;

namespace Infrastructure.Repositories
{
    public class AddressRepository(ContextBase context) : GenericRepository<Address>(context), IAddressRepository
    {
    }
}
