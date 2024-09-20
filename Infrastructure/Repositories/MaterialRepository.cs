using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MaterialRepository(ContextBase context) : GenericRepository<Material>(context), IMaterialRepository
    {

        public async Task<IEnumerable<Material>> GetByAmount(decimal amount)
        {
            return await _dbSet.Where(x => x.Amount == amount).ToListAsync();
        }

        public async Task<IEnumerable<Material>> GetByMinimumQuantity(decimal minimumQuantity)
        {
            return await _dbSet.Where(x => x.MinimumQuantity == minimumQuantity).ToListAsync();
        }

        public async Task<IEnumerable<Material>> GetByPurchasePrice(decimal purchasePrice)
        {
            return await _dbSet.Where(x => x.PurchasePrice == purchasePrice).ToListAsync();
        }

        public async Task<Material> GetByName(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Name == name);
        }

    }
}
