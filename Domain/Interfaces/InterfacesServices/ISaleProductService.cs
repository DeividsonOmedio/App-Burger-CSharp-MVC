using Domain.Entities;
using Domain.Notifications;

namespace Domain.Interfaces.InterfacesServices
{
    public interface ISaleProductService
    {
        Task<IEnumerable<SaleProduct>> GetAll();
        Task<SaleProduct> GetById(int id);
        Task<IEnumerable<SaleProduct>> GetBySale(int idSale);
        Task<Notifies> Add(SaleProduct saleProduct);
        Task<Notifies> Update(SaleProduct saleProduct);
        Task<Notifies> Delete(int id);
    }
}