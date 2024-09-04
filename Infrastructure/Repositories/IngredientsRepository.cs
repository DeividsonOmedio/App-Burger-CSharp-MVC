using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Infrastructure.Configuration;
using System.Data.Entity;

namespace Infrastructure.Repositories
{
    public class IngredientsRepository(ContextBase context) : GenericRepository<Ingredients>(context), IIngredientsRepository
    {

        public async Task<IEnumerable<Ingredients>> GetByMaterialId(int materialId)
        {
            return await _dbSet.Where(x => x.MaterialId == materialId).ToListAsync();
        }

        public async Task<IEnumerable<Ingredients>> GetByProductId(int productId)
        {
            return await _dbSet.Where(x => x.ProductId == productId).ToListAsync();
        }
    }
}
