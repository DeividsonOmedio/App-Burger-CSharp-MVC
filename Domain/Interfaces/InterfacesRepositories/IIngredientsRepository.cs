using Domain.Entities;

namespace Domain.Interfaces.InterfacesRepositories
{
    public interface IIngredientsRepository : IGenericRepository<Ingredients>
    {
        Task<IEnumerable<Ingredients>> GetByProductId(int productId);
        Task<IEnumerable<Ingredients>> GetByMaterialId(int materialId);
    }
}