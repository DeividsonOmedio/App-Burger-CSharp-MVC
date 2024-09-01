using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Interfaces.InterfacesServices;
using Domain.Notifications;

namespace Domain.Services
{
    public class SaleService : ISaleService
    {
        public Task<Notifies> Add(Sale sale)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sale>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sale>> GetByClient(int idClient)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sale>> GetByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sale>> GetByEmployee(int idEmployee)
        {
            throw new NotImplementedException();
        }

        public Task<Sale> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sale>> GetByStatusPayment(EnumStatusPayment statusPayment)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sale>> GetByStatusSale(EnumStatusSale statusSale)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sale>> GetByTypePayment(EnumTypePayment typePayment)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Update(Sale sale)
        {
            throw new NotImplementedException();
        }
    }
}