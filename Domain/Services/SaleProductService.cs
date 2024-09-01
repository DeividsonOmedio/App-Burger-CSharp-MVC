using Domain.Entities;
using Domain.Interfaces.InterfacesServices;
using Domain.Notifications;

namespace Domain.Services
{
    public class SaleProductService : ISaleProductService
    {
        public Task<Notifies> Add(SaleProduct saleProduct)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SaleProduct>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SaleProduct> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SaleProduct>> GetByProduct(int idProduct)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SaleProduct>> GetBySale(int idSale)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Update(SaleProduct saleProduct)
        {
            throw new NotImplementedException();
        }
    }
}