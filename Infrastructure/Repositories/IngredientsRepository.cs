﻿using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class IngredientsRepository(ContextBase context) : GenericRepository<Ingredients>(context), IIngredientsRepository
    {

        public async Task<IEnumerable<Ingredients>> GetByMaterialId(int materialId)
        {
            try
            {
                return await _dbSet.Where(x => x.MaterialId == materialId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Ingredients>> GetByProductId(int productId)
        {
            try
            {
                return await _dbSet.Where(x => x.ProductId == productId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
