using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Interfaces.InterfacesRepositories;
using Domain.Notifications;

namespace Infrastructure.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        public Task<Notifies> Add(Sale obj)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Delete(Sale obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sale>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Sale>> GetByClient(int idClient)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sale>> GetByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sale>> GetByEmployee(int idEmployee)
        {
            throw new NotImplementedException();
        }

        public Task<Sale> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sale>> GetByStatusPayment(EnumStatusPayment statusPayment)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sale>> GetByStatusSale(EnumStatusSale statusSale)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sale>> GetByTypePayment(EnumTypePayment typePayment)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Update(Sale obj)
        {
            throw new NotImplementedException();
        }
    }
}