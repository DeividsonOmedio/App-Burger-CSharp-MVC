using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesRepositories
{
    public interface IMaterialRepository : IGenericRepository<Material>
    {
        Task<IEnumerable<Material>> GetByAmount(decimal amount);
        Task<IEnumerable<Material>> GetByMinimumQuantity(decimal minimumQuantity);
        Task<IEnumerable<Material>> GetByPurchasePrice(decimal purchasePrice);
    }
}