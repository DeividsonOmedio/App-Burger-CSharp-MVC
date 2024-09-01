using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesRepositories
{
    public interface IIngredientsRepository
    {
        Task<IEnumerable<Ingredients>> GetByProductId(int productId);
        Task<IEnumerable<Ingredients>> GetByMaterialId(int materialId);
        Task<Notifies> Add(Ingredients ingredients);
        Task<Notifies> Update(Ingredients ingredients);
        Task<Notifies> Delete(int id);
    }
}