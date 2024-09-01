using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices
{
    public interface ISaleService
    {
        Task<IEnumerable<Sale>> GetAll();
        Task<Sale> GetById(int id);
        Task<IEnumerable<Sale>> GetByClient(int idClient);
        Task<IEnumerable<Sale>> GetByEmployee(int idEmployee);
        Task<IEnumerable<Sale>> GetByDate(DateTime date);
        Task<IEnumerable<Sale>> GetByTypePayment(EnumTypePayment typePayment);
        Task<IEnumerable<Sale>> GetByStatusPayment(EnumStatusPayment statusPayment);
        Task<IEnumerable<Sale>> GetByStatusSale(EnumStatusSale statusSale);
        Task<Notifies> Add(Sale sale);
        Task<Notifies> Update(Sale sale);
        Task<Notifies> Delete(int id);
    }
}