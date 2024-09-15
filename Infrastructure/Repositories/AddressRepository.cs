using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Domain.Notifications;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AddressRepository(ContextBase context) : GenericRepository<Address>(context), IAddressRepository
    {
        public async Task<List<Address>> GetByClientId(int clientId)
        {
            try
            {
                var result = await _dbSet.Where(a => a.ClientId == clientId).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
