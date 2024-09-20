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
                return await _dbSet.Where(x => x.ClientId == clientId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cart> GetByClientIdAndByProduct(int clientId, int productId)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(x => x.ClientId == clientId && x.ProductId == productId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
