using Domain.Entities;

namespace Domain.Interfaces.InterfacesRepositories
{
    public interface ISaleProductRepository : IGenericRepository<SaleProduct>
    {
        Task<IEnumerable<SaleProduct>> GetBySale(int idSale);
    }
}