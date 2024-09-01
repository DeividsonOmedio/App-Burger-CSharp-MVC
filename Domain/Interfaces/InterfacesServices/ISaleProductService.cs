using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices
{
    public interface ISaleProductService
    {
        Task<IEnumerable<SaleProduct>> GetAll();
        Task<SaleProduct> GetById(int id);
        Task<IEnumerable<SaleProduct>> GetBySale(int idSale);
        Task<IEnumerable<SaleProduct>> GetByProduct(int idProduct);
        Task<Notifies> Add(SaleProduct saleProduct);
        Task<Notifies> Update(SaleProduct saleProduct);
        Task<Notifies> Delete(int id);
    }
}