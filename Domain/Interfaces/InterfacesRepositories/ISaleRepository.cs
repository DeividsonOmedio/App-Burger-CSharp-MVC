using Domain.Entities;
using Domain.Entities.Enums;

namespace Domain.Interfaces.InterfacesRepositories
{
    public interface ISaleRepository : IGenericRepository<Sale>
    {
        Task<List<Sale>> GetByClient(int idClient);
        Task<List<Sale>> GetByEmployee(int idEmployee);
        Task<List<Sale>> GetByDate(DateTime date);
        Task<List<Sale>> GetByTypePayment(EnumTypePayment typePayment);
        Task<List<Sale>> GetByStatusPayment(EnumStatusPayment statusPayment);
        Task<List<Sale>> GetByStatusSale(EnumStatusSale statusSale);
    }
}