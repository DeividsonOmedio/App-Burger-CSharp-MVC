using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CartRepository(ContextBase context) : GenericRepository<Cart>(context), ICartRepository
    {
        public async Task<List<Cart>> GetByClientId(int clientId)
        {
            try
            {
                return await _context.Carts.Where(x => x.ClientId == clientId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
