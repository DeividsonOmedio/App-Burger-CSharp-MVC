using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IMaterialService
    {
        Task<IEnumerable<Material>> GetAll();
        Task<Material> GetById(int id);
        Task<IEnumerable<Material>> GetByAmount(decimal amount);
        Task<IEnumerable<Material>> GetByMinimumQuantity(decimal minimumQuantity);
        Task<IEnumerable<Material>> GetByPurchasePrice(decimal purchasePrice);
        Task<Notifies> Add(Material material);
        Task<Notifies> Update(Material material);
        Task<Notifies> Delete(int id);
    }
}