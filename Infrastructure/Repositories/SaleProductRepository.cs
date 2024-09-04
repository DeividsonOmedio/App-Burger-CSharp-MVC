using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SaleProductRepository(ContextBase context) : GenericRepository<SaleProduct>(context), ISaleProductRepository
    {
        public async Task<IEnumerable<SaleProduct>> GetBySale(int idSale)
        {
            return await _dbSet.Where(s => s.SaleId == idSale).ToListAsync();
        }
    }
}